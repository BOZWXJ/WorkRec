using System;
using System.Threading;
using System.Windows.Forms;

namespace WorkRec
{
	static class Program
	{
		private static string strAppConstName = "WorkRec";
		private static Mutex mutexObject;

		/// <summary>
		/// アプリケーションのメイン エントリ ポイントです。
		/// </summary>
		[STAThread]
		static void Main()
		{
			// Windows 2000（NT 5.0）以降のみグローバル・ミューテックス利用可
			OperatingSystem os = Environment.OSVersion;
			if (os.Platform == PlatformID.Win32NT && os.Version.Major >= 5) {
				strAppConstName = @"Global\" + strAppConstName;
			}

			try {
				mutexObject = new Mutex(false, strAppConstName);
			} catch (ApplicationException) {
				return;
			}

			try {
				if (mutexObject.WaitOne(0, false)) {
					Application.EnableVisualStyles();
					Application.SetCompatibleTextRenderingDefault(false);
					MainForm form = new MainForm();
					Application.Run();
					// ミューテックスを解放する
					mutexObject.ReleaseMutex();
				}
			} finally {
				// ミューテックスを破棄する
				mutexObject.Close();
			}
		}
	}
}
