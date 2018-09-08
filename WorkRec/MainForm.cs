using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using WorkRec.Config;
using WorkRec.Lib;

namespace WorkRec
{
	public partial class MainForm : Form
	{
		/// <summary>
		/// タスクバー点滅用 構造体
		/// </summary>
		private WinAPI.FLASHWINFO fInfo;
		/// <summary>
		/// 作業開始時刻
		/// </summary>
		private DateTime startTime;
		/// <summary>
		/// 作業終了時刻
		/// </summary>
		private DateTime endTime;
		/// <summary>
		/// アプリケーション終了フラグ
		/// </summary>
		private bool exit;
		/// <summary>
		/// 記録間隔ダウンカウンタ
		/// </summary>
		private int countDown;

		public MainForm()
		{
			InitializeComponent();

			// タスクバー点滅用 構造体 準備
			fInfo = new WinAPI.FLASHWINFO();
			fInfo.cbSize = Convert.ToUInt32(Marshal.SizeOf(fInfo));
			fInfo.hwnd = this.Handle;
			fInfo.dwFlags = WinAPI.FLASHWFLAGS.FLASHW_ALL | WinAPI.FLASHWFLAGS.FLASHW_TIMERNOFG;
			fInfo.uCount = 0;
			fInfo.dwTimeout = 0;

			// フォーム位置の復元
			if (AppSetting.IsLoad && !AppSetting.MainFormSize.IsEmpty) {
				this.Size = AppSetting.MainFormSize;
				this.DesktopLocation = AppSetting.MainFormLocation;
			} else {
				this.StartPosition = FormStartPosition.WindowsDefaultLocation;
			}
			this.MaximumSize = new Size(int.MaxValue, this.Height);

			startTime = DateTime.Now;
			endTime = startTime;
			exit = false;

			setRadioButton();
			preCheckTime = !AppSetting.RecordTimeEnable || checkRecordTime(endTime.TimeOfDay);
			if (preCheckTime) {
				recordStart();
			} else {
				recordStop();
			}
			setActivate(AppSetting.Activate);

			// 記録タイマ開始
			timer1.Enabled = true;
		}

		private bool ForceActivation = false;
		protected override bool ShowWithoutActivation
		{
			get
			{
				bool ret = !AppSetting.Activate && !ForceActivation;
				ForceActivation = false;
				return ret;
			}
		}

		protected override void WndProc(ref Message m)
		{
			if (m.Msg == WinAPI.WM_QUERYENDSESSION) {
				exit = true;
			}
			base.WndProc(ref m);
		}

		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			AppendLogFile(logTextBox.Text);
			if (!exit) {
				this.Visible = false;
				e.Cancel = true;
			} else {
				timer1.Enabled = false;
				AppSetting.MainFormSize = Size;
				AppSetting.MainFormLocation = DesktopLocation;
				AppSetting.Save();
			}
		}

		private void MainForm_Activated(object sender, EventArgs e)
		{
			logTextBox.Focus();
			logTextBox.SelectAll();
			radioButton1.Checked = false;
			radioButton2.Checked = false;
			radioButton3.Checked = false;
			radioButton4.Checked = false;
			radioButton5.Checked = false;
		}

		private bool preCheckTime;
		private void timer1_Tick(object sender, EventArgs e)
		{
			if (recordToolStripMenuItem.Checked) {
				countDown--;
				if (countDown <= 0) {
					showForm();
				}
			}
			// 記録時刻判定処理
			if (AppSetting.RecordTimeEnable) {
				bool f = checkRecordTime(DateTime.Now.TimeOfDay);
				if (f != preCheckTime) {
					if (f) {
						System.Diagnostics.Debug.WriteLine(DateTime.Now.TimeOfDay + " 記録開始");
						recordStart();
					} else {
						System.Diagnostics.Debug.WriteLine(DateTime.Now.TimeOfDay + " 記録停止");
						recordStop();
						showForm();
					}
				}
				preCheckTime = f;
			}
		}

