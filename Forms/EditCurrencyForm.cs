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
    public partial class EditCurrencyForm : Form
    {
        DatabaseClass DataBase=null;
        NeedAction Action;
        int IndexEditCurrency = -1; //индекс банка для редактирования
        int ToolTipDuration = 3000; //Длительность подсказки в мс
        bool NameValidated = false; //проверка короткого имени пройдена
        bool SymbolValidated = false; //проверка Symbol пройдена
        bool CodeValidated = false; //Проверка Code
        bool CountryValidated = false; //Проверка Страны
        bool RateValidated = false; //Проверка Курса

        string CodeOld; //Если редактируем запись и меняем code, то нужно убедиться, что нового нет в справочнике
        string SymbolOld;

        public EditCurrencyForm(DatabaseClass db, NeedAction action, int indexEditCurrency)
        {
            DataBase = db;
            Action =action;
            IndexEditCurrency = indexEditCurrency;

            InitializeComponent();

            numericTextBoxCurrencyRate.AllowDecimal = true;
            numericTextBoxCurrencyRate.AllowSeparator = false;

            textBoxCurrencyCode.AllowDecimal = false;
            textBoxCurrencyCode.AllowSeparator = false;
            textBoxCurrencyCode.MaxLength = Constants.CurrencyCodeLength;

            textBoxCurrencySymbol.OnlyLatin = true; //только латынь

            textBoxCurrencySymbol.MaxLength = Constants.CurrencySymbolLength; //Что-то не пашет, придется внутри LetterTextBox
            textBoxCurrencyCountry.MaxLength = Constants.MaxInputTextLength;
            textBoxCurrencyName.MaxLength = Constants.MaxInputTextLength;

        }

        private void EditCurrencyForm_Load(object sender, EventArgs e)
        {
            if (Action == NeedAction.AddNew)
            {
                this.Text = "Добавить новую валюту";
                buttonSaveCurrency.Text = "Добавить";
                GetValidated(); //Доступность кнопки Добавить
            }
            else if (Action == NeedAction.Edit)
            {
                this.Text = "Редактировать валюту";
                buttonSaveCurrency.Text = "Редактировать";

               SetValidated(true); //нужно установить все флаги в Проверено если все значения заданы
               FillEditCurrencyData(); //заполнить форму с данными редактируемого банка
              
            }
            else
            {

                MessageBox.Show("Требуемое действие " + Action.ToString() + " нераспознано");
                Close();
            }
        }

        private void FillEditCurrencyData()
        {
     
            DataRow row = DataBase.FindCurrencyById(IndexEditCurrency);
            if (row == null)
            {

                ErrorMessage("Нет данных по валюте с индексом " + IndexEditCurrency);
                SetValidated(false); //Уберем флаги
                return;
            }

            CodeOld = Convert.ToString(row[Constants.CurrencyCode]);
            SymbolOld = Convert.ToString(row[Constants.CurrencySymbol]);

            textBoxCurrencyCode.Text=CodeOld;
            textBoxCurrencySymbol.Text=SymbolOld;
            textBoxCurrencyName.Text=Convert.ToString(row[Constants.CurrencyName]);
            textBoxCurrencyCountry.Text = Convert.ToString(row[Constants.CurrencyCountry]);

            //MessageBox.Show("1"); почему-то под отладчиком ошибку не отлавдивает System.InvalidCastException: Невозможно выполнить приведение данного объекта из DBNull к другому типу.
            //А не отлавдивает потому что row[Constants.CurrencyRate] используешь, а надо row.Field<object>(Constants.CurrencyRate);
            decimal rate = 0;
            object rateObj = row.Field<object>(Constants.CurrencyRate);
            if (rateObj == null) //При обновлении может не заполнен курс
            {
                RateValidating(false);// инициируем проверку чтобы стал серый флаг
              
            }
            else
            {
                rate = Convert.ToDecimal(rateObj);
            }

            numericTextBoxCurrencyRate.Text = rate.ToString();

    
        }

        private bool CurrencyToMyCurrency(bool update)
        {

            string code = textBoxCurrencyCode.Text.Trim();
            string symbol = textBoxCurrencySymbol.Text.Trim();
            string name = textBoxCurrencyName.Text.Trim();
            string country = textBoxCurrencyCountry.Text.Trim();
            decimal rate = Convert.ToDecimal(numericTextBoxCurrencyRate.Text.Trim());

            if (update) //Обновление
            {
                if (CodeOld != code) //Изменили code, нужно проверить нет ли уже его в справочнике
                {
                    DataRow res = DataBase.FindCurrencyByCode(code);
                    if (res != null)
                    {
                        ErrorMessage("Валюта с кодом " + code + " уже существует в справочнике!");
                        return false;
                    }
                }
                
                if (SymbolOld != symbol)
                {
                    DataRow res = DataBase.FindCurrencyBySymbol(symbol);
                    if (res != null)
                    {
                        ErrorMessage("Валюта с символом " + symbol + " уже существует в справочнике!");
                        return false;
                    }
                }

                if (!DataBase.UpdateCurrency(IndexEditCurrency, code, symbol, name, country, rate))
                {
                    ErrorMessage("Ошибка при обновлении валюты " + name + ": " + DataBase.LastError);
                    return false;
                }
            }
            else //Добавление нового
            {
                DataRow res = DataBase.FindCurrencyByCode(code);
                if (res != null)
                {
                    ErrorMessage("Валюта с кодом " + code + " уже существует в справочнике!");
                    return false;
                }

                res = DataBase.FindCurrencyBySymbol(symbol);
                if (res != null)
                {
                    ErrorMessage("Валюта с символом " + symbol + " уже существует в справочнике!");
                    return false;
                }

                DataBase.AddNewCurrency(code, symbol, name, country, rate);
                if (DataBase.ErrorOccurred)
                {
                    ErrorMessage("Ошибка при добавлении валюты: " + DataBase.LastError);
                    return false;
                }

            }

            return true;
        }

        private void ErrorMessage(string value)
        {
            MessageBox.Show(value);
        }

        private void buttonSaveCurrency_Click(object sender, EventArgs e)
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
                if (CurrencyToMyCurrency(false))
                {
                    Close(); //При удачной вставке нового закрываем форму
                }
            }
            else if (Action == NeedAction.Edit)
            {
                if (CurrencyToMyCurrency(true))
                {
                    Close(); //При удачном обновлении закрываем форму
                }
            }
            else //Этого уже быть не должно, так как проверяем при открытии фоормы
            {

                MessageBox.Show("Требуемое действие " + Action.ToString() + " нераспознано");
            }
        }

        #region Проверка на коррекность значений

       /// <summary>
        /// Доступна ли кнопка Добавить/Сохранить
        /// </summary>
        private void GetValidated()
        {
            buttonSaveCurrency.Enabled = NameValidated & SymbolValidated & CodeValidated & CountryValidated & RateValidated ;
       
        }

        /// <summary>
        /// Установить все флаги
        /// </summary>
        /// <param name="value"></param>
        private void SetValidated(bool value)
        {
            NameValidated = SymbolValidated = CodeValidated = CountryValidated =RateValidated= value;
        }

        #endregion Проверка на коррекность значений

        /// <summary>
        /// Нужно по окончании редактирования все равно проверить на корректность значений
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxCurrencyCode_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = !CodeValidating(true);
        }

        /// <summary>
        /// Нужно по окончании редактирования все равно проверить на корректность значений. Наличие и длину кода.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private bool CodeValidating(bool showToolTip)
        {
            CodeValidated = false;
            pictureBoxCode.Image = Resources.notok;
            if (textBoxCurrencyCode.Text == String.Empty)
            {
                if (showToolTip)
                {
                    toolTip1.ToolTipTitle = "Отсутствует код валюты";
                    toolTip1.Show("Код валюты должен быть задан и состоять из " + Constants.CurrencyCodeLength + " цифр!", textBoxCurrencyCode, 0, -20, ToolTipDuration);
                    //e.Cancel = true;
                }
                return false; ;
            }

            if (textBoxCurrencyCode.Text.Length != Constants.CurrencyCodeLength)
            {
                if (showToolTip)
                {
                    toolTip1.ToolTipTitle = "Неправильный код валюты";
                    toolTip1.Show("Код валюты должен быть длиной " + Constants.CurrencyCodeLength + "!", textBoxCurrencyCode, 0, -20, ToolTipDuration);
                }
                return false;
            }
            CodeValidated = true;
            pictureBoxCode.Image = Resources.ok;

            return true;

        }

        private void textBoxCurrencyCode_TextChanged(object sender, EventArgs e)
        {
            CodeValidating(false);
            GetValidated(); //Надо проверить на корректность после изменения поля
        }

        private void textBoxCurrencySymbol_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = !SymbolValidating(true);
        }

        /// <summary>
        /// Проверим наличие и длину символа
        /// </summary>
        /// <param name="showToolTip"></param>
        /// <returns></returns>
        private bool SymbolValidating(bool showToolTip)
        {
            SymbolValidated = false;
            pictureBoxSymbol.Image = Resources.notok;
            if (textBoxCurrencySymbol.Text == String.Empty)
            {
                if (showToolTip)
                {
                    toolTip1.ToolTipTitle = "Отсутствует символ валюты";
                    toolTip1.Show("Символ валюты должен быть задан и состоять из " + Constants.CurrencyCodeLength + " латинских букв!", textBoxCurrencySymbol, 0, -20, ToolTipDuration);
                }
                return false; 
            }

            if (textBoxCurrencySymbol.Text.Length != Constants.CurrencySymbolLength)
            {
                if (showToolTip)
                {
                    toolTip1.ToolTipTitle = "Неправильный символ валюты";
                    toolTip1.Show("Символ валюты должен быть длиной " + Constants.CurrencySymbolLength + "!", textBoxCurrencySymbol, 0, -20, ToolTipDuration);
                }
                return false;
            }
            SymbolValidated = true;
            pictureBoxSymbol.Image = Resources.ok;

            return true;

        }

        private void textBoxCurrencySymbol_TextChanged(object sender, EventArgs e)
        {
            SymbolValidating(false);
            GetValidated(); 
        }

        private void textBoxCurrencyName_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = !NameValidating(true);
        }

        private void textBoxCurrencyName_TextChanged(object sender, EventArgs e)
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
            if (textBoxCurrencyName.Text == String.Empty)
            {
                if (showToolTip)
                {
                    toolTip1.ToolTipTitle = "Отсутствует наименование валюты";
                    toolTip1.Show("Наименование валюты должно быть задано!", textBoxCurrencyName, 0, -20, ToolTipDuration);
                }
                return false;
            }

            NameValidated = true;
            pictureBoxName.Image = Resources.ok;

            return true;

        }

        private void textBoxCurrencyCountry_TextChanged(object sender, EventArgs e)
        {
            CountryValidating(false);
            GetValidated(); 
        }

        private void textBoxCurrencyCountry_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = !CountryValidating(true);
        }

        /// <summary>
        /// Проверим наличие страны
        /// </summary>
        /// <param name="showToolTip"></param>
        /// <returns></returns>
        private bool CountryValidating(bool showToolTip)
        {
            CountryValidated = false;
            pictureBoxCountry.Image = Resources.notok;
            if (textBoxCurrencyCountry.Text == String.Empty)
            {
                if (showToolTip)
                {
                    toolTip1.ToolTipTitle = "Отсутствует название страны/региона";
                    toolTip1.Show("Название страны/региона валюты должно быть задано!", textBoxCurrencyCountry, 0, -20, ToolTipDuration);
                }
                return false;
            }

            CountryValidated = true;
            pictureBoxCountry.Image = Resources.ok;

            return true;

        }

        private void numericTextBoxCurrencyRate_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = !RateValidating(true);
        }

        private void numericTextBoxCurrencyRate_TextChanged(object sender, EventArgs e)
        {
            RateValidating(false);
            GetValidated();
        }

        /// <summary>
        /// Проверка на курс, Должен быть и быть положительным числом
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private bool RateValidating(bool showToolTip)
        {
            RateValidated = false;
            pictureBoxCurrencyRate.Image = Resources.notok;
            if (numericTextBoxCurrencyRate.Text == String.Empty)
            {
                if (showToolTip)
                {
                    toolTip1.ToolTipTitle = "Отсутствует курс валюты";
                    toolTip1.Show("Курс валюты должен быть задан!", numericTextBoxCurrencyRate, 0, -20, ToolTipDuration);
               
                }
                return false; 
            }

            if (Convert.ToDecimal(numericTextBoxCurrencyRate.Text) <=0)
            {
                if (showToolTip)
                {
                    toolTip1.ToolTipTitle = "Отрицательный или нулевой курс валюты";
                    toolTip1.Show("Курс валюты должен быть положительным числом!", numericTextBoxCurrencyRate, 0, -20, ToolTipDuration);

                }
                return false;
            }

            RateValidated = true;
            pictureBoxCurrencyRate.Image = Resources.ok;

            return true;

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
