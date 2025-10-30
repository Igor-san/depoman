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
    public partial class ClientsForm : Form
    {
        DatabaseClass DataBase=null;
        bool error = false;

        string lastError="";

        public ClientsForm(DatabaseClass db)
        {
            DataBase = db;
            InitializeComponent();

            dataGridViewMyClients.AutoGenerateColumns = false;
        }


        private void ErrorMessage(string error)
        {
             MessageBox.Show(error);
        }

        private void ClientsForm_Load(object sender, EventArgs e)
        {
            if (!DataBase.DBOpened)
            {
                MessageBox.Show("Вначале нужно открыть базу данных");
                Close();
            }
            dataGridViewMyClients.DataSource = DataBase.SourceClients;
        }

        private void ClientsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (dataGridViewMyClients.IsCurrentCellDirty)
            {
                if (MessageBox.Show("Существуют незафиксированные данные, " +
                       " сохранить их?", "Таблица клиентов в режиме изменения",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                dataGridViewMyClients.CommitEdit(DataGridViewDataErrorContexts.Commit);
                dataGridViewMyClients.EndEdit(); 
                 //Нужно дать знать другим таблицам обновиться? Хотя, если я уберу с главной формы, то не обязательно
                 }
                else{
                dataGridViewMyClients.CancelEdit();
                }
             }


            }


        private void dataGridViewMyClients_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            int col = e.ColumnIndex;
            if (col < 0) return;
            int row = e.RowIndex;
            if (row < 0) return;
            if (row == dataGridViewMyClients.NewRowIndex) //Для новой записи декативируем кнопку удаления
            {
                // Disable the buttons
                ((DeleteTextCell)(dataGridViewMyClients.Rows[row].Cells["MyDelete"])).Enabled = false;
                ((EditButtonCell)(dataGridViewMyClients.Rows[row].Cells["MyEdit"])).Enabled = false;
            }
            else
            {
                // Enable the buttons
                ((DeleteTextCell)(dataGridViewMyClients.Rows[row].Cells["MyDelete"])).Enabled = true;
                ((EditButtonCell)(dataGridViewMyClients.Rows[row].Cells["MyEdit"])).Enabled = true;
            }
     
        }

        private void dataGridViewMyClients_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int col = e.ColumnIndex;
                if (col < 0) return;
                int row = e.RowIndex;
                if (row < 0) return;

                #region Delete
                if (dataGridViewMyClients.Columns[col].GetType().Equals(typeof(DeleteTextColumn))) //Кликнули на столбце удаления
                {
                    DeleteTextCell buttonCell =
                        (DeleteTextCell)dataGridViewMyClients.Rows[row].Cells[col];

                    if (buttonCell.Enabled)
                    {

                        string name = dataGridViewMyClients.Rows[row].Cells["MyName"].Value.ToString();
                        int index = Convert.ToInt32(dataGridViewMyClients.Rows[row].Cells["MyIndex"].Value);
                        //Надо проверить, не используется ли этот клиент в депозитах,
                        if (CheckClientInDeposits(index))
                        {

                            MessageBox.Show("Клиент " + name + " используется в депозитах, вначале нужно удалить все депозиты с этим клиентом.");
                            return;
                        }
                        else
                        {
                            //Если в CheckClientInDeposits произошла ошибка, то она вернет False, нужно проверить это
                            if (error)
                            {
                                MessageBox.Show("При проверке клиента произошла ошибка: " + lastError);
                                return;
                            }

                        }

                        DialogResult res = MessageBox.Show("Удалить клиента " + name + " из списка?", "Удаление клиента", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                        if (res == DialogResult.Yes)
                        {
                            if (!DataBase.RemoveClient(index, name))
                            {
                                ErrorMessage("Ошибка : " + DataBase.LastError);
                            }
                        }
                    }
                }
                #endregion Delete

                #region Edit
                if (dataGridViewMyClients.Columns[col].GetType().Equals(typeof(EditButtonColumn))) //Кликнули на столбце редактирования
                {
                    EditButtonCell buttonCell =
                        (EditButtonCell)dataGridViewMyClients.Rows[row].Cells[col];

                    if (buttonCell.Enabled) //Если бы у нас вводилась новая строка, то кнопку надо было деактивировать
                    {

                        string name = dataGridViewMyClients.Rows[row].Cells["MyName"].Value.ToString();
                        int index = Convert.ToInt32(dataGridViewMyClients.Rows[row].Cells["MyIndex"].Value);

                        EditClient(index);
                    }
                }
                #endregion Edit
            }
            catch (Exception ex)
            {
                ErrorMessage("Ошибка в dataGridViewMyClients_CellClick: " + ex.Message);
            }
        }

        private void EditClient(int index)
        {
            EditClientForm frm = new EditClientForm(DataBase, NeedAction.Edit, index);
            frm.ShowDialog();
        }

        /// <summary>
        /// Проверим наличие клиента в справочние Депозиты
        /// </summary>
        /// <param name="index">Индекс клиента в справочнике Клиенты</param>
        /// <returns></returns>
        private bool CheckClientInDeposits(int index)
        {
            error = false;
            try
            {

                int pos = DataBase.SourceDeposits.Find(Constants.DepositsClientID, index);//поиск в таблице Депозиты, по полю DepositsClientID

                if (pos < 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }

            }
            catch (Exception ex)
            {
                error = true;
                lastError = "Ошибка в CheckClientsInDeposits: " + ex.Message;
                ErrorMessage(lastError);

                return false;
            }
        }

        private void AddNewClient()
        {
            EditClientForm frm = new EditClientForm(DataBase, NeedAction.AddNew, -1);
            frm.ShowDialog();
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem == toolStripCloseButton)
            {
                Close();
            }
            else if (e.ClickedItem == toolStripNewButton)
            {
                AddNewClient();
            }
        }

    }
}
