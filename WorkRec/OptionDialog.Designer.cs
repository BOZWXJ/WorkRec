namespace WorkRec
{
	partial class OptionDialog
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.intervalUpDown = new System.Windows.Forms.NumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			this.activateCheckBox = new System.Windows.Forms.CheckBox();
			this.logFolderTextBox = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.folderButton = new System.Windows.Forms.Button();
			this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			this.okButton = new System.Windows.Forms.Button();
			this.cancelButton = new System.Windows.Forms.Button();
			this.enableTimeCheckBox = new System.Windows.Forms.CheckBox();
			this.endMinuteNumericUpDown = new System.Windows.Forms.NumericUpDown();
			this.endHourNumericUpDown = new System.Windows.Forms.NumericUpDown();
			this.beginMinuteNumericUpDown = new System.Windows.Forms.NumericUpDown();
			this.beginHourNumericUpDown = new System.Windows.Forms.NumericUpDown();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.intervalUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.endMinuteNumericUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.endHourNumericUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.beginMinuteNumericUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.beginHourNumericUpDown)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(19, 14);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(53, 12);
			this.label1.TabIndex = 0;
			this.label1.Text = "記録間隔";
			// 
			// intervalUpDown
			// 
			this.intervalUpDown.Location = new System.Drawing.Point(96, 12);
			this.intervalUpDown.Name = "intervalUpDown";
			this.intervalUpDown.Size = new System.Drawing.Size(50, 19);
			this.intervalUpDown.TabIndex = 1;
			this.intervalUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(152, 14);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(17, 12);
			this.label2.TabIndex = 2;
			this.label2.Text = "分";
			// 
			// activateCheckBox
			// 
			this.activateCheckBox.AutoSize = true;
			this.activateCheckBox.Location = new System.Drawing.Point(21, 109);
			this.activateCheckBox.Name = "activateCheckBox";
			this.activateCheckBox.Size = new System.Drawing.Size(140, 16);
			this.activateCheckBox.TabIndex = 14;
			this.activateCheckBox.Text = "ウィンドウを最前面にする";
			this.activateCheckBox.UseVisualStyleBackColor = true;
			// 
			// logFolderTextBox
			// 
			this.logFolderTextBox.Location = new System.Drawing.Point(96, 37);
			this.logFolderTextBox.Name = "logFolderTextBox";
			this.logFolderTextBox.Size = new System.Drawing.Size(175, 19);
			this.logFolderTextBox.TabIndex = 4;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(19, 40);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(64, 12);
			this.label3.TabIndex = 3;
			this.label3.Text = "保存フォルダ";
			// 
			// folderButton
			// 
			this.folderButton.Location = new System.Drawing.Point(277, 35);
			this.folderButton.Name = "folderButton";
			this.folderButton.Size = new System.Drawing.Size(25, 23);
			this.folderButton.TabIndex = 5;
			this.folderButton.Text = "...";
			this.folderButton.UseVisualStyleBackColor = true;
			this.folderButton.Click += new System.EventHandler(this.folderButton_Click);
			// 
			// folderBrowserDialog1
			// 
			this.folderBrowserDialog1.Description = "保存先を選択して下さい。";
			// 
			// okButton
			// 
			this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.okButton.Location = new System.Drawing.Point(146, 131);
			this.okButton.Name = "okButton";
			this.okButton.Size = new System.Drawing.Size(75, 23);
			this.okButton.TabIndex = 15;
			this.okButton.Text = "OK";
			this.okButton.UseVisualStyleBackColor = true;
			// 
			// cancelButton
			// 
			this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelButton.Location = new System.Drawing.Point(227, 131);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(75, 23);
			this.cancelButton.TabIndex = 16;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.UseVisualStyleBackColor = true;
			// 
			// enableTimeCheckBox
			// 
			this.enableTimeCheckBox.AutoSize = true;
			this.enableTimeCheckBox.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.enableTimeCheckBox.Location = new System.Drawing.Point(21, 62);
			this.enableTimeCheckBox.Name = "enableTimeCheckBox";
			this.enableTimeCheckBox.Size = new System.Drawing.Size(136, 16);
			this.enableTimeCheckBox.TabIndex = 6;
			this.enableTimeCheckBox.Text = "記録時間帯を指定する";
			this.enableTimeCheckBox.UseVisualStyleBackColor = true;
			this.enableTimeCheckBox.CheckedChanged += new System.EventHandler(this.beginTimeEnableCheckBox_CheckedChanged);
			// 
			// endMinuteNumericUpDown
			// 
			this.endMinuteNumericUpDown.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.endMinuteNumericUpDown.Location = new System.Drawing.Point(252, 84);
			this.endMinuteNumericUpDown.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
			this.endMinuteNumericUpDown.Name = "endMinuteNumericUpDown";
			this.endMinuteNumericUpDown.Size = new System.Drawing.Size(50, 19);
			this.endMinuteNumericUpDown.TabIndex = 13;
			this.endMinuteNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// endHourNumericUpDown
			// 
			this.endHourNumericUpDown.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.endHourNumericUpDown.Location = new System.Drawing.Point(179, 84);
			this.endHourNumericUpDown.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
			this.endHourNumericUpDown.Name = "endHourNumericUpDown";
			this.endHourNumericUpDown.Size = new System.Drawing.Size(50, 19);
			this.endHourNumericUpDown.TabIndex = 11;
			this.endHourNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// beginMinuteNumericUpDown
			// 
			this.beginMinuteNumericUpDown.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.beginMinuteNumericUpDown.Location = new System.Drawing.Point(94, 84);
			this.beginMinuteNumericUpDown.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
			this.beginMinuteNumericUpDown.Name = "beginMinuteNumericUpDown";
			this.beginMinuteNumericUpDown.Size = new System.Drawing.Size(50, 19);
			this.beginMinuteNumericUpDown.TabIndex = 9;
			this.beginMinuteNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// beginHourNumericUpDown
			// 
			this.beginHourNumericUpDown.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.beginHourNumericUpDown.Location = new System.Drawing.Point(21, 84);
			this.beginHourNumericUpDown.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
			this.beginHourNumericUpDown.Name = "beginHourNumericUpDown";
			this.beginHourNumericUpDown.Size = new System.Drawing.Size(50, 19);
			this.beginHourNumericUpDown.TabIndex = 7;
			this.beginHourNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.label5.Location = new System.Drawing.Point(235, 86);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(11, 12);
			this.label5.TabIndex = 12;
			this.label5.Text = "：";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.label4.Location = new System.Drawing.Point(77, 86);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(11, 12);
			this.label4.TabIndex = 8;
			this.label4.Text = "：";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.label6.Location = new System.Drawing.Point(150, 86);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(23, 12);
			this.label6.TabIndex = 10;
			this.label6.Text = "から";
			// 
			// OptionDialog
			// 
			this.AcceptButton = this.okButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.cancelButton;
			this.ClientSize = new System.Drawing.Size(314, 166);
			this.Controls.Add(this.endMinuteNumericUpDown);
			this.Controls.Add(this.enableTimeCheckBox);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.beginHourNumericUpDown);
			this.Controls.Add(this.okButton);
			this.Controls.Add(this.endHourNumericUpDown);
			this.Controls.Add(this.folderButton);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.logFolderTextBox);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.activateCheckBox);
			this.Controls.Add(this.beginMinuteNumericUpDown);
			this.Controls.Add(this.intervalUpDown);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "OptionDialog";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "WorkRec 設定";
			this.Shown += new System.EventHandler(this.OptionDialog_Shown);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OptionDialog_FormClosed);
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OptionDialog_FormClosing);
			((System.ComponentModel.ISupportInitialize)(this.intervalUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.endMinuteNumericUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.endHourNumericUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.beginMinuteNumericUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.beginHourNumericUpDown)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.NumericUpDown intervalUpDown;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.CheckBox activateCheckBox;
		private System.Windows.Forms.TextBox logFolderTextBox;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button folderButton;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
		private System.Windows.Forms.Button okButton;
		private System.Windows.Forms.Button cancelButton;
		private System.Windows.Forms.CheckBox enableTimeCheckBox;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.NumericUpDown endMinuteNumericUpDown;
		private System.Windows.Forms.NumericUpDown endHourNumericUpDown;
		private System.Windows.Forms.NumericUpDown beginMinuteNumericUpDown;
		private System.Windows.Forms.NumericUpDown beginHourNumericUpDown;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label6;
	}
}