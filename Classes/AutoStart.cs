using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace DepoMan.Classes
{
    /// <summary>
    /// Enables or disables the autostart (with the OS) of the application.
    /// </summary>
    public static class AutoStart
    {
        private const string RUN_LOCATION = @"Software\Microsoft\Windows\CurrentVersion\Run";
        private static string VALUE_NAME = AssemblyProduct;

        private static string AssemblyProduct
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        /// <summary>
        /// Set the autostart value for the assembly.
        /// </summary>
        public static void SetAutoStart()
        {
            RegistryKey key = Registry.CurrentUser.CreateSubKey(RUN_LOCATION);
            key.SetValue(VALUE_NAME, Assembly.GetExecutingAssembly().Location);
        }

        /// <summary>
        /// Returns whether auto start is enabled.
        /// </summary>
        public static bool IsAutoStartEnabled
        {
            get
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey(RUN_LOCATION);
                if (key == null)
                    return false;

                string value = (string)key.GetValue(VALUE_NAME);
                if (value == null)
                    return false;
                return (value == Assembly.GetExecutingAssembly().Location);
            }
        }

        /// <summary>
        /// Unsets the autostart value for the assembly. на данном этапе удаляет по имени, т.е. для всех путей
        /// </summary>
        public static void UnSetAutoStart()
        {
            RegistryKey key = Registry.CurrentUser.CreateSubKey(RUN_LOCATION);
            //Но вначале проверим, есть ли он там, чтобы не вызывать ошибку
            string value = (string)key.GetValue(VALUE_NAME);
            if (value != null)
            {
                /*
                //Проверим, этот ли путь, чтобы не удалять запуск из других путей
                //if (value==Assembly.GetExecutingAssembly().Location) - Но тогда нужно и key менять, так как при   key.SetValue он перепишет другой путь! Оставлю на потом TODO
                 * */
                key.DeleteValue(VALUE_NAME);
            }
        }
    }
}
