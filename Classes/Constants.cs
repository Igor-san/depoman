using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace DepoMan.Classes
{
    /// <summary>
    /// Какое действие требуется, редактирование, добавление нового - чтобы использовать одну форму справочника
    /// </summary>
    public enum NeedAction
    {
        Edit,
        AddNew
    }

    public enum PeriodInterestPayment
    {
       [Description("Ежедневно")]
       Daily, // Ежедневно,
        [Description("Ежемесячно")]
       Monthly, //Ежемесячно,
        [Description("Ежеквартально")]
       Quarterly, //Ежеквартально,
        [Description("Ежегодно")]
       Annually, //Ежегодно,
        [Description("В конце срока")]
       EndPeriod, //В конце срока,
        [Description("В начале срока")]
       StartPeriod //В начале срока,
    }

    public enum DayInterestPayment
    {
        [Description("Первый день периода")]
        FirstDayPeriod,
        [Description("Последний день периода")]
        LastDayPeriod,
        [Description("День открытия вклада")]
        DayOfDeposit,
        [Description("День, следующий за открытием вклада")]
        NextDayOfDeposit
    }

    public static class Constants
    {
        public const string ProgramFullName = "Deposit Manager"; 
        public const string ProgramShortName = "DepoMan"; //имя программы для папок,названий файлов
        public const string AppDataPath = "HomeSoft\\" + ProgramShortName; //Имя папки в Application Data, где храняться изменяемые файлы
        public const string SettingsFileName = ProgramShortName+".cfg";
        
        public const string HelpFile = ProgramShortName + ".chm";
        //public const string FilterDataBase = "XML Files (*.xml)|*.xml|SDF Files (*.sdf)|*.sdf|All Files (*.*)|*.*";
        public const string XmlFilter = "XML Files (*.xml)|*.xml|All Files (*.*)|*.*"; //Для переноса баз

        public const string FilterDataBase = "XML Files (*.xml)|*.xml|All Files (*.*)|*.*"; //вдруг поменяю расширение для баз
        public const string HelpFileExt = ".htm"; //какое расширение подставлять в Хэлп
        public const int MaxLastOpenFiles = 4;

        public const int MaxInputTextLength = 50; //Максимальная длина текста в базе данных. Делаю равным для всех
        public const int MaxDepositsNameLength = 100; //У меня попалось название депозита на 56 длина !!
        public const int BIKLength = 9; //Длина поля БИК
        public const int CurrencyCodeLength = 3; //Длина кода валюты 810
        public const int CurrencySymbolLength = 3; //Длина символа валюты RUB

        public const string DataBasesFolderName = "Databases";
        public const string BikFolderName = "Bik";
        public const string OkvFolderName = "Okv";


        public const string BanksImportName = "banks"; //название таблицы общее, в ReferenceToXml и BanksForm для экспорта импорта
        public const string CurrencyImportName = "currency"; //название таблицы общее, в ReferenceToXml и CurrencyForm для экспорта импорта

        #region Tables
        public const string DataSetName = "DataSetAccount"; //

        #region Config

        public const string ConfigTableName = "config"; //Название таблицы
        public const string ConfigName = "name"; //Название столбца с Name
        public const string ConfigValue = "value"; //Value

        //Этими параметрами мы определяем, что это наша база, а не левый xml файл
        public const string DbVersionName = "database_version";
        public const int DbVersionValue = 1;

        public const string BaseCurrencyId = "base_currency_id"; //Индекс,Id, базовой валюты 

        #endregion Config

        #region Banks
        /*
     CREATE TABLE [banks] (
	[id] int NOT NULL IDENTITY(1,1) PRIMARY KEY, 
	[regn] int NOT NULL, 
	[bik] nvarchar(9) NOT NULL,   ?? int Нельзя, нужно string,так как есть с 0 вначале, "044583139";
	[name] nvarchar(50) NOT NULL, 
	[fullname] nvarchar(50) NOT NULL
    )
         * */
        public const string BanksTableName = "banks"; //Название таблицы с банками
        public const string BanksIndex = "id"; //Название столбца с Индексом
        public const string BanksRegNum = "regn"; //Название столбца с регистрационным номером - Лицензия, может и не быть, текстовый 2816/19 или 3512-К
        public const string BanksBIK = "bik"; //Название столбца с БИК
        public const string BanksName = "name"; //Название столбца с кратким наименование
        public const string BanksFullName = "fullname"; //Название столбца с полным наименование
        #endregion Banks

        #region Currency //ОКВ — Общероссийский классификатор валют.

        /*
        CREATE TABLE [currency] (
	[id] int NOT NULL IDENTITY(1,1) PRIMARY KEY, 
	[code] numeric(3, 0) NOT NULL,  ?? int Нельзя, есть нули вначале 032
	[symbol] nvarchar(3) NOT NULL, 
	[name] nvarchar(50) NOT NULL, 
	[iso] nvarchar(50)
)
       В связи с включением в реестр Международного стандарта ISO-4217 "Коды для представления валют и фондов" нового кода валюты Российской Федерации - российского рубля (деноминированного) с цифровым кодом "643", буквенным - "RUB" вместо кода "810 RUR", нового кода немецкой марки "276 DEM" вместо кода "280 DEM" и вводом в действие с 1 января 2001 года в банковской системе Российской Федерации Изменений к Общероссийскому классификатору валют (ОКВ) N 7/2000 и N 8/2000 Банк России разъясняет следующее.
https://ru.wikipedia.org/wiki/%D0%9E%D0%B1%D1%89%D0%B5%D1%80%D0%BE%D1%81%D1%81%D0%B8%D0%B9%D1%81%D0%BA%D0%B8%D0%B9_%D0%BA%D0%BB%D0%B0%D1%81%D1%81%D0%B8%D1%84%D0%B8%D0%BA%D0%B0%D1%82%D0%BE%D1%80_%D0%B2%D0%B0%D0%BB%D1%8E%D1%82
   
         * * */
        public const string CurrencyTableName = "currency"; //Название таблицы с валютами
        public const string CurrencyIndex = "id"; //Название столбца с Индексом
        public const string CurrencyCode = "code"; //Название столбца с кодом "643"
        public const string CurrencySymbol = "symbol"; //Название столбца с буквенным кодом "RUB"
        public const string CurrencyName = "name"; //Название столбца с именем ОКВ "Российский рубль"
        public const string CurrencyRate = "rate"; //курс валюты по отношению к базовой валюте, которую устанавливаем в настройке
        public const string CurrencyCountry = "country"; // Краткое наименование стран

        #endregion Currency

        #region Clients

        public const string ClientsTableName = "clients"; //Название таблицы с клиентами
        public const string ClientsIndex = "id"; //Название столбца с Индексом
        public const string ClientsName = "name";
 
        #endregion Clients

        #region Deposits

        public const string DepositsTableName = "deposits"; //Название таблицы с депозитами
        public const string DepositsIndex = "id"; //Название столбца с Индексом

        public const string DepositsName = "name"; //Название депозита
        public const string DepositsAmount = "amount"; //Название столбца с сумма вклада
        public const string DepositsPercent = "percent"; //Название столбца с процентом вклада
        public const string DepositsDateStart = "datestart";//начало действия
        public const string DepositsDateEnd = "dateend";//конец действия
        public const string DepositsClosed = "closed";//закрыт ли

        public const string DepositsBankID = "bankid"; //Название столбца с кодом банка - связь по id BanksTableName
        public const string DepositsCurrencyID = "currencyid"; //Название столбца с кодом валюты - связь по id CurrencyTableName
        public const string DepositsClientID = "clientsid"; //Название столбца с кодом валюты - связь по id ClientsTableName

        public const string DepositsBankRelation = "DepositsBank"; //связь между таблицами Депозиты и Банки
        public const string DepositsCurrencyRelation = "DepositsCurrency"; //связь между таблицами Депозиты и Валюты
        public const string DepositsClientsRelation = "DepositsClients"; //связь между таблицами Депозиты и Клиенты

        public const string InterestPaymentNotification = "InterestPaymentNotification";//оповещение о выплате депозита
        public const string PeriodInterestPayment = "PeriodInterestPayment";//Период выплаты процентов
        public const string DayInterestPayment = "DayInterestPayment";//День выплаты процентов

        #endregion Deposits

        #endregion Tables

        public const int SqlErrorNum = -2; //моя ошибка в try cath при запросах

        public static List<string> needleExt = new List<string>() {".xml", ".sdf" }; //расширения, версии которых нужно проверять
       
        public static string LogFileName
        {
            get
            {
                return Common.UserAppDataPath + "CriticalError.log";

            }
        }
        /// <summary>
        /// Путь к папке хранения баз
        /// </summary>
        public static string DataBasesPath
        {
            get
            {
                return Common.UserAppDataPath + "\\" + Constants.DataBasesFolderName + "\\";
            }
        }


        public static class Messages
        {
            public const string ErrorMessage = "Error ID: {0}\r\nFor more information, see a log file.";
            public const string NewVersionAvailable = "A new version of "+ProgramShortName+" ({0}) is available for download at \n\r{1}\n\rPress OK to navigate to this page.";
            public const string NewVersionNotification = "A new version ({0}) of " + ProgramShortName + " is available for download. \n\r Click here to view details.";
            public const string NewVersionTitle = "" + ProgramShortName + " Update Available";
            public const string HaveLatestVersion = "You already have the latest version of " + ProgramShortName + ".";
            public const string HaveLatestVersionTitle = "" + ProgramShortName + " is Up To Date";
            public const string ErrorCheckUpdates = "Error occured, during checking of updated version of the program:\n\r{0}";
        }
    }
}
