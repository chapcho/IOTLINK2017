using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using log4net.Config;
using System.IO;

namespace IOTL.Common.Log
{
	public class Logger
	{
        private const string SYSTEM_LOG_PATH = @"C:\LOG\";
		private static readonly object locker = new object();

		private ILog _Logger = null;
		public ILog ll
		{
			get { return _Logger; }
		}

		public Logger(string log)
		{
			_Logger = log4net.LogManager.GetLogger(log);
		}

		#region Log Append Func
		/// <summary>
		/// 치명적 장애 발생시 Log Append
		/// </summary>
		/// <param name="message"></param>
		public void appendFatalLog(string message)
		{
			lock (locker)
			{
				DeleteLogFile();

				if (_Logger.IsFatalEnabled)
					_Logger.Fatal(message);
			}
		}

		/// <summary>
		/// 일반적 장애 발생시 Log Append
		/// </summary>
		/// <param name="message"></param>
		public void appendErrorLog(string message)
		{
			lock (locker)
			{
				DeleteLogFile();

				if (_Logger.IsErrorEnabled)
					_Logger.Error(message);
			}
		}

		/// <summary>
		/// 경고 Log Append
		/// </summary>
		/// <param name="message"></param>
		public void appendWarnLog(string message)
		{
			lock (locker)
			{
				DeleteLogFile();

				if (_Logger.IsWarnEnabled)
					_Logger.Warn(message);
			}
		}

		/// <summary>
		/// 정보 Log Append
		/// </summary>
		/// <param name="message"></param>
		public void appendInfoLog(string message)
		{
			lock (locker)
			{
				DeleteLogFile();

				if (_Logger.IsInfoEnabled)
					_Logger.Info(message);
			}
		}

		/// <summary>
		/// 디버그 TRACE용 Log Append
		/// </summary>
		/// <param name="message"></param>
		public void appendDebugLog(string message)
		{
			lock (locker)
			{
				DeleteLogFile();

				if (_Logger.IsDebugEnabled)
					_Logger.Debug(message);
			}
		}
		#endregion

		public void DeleteLogFile()
		{
			try
			{
                string folderPath = SYSTEM_LOG_PATH;
				DirectoryInfo dirInfo = new DirectoryInfo(folderPath);
				if (dirInfo != null)
				{
					foreach (FileInfo file in dirInfo.GetFiles())
					{
						if (file.Extension != ".log")
							continue;

						if (file.CreationTime < DateTime.Now.AddDays(-10))
							file.Delete();
					}
				}
				dirInfo = null;
			}
			catch (Exception ex)
			{
				appendErrorLog(string.Format("Log File Delete Error\r\nMessage : {0}\r\nStack Trace :\r\n{1}", ex.Message, ex.StackTrace));
			}
		}
	}

	public class LogManager
	{
		private static LogManager _instance;
		private static readonly object locker = new object();
		public Logger AppLog = null;
		public Logger SocketLog = null;
		public Logger DbLog = null;

		public static LogManager Instance()
		{
			lock (locker)
			{
				if (_instance == null)
					_instance = new LogManager();

				return _instance;
			}
		}

		public LogManager()
		{
			string strDirPath;
			strDirPath = @"C:\Log";
			DirectoryInfo dirInfo = new DirectoryInfo(strDirPath);
			if (dirInfo.Exists == false)
			{
				if (dirInfo != null)
					dirInfo.Create();
			}

			string AppPath = AppDomain.CurrentDomain.BaseDirectory;
            XmlConfigurator.Configure(new System.IO.FileInfo(AppPath + @"LogConfig.xml"));

			AppLog = new Logger("ApplicationLog");
			SocketLog = new Logger("CommunicationLog");
			DbLog = new Logger("DatabaseLog");
		}
	}
}
