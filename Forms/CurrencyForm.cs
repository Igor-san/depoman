using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DepoMan.Classes;
using DepoMan.Components;

namespace DepoMan.Forms
{
    public partial class CurrencyForm : Form
    {
        DataView DataViewCurrency;
        DataSet DataSetCurrency;

        private DatabaseClass DataBase=null;
        bool error = false;
        string lastError="";

        public CurrencyForm(DatabaseClass db)
        {
            DataBase = db;
            InitializeComponent();

            statusMessagePanel.ProgressVisible = false;
        }

        private void ErrorMessage(string error)
        {
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

        private void buttonImport_Click(object sender, EventArgs e)
        {
            OpenOkv();
        }

        private void OpenOkv()
        {

            OpenFileDialog openDB = new OpenFileDialog();
            #region Set openDB Dialog Properties
            openDB.InitialDirectory = Application.StartupPath + "\\"+Constants.OkvFolderName;;
            openDB.Title = "Открыть...";
            openDB.CheckFileExists = true;
            openDB.Multiselect = false;
            openDB.Filter = Constants.XmlFilter;

            #endregion

            if (openDB.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            try
            {
              

            DataSetCurrency = new DataSet();
            DataSetCurrency.Tables.Add(Constants.CurrencyImportName);

            DataSetCurrency.Tables[Constants.CurrencyImportName].ReadXml(openDB.FileName);

            dataGridViewExtCurrency.AutoGenerateColumns = false;

            DataViewCurrency = new DataView();
            DataViewCurrency.Table = DataSetCurrency.Tables[Constants.CurrencyImportName];
            dataGridViewExtCurrency.DataSource = DataViewCurrency;

           // ImportFromCsv(openDB.FileName);
             EnableOptionsControls(true);
            }
            catch (Exception ex)
            {
                ErrorMessage("Ошибка при загрузке файла " + openDB.FileName + " : " + ex.Message);
                EnableOptionsControls(false);
            }
            finally
            {
                ;
            }

        }

        private void CurrencyForm_Load(object sender, EventArgs e)
        {
            EnableOptionsControls(false);
            dataGridViewExtCurrency.AutoGenerateColumns = false;
            dataGridViewMyCurrency.AutoGenerateColumns = false;

            if (!DataBase.DBOpened)
            {
                MessageBox.Show("Вначале нужно открыть базу данных");
                Close();
            }

            statusMessagePanel.ProgressVisible = false;
            statusMessagePanel.HidePanel();

            dataGridViewMyCurrency.DataSource = DataBase.SourceCurrency;
        
        }

        private void dataGridViewMyCurrency_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int col = e.ColumnIndex;
                if (col < 0) return;
                int row = e.RowIndex;
                if (row < 0) return;

                 #region Delete
                if (dataGridViewMyCurrency.Columns[col].GetType().Equals(typeof(DeleteTextColumn))) //Кликнули на столбце удаления
                {
                    DeleteTextCell buttonCell =
                        (DeleteTextCell)dataGridViewMyCurrency.Rows[row].Cells[col];

                    if (buttonCell.Enabled)
                    {

                        string name = dataGridViewMyCurrency.Rows[row].Cells["MyName"].Value.ToString();
                        string symbol = dataGridViewMyCurrency.Rows[row].Cells["MySymbol"].Value.ToString();
                        int index = Convert.ToInt32(dataGridViewMyCurrency.Rows[row].Cells["MyIndex"].Value);
                        //Надо проверить, не используется ли эта валюта в депозитах,
                        if (DataBase.CheckCurrencyInDeposits(index))
                        {

                            MessageBox.Show("Валюта " + name + " используется в депозитах, вначале нужно удалить все депозиты с этой валютой.");
                            return;
                        }
                        else
                        {
                            //Если в CheckCurrencyInDeposits произошла ошибка, то она вернет False, нужно проверить это
                            if (DataBase.ErrorOccurred)
                            {
                                MessageBox.Show("При проверке валюты произошла ошибка: " + lastError);
                                return;
                            }

                        }

                        DialogResult res = MessageBox.Show("Удалить валюту " + name + " из справочника?", "Удаление валюты", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                        if (res == DialogResult.Yes)
                        {
                            if (!DataBase.RemoveCurrency(index, name))
                            {
                                ErrorMessage("Ошибка : " + DataBase.LastError);
                            }
                        }
                    }

                }
                #endregion Delete

                #region Edit
                if (dataGridViewMyCurrency.Columns[col].GetType().Equals(typeof(EditButtonColumn))) //Кликнули на столбце редактирования
                {
                    EditButtonCell buttonCell =
                        (EditButtonCell)dataGridViewMyCurrency.Rows[row].Cells[col];

                    if (buttonCell.Enabled) //Если бы у нас вводилась новая строка, то кнопку надо было деактивировать
                    {

                        //string name = dataGridViewMyCurrency.Rows[row].Cells["MyName"].Value.ToString();
                        //string symbol = dataGridViewMyCurrency.Rows[row].Cells["MySymbol"].Value.ToString();
                        int index = Convert.ToInt32(dataGridViewMyCurrency.Rows[row].Cells["MyIndex"].Value);

                        EditCurrency(index);
                    }
                }
                #endregion Edit
            }
            catch (Exception ex)
            {
                ErrorMessage("Ошибка в dataGridViewMyCurrency_CellClick: " + ex.Message);
            }
        }


        /// <summary>
        /// Открыть форму редактирования валюты
        /// </summary>
        /// <param name="index"></param>
        private void EditCurrency(int index)
        {
            EditCurrencyForm frm = new EditCurrencyForm(DataBase, NeedAction.Edit, index);
            frm.ShowDialog();
        }

        private void buttonCurrencySelect_Click(object sender, EventArgs e)
        {
            CurrencyToMyCurrency();
        }

        private void dataGridViewExtCurrency_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            CurrencyToMyCurrency();
        }

