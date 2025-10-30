using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DepoMan.Classes;
using DepoMan.Components;

namespace DepoMan.Forms
{
    public partial class BanksForm : Form
    {
        DataView DataViewBanks;
        DataSet DataSetBanks;

        DatabaseClass DataBase=null;
        //bool error = false;

       // string lastError="";

        public BanksForm(DatabaseClass db)
        {
            DataBase = db;
            InitializeComponent();

            dataGridViewMyBanks.AutoGenerateColumns = false;
        }


        private void ErrorMessage(string error)
        {
            // MessageBox.Show(error);
            statusMessagePanel.StatusMessage(error, MessagesTypes.Error);
            statusMessagePanel.UnHidePanel();
        }
        private void StatusMessage(string text)
        {
            statusMessagePanel.StatusMessage(text);
            statusMessagePanel.UnHidePanel();

        }
        private void StatusMessage(string text, MessagesTypes type)
        {
            statusMessagePanel.StatusMessage(text, type);
            statusMessagePanel.UnHidePanel();
        }

        private void dataGridViewMyBanks_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int col = e.ColumnIndex;
                if (col < 0) return;
                int row = e.RowIndex;
                if (row < 0) return;

                #region delete
                if (dataGridViewMyBanks.Columns[col].GetType().Equals(typeof(DeleteTextColumn))) //Кликнули на столбце удаления
                {
                    DeleteTextCell buttonCell =
                        (DeleteTextCell)dataGridViewMyBanks.Rows[row].Cells[col];

                    if (buttonCell.Enabled)
                    {

                        string name = dataGridViewMyBanks.Rows[row].Cells["MyName"].Value.ToString();
                        string regNum = dataGridViewMyBanks.Rows[row].Cells["MyRegNum"].Value.ToString();
                        int index = Convert.ToInt32(dataGridViewMyBanks.Rows[row].Cells["MyIndex"].Value);
                        //Надо проверить, не используется ли этот банк в депозитах,
                        if (DataBase.CheckBankInDeposits(index))
                        {

                            MessageBox.Show("Банк " + name + " используется в депозитах, вначале нужно удалить все депозиты с этим банком.");
                            return;
                        }
                        else
                        {
                            //Если в CheckBanksInDeposits произошла ошибка, то она вернет False, , то также вернет -1,нужно проверить это
                            if (DataBase.ErrorOccurred)
                            {
                                ErrorMessage("При проверке банка произошла ошибка: " +DataBase.LastError);
                                return;

                            }

                        }

                        DialogResult res = MessageBox.Show("Удалить банк " + name + " из справочника?", "Удаление банка", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                        if (res == DialogResult.Yes)
                        {
                            if (!DataBase.RemoveBank(index, name))
                            {
                                ErrorMessage("Ошибка : " + DataBase.LastError);
                            }
                        }
                    }
                }
                #endregion delete


                #region Edit
                if (dataGridViewMyBanks.Columns[col].GetType().Equals(typeof(EditButtonColumn))) //Кликнули на столбце редактирования
                {
                    EditButtonCell buttonCell =
                        (EditButtonCell)dataGridViewMyBanks.Rows[row].Cells[col];

                    if (buttonCell.Enabled) //Если бы у нас вводилась новая строка, то кнопку надо было деактивировать
                    {

                        string name = dataGridViewMyBanks.Rows[row].Cells["MyName"].Value.ToString();
                        string regNum = dataGridViewMyBanks.Rows[row].Cells["MyRegNum"].Value.ToString();
                        int index = Convert.ToInt32(dataGridViewMyBanks.Rows[row].Cells["MyIndex"].Value);

                        EditBank(index);
                    }
                }
                #endregion Edit
            }
            catch (Exception ex)
            {
                ErrorMessage("Ошибка в dataGridViewMyBanks_CellClick: " + ex.Message);
            }
        }

