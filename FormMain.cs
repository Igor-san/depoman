using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using DepoMan.Classes;
using DepoMan.Components;
using DepoMan.Forms;

namespace DepoMan
{
    public partial class FormMain : Form
    {
        //для освобождения памяти, а то под Windows 7 x64 растет и не уменьшается
        [DllImport("kernel32.dll")]
        public static extern bool SetProcessWorkingSetSize(IntPtr handle, int minimumWorkingSetSize, int maximumWorkingSetSize);

        [DllImport("kernel32.dll")]
        public static extern bool GetVersionEx([In, Out] OSVersionInfo osvi);

        public DatabaseClass DataBase = null;

        private MRUMenuItem mRecent = new MRUMenuItem();
        private bool FormFirstLoad = true; //форма только загружается, к базе обращаться нельзя
        private bool boolFirstAutoLoad = false; //чтобы предотвратить сохранение параметров при первом  boolAutoLoadLastDataBase

        List<int> OverdueDeposits=new List<int>(); //Просроченные депозиты, срок которых истек (< End Date)
        List<int> DeadlineDeposits = new List<int>();  //истекающие депозиты, срок которых больше сегодняшнего и меньше сегодня +Common.ProgramSettings.RemindPriorEndDepositDays
        bool AllowClose = false; //чтобы закрыть программу минуя проверку CloseReason.UserClosing
        FormWindowState OldWindowState = FormWindowState.Normal;

        public FormMain()
        {
            FormFirstLoad = true;

            Thread.CurrentThread.CurrentUICulture = Application.CurrentCulture;
            Thread.CurrentThread.CurrentCulture = Application.CurrentCulture;

            InitializeComponent();

            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);

            //получим версию ОС
            Global.OSVI = new OSVersionInfo();
            Global.OSVI.dwOSVersionInfoSize = Marshal.SizeOf(Global.OSVI);
            GetVersionEx(Global.OSVI);


            string swin7 = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData); //Эта папка еще не создана при первом запуске! +"\\" + Constants.AppDataPath + "\\";
            //Надо приучаться хранить все данные в специальной пользовательской директории
            if ((Global.OSVI.dwMajorVersion > 5) && (System.IO.Directory.Exists(swin7)))
            {
                //Common.ProgramDataPath = swin7;//Для Виста и Семерки
                Common.Vista = true;

                //MessageBox.Show("Vista");

                try
                {
                    
                   bool portable = Common.Portable; // GetUserRight();
         
                    if (portable)
                    {
                      
                        Common.UserAppDataPath = Common.ProgramDataPath;
                 
                    }
                    else
                    {
                        if (!Directory.Exists(Common.UserAppDataPath)) //Похоже, первый запуск непортальной версии
                        {
                       
                            string error = "";
                            bool res = Utils.CreateUserAppDataPath(out error);
                            if (!res)
                            {

                                MessageBox.Show("Ошибка создания директории " + Common.UserAppDataPath + " и необходимых файлов:"+error);
                            }

                        }

                    }
                }
                catch (Exception ex)
                {

                }

            }
            else
            {
                Common.Vista = false;
                //MessageBox.Show("XP");
                Common.ProgramDataPath = Environment.CurrentDirectory + "\\";
                Common.UserAppDataPath = Common.ProgramDataPath;
            }

            Logger.CriticalErrorOccurred += new EventHandler(CriticalErrorOccurred);

            #region Initialize DataBase
            DataBase = new DatabaseClass();
            DataBase.OnDataBaseModified += new EventHandler(WhenDataBaseModified);
            DataBase.OnDataBaseOpen += new EventHandler(WhenDataBaseOpen);
            DataBase.OnDataBaseClose += new EventHandler(WhenDataBaseClose);
            DataBase.OnDataBaseSaved += new EventHandler(WhenDataBaseSaved);

            DataBase.OnDataBaseModified += new EventHandler(WhenDataBaseModified);
            #endregion Initialize DataBase

            LoadSettings(); //прочитаем настройки программы

            #region Initialize Menu
            mRecent.Name = "LastOpenedFiles";
            mRecent.Text = "Последние файлы"; //Заглавие пункта меню
            fileToolStripMenuItem.DropDownItems.Insert(fileToolStripMenuItem.DropDownItems.Count, mRecent);

           
            string[] stringMRU = new string[0];
            if (Common.ProgramSettings.LastOpenFiles != null)
            {

                stringMRU = OtherFunctions.RemoveEmptyLines(Common.ProgramSettings.LastOpenFiles);

            }
            int maxLast = Common.ProgramSettings.MaxLastOpenFiles;
            if (maxLast <= 0)
            {
                maxLast = Constants.MaxLastOpenFiles;
                Common.ProgramSettings.MaxLastOpenFiles = maxLast;
            }
            mRecent.InitializeFromConfig(stringMRU, maxLast);
            mRecent.MRUClicked += new EventHandler(MRUClick);
            mRecent.MRUChanged += new EventHandler(MRUChanged);
            #endregion Initialize Menu

             
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            AmountInfoClear();

            labelErrorProvider.Text = "";
            statusMessagePanel.ProgressVisible = false;
            statusMessagePanel.HidePanel();
            GetModifiedStatus();
            WhenDataBaseClose(this, null);

            if (Common.ProgramSettings.AutoLoadLastDataBase) //автозагрузка последней базы данных
            {
                if ((mRecent.MRUFiles != null) && (mRecent.MRUFiles.GetLength(0) > 0) && (mRecent.MRUFiles[0] != "") && (System.IO.File.Exists(mRecent.MRUFiles[0])))
                {
                    string fileName = mRecent.MRUFiles[0];
                    boolFirstAutoLoad = true; //первое автооткрытие не должно вызывать сохранение настроек
                    bool open = OpenDatabase(fileName); //Форма остается на заднем плане и this.BringToFront(); не помогает

                    if (!open)
                    {
                        //Нужно удалить из последних имя вызвавшее сбой
                        mRecent.RemoveMru(fileName);
                        Common.ProgramSettings.LastOpenFiles = OtherFunctions.RemoveStringFromLines(fileName, Common.ProgramSettings.LastOpenFiles);
                    }
                }
            }


            FormFirstLoad = false; //закончили загрузку формы

            #region Minimixe on TaskBar
            if (Common.ProgramSettings.MinimizeOnStart)
            {
                HideMainForm();

            }
            else
            {
                SetWindowState(); //Размер, место формы, сплиттеры если не минимизировано
            }
            #endregion Minimixe on TaskBar

