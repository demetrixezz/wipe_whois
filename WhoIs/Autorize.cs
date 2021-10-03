using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhoIs
{
    public static class Autorize
    {
        private static bool status;
        private static string login;

        public static string Login()            { return login;         }
        public static bool   OK()               { return status==true;  }
        public static string StatusDescription(){ return status ? $"Авторизовано для \"{login}\"" : "Требуется авторизация!"; }

        // Процесс авторизации
        public static void Run()
        {
            // Если при запуске нет логина в реестре - запросим ввод логина

            // Если есть логин в реестре - проверим его в базе данных

            // Если логин есть в базе данных - сохраняем логин в реестре и ставим флаг успешной авторизации

            // Если логина нет в базе данных - сбрасываем логин в реестре и просим связаться с админами
        }
        
        
        
        // Записывает логин в реестр
        private static void SaveLogin()
        {
            using(RegistryKey RegKey = Registry.CurrentUser.CreateSubKey(@"Software\WhoIs"))
            {
                RegKey.SetValue("Login", login, RegistryValueKind.String);
            }
        }
        // Загружает из реестра сохранённый логин
        private static bool LoadLogin()
        {
            using(RegistryKey RegKey = Registry.CurrentUser.CreateSubKey(@"Software\WhoIs"))
            {
                login = RegKey.GetValue("Login") != null ? Convert.ToString(RegKey.GetValue("Login")) : "";
                status = (login != "" ? true : false);
            }
            return status;
        }
        // Удаляет запись логина из реестра
        public static void ClearLogin()
        {
            using(RegistryKey RegKey = Registry.CurrentUser.CreateSubKey(@"Software\WhoIs"))
            {
                login = "";
                status = false;
                RegKey.SetValue("Login", login, RegistryValueKind.String);
            }
        }
        // Проверяет наличие логина в базе данных
        private static bool CheckLoginInDB()
        {
            return false;
        }
    }
}
