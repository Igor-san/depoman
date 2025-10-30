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
    public partial class EditDepositForm : Form
    {
        DatabaseClass DataBase = null;
        NeedAction Action;
        int IndexEditDeposit = -1; //индекс банка для редактирования
        int ToolTipDuration = 3000; //Длительность подсказки в мс

        bool NameValidated = false; //проверка наименования пройдена
        bool StartValidated = false; //проверка DateStart пройдена
        bool EndValidated = false; 
        bool AmountValidated = false; 
        bool PercentValidated = false; 
        bool BankValidated = false; 
        bool CurrencyValidated = false; 
        bool ClientValidated = false;

        /// <summary>
        /// Период выплаты процентов
        /// </summary>
        public PeriodInterestPayment PeriodInterestPaymentValue = PeriodInterestPayment.EndPeriod;
        /// <summary>
        /// День выплаты процентов
        /// </summary>
        public DayInterestPayment DayInterestPaymentValue = DayInterestPayment.DayOfDeposit;
        /// <summary>
        /// Извещать о выплате процентов
        /// </summary>
        public bool InterestPaymentNotification = false;

        public EditDepositForm(DatabaseClass db, NeedAction action, int indexEdit)
        {
            DataBase = db;
            Action =action;
            IndexEditDeposit = indexEdit;

            InitializeComponent();
        }

        private void ErrorMessage(string value)
        {
            MessageBox.Show(value);
        }

        private void EditDepositForm_Load(object sender, EventArgs e)
        {
            DataBindings();

           if (Action == NeedAction.AddNew)
            {
                this.Text = "Добавить новый депозит";
                buttonSave.Text = "Добавить";
                GetValidated(); //Доступность кнопки Добавить
            }
           else if (Action == NeedAction.Edit)
           {
               this.Text = "Редактировать депозит";
               buttonSave.Text = "Редактировать";
               FillEditDepositData(); //заполнить форму с данными редактируемого депозита
               SetValidated(true); //нужно установить все флаги в Проверено
               //buttonSave.Enabled = false; //Но дективировать кнопку, чтобы если не менял ничего, то и сохранять не надо, но тогда проверку ВСЕХ полей нужно
           }
           else
           {

               MessageBox.Show("Требуемое действие " + Action.ToString() + " нераспознано");
               Close();
           }

          
        }

        /// <summary>
        /// Установить привязку к справочникам
        /// </summary>
        private void DataBindings()
        {
            try
            {
                comboBoxBank.DataSource = DataBase.SourceBanks;
                comboBoxBank.DisplayMember = Constants.BanksName;
                comboBoxBank.ValueMember = Constants.BanksIndex;

                comboBoxBank.SelectedIndex = -1;

                comboBoxCurrency.DataSource = DataBase.SourceCurrency;
                comboBoxCurrency.DisplayMember = Constants.CurrencySymbol;
                comboBoxCurrency.ValueMember = Constants.CurrencyIndex;

                comboBoxCurrency.SelectedIndex = -1;

                comboBoxClient.DataSource = DataBase.SourceClients;
                comboBoxClient.DisplayMember = Constants.ClientsName;
                comboBoxClient.ValueMember = Constants.ClientsIndex;

                comboBoxClient.SelectedIndex = -1;

            }
            catch (Exception ex)
            {
                ErrorMessage("Ошибка в DataBindings: " + ex.Message);
            }
        }

        private void FillEditDepositData()
        {
          try
            {
            DataRow row = DataBase.FindDepositById(IndexEditDeposit);
            if (row == null)
            {

                ErrorMessage("Нет данных по депозиту с индексом " + IndexEditDeposit);
                return;
            }

            textBoxName.Text = Convert.ToString(row[Constants.DepositsName]);
            numericTextBoxAmount.Text = Convert.ToString(row[Constants.DepositsAmount]);
            numericTextBoxPercent.Text = Convert.ToString(row[Constants.DepositsPercent]);
            dateTimePickerStart.Value = Convert.ToDateTime(row[Constants.DepositsDateStart]);
            dateTimePickerEnd.Value = Convert.ToDateTime(row[Constants.DepositsDateEnd]);

         
            comboBoxBank.SelectedValue = Convert.ToInt32(row[Constants.DepositsBankID]);
            
            comboBoxCurrency.SelectedValue = Convert.ToInt32(row[Constants.DepositsCurrencyID]);
            
            comboBoxClient.SelectedValue = Convert.ToInt32(row[Constants.DepositsClientID]);

            checkBoxClosed.Checked = Convert.ToBoolean(row[Constants.DepositsClosed]);

          // if (row.Table.Columns.Contains(Constants.PeriodInterestPayment)) //проверим наличие столбца, вдруг старая версия- но я таблицу пересоздаю пока в памяти
               PeriodInterestPaymentValue = Common.GetPeriodInterestPayment(row[Constants.PeriodInterestPayment]);
          // if (row.Table.Columns.Contains(Constants.DayInterestPayment))
               DayInterestPaymentValue = Common.GetDayInterestPayment(row[Constants.DayInterestPayment]);
          // if (row.Table.Columns.Contains(Constants.InterestPaymentNotification)) - а вот с Булевым проблема, он там нулл
               InterestPaymentNotification = Common.GetInterestPaymentNotification(row[Constants.InterestPaymentNotification]);// Convert.ToBoolean(row[Constants.InterestPaymentNotification]);

            ShowInterestPayment(PeriodInterestPaymentValue, DayInterestPaymentValue, InterestPaymentNotification);

            }
           catch (Exception ex)
          {
             ErrorMessage("Ошибка в FillEditDepositData: " + ex.Message);
          }

        }



        private bool DepositToMyDeposit(bool update)
        {
            DepositInfo deposit = new DepositInfo();

            deposit.Name = textBoxName.Text.Trim();
            deposit.Amount =Convert.ToDecimal(numericTextBoxAmount.Text.Trim());
            deposit.Percent = Convert.ToDecimal(numericTextBoxPercent.Text.Trim());
            deposit.DateStart = dateTimePickerStart.Value;
            deposit.DateEnd = dateTimePickerEnd.Value;
            deposit.BankID =Convert.ToInt32(comboBoxBank.SelectedValue);
            deposit.CurrencyID = Convert.ToInt32(comboBoxCurrency.SelectedValue);
            deposit.ClientID = Convert.ToInt32(comboBoxClient.SelectedValue);
            deposit.Closed = checkBoxClosed.Checked;

            deposit.PeriodInterestPaymentValue = PeriodInterestPaymentValue;
            deposit.DayInterestPaymentValue = DayInterestPaymentValue;
            deposit.InterestPaymentNotification = InterestPaymentNotification;

            if (update) //Обновление
            {

                if (!DataBase.UpdateDeposit(IndexEditDeposit, deposit))
                {
                    ErrorMessage("Ошибка при обновлении депозита " + deposit.Name + ": " + DataBase.LastError);
                    return false;
                }
            }
            else //Добавление нового
            {

                DataBase.AddNewDeposit(deposit);
                if (DataBase.ErrorOccurred)
                {
                    ErrorMessage("Ошибка при добавлении депозита " + deposit.Name + ": " + DataBase.LastError);
                    return false;
                }

            }

            return true;
        }

        /// <summary>
        /// Доступна ли кнопка Добавить/Сохранить
        /// </summary>
        private void GetValidated()
        {
            buttonSave.Enabled = NameValidated & AmountValidated &
                PercentValidated & StartValidated &  EndValidated &
                BankValidated & CurrencyValidated & ClientValidated;

        }

        /// <summary>
        /// Установить все флаги
        /// </summary>
        /// <param name="value"></param>
        private void SetValidated(bool value)
        {
            NameValidated = AmountValidated = PercentValidated =
                StartValidated = EndValidated =BankValidated=
                CurrencyValidated = CurrencyValidated = ClientValidated=value;
        }

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
                if (DepositToMyDeposit(false))
                {
                    Close(); //При удачной вставке нового закрываем форму
                }
            }
            else if (Action == NeedAction.Edit)
            {
                if (DepositToMyDeposit(true))
                {
                    Close(); //При удачном обновлении закрываем форму
                }
            }
            else //Этого уже быть не должно, так как проверяем при открытии фоормы
            {

                MessageBox.Show("Требуемое действие " + Action.ToString() + " нераспознано");
            }
        }

        #region   Валидация данных
        private void textBoxName_TextChanged(object sender, EventArgs e)
        {
            NameValidating(false);
            GetValidated(); 
        }

        /// <summary>
        /// Проверим наличие имени
        /// </summary>
        /// <param name="showToolTip"></param>
        /// <returns></returns>
        private bool NameValidating(bool showToolTip)
        {
            NameValidated = false;
            pictureBoxName.Image = Resources.notok;
            if (textBoxName.Text == String.Empty)
            {
                if (showToolTip)
                {
                    toolTip1.ToolTipTitle = "Отсутствует депозита";
                    toolTip1.Show("Название депозита должно быть задано!", textBoxName, 0, -20, ToolTipDuration);
                }
                return false;
            }

            NameValidated = true;
            pictureBoxName.Image = Resources.ok;

            return true;

        }

        private void textBoxName_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = !NameValidating(true);
        }


        private void numericTextBoxAmount_TextChanged(object sender, EventArgs e)
        {
            AmountValidating(false);
            GetValidated(); 
        }

        private void numericTextBoxAmount_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = !AmountValidating(true);
        }

        /// <summary>
        /// Проверим наличие суммы (её корректность наш numericTextBox проверяет внутри)
        /// </summary>
        /// <param name="showToolTip"></param>
        /// <returns></returns>
        private bool AmountValidating(bool showToolTip)
        {
            AmountValidated = false;
            pictureBoxAmount.Image = Resources.notok;
            if (numericTextBoxAmount.Text == String.Empty)
            {
                if (showToolTip)
                {
                    toolTip1.ToolTipTitle = "Отсутствует сумма";
                    toolTip1.Show("Сумма депозита должна быть задана!", numericTextBoxAmount, 0, -20, ToolTipDuration);
                }
                return false;
            }

            AmountValidated = true;
            pictureBoxAmount.Image = Resources.ok;

            return true;

        }

        private void numericTextBoxPercent_TextChanged(object sender, EventArgs e)
        {
            PercentValidating(false);
            GetValidated(); 
        }

        private void numericTextBoxPercent_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = !PercentValidating(true);
        }
        /// <summary>
        /// Проверим наличие суммы (её корректность наш numericTextBox проверяет внутри)
        /// </summary>
        /// <param name="showToolTip"></param>
        /// <returns></returns>
        private bool PercentValidating(bool showToolTip)
        {
            PercentValidated = false;
            pictureBoxPercent.Image = Resources.notok;
            if (numericTextBoxPercent.Text == String.Empty)
            {
                if (showToolTip)
                {
                    toolTip1.ToolTipTitle = "Отсутствует процент";
                    toolTip1.Show("Процент депозита должен быть задан!", numericTextBoxPercent, 0, -20, ToolTipDuration);
                }
                return false;
            }

            PercentValidated = true;
            pictureBoxPercent.Image = Resources.ok;

            return true;

        }

        private void dateTimePickerStart_ValueChanged(object sender, EventArgs e)
        {
            StartValidated = true;
            pictureBoxStart.Image = Resources.ok;
           // StartValidating(false);
            GetValidated(); 
        }


        private void dateTimePickerEnd_ValueChanged(object sender, EventArgs e)
        {
            //EndValidating(false); //У нас по умолчанию и так Дата устанавливается
            EndValidated = true;
            pictureBoxEnd.Image = Resources.ok;
            GetValidated(); 
        }

        private void comboBoxBank_SelectedIndexChanged(object sender, EventArgs e)
        {
            BankValidating(false);
            GetValidated(); 
        }

        private bool BankValidating(bool showToolTip)
        {
            BankValidated = false;
            pictureBoxBank.Image = Resources.notok;
            if (comboBoxBank.SelectedIndex == -1)
            {
                if (showToolTip)
                {
                    toolTip1.ToolTipTitle = "Отсутствует банк";
                    toolTip1.Show("Банк должен быть задан!", comboBoxBank, 0, -20, ToolTipDuration);
                }
                return false;
            }

            BankValidated = true;
            pictureBoxBank.Image = Resources.ok;
            return true;
        }

        private void comboBoxBank_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = !BankValidating(true);
        }

        private void comboBoxCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {
            CurrencyValidating(false);
            GetValidated(); 
        }

        private void comboBoxCurrency_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = !CurrencyValidating(true);
        }
        private bool CurrencyValidating(bool showToolTip)
        {
            CurrencyValidated = false;
            pictureBoxCurrency.Image = Resources.notok;
            if (comboBoxCurrency.SelectedIndex == -1)
            {
                if (showToolTip)
                {
                    toolTip1.ToolTipTitle = "Отсутствует валюта";
                    toolTip1.Show("Валюта должна быть задана!", comboBoxCurrency, 0, -20, ToolTipDuration);
                }
                return false;
            }

            CurrencyValidated = true;
            pictureBoxCurrency.Image = Resources.ok;
            return true;
        }

       

        private void comboBoxClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClientValidating(false);
            GetValidated(); 
        }

        private void comboBoxClient_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = !ClientValidating(true);
        }
        private bool ClientValidating(bool showToolTip)
        {
            ClientValidated = false;
            pictureBoxClient.Image = Resources.notok;
            if (comboBoxClient.SelectedIndex == -1)
            {
                if (showToolTip)
                {
                    toolTip1.ToolTipTitle = "Отсутствует клиент";
                    toolTip1.Show("Клиент должен быт задан!", comboBoxClient, 0, -20, ToolTipDuration);
                }
                return false;
            }

            ClientValidated = true;
            pictureBoxClient.Image = Resources.ok;
            return true;
        }

        #endregion   Валидация данных

        private void buttonInterestPayment_Click(object sender, EventArgs e)
        {
            InterestPaymentForm frm = new InterestPaymentForm();

            frm.PeriodInterestPaymentValue=PeriodInterestPaymentValue;
            frm.DayInterestPaymentValue= DayInterestPaymentValue;
            frm.InterestPaymentNotification=InterestPaymentNotification;
            if (frm.ShowDialog() == DialogResult.OK)
            {

                PeriodInterestPaymentValue = frm.PeriodInterestPaymentValue;
                DayInterestPaymentValue = frm.DayInterestPaymentValue;
                InterestPaymentNotification = frm.InterestPaymentNotification;
                ShowInterestPayment(PeriodInterestPaymentValue, DayInterestPaymentValue, InterestPaymentNotification);
            }
            else //Отменили или ошибка
            {


            }
        }

        private void ShowInterestPayment(PeriodInterestPayment periodInterestPayment, DayInterestPayment dayInterestPayment, bool notificationEnabled)
        {
                string notifi = (notificationEnabled) ? "Оповещать" : "Не оповещать";

                textBoxInterestPayment.Text = periodInterestPayment.GetDescription() + Environment.NewLine +
                    dayInterestPayment.GetDescription() + Environment.NewLine +
                    notifi;

        }

    }
}
