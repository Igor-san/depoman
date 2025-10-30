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
using DepoMan.Properties;

namespace DepoMan.Forms
{
    public partial class EditClientForm : Form
    {
        DatabaseClass DataBase = null;
        NeedAction Action;
        int IndexEditClient = -1; //индекс клиента для редактирования
        int ToolTipDuration = 3000; //Длительность подсказки в мс
        bool NameValidated = false; //проверка  имени пройдена
        
        public EditClientForm(DatabaseClass db, NeedAction action, int client)
        {

            DataBase = db;
            Action = action;
            IndexEditClient = client;

            InitializeComponent();

            textBoxClientName.MaxLength = Constants.MaxInputTextLength;

        }

        private void ClientForm_Load(object sender, EventArgs e)
        {
            if (Action == NeedAction.AddNew)
            {
                this.Text = "Добавить нового клиента";
                buttonSave.Text = "Добавить";
                GetValidated(); //Доступность кнопки Добавить
            }
            else if (Action == NeedAction.Edit)
            {
                this.Text = "Редактировать клиента";
                buttonSave.Text = "Редактировать";
                FillEditClientData(); //заполнить форму с данными редактируемого
                SetValidated(true); //нужно установить все флаги в Проверено
            }
            else
            {

                MessageBox.Show("Требуемое действие " + Action.ToString() + " нераспознано");
                Close();
            }
        }

        #region Проверка на коррекность значений

        /// <summary>
        /// Установить все флаги
        /// </summary>
        /// <param name="value"></param>
        private void SetValidated(bool value)
        {
            NameValidated =  value;
        }

        /// <summary>
        /// Доступна ли кнопка Добавить/Сохранить
        /// </summary>
        private void GetValidated()
        {
            buttonSave.Enabled = NameValidated ;
        }

        private void textBoxClientName_TextChanged(object sender, EventArgs e)
        {
            ClientValidating(false);
            GetValidated(); 
        }

        private void textBoxClientName_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = !ClientValidating(true);
        }

        /// <summary>
        /// Проверим наличие имени
        /// </summary>
        /// <param name="showToolTip"></param>
        /// <returns></returns>
        private bool ClientValidating(bool showToolTip)
        {
            NameValidated = false;
            pictureClientName.Image = Resources.notok;
            if (textBoxClientName.Text == String.Empty)
            {
                if (showToolTip)
                {
                    toolTip1.ToolTipTitle = "Отсутствует имя клиента";
                    toolTip1.Show("Имя клиента должно быть задано!", textBoxClientName, 0, -20, ToolTipDuration);
                }
                return false;
            }

            NameValidated = true;
            pictureClientName.Image = Resources.ok;

            return true;

        }

        #endregion Проверка на коррекность значений

        private void buttonSave_Click(object sender, EventArgs e)
        {
            RunAction();
        }

        /// <summary>
        /// Выполнить требуемое действие
        /// </summary>
        private void RunAction()
        {
            if (Action == NeedAction.AddNew)
            {
                if (ClientToMyClient(false))
                {
                    Close(); //При удачной вставке нового закрываем форму
                }
            }
            else if (Action == NeedAction.Edit)
            {
                if (ClientToMyClient(true))
                {
                    Close(); //При удачном обновлении закрываем форму
                }
            }
            else //Этого уже быть не должно, так как проверяем при открытии фоормы
            {

                MessageBox.Show("Требуемое действие " + Action.ToString() + " нераспознано");
            }
        }

        private void FillEditClientData()
        {
            DataRow row = DataBase.FindClientById(IndexEditClient);
            if (row == null)
            {

                ErrorMessage("Нет данных по клиенту с индексом " + IndexEditClient);
                return;
            }

            textBoxClientName.Text = Convert.ToString(row[Constants.ClientsName]);

        }

        private bool ClientToMyClient(bool update)
        {

            string name = textBoxClientName.Text.Trim();

            if (update) //Обновление
            {

                if (!DataBase.UpdateClient(IndexEditClient, name))
                {
                    ErrorMessage("Ошибка при обновлении клиента " + name + ": " + DataBase.LastError);
                    return false;
                }
            }
            else //Добавление нового
            {

                DataBase.AddNewClient(name);
                if (DataBase.ErrorOccurred)
                {
                    ErrorMessage("Ошибка при добавлении клиента: " + DataBase.LastError);
                    return false;
                }

            }

            return true;
        }

        private void ErrorMessage(string value)
        {
            MessageBox.Show(value);
        }

    /// <summary>
    /// Заставим выйти по Эскейпу без изменения
    /// </summary>
    /// <param name="keyData"></param>
    /// <returns></returns>
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Escape)  //При кнопке Отменить не разрешает незаполненные значения пропускать. Но для этого есть buttonCancel.CausesValidation =false; !!!
            {
                this.AutoValidate = AutoValidate.Disable;
                buttonCancel.PerformClick();
                this.AutoValidate = AutoValidate.Inherit;
                return true;
            }
            return base.ProcessDialogKey(keyData);
        }

    }
}
