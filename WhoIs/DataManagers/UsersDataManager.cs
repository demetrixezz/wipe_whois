using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhoIs.Helpers;

namespace WhoIs.DataManagers
{
	public class UsersDataManager : BaseDataManager
	{

		/// <summary>
		/// Проверка существует ли такой пользователь
		/// </summary>
		/// <param name="login"></param>
		/// <returns>true если существует false если нет</returns>
		public static bool CheckUserLogin(string login)
		{
			bool result = false;
			
			// параметр для передачи данных в базу
			var loginParam = new SqlParameter("Login", login);

			// запрос в базу ищем всех пользователей с указанным ником их должно быть ровно 1
			var cmd = @"SELECT count(*) FROM Users u
						where u.NickName = @Login";
			
			// выполнение запроса
			var resultCount = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, CommandType.Text, cmd, loginParam));
			
			// проверка результата
			result = resultCount == 1;
			return result;
		}

		/// <summary>
		/// проверяем логин с паролем
		/// в случае если совпадения нет - то проверяем надо ли его восстанавливать для пользователя, если надо то восстанавливаем
		/// </summary>
		/// <param name="login"></param>
		/// <param name="password"></param>
		/// <returns>true если существует false если нет</returns>
		public static bool CheckUserLoginAndPass(string login, string password)
		{
			// параметры для запроса
			var loginParam = new SqlParameter("Login", login);
			var passwordParam = new SqlParameter("Password", HashDataHelper.GetHashString(password));

			// запрос проверки логина с паролем если есть такой то сразу возвращаем true
			var cmd = @"SELECT count(*) FROM Users u
						where u.NickName = @Login AND u.[Password] = @Password";

			var usersCount = Convert.ToInt32(SqlHelper.ExecuteScalar(connectionString, CommandType.Text, cmd, loginParam, passwordParam));
			if (usersCount == 1)
				return true;

			//проверяем надо ли ему восстанавливать пароль
			var needPassResetCmd = @"SELECT [NeedPassReset] FROM Users u
									where u.NickName = @Login; AND u.[Password] is null";

			bool needPassReset = Convert.ToBoolean(SqlHelper.ExecuteScalar(connectionString, CommandType.Text, needPassResetCmd, loginParam));

			//если надо - то восстанавливаем
			if(needPassReset)
			{
				SetPassword(login, password);
				return true;
			}

			return false;
		}

		/// <summary>
		/// устанавливаем логин с паролем
		/// </summary>
		/// <param name="login"></param>
		/// <param name="password"></param>
		public static void SetPassword(string login, string password)
		{
			var loginParam = new SqlParameter("Login", login);
			var passwordParam = new SqlParameter("Password", HashDataHelper.GetHashString(password));

			var cmd = @"update Users
						set
							[Password] = @Password,
							[NeedPassReset] = 0
							where NickName = @Login";

			SqlHelper.ExecuteNonQuery(connectionString, CommandType.Text, cmd, loginParam, passwordParam);
		}

		/// <summary>
		/// переводим в состояние что нужно восстановить пароль
		/// </summary>
		/// <param name="login"></param>
		public static void ResetPassword(string login)
		{
			var loginParam = new SqlParameter("Login", login);
			

			var cmd = @"update Users
						set
							[Password] = null,
							[NeedPassReset] = 1
							where NickName = @Login";

			SqlHelper.ExecuteNonQuery(connectionString, CommandType.Text, cmd, loginParam);
		}
	}
}
