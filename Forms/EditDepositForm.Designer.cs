namespace DepoMan.Forms
{
    partial class EditDepositForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditDepositForm));
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.pictureBoxAmount = new System.Windows.Forms.PictureBox();
            this.pictureBoxName = new System.Windows.Forms.PictureBox();
            this.pictureBoxPercent = new System.Windows.Forms.PictureBox();
            this.pictureBoxStart = new System.Windows.Forms.PictureBox();
            this.pictureBoxEnd = new System.Windows.Forms.PictureBox();
            this.dateTimePickerStart = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerEnd = new System.Windows.Forms.DateTimePicker();
            this.pictureBoxBank = new System.Windows.Forms.PictureBox();
            this.pictureBoxCurrency = new System.Windows.Forms.PictureBox();
            this.pictureBoxClient = new System.Windows.Forms.PictureBox();
            this.comboBoxBank = new System.Windows.Forms.ComboBox();
            this.comboBoxCurrency = new System.Windows.Forms.ComboBox();
            this.comboBoxClient = new System.Windows.Forms.ComboBox();
            this.checkBoxClosed = new System.Windows.Forms.CheckBox();
            this.textBoxInterestPayment = new System.Windows.Forms.TextBox();
            this.buttonInterestPayment = new System.Windows.Forms.Button();
            this.numericTextBoxPercent = new DepoMan.Components.NumericTextBox();
            this.numericTextBoxAmount = new DepoMan.Components.NumericTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPercent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCurrency)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxClient)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonCancel.CausesValidation = false;
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(3, 233);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(100, 23);
            this.buttonCancel.TabIndex = 72;
            this.buttonCancel.Text = "Отменить";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSave.Location = new System.Drawing.Point(412, 233);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(100, 23);
            this.buttonSave.TabIndex = 71;
            this.buttonSave.Text = "Добавить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 73;
            this.label1.Text = "Название:";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(100, 6);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(404, 20);
            this.textBoxName.TabIndex = 74;
            this.textBoxName.TextChanged += new System.EventHandler(this.textBoxName_TextChanged);
            this.textBoxName.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxName_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 75;
            this.label2.Text = "Сумма:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 76;
            this.label3.Text = "Процент:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 159);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 77;
            this.label4.Text = "Начало:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 195);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 78;
            this.label5.Text = "Окончание:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(308, 42);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 80;
            this.label7.Text = "Банк:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(308, 75);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 13);
            this.label8.TabIndex = 81;
            this.label8.Text = "Валюта:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(308, 110);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 13);
            this.label9.TabIndex = 82;
            this.label9.Text = "Клиент:";
            // 
            // pictureBoxAmount
            // 
            this.pictureBoxAmount.Image = global::DepoMan.Properties.Resources.notok;
            this.pictureBoxAmount.Location = new System.Drawing.Point(4, 40);
            this.pictureBoxAmount.Name = "pictureBoxAmount";
            this.pictureBoxAmount.Size = new System.Drawing.Size(19, 17);
            this.pictureBoxAmount.TabIndex = 84;
            this.pictureBoxAmount.TabStop = false;
            // 
            // pictureBoxName
            // 
            this.pictureBoxName.Image = global::DepoMan.Properties.Resources.notok;
            this.pictureBoxName.Location = new System.Drawing.Point(4, 8);
            this.pictureBoxName.Name = "pictureBoxName";
            this.pictureBoxName.Size = new System.Drawing.Size(19, 17);
            this.pictureBoxName.TabIndex = 85;
            this.pictureBoxName.TabStop = false;
            // 
            // pictureBoxPercent
            // 
            this.pictureBoxPercent.Image = global::DepoMan.Properties.Resources.notok;
            this.pictureBoxPercent.Location = new System.Drawing.Point(4, 73);
            this.pictureBoxPercent.Name = "pictureBoxPercent";
            this.pictureBoxPercent.Size = new System.Drawing.Size(19, 17);
            this.pictureBoxPercent.TabIndex = 87;
            this.pictureBoxPercent.TabStop = false;
            // 
            // pictureBoxStart
            // 
            this.pictureBoxStart.Image = global::DepoMan.Properties.Resources.notok;
            this.pictureBoxStart.Location = new System.Drawing.Point(4, 157);
            this.pictureBoxStart.Name = "pictureBoxStart";
            this.pictureBoxStart.Size = new System.Drawing.Size(19, 17);
            this.pictureBoxStart.TabIndex = 88;
            this.pictureBoxStart.TabStop = false;
            // 
            // pictureBoxEnd
            // 
            this.pictureBoxEnd.Image = global::DepoMan.Properties.Resources.notok;
            this.pictureBoxEnd.Location = new System.Drawing.Point(4, 193);
            this.pictureBoxEnd.Name = "pictureBoxEnd";
            this.pictureBoxEnd.Size = new System.Drawing.Size(19, 17);
            this.pictureBoxEnd.TabIndex = 89;
            this.pictureBoxEnd.TabStop = false;
            // 
            // dateTimePickerStart
            // 
            this.dateTimePickerStart.Location = new System.Drawing.Point(100, 155);
            this.dateTimePickerStart.Name = "dateTimePickerStart";
            this.dateTimePickerStart.Size = new System.Drawing.Size(127, 20);
            this.dateTimePickerStart.TabIndex = 90;
            this.dateTimePickerStart.ValueChanged += new System.EventHandler(this.dateTimePickerStart_ValueChanged);
            // 
            // dateTimePickerEnd
            // 
            this.dateTimePickerEnd.Location = new System.Drawing.Point(100, 191);
            this.dateTimePickerEnd.Name = "dateTimePickerEnd";
            this.dateTimePickerEnd.Size = new System.Drawing.Size(127, 20);
            this.dateTimePickerEnd.TabIndex = 91;
            this.dateTimePickerEnd.ValueChanged += new System.EventHandler(this.dateTimePickerEnd_ValueChanged);
            // 
            // pictureBoxBank
            // 
            this.pictureBoxBank.Image = global::DepoMan.Properties.Resources.notok;
            this.pictureBoxBank.Location = new System.Drawing.Point(281, 40);
            this.pictureBoxBank.Name = "pictureBoxBank";
            this.pictureBoxBank.Size = new System.Drawing.Size(19, 17);
            this.pictureBoxBank.TabIndex = 92;
            this.pictureBoxBank.TabStop = false;
            // 
            // pictureBoxCurrency
            // 
            this.pictureBoxCurrency.Image = global::DepoMan.Properties.Resources.notok;
            this.pictureBoxCurrency.Location = new System.Drawing.Point(281, 73);
            this.pictureBoxCurrency.Name = "pictureBoxCurrency";
            this.pictureBoxCurrency.Size = new System.Drawing.Size(19, 17);
            this.pictureBoxCurrency.TabIndex = 93;
            this.pictureBoxCurrency.TabStop = false;
            // 
            // pictureBoxClient
            // 
            this.pictureBoxClient.Image = global::DepoMan.Properties.Resources.notok;
            this.pictureBoxClient.Location = new System.Drawing.Point(281, 108);
            this.pictureBoxClient.Name = "pictureBoxClient";
            this.pictureBoxClient.Size = new System.Drawing.Size(19, 17);
            this.pictureBoxClient.TabIndex = 94;
            this.pictureBoxClient.TabStop = false;
            // 
            // comboBoxBank
            // 
            this.comboBoxBank.FormattingEnabled = true;
            this.comboBoxBank.Location = new System.Drawing.Point(369, 38);
            this.comboBoxBank.Name = "comboBoxBank";
            this.comboBoxBank.Size = new System.Drawing.Size(135, 21);
            this.comboBoxBank.TabIndex = 95;
            this.comboBoxBank.SelectedIndexChanged += new System.EventHandler(this.comboBoxBank_SelectedIndexChanged);
            this.comboBoxBank.Validating += new System.ComponentModel.CancelEventHandler(this.comboBoxBank_Validating);
            // 
            // comboBoxCurrency
            // 
            this.comboBoxCurrency.FormattingEnabled = true;
            this.comboBoxCurrency.Location = new System.Drawing.Point(369, 71);
            this.comboBoxCurrency.Name = "comboBoxCurrency";
            this.comboBoxCurrency.Size = new System.Drawing.Size(135, 21);
            this.comboBoxCurrency.TabIndex = 96;
            this.comboBoxCurrency.SelectedIndexChanged += new System.EventHandler(this.comboBoxCurrency_SelectedIndexChanged);
            this.comboBoxCurrency.Validating += new System.ComponentModel.CancelEventHandler(this.comboBoxCurrency_Validating);
            // 
            // comboBoxClient
            // 
            this.comboBoxClient.FormattingEnabled = true;
            this.comboBoxClient.Location = new System.Drawing.Point(369, 106);
            this.comboBoxClient.Name = "comboBoxClient";
            this.comboBoxClient.Size = new System.Drawing.Size(135, 21);
            this.comboBoxClient.TabIndex = 97;
            this.comboBoxClient.SelectedIndexChanged += new System.EventHandler(this.comboBoxClient_SelectedIndexChanged);
            this.comboBoxClient.Validating += new System.ComponentModel.CancelEventHandler(this.comboBoxClient_Validating);
            // 
            // checkBoxClosed
            // 
            this.checkBoxClosed.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxClosed.Location = new System.Drawing.Point(308, 140);
            this.checkBoxClosed.Name = "checkBoxClosed";
            this.checkBoxClosed.Size = new System.Drawing.Size(90, 24);
            this.checkBoxClosed.TabIndex = 98;
            this.checkBoxClosed.Text = "Закрыт:";
            this.checkBoxClosed.UseVisualStyleBackColor = true;
            // 
            // textBoxInterestPayment
            // 
            this.textBoxInterestPayment.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxInterestPayment.Location = new System.Drawing.Point(100, 97);
            this.textBoxInterestPayment.Multiline = true;
            this.textBoxInterestPayment.Name = "textBoxInterestPayment";
            this.textBoxInterestPayment.ReadOnly = true;
            this.textBoxInterestPayment.Size = new System.Drawing.Size(127, 52);
            this.textBoxInterestPayment.TabIndex = 100;
            this.textBoxInterestPayment.WordWrap = false;
            // 
            // buttonInterestPayment
            // 
            this.buttonInterestPayment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonInterestPayment.Location = new System.Drawing.Point(19, 105);
            this.buttonInterestPayment.Name = "buttonInterestPayment";
            this.buttonInterestPayment.Size = new System.Drawing.Size(75, 40);
            this.buttonInterestPayment.TabIndex = 101;
            this.buttonInterestPayment.Text = "Выплата процентов:";
            this.buttonInterestPayment.UseVisualStyleBackColor = true;
            this.buttonInterestPayment.Click += new System.EventHandler(this.buttonInterestPayment_Click);
            // 
            // numericTextBoxPercent
            // 
            this.numericTextBoxPercent.AllowDecimal = true;
            this.numericTextBoxPercent.AllowSeparator = false;
            this.numericTextBoxPercent.Location = new System.Drawing.Point(100, 71);
            this.numericTextBoxPercent.Name = "numericTextBoxPercent";
            this.numericTextBoxPercent.Size = new System.Drawing.Size(127, 20);
            this.numericTextBoxPercent.TabIndex = 86;
            this.numericTextBoxPercent.TextChanged += new System.EventHandler(this.numericTextBoxPercent_TextChanged);
            this.numericTextBoxPercent.Validating += new System.ComponentModel.CancelEventHandler(this.numericTextBoxPercent_Validating);
            // 
            // numericTextBoxAmount
            // 
            this.numericTextBoxAmount.AllowDecimal = true;
            this.numericTextBoxAmount.AllowSeparator = false;
            this.numericTextBoxAmount.Location = new System.Drawing.Point(100, 38);
            this.numericTextBoxAmount.Name = "numericTextBoxAmount";
            this.numericTextBoxAmount.Size = new System.Drawing.Size(127, 20);
            this.numericTextBoxAmount.TabIndex = 83;
            this.numericTextBoxAmount.TextChanged += new System.EventHandler(this.numericTextBoxAmount_TextChanged);
            this.numericTextBoxAmount.Validating += new System.ComponentModel.CancelEventHandler(this.numericTextBoxAmount_Validating);
            // 
            // EditDepositForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(515, 258);
            this.Controls.Add(this.buttonInterestPayment);
            this.Controls.Add(this.textBoxInterestPayment);
            this.Controls.Add(this.checkBoxClosed);
            this.Controls.Add(this.comboBoxClient);
            this.Controls.Add(this.comboBoxCurrency);
            this.Controls.Add(this.comboBoxBank);
            this.Controls.Add(this.pictureBoxClient);
            this.Controls.Add(this.pictureBoxCurrency);
            this.Controls.Add(this.pictureBoxBank);
            this.Controls.Add(this.dateTimePickerEnd);
            this.Controls.Add(this.dateTimePickerStart);
            this.Controls.Add(this.pictureBoxEnd);
            this.Controls.Add(this.pictureBoxStart);
            this.Controls.Add(this.pictureBoxPercent);
            this.Controls.Add(this.numericTextBoxPercent);
            this.Controls.Add(this.pictureBoxName);
            this.Controls.Add(this.pictureBoxAmount);
            this.Controls.Add(this.numericTextBoxAmount);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditDepositForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Добавить новый депозит";
            this.Load += new System.EventHandler(this.EditDepositForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPercent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCurrency)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxClient)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.PictureBox pictureBoxAmount;
        private Components.NumericTextBox numericTextBoxAmount;
        private System.Windows.Forms.PictureBox pictureBoxName;
        private Components.NumericTextBox numericTextBoxPercent;
        private System.Windows.Forms.PictureBox pictureBoxPercent;
        private System.Windows.Forms.PictureBox pictureBoxStart;
        private System.Windows.Forms.PictureBox pictureBoxEnd;
        private System.Windows.Forms.DateTimePicker dateTimePickerStart;
        private System.Windows.Forms.DateTimePicker dateTimePickerEnd;
        private System.Windows.Forms.PictureBox pictureBoxBank;
        private System.Windows.Forms.PictureBox pictureBoxCurrency;
        private System.Windows.Forms.PictureBox pictureBoxClient;
        private System.Windows.Forms.ComboBox comboBoxBank;
        private System.Windows.Forms.ComboBox comboBoxCurrency;
        private System.Windows.Forms.ComboBox comboBoxClient;
        private System.Windows.Forms.CheckBox checkBoxClosed;
        private System.Windows.Forms.TextBox textBoxInterestPayment;
        private System.Windows.Forms.Button buttonInterestPayment;
    }
}