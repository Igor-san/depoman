using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Windows.Forms;
using DepoMan.Properties;

namespace DepoMan.Classes
{
 

    [StructLayout(LayoutKind.Sequential)]
    public class OSVersionInfo
    {
        public int dwOSVersionInfoSize;
        public int dwMajorVersion;
        public int dwMinorVersion;
        public int dwBuildNumber;
        public int dwPlatformId;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        public String szCSDVersion;
    }

    public static partial class StringExtensions
    {


        public static string GetDirectoryName(this string s)
        {
            return new FileInfo(s).DirectoryName;

        }
        /// <summary>
        /// Gets the extension from a string of full file name.
        /// </summary>
        /// <param name="s">The string to get the extension from.</param>
        /// <returns>The file extension of the string.</returns>
        public static string GetFilePathExtension(this string s)
        {
            return new FileInfo(s).Extension;

        }
        /// <summary>
        /// Gets the Name from a string of full file name.
        /// </summary>
        /// <param name="s">The string to get the Name from.</param>
        /// <returns>The file Name of the string.</returns>
        public static string GetFileName(this string s)
        {
            return new FileInfo(s).Name;
        }
        /// <summary>
        /// 
        /// Получить имя файла без расширения 
        /// </summary>
        /// <param name="s">The string to get the Name from.</param>
        /// <returns></returns>
        public static string GetFileNameWOExt(this string s)
        {
            if (s == String.Empty) return String.Empty;
            string Ext = new FileInfo(s).Extension;
            string Name = new FileInfo(s).Name;
            return Name.Substring(0, (Name.Length - Ext.Length));

        }
        /// <summary>
        /// 
        /// Отбрасываем расширения от передаваемой строки (она может быть d:\windows\system.sav)
        /// </summary>
        /// <param name="s">The string to get the Name from.</param>
        /// <returns></returns>
        public static string DeleteExtension(this string s)
        {
            string Ext = new FileInfo(s).Extension;
            return s.Substring(0, (s.Length - Ext.Length));

        }

        /// <summary>
        /// Получить первую родительскую папку файлаиз пути
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string GetFirstParentFolder(this string s)
        {
            DirectoryInfo di = new FileInfo(s).Directory;

            return di.Name;


        }

        private static void GetAllParentDirectories(DirectoryInfo directoryToScan, ref Stack<DirectoryInfo> directories)
        {
            if (directoryToScan == null || directoryToScan.Name == directoryToScan.Root.Name)
                return;

            directories.Push(directoryToScan);
            GetAllParentDirectories(directoryToScan.Parent, ref directories);
        }

    }

    public static class EnumUtils
    {
        /// <summary>
        /// Расширение для получения описания из [Description("обновление")] с локализацией в ResourceManager
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetLocalDescription(this Enum value)
        {
            Type type = value.GetType();
            string name = Enum.GetName(type, value);
            if (name != null)
            {
                FieldInfo field = type.GetField(name);
                if (field != null)
                {
                    DescriptionAttribute attr =
                           Attribute.GetCustomAttribute(field,
                             typeof(DescriptionAttribute)) as DescriptionAttribute;
                    if (attr != null)
                    {
                        string res = value.ToString();
                        string s = Resources.ResourceManager.GetString(res); //выполним поиск в ресурсах по строковому представлению
                        if ((s == null) || (s == "")) s = attr.Description; // и если нет, то выведем просто описание
                        // return attr.Description;
                        return s;
                    }
                }
            }
            return null;
        }
        /// <summary>
        /// Расширение для получения описания из [Description("обновление")]
        /// </summary>
        public static string GetDescription(this Enum e)
        {
            var s = e.ToString();
            var fi = e.GetType().GetField(s);
            var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(
                typeof(DescriptionAttribute), false);
            if (attributes.Length > 0)
                s = attributes[0].Description;
            return s;
        }
    }

    public class Global //данный класс будет виден из всех проектов, плагинов и т.п. решения
    {
        [DllImport("user32.dll")]
        public static extern bool GetCursorPos(out Point lpPoint);
        [DllImport("user32.dll")]
        public static extern bool ScreenToClient(IntPtr hWnd, out Point lpPoint);

        public static string LastInitialDirectory = String.Empty; //Какой директорией пользовались в последний раз

