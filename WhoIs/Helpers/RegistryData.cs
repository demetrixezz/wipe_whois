using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WhoIs
{



    public static class RegistryData
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
        private static string password;

        public static string Login()                { return login;                     }
        public static string Password()             { return password;                  }
        public static bool   OK()                   { return status==AuthState.Success; }
        public static string StatusDescription()
        {
            return
                status == AuthState.NoReg ? "Требуется авторизация!" :
                status == AuthState.NoDBLogin ? $"{login} Не зарегистрирован в базе данных" :
                status == AuthState.NoDBPass ? $"Пароль в базе данных для {login} не совпадает с указанным" :
                status == AuthState.LoginInvalid ? "Не правильный логин" :
                $"Авторизовано для \"{login}\"";
        }

        public static void   SetLogin(string name)
        { 
            login = name;
            SaveLogin();
        }
        public static void   SetPassword(string pass)   { password = pass; } 
        
        // Процесс авторизации
        public static AuthState Run()
        {
            MessageBox.Show("Login: " + Login() + "\nPass: " + Password(), "Run enter");
            // Если при запуске нет логина в реестре -
            // возвращаем "Не зарегистрирован в программе"
            if(!LoadLogin() || !LoadPassword())
            {
                status = AuthState.NoReg;
                MessageBox.Show(StatusDescription(), "!LoadLogin || !LoadPassword");
            }
            // Если есть логин и пароль в реестре - проверим их в базе данных
            else
            {
                // Если нет логина в базе данных -
                // возвращаем "Не зарегистрирован в базе данных"
                if(!CheckLoginInDB())
                {
                    status = AuthState.NoDBLogin;
                    MessageBox.Show(StatusDescription(), "!CheckLoginInDB");
                }
                // Если логин в базе данных зарегистрирован
                else
                {
                    // Если введённый пароль не совпадает с базой данных -
                    // возвращаем "Пароль в базе данных не совпадает"
                    if(!CheckPasswordInDB())
                    {
                        status = AuthState.NoDBPass;
                        MessageBox.Show(StatusDescription(), "!CheckPasswordInDB");
                    }
                    // Если логин есть в базе данных и пароль совпадает -
                    // сохраняем логин в реестре и ставим флаг успешной авторизации
                    else
                    {
                        SaveLogin();
                        SavePassword();
                        status = AuthState.Success;
                        MessageBox.Show(StatusDescription(),"OK");
                    }
                }
            }
            MessageBox.Show("Login: " + Login() + "\nPass: " + Password() + "\nStatus" + StatusDescription(), "Run exit");
            return status;
        }
        
        // Записывает в реестр авторизационные данные
        public static void SaveRegistrationData(string name, string pass)
        {
            login = name;
            password = pass;
            SaveLogin();
            SavePassword();
        }
        // Загружает из реестра авторизационные данные
        public static void LoadRegistrationData()
        {
            if(!LoadLogin() && !LoadPassword())
                status = AuthState.NoReg;
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
            login = "";
            using(RegistryKey RegKey = Registry.CurrentUser.CreateSubKey(@"Software\WhoIs"))
                RegKey.SetValue("Login", login, RegistryValueKind.String);
            status = AuthState.NoReg;
        }
        // Проверяет наличие логина в базе данных
        private static bool CheckLoginInDB()
        {
            return true;
        }

        // Записывает пароль в реестр
        private static void SavePassword()
        {
            using(RegistryKey RegKey = Registry.CurrentUser.CreateSubKey(@"Software\WhoIs"))
                RegKey.SetValue("Password", password, RegistryValueKind.String);
        }
        // Загружает из реестра сохранённый пароль
        private static bool LoadPassword()
        {
            using(RegistryKey RegKey = Registry.CurrentUser.CreateSubKey(@"Software\WhoIs"))
                password = RegKey.GetValue("Password") != null ? Convert.ToString(RegKey.GetValue("Password")) : "";
            return password != "";
        }
        // Удаляет запись пароля из реестра
        public static void ClearPassword()
        {
            password = "";
            using(RegistryKey RegKey = Registry.CurrentUser.CreateSubKey(@"Software\WhoIs"))
                RegKey.SetValue("Password", password, RegistryValueKind.String);
            status = AuthState.NoReg;
        }

        // Проверяет совпадение пароля с базой данных
        private static bool CheckPasswordInDB()
        {
            return false;
        }
    }
}
