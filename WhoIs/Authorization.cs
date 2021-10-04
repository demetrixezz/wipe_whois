using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhoIs
{



    public static class Authorization
    {
        public enum AuthState 
            {   
                NoReg=-3,       // Не зарегистрирован в программе
                NoDBLogin=-2,   // Не зарегистрирован в базе данных
                NoDBPass=-1,    // Пароль в базе данных не совпадает
                LoginInvalid=0, // Не правильный логин
                Success=1       // Успешная авторизация
            };

        private static AuthState status;
        private static string login;

        public static string Login()            { return login;         }
        public static bool   OK()               { return status==AuthState.Success;  }
        public static string StatusDescription()
        {
            return
                status == AuthState.NoReg ? "Требуется авторизация!" :
                status == AuthState.NoDBLogin ? $"{login} Не зарегистрирован в базе данных" :
                status == AuthState.NoDBPass ? $"Пароль в базе данных для {login} не совпадает с указанным" :
                status == AuthState.LoginInvalid ? "Не правильный логин" :
                $"Авторизовано для \"{login}\"";
        }

        // Процесс авторизации
        public static AuthState Run()
        {
            // Если при запуске нет логина в реестре -
            // возвращаем "Не зарегистрирован в программе"
            if(!LoadLogin())
            {
                status = AuthState.NoReg;
            }
            // Если есть логин в реестре - проверим его в базе данных
            else
            {
                // Если нет логина в базе данных -
                // возвращаем "Не зарегистрирован в базе данных"
                if(!CheckLoginInDB())
                    status = AuthState.NoDBLogin;
                // Если логин в базе данных зарегистрирован
                else
                {
                    // Если введённый пароль не совпадает с базой данных -
                    // возвращаем "Пароль в базе данных не совпадает"
                    if(!CheckPassInDB())
                        status = AuthState.NoDBPass;
                    // Если логин есть в базе данных и пароль совпадает -
                    // сохраняем логин в реестре и ставим флаг успешной авторизации
                    else
                    {
                        SaveLogin();
                        status = AuthState.Success;
                    }
                }
            }
            return status;
        }
        
        // Записывает логин в реестр
        private static void SaveLogin()
        {
            using(RegistryKey RegKey = Registry.CurrentUser.CreateSubKey(@"Software\WhoIs"))
                RegKey.SetValue("Login", login, RegistryValueKind.String);
        }
        // Загружает из реестра сохранённый логин
        private static bool LoadLogin()
        {
            using(RegistryKey RegKey = Registry.CurrentUser.CreateSubKey(@"Software\WhoIs"))
                login = RegKey.GetValue("Login") != null ? Convert.ToString(RegKey.GetValue("Login")) : "";
            return login != "";
        }
        // Удаляет запись логина из реестра
        public static void ClearLogin()
        {
            using(RegistryKey RegKey = Registry.CurrentUser.CreateSubKey(@"Software\WhoIs"))
                RegKey.SetValue("Login", login, RegistryValueKind.String);
            login = "";
            status = AuthState.NoReg;
        }
        // Проверяет наличие логина в базе данных
        private static bool CheckLoginInDB()
        {
            return true;
        }
        // Проверяет совпадение пароля с базой данных
        private static bool CheckPassInDB()
        {
            return false;
        }
    }
}
