namespace DepoMan.Forms
{
    partial class OptionsForm
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
            if (disposing && (components != null))
            {
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionsForm));
            this.bottomPanel = new System.Windows.Forms.Panel();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOkClose = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageCommon = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDownOffsetInterestPayment = new System.Windows.Forms.NumericUpDown();
            this.checkBoxMinimizeInsteadClose = new System.Windows.Forms.CheckBox();
            this.checkBoxMinimizeOnStart = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDownRemindPriorEndDeposit = new System.Windows.Forms.NumericUpDown();
            this.checkBoxRemindPriorEndDeposit = new System.Windows.Forms.CheckBox();
            this.checkBoxAutoStartProgram = new System.Windows.Forms.CheckBox();
            this.checkBoxAutoSaveDataBaseOnClose = new System.Windows.Forms.CheckBox();
            this.checkBoxAutoLoadLastDataBase = new System.Windows.Forms.CheckBox();
            this.tabPageCurrency = new System.Windows.Forms.TabPage();
            this.comboBoxBaseCurrency = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.checkBoxRemindInterestPayment = new System.Windows.Forms.CheckBox();
            this.bottomPanel.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPageCommon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOffsetInterestPayment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRemindPriorEndDeposit)).BeginInit();
            this.tabPageCurrency.SuspendLayout();
            this.SuspendLayout();
            // 
            // bottomPanel
            // 
            this.bottomPanel.Controls.Add(this.buttonCancel);
            this.bottomPanel.Controls.Add(this.buttonOkClose);
            this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomPanel.Location = new System.Drawing.Point(0, 211);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Size = new System.Drawing.Size(361, 33);
            this.bottomPanel.TabIndex = 14;
            // 
            // buttonCancel
            // 
            this.buttonCancel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonCancel.Location = new System.Drawing.Point(13, 6);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "Отменить";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOkClose
            // 
            this.buttonOkClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonOkClose.Location = new System.Drawing.Point(274, 6);
            this.buttonOkClose.Name = "buttonOkClose";
            this.buttonOkClose.Size = new System.Drawing.Size(75, 23);
            this.buttonOkClose.TabIndex = 1;
            this.buttonOkClose.Text = "Сохранить";
            this.buttonOkClose.UseVisualStyleBackColor = true;
            this.buttonOkClose.Click += new System.EventHandler(this.buttonOkClose_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageCommon);
            this.tabControl1.Controls.Add(this.tabPageCurrency);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(361, 211);
            this.tabControl1.TabIndex = 15;
            // 
            // tabPageCommon
            // 
            this.tabPageCommon.Controls.Add(this.checkBoxRemindInterestPayment);
            this.tabPageCommon.Controls.Add(this.label4);
            this.tabPageCommon.Controls.Add(this.numericUpDownOffsetInterestPayment);
            this.tabPageCommon.Controls.Add(this.checkBoxMinimizeInsteadClose);
            this.tabPageCommon.Controls.Add(this.checkBoxMinimizeOnStart);
            this.tabPageCommon.Controls.Add(this.label1);
            this.tabPageCommon.Controls.Add(this.numericUpDownRemindPriorEndDeposit);
            this.tabPageCommon.Controls.Add(this.checkBoxRemindPriorEndDeposit);
            this.tabPageCommon.Controls.Add(this.checkBoxAutoStartProgram);
            this.tabPageCommon.Controls.Add(this.checkBoxAutoSaveDataBaseOnClose);
            this.tabPageCommon.Controls.Add(this.checkBoxAutoLoadLastDataBase);
            this.tabPageCommon.Location = new System.Drawing.Point(4, 22);
            this.tabPageCommon.Name = "tabPageCommon";
            this.tabPageCommon.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCommon.Size = new System.Drawing.Size(353, 185);
            this.tabPageCommon.TabIndex = 0;
            this.tabPageCommon.Text = "Основные";
            this.tabPageCommon.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(182, 160);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(150, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "дней до выплаты процентов";
            // 
            // numericUpDownOffsetInterestPayment
            // 
            this.numericUpDownOffsetInterestPayment.Location = new System.Drawing.Point(118, 158);
            this.numericUpDownOffsetInterestPayment.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.numericUpDownOffsetInterestPayment.Name = "numericUpDownOffsetInterestPayment";
            this.numericUpDownOffsetInterestPayment.Size = new System.Drawing.Size(58, 20);
            this.numericUpDownOffsetInterestPayment.TabIndex = 21;
            // 
            // checkBoxMinimizeInsteadClose
            // 
            this.checkBoxMinimizeInsteadClose.AutoSize = true;
            this.checkBoxMinimizeInsteadClose.Location = new System.Drawing.Point(8, 106);
            this.checkBoxMinimizeInsteadClose.Name = "checkBoxMinimizeInsteadClose";
            this.checkBoxMinimizeInsteadClose.Size = new System.Drawing.Size(183, 17);
            this.checkBoxMinimizeInsteadClose.TabIndex = 19;
            this.checkBoxMinimizeInsteadClose.Text = "Сворачивать вместо закрытия";
            this.toolTip1.SetToolTip(this.checkBoxMinimizeInsteadClose, "Сворачивать программу вместо её закрытия при нажатии на правый верхний красный кр" +
        "ест");
            this.checkBoxMinimizeInsteadClose.UseVisualStyleBackColor = true;
            // 
            // checkBoxMinimizeOnStart
            // 
            this.checkBoxMinimizeOnStart.AutoSize = true;
            this.checkBoxMinimizeOnStart.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.checkBoxMinimizeOnStart.Location = new System.Drawing.Point(8, 81);
            this.checkBoxMinimizeOnStart.Name = "checkBoxMinimizeOnStart";
            this.checkBoxMinimizeOnStart.Size = new System.Drawing.Size(172, 17);
            this.checkBoxMinimizeOnStart.TabIndex = 18;
            this.checkBoxMinimizeOnStart.Text = "Запускать в свернутом виде";
            this.toolTip1.SetToolTip(this.checkBoxMinimizeOnStart, "при старте программа сворачивается в трей");
            this.checkBoxMinimizeOnStart.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(182, 133);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "дней до окончания вклада";
            // 
            // numericUpDownRemindPriorEndDeposit
            // 
            this.numericUpDownRemindPriorEndDeposit.Location = new System.Drawing.Point(118, 129);
            this.numericUpDownRemindPriorEndDeposit.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.numericUpDownRemindPriorEndDeposit.Name = "numericUpDownRemindPriorEndDeposit";
            this.numericUpDownRemindPriorEndDeposit.Size = new System.Drawing.Size(58, 20);
            this.numericUpDownRemindPriorEndDeposit.TabIndex = 16;
            // 
            // checkBoxRemindPriorEndDeposit
            // 
            this.checkBoxRemindPriorEndDeposit.AutoSize = true;
            this.checkBoxRemindPriorEndDeposit.Location = new System.Drawing.Point(8, 131);
            this.checkBoxRemindPriorEndDeposit.Name = "checkBoxRemindPriorEndDeposit";
            this.checkBoxRemindPriorEndDeposit.Size = new System.Drawing.Size(104, 17);
            this.checkBoxRemindPriorEndDeposit.TabIndex = 15;
            this.checkBoxRemindPriorEndDeposit.Text = "Напоминать за";
            this.toolTip1.SetToolTip(this.checkBoxRemindPriorEndDeposit, "Напоминать за столько дней до окончания вклада");
            this.checkBoxRemindPriorEndDeposit.UseVisualStyleBackColor = true;
            // 
            // checkBoxAutoStartProgram
            // 
            this.checkBoxAutoStartProgram.AutoSize = true;
            this.checkBoxAutoStartProgram.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.checkBoxAutoStartProgram.Location = new System.Drawing.Point(8, 6);
            this.checkBoxAutoStartProgram.Name = "checkBoxAutoStartProgram";
            this.checkBoxAutoStartProgram.Size = new System.Drawing.Size(196, 17);
            this.checkBoxAutoStartProgram.TabIndex = 14;
            this.checkBoxAutoStartProgram.Text = "Автостарт программы с Windows";
            this.checkBoxAutoStartProgram.UseVisualStyleBackColor = true;
            // 
            // checkBoxAutoSaveDataBaseOnClose
            // 
            this.checkBoxAutoSaveDataBaseOnClose.AutoSize = true;
            this.checkBoxAutoSaveDataBaseOnClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.checkBoxAutoSaveDataBaseOnClose.Location = new System.Drawing.Point(8, 56);
            this.checkBoxAutoSaveDataBaseOnClose.Name = "checkBoxAutoSaveDataBaseOnClose";
            this.checkBoxAutoSaveDataBaseOnClose.Size = new System.Drawing.Size(276, 17);
            this.checkBoxAutoSaveDataBaseOnClose.TabIndex = 13;
            this.checkBoxAutoSaveDataBaseOnClose.Text = "Автосохранение измененной базы при закрытии";
            this.checkBoxAutoSaveDataBaseOnClose.UseVisualStyleBackColor = true;
            // 
            // checkBoxAutoLoadLastDataBase
            // 
            this.checkBoxAutoLoadLastDataBase.AutoSize = true;
            this.checkBoxAutoLoadLastDataBase.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.checkBoxAutoLoadLastDataBase.Location = new System.Drawing.Point(8, 31);
            this.checkBoxAutoLoadLastDataBase.Name = "checkBoxAutoLoadLastDataBase";
            this.checkBoxAutoLoadLastDataBase.Size = new System.Drawing.Size(182, 17);
            this.checkBoxAutoLoadLastDataBase.TabIndex = 12;
            this.checkBoxAutoLoadLastDataBase.Text = "Автозагрузка последней базы";
            this.checkBoxAutoLoadLastDataBase.UseVisualStyleBackColor = true;
            // 
            // tabPageCurrency
            // 
            this.tabPageCurrency.Controls.Add(this.comboBoxBaseCurrency);
            this.tabPageCurrency.Controls.Add(this.label2);
            this.tabPageCurrency.Location = new System.Drawing.Point(4, 22);
            this.tabPageCurrency.Name = "tabPageCurrency";
            this.tabPageCurrency.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCurrency.Size = new System.Drawing.Size(353, 185);
            this.tabPageCurrency.TabIndex = 1;
            this.tabPageCurrency.Text = "Валюта";
            this.tabPageCurrency.UseVisualStyleBackColor = true;
            // 
            // comboBoxBaseCurrency
            // 
            this.comboBoxBaseCurrency.FormattingEnabled = true;
            this.comboBoxBaseCurrency.Location = new System.Drawing.Point(117, 13);
            this.comboBoxBaseCurrency.Name = "comboBoxBaseCurrency";
            this.comboBoxBaseCurrency.Size = new System.Drawing.Size(121, 21);
            this.comboBoxBaseCurrency.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Базовая валюта:";
            this.toolTip1.SetToolTip(this.label2, "По отношению к которой считаются курсы");
            // 
            // checkBoxRemindInterestPayment
            // 
            this.checkBoxRemindInterestPayment.AutoSize = true;
            this.checkBoxRemindInterestPayment.Location = new System.Drawing.Point(8, 158);
            this.checkBoxRemindInterestPayment.Name = "checkBoxRemindInterestPayment";
            this.checkBoxRemindInterestPayment.Size = new System.Drawing.Size(104, 17);
            this.checkBoxRemindInterestPayment.TabIndex = 23;
            this.checkBoxRemindInterestPayment.Text = "Напоминать за";
            this.toolTip1.SetToolTip(this.checkBoxRemindInterestPayment, "Напоминать за столько дней до выплаты процентов");
            this.checkBoxRemindInterestPayment.UseVisualStyleBackColor = true;
            // 
            // OptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 244);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.bottomPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OptionsForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Настройки";
            this.Load += new System.EventHandler(this.OptionsForm_Load);
            this.bottomPanel.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPageCommon.ResumeLayout(false);
            this.tabPageCommon.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOffsetInterestPayment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRemindPriorEndDeposit)).EndInit();
            this.tabPageCurrency.ResumeLayout(false);
            this.tabPageCurrency.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel bottomPanel;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOkClose;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageCommon;
        private System.Windows.Forms.CheckBox checkBoxAutoSaveDataBaseOnClose;
        private System.Windows.Forms.CheckBox checkBoxAutoLoadLastDataBase;
        private System.Windows.Forms.CheckBox checkBoxAutoStartProgram;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDownRemindPriorEndDeposit;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.CheckBox checkBoxRemindPriorEndDeposit;
        private System.Windows.Forms.CheckBox checkBoxMinimizeOnStart;
        private System.Windows.Forms.CheckBox checkBoxMinimizeInsteadClose;
        private System.Windows.Forms.TabPage tabPageCurrency;
        private System.Windows.Forms.ComboBox comboBoxBaseCurrency;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDownOffsetInterestPayment;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkBoxRemindInterestPayment;
    }
}