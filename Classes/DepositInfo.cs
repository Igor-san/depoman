using System;

namespace DepoMan.Classes
{
    public class DepositInfo
    {
        /// <summary>
        /// Название депозита
        /// </summary>
        public string Name
        { get; set; }
        /// <summary>
        /// Сумма депозита
        /// </summary>
        public decimal Amount
        { get; set; }
        /// <summary>
        /// Процент депозита
        /// </summary>
        public decimal Percent
        { get; set; }
        /// <summary>
        /// Начало депозита
        /// </summary>
        public DateTime DateStart
        { get; set; }
        /// <summary>
        /// Окончание депозита
        /// </summary>
        public DateTime DateEnd
        { get; set; }
        /// <summary>
        /// Закрыт ли депозит
        /// </summary>
        public bool Closed
        { get; set; }
        /// <summary>
        /// Индекс (ID) банка
        /// </summary>
        public int BankID
        { get; set; }
        /// <summary>
        /// Индекс (ID) валюты
        /// </summary>
        public int CurrencyID
        { get; set; }
        /// <summary>
        /// Индекс (ID) клиента
        /// </summary>
        public int ClientID
        { get; set; }

        /// <summary>
        /// Период выплаты процентов
        /// </summary>
        public PeriodInterestPayment PeriodInterestPaymentValue
        { get; set; }

        /// <summary>
        /// День выплаты процентов
        /// </summary>
        public DayInterestPayment DayInterestPaymentValue
        { get; set; }
        /// <summary>
        /// Извещать о выплате процентов
        /// </summary>
        public bool InterestPaymentNotification
        { get; set; }
    }
}

