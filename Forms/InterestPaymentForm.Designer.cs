namespace DepoMan.Forms
{
    partial class InterestPaymentForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxPeriodInterestPayment = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxDayInterestPayment = new System.Windows.Forms.ComboBox();
            this.checkBoxNotification = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.bottomPanel = new System.Windows.Forms.Panel();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOkClose = new System.Windows.Forms.Button();
            this.bottomPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Период выплаты:";
            // 
            // comboBoxPeriodInterestPayment
            // 
            this.comboBoxPeriodInterestPayment.FormattingEnabled = true;
            this.comboBoxPeriodInterestPayment.Items.AddRange(new object[] {
            "Ежедневно",
            "Ежемесячно",
            "Ежеквартально",
            "Ежегодно",
            "В конце срока",
            "В начале срока"});
            this.comboBoxPeriodInterestPayment.Location = new System.Drawing.Point(114, 15);
            this.comboBoxPeriodInterestPayment.Name = "comboBoxPeriodInterestPayment";
            this.comboBoxPeriodInterestPayment.Size = new System.Drawing.Size(211, 21);
            this.comboBoxPeriodInterestPayment.TabIndex = 1;
            this.comboBoxPeriodInterestPayment.Text = "Ежемесячно";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "День выплаты:";
            // 
            // comboBoxDayInterestPayment
            // 
            this.comboBoxDayInterestPayment.FormattingEnabled = true;
            this.comboBoxDayInterestPayment.Items.AddRange(new object[] {
            "Первый день месяца",
            "Последний день месяца",
            "День открытия вклада",
            "День, следующий за открытием вклада"});
            this.comboBoxDayInterestPayment.Location = new System.Drawing.Point(114, 60);
            this.comboBoxDayInterestPayment.Name = "comboBoxDayInterestPayment";
            this.comboBoxDayInterestPayment.Size = new System.Drawing.Size(211, 21);
            this.comboBoxDayInterestPayment.TabIndex = 3;
            this.comboBoxDayInterestPayment.Text = "День открытия вклада";
            // 
            // checkBoxNotification
            // 
            this.checkBoxNotification.AutoSize = true;
            this.checkBoxNotification.Location = new System.Drawing.Point(114, 104);
            this.checkBoxNotification.Name = "checkBoxNotification";
            this.checkBoxNotification.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBoxNotification.Size = new System.Drawing.Size(15, 14);
            this.checkBoxNotification.TabIndex = 4;
            this.toolTip1.SetToolTip(this.checkBoxNotification, "Оповещение о наступлении выплаты");
            this.checkBoxNotification.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Оповещение:";
            this.toolTip1.SetToolTip(this.label3, "Оповещение о наступлении выплаты");
            // 
            // bottomPanel
            // 
            this.bottomPanel.Controls.Add(this.buttonCancel);
            this.bottomPanel.Controls.Add(this.buttonOkClose);
            this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomPanel.Location = new System.Drawing.Point(0, 143);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Size = new System.Drawing.Size(337, 33);
            this.bottomPanel.TabIndex = 15;
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
            this.buttonOkClose.Location = new System.Drawing.Point(250, 6);
            this.buttonOkClose.Name = "buttonOkClose";
            this.buttonOkClose.Size = new System.Drawing.Size(75, 23);
            this.buttonOkClose.TabIndex = 1;
            this.buttonOkClose.Text = "Сохранить";
            this.buttonOkClose.UseVisualStyleBackColor = true;
            this.buttonOkClose.Click += new System.EventHandler(this.buttonOkClose_Click);
            // 
            // InterestPaymentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 176);
            this.Controls.Add(this.bottomPanel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.checkBoxNotification);
            this.Controls.Add(this.comboBoxDayInterestPayment);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxPeriodInterestPayment);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InterestPaymentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Выплата процентов";
            this.Load += new System.EventHandler(this.InterestPaymentForm_Load);
            this.bottomPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxPeriodInterestPayment;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxDayInterestPayment;
        private System.Windows.Forms.CheckBox checkBoxNotification;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel bottomPanel;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOkClose;
    }
}