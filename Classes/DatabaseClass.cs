using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DepoMan.Classes
{
    public class DatabaseClass
    {
        #region Events
        public event DataColumnChangeEventHandler TableConfigColumnChanged, TableBanksColumnChanged, TableCurrencyColumnChanged, TableDepositsColumnChanged, TableClientsColumnChanged;
        public event DataRowChangeEventHandler TableConfigRowChanged, TableBanksRowChanged, TableCurrencyRowChanged, TableDepositsRowChanged, TableClientsRowChanged;
        public event DataRowChangeEventHandler TableConfigRowDeleted, TableBanksRowDeleted, TableCurrencyRowDeleted, TableDepositsRowDeleted, TableClientsRowDeleted;
        public event DataTableNewRowEventHandler TableConfigNewRow, TableBanksNewRow, TableCurrencyNewRow, TableDepositsNewRow, TableClientsNewRow;

        public event EventHandler OnDataBaseSaved; //событие после сохранения базы данных
        public EventHandler OnDataBaseOpen; //поэтому используем делегат
        public EventHandler OnDataBaseClose;
        public EventHandler OnDataBaseModified; //База изменилась, например, добавились тиражи, чтобы плагины поняли

        #endregion Events

        private string _DBFileName = ""; //имя файла с базой данных

        private bool modifiedConfig = false;//модифицированы ли Config
        private bool modifiedBanks = false;//модифицированы ли banks
        private bool modifiedCurrency = false;//модифицированы ли currency
        private bool modifiedDeposits = false;//модифицированы ли deposits
        private bool modifiedClients = false;//модифицированы ли deposits

        private bool modifiedDB = false;//модифицирован база данных без конкретизации в какой таблице

        private DataTable tableConfig = null;
        private DataTable tableBanks = null;
        private DataTable tableCurrency = null;
        private DataTable tableDeposits = null;
        private DataTable tableClients = null;

        private BindingSource sourceConfig = null;
        private BindingSource sourceBanks = null;
        private BindingSource sourceCurrency = null;
        private BindingSource sourceDeposits = null;
        private BindingSource sourceClients = null;

        private DataSet dataSetAccount = null;

        private bool dbOpened; //открыта ли база данных
        private bool errorOccurred = false;

        /// <summary>
        /// возникла ошибка при операции
        /// </summary>
        public bool ErrorOccurred
        {
            get
            {
                return errorOccurred;
            }
        }

        public string LastError
        { get; set; }

        public static bool FirstOpen 
        { get; set; }

        public bool EditTableEnabled  
        { get; set; }

        public DataSet DataSetAccount
        {
            get
            {
                return dataSetAccount;
            }
        }

        #region Tables
        public DataTable TableConfig
        {
            get
            {
                return tableConfig;
            }
        }

        public DataTable TableBanks
        {
            get
            {
                return tableBanks;
            }
        }

        public DataTable TableCurrency
        {
            get
            {
                return tableCurrency;
            }
        }

        public DataTable TableDeposits
        {
            get
            {
                return tableDeposits;
            }
        }
        public DataTable TableClients
        {
            get
            {
                return tableClients;
            }
        }
        #endregion Tables

        #region BindingSource
        public BindingSource SourceConfig
        {
            get
            {
                return sourceConfig;
            }
        }

        public BindingSource SourceBanks
        {
            get
            {
                return sourceBanks;
            }
        }

        public BindingSource SourceCurrency
        {
            get
            {
                return sourceCurrency;
            }
        }

        public BindingSource SourceDeposits
        {
            get
            {
                return sourceDeposits;
            }
        }
        public BindingSource SourceClients
        {
            get
            {
                return sourceClients;
            }
        }

        #endregion BindingSource
        /// <summary>
        /// Имя файла с полным путем базы данных.
        /// </summary>
        public string DBFileName
        {
            get
            {
                return _DBFileName;
            }
        }

        /// <summary>
        /// Returns true if database connection is open.
        /// </summary>
        public bool DBOpened
        {
            get { return dbOpened; }
        }
        /// <summary>
        /// Признак модифицируемости всей базы
        /// </summary>
        public bool ModifiedDB
        {
            get
            {
                return modifiedDB;
            }
            set
            {
                modifiedDB = value; //Позволяем извне устанавливать признак модифицируемости?
                if ((modifiedDB) && (OnDataBaseModified != null)) //только если модифицировано
                    OnDataBaseModified.Invoke(this, new EventArgs());
            }
        }

        /// <summary>
        /// Модифицируемость таблицы Банков
        /// </summary>
        public bool ModifiedConfig
        {
            get
            {
                return modifiedConfig;
            }
        }
        /// <summary>
        /// Модифицируемость таблицы Банков
        /// </summary>
        public bool ModifiedBanks
        {
            get
            {
                return modifiedBanks;
            }
        }

        /// <summary>
        /// Модифицируемость таблицы Валют
        /// </summary>
        public bool ModifiedCurrency
        {
            get
            {
                return modifiedCurrency;
            }
        }

        /// <summary>
        /// Модифицируемость таблицы Депозиты
        /// </summary>
        public bool ModifiedDeposits
        {
            get
            {
                return modifiedDeposits;
            }
        }

        /// <summary>
        /// Модифицируемость таблицы Клиенты
        /// </summary>
        public bool ModifiedClients
        {
            get
            {
                return modifiedClients;
            }
        }

        /// <summary>
        /// Установим признак чтобы не срабатывали при измении столбцов - для ускорения например автообновления
        /// </summary>
        /// <param name="value"></param>
        internal void SetFirstOpen(bool value)
        {
            FirstOpen = value;
        }

        internal bool OpenDB(string openFileName)
        {
            errorOccurred = false;
            try
            {
                SetFirstOpen(true);  //Запрещаем события модифицируемости таблиц

                if (openFileName == string.Empty)
                {
                    errorOccurred = true;
                    LastError = "Не задано имя файла";
                    return false;
                }

                    #region Variable Declarations
                    dbOpened = false;

                    #endregion

                    _DBFileName = openFileName;

                    if (!LoadDataSet(openFileName)) //Создание Датасет ДатаТабле и загрузка данных
                    {
                        return false;

                    }
                     
                   //Теперь убедимся что это наш файл и если надо нужная версия базы
                    int ver = GetDataBaseVersion();
                    if (ver == -1)
                    {
                        errorOccurred = true;
                        LastError = "Файл не является базой данных " + Constants.ProgramFullName;
                        return false;

                    }
                    //Если версии более новые - тут нужно добавлять обработку

                    AcceptTables(); //иначе при получении версий DataRowVersion исключение VersionNotFoundException

                    AttachTablesEvents();

                    dbOpened = true;
                    if ((this.OnDataBaseOpen) != null)
                        this.OnDataBaseOpen.Invoke(this, new EventArgs());

                    SetDatabaseModified(false);

                    EditTableEnabled = false; //запрещаем редактирование и вставку строк


                if (dataSetAccount != null)
                {

                    AcceptTables();
                    SetFirstOpen(false);
                }
                else
                {
                    errorOccurred = true;
                    LastError = "Непредвиденная проблема с открытием файла.";
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                errorOccurred = true;
                LastError = "Проблема с открытием файла: " + ex.Message;
                return false;
            }

        }


        /// <summary>
        /// Создаем и загружаем данные в таблицы
        /// </summary>
        /// <param name="openFileName"></param>
        /// <returns></returns>
        private bool LoadDataSet(string openFileName)
        {
            try
            {
                MakeDataSet(); //Создали DataTables and DataSet

                //dataSetAccount.ReadXml(openFileName,XmlReadMode.ReadSchema);
                dataSetAccount.ReadXml(openFileName, XmlReadMode.IgnoreSchema);

                return true;
            }
            catch (Exception ex)
            {
                LastError = ex.Message;
                Logger.HandleCriticalError("Ошибка в LoadDataSet(" + openFileName + "):" + LastError, ex);
                return false;
            }
            finally
            {
                ;
            }

        }

        /// <summary>
        /// Выгрузим данные
        /// </summary>
        /// <param name="saveFileName"></param>
        /// <returns></returns>
        private bool SaveDataSet(string saveFileName)
        {
            try
            {

                dataSetAccount.WriteXml(saveFileName, XmlWriteMode.WriteSchema);
                return true;
            }
            catch (Exception ex)
            {
                LastError = ex.Message;
                Logger.HandleCriticalError("Ошибка в SaveDataSet(" + saveFileName + ")", ex);
                return false;
            }
            finally
            {
                ;
            }

        }

        private void SetDatabaseModified(bool value)
        {

            modifiedDB = value;

            if (value == false) //Немодифицируемость устанавливаем у всех таблиц, тогда как Модифицируемость будет установлена в событиях каждой таблицы отдельно
            {
                modifiedBanks = false; //с маленькой, так как не надо возбуждать у других
                modifiedCurrency = false;
                modifiedDeposits = false;

            }
        }

        /// <summary>
        /// Назначим события на изменения в таблицах
        /// </summary>
        private void AttachTablesEvents()
        {
            if (tableBanks!=null)
            {

            tableBanks.RowChanged += new DataRowChangeEventHandler(Table_Banks_Row_Changed); //Для ускорения подключаем после загрузки файла
            tableBanks.RowDeleted += new DataRowChangeEventHandler(Table_Banks_Row_Deleted);
            tableBanks.TableNewRow += new DataTableNewRowEventHandler(Table_Banks_New_Row);
            }

            if (tableCurrency != null)
            {
       
                tableCurrency.RowChanged += new DataRowChangeEventHandler(Table_Currency_Row_Changed); //Для ускорения подключаем после загрузки файла
                tableCurrency.RowDeleted += new DataRowChangeEventHandler(Table_Currency_Row_Deleted);
                tableCurrency.TableNewRow += new DataTableNewRowEventHandler(Table_Currency_New_Row);
            }

            if (tableDeposits != null)
            {
          
                tableDeposits.RowChanged += new DataRowChangeEventHandler(Table_Deposits_Row_Changed); //Для ускорения подключаем после загрузки файла
                tableDeposits.RowDeleted += new DataRowChangeEventHandler(Table_Deposits_Row_Deleted);
                tableDeposits.TableNewRow += new DataTableNewRowEventHandler(Table_Deposits_New_Row);
            }

            if (tableClients != null)
            {
         
                tableClients.RowChanged += new DataRowChangeEventHandler(Table_Clients_Row_Changed); //Для ускорения подключаем после загрузки файла
                tableClients.RowDeleted += new DataRowChangeEventHandler(Table_Clients_Row_Deleted);
                tableClients.TableNewRow += new DataTableNewRowEventHandler(Table_Clients_New_Row);
            }

            if (tableConfig != null)
            {
           
                tableConfig.RowChanged += new DataRowChangeEventHandler(Table_Config_Row_Changed); 
                tableConfig.RowDeleted += new DataRowChangeEventHandler(Table_Config_Row_Deleted);
                tableConfig.TableNewRow += new DataTableNewRowEventHandler(Table_Config_New_Row);
            }

        }
        /// <summary>
        /// Отсоединим события
        /// </summary>
        private void DetachTablesEvents()
        {
            if (tableBanks != null)
            {
                tableBanks.RowChanged -= new DataRowChangeEventHandler(Table_Banks_Row_Changed);
                tableBanks.RowDeleted -= new DataRowChangeEventHandler(Table_Banks_Row_Deleted);
                tableBanks.TableNewRow -= new DataTableNewRowEventHandler(Table_Banks_New_Row);
            }

            if (tableCurrency != null)
            {
       
                tableCurrency.RowChanged -= new DataRowChangeEventHandler(Table_Currency_Row_Changed); //Для ускорения подключаем после загрузки файла
                tableCurrency.RowDeleted -= new DataRowChangeEventHandler(Table_Currency_Row_Deleted);
                tableCurrency.TableNewRow -= new DataTableNewRowEventHandler(Table_Currency_New_Row);
            }

            if (tableDeposits != null)
            {
           
                tableDeposits.RowChanged -= new DataRowChangeEventHandler(Table_Deposits_Row_Changed); //Для ускорения подключаем после загрузки файла
                tableDeposits.RowDeleted -= new DataRowChangeEventHandler(Table_Deposits_Row_Deleted);
                tableDeposits.TableNewRow -= new DataTableNewRowEventHandler(Table_Deposits_New_Row);
            }

            if (tableClients != null)
            {
               
                tableClients.RowChanged -= new DataRowChangeEventHandler(Table_Clients_Row_Changed); //Для ускорения подключаем после загрузки файла
                tableClients.RowDeleted -= new DataRowChangeEventHandler(Table_Clients_Row_Deleted);
                tableClients.TableNewRow -= new DataTableNewRowEventHandler(Table_Clients_New_Row);
            }

            if (tableConfig != null)
            {
         
                tableConfig.RowChanged -= new DataRowChangeEventHandler(Table_Config_Row_Changed);
                tableConfig.RowDeleted -= new DataRowChangeEventHandler(Table_Config_Row_Deleted);
                tableConfig.TableNewRow -= new DataTableNewRowEventHandler(Table_Config_New_Row);
            }
        }
        /// <summary>
        /// AcceptChanges во всех таблицах
        /// </summary>
        private void AcceptTables()
        {

            foreach (DataTable item in dataSetAccount.Tables)
            {
                item.AcceptChanges();
            }

        }

        private void EndEditTables()
        {
            sourceBanks.EndEdit(); 
        }

        /// <summary>
        /// Очистим и удалим всме таблицы и дата сет
        /// </summary>
        public void ClearDB()
        {
            try
            {

                if (dataSetAccount == null) return;

                //удаляем все таблицы
                foreach (DataTable item in dataSetAccount.Tables)
                {
                    if (item == null) continue;
                    item.Dispose();
                    item.Dispose();
                }

           
                //удаляем сам ДатаСет
                sourceConfig = null;
                sourceBanks = null;
                sourceCurrency = null;
                sourceClients = null;
                sourceDeposits = null;

                dataSetAccount.Dispose();
            }
            catch (Exception ex)
            {
                string msg = "Ошибка в CloseDB";
                Logger.HandleNonCriticalError(msg, ex, false);
                //throw;
            }
          
        }

        #region DataSet
        private bool MakeDataSet()
        {
            dataSetAccount = new DataSet(Constants.DataSetName);

            #region tableConfig таблица для служеьных нужд, например, понять что это нужная база а не например banks.xml
            //start Create a new DataTable
            tableConfig = new DataTable(Constants.ConfigTableName);

            //Добавим Индекс в базе  ВСЕГДА ПЕРВЫМ ПО ИНДЕКСОМ 0, так как 0 используется в AddHistoryRow
            DataColumn column = new DataColumn();

            //Добавим ConfigName
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = Constants.ConfigName;
            column.ReadOnly = false;
            column.Unique = false;
            tableConfig.Columns.Add(column);

            //Добавим ConfigValue
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = Constants.ConfigValue;
            column.ReadOnly = false;
            column.Unique = false;
            tableConfig.Columns.Add(column);

            //set the BindingSource DataSource
            sourceConfig = new BindingSource();
            sourceConfig.DataSource = tableConfig;

            dataSetAccount.Tables.Add(tableConfig);
            #endregion tableConfig

            #region tableBanks
            //start Create a new DataTable
            tableBanks = new DataTable(Constants.BanksTableName);
            // Declare variables for DataColumn and DataRow objects.

            //Добавим Индекс в базе  ВСЕГДА ПЕРВЫМ ПО ИНДЕКСОМ 0, так как 0 используется в AddHistoryRow
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = Constants.BanksIndex;
            column.AutoIncrement = true; 
            column.ReadOnly = true;
            column.Unique = true;
            column.AutoIncrementSeed = 1; //Начинаем с 1 для удобства
            // Add the Column to the DataColumnCollection.
            tableBanks.Columns.Add(column);

            //Добавим BanksRegNum есть и такие 3486-К/2 - это Лицензия, а не номер банка!
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = Constants.BanksRegNum;
            column.ReadOnly = false;
            column.Unique = false;
            tableBanks.Columns.Add(column);

            //Добавим BanksBIK
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String"); //int Нельзя, нужно string,так как есть с 0 вначале, "044583139";
            column.ColumnName = Constants.BanksBIK;
            column.ReadOnly = false;
            column.Unique = true;
            column.MaxLength = Constants.BIKLength; //Длина БИК
            tableBanks.Columns.Add(column);

            //Добавим BanksName
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = Constants.BanksName;
            column.ReadOnly = false;
            column.Unique = false;
            column.MaxLength=Constants.MaxInputTextLength;
            tableBanks.Columns.Add(column);

            //Добавим BanksFullName
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = Constants.BanksFullName;
            column.ReadOnly = false;
            column.Unique = false;
            column.MaxLength=Constants.MaxInputTextLength;
            tableBanks.Columns.Add(column);


            #region Event


            #endregion Event


            //set the BindingSource DataSource
            sourceBanks = new BindingSource();

            sourceBanks.DataSource = tableBanks;
            //sourceBanks.DataMember = Constants.BanksName;
            // Add the new DataTable to the DataSet.
            dataSetAccount.Tables.Add(tableBanks);
            #endregion tableBanks

            #region tableCurrency
            //start Create a new DataTable
            tableCurrency = new DataTable(Constants.CurrencyTableName);

            //Добавим Индекс в базе  ВСЕГДА ПЕРВЫМ ПО ИНДЕКСОМ 0, так как 0 используется в AddHistoryRow
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = Constants.CurrencyIndex;
            column.AutoIncrement = true; 
            column.ReadOnly = true;
            column.Unique = true;
            column.AutoIncrementSeed = 1;
            // Add the Column to the DataColumnCollection.
            tableCurrency.Columns.Add(column);

            //Добавим CurrencyCode
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String"); //INT нельзя, есть лидирующий 0, 032 - аргентинское ПЕСО
            column.ColumnName = Constants.CurrencyCode;
            column.ReadOnly = false;
            column.Unique = true;
            column.MaxLength = 3;
            tableCurrency.Columns.Add(column);

            //Добавим CurrencySymbol
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = Constants.CurrencySymbol;
            column.ReadOnly = false;
            column.Unique = true;
            column.MaxLength=3;
            tableCurrency.Columns.Add(column);

            //Добавим CurrencyName
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = Constants.CurrencyName;
            column.ReadOnly = false;
            column.Unique = false;
            column.MaxLength=Constants.MaxInputTextLength;
            tableCurrency.Columns.Add(column);

            //Добавим CurrencyCountry
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = Constants.CurrencyCountry;
            column.ReadOnly = false;
            column.Unique = false;
            //column.MaxLength=Constants.MaxInputTextLength; Тут иногда длинный список стран бывает
            tableCurrency.Columns.Add(column);

            //Добавим CurrencyRate
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Decimal");
            column.ColumnName = Constants.CurrencyRate;
            column.ReadOnly = false;
            column.Unique = false;
            column.DefaultValue = 1;
            tableCurrency.Columns.Add(column);

            //set the BindingSource DataSource
            sourceCurrency = new BindingSource();
            sourceCurrency.DataSource = tableCurrency;
           // sourceCurrency.DataMember = Constants.CurrencySymbol;

            // Add the new DataTable to the DataSet.
            dataSetAccount.Tables.Add(tableCurrency);
            #endregion tableCurrency

            #region tableClients
            //start Create a new DataTable
            tableClients = new DataTable(Constants.ClientsTableName);

            //Добавим Индекс в базе  ВСЕГДА ПЕРВЫМ ПО ИНДЕКСОМ 0, так как 0 используется в AddHistoryRow
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = Constants.ClientsIndex;
            column.AutoIncrement = true;
            column.ReadOnly = true;
            column.Unique = true;
            column.AutoIncrementSeed = 1;
            // Add the Column to the DataColumnCollection.
            tableClients.Columns.Add(column);

            //Добавим ClientsName
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = Constants.ClientsName;
            column.ReadOnly = false;
            column.Unique = false;
            column.MaxLength=Constants.MaxInputTextLength;
            tableClients.Columns.Add(column);

            //set the BindingSource DataSource
            sourceClients = new BindingSource();
            sourceClients.DataSource = tableClients;

            dataSetAccount.Tables.Add(tableClients);
            #endregion tableClients

            #region tableDeposits
            //start Create a new DataTable
            tableDeposits = new DataTable(Constants.DepositsTableName);

            //Добавим Индекс в базе  ВСЕГДА ПЕРВЫМ ПО ИНДЕКСОМ 0, так как 0 используется в AddHistoryRow
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = Constants.DepositsIndex;
            column.AutoIncrement = true;
            column.ReadOnly = true;
            column.Unique = true;
            column.AutoIncrementSeed = 1;
            // Add the Column to the DataColumnCollection.
            tableDeposits.Columns.Add(column);

            //Добавим DepositsName
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = Constants.DepositsName;
            column.ReadOnly = false;
            column.Unique = false;
            column.MaxLength = Constants.MaxDepositsNameLength; ; // 100;// У меня попалось на 56 длина ! Constants.MaxInputTextLength;
            tableDeposits.Columns.Add(column);

            //Добавим DepositsBank
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = Constants.DepositsBankID;
            column.ReadOnly = false;
            column.Unique = false;
            tableDeposits.Columns.Add(column);

            //Добавим DepositsCurrency
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = Constants.DepositsCurrencyID;
            column.ReadOnly = false;
            column.Unique = false;
            tableDeposits.Columns.Add(column);

            //Добавим DepositsClientID
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = Constants.DepositsClientID;
            column.ReadOnly = false;
            column.Unique = false;
            tableDeposits.Columns.Add(column);


            //Добавим DepositsAmount
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Decimal");
            column.ColumnName = Constants.DepositsAmount;
            column.ReadOnly = false;
            column.Unique = false;
            tableDeposits.Columns.Add(column);

            //Добавим DepositsPercent
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Decimal");
            column.ColumnName = Constants.DepositsPercent;
            column.ReadOnly = false;
            column.Unique = false;
            tableDeposits.Columns.Add(column);

            //Добавим DepositsDateStart
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.DateTime");
            column.ColumnName = Constants.DepositsDateStart;
            column.ReadOnly = false;
            column.Unique = false;
            column.AllowDBNull = true; //Нужно вручную проверить на ненулевые значения!
            column.DefaultValue = DateTime.Now;
            tableDeposits.Columns.Add(column);

            //Добавим DepositsDateEnd
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.DateTime");
            column.ColumnName = Constants.DepositsDateEnd;
            column.ReadOnly = false;
            column.Unique = false;
            column.AllowDBNull = true;//Нужно вручную проверить на ненулевые значения!
            column.DefaultValue = DateTime.Now;
            tableDeposits.Columns.Add(column);

            //Добавим DepositsClosed
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Boolean");
            column.ColumnName = Constants.DepositsClosed;
            column.ReadOnly = false;
            column.Unique = false;
            column.DefaultValue = false;
            tableDeposits.Columns.Add(column);

            //Добавим PeriodInterestPayment
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = Constants.PeriodInterestPayment;
            column.ReadOnly = false;
            column.Unique = false;
            tableDeposits.Columns.Add(column);

            //Добавим DayInterestPayment
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = Constants.DayInterestPayment;
            column.ReadOnly = false;
            column.Unique = false;
            tableDeposits.Columns.Add(column);

            //Добавим InterestPaymentNotification
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Boolean");
            column.ColumnName = Constants.InterestPaymentNotification;
            column.ReadOnly = false;
            column.Unique = false;
            column.DefaultValue = false;
            tableDeposits.Columns.Add(column);

            //set the BindingSource DataSource
            sourceDeposits = new BindingSource();
            sourceDeposits.DataSource = tableDeposits;
        

            // Add the new DataTable to the DataSet.
            dataSetAccount.Tables.Add(tableDeposits);

            // use the Add() method through the Relations property
            // to define a relationship between the Customers and
            // Orders DataTable objects
            //myDataSet.Relations.Add("Orders",
           //myDataSet.Tables["Customers"].Columns["CustomerID"],
            // myDataSet.Tables["Orders"].Columns["CustomerID"] );

            //Добавим связи
            //Banks
            dataSetAccount.Relations.Add(
              Constants.DepositsBankRelation,
              dataSetAccount.Tables[Constants.BanksTableName].Columns[Constants.BanksIndex],
              dataSetAccount.Tables[Constants.DepositsTableName].Columns[Constants.DepositsBankID]
           );
            //Currency
            dataSetAccount.Relations.Add(
              Constants.DepositsCurrencyRelation,
              dataSetAccount.Tables[Constants.CurrencyTableName].Columns[Constants.CurrencyIndex],
              dataSetAccount.Tables[Constants.DepositsTableName].Columns[Constants.DepositsCurrencyID]
            );
          
            //Clients
            //DataRelation dataRelation = new DataRelation("Name", dataSetAccount.Tables[Constants.ClientsTableName].Columns[Constants.ClientsIndex], dataSetAccount.Tables[Constants.DepositsTableName].Columns[Constants.DepositsClientID]);
           // dataSetAccount.Relations.Add(dataRelation);
            
            dataSetAccount.Relations.Add(
              Constants.DepositsClientsRelation,
              dataSetAccount.Tables[Constants.ClientsTableName].Columns[Constants.ClientsIndex],
              dataSetAccount.Tables[Constants.DepositsTableName].Columns[Constants.DepositsClientID]
            );
           
            #endregion tableDeposits

            return true;
        }

        #endregion DataSet

        #region Events

        #region Banks


        /// <summary>
        /// Запускается после создания новой строки DataRow с помощью метода NewRow. Это событие возникает до возврата результата методом NewRow. Новый экземпляр DataRow отсоединяется; он не добавляется в коллекцию.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Table_Banks_New_Row(object sender, DataTableNewRowEventArgs e)
        {
            if (FirstOpen) return;

            modifiedBanks = true;
            modifiedDB = true; //Это при любой таблице устанавливаем признак общей модификации

            if (TableBanksNewRow != null)
                TableBanksNewRow.Invoke(sender, e);

            if (OnDataBaseModified != null) //Модификация всей базы
                OnDataBaseModified.Invoke(sender, e);

        }

        private void Table_Banks_Row_Changed(object sender, DataRowChangeEventArgs e)
        {

            if (FirstOpen) return;

           // if (this.EditTableEnabled == false) return; //если кнопка редактирования не нажата, то возможно кликаем на чекбоксе, не меняем модифицированность
            //Так как в основной форме опрашивается GetModifiedStatus(), то эти нужно раньше генерации событий устанавливать
            modifiedBanks = true;
            modifiedDB = true; //Это при любой таблице устанавливаем признак общей модификации

            if (TableBanksRowChanged != null) //Модификация отдельной таблицы
                TableBanksRowChanged.Invoke(sender, e);

            if (OnDataBaseModified != null) //Модификация всей базы
                OnDataBaseModified.Invoke(sender, e);


        }

        private void Table_Banks_Row_Deleted(object sender, DataRowChangeEventArgs e)
        {
            if (FirstOpen) return;

            //Так как в основной форме опрашивается GetModifiedStatus(), то эти нужно раньше генерации событий устанавливать
            modifiedBanks = true;
            modifiedDB = true; //Это при любой таблице устанавливаем признак общей модификации

                if (TableBanksRowDeleted != null)
                    TableBanksRowDeleted.Invoke(sender, e);

                if (OnDataBaseModified != null) //Модификация всей базы
                    OnDataBaseModified.Invoke(sender, e);
        }

        #endregion Banks
        #region Currency

        private void Table_Currency_New_Row(object sender, DataTableNewRowEventArgs e)
        {
            if (FirstOpen) return;

            modifiedCurrency = true;
            modifiedDB = true; //Это при любой таблице устанавливаем признак общей модификации

            if (TableCurrencyNewRow != null)
                TableCurrencyNewRow.Invoke(sender, e);

            if (OnDataBaseModified != null) //Модификация всей базы
                OnDataBaseModified.Invoke(sender, e);


        }

        private void Table_Currency_Row_Changed(object sender, DataRowChangeEventArgs e)
        {

            if (FirstOpen) return;

    
            modifiedCurrency = true;
            modifiedDB = true; //Это при любой таблице устанавливаем признак общей модификации

            if (TableCurrencyRowChanged != null) //Модификация отдельной таблицы
                TableCurrencyRowChanged.Invoke(sender, e);

            if (OnDataBaseModified != null) //Модификация всей базы
                OnDataBaseModified.Invoke(sender, e);

        }

        private void Table_Currency_Row_Deleted(object sender, DataRowChangeEventArgs e)
        {
            if (FirstOpen) return;

            modifiedCurrency = true;
            modifiedDB = true; //Это при любой таблице устанавливаем признак общей модификации

            if (TableCurrencyRowDeleted != null)
                TableCurrencyRowDeleted.Invoke(sender, e);

            if (OnDataBaseModified != null) //Модификация всей базы
                OnDataBaseModified.Invoke(sender, e);

        }
        #endregion Currency
        #region Deposits

        private void Table_Deposits_New_Row(object sender, DataTableNewRowEventArgs e)
        {
            if (FirstOpen) return;

            modifiedDeposits = true;
            modifiedDB = true; //Это при любой таблице устанавливаем признак общей модификации

            if (TableDepositsNewRow != null)
                TableDepositsNewRow.Invoke(sender, e);

            if (OnDataBaseModified != null) //Модификация всей базы
                OnDataBaseModified.Invoke(sender, e);


        }

        private void Table_Deposits_Row_Changed(object sender, DataRowChangeEventArgs e)
        {

            if (FirstOpen) return;

            modifiedDeposits = true;
            modifiedDB = true; //Это при любой таблице устанавливаем признак общей модификации

            if (TableDepositsRowChanged != null) //Модификация отдельной таблицы
                TableDepositsRowChanged.Invoke(sender, e);

            if (OnDataBaseModified != null) //Модификация всей базы
                OnDataBaseModified.Invoke(sender, e);

        }

        private void Table_Deposits_Row_Deleted(object sender, DataRowChangeEventArgs e)
        {
            if (FirstOpen) return;

            modifiedDeposits = true;
            modifiedDB = true; //Это при любой таблице устанавливаем признак общей модификации

            if (TableDepositsRowDeleted != null)
                TableDepositsRowDeleted.Invoke(sender, e);

            if (OnDataBaseModified != null) //Модификация всей базы
                OnDataBaseModified.Invoke(sender, e);

        }
        #endregion Deposits

        #region Clients

        private void Table_Clients_New_Row(object sender, DataTableNewRowEventArgs e)
        {
            if (FirstOpen) return;

            modifiedClients = true;
            modifiedDB = true; //Это при любой таблице устанавливаем признак общей модификации

            if (TableClientsNewRow != null)
                TableClientsNewRow.Invoke(sender, e);

            if (OnDataBaseModified != null) //Модификация всей базы
                OnDataBaseModified.Invoke(sender, e);


        }

        private void Table_Clients_Row_Changed(object sender, DataRowChangeEventArgs e)
        {

            if (FirstOpen) return;

            modifiedClients = true;
            modifiedDB = true; //Это при любой таблице устанавливаем признак общей модификации

            if (TableClientsRowChanged != null) //Модификация отдельной таблицы
                TableClientsRowChanged.Invoke(sender, e);

            if (OnDataBaseModified != null) //Модификация всей базы
                OnDataBaseModified.Invoke(sender, e);

        }

        private void Table_Clients_Row_Deleted(object sender, DataRowChangeEventArgs e)
        {
            if (FirstOpen) return;

            modifiedClients = true;
            modifiedDB = true; //Это при любой таблице устанавливаем признак общей модификации

            if (TableClientsRowDeleted != null)
                TableClientsRowDeleted.Invoke(sender, e);

            if (OnDataBaseModified != null) //Модификация всей базы
                OnDataBaseModified.Invoke(sender, e);

        }
        #endregion Clients

        #region Config

        private void Table_Config_New_Row(object sender, DataTableNewRowEventArgs e)
        {
            if (FirstOpen) return;

            modifiedConfig = true;
            modifiedDB = true; //Это при любой таблице устанавливаем признак общей модификации

            if (TableConfigNewRow != null)
                TableConfigNewRow.Invoke(sender, e);

            if (OnDataBaseModified != null) //Модификация всей базы
                OnDataBaseModified.Invoke(sender, e);


        }

        private void Table_Config_Row_Changed(object sender, DataRowChangeEventArgs e)
        {

            if (FirstOpen) return;

            modifiedConfig = true;
            modifiedDB = true; //Это при любой таблице устанавливаем признак общей модификации

            if (TableConfigRowChanged != null) //Модификация отдельной таблицы
                TableConfigRowChanged.Invoke(sender, e);

            if (OnDataBaseModified != null) //Модификация всей базы
                OnDataBaseModified.Invoke(sender, e);

        }

        private void Table_Config_Row_Deleted(object sender, DataRowChangeEventArgs e)
        {
            if (FirstOpen) return;

            modifiedConfig = true;
            modifiedDB = true; //Это при любой таблице устанавливаем признак общей модификации

            if (TableConfigRowDeleted != null)
                TableConfigRowDeleted.Invoke(sender, e);

            if (OnDataBaseModified != null) //Модификация всей базы
                OnDataBaseModified.Invoke(sender, e);

        }
        #endregion Config

        #endregion Events



        public bool SaveDBAs(string saveFileName)
        {
            bool result = false; //используется finally

            bool sameDB = (this.DBFileName == saveFileName); //та же база, нужно установить признак немодифицированности после сохранениия
            //Если не та же, но база остается немодифицированной, так как продолжаем работать в старой!
            string errorMessage = "";

            if (saveFileName == "")
            {
                SaveFileDialog saveDB = new SaveFileDialog();
                #region Set saveDB Dialog Properties

                saveDB.AddExtension = true;
                saveDB.Title = "Выберите имя новой базы данных...";
                saveDB.Filter = Constants.FilterDataBase;
                saveDB.ValidateNames = true;
                saveDB.OverwritePrompt = true;
                saveDB.InitialDirectory = Constants.DataBasesPath;
                #endregion
                if (saveDB.ShowDialog() != DialogResult.OK)
                {
                    LastError = "Не задано имя файла базы данных";
                    return result = false;
                }

                saveFileName = saveDB.FileName;

                sameDB = true;
            }



            try
            {
                FirstOpen = true;

                EndEditTables();

                if (!SaveDataSet(saveFileName))
                {
                    //LastError = ""; внутри SaveDataSet
                    return result = false;
                }

                if (sameDB) //та же база, нужно установить признак немодифицированности после сохранениия
                //Если не та же, но база остается немодифицированной, так как продолжаем работать в старой!
                {
                    AcceptTables();
                    SetDatabaseModified(false);
                }

                return result = true;
            }
            catch (Exception ex)
            {
                LastError = ex.Message;
                errorMessage = LastError;
                return result = false;
            }
            finally
            {
                if (OnDataBaseSaved != null)
                {
                    DepoMan.Classes.Utils.MyEventArgs arg = new DepoMan.Classes.Utils.MyEventArgs(result, errorMessage);
                    OnDataBaseSaved.Invoke(this, arg);
                }
                FirstOpen = false;

            }
        }

        /// <summary>
        /// Closes the opened Database file.
        /// </summary>
        public void CloseDB()
        {
            try
            {
                ClearDB(); //удалим таблицы и датасет
              
                if (dbOpened)
                {
                    dbOpened = false;
                    _DBFileName = String.Empty;


                    if (OnDataBaseClose != null)
                        OnDataBaseClose.Invoke(this, new EventArgs());
                }


                SetDatabaseModified(false);

            }
            catch (Exception ex)
            {
                string msg = "Ошибка в CloseDB";
                Logger.HandleNonCriticalError(msg, ex, false);
                //throw;
            }
            finally
            {
                DetachTablesEvents(); 
               
            }

        }

        /// <summary>
        /// Создадим новую базу данных
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        internal bool CreateNewDB()
        {
            errorOccurred = false;
            LastError = "";

            try
            {
                SetFirstOpen(true);  //Запрещаем события модифицируемости таблиц

                    #region Variable Declarations
                    dbOpened = false;

                    #endregion

                    _DBFileName = ""; //Новая база еще в памяти и не сохранена на диск

                    MakeDataSet(); //Создали DataTables and DataSet
                    //Запишем в таблицу Конфига параметр, который будем считать нашей базой, например версия файла =1

                    AddNewConfig(Constants.DbVersionName, Constants.DbVersionValue.ToString());

                    AcceptTables(); 


                    AttachTablesEvents();

                    dbOpened = true;
         
                    SetDatabaseModified(false);

                    EditTableEnabled = false; //запрещаем редактирование и вставку строк

   

                if (dataSetAccount != null)
                {

                    AcceptTables();
                    SetFirstOpen(false);
                }
                else
                {
                    LastError = "Непредвиденная проблема с созданием новой базы.";
                    return false;
                }

                return true;

            }
            catch (Exception ex)
            {
                errorOccurred = true;
                LastError = "Проблема с созданием новой базы: " + ex.Message;
                return false;
            }

            finally
            {

                ;


            }

        }

        #region Banks Methods

        /// <summary>
        /// Обновить существующий банк по индексу
        /// </summary>
        /// <param name="index"></param>
        /// <param name="regNum"></param>
        /// <param name="bik"></param>
        /// <param name="name"></param>
        /// <param name="fullname"></param>
        internal bool UpdateBank(int index, string regNum, string bik, string name, string fullname)
        {
            errorOccurred = false;
            LastError = "";
            try
            {
                DataRow row = FindBankById(index);

                row[Constants.BanksRegNum] = regNum;
                row[Constants.BanksBIK] = bik;
                row[Constants.BanksName] = name;
                row[Constants.BanksFullName] = fullname;

                return true;

            }
            catch (Exception ex)
            {
                errorOccurred = true;
                LastError = "Ошибка при обновлении банка[" + regNum + "," + name + "," + fullname + "]: " + ex.Message;
                return false;
            }

        }

        /// <summary>
        /// Добавить новый банк в справочник без проверки на существование
        /// </summary>
        /// <param name="regNum"></param>
        /// <param name="bik"></param>
        /// <param name="name"></param>
        /// <param name="fullname"></param>
        internal void AddNewBank(string regNum, string bik, string name, string fullname)
        {
            errorOccurred = false;
            LastError = "";
            try
            {
            DataRow row;

            row = tableBanks.NewRow();
            row[Constants.BanksRegNum] = regNum;
            row[Constants.BanksBIK] = bik;
            row[Constants.BanksName] = name;
            row[Constants.BanksFullName] = fullname;


            tableBanks.Rows.Add(row);

            }
            catch (Exception ex)
            {
                errorOccurred = true;
                LastError = "Ошибка при добавлении нового банка["+regNum+","+name+","+fullname+"]: " + ex.Message;
            }
          
        }
        /// <summary>
        /// Удалить банк из справочника. Может нужно вначале проверить на наличие его в депозитах? TODO
        /// </summary>
        /// <param name="index"Индекс банка в справочнике</param>
        /// <param name="name">Название банка, может быть пустым, для вывода ошибки</param>
        internal bool RemoveBank(int index,string name)
        {
            LastError = "";
            errorOccurred = false;
            try
            {
 
                DataRow row = FindBankById(index);

                if (row == null)
                {
                    errorOccurred = true;
                    LastError = "Не найден банк " + name + " с индексом: " + index;
                    return false;
                }
                tableBanks.Rows.Remove(row);
            return true;
            }
            catch (Exception ex)
            {
                errorOccurred = true;
                LastError = "Проблема при удалении банка " + name + " с индексом " + index+":" + ex.Message;
                return false;
            }
        }
        /// <summary>
        /// Поиск банка по индексу
        /// </summary>
        /// <param name="index">Индекс</param>
        /// <returns>запись</returns>
        internal DataRow FindBankById(int index)
        {
            if (tableBanks.Rows.Count == 0)
            {
                return null;

            }

            DataRow query =
            (from item in tableBanks.AsEnumerable()
             where (item.RowState != DataRowState.Deleted && item.RowState != DataRowState.Detached//!! чтобы не было ошибки после удаления "Невозможно получить доступ к удаленной информации строки через данную строку"/ Также во всех плагинах нужно добавить, что SQL используют!
             &&
             item.Field<int>(Constants.BanksIndex) == index)
             select item).SingleOrDefault();

            return query;
        }

    
        /// <summary>
        /// Есть ли банк в моем списке по RegNum - лицензия, может повторяться
        /// </summary>
        /// <param name="regN"></param>
        /// <returns></returns>
        internal int BankInMyBankByRegNum(string regN)
        {
            errorOccurred = false;
            LastError = "";
            try
            {

                return sourceBanks.Find(Constants.BanksRegNum, regN);

            }
            catch (Exception ex)
            {
                errorOccurred = true;
                LastError = "Ошибка в BankInMyBankByRegNum: " + ex.Message;
                return -1;
            }
        }

        /// <summary>
        /// Поиск банка по БИК
        /// </summary>
        /// <param name="bank"></param>
        /// <returns></returns>
        internal int BankInMyBankByBik(string bik)
        {
            errorOccurred = false;
            LastError = "";
            try
            {

                return sourceBanks.Find(Constants.BanksBIK, bik);

            }
            catch (Exception ex)
            {
                errorOccurred = true;
                LastError = "Ошибка в BankInMyBankByBik: " + ex.Message;
                return -1;
            }
        }

        /// <summary>
        /// Проверим наличие банка в справочние Депозиты
        /// </summary>
        /// <param name="index">Индекс банка в справочнике Банки</param>
        /// <returns></returns>
        internal bool CheckBankInDeposits(int index)
        {
            errorOccurred = false;
            LastError = "";
            try
            {

                int pos = sourceDeposits.Find(Constants.DepositsBankID, index);//поиск в таблице Депозиты, по полю DepositsBankID

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
                errorOccurred = true;
                LastError = "Ошибка в CheckBanksInDeposits: " + ex.Message;

                return false;
            }
        }
       
        #endregion Banks Methods


        #region Currency Methods

        /// <summary>
        /// Обновить валюту по индексу
        /// </summary>
        /// <param name="index">индекс</param>
        /// <param name="code">код</param>
        /// <param name="symbol">символ</param>
        /// <param name="name">имя</param>
        /// <param name="country">страна</param>
        /// <returns></returns>
        internal bool UpdateCurrency(int index, string code, string symbol, string name, string country, decimal rate)
        {
            errorOccurred = false;
            LastError = "";
            try
            {
                DataRow row = FindCurrencyById(index);

                row[Constants.CurrencyCode] = code;
                row[Constants.CurrencySymbol] = symbol;
                row[Constants.CurrencyName] = name;
                row[Constants.CurrencyCountry] = country;
                row[Constants.CurrencyRate] = rate;

                return true;

            }
            catch (Exception ex)
            {
                errorOccurred = true;
                LastError = "Ошибка при обновлении валюты[" + code + "," + symbol + "," + name + "," + country + "]: " + ex.Message;
                return false;
            }

        }

        /// <summary>
        /// Добавить новую валюту в справочник без проверки на существование
        /// </summary>
        internal void AddNewCurrency(string code, string symbol, string name, string country, decimal rate)
        {

            errorOccurred = false;
            LastError = "";
            try
            {
                DataRow row;

                row = tableCurrency.NewRow();
                row[Constants.CurrencyCode] = code;
                row[Constants.CurrencySymbol] = symbol;
                row[Constants.CurrencyName] = name;
                row[Constants.CurrencyCountry] = country;
                row[Constants.CurrencyRate] = rate;

                tableCurrency.Rows.Add(row);
            }
            catch (Exception ex)
            {
                errorOccurred = true;
                LastError = "Ошибка при добавлении новой валюты[" + code + "," + symbol + "," + name + "," + country + "," + rate + "]: " + ex.Message;
            }

        }

        /// <summary>
        /// Проверим наличие валюты в справочние Депозиты
        /// </summary>
        /// <param name="index">Индекс валюты в справочнике Валют</param>
        /// <returns></returns>
        internal bool CheckCurrencyInDeposits(int index)
        {
            errorOccurred = false;
            LastError = "";
            try
            {

                int pos = sourceDeposits.Find(Constants.DepositsCurrencyID, index);//поиск в таблице Депозиты, по полю DepositsCurrencyID

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
                errorOccurred = true;
                LastError = "Ошибка в CheckCurrencyInDeposits: " + ex.Message;

                return false;
            }
        }

        /// <summary>
        /// Удалить валюты из справочника. Проверка на наличие в депозитах осуществляется в форме справочника
        /// </summary>
        /// <param name="index"Индекс валюты в справочнике</param>
        /// <param name="name">Название валюты, может быть пустым, для вывода ошибки</param>
        internal bool RemoveCurrency(int index, string name)
        {
            LastError = "";
            errorOccurred = false;
            try
            {

                DataRow row = FindCurrencyById(index);

                if (row == null)
                {
                    errorOccurred = true;
                    LastError = "Не найдена валюта " + name + " с индексом: " + index;
                    return false;
                }
                tableCurrency.Rows.Remove(row);
                return true;
            }
            catch (Exception ex)
            {
                errorOccurred = true;
                LastError = "Проблема при удалении валюты " + name + " с индексом " + index + ":" + ex.Message;
                return false;
            }
        }

        /// <summary>
        /// Поиск валюты по индексу
        /// </summary>
        /// <param name="index">Индекс</param>
        /// <returns>запись</returns>
        internal DataRow FindCurrencyById(int index)
        {
            if (tableCurrency.Rows.Count == 0)
            {
                return null;

            }

            DataRow query =
            (from item in tableCurrency.AsEnumerable()
             where (item.RowState != DataRowState.Deleted && item.RowState != DataRowState.Detached//!! чтобы не было ошибки после удаления "Невозможно получить доступ к удаленной информации строки через данную строку"/ Также во всех плагинах нужно добавить, что SQL используют!
             &&
             item.Field<int>(Constants.CurrencyIndex) == index)
             select item).SingleOrDefault();

            return query;
        }

        /// <summary>
        /// Поиск валюты по индексу и вывод её Symbol
        /// </summary>
        /// <param name="index">Индекс</param>
        /// <returns>запись</returns>
        internal string FindCurrencySymbolById(int index)
        {
            if (tableCurrency.Rows.Count == 0)
            {
                return "";

            }

            DataRow query =
            (from item in tableCurrency.AsEnumerable()
             where (item.RowState != DataRowState.Deleted && item.RowState != DataRowState.Detached//!! чтобы не было ошибки после удаления "Невозможно получить доступ к удаленной информации строки через данную строку"/ Также во всех плагинах нужно добавить, что SQL используют!
             &&
             item.Field<int>(Constants.CurrencyIndex) == index)
             select item).SingleOrDefault();

            return query.Field<string>(Constants.CurrencySymbol);
        }

        /// <summary>
        /// Поиск валюты по индексу и вывод её Symbol
        /// </summary>
        /// <param name="index">Индекс</param>
        /// <returns>запись</returns>
        internal decimal FindCurrencyRateById(int index)
        {
            try
            {

            if (tableCurrency.Rows.Count == 0)
            {
                return 0; //дать знать об ошибке

            }

            DataRow query =
            (from item in tableCurrency.AsEnumerable()
             where (item.RowState != DataRowState.Deleted && item.RowState != DataRowState.Detached//!! чтобы не было ошибки после удаления "Невозможно получить доступ к удаленной информации строки через данную строку"/ Также во всех плагинах нужно добавить, что SQL используют!
             &&
             item.Field<int>(Constants.CurrencyIndex) == index)
             select item).SingleOrDefault();

            object res=query.Field<object>(Constants.CurrencyRate);
                  if (res==null) res=0; //если вдруг не задали, то выдадим 0// всегда умножаем на курс. например базовая Рубль, у Доллара курс будет 65
           
            return Convert.ToDecimal(res);
            }
            catch (Exception ex)
            {
                errorOccurred = true;
                LastError = "Ошибка в FindCurrencyRateById(" + index + "):" + ex.Message;
                return 0;
            }
        }

        /// <summary>
        /// Поиск валюты по коду
        /// </summary>
        /// <param name="code">код</param>
        /// <returns>запись</returns>
        internal DataRow FindCurrencyByCode(string code)
        {
            if (tableCurrency.Rows.Count == 0)
            {
                return null;

            }

            DataRow query =
            (from item in tableCurrency.AsEnumerable()
             where (item.RowState != DataRowState.Deleted && item.RowState != DataRowState.Detached//!! чтобы не было ошибки после удаления "Невозможно получить доступ к удаленной информации строки через данную строку"/ Также во всех плагинах нужно добавить, что SQL используют!
             &&
             item.Field<string>(Constants.CurrencyCode) == code)
             select item).SingleOrDefault();

            return query;
        }

        /// <summary>
        /// Поиск валюты по символу
        /// </summary>
        /// <param name="symbol">символ</param>
        /// <returns>запись</returns>
        internal DataRow FindCurrencyBySymbol(string symbol)
        {
            if (tableCurrency.Rows.Count == 0)
            {
                return null;

            }

            DataRow query =
            (from item in tableCurrency.AsEnumerable()
             where (item.RowState != DataRowState.Deleted && item.RowState != DataRowState.Detached//!! чтобы не было ошибки после удаления "Невозможно получить доступ к удаленной информации строки через данную строку"/ Также во всех плагинах нужно добавить, что SQL используют!
             &&
             item.Field<string>(Constants.CurrencySymbol) == symbol)
             select item).SingleOrDefault();

            return query;
        }

        #endregion Currency Methods

        #region Deposits Methods
        /// <summary>
        /// Удалить депозит из справочника.
        /// </summary>
        /// <param name="index"Индекс депозита в справочнике</param>
        /// <param name="name">Название депозита, может быть пустым, для вывода ошибки</param>
        internal bool RemoveDeposit(int index, string name)
        {
            LastError = "";
            errorOccurred = false;
            try
            {

                DataRow row = FindDepositById(index);

                if (row == null)
                {
                    errorOccurred = true;
                    LastError = "Не найден депозит " + name + " с индексом: " + index;
                    return false;
                }

                tableDeposits.Rows.Remove(row);

                return true;
            }
            catch (Exception ex)
            {
                errorOccurred = true;
                LastError = "Проблема при удалении депозита " + name + " с индексом " + index + ":" + ex.Message;
                return false;
            }
        }

        /// <summary>
        /// Поиск депозита по индексу
        /// </summary>
        /// <param name="index">Индекс</param>
        /// <returns>запись</returns>
        internal DataRow FindDepositById(int index)
        {
            LastError = "";
            errorOccurred = false;
            try
            {

            if (tableDeposits.Rows.Count == 0)
            {
                return null;

            }

            DataRow query =
            (from item in tableDeposits.AsEnumerable()
             where (item.RowState != DataRowState.Deleted && item.RowState != DataRowState.Detached
             &&
             item.Field<int>(Constants.DepositsIndex) == index)
             select item).SingleOrDefault();

            return query;
            }
            catch (Exception ex)
            {
                errorOccurred = true;
                LastError = "Ошибка в FindDepositById(" + index + "):" + ex.Message;
                return null;
            }

        }

        /// <summary>
        /// Найти депозиты, у которых срок закрытия в промежутке date+days
        /// </summary>
        /// <param name="date">от какой даты считать</param>
        /// <param name="days">дней до закрытия от даты</param>
        /// <returns>Список с индексами депозитов</returns>
        internal List<int> FindDeadlineDeposits(DateTime date, int days)
        {
            LastError = "";
            errorOccurred = false;

            try
            {

            if (tableDeposits.Rows.Count == 0)
            {
                return null;

            }

            var query =
            (from item in tableDeposits.AsEnumerable()
             where (item.RowState != DataRowState.Deleted && item.RowState != DataRowState.Detached
             &&
             item.Field<DateTime>(Constants.DepositsDateEnd) <= (date.AddDays(days)))
             select item);

            List<int> res = new List<int>();
            #region FOREACH ITEM

            foreach (var item in query)
            {
                int index = item.Field<int>(Constants.DepositsIndex);
                res.Add(index);
            }
            #endregion FOREACH ITEM

            return res;
            }
            catch (Exception ex)
            {
                errorOccurred = true;
                LastError = "Ошибка в FindDeadlineDeposits:" + ex.Message;
                return null;
            }
        }

        internal void AddNewDeposit(DepositInfo deposit)
        {
            errorOccurred = false;
            LastError = "";
            try
            {
                DataRow row = tableDeposits.NewRow();

                row[Constants.DepositsName] = deposit.Name;
                row[Constants.DepositsAmount] = deposit.Amount;
                row[Constants.DepositsPercent] = deposit.Percent;

                row[Constants.DepositsDateStart] = deposit.DateStart;
                row[Constants.DepositsDateEnd] = deposit.DateEnd;

                row[Constants.DepositsBankID] = deposit.BankID;
                row[Constants.DepositsCurrencyID] = deposit.CurrencyID;
                row[Constants.DepositsClientID] = deposit.ClientID;

                row[Constants.DepositsClosed] = deposit.Closed;

                row[Constants.InterestPaymentNotification] = deposit.InterestPaymentNotification;
                row[Constants.PeriodInterestPayment] = deposit.PeriodInterestPaymentValue;
                row[Constants.DayInterestPayment] = deposit.DayInterestPaymentValue;

                tableDeposits.Rows.Add(row); 

            }
            catch (Exception ex)
            {
                errorOccurred = true;
                LastError = "Ошибка в AddNewDeposit[" + deposit.Name + "]: " + ex.Message;
                return ;
            }
        }

        internal bool UpdateDeposit(int index, DepositInfo deposit)
        {
            errorOccurred = false;
            LastError = "";
            try
            {
                DataRow row = FindDepositById(index);

                row[Constants.DepositsName] = deposit.Name;
                row[Constants.DepositsAmount] = deposit.Amount;
                row[Constants.DepositsPercent] = deposit.Percent;

                row[Constants.DepositsDateStart] = deposit.DateStart;
                row[Constants.DepositsDateEnd] = deposit.DateEnd;

                row[Constants.DepositsBankID] = deposit.BankID;
                row[Constants.DepositsCurrencyID] = deposit.CurrencyID;
                row[Constants.DepositsClientID] = deposit.ClientID;

                row[Constants.DepositsClosed] = deposit.Closed;

                row[Constants.InterestPaymentNotification] = deposit.InterestPaymentNotification;
                row[Constants.PeriodInterestPayment] = deposit.PeriodInterestPaymentValue;
                row[Constants.DayInterestPayment] = deposit.DayInterestPaymentValue;

                return true;

            }
            catch (Exception ex)
            {
                errorOccurred = true;
                LastError = "Ошибка в UpdateDeposit[" + index+"," + deposit.Name + "]: " + ex.Message;
                return false;
            }
        }

        #endregion Deposits Methods

        #region Clientd Methods

        /// <summary>
        /// Обновить существующего клиента по индексу
        /// </summary>
        /// <param name="index">Индекс</param>
        /// <param name="name">Имя</param>
        internal bool UpdateClient(int index, string name)
        {
            errorOccurred = false;
            LastError = "";
            try
            {
                DataRow row = FindClientById(index);

                row[Constants.BanksName] = name;

                return true;

            }
            catch (Exception ex)
            {
                errorOccurred = true;
                LastError = "Ошибка при обновлении клиента[" + name + "]: " + ex.Message;
                return false;
            }

        }

        /// <summary>
        /// Добавить нового клиента в справочник без проверки на существование
        /// </summary>

        /// <param name="name"></param>
        internal void AddNewClient(string name)
        {
            errorOccurred = false;
            LastError = "";
            try
            {
                DataRow row;

                row = tableClients.NewRow();
                row[Constants.ClientsName] = name;

                tableClients.Rows.Add(row);

            }
            catch (Exception ex)
            {
                errorOccurred = true;
                LastError = "Ошибка при добавлении нового клиента[" + name + "]: " + ex.Message;
            }

        }

        /// <summary>
        /// Удалить клиента из справочника. Проверка на наличие в депозитах осуществляется в форме справочника
        /// </summary>
        /// <param name="index"Индекс клиента в справочнике</param>
        /// <param name="name">Название клиента, может быть пустым, для вывода ошибки</param>
        internal bool RemoveClient(int index, string name)
        {
            LastError = "";
            errorOccurred = false;
            try
            {

                DataRow row = FindClientById(index);

                if (row == null)
                {
                    errorOccurred = true;
                    LastError = "Не найден клиент " + name + " с индексом: " + index;
                    return false;
                }
                tableClients.Rows.Remove(row);
                return true;
            }
            catch (Exception ex)
            {
                errorOccurred = true;
                LastError = "Проблема при удалении клиента " + name + " с индексом " + index + ":" + ex.Message;
                return false;
            }
        }

        /// <summary>
        /// Поиск клиента по индексу
        /// </summary>
        /// <param name="index">Индекс</param>
        /// <returns>запись</returns>
        internal DataRow FindClientById(int index)
        {
            if (tableClients.Rows.Count == 0)
            {
                return null;

            }

            DataRow query =
            (from item in tableClients.AsEnumerable()
             where (item.RowState != DataRowState.Deleted && item.RowState != DataRowState.Detached//!! чтобы не было ошибки после удаления "Невозможно получить доступ к удаленной информации строки через данную строку"/ Также во всех плагинах нужно добавить, что SQL используют!
             &&
             item.Field<int>(Constants.ClientsIndex) == index)
             select item).SingleOrDefault();

            return query;
        }

        #endregion Clientd Methods

        #region Config Methods

        /// <summary>
        /// Обновить запись конфига (ищем name, меняем value)
        /// </summary>
        /// <param name="name">Индекс</param>
        /// <param name="value">Имя</param>
        internal bool UpdateConfig(string name, string value)
        {
            errorOccurred = false;
            LastError = "";
            try
            {
                DataRow row = FindConfigByName(name);
                if (row != null)
                {
                    row[Constants.ConfigValue] = value;
                }
                else
                {
                    errorOccurred = true;
                    LastError = "Не найдена запись конфигурации с именем " + name ;
                    return false;
                }
                return true;

            }
            catch (Exception ex)
            {
                errorOccurred = true;
                LastError = "Ошибка при обновлении конфигурации [" + name + "," + value + "]: " + ex.Message;
                return false;
            }

        }

        /// <summary>
        /// Обновить запись конфига (ищем name, меняем value). Если нет, то создать новую. Если флаг создания false, а записи нет, то выдаст ошибку
        /// </summary>
        /// <param name="name">Индекс</param>
        /// <param name="value">Имя</param>
        /// <param name="create">Создавать ли новую при отсутствии</param>
        internal bool UpdateConfig(string name, string value, bool create)
        {
            errorOccurred = false;
            LastError = "";
            try
            {
                DataRow row = FindConfigByName(name);
                if (row != null)
                {
                    row[Constants.ConfigValue] = value;
                }
                else
                {
                    if (create)
                    {
                        row = tableConfig.NewRow();
                        row[Constants.ConfigName] = name;
                        row[Constants.ConfigValue] = value;

                        tableConfig.Rows.Add(row);
                    }
                    else
                    {
                        errorOccurred = true;
                        LastError = "Не найдена запись конфигурации с именем " + name+", а флаг создания новой не установлен!";
                        return false;
                    }
                }
                return true;

            }
            catch (Exception ex)
            {
                errorOccurred = true;
                LastError = "Ошибка при обновлении конфигурации [" + name + "," + value + "]: " + ex.Message;
                return false;
            }

        }

        /// <summary>
        /// Добавить новую запись в конфигурацию
        /// </summary>
        /// <param name="name">Название параметра</param>
        /// <param name="value">Значение параметра</param>
        internal void AddNewConfig(string name, string value)
        {
            errorOccurred = false;
            LastError = "";
            try
            {
                DataRow row;

                row = tableConfig.NewRow();
                row[Constants.ConfigName] = name;
                row[Constants.ConfigValue] = value;

                tableConfig.Rows.Add(row);

            }
            catch (Exception ex)
            {
                errorOccurred = true;
                LastError = "Ошибка при добавлении новой записи в конфигурацию [" + name + "," + value + "]: " + ex.Message;
            }

        }

        /// <summary>
        /// Удалить запись с именем name из конфигурации
        /// </summary>
        /// <param name="name">Название параметра для удаления</param>
        internal bool RemoveConfig(string name)
        {
            LastError = "";
            errorOccurred = false;
            try
            {

                DataRow row = FindConfigByName(name);

                if (row == null)
                {
                    errorOccurred = true;
                    LastError = "Не найдена запись конфигурации с именем " + name;
                    return false;
                }
                tableConfig.Rows.Remove(row);
                return true;
            }
            catch (Exception ex)
            {
                errorOccurred = true;
                LastError = "Проблема при удалении записи с именем " + name + ":" + ex.Message;
                return false;
            }
        }

        /// <summary>
        /// Поиск записи с именем name в конфигурации
        /// </summary>
        /// <param name="name">Имя параметра</param>
        /// <returns>запись</returns>
        internal DataRow FindConfigByName(string name)
        {
            LastError = "";
            errorOccurred = false;
            try
            {

            if (tableConfig.Rows.Count == 0)
            {
                return null;
            }

            DataRow query =
            (from item in tableConfig.AsEnumerable()
             where (item.RowState != DataRowState.Deleted && item.RowState != DataRowState.Detached
             &&
             item.Field<string>(Constants.ConfigName) == name)
             select item).SingleOrDefault();

            return query;
            }
            catch (Exception ex)
            {
                errorOccurred = true;
                LastError = "Ошибка в FindConfigByName(" + name + "):" + ex.Message;
                return null;
            }
        }

        /// <summary>
        /// Поиск значения параметра по его имени в конфигурации
        /// </summary>
        /// <param name="name">имя параметра</param>
        /// <returns>значение параметра</returns>
        internal string FindConfigValueByName(string name)
        {
            LastError = "";
            errorOccurred = false;
            try
            {

                if (tableConfig.Rows.Count == 0)
                {
                    return null;
                }

                DataRow query =
                (from item in tableConfig.AsEnumerable()
                 where (item.RowState != DataRowState.Deleted && item.RowState != DataRowState.Detached
                 &&
                 item.Field<string>(Constants.ConfigName) == name)
                 select item).SingleOrDefault();

                return query.Field<string>(Constants.ConfigValue);
            }
            catch (Exception ex)
            {
                errorOccurred = true;
                LastError = "Ошибка в FindConfigValueByName(" + name + "):" + ex.Message;
                return null;
            }
        }

        /// <summary>
        /// Узнаем версию базы данных в файле
        /// </summary>
        /// <returns></returns>
        private int GetDataBaseVersion()
        {
            LastError = "";
            errorOccurred = false;
            try
            {

            DataRow row = FindConfigByName(Constants.DbVersionName);
            if (row != null)
            {
                return Convert.ToInt32(row[Constants.ConfigValue]);
            }
            else
            {
                errorOccurred = true;
                LastError = "Не найдена запись конфигурации с именем " + Constants.DbVersionName;
                return -1;
            }

            }
            catch (Exception ex)
            {
                errorOccurred = true;
                LastError = "Ошибка в GetDataBaseVersion:" + ex.Message;
                return -1;
            }

        }

        #endregion Config Methods

    }
}