            Global.LastInitialDirectory=String.Empty; // Пусть всегда открывается из нужных папок


        }


        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                //Если это пользователь кликнул на закрытии, то минимизируем в трей
                bool minimizeInsteadClose = Common.ProgramSettings.MinimizeInsteadClose;

                if (minimizeInsteadClose && e.CloseReason == CloseReason.UserClosing & !AllowClose)  //AllowClose true по нажатию Выход - кнопок
                {
                    e.Cancel = true;

                    HideMainForm();
                    return;
                }
                //Иначе это выход из программы
                #region Сохраним кое-какие настройки
                ApplySetting();
                Common.ProgramSettings.SaveAppSettings();
                #endregion Сохраним кое-какие настройки

                CloseDatabase();
            }
            catch (Exception ex)
            {
                ErrorMessage("Ошибка при закрытии программы");
            }
        }

        private void CriticalErrorOccurred(object sender, EventArgs e)
        {
            Logger logger = sender as Logger;
            if (logger != null)
            {

                string message = String.Format(Constants.Messages.ErrorMessage, logger.LastErrorMessage);
                ErrorWindow ew = new ErrorWindow(message, null);
                ew.ShowDialog();
                // Determine if the OK button was clicked on the dialog box.
                if (ew.DialogResult == DialogResult.OK)
                {
                    // Display a message box indicating that the OK button was clicked.
                    //Application.Exit();
                    Application.ExitThread();
                    //Close();
                }
                else
                {
            
                    return;
                }


            }
        }

        private void SetWindowState()
        {
            if (Common.ProgramSettings.WindowState != FormWindowState.Minimized) //если мы закрылись при минимизации, но следующий запуск определяет настройками "Сворачивать при старте"!
            {
                this.WindowState = Common.ProgramSettings.WindowState; ///Нужно именно здесь, иначе сбрасывается в Normal
            
               if (this.WindowState == FormWindowState.Normal)
                {
                    if (Common.ProgramSettings.WindowHeight > 10) this.Height = Common.ProgramSettings.WindowHeight;
                    if (Common.ProgramSettings.WindowWidth > 10) this.Width = Common.ProgramSettings.WindowWidth;
                }
            }


        }

        private void MRUClick(object sender, System.EventArgs e)
        {
            ToolStripMenuItem mSender = sender as ToolStripMenuItem;

            WhenDataBaseClose(this, null);
            OpenFile(mSender.Text);

        }

        private void MRUChanged(object sender, System.EventArgs e)
        {
        
        }

        /// <summary>
        /// Initialization of settings stored in cfg-file
        /// </summary>
        private void LoadSettings()
        {

            Common.ProgramSettings = new ProgramSettings();
            Common.ProgramSettings.SetFirstLoad(true); //Запрещает событие SettingChanged()

            Common.ProgramSettings.LoadAppSettings(); //загружаем настройки программы
   
            Common.ProgramSettings.Changed += new EventHandler(SettingsChanged);
            Common.ProgramSettings.SetFirstLoad(false); //а теперь позволим изменениям вызывать SettingChanged()
        }

        /// <summary>
        /// Произошли изменения в ProgramOptionsForm ( )
        /// </summary>
        private void SettingsChanged(object sender, EventArgs e)
        {
            try
            {

                Common.ProgramSettings.SaveAppSettings();
            }
            catch (Exception ex)
            {

                StatusMessage("Ошибка в SettingsChanged: " + ex.Message);
                return;
            }

        }

        /// <summary>
        /// Применим некоторые настройки, которые не сохраняются автоматически
        /// </summary>
        private void ApplySetting()
        {
            Common.ProgramSettings.SetFirstLoad(true); //чтобы не дергать на следующем изменении, все равно выходим
            Common.ProgramSettings.LastOpenFiles = OtherFunctions.RemoveEmptyLines(mRecent.MRUFiles); //Сохраним ранее открытые файлы

            Common.ProgramSettings.WindowState = this.WindowState;

            Common.ProgramSettings.WindowHeight = this.Height;
            Common.ProgramSettings.WindowWidth = this.Width;
            //  Common.ProgramSettings.SetFirstLoad(false); 
        }

        #region Messages
        /// <summary>
        /// Сообщаем об ошибке в панели со значком ошибки
        /// </summary>
        /// <param name="error"></param>
        private void ErrorMessage(string error)
        {
            // MessageBox.Show(error);
            statusMessagePanel.StatusMessage(error, MessagesTypes.Error);
            statusMessagePanel.UnHidePanel();
        }
        /// <summary>
        /// Сообщение в панели сообщений без значка
        /// </summary>
        /// <param name="text"></param>
        private void StatusMessage(string text)
        {
            statusMessagePanel.StatusMessage(text);
            statusMessagePanel.UnHidePanel();

        }
        /// <summary>
        /// Сообщение в панели с заданным значком
        /// </summary>
        /// <param name="text"></param>
        /// <param name="type"></param>
        private void StatusMessage(string text, MessagesTypes type)
        {
            statusMessagePanel.StatusMessage(text, type);
            statusMessagePanel.UnHidePanel();
        }
        /// <summary>
        /// Дополнительная информация о базе данных в строке состояния
        /// </summary>
        /// <param name="msg"></param>
        private void InfoDB(string msg)
        {
            infoDBLabel.Text = msg;
        }
        /// <summary>
        /// Открыта,закрыта,модифицирована ли базаданных
        /// </summary>
        /// <param name="msg"></param>
        private void StatusDB(string msg)
        {
            statusDBLabel.Text = msg;
        }

        /// <summary>
        /// Отображение сообщения в трее
        /// </summary>
        /// <param name="msg"></param>
        public void TrayMessage(string msg, MessagesTypes type)
        {
            switch (type)
            {
                case MessagesTypes.Info:
                    notifyIconMain.BalloonTipIcon = ToolTipIcon.None;
                    break;
                case MessagesTypes.Attention: //Важная инфа к вниманию
                    notifyIconMain.BalloonTipIcon = ToolTipIcon.Info;
                    break;

                case MessagesTypes.Warning: //Предупреждение
                    notifyIconMain.BalloonTipIcon = ToolTipIcon.Warning;
                    break;
                case MessagesTypes.Error:  //Ошибка
                    notifyIconMain.BalloonTipIcon = ToolTipIcon.Error;
                    break;
            }
            string time = DateTime.Now.ToString();

            notifyIconMain.BalloonTipText = time + ": " + msg;
            notifyIconMain.BalloonTipTitle = Constants.ProgramFullName;
            notifyIconMain.ShowBalloonTip(10000); //минимум 10 и максимум 30 секунд как в системе
        }
        #endregion Messages


        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AllowClose = true;
            Close();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AllowClose = true;
            Close();
        }


        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm frm = new AboutForm();
            frm.ShowDialog();
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

                if (!DataBase.DBOpened)
                {
                    OpenFile(String.Empty);

                }
                else
                {
                    CloseDatabase();
                }


            }
            catch (Exception ex)
            {
                openFileToolStripMenuItem.Text = "Открыть";

                string msg = "Ошибка открытия файла : " + ex.Message;
                Logger.HandleNonCriticalError(msg, ex, false);
            }
        }

        private void CloseDatabase()
        {

            if (DataBase.ModifiedDB)
            {

               if (Common.ProgramSettings.AutoSaveDataBaseOnClose)
                {
                    if (DataBase.SaveDBAs(DataBase.DBFileName))
                    {
                        ;
                    }
                    else
                    {
                        MessageBox.Show("Ошибка сохранения " + DataBase.DBFileName + " (" + DataBase.LastError + ")", "Ошибка сохранения базы", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else
                {
                    string msg = "";
 
                    if (MessageBox.Show("База данных изменена, " +
                           " сохранить её?", "База данных изменена",
    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        if (DataBase.SaveDBAs(DataBase.DBFileName))
                        {
                            ;
                        }
                        else
                        {
                            MessageBox.Show("Ошибка сохранения " + DataBase.DBFileName + " (" + DataBase.LastError + ")", "Ошибка сохранения базы", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }

            ClearDataSource(); //Обнуляем Источник данных и устанавливаем отображение по умолчанию.

            DataBase.CloseDB();
            GetModifiedStatus();
   


        }

        private void GetModifiedStatus()
        {
            string msg = "";
            //установим сообщение об измененных таблиц 

            if (!DataBase.DBOpened)
            {
                StatusDB("Закрыта");
                InfoDB("");
                return;
            }

            if (!DataBase.ModifiedDB) 
            {
                msg = "База не изменялась";
                StatusDB("Открыта");
            }
            else
            {
                msg = "Изменены таблицы: ";
                if ((DataBase.ModifiedDeposits)) msg += "депозитов,";
                if ((DataBase.ModifiedBanks)) msg += "банков,";
                if ((DataBase.ModifiedCurrency)) msg += "валют,";
                if ((DataBase.ModifiedClients)) msg += "клиентов,";
                if ((DataBase.ModifiedConfig)) msg += "настроек,";

                msg = msg.TrimEnd(new char[1] { ',' });
                StatusDB("Изменена");
            }
            
            InfoDB(msg);

        }



        private void OpenFile(string fileName)
        {
            //Определим, какой файл открываем и пошлем по нужному адресу
            bool open = false;
            if (fileName == String.Empty)
            {
                if (Global.LastInitialDirectory == String.Empty) Global.LastInitialDirectory = Constants.DataBasesPath;
                OpenFileDialog openDB = new OpenFileDialog();
                #region Set openDB Dialog Properties
                openDB.InitialDirectory = Global.LastInitialDirectory;
                openDB.Title = "Открыть...";
                openDB.CheckFileExists = true;
                openDB.Multiselect = false;
                openDB.Filter = Constants.FilterDataBase;

                #endregion

                if (openDB.ShowDialog() == DialogResult.OK)
                {
                    fileName = openDB.FileName;
                    open=OpenDatabase(fileName);

                    Global.LastInitialDirectory = openDB.FileName.GetDirectoryName();
                }
                else
                {
                    WhenDataBaseClose(this, null);
                    return; //пользователь не стал открывать файл
                }

            }
            else if (System.IO.File.Exists(fileName))
            {
               open= OpenDatabase(fileName);
            }
            else
            {
                MessageBox.Show("File '" + fileName + "' is missing");
                return;// чтобы не попадать в mRecent.FileOpened(file);

            }

            string firstMRUFile = "";
            if ((mRecent != null) && (mRecent.MRUFiles.GetLength(0) > 0))
            {
                firstMRUFile = mRecent.MRUFiles[0];
            }
            if (open)
            {
                mRecent.FileOpened(fileName);
            }
            else
            {
               fileToolStripMenuItem.DropDownItems.RemoveByKey(fileName);
            }

            if (boolFirstAutoLoad)
            {
                boolFirstAutoLoad = false; //при следующих открытиях будем вызывать Settings.SettingChanged()
            }
            else
            {
                if (open && fileName != firstMRUFile) //открываем файл что и в прошлый раз и не меняем Settings. Но при условии что файл открылся нормально
                    Common.ProgramSettings.SettingChanged();

            }
      

        }

        public bool OpenDatabase(string fileName)
        {
            Cursor.Current = Cursors.WaitCursor;

            if (!DataBase.OpenDB(fileName))
            {
                MessageBox.Show(DataBase.LastError, "Ошибка открытия базы данных", MessageBoxButtons.OK, MessageBoxIcon.Error);

                WhenDataBaseClose(this, null);
                return false; //если сбой при открытии то не инициализируем датагрид
            }

            ClearDataSource();//на всякий случай, иногда при необработанных ошибках не вызывается DataGridViewClear()

           SetDataSource();

            return true;
        }

        private void ClearDataSource()
        {

            dataGridViewDeposits.DataSource = null;
            dataGridViewDeposits.Columns.Clear();
             
        }

        private void SetDataSource()
        {
              SetDataGridViewDeposits();
        }

        private void saveFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFile();
        }

        private void SaveFile()
        {
            if (DataBase.DataSetAccount == null)
            {
                MessageBox.Show("ДатаСет пустой", "Базы данных отсутствует", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (DataBase.SaveDBAs(DataBase.DBFileName))
            {
                GetModifiedStatus();
                InfoDB("Сохранена");
            }
            else
            {
                MessageBox.Show("Ошибка сохранения " + DataBase.DBFileName + " (" + DataBase.LastError + ")", "Ошибка сохранения базы данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

           
        }

        private void WhenDataBaseClose(object sender, EventArgs e)
        {
            //действия после закрытия базы
            this.Text = Constants.ProgramFullName;

            openFileToolStripMenuItem.Text = "Открыть";

            saveFileToolStripMenuItem.Enabled = false;
            Cursor.Current = Cursors.Default;

            EnableAnyButton(false);

            AmountInfoClear();
        }

        private void WhenDataBaseOpen(object sender, EventArgs e)
        {

            this.Text = Constants.ProgramFullName + " " + DataBase.DBFileName;

            openFileToolStripMenuItem.Text = "Закрыть";
            saveFileToolStripMenuItem.Enabled = true;
            //historyBindingNavigator.Enabled = true;

            Cursor.Current = Cursors.Default;

            GetModifiedStatus();
            EnableAnyButton(true);

            if (Common.ProgramSettings.RemindPriorEndDeposit) RemindPriorEndDeposit(); //Если настроено, проверим заканчивающиеся депозиты 

            if (Common.ProgramSettings.RemindInterestPayment) RemindInterestPayment(); //Проверим выплаты по вкладам

            GetAmountInfo(); //Получим инфо о вкладах
           // bindingNavigatorCountItem.Enabled = false;

        }

        private void WhenDataBaseModified(object sender, EventArgs e)
        {
           
            GetModifiedStatus();
        }

        private void WhenDataBaseSaved(object sender, EventArgs e)
        {
            //действия после сохранения базы

            GetModifiedStatus();
            InfoDB("Сохранена");
        }

        private void createNewToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (DataBase.DBOpened)
            {
                if (MessageBox.Show("Открытая база данных будет закрыта, " +
                " продолжить?", "Необходимо закрыть текущую базу данных",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    CloseDatabase();
                }
                else
                {
                    return;
                }
            }

            bool result = DataBase.CreateNewDB();

            if (result)
            {
                
                ClearDataSource();

                SetDataSource();
  
                WhenDataBaseOpen(null, null);
                InfoDB("База данных успешно создана, можно с ней работать");
                StatusDB("Создана");

                MessageBox.Show("База создана. Теперь нужно заполнить справочники Банков, Валют и Клиентов. После чего можно приступать к заполнению депозитов.",
                    "Создана новая база", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                StatusDB("Закрыта");
                StatusMessage(DataBase.LastError);
            
            }

        }

        private void EnableAnyButton(bool value)
        {
            
            referenceToolStripMenuItem.Enabled = value; //при закрытой базе к справочникам доступа нет
        }
        /// <summary>
        /// Подготовим вывод депозитов
        /// </summary>
        private void SetDataGridViewDeposits()
        {
            #region dataGridViewDeposits
            //Стиль комбобоксов
            DataGridViewCellStyle styleCol = new DataGridViewCellStyle();

            dataGridViewDeposits.AutoGenerateColumns = false;

            dataGridViewDeposits.Columns.Clear();

            #region DeleteButton
            DeleteTextColumn colDelete = new DeleteTextColumn();
            colDelete.Frozen = true;
            colDelete.HeaderText = "Х";
            colDelete.Name = "MyDelete";
            colDelete.ToolTipText = "Удалить депозит";

            dataGridViewDeposits.Columns.Add(colDelete);
           
            #endregion DeleteButton

            #region EditButton

            EditButtonColumn colEdit = new EditButtonColumn();
            colEdit.Frozen = true;
            colEdit.HeaderText = "Х";
            colEdit.Name = "MyEdit";
            colEdit.ToolTipText = "Редактировать депозит";
            colEdit.ReadOnly = true;
            dataGridViewDeposits.Columns.Add(colEdit);

            #endregion EditButton

            #region Индекс
            DataGridViewTextBoxColumn colIndex = new DataGridViewTextBoxColumn();
            colIndex.Name = Constants.DepositsIndex;// "DepositsIndex"; 
            colIndex.DataPropertyName = Constants.DepositsIndex;
            colIndex.HeaderText = "Индекс";
            
            colIndex.Width = 100;
            colIndex.ReadOnly = true;
            dataGridViewDeposits.Columns.Add(colIndex);
            #endregion Индекс

            #region DepositsName
            DataGridViewTextBoxColumn colDepositsName = new DataGridViewTextBoxColumn();
            colDepositsName.Name = Constants.DepositsName; 
            colDepositsName.DataPropertyName = Constants.DepositsName;
            colDepositsName.HeaderText = "Название";
            colDepositsName.MaxInputLength = Constants.MaxInputTextLength;
            colDepositsName.Width = 200;
            colDepositsName.ReadOnly = true;
            dataGridViewDeposits.Columns.Add(colDepositsName);
            #endregion DepositsName

            #region DepositsAmount
            DataGridViewTextBoxColumn colDepositsAmount = new DataGridViewTextBoxColumn();
            colDepositsAmount.Name = Constants.DepositsAmount; 
            colDepositsAmount.DataPropertyName = Constants.DepositsAmount;
            colDepositsAmount.HeaderText = "Сумма";
            colDepositsAmount.Width = 100;
            colDepositsAmount.ReadOnly = true;
            colDepositsAmount.SortMode = DataGridViewColumnSortMode.Automatic; 
            dataGridViewDeposits.Columns.Add(colDepositsAmount);
            #endregion DepositsAmount

            #region DepositsPercent
            DataGridViewTextBoxColumn colDepositsPercent = new DataGridViewTextBoxColumn();
            colDepositsPercent.Name = Constants.DepositsPercent; 
            colDepositsPercent.DataPropertyName = Constants.DepositsPercent;
            colDepositsPercent.HeaderText = "%";
            colDepositsPercent.Width = 40;
            colDepositsPercent.MaxInputLength = 6;///!!! думаю 999,99 % вряд ли превысят
            colDepositsPercent.ReadOnly = true;
            colDepositsPercent.SortMode = DataGridViewColumnSortMode.Automatic;       
            dataGridViewDeposits.Columns.Add(colDepositsPercent);
            #endregion DepositsPercent

            #region DateStart
            CalendarColumn cellDate = new CalendarColumn();
            cellDate.Name = Constants.DepositsDateStart;
            cellDate.DataPropertyName = Constants.DepositsDateStart;
            cellDate.Width = 100;
            //cellDate.DefaultCellStyle.BackColor = Constants.HistoryDateColumnBackColor;
            cellDate.HeaderText = "Начало";
   
            cellDate.ReadOnly = true;
            cellDate.SortMode = DataGridViewColumnSortMode.Automatic;
            dataGridViewDeposits.Columns.Add(cellDate);
            #endregion DateStart

            #region DepositsDateEnd
            CalendarColumn cellDateEnd = new CalendarColumn();
            cellDateEnd.Name = Constants.DepositsDateEnd;
            cellDateEnd.DataPropertyName = Constants.DepositsDateEnd;
            cellDateEnd.Width = 100;
            cellDateEnd.HeaderText = "Окончание";
            cellDateEnd.ReadOnly = true;
            cellDateEnd.SortMode = DataGridViewColumnSortMode.Automatic;
            dataGridViewDeposits.Columns.Add(cellDateEnd);
            #endregion DepositsDateEnd

            #region Bank
            DataGridViewComboBoxColumn colBank = new DataGridViewComboBoxColumn();
           // colBank.ValueType = typeof(int);
            colBank.Name = Constants.DepositsBankID;  //"DepositsBanks";
            colBank.DataPropertyName = Constants.DepositsBankID;
           
            colBank.ValueMember = Constants.BanksIndex;
            colBank.DisplayMember = Constants.BanksName;
            colBank.DataSource = DataBase.SourceBanks;

            colBank.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing; //Чтобы кнопки выпадения не было

            colBank.HeaderText = "Банк";
            colBank.Width = 200;
            colBank.ReadOnly = false;

            colBank.SortMode = DataGridViewColumnSortMode.Automatic;

            colBank.DefaultCellStyle = styleCol;
            colBank.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            colBank.ReadOnly = true; 
            dataGridViewDeposits.Columns.Add(colBank);
            #endregion Bank

            #region Currency
            DataGridViewComboBoxColumn colCurrency = new DataGridViewComboBoxColumn();
            colCurrency.Name = Constants.DepositsCurrencyID;// "DepositsCurrency";
            colCurrency.DataPropertyName = Constants.DepositsCurrencyID;

            colCurrency.ValueMember = Constants.CurrencyIndex;
            colCurrency.DisplayMember = Constants.CurrencySymbol;
            colCurrency.DataSource = DataBase.SourceCurrency;

            colCurrency.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing; //Чтобы кнопки выпадения не было
            colCurrency.DefaultCellStyle = styleCol;
            colCurrency.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            colCurrency.SortMode = DataGridViewColumnSortMode.Automatic; 
            colCurrency.HeaderText = "Валюта";
            colCurrency.Width = 70;
            colCurrency.ReadOnly = true; 
            dataGridViewDeposits.Columns.Add(colCurrency);
            #endregion Currency

            #region Clients
            DataGridViewComboBoxColumn colClients = new DataGridViewComboBoxColumn();
            colClients.Name = Constants.DepositsClientID; // "DepositsClients";
            colClients.DataPropertyName = Constants.DepositsClientID;

            colClients.ValueMember = Constants.ClientsIndex;
            colClients.DisplayMember = Constants.ClientsName;
            colClients.DataSource = DataBase.SourceClients;

            colClients.DefaultCellStyle = styleCol;
            colClients.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            colClients.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing; //Чтобы кнопки выпадения не было

            colClients.HeaderText = "Клиент";
            colClients.Width = 100;
            colClients.ReadOnly = true;

            colClients.SortMode = DataGridViewColumnSortMode.Automatic;
            dataGridViewDeposits.Columns.Add(colClients);
            #endregion Clients

            
            #region DepositsClosed
            DataGridViewCheckBoxColumn colClosed = new DataGridViewCheckBoxColumn();
            colClosed.Name = Constants.DepositsClosed;
            colClosed.DataPropertyName = Constants.DepositsClosed;
            colClosed.FalseValue = false;
            colClosed.TrueValue = true;
            // colClosed.DefaultCellStyle = styleCol; Для DataGridViewCheckBoxColumn нельзя
            colClosed.FlatStyle = System.Windows.Forms.FlatStyle.Flat;

            colClosed.HeaderText = "Закрыт";
            colClosed.Width = 40;
            colClosed.ReadOnly = true; 
            dataGridViewDeposits.Columns.Add(colClosed);

            #endregion DepositsClosed
            
            dataGridViewDeposits.DataSource = DataBase.SourceDeposits;

            //Пока постоянно задаю скрывать закрытые депозиты
            checkBoxHideClosed_CheckedChanged(this, null);

            #endregion dataGridViewDeposits;
        }

        private void checkBoxHideClosed_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxHideClosed.Checked)
            {

                DataBase.SourceDeposits.Filter = Constants.DepositsClosed + "=false";
            }
            else
            {
                DataBase.SourceDeposits.Filter = "";
            }
        }

        /// <summary>
        /// Редактирование по двойному клику
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewDeposits_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int col = e.ColumnIndex;
                if (col < 0) return;
                int row = e.RowIndex;
                if (row < 0) return;

                #region Edit

                EditButtonCell buttonCell = (EditButtonCell)dataGridViewDeposits.Rows[row].Cells["MyEdit"];

                    if (buttonCell.Enabled) //Если бы у нас вводилась новая строка, то кнопку надо было деактивировать
                    {

                        int index = Convert.ToInt32(dataGridViewDeposits.Rows[row].Cells[Constants.DepositsIndex].Value);

                        EditDeposit(index);
                    }
            
                #endregion Edit

            }
            catch (Exception ex)
            {
                ErrorMessage("Ошибка в dataGridViewDeposits_CellDoubleClick: " + ex.Message);
            }
        }

        private void dataGridViewDeposits_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int col = e.ColumnIndex;
                if (col < 0) return;
                int row = e.RowIndex;
                if (row < 0) return;

                #region Delete
                if (dataGridViewDeposits.Columns[col].GetType().Equals(typeof(DeleteTextColumn))) //Кликнули на столбце удаления
                {
                    DeleteTextCell buttonCell =
                        (DeleteTextCell)dataGridViewDeposits.
                        Rows[row].Cells[col];

                    if (buttonCell.Enabled)
                    {
                        string name = dataGridViewDeposits.Rows[row].Cells[Constants.DepositsName].Value.ToString();
                        int index = Convert.ToInt32(dataGridViewDeposits.Rows[row].Cells[Constants.DepositsIndex].Value);

                        DialogResult res = MessageBox.Show("Удалить депозит " + name + " ?", "Удаление депозита", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                        if (res == DialogResult.Yes)
                        {
                            if (!DataBase.RemoveDeposit(index, name))
                            {
                                ErrorMessage("Ошибка : " + DataBase.LastError);
                            }
                        }
                    }

                }
                #endregion Delete


                #region Edit
                if (dataGridViewDeposits.Columns[col].GetType().Equals(typeof(EditButtonColumn))) //Кликнули на столбце редактирования
                {
                    EditButtonCell buttonCell =
                        (EditButtonCell)dataGridViewDeposits.Rows[row].Cells[col];

                    if (buttonCell.Enabled) //Если бы у нас вводилась новая строка, то кнопку надо было деактивировать
                    {

                        int index = Convert.ToInt32(dataGridViewDeposits.Rows[row].Cells[Constants.DepositsIndex].Value);

                        EditDeposit(index);
                    }
                }
                #endregion Edit

            }
            catch (Exception ex)
            {
                ErrorMessage("Ошибка в dataGridViewDeposits_CellClick: " + ex.Message);
            }
        }

        private void EditDeposit(int index)
        {
            EditDepositForm frm = new EditDepositForm(DataBase, NeedAction.Edit, index);
            frm.ShowDialog();
        }

        /// <summary>
        /// Устанавливаем подсказки, так как предустановленные только для заголовков действуют
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewDeposits_CellToolTipTextNeeded(object sender, DataGridViewCellToolTipTextNeededEventArgs e)
        {
            int col = e.ColumnIndex;
            if (col<0) return;
            int ind = e.RowIndex;
            if (ind < 0) return;
            if (ind == dataGridViewDeposits.NewRowIndex)
            {
                e.ToolTipText = "Новая запись,еще не введена в базу";
                return;
            }
            if (dataGridViewDeposits.Columns[col].Name == "MyDelete") //Delete Button
            {
  
                string name = dataGridViewDeposits.Rows[ind].Cells[Constants.DepositsName].Value.ToString();
                e.ToolTipText = "Удалить депозит '"+name+"'";
                return;
            }
        }

        private void dataGridViewDeposits_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            int col = e.ColumnIndex;
            if (col < 0) return;
            int row = e.RowIndex;
            if (row < 0) return;
            bool newRow = false;

            #region Button Delete
            if (row == dataGridViewDeposits.NewRowIndex) //Для новой записи декативируем кнопку удаления
            {
                // Disable the buttons
                ((DeleteTextCell)(dataGridViewDeposits.Rows[row].Cells["MyDelete"])).Enabled = false;
                ((EditButtonCell)(dataGridViewDeposits.Rows[row].Cells["MyEdit"])).Enabled = false;
                newRow = true;
            }
            else
            {
                // Enable the buttons
                ((DeleteTextCell)(dataGridViewDeposits.Rows[row].Cells["MyDelete"])).Enabled = true;
                ((EditButtonCell)(dataGridViewDeposits.Rows[row].Cells["MyEdit"])).Enabled = true;
            }
            #endregion Button Delete


            #region Закончившиеся и заканчивающиеся депозиты
            if (!newRow)
            {
                if (dataGridViewDeposits.Columns[col].Name == Constants.DepositsDateEnd)
                {
                    int index = Convert.ToInt32(dataGridViewDeposits.Rows[row].Cells[Constants.DepositsIndex].Value);
                    if (OverdueDeposits.Contains(index))
                    {
                        e.CellStyle.BackColor = Color.Tomato;
                    }
                    else if (DeadlineDeposits.Contains(index))
                    {
                        e.CellStyle.BackColor = Color.MistyRose;
                    }
                }
            }
            #endregion Закончившиеся и заканчивающиеся депозиты
        }

        private void dataGridViewDeposits_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            
            Logger.HandleCriticalError("Ошибка данных вывода в dataGridViewDeposits", e.Exception); //Так как иногда при некритичности входит в цикл
        }

        private void dataGridViewDeposits_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {         
            return;

        }

        private void dataGridViewDeposits_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            errorProviderDeposit.SetError(labelErrorProvider, String.Empty);
        }

        private void dataGridViewDeposits_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex<0) return;

            string name = this.dataGridViewDeposits.Columns[e.ColumnIndex].Name;
            #region DepositsPercent and DepositsAmount
           
            if (name == Constants.DepositsPercent | name == Constants.DepositsAmount)
            {
                Rectangle cell = dataGridViewDeposits.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);

                int x = cell.Width + cell.Location.X - 10;
                int y = dataGridViewDeposits.Location.Y + cell.Location.Y;

                string ErrorText;

                decimal value;
                if (decimal.TryParse(e.FormattedValue.ToString(), out value) == false)
                {
                    ErrorText = "Значение должно быть числовым";
                    labelErrorProvider.Location = new Point(x, y);
                    errorProviderDeposit.SetError(labelErrorProvider, ErrorText);
                    e.Cancel = true;
                    return;
                }

                if (value < 0)
                {
                    ErrorText = "Значение должно быть положительным";
                    //labelErrorProvider.Location = dataGridViewDeposits.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false).Location + new Size(20, 0);
                    labelErrorProvider.Location = new Point(x, y);
                    errorProviderDeposit.SetError(labelErrorProvider, ErrorText);
                    e.Cancel = true;
                }
            }
            #endregion DepositsPercent

            #region DepositsDateStart and DepositsDateEnd

            if (name == Constants.DepositsDateStart | name == Constants.DepositsDateEnd)
            {
                Rectangle cell = dataGridViewDeposits.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);

                int x = cell.Width + cell.Location.X-10;
                int y = dataGridViewDeposits.Location.Y + cell.Location.Y;

                string ErrorText;

                DateTime value;
                if (DateTime.TryParse(e.FormattedValue.ToString(), out value) == false)
                {
                    ErrorText = "Значение должно быть корректной датой";
                    labelErrorProvider.Location = new Point(x, y);
                    errorProviderDeposit.SetError(labelErrorProvider, ErrorText);
                    e.Cancel = true;
                    return;
                }

            }
            #endregion DepositsDateStart and DepositsDateEnd
        }

        private void banksReferenceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BanksForm frm = new BanksForm(DataBase);
            frm.ShowDialog();
        }

        private void currencyReferenceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrencyForm frm = new CurrencyForm(DataBase);
            frm.ShowDialog();
        }


        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OptionsForm frm = new OptionsForm(DataBase);
            frm.ShowDialog();
        }

        private void clientsReferenceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClientsForm frm = new ClientsForm(DataBase);
            frm.ShowDialog();
        }

        /// <summary>
        /// Проверим депозиты, о которых нужно заблаговременно сообщить до окончания
        /// </summary>
        private void RemindPriorEndDeposit()
        {
            if (!DataBase.DBOpened) return;

            List<int> deadlineDeposits = DataBase.FindDeadlineDeposits(GetNowDate(), Common.ProgramSettings.RemindPriorEndDepositDays);

           if (DataBase.ErrorOccurred)
           {
              ErrorMessage("Ошибка в RemindPriorEndDeposit:DataBase.FindDeadlineDeposits : " + DataBase.LastError);
               return;
           }

           string message = "";
           int eventCount = 0; //Чтобы подсчитывать сообщений к выводу
           if (deadlineDeposits == null || deadlineDeposits.Count == 0)
           {

               OverdueDeposits.Clear();
               DeadlineDeposits.Clear();
               
           }
           else
           {
               OverdueDeposits = new List<int>();
               DeadlineDeposits = new List<int>();
               StringBuilder sb = new StringBuilder();

               foreach (int index in deadlineDeposits)
               {
                  DataRow row= DataBase.FindDepositById(index);
                  if (row != null)
                  {
                      string name = row.Field<string>(Constants.DepositsName);
                      DateTime endDate =row.Field<DateTime>(Constants.DepositsDateEnd);
                      bool closed = row.Field<bool>(Constants.DepositsClosed);
                      
                      if (closed) continue; //Если депозит уже закрыт, то не напоминаем!!!
                  
                      if (endDate < GetNowDate()) //Если срок меньше сегодня, то это истекший депозит. DateTime.Now.Date так как дата 29.01.15 00:00 - это начало дня
                      {
                          sb.AppendFormat("Депозит '{0}' закончился {1:d}", name, endDate);
                          OverdueDeposits.Add(index);
                          eventCount++;
                      }
                      else //иначе это заканчивающийся
                      {
                          sb.AppendFormat("Депозит '{0}' заканчивается {1:d}", name, endDate);
                          DeadlineDeposits.Add(index);
                          eventCount++;
                      }

                      sb.AppendLine();
                  }
                  else
                  {
                      ErrorMessage("Проблема при поиске депозита с индексом "+index);
                  }
               }
               message = sb.ToString();

           }

           if (eventCount > 0)
           {
               TrayMessage("Имеются заканчивающиеся или просроченные депозиты!", MessagesTypes.Attention);

               dataGridViewDeposits.Refresh();
               MessageBox.Show(this, message, "Заканчивающиеся или просроченные депозиты", MessageBoxButtons.OK, MessageBoxIcon.Information,MessageBoxDefaultButton.Button1);
           }
           else
           {
               StatusMessage("Нет заканчивающихся или просроченных вкладов (закрытые вклады не учитываются)");
           }
        }

        /// <summary>
        /// Проверим депозиты и сообщим что выплата процентов должна произойти
        /// </summary>
        private void RemindInterestPayment()
        {
            if (!DataBase.DBOpened) return;

            List<string> interestPaymentList = new List<string>();

            int offsetDay = Common.ProgramSettings.OffsetInterestPayment; //за сколько дней предупреждать - вынести в общие настройки

             PeriodInterestPayment periodInterestPaymentValue;
             DayInterestPayment dayInterestPaymentValue;
             bool interestPaymentNotification;
             DateTime depositStart, depositEnd;
             DateTime nowDate = GetNowDate(); //текущая дата
             string depositName;
             //Тут нужно пройтись по всем депозитам
            foreach (DataRow row in DataBase.TableDeposits.Rows)
            {
                if (row.RowState == DataRowState.Deleted || row.RowState == DataRowState.Detached) continue;

                depositName = Convert.ToString(row[Constants.DepositsName]);
                depositStart = Convert.ToDateTime(row[Constants.DepositsDateStart]);
                depositEnd = Convert.ToDateTime(row[Constants.DepositsDateEnd]);
                periodInterestPaymentValue = Common.GetPeriodInterestPayment(row[Constants.PeriodInterestPayment]);
                dayInterestPaymentValue = Common.GetDayInterestPayment(row[Constants.DayInterestPayment]);
                interestPaymentNotification = Common.GetInterestPaymentNotification(row[Constants.InterestPaymentNotification]);

                if (!interestPaymentNotification) continue; //Не извещать

                if (nowDate > depositEnd || nowDate.AddDays(offsetDay)<depositStart) continue; //вне рамок
                bool addToList=false;
                switch (periodInterestPaymentValue)
                {

                    case PeriodInterestPayment.Daily: //Ежедневно, dayInterestPaymentValue не имеет значения
                        if (nowDate>= depositStart & nowDate<= depositEnd) //Просто проверяем что депозит действующий и ежедневно сообщаем
                        {
                            addToList = true;
                        }
                        break;
                    case PeriodInterestPayment.Monthly: //Ежемесячно. Нужно привязаться к dayInterestPaymentValue

                        if (DateTimeEventOccurred(nowDate, PeriodInterestPayment.Monthly, dayInterestPaymentValue, offsetDay, depositStart))
                        {
                            addToList = true;
                        }

                        break;
                    case PeriodInterestPayment.Quarterly:
                        if (DateTimeEventOccurred(nowDate, PeriodInterestPayment.Quarterly, dayInterestPaymentValue, offsetDay, depositStart))
                        {
                            addToList = true;
                        }
                        break;
                    case PeriodInterestPayment.Annually:
                        if (DateTimeEventOccurred(nowDate, PeriodInterestPayment.Annually, dayInterestPaymentValue, offsetDay, depositStart))
                        {
                            addToList = true;
                        }
                        break;
                    case PeriodInterestPayment.EndPeriod: //Конец периода, dayInterestPaymentValue не имеет значения
                        if (DateTimeEventOccurred(nowDate, depositEnd, offsetDay))
                        {
                            addToList = true;
                        }
                        break;
                    case PeriodInterestPayment.StartPeriod: //Начало периода, dayInterestPaymentValue не имеет значения
                        if (DateTimeEventOccurred(nowDate,depositStart,offsetDay))
                        {
                            addToList = true;
                        }
                        break;
                    default:
                        break;
                }

                if (addToList) interestPaymentList.Add(depositName);
            }

            if (interestPaymentList.Count == 0)
            {
                StatusMessage("Выплаты процентов не ожидается ни по одному из вкладов");
            }
            else
            {
                string message = "";
                for (int i = 0; i < interestPaymentList.Count; i++)
                {
                    message += interestPaymentList[i] + Environment.NewLine;
                }

                MessageBox.Show(this, message, "Ожидающиеся выплаты по вкладам", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                TrayMessage("Ожидающиеся выплаты по вкладам!", MessagesTypes.Attention);
            }

        }

        private bool DateTimeEventOccurred(DateTime nowDate, PeriodInterestPayment periodInterestPayment, DayInterestPayment dayInterestPaymentValue, int offsetDay,DateTime depositStart)
        {
            bool value = false;
            DateTime dayOfPayment;
            int year, month, day,lastDay;
            switch (periodInterestPayment)
            {
                case PeriodInterestPayment.Monthly:
                    //Если ежемесячно, то смотрим на dayInterestPaymentValue, вычитаем offsetDay из соответствующего дня, и проверяем nowDate в этом периоде
                    switch (dayInterestPaymentValue)
	                        {
                                case DayInterestPayment.FirstDayPeriod:
                                    //как быть если offsetDay=30,40 дней?
                                    year = nowDate.Year;
                                    month = nowDate.Month;
                                    day = 1;
                                    month++; //берем следующий месяц, так как этот уже начался
                                    if (month > 12)
                                    {
                                        year++;
                                        month = 1;
                                    }
                                    dayOfPayment = new DateTime(year, month, day);
                                    if (nowDate.AddDays(offsetDay) >= dayOfPayment) value = true; //Так как nowDate всегда меньше dayOfPayment, то тут проверяем просто

                                    break;
                                case DayInterestPayment.LastDayPeriod:
                                    year = nowDate.Year;
                                    month = nowDate.Month;
                                    day = DateTime.DaysInMonth(year, month);
                                    dayOfPayment = new DateTime(year, month, day);
                                    if (nowDate.AddDays(offsetDay) >= dayOfPayment) value = true; //Так как nowDate всегда меньше dayOfPayment, то тут проверяем просто
                                    //если offsetDay больше 31, то всегда будет труе, может ограничить не более 30 дней?

                                    break;
                                case DayInterestPayment.DayOfDeposit:
                                    year = nowDate.Year;
                                    month = nowDate.Month;
                                    day = depositStart.Day;
                                    if (nowDate.Day <= day) //Номер текущего дня меньше дня открытия
                                    {
                                        if ((day - nowDate.Day) <= offsetDay) value = true;
                                    }
                                    else //Номер текущего дня больше дня открытия. Нужно проверить следующий месяц
                                    {
                                        year = nowDate.Year;
                                        month = nowDate.Month;
                                        month++; //берем следующий месяц, так как этот уже начался
                                        if (month > 12)
                                        {
                                            year++;
                                            month = 1;
                                        }
                                        lastDay = DateTime.DaysInMonth(year, month);
                                        if (day > lastDay) day = lastDay;

                                        dayOfPayment = new DateTime(year, month, day);
                                        if (nowDate.AddDays(offsetDay) >= dayOfPayment) value = true;

                                    }
                                    break;
                                case DayInterestPayment.NextDayOfDeposit:
                                    year = nowDate.Year;
                                    month = nowDate.Month;
                                    lastDay = DateTime.DaysInMonth(year, month);
                                    day = depositStart.Day+1;
                                    if (day > lastDay) //Это следующий месяц будет
                                    {
                                        month++;
                                        day = 1;

                                        if (month > 12)
                                        {
                                            year++;
                                            month = 1;
                                        }

                                        dayOfPayment = new DateTime(year, month, day);
                                        if (nowDate.AddDays(offsetDay) >= dayOfPayment) value = true;
                                    }
                                    else
                                    {
                                        if (nowDate.Day <= day) //Номер текущего дня меньше дня открытия
                                        {
                                            if ((day - nowDate.Day) <= offsetDay) value = true;
                                        }
                                        else //Номер текущего дня больше дня открытия. Нужно проверить следующий месяц
                                        {
                                            year = nowDate.Year;
                                            month = nowDate.Month;
                                            month++; //берем следующий месяц, так как этот уже начался
                                            if (month > 12)
                                            {
                                                year++;
                                                month = 1;
                                            }
                                            lastDay = DateTime.DaysInMonth(year, month);
                                            if (day > lastDay) day = lastDay;

                                            dayOfPayment = new DateTime(year, month, day);
                                            if (nowDate.AddDays(offsetDay) >= dayOfPayment) value = true;

                                        }
                                    }
       
                                    break;
                                default:
                                    break;
	                        }
                    
                    break;
                case PeriodInterestPayment.Quarterly: //Ежеквартально
                    switch (dayInterestPaymentValue)
	                {
                        case DayInterestPayment.FirstDayPeriod://Первый день квартала
                            dayOfPayment = GetNextQuarterStartingDate(nowDate); //Следующего квартала первая дата
                            if (nowDate.AddDays(offsetDay) >= dayOfPayment) value = true; 
                            break;
                        case DayInterestPayment.LastDayPeriod://Последний день квартала
                            dayOfPayment = GetQuarterEndingDate(nowDate);
                            if (nowDate.AddDays(offsetDay) >= dayOfPayment) value = true; 
                            break;
                        case DayInterestPayment.DayOfDeposit: //День открытия депозита - Такого быть не может
                            ErrorMessage("При ежеквартальной выплате день открытия депозита не используется!");
                            break;
                        case DayInterestPayment.NextDayOfDeposit://Следующий День открытия депозита - Такого быть не может
                            ErrorMessage("При ежеквартальной выплате день следующий день после открытия депозита не используется!");
                            break;
                        default:
                            break;
	                }
                    break;
                case PeriodInterestPayment.Annually: //Ежегодно
                    switch (dayInterestPaymentValue)
	                {
                        case DayInterestPayment.FirstDayPeriod: //Подразумеваем первый день года
                             year = nowDate.Year;
                             month = 1;
                             day = 1;
                             year++; //берем следующий год, так как этот уже начался
 
                             dayOfPayment = new DateTime(year, month, day);
                             if (nowDate.AddDays(offsetDay) >= dayOfPayment) value = true; //Так как nowDate всегда меньше dayOfPayment, то тут проверяем просто
                            break;
                        case DayInterestPayment.LastDayPeriod: //Подразумеваем последний день года
                             year = nowDate.Year;
                             month = 12;
                             day = 31;
                             dayOfPayment = new DateTime(year, month, day);
                             if (nowDate.AddDays(offsetDay) >= dayOfPayment) value = true; //Так как nowDate всегда меньше dayOfPayment, то тут проверяем просто
                            break;
                        case DayInterestPayment.DayOfDeposit: //День и месяц депозита
                            day=depositStart.Day;
                            month=depositStart.Month;
                            year=nowDate.Year;
                            lastDay = DateTime.DaysInMonth(year, month);
                            if (day>lastDay)
                            {
                                month++;
                                if (month>12)
                                {
                                year++;
                                month=1;
                                day=1;
                                }
                            }
                            dayOfPayment = new DateTime(year, month, day);
                            if (nowDate.AddDays(offsetDay) >= dayOfPayment) value = true;
                            break;
                        case DayInterestPayment.NextDayOfDeposit://Следующий день после депозита
                            day=depositStart.Day+1;
                            month=depositStart.Month;
                            year=nowDate.Year;
                            lastDay = DateTime.DaysInMonth(year, month);
                            if (day>lastDay)
                            {
                                month++;
                                if (month>12)
                                {
                                year++;
                                month=1;
                                day=1;
                                }
                            }
                            dayOfPayment = new DateTime(year, month, day);
                            if (nowDate.AddDays(offsetDay) >= dayOfPayment) value = true;
                            break;
                        default:
                            break;
	                }
                    break;
                default:
                    break;
            }

            return value;
        }
        /// <summary>
        /// Номер квартала, 1,2,3,4
        /// </summary>
        /// <param name="myDate"></param>
        /// <returns></returns>
        int GetQuarterName(DateTime myDate)
        {
            // int currQuarter = (datetime.Month - 1) / 3 + 1;
            return (int)Math.Ceiling(myDate.Month / 3.0);
        }
        /// <summary>
        /// Первый день квартала
        /// </summary>
        /// <param name="myDate"></param>
        /// <returns></returns>
        DateTime GetQuarterStartingDate(DateTime myDate)
        {
            return new DateTime(myDate.Year, (3 * GetQuarterName(myDate)) - 2, 1);
        }
        /// <summary>
        /// Получить первый день следующего квартала
        /// </summary>
        /// <param name="myDate"></param>
        /// <returns></returns>
        DateTime GetNextQuarterStartingDate(DateTime myDate)
        {
            int num = GetQuarterName(myDate);
            int year = myDate.Year;
            num++;
            if (num > 4)
            {
                num = 1;
                year++;

            }
            return new DateTime(year, (3 * num) - 2, 1);
        }

        /// <summary>
        /// Последний день квартала
        /// </summary>
        /// <param name="myDate"></param>
        /// <returns></returns>
        DateTime GetQuarterEndingDate(DateTime myDate)
        {
            //DateTime dtLastDay = new DateTime(datetime.Year, 3 * currQuarter + 1, 1).AddDays(-1);
            return new DateTime(myDate.Year, (3 * GetQuarterName(myDate)) + 1, 1).AddDays(-1);
        }

        /// <summary>
        /// Истина, если date1 лежит в промежутке от (date2-offsetDay) и до date2 включительно. Чтобы оповещать о процентах
        /// </summary>
        /// <param name="date1"></param>
        /// <param name="date2"></param>
        /// <param name="offsetDay"></param>
        /// <returns></returns>
        private bool DateTimeEventOccurred(DateTime date1, DateTime date2, int offsetDay)
        {
            if (date1 >= date2.AddDays(-offsetDay) & date1 <= date2) return true;
               else return false;
        }

        /// <summary>
        /// Получить текущую дату, чтобы при тестировании можно легко её изменять
        /// </summary>
        /// <returns></returns>
        private DateTime GetNowDate()
        {
            if (checkBoxNowDate.Checked)
            {
                return dateTimePickerNowDate.Value;
            }
            else
            {
                return DateTime.Now.Date;
            }
        }


        private void AddNewDeposit()
        {
            EditDepositForm frm = new EditDepositForm(DataBase, NeedAction.AddNew, -1);
            frm.ShowDialog();
        }

        private void toolStripNewButton_Click(object sender, EventArgs e)
        {
            AddNewDeposit();
        }

        private void toolStripCheckDeadline_Click(object sender, EventArgs e)
        {
            RemindPriorEndDeposit(); //Проверить депозиты на истекший срок
        }

        private void toolStripButtonCheckPercentDeadline_Click(object sender, EventArgs e)
        {
            RemindInterestPayment(); //Проверить депозиты на событие выплаты процентов
        }



        private void notifyIconMain_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ShowMainForm();
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowMainForm();
        }

        private void ShowMainForm()
        {
            this.ShowInTaskbar = true; //восстанавливаем в панели задач значок в развернутом виде. Тут вроде меньше мигает
            Show();
            WindowState = OldWindowState; // FormWindowState.Normal;
            // this.ShowInTaskbar = true; //Тут заметное мигание при развертывании
         
        }

        /// <summary>
        /// Минимизируем форму
        /// </summary>
        private void HideMainForm()
        {
            OldWindowState = this.WindowState;
            this.WindowState = FormWindowState.Minimized;
            this.Hide();
            this.ShowInTaskbar = false;
        }

        /// <summary>
        /// Не разворачиваем. если минимизирована
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMain_Resize(object sender, EventArgs e)
        {
            
            if (WindowState == FormWindowState.Minimized)
            {
                this.ShowInTaskbar = false; //убираем из панели задач значок в свернутом виде
            }

            
        }
        /// <summary>
        /// Получим сколько денег и в какой валюте у нас есть
        /// </summary>
        public void GetAmountInfo()
        {
            try
            {
                if (!DataBase.DBOpened) return;

                int baseCurrencyId=-1;
                string strBaseCurrencyId = DataBase.FindConfigValueByName(Constants.BaseCurrencyId);

                if (!String.IsNullOrEmpty(strBaseCurrencyId)) baseCurrencyId = Convert.ToInt32(strBaseCurrencyId);

                Dictionary<int, decimal> amountDic = new Dictionary<int, decimal>(); //По индексу валюты суммируем вклады

                for (int i = 0; i < DataBase.TableDeposits.Rows.Count; i++)
                {
                    DataRow row = DataBase.TableDeposits.Rows[i];
                    bool closed = Convert.ToBoolean(row.Field<bool>(Constants.DepositsClosed)); //закрыть ли депозит

                    if (!closed)
                    {
                        int currencyId = Convert.ToInt32(row.Field<int>(Constants.DepositsCurrencyID)); //Индекс валюты
                        decimal amount = Convert.ToDecimal(row.Field<decimal>(Constants.DepositsAmount)); //Сумма 

                        if (amountDic.ContainsKey(currencyId))
                        {
                            amountDic[currencyId] += amount; //Увеличим для той же валюты
                        }
                        else
                        {
                            amountDic.Add(currencyId, amount); //Создадим первую запись
                        }
                    }

                }

                StringBuilder sb = new StringBuilder();

                decimal inBaseCurrencyAmount = 0;

                foreach (KeyValuePair<int, decimal> pair in amountDic)
                {
                    if (pair.Key != baseCurrencyId)
                    {
                        inBaseCurrencyAmount += pair.Value * DataBase.FindCurrencyRateById(pair.Key); //Если валюта не базовая, пересчитаем по курсу
                    }
                    else inBaseCurrencyAmount += pair.Value;

                    sb.AppendFormat("{0:N} {1}    ", pair.Value, DataBase.FindCurrencySymbolById(pair.Key));
               
                }

                if (baseCurrencyId >= 0)
                {
                    sb.AppendFormat(" ( или в базовой валюте {0:N} {1} )", inBaseCurrencyAmount, DataBase.FindCurrencySymbolById(baseCurrencyId));
                }
                labelAmountInfo.Text = "Вкладов: " + sb.ToString().TrimEnd(); //.TrimEnd(new char[1] { ',' });

            }
    
            catch (Exception ex)
            {
                ErrorMessage("Ошибка в GetAmountInfo: " + ex.Message);
            }
        }

        /// <summary>
        /// Сбрасываю некоторую информацию на инфо панели и других
        /// </summary>
        private void AmountInfoClear()
        {

            labelAmountInfo.Text = "";

        }

        private void toolStripButtonAmountInfo_Click(object sender, EventArgs e)
        {
            GetAmountInfo();

            //Очистим списки чтобы при открытии другой не высвечивалось
            OverdueDeposits.Clear();
            DeadlineDeposits.Clear();
        }

#region My TEST
        private void buttonOverdueDepositsToText_Click(object sender, EventArgs e)
        {
            StringBuilder sb=new StringBuilder ();

            for (int i = 0; i < OverdueDeposits.Count; i++)
			{
			     sb.AppendLine(OverdueDeposits[i].ToString());
			}

            textBoxTest.Text = sb.ToString();
        }

        private void buttonDeadlineDeposits_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < DeadlineDeposits.Count; i++)
            {
                sb.AppendLine(DeadlineDeposits[i].ToString());
            }

            textBoxTest.Text = sb.ToString();
        }

        #endregion My TEST



    }
}
