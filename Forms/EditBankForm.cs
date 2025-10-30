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
    public partial class EditBankForm : Form
    {
        DatabaseClass DataBase=null;
        NeedAction Action;
        int IndexEditBank = -1; //индекс банка для редактирования
        int ToolTipDuration = 3000; //Длительность подсказки в мс
        bool ShortNameValidated = false; //проверка короткого имени пройдена
        bool BikValidated = false; //проверка BIK пройдена
        //bool RegNumValidated = false; //Проверка Рег № Не контролируем, может не быть

        //string RegNumOld; //Если редактируем запись и меняем regNum, то нужно убедиться, что нового нет в базе
        string  BikOld; 

        public EditBankForm(DatabaseClass db,NeedAction action,int indexEditBank)
        {
            DataBase = db;
            Action =action;
            IndexEditBank = indexEditBank;

            InitializeComponent();

            //textBoxRegNum.AllowDecimal = false;
            //textBoxRegNum.AllowSeparator = false;

            textBoxBankFullName.MaxLength = Constants.MaxInputTextLength;
            textBoxBankShortName.MaxLength = Constants.MaxInputTextLength;
            textBoxBik.MaxLength = Constants.BIKLength;


        }

        private void NewBankForm_Load(object sender, EventArgs e)
        {

            if (Action == NeedAction.AddNew)
            {
                this.Text = "Добавить новый банк";
                buttonSaveBank.Text = "Добавить";
                GetValidated(); //Доступность кнопки Добавить
            }
            else if (Action == NeedAction.Edit)
            {
                this.Text = "Редактировать банк";
                buttonSaveBank.Text = "Редактировать";
                FillEditBankData(); //заполнить форму с данными редактируемого банка
                SetValidated(true); //нужно установить все флаги в Проверено
            }
            else
            {

                MessageBox.Show("Требуемое действие " + Action.ToString() + " нераспознано");
                Close();
            }

            
        }


        private void FillEditBankData()
        {
            DataRow row=DataBase.FindBankById(IndexEditBank);
            if (row==null)
            {

                ErrorMessage("Нет данных по банку с индексом "+IndexEditBank);
                return;
            }

            BikOld = Convert.ToString(row[Constants.BanksBIK]);

            textBoxRegNum.Text =  Convert.ToString(row[Constants.BanksRegNum]);
            textBoxBik.Text =  Convert.ToString(row[Constants.BanksBIK]);
            textBoxBankFullName.Text=Convert.ToString(row[Constants.BanksFullName]);
            textBoxBankShortName.Text = Convert.ToString(row[Constants.BanksName]);
        }

        private bool BankToMyBanks(bool update)
        {

            string regNum = textBoxRegNum.Text.Trim();
            string bik = textBoxBik.Text.Trim();
            string fullName = textBoxBankFullName.Text.Trim();
            string name = textBoxBankShortName.Text.Trim();

            if (update) //Обновление
            {
               
                if (BikOld != bik) //Ессли изменили БИК
                {
                    int res = DataBase.BankInMyBankByBik(bik);
                    if (res >=0)
                    {
                        ErrorMessage("Банк с БИК " + bik + " уже существует в справочнике!");
                        return false;
                    }
                }

                if (!DataBase.UpdateBank(IndexEditBank, regNum, bik, name, fullName))
                {
                    ErrorMessage("Ошибка при обновлении банка "+name+": " + DataBase.LastError);
                    return false;
                }
            }
            else //Добавление нового
            {
                int res = DataBase.BankInMyBankByRegNum(regNum);
                    if (res>=0)
                    {
                        ErrorMessage("Банк с номером "+regNum + " уже существует в справочнике!");
                        return false;
                    }

                res = DataBase.BankInMyBankByBik(bik);
                    if (res >=0)
                    {
                        ErrorMessage("Банк с БИК " + bik + " уже существует в справочнике!");
                        return false;
                    }

                 DataBase.AddNewBank(regNum, bik, name, fullName);
                    if (DataBase.ErrorOccurred)
                    {
                        ErrorMessage("Ошибка при добавлении банка: " + DataBase.LastError);
                        return false;
                    }

            }

            return true;
        }

        private void ErrorMessage(string value)
        {
            MessageBox.Show(value);
        }

        private void buttonAddNewBank_Click(object sender, EventArgs e)
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
                if (BankToMyBanks(false))
                {
                    Close(); //При удачной вставке нового банка закрываем форму
                }
            }
            else if (Action == NeedAction.Edit)
            {
                if (BankToMyBanks(true))
                {
                    Close(); //При удачном обновлении банка закрываем форму
                }
            }
            else //Этого уже быть не должно, так как проверяем при открытии фоормы
            {

                MessageBox.Show("Требуемое действие " + Action.ToString() + " нераспознано");
            }
        }

        #region Проверка на коррекность значений


        private void textBoxBik_Validating(object sender, CancelEventArgs e)
        {
            BikValidated = false;
            pictureBoxBik.Image = Resources.notok;
            if (textBoxBik.Text == String.Empty)
            {
                    toolTip1.ToolTipTitle = "Отсутствует БИК";
                    toolTip1.Show("БИК должен быть задан!", textBoxBik, 0, -20, ToolTipDuration);
                e.Cancel = true;
                return;
            }
            if (textBoxBik.Text.Length != Constants.BIKLength)
            {
                    toolTip1.ToolTipTitle = "Неправильный БИК";
                    toolTip1.Show("БИК должен быть длиной " + Constants.BIKLength + "!", textBoxBik, 0, -20, ToolTipDuration);
                e.Cancel = true;
                return;
            }

            int temp;
            bool res=Int32.TryParse(textBoxBik.Text, out temp); //032 будет распознано как числовое значение, в БИК это нам подойдет
            if (!res)
            {
                    toolTip1.ToolTipTitle = "Неправильный БИК";
                    toolTip1.Show("Регистрационный номер должен содержать только цифры!", textBoxBik, 0, -20, ToolTipDuration);
                e.Cancel = true;
                return;
            }
            BikValidated = true;
            pictureBoxBik.Image = Resources.ok;
        }

        private void textBoxBik_TextChanged(object sender, EventArgs e)
        {

            ValidateBik();
            GetValidated(); //Надо проверить на корректность после изменения поля

        }

        private void ValidateBik()
        {
            BikValidated = false;
            pictureBoxBik.Image = Resources.notok;
            if (textBoxBik.Text == String.Empty)
            {
                return;
            }
            if (textBoxBik.Text.Length != Constants.BIKLength)
            {
                return;
            }

            int temp;
            bool res = Int32.TryParse(textBoxBik.Text, out temp); //032 будет распознано как числовое значение, в БИК это нам подойдет
            if (!res)
            {
                return;
            }
            BikValidated = true;
            pictureBoxBik.Image = Resources.ok;
        }

        private void textBoxBik_KeyDown(object sender, KeyEventArgs e)
        {
            toolTip1.Hide(textBoxBik);
        }


        private void textBoxBankFullName_Validating(object sender, CancelEventArgs e)
        {
            ;//Полное имя нас не интересует 
        }

        private void textBoxBankFullName_KeyDown(object sender, KeyEventArgs e)
        {
            toolTip1.Hide(textBoxBankFullName);
        }

        private void textBoxBankShortName_Validating(object sender, CancelEventArgs e)
        {
            ShortNameValidated = false;
            pictureBoxShortName.Image = Resources.notok;
            if (textBoxBankShortName.Text == String.Empty)
            {
                toolTip1.ToolTipTitle = "Отсутствует имя банка";
                toolTip1.Show("Имя банка должно быть задано!", textBoxBankShortName, 0, -20, ToolTipDuration);
                e.Cancel = true;
                
                return;
            }

            ShortNameValidated = true;
            pictureBoxShortName.Image = Resources.ok;
        }

        private void textBoxBankShortName_TextChanged(object sender, EventArgs e)
        {
            ValidateShortName();
            GetValidated(); //Надо проверить на корректность после изменения поля
        }

        private void ValidateShortName()
        {
            ShortNameValidated = false;
            pictureBoxShortName.Image = Resources.notok;
            if (textBoxBankShortName.Text == String.Empty)
            {
                return;
            }
            ShortNameValidated = true;
            pictureBoxShortName.Image = Resources.ok;
        }

        private void textBoxBankShortName_KeyDown(object sender, KeyEventArgs e)
        {
            toolTip1.Hide(textBoxBankShortName);
        }

        /// <summary>
        /// Доступна ли кнопка Добавить/Сохранить
        /// </summary>
        private void GetValidated()
        {
            buttonSaveBank.Enabled = ShortNameValidated & BikValidated ;
        }

        /// <summary>
        /// Установить все флаги
        /// </summary>
        /// <param name="value"></param>
        private void SetValidated(bool value)
        {
            ShortNameValidated = BikValidated =  value;
        }

        #endregion Проверка на коррекность значений


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
