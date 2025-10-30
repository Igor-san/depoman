using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Runtime.Serialization;

namespace DepoMan.Classes
{
    public class ProgramSettings
    {

        #region Window Size and State
        private FormWindowState _WindowState = FormWindowState.Normal;//
        private int _WindowHeight = 750; //Высота окна
        private int _WindowWidth = 1200; //Ширина окна

        [DataMember(IsRequired = false)]
        public int WindowWidth
        {
            get
            {
                return _WindowWidth;
            }

            set
            {
                if (_WindowWidth != value)
                {
                    _WindowWidth = value;
                    if (!appFirstLoad) SettingChanged();
                }
            }
        }

        [DataMember(IsRequired = false)]
        public int WindowHeight
        {
            get
            {
                return _WindowHeight;
            }

            set
            {
                if (_WindowHeight != value)
                {
                    _WindowHeight = value;
                    if (!appFirstLoad) SettingChanged();
                }
            }
        }

        [DataMember(IsRequired = false)]
        public FormWindowState WindowState
        {
            get
            {
                return _WindowState;
            }

            set
            {
                if (_WindowState != value)
                {
                    _WindowState = value;
                    if (!appFirstLoad) SettingChanged();
                }
            }
        }

        #endregion Window Size and State

        private bool appFirstLoad = true;

        private string m_ConfigFileName = "";
        private string m_ConfigFilePath = "";

        private string[] m_LastOpenFiles;

        public event EventHandler Changed;

        // Properties used to access the application settings variables.

        #region AutoLoad
        /// <summary>
        /// загружать автоматом последнюю базу лотереи
        /// </summary>
        private bool boolAutoLoadLastDataBase;
        /// <summary>
        /// загружать автоматом последнюю базу лотереи
        /// </summary>
        public bool AutoLoadLastDataBase //загружать автоматом последнюю базу лотереи
        {
            get { return boolAutoLoadLastDataBase; }
            set
            {
                if (value != boolAutoLoadLastDataBase)
                {
                    boolAutoLoadLastDataBase = value;
                    if (!appFirstLoad) SettingChanged();

                }
            }
        }

        private bool boolMinimizeOnStart;
        /// <summary>
        /// Сворачивать в трей при старте
        /// </summary>
        public bool MinimizeOnStart
        {
            get { return boolMinimizeOnStart; }
            set
            {
                if (value != boolMinimizeOnStart)
                {
                    boolMinimizeOnStart = value;
                    if (!appFirstLoad) SettingChanged();

                }
            }
        }

        private bool boolAutoSaveDataBaseOnClose;//автоматом сохранять базу данных при закрытии, если она была изменена! (а не при каждом изменении)
        /// <summary>
        /// автоматом сохранять базу данных при закрытии, если она была изменена! (а не при каждом изменении)
        /// </summary>
        public bool AutoSaveDataBaseOnClose
        {
            get { return boolAutoSaveDataBaseOnClose; }
            set
            {
                if (value != boolAutoSaveDataBaseOnClose)
                {
                    boolAutoSaveDataBaseOnClose = value;
                    if (!appFirstLoad) SettingChanged();

                }
            }
        }

     

        private bool boolMinimizeInsteadClose;
        /// <summary>
        /// Сворачивать при нажатии на крест
        /// </summary>
        public bool MinimizeInsteadClose
        {
            get { return boolMinimizeInsteadClose; }
            set
            {
                if (value != boolMinimizeInsteadClose)
                {
                    boolMinimizeInsteadClose = value;
                    if (!appFirstLoad) SettingChanged();

                }
            }
        }

        #endregion AutoLoad

        #region напоминание
        private bool boolRemindPriorEndDeposit;
        /// <summary>
        /// Напоминать до окончания вклада
        /// </summary>
        public bool RemindPriorEndDeposit
        {
            get { return boolRemindPriorEndDeposit; }
            set
            {
                if (value != boolRemindPriorEndDeposit)
                {
                    boolRemindPriorEndDeposit = value;
                    if (!appFirstLoad) SettingChanged();

                }
            }
        }

        private int intRemindPriorEndDepositDays;
        /// <summary>
        /// Дней до окончания вклада при напонимании
        /// </summary>
        public int RemindPriorEndDepositDays
        {
            get { return intRemindPriorEndDepositDays; }
            set
            {
                if (value != intRemindPriorEndDepositDays)
                {
                    intRemindPriorEndDepositDays = value;
                    if (!appFirstLoad) SettingChanged();

                }
            }
        }

        private bool boolRemindInterestPayment;
        /// <summary>
        /// Напоминать до наступления выплаты, переписывается индивидуальными установками. Т.е. если не отмечено здесь - напоминаний не будет
        /// Если здесь отмечено, то зависит от установок в каждом депозите
        /// </summary>
        public bool RemindInterestPayment
        {
            get { return boolRemindInterestPayment; }
            set
            {
                if (value != boolRemindInterestPayment)
                {
                    boolRemindInterestPayment = value;
                    if (!appFirstLoad) SettingChanged();

                }
            }
        }

