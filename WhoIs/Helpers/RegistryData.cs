﻿using Microsoft.Win32;
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
        
        ///*<summary> Записывает в реестр авторизационные данные </summary>*/
        public static void SaveRegistrationData(string name, string pass)
        {
            SetLogin(name);
            SetPassword(pass);
        }

        ///*<summary> Устанавливает логин и записывает его в реестр </summary>*/
        public static void   SetLogin(string name)
        { 
            login = name;
            SaveLogin();
        }
        ///*<summary> Устанавливает пароль и записывает его в реестр </summary>*/
        public static void   SetPassword(string pass)   
        {
            password = pass;
            SavePassword();
        }
        ///*<summary> Загружает из реестра авторизационные данные </summary>*/
        public static void LoadRegistrationData()
        {
            if(!LoadLogin() & !LoadPassword())
                status = AuthState.NoReg;
        }

        ///*<summary> Записывает логин в реестр </summary>*/
        private static void SaveLogin()
        {
            using(RegistryKey RegKey = Registry.CurrentUser.CreateSubKey(@"Software\WhoIs"))
                RegKey.SetValue("Login", login, RegistryValueKind.String);
        }
        ///*<summary> Загружает из реестра сохранённый логин </summary>*/
        private static bool LoadLogin()
        {
            using(RegistryKey RegKey = Registry.CurrentUser.CreateSubKey(@"Software\WhoIs"))
                login = RegKey.GetValue("Login") != null ? Convert.ToString(RegKey.GetValue("Login")) : "";
            return login != "";
        }
        ///*<summary> Удаляет запись логина из реестра </summary>*/
        public static void ClearLogin()
        {
            login = "";
            using(RegistryKey RegKey = Registry.CurrentUser.CreateSubKey(@"Software\WhoIs"))
                RegKey.DeleteValue("Login", false);
            status = AuthState.NoReg;
        }
        ///*<summary> Проверяет наличие логина в базе данных </summary>*/
        private static bool CheckLoginInDB()
        {
            return true;
        }

        ///*<summary> Записывает пароль в реестр </summary>*/
        private static void SavePassword()
        {
            using(RegistryKey RegKey = Registry.CurrentUser.CreateSubKey(@"Software\WhoIs"))
                RegKey.SetValue("Password", password, RegistryValueKind.String);
        }
        ///*<summary> Загружает из реестра сохранённый пароль </summary>*/
        private static bool LoadPassword()
        {
            using(RegistryKey RegKey = Registry.CurrentUser.CreateSubKey(@"Software\WhoIs"))
                password = RegKey.GetValue("Password") != null ? Convert.ToString(RegKey.GetValue("Password")) : "";
            return password != "";
        }
        ///*<summary> Удаляет запись пароля из реестра </summary>*/
        public static void ClearPassword()
        {
            password = "";
            using(RegistryKey RegKey = Registry.CurrentUser.CreateSubKey(@"Software\WhoIs"))
                RegKey.DeleteValue("Password", true);
            status = AuthState.NoReg;
        }

        ///*<summary> Проверяет совпадение пароля с базой данных </summary>*/
        private static bool CheckPasswordInDB()
        {
            return false;
        }
    }
}