        private static OSVersionInfo osvi;
        /*
        Console.WriteLine("Class size: " + osvi.dwOSVersionInfoSize);
        Console.WriteLine("Major Version: " + osvi.dwMajorVersion);
        Console.WriteLine("Minor Version: " + osvi.dwMinorVersion);
        Console.WriteLine("Build Number: " + osvi.dwBuildNumber);
        Console.WriteLine("Platform Id: " + osvi.dwPlatformId);
        Console.WriteLine("CSD Version: " + osvi.szCSDVersion);
        Console.WriteLine("Platform: " + Environment.OSVersion.Platform);
        Console.WriteLine("Version: " + Environment.OSVersion.Version);
        */

        public static bool IsDesignMode
        {
            get
            {
                return System.Diagnostics.Debugger.IsAttached;
                
            }

        }

        public static OSVersionInfo OSVI
        {
            get
            {
                return osvi;
            }

            set
            {
                osvi = value;
            }

        }


        public Global()
        {



        } //Constructor


        /// <summary>
        /// Преобразуем строковый одномерный массив arr в строку, разделенную делиметатором delimiter
        /// </summary>
        /// 
        public static string ArrayToString(string[] arr, string delimiter)
        {
            StringBuilder sb = new StringBuilder("");

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                sb.Append(arr[i] + delimiter);

            }
            sb.Remove(sb.Length - delimiter.Length, delimiter.Length);
            return sb.ToString();

        }

        public static string EnryptString(string strEncrypted)
        {
            try
            {
                byte[] b = System.Text.ASCIIEncoding.ASCII.GetBytes(strEncrypted);
                string encryptedConnectionString = Convert.ToBase64String(b);
                return encryptedConnectionString;
            }
            catch
            {
                //throw;
                return "";
            }
        }

        public static string DecryptString(string encrString)
        {
            try
            {
                byte[] b = Convert.FromBase64String(encrString);
                string decryptedConnectionString = System.Text.ASCIIEncoding.ASCII.GetString(b);
                return decryptedConnectionString;
            }
            catch
            {
                //throw;
                return "";
            }
        }

        public static DateTime ConvertStringToDate(string value, string format)
        {
            //ConvertStringToDate("2009-12-21","yyyy-MM-dd")
            //ConvertStringToDate("21.12.2009 16:24:55", "dd.MM.yyyy HH:mm:ss");
            IFormatProvider culture = new CultureInfo("ru-RU", true);

            return DateTime.ParseExact(value, format, culture);
        }


        // Get mouse X coordinates in pixels
        //
        // If a window handle is passed, the result is relative to the client area
        // of that window, otherwise the result is relative to the screen

        internal static int MouseX(IntPtr hWnd)
        {
            Point lpPoint = new Point();
            GetCursorPos(out lpPoint);

            if (hWnd != System.IntPtr.Zero)
            {
                ScreenToClient(hWnd, out lpPoint);
            }

            return lpPoint.X;
        }

        // Get mouse Y coordinates in pixels
        //
        // If a window handle is passed, the result is relative to the client area
        // of that window, otherwise the result is relative to the screen
        internal static int MouseY(IntPtr hWnd)
        {
            Point lpPoint = new Point();
            GetCursorPos(out lpPoint);

            if (hWnd != System.IntPtr.Zero)
            {
                ScreenToClient(hWnd, out lpPoint);
            }

            return lpPoint.Y;
        }