        /// <summary>
        /// Активировать некоторые кнопки на tabPageControls
        /// </summary>
        /// <param name="enable"></param>
        private void EnableOptionsControls(bool enable)
        {
            buttonCurrencySelect.Enabled = enable;
            groupBoxLike.Enabled = enable;
        }

        private void CurrencyToMyCurrency()
        {
            DataGridViewRow current = dataGridViewExtCurrency.CurrentRow;
            if (current == null)
            {
                StatusMessage("ничего не выбрано");
            }

            //int index = Convert.ToInt32(current.Cells["MyIndex"].Value);
            string code = current.Cells["ExtCode"].Value.ToString();
            string symbol = current.Cells["ExtSymbol"].Value.ToString();
            string name = current.Cells["ExtName"].Value.ToString();
            string country = current.Cells["ExtCountry"].Value.ToString();
            decimal rate = 1;  //Курс по умолчани.

            if (CurrencyInMyCurrency(code) < 0)
            {
                DataBase.AddNewCurrency(code, symbol, name, country,rate);

            }
            else
            {
                MessageBox.Show(name + " уже в списке!");
            }
        }

        /// <summary>
        /// Есть ли валюта в моем списке
        /// </summary>
        /// <param name="code">Code</param>
        /// <returns></returns>
        private int CurrencyInMyCurrency(string code)
        {
            error = false;
            try
            {

                return DataBase.SourceCurrency.Find(Constants.CurrencyCode, code);

            }
            catch (Exception ex)
            {
                error=true;
                lastError = "Ошибка в CurrencyInMyCurrency: " + ex.Message;
                ErrorMessage(lastError);

                return -1;
            }
        }

        private void buttonLikeFind_Click(object sender, EventArgs e)
        {
            LikeFind();
        }

        private void buttonClearFilter_Click(object sender, EventArgs e)
        {
            textBoxLikeFind.Text = "";

            if (DataViewCurrency != null) DataViewCurrency.RowFilter = "";
        }

        private void LikeFind()
        {
            if (DataViewCurrency==null) return;

            string what = "name Like '*" + textBoxLikeFind.Text.Trim() + "*'";

            DataViewCurrency.RowFilter = what;

        }

        private void dataGridViewMyCurrency_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            int col = e.ColumnIndex;
            if (col < 0) return;
            int row = e.RowIndex;
            if (row < 0) return;
            if (row == dataGridViewMyCurrency.NewRowIndex) //Для новой записи декативируем кнопку удаления
            {
                // Disable the buttons
                ((DeleteTextCell)(dataGridViewMyCurrency.Rows[row].Cells["MyDelete"])).Enabled = false;
                ((EditButtonCell)(dataGridViewMyCurrency.Rows[row].Cells["MyEdit"])).Enabled = false;

            }
            else
            {
                // Enable the buttons
                ((DeleteTextCell)(dataGridViewMyCurrency.Rows[row].Cells["MyDelete"])).Enabled = true;
                ((EditButtonCell)(dataGridViewMyCurrency.Rows[row].Cells["MyEdit"])).Enabled = true;
            }
        }

        private void AddNewCurrency()
        {
            EditCurrencyForm frm = new EditCurrencyForm(DataBase, NeedAction.AddNew, 0);
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
                AddNewCurrency();
            }
        }
    }
}
