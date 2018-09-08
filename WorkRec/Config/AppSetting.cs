using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace WorkRec.Config
{
	static class AppSetting
	{
		// 設定ファイル名
		private const string fileName = "WorkRec";
		// 設定ファイルパス
		private static readonly string SettingPath;

		/// <summary>
		/// 設定ファイルバージョン
		/// </summary>
		public static int Version { get { return data.Version; } }

		/// <summary>
		/// 設定読み込みフラグ
		/// </summary>
		public static bool IsLoad { get; private set; }

		/// <summary>
		/// 記録間隔 (分)
		/// </summary>
		public static int Interval
		{
			get { return data.Interval; }
			set { data.Interval = value; }
		}

		/// <summary>
		/// ログ保存フォルダ
		/// </summary>
		public static string LogFolder
		{
			get { return data.LogFolder; }
			set { data.LogFolder = value; }
		}

		/// <summary>
		/// 記録時刻有効
		/// </summary>
		public static bool RecordTimeEnable
		{
			get { return data.RecordTimeEnable; }
			set { data.RecordTimeEnable = value; }
		}

		/// <summary>
		/// 記録開始時刻
		/// </summary>
		public static TimeSpan BeginTime
		{
			get
			{
				TimeSpan ret;
				TimeSpan.TryParse(data.BeginTime, out ret);
				return ret;
			}
			set { data.BeginTime = value.ToString(); }
		}

		/// <summary>
		/// 記録終了時刻
		/// </summary>
		public static TimeSpan EndTime
		{
			get
			{
				TimeSpan ret;
				TimeSpan.TryParse(data.EndTime, out ret);
				return ret;
			}
			set { data.EndTime = value.ToString(); }
		}

		/// <summary>
		/// ウィンドウを最前面にする
		/// </summary>
		public static bool Activate
		{
			get { return data.Activate; }
			set { data.Activate = value; }
		}

		// ログ履歴
		public static string LogString1
		{
			get { return data.LogString1; }
			set { data.LogString1 = value; }
		}
		public static string LogString2
		{
			get { return data.LogString2; }
			set { data.LogString2 = value; }
		}
		public static string LogString3
		{
			get { return data.LogString3; }
			set { data.LogString3 = value; }
		}
		public static string LogString4
		{
			get { return data.LogString4; }
			set { data.LogString4 = value; }
		}
		public static string LogString5
		{
			get { return data.LogString5; }
			set { data.LogString5 = value; }
		}

		/// <summary>
		/// MainForm 位置
		/// </summary>
		public static Point MainFormLocation
		{
			get { return data.MainFormLocation; }
			set { data.MainFormLocation = value; }
		}
		/// <summary>
		/// MainForm サイズ
		/// </summary>
		public static Size MainFormSize
		{
			get { return data.MainFormSize; }
			set { data.MainFormSize = value; }
		}

		private static AppSettingData data;

		static AppSetting()
		{
			string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
			//path = Path.Combine(path, Application.CompanyName);
			path = Path.Combine(path, Application.ProductName.Replace(".", null).Replace(" ", "_"));
			path = Path.Combine(path, Path.ChangeExtension(fileName, ".config"));
			SettingPath = path;

			// 設定ファイルから読み込む
			data = Load();
			if (data != null) {
				IsLoad = true;
			} else {
				IsLoad = false;
				data = new AppSettingData();
				// デフォルト設定
				data.SetDefault();
				// 設定ファイル保存
				Save();
			}
		}

		public static AppSettingData Load()
		{
			object obj = null;
			try {
				using (FileStream fs = new FileStream(SettingPath, FileMode.Open, FileAccess.Read)) {
					XmlSerializer xs = new XmlSerializer(typeof(AppSettingData));
					obj = xs.Deserialize(fs);
					fs.Close();
				}
			} catch { }
			return (AppSettingData)obj;
		}

		public static void Save()
		{
			Directory.CreateDirectory(Path.GetDirectoryName(SettingPath));
			using (FileStream fs = new FileStream(SettingPath, FileMode.Create, FileAccess.Write)) {
				XmlSerializer xs = new XmlSerializer(typeof(AppSettingData));
				xs.Serialize(fs, data);
				fs.Close();
			}
		}
	}

	[Serializable]
	public class AppSettingData
	{
		// 設定ファイルバージョン
		public int Version;
		// 記録間隔 (分)
		public int Interval;
		// ログ保存フォルダ
		public string LogFolder;
		// 記録時刻有効
		public bool RecordTimeEnable;
		// 開始時刻
		public string BeginTime;
		// 終了時刻
		public string EndTime;
		// ウィンドウを最前面にする
		public bool Activate;
		// ログ履歴
		public string LogString1;
		public string LogString2;
		public string LogString3;
		public string LogString4;
		public string LogString5;
		// MainForm位置
		public Point MainFormLocation;
		// MainForm サイズ
		public Size MainFormSize;

		public void SetDefault()
		{
			// 設定ファイルバージョン
			Version = 1;
			// 記録間隔 (分)
			Interval = 15;
			// ログ保存フォルダ
			LogFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "WorkRec");
			// 記録時刻
			RecordTimeEnable = false;
			BeginTime = TimeSpan.Zero.ToString();
			EndTime = TimeSpan.Zero.ToString();
			// ウィンドウを最前面にする
			Activate = true;
			// ログ履歴
			LogString1 = string.Empty;
			LogString2 = string.Empty;
			LogString3 = string.Empty;
			LogString4 = string.Empty;
			LogString5 = string.Empty;
			// MainForm位置
			MainFormLocation = Point.Empty;
			// MainForm サイズ
			MainFormSize = Size.Empty;
		}
	}
}