        private int intOffsetInterestPayment;
        /// <summary>
        /// Дней до выплаты процентов
        /// </summary>
        public int OffsetInterestPayment
        {
            get { return intOffsetInterestPayment; }
            set
            {
                if (value != intOffsetInterestPayment)
                {
                    intOffsetInterestPayment = value;
                    if (!appFirstLoad) SettingChanged();

                }
            }
        }

        #endregion напоминание


        public int MaxLastOpenFiles //максимальное число последних файлов
        { get; set; }


        public ProgramSettings()
        {

        }

        public void SetFilePath()
        {

            m_ConfigFileName = Constants.SettingsFileName;
            //m_ConfigFilePath = Common.ProgramDataPath; //Windows 7 нужно хранить в папке пользователя
            m_ConfigFilePath = Common.UserAppDataPath;
        }


        private string ConfigFilePath
        {
            get { return m_ConfigFilePath; }
            set
            {
                if (value != m_ConfigFilePath)
                {
                    m_ConfigFilePath = value;
                    if (!appFirstLoad) SettingChanged();
                    //appSettingsChanged = true;
                }
            }
        }

        private string ConfigFileName
        {
            get { return m_ConfigFileName; }
            set
            {
                if (value != m_ConfigFileName)
                {
                    m_ConfigFileName = value;
                    if (!appFirstLoad) SettingChanged();
                    // appSettingsChanged = true;
                }
            }
        }

        public string[] LastOpenFiles
        {
            get { return m_LastOpenFiles; }
            set
            {
                if (value != m_LastOpenFiles) //что-то это не вызывается ???
                {
                    m_LastOpenFiles = value;
                    if (!appFirstLoad) SettingChanged();
                    //appSettingsChanged = true;
                }
            }
        }

        // Serializes the class to the config file
        // if any of the settings have changed.
        public void SaveAppSettings()
        {
            //if (this.appSettingsChanged)
            SetFilePath();
            {
                StreamWriter myWriter = null;
                XmlSerializer mySerializer = null;
                try
                {
                    // Create an XmlSerializer for the 
                    // ApplicationSettings type.
                    mySerializer = new XmlSerializer(
                      typeof(ProgramSettings));
                    //myWriter = new StreamWriter(Application.LocalUserAppDataPath + @"\myApplication.config", false);
                    myWriter = new StreamWriter(m_ConfigFilePath + @"\" + m_ConfigFileName, false);
                    // Serialize this instance of the ApplicationSettings 
                    // class to the config file.
                    mySerializer.Serialize(myWriter, this);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    // If the FileStream is open, close it.
                    if (myWriter != null)
                    {
                        myWriter.Close();
                    }
                }
            }
            return;// appSettingsChanged;
        }

        // Deserializes the class from the config file.
        public bool LoadAppSettings()
        {
            SetFilePath();
            XmlSerializer mySerializer = null;
            FileStream myFileStream = null;
            bool fileExists = false;

            try
            {
                // Create an XmlSerializer for the ApplicationSettings type.
                mySerializer = new XmlSerializer(typeof(ProgramSettings));
                //FileInfo fi = new FileInfo(Application.LocalUserAppDataPath+ @"\myApplication.config");
                FileInfo fi = new FileInfo(m_ConfigFilePath + @"\" + m_ConfigFileName);
                // If the config file exists, open it.
                if (fi.Exists)
                {
                    myFileStream = fi.OpenRead();
                    // Create a new instance of the ApplicationSettings by
                    // deserializing the config file.
                    appFirstLoad = true; // чтобы не вызывать appSettingsChanged

                    Common.ProgramSettings = (ProgramSettings)mySerializer.Deserialize(myFileStream);

                    fileExists = true;
                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                // If the FileStream is open, close it.
                if (myFileStream != null)
                {
                    myFileStream.Close();
                }
            }

            if (m_ConfigFilePath == null)
            {
                // If m_ConfigFilePath is not set, default
                // to the user's "My Documents" directory.
                m_ConfigFilePath = Environment.GetFolderPath(
                   System.Environment.SpecialFolder.Personal);
                // this.appSettingsChanged = true;
                SettingChanged();
            }
            return fileExists;
        }


        #region Methods

        public void SettingChanged()
        {
            if (Changed != null)
                Changed.Invoke(this, new EventArgs());
        }

        #endregion


        internal void SetFirstLoad(bool value) //Флаг, что при первой загрузе не надо возбуждать SettingChanged
        {
            appFirstLoad = value;
        }
    }
}
