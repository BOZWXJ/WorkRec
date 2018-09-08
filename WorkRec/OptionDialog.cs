using System;
using System.IO;
using System.Windows.Forms;

namespace WorkRec
{
	public partial class OptionDialog : Form
	{
		public int IntervalTime;
		public string LogFolder;
		public bool RecordTimeEnable;
		public TimeSpan BeginTime;
		public TimeSpan EndTime;
		public bool ActivateFlag;

		public OptionDialog()
		{
			InitializeComponent();
		}

		private void OptionDialog_Shown(object sender, EventArgs e)
		{
			// 記録間隔
			intervalUpDown.Value = IntervalTime;
			// 保存フォルダ
			logFolderTextBox.Text = LogFolder;
			// 開始終了時刻
			enableTimeCheckBox.Checked = RecordTimeEnable;
			beginHourNumericUpDown.Enabled = RecordTimeEnable;
			beginHourNumericUpDown.Value = BeginTime.Hours;
			beginMinuteNumericUpDown.Enabled = RecordTimeEnable;
			beginMinuteNumericUpDown.Value = BeginTime.Minutes;
			endHourNumericUpDown.Enabled = RecordTimeEnable;
			endHourNumericUpDown.Value = EndTime.Hours;
			endMinuteNumericUpDown.Enabled = RecordTimeEnable;
			endMinuteNumericUpDown.Value = EndTime.Minutes;
			// ウィンドウを最前面にする
			activateCheckBox.Checked = ActivateFlag;
		}

		private void OptionDialog_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (DialogResult == DialogResult.OK) {
				try {
					logFolderTextBox.Text = Path.GetFullPath(logFolderTextBox.Text);
					if (File.Exists(logFolderTextBox.Text)) {
						throw new Exception();
					}
				} catch {
					MessageBox.Show("保存フォルダに正しいフォルダを指定して下さい。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
					e.Cancel = true;
					return;
				}
				if (string.IsNullOrEmpty(intervalUpDown.Text)) {
					MessageBox.Show("記録間隔を入力して下さい。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
					e.Cancel = true;
					return;
				}
				if (enableTimeCheckBox.Checked && (string.IsNullOrEmpty(beginHourNumericUpDown.Text)
													|| string.IsNullOrEmpty(beginMinuteNumericUpDown.Text)
													|| string.IsNullOrEmpty(endHourNumericUpDown.Text)
													|| string.IsNullOrEmpty(endMinuteNumericUpDown.Text))) {
					MessageBox.Show("時刻を入力して下さい。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
					e.Cancel = true;
					return;
				}
			}
		}

		private void OptionDialog_FormClosed(object sender, FormClosedEventArgs e)
		{
			if (DialogResult == DialogResult.OK) {
				// 記録間隔
				IntervalTime = (int)intervalUpDown.Value;
				// 保存フォルダ
				LogFolder = logFolderTextBox.Text;
				// 開始終了時刻
				RecordTimeEnable = enableTimeCheckBox.Checked;
				BeginTime = new TimeSpan((int)beginHourNumericUpDown.Value, (int)beginMinuteNumericUpDown.Value, 0);
				EndTime = new TimeSpan((int)endHourNumericUpDown.Value, (int)endMinuteNumericUpDown.Value, 0);
				// ウィンドウを最前面にする
				ActivateFlag = activateCheckBox.Checked;
			}
		}

		private void folderButton_Click(object sender, EventArgs e)
		{
			folderBrowserDialog1.SelectedPath = logFolderTextBox.Text;
			if (folderBrowserDialog1.ShowDialog() == DialogResult.OK) {
				logFolderTextBox.Text = folderBrowserDialog1.SelectedPath;
			}
		}

		private void beginTimeEnableCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			beginHourNumericUpDown.Enabled = enableTimeCheckBox.Checked;
			beginMinuteNumericUpDown.Enabled = enableTimeCheckBox.Checked;
			endHourNumericUpDown.Enabled = enableTimeCheckBox.Checked;
			endMinuteNumericUpDown.Enabled = enableTimeCheckBox.Checked;
		}
	}
}