        // Hash an input string and return the hash as
        // a 32 character hexadecimal string.
        public static string getMd5Hash(string input)
        {
            // Create a new instance of the MD5CryptoServiceProvider object.
            MD5 md5Hasher = MD5.Create();

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        // Verify a hash against a string.
        public static bool verifyMd5Hash(string input, string hash)
        {
            // Hash the input.
            string hashOfInput = getMd5Hash(input);

            // Create a StringComparer an comare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(hashOfInput, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

   
    }

    public class Common
    {

        public static ProgramSettings ProgramSettings;


        private static string _ProgramDataPath =Application.ExecutablePath.GetDirectoryName() ; // Environment.CurrentDirectory + "\\"; //откуда запущена программа

        //Но сделать проверку, на существование папки _UserAppDataPath, иначе относительно _appDataPath
        private static string _UserAppDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\" + Constants.AppDataPath; 

        private static bool _Vista = false;

        private static string helpfile = Common.ProgramDataPath +Constants.HelpFile; 
        
        /// <summary>
        /// Показываем хелп для заданной секции (которая как правило извлекается из имени плагина+".htm")
        /// </summary>
        /// <param name="section"></param>
        public static void ShowHelp(Control ctr, string section)
        {
            if (section == "") section = "Introduction";

            Help.ShowHelp(ctr, helpfile, section + Constants.HelpFileExt);
        }


        /// <summary>
        /// версия операционной системы виста или старше
        /// </summary>
        public static bool Vista
        {
            get
            {
                return _Vista;
            }
            set
            {
                _Vista = value;
            }

        }

        /// <summary>
        /// Портабельная версия
        /// </summary>
        public static bool Portable
        {
            get
            {
                return GetUserRight();
            }


        }

        public static string ProgramDataPath
        {
            get
            {
                return _ProgramDataPath;
            }

            set
            {
                _ProgramDataPath = value;
            }

        }

        /// <summary>
        /// </summary>
        public static string UserAppDataPath
        {
            get
            {
                return _UserAppDataPath;
            }
            set
            {
                _UserAppDataPath = value;
            }
        }


        /// <summary>
        /// Может ли текущий пользователь писать в директорию с программой
        /// </summary>
        /// <returns></returns>
        private static bool GetUserRight()
        {

            string path = Common.ProgramDataPath;
            DirectoryInfo dir = new DirectoryInfo(path);
            WindowsIdentity wi = WindowsIdentity.GetCurrent();
            DirectorySecurity ds = dir.GetAccessControl(AccessControlSections.Access);
            AuthorizationRuleCollection rules = ds.GetAccessRules(true, true, typeof(SecurityIdentifier));
            foreach (FileSystemAccessRule rl in rules)
            {
                SecurityIdentifier sid = (SecurityIdentifier)rl.IdentityReference;
                if (((rl.FileSystemRights & FileSystemRights.WriteData) == FileSystemRights.WriteData))
                {
                    if ((sid.IsAccountSid() && wi.User == sid) ||
                        (!sid.IsAccountSid() && wi.Groups.Contains(sid)))
                    {
                        if (rl.AccessControlType == AccessControlType.Allow)
                        {
                            return true;

                        }
                        else
                        {
                            return false;

                        }
                    }
                }
            }

            return false;

       }

        // <T> is the type of data in the list.
        // If you have a List<int>, for example, then call this as follows:
        // List<int> ListOfInt;
        // DataTable ListTable = BuildDataTable<int>(ListOfInt);
        public static DataTable BuildDataTable<T>(IList<T> lst)
        {
            //create DataTable Structure
            DataTable tbl = CreateTable<T>();
            Type entType = typeof(T);
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(entType);
            //get the list item and add into the list
            foreach (T item in lst)
            {
                DataRow row = tbl.NewRow();
                foreach (PropertyDescriptor prop in properties)
                {
                    row[prop.Name] = prop.GetValue(item);
                }
                tbl.Rows.Add(row);
            }
            return tbl;
        }

        private static DataTable CreateTable<T>()
        {
            //T –> ClassName
            Type entType = typeof(T);
            //set the datatable name as class name
            DataTable tbl = new DataTable(entType.Name);
            //get the property list
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(entType);
            foreach (PropertyDescriptor prop in properties)
            {
                //add property as column
                tbl.Columns.Add(prop.Name, prop.PropertyType);
            }
            return tbl;
        }

        internal static bool GetInterestPaymentNotification(object value)
        {
            if (value == DBNull.Value)
            {
                return false;
            }
            return Convert.ToBoolean(value);
        }

        internal static DayInterestPayment GetDayInterestPayment(object value)
        {
            DayInterestPayment defaultValue = DayInterestPayment.DayOfDeposit;
            if (value == DBNull.Value)
            {
                return defaultValue;
            }

            string name = value.ToString();

            foreach (DayInterestPayment item in Enum.GetValues(typeof(DayInterestPayment)))
            {
                if (item.ToString() == name) return item;

            }

            return defaultValue;

        }

        internal static PeriodInterestPayment GetPeriodInterestPayment(object value)
        {
            PeriodInterestPayment defaultValue = PeriodInterestPayment.EndPeriod;
            if (value == DBNull.Value)
            {
                return defaultValue;
            }

            string name = value.ToString();

            foreach (PeriodInterestPayment item in Enum.GetValues(typeof(PeriodInterestPayment)))
            {
                if (item.ToString() == name) return item;

            }

            return defaultValue;
        }
    }

    public class Logger
    {

        public static event EventHandler CriticalErrorOccurred;

        public static int ErrorsCount //произошла ошибка, может не стоит сохранять конфиг файл - может сохраниться пустым
        {
            get;
            private set;
        }

        public string LastErrorMessage
        {
            get;
            private set;
        }

        public Guid LastEventId
        {
            get;
            private set;
        }

        public Exception CriticalErrorException
        {
            get;
            private set;
        }

        public Logger()
        {

        }
        /// <summary>
        /// Сбросим число ошибок
        /// </summary>
        public static void ResetErrors()
        {
            ErrorsCount = 0;
        }

        public static Logger HandleError(Exception ex)
        {
            Logger logger = new Logger()
            {
                LastEventId = Guid.NewGuid(),
                CriticalErrorException = ex
            };
            logger.LastErrorMessage = ex.Message;
            logger.LogCriticalError();
            return logger;
        }

        public static void HandleCriticalError(Exception ex)
        {
            /* Logger logger = HandleError(ex);
             if (CriticalErrorOccurred != null)
                 CriticalErrorOccurred.Invoke(logger, new EventArgs());
             * */
            HandleCriticalError("", ex);
        }
        //перегруженный метод, позволяет выдать полезное сообщение пользователю и записать ошибку и вернуть управление в место возникновения ошибки
        public static void HandleCriticalError(string message, Exception ex)
        {
            if (message != "")
            {
                MessageBox.Show(message, "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Logger logger = HandleError(ex);
            if (CriticalErrorOccurred != null)
                CriticalErrorOccurred.Invoke(logger, new EventArgs());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="log">FALSE то просто ничего не делаем,TRUE пишем в лог но не выдаем сообщение об ошибке</param>
        public static void HandleNonCriticalError(Exception ex, bool log)
        {
            if (log) HandleError(ex); //не выдает сообщение, но пишет в лог и соответственно увеличивает ErrorsCount
            //если log =FALSE то просто ничего не делаем
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message">Если не пусто, то выдаем это сообщение + расшифровка ошибки</param>
        /// <param name="ex">сама ошибка</param>
        /// <param name="log">FALSE не пишем в лог,TRUE пишем в лог и увеличиваем ErrorsCount</param>
        public static void HandleNonCriticalError(string message, Exception ex, bool log)
        {
            if (message != "")
            {
                MessageBox.Show(message + Environment.NewLine + "Описание : (" + ex + ")", "Некритичная ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (log) HandleNonCriticalError(ex, log); //Если логгировать, то логгируем и увеличиваем ErrorsCount
        }

        private void LogCriticalError()
        {
            ErrorsCount++;
            using (StreamWriter streamWriter = new StreamWriter(Constants.LogFileName, true))
            {
                string logMessage = String.Format("ErrorID: {0}\r\nDate: {1}\r\nMessage: {2}\r\nStackTrace: {3}\r\n\r\n",
                        LastEventId, DateTime.Now, CriticalErrorException.Message, CriticalErrorException.StackTrace);
                streamWriter.Write(logMessage);
            }
        }


    }

    public class Utils
    {
        /// <summary>
        /// Создадим нужные директории при первом запуске под Вин7 в случае непортабельной установки
        /// </summary>
        /// <returns></returns>
        public static bool CreateUserAppDataPath(out string error)
        {
            try
            {
                //"Не удалось найти часть пути C:\Windows\system32\Databases" ошибка при запуске из автостарта
                //Т.е. не определяет правильно Common.ProgramDataPath, так как там Environment.CurrentDirectory - автозапуск вызывается Проводником, исправил на Application.ExecutablePath.GetDirectoryName()

                error = "";
                //А если HomeSoft папки еще нет -  Нормально копирует и верхнюю папку
                Directory.CreateDirectory(Common.UserAppDataPath);

                //Папка с базами
                string sourceDirectory = Common.ProgramDataPath +"\\"+ Constants.DataBasesFolderName;
                string targetDirectory = Common.UserAppDataPath + "\\" + Constants.DataBasesFolderName;
                Copy(sourceDirectory, targetDirectory);

                //Папка с БИК
                sourceDirectory = Common.ProgramDataPath + "\\" + Constants.BikFolderName;
                targetDirectory = Common.UserAppDataPath + "\\" + Constants.BikFolderName;
                Copy(sourceDirectory, targetDirectory);

                //Папка с ОКВ
                sourceDirectory = Common.ProgramDataPath + "\\" + Constants.OkvFolderName;
                targetDirectory = Common.UserAppDataPath + "\\" + Constants.OkvFolderName;
                Copy(sourceDirectory, targetDirectory);

                /*
                //копируем нужные файлы
                string fileName = "lottery.xml";
                CopyFile(fileName);

                fileName = "en-lottery.xml";
                CopyFile(fileName);

                fileName = "de-lottery.xml";
                CopyFile(fileName);
                */

                return true;
            }
            catch(Exception ex)
            {
                error = "Ошибка в CreateUserAppDataPath:"+ex.Message;
                return false;
            }
        }


        public static void CopyAll(DirectoryInfo source, DirectoryInfo target)
        {
            // Если директория для копирования файлов не существует, то создаем ее
            if (Directory.Exists(target.FullName) == false)
            {
                Directory.CreateDirectory(target.FullName);
            }

            // Копируем все файлы в новую директорию
            foreach (FileInfo fi in source.GetFiles())
            {
                // Выводим информацию о копировании в консоль
                //Console.WriteLine(@"Copying {0}\{1}", target.FullName, fi.Name);
                fi.CopyTo(Path.Combine(target.ToString(), fi.Name), true);
            }

            // Копируем рекурсивно все поддиректории
            foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
            {
                // Создаем новую поддиректорию в директории
                DirectoryInfo nextTargetSubDir =
                  target.CreateSubdirectory(diSourceSubDir.Name);
                // Опять вызываем функцию копирования
                // Рекурсия
                CopyAll(diSourceSubDir, nextTargetSubDir);
            }
        }

        // Метод копирования: задаем две директории откуда копировать и куда копировать
        public static void Copy(string sourceDirectory, string targetDirectory)
        {
            DirectoryInfo diSource = new DirectoryInfo(sourceDirectory);
            DirectoryInfo diTarget = new DirectoryInfo(targetDirectory);
            // Вызываем основной метод копирования
            CopyAll(diSource, diTarget);
        }

        public static void CopyFile(string fileName)
        {
            if (!File.Exists(Common.ProgramDataPath + fileName)) return;
            string sourceFile = Common.ProgramDataPath + fileName;
            string targetFile = Common.UserAppDataPath + fileName;
            File.Copy(sourceFile, targetFile, true);
        }


        public class MyEventArgs : EventArgs
        {
            public MyEventArgs(bool result, string message)
            {
                this.result = result;
                this.message = message;
            }

            public bool result; //результат какой-то операции (например, сохранение)
            public string message;//сообщение после какой-то операции


        }	//end of class MyEventArgs



        public class MyException : Exception
        {
            public MyException()
            {
            }
            public MyException(string message)
                : base(message)
            {
            }
            public MyException(string message, Exception inner)
                : base(message, inner)
            {
            }
        }
    }

    public class OtherFunctions
    {
        /// <summary>
        /// Удалить пустые строки
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static string[] RemoveEmptyLines(string[] lines)
        {
            if (lines == null) return new string[0];
            List<string> res = new List<string>();
            for (int i = 0; i < lines.GetLength(0); i++)
            {
                string val = lines[i].Trim();
                if (val != String.Empty) res.Add(val);
            }
            return res.ToArray();
        }
        /// <summary>
        /// Удалить строку из массива
        /// </summary>
        /// <param name="value">строка для удаления</param>
        /// <param name="lines">массив строк</param>
        /// <returns></returns>
        public static string[] RemoveStringFromLines(string value,string[] lines)
        {
            if (lines == null) return new string[0];
            List<string> res = new List<string>();
            for (int i = 0; i < lines.GetLength(0); i++)
            {
                string val = lines[i].Trim();
                if (val != value) res.Add(val);
            }
            return res.ToArray();
        }
        /// <summary>
        /// Копировать выбранные ячейки в Клипбоард в формате текста
        /// </summary>
        /// <param name="Grid"></param>
        public static void CopySelectedCellsToClipBoardText(DataGridView Grid)
        {
            if (Grid == null) return; //29.10.2014
            var newline = System.Environment.NewLine;
            var tab = "\t";
            var clipboard_string = new StringBuilder();

            foreach (DataGridViewRow row in Grid.Rows)
            {
                int cellsInRow = 0;
                for (int i = 0; i < row.Cells.Count; i++)
                {
                    if (!row.Cells[i].Selected) continue;
                    clipboard_string.Append(row.Cells[i].Value + tab);
                    cellsInRow++;
                }
                if (cellsInRow > 0) clipboard_string.Append(newline);

            }

            Clipboard.SetText(clipboard_string.ToString());

        }

        /// <summary>
        /// Копировать выбранные ячейки в Клипбоард в формате Html
        /// </summary>
        /// <param name="Grid"></param>
        public static void CopySelectedCellsToClipBoardHtml(DataGridView Grid)
        {
            if (Grid == null) return; //29.10.2014
            //Это вроде всегда правильная кодировка
            String HTData = Grid.GetClipboardContent().GetText(TextDataFormat.Html);
            int StartLen = HTData.Length;

            byte[] UTF8Data = Encoding.UTF8.GetBytes(HTData);
            HTData = Encoding.Default.GetString(UTF8Data);

            int LenAdd = HTData.Length - StartLen;

            String HTMLLenData = HTData.Substring(HTData.IndexOf("EndHTML") + 8, 8);
            String FragmentLenData = HTData.Substring(HTData.IndexOf("EndFragment") + 12, 8);
            String NewHTMLLenData = (int.Parse(HTMLLenData) + LenAdd).ToString("D8");
            String NewFragmentLenData = (int.Parse(FragmentLenData) + LenAdd).ToString("D8");
            HTData = HTData.Replace("EndHTML:" + HTMLLenData, "EndHTML:" + NewHTMLLenData);
            HTData = HTData.Replace("EndFragment:" + FragmentLenData, "EndFragment:" + NewFragmentLenData);

            byte[] DataToStream = Encoding.Default.GetBytes(HTData);
            MemoryStream DataToClipBoard = new MemoryStream(DataToStream);
            Clipboard.SetData(DataFormats.Html, DataToClipBoard);
            DataToClipBoard.Dispose();
        }

        /// <summary>
        /// Преобразуем строковый одномерный массив arr в строку, разделенную делиметатором delimiter
        /// класс LotteryConfig
        /// </summary>
        /// 
        public static string ArrayToString(string[] arr, string delimiter)
        {
            if ((arr == null) || (arr.GetLength(0) <= 0)) return String.Empty;
            StringBuilder sb = new StringBuilder("");

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                sb.Append(arr[i] + delimiter);

            }
            sb.Remove(sb.Length - delimiter.Length, delimiter.Length);
            return sb.ToString();

        }

        #region List To String

        public static string ListToString(List<decimal> lst, string delimiter)
        {
            if ((lst == null) || (lst.Count <= 0)) return String.Empty;
            StringBuilder sb = new StringBuilder("");

            for (int i = 0; i < lst.Count; i++)
            {
                sb.Append(lst[i] + delimiter);

            }
            sb.Remove(sb.Length - delimiter.Length, delimiter.Length);
            return sb.ToString();

        }

        public static string ListToString(List<int> arr, string delimiter)
        {
            if ((arr == null) || (arr.Count <= 0)) return String.Empty;
            StringBuilder sb = new StringBuilder("");

            for (int i = 0; i < arr.Count; i++)
            {
                sb.Append(arr[i] + delimiter);

            }
            sb.Remove(sb.Length - delimiter.Length, delimiter.Length);
            return sb.ToString();

        }

        public static string ListToString(List<string> lst, string delimiter)
        {
            if ((lst == null) || (lst.Count <= 0)) return String.Empty;
            StringBuilder sb = new StringBuilder("");

            for (int i = 0; i < lst.Count; i++)
            {
                sb.Append(lst[i] + delimiter);

            }
            sb.Remove(sb.Length - delimiter.Length, delimiter.Length);
            return sb.ToString();

        }



        #endregion List To String

        /// <summary>
        /// Аналог Join,преобразует массив целых в строку с заданным сепаратором. -1 заменяется на _ !
        /// </summary>
        /// <param name="separator"></param>
        /// <param name="array"></param>
        /// <returns></returns>
        public static string IntArrayToString(int[] array, string separator)
        {

            if ((array == null) || (array.GetLength(0) <= 0)) return String.Empty;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < array.GetLength(0) - 1; i++)
            {
                if (array[i] == -1) sb.Append("_" + separator); //Если в массиве есть -1 (для условия removeFromColumnCheckBox)
                else sb.Append(array[i].ToString() + separator);
            }
            if (array[array.GetLength(0) - 1] == -1) sb.Append("_");
            else sb.Append(array[array.GetLength(0) - 1].ToString());

            return sb.ToString();

        }

 
        /// <summary>
        /// Аналог Join,преобразует массив целых в строку с заданным сепаратором. -1 не преобразуется в _ !
        /// </summary>
        /// <param name="array">Входной массив</param>
        /// <param name="separator">Разделитель</param>
        /// <param name="separator">Лидирующий ноль</param>
        /// <returns></returns>
        public static string IntArrayToString(int[] array, string separator, bool nullLeader)
        {
            if ((array == null) || (array.GetLength(0) <= 0)) return "";
            int val;
            string str;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < array.GetLength(0); i++)
            {

                val = array[i];
                if ((Math.Abs(val) < 10) && (nullLeader))
                    str = "0" + val.ToString();//добавляем лидирующий 0
                else str = val.ToString();
                sb.Append(str + separator);

            }


            return sb.ToString();

        }

        /// <summary>
        ///  Преобразование строки в массив чисел с автоматическим распознаванием разделителя
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        public static int[] AutoStringToIntArray(string line, out string error)
        {
            int[] result;
            error = "";
            try
            {
                List<int> list = new List<int>();
                string temp = "";

                int count = 0;
                for (int i = 0; i < line.Length; i++)
                {
                    if (Char.IsDigit(line[i]))
                    {
                        temp += line[i];
                        count = 0;
                    }
                    else
                    {
                        if (count == 0)
                        {
                            list.Add(Convert.ToInt32(temp));
                            count++; //чтобы обрабатывать повторы разделителя, например несколько пробелов
                            temp = "";
                        }

                    }


                }
                if (temp != "") list.Add(Convert.ToInt32(temp));
                result = new int[list.Count];
                list.CopyTo(result);
            }
            catch (Exception ex)
            {
                error = "Ошибка преобразования в массив строки [" + line + "]: " + ex.Message;
                return null;
            }

            return result;
        }

        /// <summary>
        ///  Преобразование строки в массив чисел с заданным разделителем между числами
        /// </summary>
        /// <param name="line">Строка входа</param>
        /// <param name="error">Выходная ошибка</param>
        /// <returns>Массив целых чисел</returns>
        public static int[] StringToIntArray(string line, string separator, out string error)
        {
            int[] result;
            error = "";
            try
            {
                string[] aSeparator = new string[1] { separator };
                string[] sResult = line.Split(aSeparator, StringSplitOptions.RemoveEmptyEntries);
                int sResultLength = sResult.GetLength(0);
                result = new int[sResultLength];

                for (int i = 0; i < sResultLength; i++)
                {
                    result[i] = -1;
                    bool oK = Int32.TryParse(sResult[i], out result[i]); //если ошибка, просто вставляем -1 без предупреждений
                    if (!oK)
                    {
                        error += "Ошибка преобразования символа '" + sResult[i] + "' в целое число [" + line + "]";
                        return null;
                    }

                }

            }
            catch (Exception ex)
            {
                error += "Ошибка преобразования в целочисленный массив строки [" + line + "]: " + ex.Message;
                return null;
            }

            return result;
        }

        /// <summary>
        ///  Преобразование строки в массив чисел с заданным разделителем между числами
        /// </summary>
        /// <param name="line">Строка входа</param>
        /// <param name="error">Выходная ошибка</param>
        /// <returns>Массив десятичных чисел</returns>
        public static decimal[] StringToDecimalArray(string line, string separator, out string error)
        {
            decimal[] result;
            error = "";
            try
            {
                string[] aSeparator = new string[1] { separator };
                string[] sResult = line.Split(aSeparator, StringSplitOptions.RemoveEmptyEntries);
                int sResultLength = sResult.GetLength(0);
                result = new decimal[sResultLength];

                for (int i = 0; i < sResultLength; i++)
                {
                    result[i] = -1;
                    bool oK = Decimal.TryParse(sResult[i], out result[i]); //если ошибка, просто вставляем -1 без предупреждений
                    if (!oK)
                    {
                        error += "Ошибка преобразования символа '" + sResult[i] + "' в десятичное число [" + line + "]";
                        return null;
                    }

                }

            }
            catch (Exception ex)
            {
                error += "Ошибка преобразования в десятичный массив строки [" + line + "]: " + ex.Message;
                return null;
            }

            return result;
        }

 
    }

}
