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
    public partial class InterestPaymentForm : Form
    {
        bool firstLoad;// первая загрузка формы, чтобы не срабатывал на изменение переключателей (Комбобоксов например)

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

        public InterestPaymentForm()
        {
            InitializeComponent();
   
        }

        private void FillComboBoxPeriodInterestPayment()
        {
            comboBoxPeriodInterestPayment.DataSource = new List<PeriodInterestPayment>((PeriodInterestPayment[])Enum.GetValues(typeof(PeriodInterestPayment)))
                  .Select(value => new { Display = value.GetDescription(), Value = value })
                  .ToList();
            comboBoxPeriodInterestPayment.DisplayMember = "Display";
            comboBoxPeriodInterestPayment.ValueMember = "Value";

        }

        private void FillComboBoxDayInterestPayment()
        {
            comboBoxDayInterestPayment.DataSource = new List<DayInterestPayment>((DayInterestPayment[])Enum.GetValues(typeof(DayInterestPayment)))
                  .Select(value => new { Display = value.GetDescription(), Value = value })
                  .ToList();
            comboBoxDayInterestPayment.DisplayMember = "Display";
            comboBoxDayInterestPayment.ValueMember = "Value";

        }

        private void InterestPaymentForm_Load(object sender, EventArgs e)
        {
            firstLoad = true;
            try
            {
                checkBoxNotification.Checked=InterestPaymentNotification;

                comboBoxPeriodInterestPayment.Items.Clear();
                comboBoxPeriodInterestPayment.Text = "";

                FillComboBoxPeriodInterestPayment();
                comboBoxPeriodInterestPayment.SelectedValue = PeriodInterestPaymentValue;

                comboBoxDayInterestPayment.Items.Clear();
                comboBoxDayInterestPayment.Text = "";

                FillComboBoxDayInterestPayment();
                comboBoxDayInterestPayment.SelectedValue = DayInterestPaymentValue;

                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке формы 'Выплата процентов':" + ex.Message);
            }
            firstLoad = false;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        private void buttonOkClose_Click(object sender, EventArgs e)
        {
            try
            {


                PeriodInterestPaymentValue=(PeriodInterestPayment)comboBoxPeriodInterestPayment.SelectedValue;
                DayInterestPaymentValue=(DayInterestPayment)comboBoxDayInterestPayment.SelectedValue;
                InterestPaymentNotification= checkBoxNotification.Checked;

                //Проверить, при Ежеквартальной выплате День открытия депозита и Следующий день не используется!
                if (PeriodInterestPaymentValue == PeriodInterestPayment.Quarterly)
                {
                    if (DayInterestPaymentValue == DayInterestPayment.DayOfDeposit || DayInterestPaymentValue == DayInterestPayment.NextDayOfDeposit)
                    {
                        MessageBox.Show("Для ежеквартальной выплаты установите либо начало либо конец периода!");
                        return;
                    }


                }
                this.DialogResult = DialogResult.OK;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при закрытии формы 'Выплата процентов':" + ex.Message);
            }

            Close();
        }

    }
}