        /// <summary>
        /// Открыть форму редактирования банка
        /// </summary>
        /// <param name="index"></param>
        private void EditBank(int index)
        {
            EditBankForm frm=new EditBankForm(DataBase,NeedAction.Edit,index);
            frm.ShowDialog();
        }



        private void buttonOpenBik_Click(object sender, EventArgs e)
        {
            try
            {
                SpinningProgressMain.Enabled = true;
                SpinningProgressMain.Visible = true;
                SpinningProgressMain.Refresh();
                buttonOpenBik.Enabled = false;
                OpenBanks();
                SpinningProgressMain.Refresh();
            }
            finally
            {
                buttonOpenBik.Enabled = true;
                SpinningProgressMain.Enabled = false;
                SpinningProgressMain.Visible = false;
            }
        }

        private void buttonBankSelect_Click(object sender, EventArgs e)
        {
            BankToMyBanks();
        }

        private void dataGridViewBik_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            BankToMyBanks();
        }

        private void buttonLikeFind_Click(object sender, EventArgs e)
        {
            LikeFind();
        }

        private void buttonClearFilter_Click(object sender, EventArgs e)
        {
            textBoxLikeFind.Text = "";
            DataViewBanks.RowFilter = "";
        }

        private void LikeFind()
        {
            string what = Constants.BanksFullName+" Like '*" + textBoxLikeFind.Text.Trim() + "*'";
            /*       
        DataRow[] foundRows;
        foundRows = DataSetBanks.Tables[Constants.BanksImportName].Select(what);
        */

            //DataViewBanks = new DataView();
            //DataViewBanks.Table = DataSetBanks.Tables[Constants.BanksImportName];
            DataViewBanks.RowFilter = what;

            //dataGridViewBik.DataSource = DataViewBanks;

        }
        private void OpenBanks()
        {
            try
            {
                dataGridViewBik.SuspendLayout();

                OpenFileDialog openDB = new OpenFileDialog();
                #region Set openDB Dialog Properties
                openDB.InitialDirectory = Application.StartupPath + "\\" + Constants.BikFolderName; ;
                openDB.Title = "Открыть...";
                openDB.CheckFileExists = true;
                openDB.Multiselect = false;
                openDB.Filter = Constants.XmlFilter;

                #endregion

                if (openDB.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                SpinningProgressMain.Refresh();

                DataSetBanks = new DataSet();
                DataSetBanks.Tables.Add(Constants.BanksImportName);

                DataSetBanks.Tables[Constants.BanksImportName].ReadXml(openDB.FileName);
           
                dataGridViewBik.AutoGenerateColumns = false;

                DataViewBanks = new DataView();
                DataViewBanks.Table = DataSetBanks.Tables[Constants.BanksImportName];
                dataGridViewBik.DataSource = DataViewBanks;

                SpinningProgressMain.Refresh();

                List<string> autoBik = new List<string>();
                List<string> autoBanks = new List<string>();
                List<string> autoShortBanks = new List<string>();
                List<string> autoRegN = new List<string>();
                foreach (DataRow row in DataSetBanks.Tables[Constants.BanksImportName].Rows)
                {
                    string bik = row.Field<string>(Constants.BanksBIK);
                    string bank = row.Field<string>(Constants.BanksFullName);
                    string shortbank = row.Field<string>(Constants.BanksName);
                    string regn = row.Field<string>(Constants.BanksRegNum);
                    autoBik.Add(bik);
                    autoBanks.Add(bank);
                    autoShortBanks.Add(shortbank);
                    autoRegN.Add(regn);
                }
                SpinningProgressMain.Refresh();

                comboBoxBankFullName.DataSource = DataViewBanks;
                comboBoxBankFullName.AutoCompleteCustomSource.AddRange(autoBanks.ToArray());
                comboBoxBankFullName.DisplayMember = Constants.BanksFullName; //Полное название банка

                SpinningProgressMain.Refresh();

                comboBoxBankShortName.DataSource = DataViewBanks;
                comboBoxBankShortName.AutoCompleteCustomSource.AddRange(autoShortBanks.ToArray());
                comboBoxBankShortName.DisplayMember = Constants.BanksName; //Краткое название банка

                SpinningProgressMain.Refresh();

                comboBoxRegNum.DataSource = DataViewBanks;
                comboBoxRegNum.AutoCompleteCustomSource.AddRange(autoRegN.ToArray());
                comboBoxRegNum.DisplayMember = Constants.BanksRegNum; 

                SpinningProgressMain.Refresh();

                comboBoxBik.DataSource = DataViewBanks;
                comboBoxBik.AutoCompleteCustomSource.AddRange(autoBik.ToArray());
                comboBoxBik.DisplayMember = Constants.BanksBIK;

                EnableOptionsControls(true);

            }
            catch (Exception ex)
            {
                EnableOptionsControls(false);
                ErrorMessage("Ошибка в OpenBanks: " + ex.Message);
            }
            finally
            {
                SpinningProgressMain.Refresh();
                dataGridViewBik.ResumeLayout();
            }
        }

        /// <summary>
        /// Активировать некоторые кнопки на tabPageControls
        /// </summary>
        /// <param name="enable"></param>
        private void EnableOptionsControls(bool enable)
        {
            buttonBankSelect.Enabled = enable;
            groupBox1.Enabled = enable;
            groupBox2.Enabled = enable;
        }

        private bool BankToMyBanks()
        {

            string regNum = comboBoxRegNum.Text.Trim();
            string bik = comboBoxBik.Text.Trim();
            string fullName = comboBoxBankFullName.Text.Trim();
            string name = comboBoxBankShortName.Text.Trim();


            int res = DataBase.BankInMyBankByBik(bik);
            if (res >= 0)
            {
                MessageBox.Show("Банк с БИК " + bik + " уже существует в справочнике!");
                return false;
            }

            DataBase.AddNewBank(regNum, bik, name, fullName);
            if (DataBase.ErrorOccurred)
            {
                ErrorMessage("Ошибка при добавлении банка: " + DataBase.LastError);
                return false;
            }

            return true;


        }

        private void BanksForm_Load(object sender, EventArgs e)
        {
            if (!DataBase.DBOpened)
            {
                MessageBox.Show("Вначале нужно открыть базу данных");
                Close();
            }
            EnableOptionsControls(false);
            dataGridViewMyBanks.AutoGenerateColumns = false;
            dataGridViewBik.AutoGenerateColumns = false;

            statusMessagePanel.ProgressVisible = false;
            statusMessagePanel.HidePanel();

            dataGridViewMyBanks.DataSource = DataBase.SourceBanks;
        }

        private void dataGridViewMyBanks_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            int col = e.ColumnIndex;
            if (col < 0) return;
            int row = e.RowIndex;
            if (row < 0) return;
            if (row == dataGridViewMyBanks.NewRowIndex) //Для новой записи декативируем кнопку удаления
            {
                // Disable the buttons
                ((DeleteTextCell)(dataGridViewMyBanks.Rows[row].Cells["MyDelete"])).Enabled = false;
                ((EditButtonCell)(dataGridViewMyBanks.Rows[row].Cells["MyEdit"])).Enabled = false;
               
            }
            else
            {
            // Enable the buttons
            ((DeleteTextCell)(dataGridViewMyBanks.Rows[row].Cells["MyDelete"])).Enabled = true;
            ((EditButtonCell)(dataGridViewMyBanks.Rows[row].Cells["MyEdit"])).Enabled = true;
            }
        }

        private void AddNewBank()
        {
            EditBankForm frm = new EditBankForm(DataBase, NeedAction.AddNew, -1);
            frm.ShowDialog();
        }
        private void toolStripMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem == toolStripCloseButton)
            {
                Close();
            }
            else if (e.ClickedItem == toolStripNewButton)
            {
                AddNewBank();
            }
        }
   
    }
}
