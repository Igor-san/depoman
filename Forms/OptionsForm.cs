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

namespace DepoMan.Forms
{
    public partial class OptionsForm : Form
    {
        bool firstLoad;// первая загрузка формы, чтобы не срабатывал на изменение переключателей (Комбобоксов например)
       
        DatabaseClass DataBase;

        public OptionsForm(DatabaseClass db)
        {
            InitializeComponent();
            DataBase = db;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        private void buttonOkClose_Click(object sender, EventArgs e)
        {
            string msg = "";
            try
            {
           #region DataBase НЕ зависимые

           #region AutoLoad
           msg = "AutoLoadLastDataBase";
           Common.ProgramSettings.AutoLoadLastDataBase = checkBoxAutoLoadLastDataBase.Checked;
           msg = "AutoSaveDataBaseOnClose";
           Common.ProgramSettings.AutoSaveDataBaseOnClose = checkBoxAutoSaveDataBaseOnClose.Checked;
           msg = "checkBoxAutoStartProgram.Checked";
           //Common.ProgramSettings.AutoStartProgram=checkBoxAutoStartProgram.Checked ; Все равно в реестре есть данные
           try
           {
               if (checkBoxAutoStartProgram.Checked)
               {
                   msg = "SetAutoStart";
                   AutoStart.SetAutoStart();
               }
               else
               {
                   msg = "UnSetAutoStart";
                   AutoStart.UnSetAutoStart();
               }
           }
           catch
           {
               ; //"значения для этого имени не существует"
           }

           msg = "MinimizeOnStart";
           Common.ProgramSettings.MinimizeOnStart = checkBoxMinimizeOnStart.Checked;
           #endregion AutoLoad

           #region напоминание
           msg = "RemindPriorEndDeposit";
           Common.ProgramSettings.RemindPriorEndDeposit = checkBoxRemindPriorEndDeposit.Checked;
           msg = "RemindPriorEndDepositDays";
           Common.ProgramSettings.RemindPriorEndDepositDays = (int) numericUpDownRemindPriorEndDeposit.Value;

           msg = "RemindInterestPayment";
           Common.ProgramSettings.RemindInterestPayment = checkBoxRemindInterestPayment.Checked;
           msg = "OffsetInterestPayment";
           Common.ProgramSettings.OffsetInterestPayment = (int)numericUpDownOffsetInterestPayment.Value;

           msg = "MinimizeOnClose";
           Common.ProgramSettings.MinimizeInsteadClose = checkBoxMinimizeInsteadClose.Checked;
           #endregion напоминание


           #endregion DataBase НЕ зависимые

           #region DataBase зависимые

           if (DataBase != null && DataBase.DBOpened)
           {
               SetDatabaseOptions();

           }

           #endregion DataBase зависимые

           this.DialogResult = DialogResult.OK;

            }
            catch(Exception ex)
            {
                MessageBox.Show("Ошибка при закрытии формы настроек [" + msg + "]:" + ex.Message);
            }

           Close();
            
        }

        private void OptionsForm_Load(object sender, EventArgs e)
        {
            firstLoad = true;
            try
            {
                if (!Global.IsDesignMode)
                {
                    // tabPageOnlyForMe.Dispose();

                }
                #region напоминание
                checkBoxRemindPriorEndDeposit.Checked = Common.ProgramSettings.RemindPriorEndDeposit;
                numericUpDownRemindPriorEndDeposit.Value = Common.ProgramSettings.RemindPriorEndDepositDays;

                checkBoxRemindInterestPayment.Checked=Common.ProgramSettings.RemindInterestPayment;
                numericUpDownOffsetInterestPayment.Value=Common.ProgramSettings.OffsetInterestPayment;
                #endregion напоминание

                #region AutoLoad
                checkBoxAutoStartProgram.Checked = AutoStart.IsAutoStartEnabled; //Common.ProgramSettings.AutoStartProgram //Проверим и на конфигурацию и на наличие в автостарте
                checkBoxAutoLoadLastDataBase.Checked = Common.ProgramSettings.AutoLoadLastDataBase;
                checkBoxAutoSaveDataBaseOnClose.Checked = Common.ProgramSettings.AutoSaveDataBaseOnClose;
                checkBoxMinimizeOnStart.Checked = Common.ProgramSettings.MinimizeOnStart;
                checkBoxMinimizeInsteadClose.Checked = Common.ProgramSettings.MinimizeInsteadClose ;



                #endregion AutoLoad

                if (DataBase!=null && DataBase.DBOpened)
                {
                    GetDatabaseOptions();

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке формы настроек:"+ex.Message);
            }
            firstLoad = false;
        }

        /// <summary>
        /// Настройки из самой базы
        /// </summary>
        private void GetDatabaseOptions()
        {
            try
            {

            #region Base Currency
            comboBoxBaseCurrency.DataSource = DataBase.SourceCurrency;
            comboBoxBaseCurrency.DisplayMember = Constants.CurrencySymbol;
            comboBoxBaseCurrency.ValueMember = Constants.CurrencyIndex;

            comboBoxBaseCurrency.SelectedIndex = -1;
            string baseCurrencyId = DataBase.FindConfigValueByName(Constants.BaseCurrencyId);
            if (!String.IsNullOrEmpty(baseCurrencyId))
            {

                comboBoxBaseCurrency.SelectedValue = Convert.ToInt32(baseCurrencyId); /// 17.02.2015
            }

            #endregion Base Currency

                        }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка в GetDatabaseOptions :" + ex.Message);
            }
        }

        /// <summary>
        /// Эти настройки пишутся в саму базу
        /// </summary>
        private void SetDatabaseOptions()
        {
            try
            {

            #region Base Currency

            string baseCurrencyID = Convert.ToInt32(comboBoxBaseCurrency.SelectedValue).ToString();
            DataBase.UpdateConfig(Constants.BaseCurrencyId, baseCurrencyID, true);
            #endregion Base Currency




            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка в SetDatabaseOptions :" + ex.Message);
            }

        }

    }
}