		private void MainForm_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Modifiers == Keys.Control) {
				if (e.KeyCode == Keys.Enter) {
					e.Handled = true;
					this.Hide();
					AppendLogFile(logTextBox.Text);
					countDown = AppSetting.Interval;
				} else if (radioButton1.Enabled && (e.KeyCode == Keys.D1 || e.KeyCode == Keys.NumPad1)) {
					e.Handled = true;
					radioButton1.Checked = true;
				} else if (radioButton2.Enabled && (e.KeyCode == Keys.D2 || e.KeyCode == Keys.NumPad2)) {
					e.Handled = true;
					radioButton2.Checked = true;
				} else if (radioButton3.Enabled && (e.KeyCode == Keys.D3 || e.KeyCode == Keys.NumPad3)) {
					e.Handled = true;
					radioButton3.Checked = true;
				} else if (radioButton4.Enabled && (e.KeyCode == Keys.D4 || e.KeyCode == Keys.NumPad4)) {
					e.Handled = true;
					radioButton4.Checked = true;
				} else if (radioButton5.Enabled && (e.KeyCode == Keys.D5 || e.KeyCode == Keys.NumPad5)) {
					e.Handled = true;
					radioButton5.Checked = true;
				}
			}
		}

		private void addButton_Click(object sender, EventArgs e)
		{
			this.Hide();
			AppendLogFile(logTextBox.Text);
			countDown = AppSetting.Interval;
		}

		private void radioButton_CheckedChanged(object sender, EventArgs e)
		{
			if (((RadioButton)sender).Checked) {
				this.Hide();
				logTextBox.Text = (string)((RadioButton)sender).Tag;
				AppendLogFile(logTextBox.Text);
				countDown = AppSetting.Interval;
			}
		}

		#region トレイアイコンメニュー

		private void showToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ForceActivation = true;
			showForm();
		}

		private void recordToolStripMenuItem_Click(object sender, EventArgs e)
		{
			bool f = !recordToolStripMenuItem.Checked;
			if (f) {
				recordStart();
			} else {
				recordStop();
				showForm();
			}
		}

		private void activateToolStripMenuItem_Click(object sender, EventArgs e)
		{
			setActivate(!AppSetting.Activate);
		}

		private void optionToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OptionDialog dlg = new OptionDialog();
			dlg.IntervalTime = AppSetting.Interval;
			dlg.LogFolder = AppSetting.LogFolder;
			dlg.RecordTimeEnable = AppSetting.RecordTimeEnable;
			dlg.BeginTime = AppSetting.BeginTime;
			dlg.EndTime = AppSetting.EndTime;
			dlg.ActivateFlag = AppSetting.Activate;
			if (dlg.ShowDialog() == DialogResult.OK) {
				AppSetting.Interval = dlg.IntervalTime;
				AppSetting.LogFolder = dlg.LogFolder;
				AppSetting.RecordTimeEnable = dlg.RecordTimeEnable;
				AppSetting.BeginTime = dlg.BeginTime;
				AppSetting.EndTime = dlg.EndTime;
				setActivate(dlg.ActivateFlag);
				AppSetting.Save();
			}
		}

		private void infoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			AboutBox dlg = new AboutBox();
			dlg.ShowDialog();
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			notifyIcon1.Visible = false;
			exit = true;
			Application.Exit();
		}

		#endregion

		/// <summary>
		/// ログファイルに追記する
		/// </summary>
		/// <param name="str"></param>
		private void AppendLogFile(string str)
		{
			endTime = DateTime.Now;
			str = str.Trim().Replace("\t", " ").Replace("\"", "\"\"");
			string line = string.Format("\"{0}\",{1},{2},{3}\r\n", str, startTime, endTime, (endTime - startTime).TotalMinutes);
			string file = Path.Combine(AppSetting.LogFolder, string.Format("{0:yyyyMMdd}.csv", DateTime.Now));
			startTime = endTime;
			if (!string.IsNullOrEmpty(str) && AppSetting.LogString1 != str) {
				string[] log = { AppSetting.LogString1, AppSetting.LogString2, AppSetting.LogString3, AppSetting.LogString4, AppSetting.LogString5 };
				bool find = false;
				for (int i = 0; i < log.Length - 1; i++) {
					find |= log[i] == str;
					if (find) {
						log[i] = log[i + 1];
					}
				}
				AppSetting.LogString1 = str;
				AppSetting.LogString2 = log[0];
				AppSetting.LogString3 = log[1];
				AppSetting.LogString4 = log[2];
				AppSetting.LogString5 = log[3];
				setRadioButton();
			}
			try {
				Directory.CreateDirectory(AppSetting.LogFolder);
				File.AppendAllText(file, line, Encoding.GetEncoding(932));
				System.Diagnostics.Debug.Write(line);
			} catch {
				MessageBox.Show("ログファイルに追加できませんでした。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		/// <summary>
		/// ログ履歴ボタン設定
		/// </summary>
		private void setRadioButton()
		{
			radioButton1.Text = "1:" + AppSetting.LogString1;
			radioButton1.Tag = AppSetting.LogString1;
			radioButton1.Enabled = !string.IsNullOrEmpty(AppSetting.LogString1);
			radioButton1.Checked = false;

			radioButton2.Text = "2:" + AppSetting.LogString2;
			radioButton2.Tag = AppSetting.LogString2;
			radioButton2.Enabled = !string.IsNullOrEmpty(AppSetting.LogString2);
			radioButton2.Checked = false;

			radioButton3.Text = "3:" + AppSetting.LogString3;
			radioButton3.Tag = AppSetting.LogString3;
			radioButton3.Enabled = !string.IsNullOrEmpty(AppSetting.LogString3);
			radioButton3.Checked = false;

			radioButton4.Text = "4:" + AppSetting.LogString4;
			radioButton4.Tag = AppSetting.LogString4;
			radioButton4.Enabled = !string.IsNullOrEmpty(AppSetting.LogString4);
			radioButton4.Checked = false;

			radioButton5.Text = "5:" + AppSetting.LogString5;
			radioButton5.Tag = AppSetting.LogString5;
			radioButton5.Enabled = !string.IsNullOrEmpty(AppSetting.LogString5);
			radioButton5.Checked = false;
		}

		/// <summary>
		/// Form Activate フラグ設定
		/// </summary>
		/// <param name="f"></param>
		private void setActivate(bool f)
		{
			AppSetting.Activate = f;
			activateToolStripMenuItem.Checked = f;
		}

		/// <summary>
		/// 記録時刻を判定する
		/// </summary>
		/// <param name="time"></param>
		/// <returns></returns>
		private static bool checkRecordTime(TimeSpan time)
		{
			TimeSpan begin = AppSetting.BeginTime;
			TimeSpan end = AppSetting.EndTime;
			if (begin <= end) {
				return begin <= time && time <= end;
			} else {
				return begin <= time || time <= end;
			}
		}

		/// <summary>
		/// 記録開始
		/// </summary>
		private void recordStart()
		{
			recordToolStripMenuItem.Checked = true;
			countDown = AppSetting.Interval;
		}

		/// <summary>
		/// 記録終了
		/// </summary>
		private void recordStop()
		{
			recordToolStripMenuItem.Checked = false;
			countDown = AppSetting.Interval;
		}

		/// <summary>
		/// 記録フォーム表示
		/// </summary>
		private void showForm()
		{
			countDown = AppSetting.Interval;
			this.Visible = true;
			WinAPI.FlashWindowEx(ref fInfo);
		}

	}
}
