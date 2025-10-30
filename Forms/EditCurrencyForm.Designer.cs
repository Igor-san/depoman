using DepoMan.Components;
namespace DepoMan.Forms
{
    partial class EditCurrencyForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditCurrencyForm));
            this.buttonCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBoxCode = new System.Windows.Forms.PictureBox();
            this.pictureBoxSymbol = new System.Windows.Forms.PictureBox();
            this.pictureBoxName = new System.Windows.Forms.PictureBox();
            this.pictureBoxCountry = new System.Windows.Forms.PictureBox();
            this.textBoxCurrencyName = new System.Windows.Forms.TextBox();
            this.textBoxCurrencyCode = new DepoMan.Components.NumericTextBox();
            this.textBoxCurrencySymbol = new DepoMan.Components.LetterTextBox();
            this.textBoxCurrencyCountry = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.buttonSaveCurrency = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pictureBoxCurrencyRate = new System.Windows.Forms.PictureBox();
            this.numericTextBoxCurrencyRate = new DepoMan.Components.NumericTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSymbol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCountry)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCurrencyRate)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonCancel.CausesValidation = false;
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(8, 166);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(100, 23);
            this.buttonCancel.TabIndex = 73;
            this.buttonCancel.Text = "Отменить";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pictureBoxCurrencyRate);
            this.groupBox1.Controls.Add(this.numericTextBoxCurrencyRate);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.pictureBoxCode);
            this.groupBox1.Controls.Add(this.pictureBoxSymbol);
            this.groupBox1.Controls.Add(this.pictureBoxName);
            this.groupBox1.Controls.Add(this.pictureBoxCountry);
            this.groupBox1.Controls.Add(this.textBoxCurrencyName);
            this.groupBox1.Controls.Add(this.textBoxCurrencyCode);
            this.groupBox1.Controls.Add(this.textBoxCurrencySymbol);
            this.groupBox1.Controls.Add(this.textBoxCurrencyCountry);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label22);
            this.groupBox1.Controls.Add(this.label24);
            this.groupBox1.Controls.Add(this.label23);
            this.groupBox1.Location = new System.Drawing.Point(6, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(367, 152);
            this.groupBox1.TabIndex = 72;
            this.groupBox1.TabStop = false;
            // 
            // pictureBoxCode
            // 
            this.pictureBoxCode.Image = global::DepoMan.Properties.Resources.notok;
            this.pictureBoxCode.Location = new System.Drawing.Point(340, 17);
            this.pictureBoxCode.Name = "pictureBoxCode";
            this.pictureBoxCode.Size = new System.Drawing.Size(19, 17);
            this.pictureBoxCode.TabIndex = 74;
            this.pictureBoxCode.TabStop = false;
            // 
            // pictureBoxSymbol
            // 
            this.pictureBoxSymbol.Image = global::DepoMan.Properties.Resources.notok;
            this.pictureBoxSymbol.Location = new System.Drawing.Point(340, 41);
            this.pictureBoxSymbol.Name = "pictureBoxSymbol";
            this.pictureBoxSymbol.Size = new System.Drawing.Size(19, 17);
            this.pictureBoxSymbol.TabIndex = 73;
            this.pictureBoxSymbol.TabStop = false;
            // 
            // pictureBoxName
            // 
            this.pictureBoxName.Image = global::DepoMan.Properties.Resources.notok;
            this.pictureBoxName.Location = new System.Drawing.Point(340, 67);
            this.pictureBoxName.Name = "pictureBoxName";
            this.pictureBoxName.Size = new System.Drawing.Size(19, 17);
            this.pictureBoxName.TabIndex = 72;
            this.pictureBoxName.TabStop = false;
            // 
            // pictureBoxCountry
            // 
            this.pictureBoxCountry.Image = global::DepoMan.Properties.Resources.notok;
            this.pictureBoxCountry.Location = new System.Drawing.Point(340, 93);
            this.pictureBoxCountry.Name = "pictureBoxCountry";
            this.pictureBoxCountry.Size = new System.Drawing.Size(19, 17);
            this.pictureBoxCountry.TabIndex = 71;
            this.pictureBoxCountry.TabStop = false;
            // 
            // textBoxCurrencyName
            // 
            this.textBoxCurrencyName.Location = new System.Drawing.Point(92, 67);
            this.textBoxCurrencyName.MaxLength = 100;
            this.textBoxCurrencyName.Name = "textBoxCurrencyName";
            this.textBoxCurrencyName.Size = new System.Drawing.Size(249, 20);
            this.textBoxCurrencyName.TabIndex = 70;
            this.textBoxCurrencyName.TextChanged += new System.EventHandler(this.textBoxCurrencyName_TextChanged);
            this.textBoxCurrencyName.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxCurrencyName_Validating);
            // 
            // textBoxCurrencyCode
            // 
            this.textBoxCurrencyCode.AllowDecimal = false;
            this.textBoxCurrencyCode.AllowSeparator = false;
            this.textBoxCurrencyCode.Location = new System.Drawing.Point(92, 15);
            this.textBoxCurrencyCode.Name = "textBoxCurrencyCode";
            this.textBoxCurrencyCode.Size = new System.Drawing.Size(249, 20);
            this.textBoxCurrencyCode.TabIndex = 0;
            this.textBoxCurrencyCode.TextChanged += new System.EventHandler(this.textBoxCurrencyCode_TextChanged);
            this.textBoxCurrencyCode.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxCurrencyCode_Validating);
            // 
            // textBoxCurrencySymbol
            // 
            this.textBoxCurrencySymbol.Location = new System.Drawing.Point(92, 41);
            this.textBoxCurrencySymbol.Name = "textBoxCurrencySymbol";
            this.textBoxCurrencySymbol.OnlyLatin = false;
            this.textBoxCurrencySymbol.Size = new System.Drawing.Size(249, 20);
            this.textBoxCurrencySymbol.TabIndex = 65;
            this.textBoxCurrencySymbol.TextChanged += new System.EventHandler(this.textBoxCurrencySymbol_TextChanged);
            this.textBoxCurrencySymbol.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxCurrencySymbol_Validating);
            // 
            // textBoxCurrencyCountry
            // 
            this.textBoxCurrencyCountry.Location = new System.Drawing.Point(92, 93);
            this.textBoxCurrencyCountry.MaxLength = 100;
            this.textBoxCurrencyCountry.Name = "textBoxCurrencyCountry";
            this.textBoxCurrencyCountry.Size = new System.Drawing.Size(249, 20);
            this.textBoxCurrencyCountry.TabIndex = 64;
            this.textBoxCurrencyCountry.TextChanged += new System.EventHandler(this.textBoxCurrencyCountry_TextChanged);
            this.textBoxCurrencyCountry.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxCurrencyCountry_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 62;
            this.label1.Text = "Символ:";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(3, 18);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(26, 13);
            this.label22.TabIndex = 58;
            this.label22.Text = "Код";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(3, 96);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(46, 13);
            this.label24.TabIndex = 60;
            this.label24.Text = "Страна:";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(3, 70);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(86, 13);
            this.label23.TabIndex = 59;
            this.label23.Text = "Наименование:";
            // 
            // buttonSaveCurrency
            // 
            this.buttonSaveCurrency.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSaveCurrency.Location = new System.Drawing.Point(271, 166);
            this.buttonSaveCurrency.Name = "buttonSaveCurrency";
            this.buttonSaveCurrency.Size = new System.Drawing.Size(100, 23);
            this.buttonSaveCurrency.TabIndex = 71;
            this.buttonSaveCurrency.Text = "Добавить";
            this.buttonSaveCurrency.UseVisualStyleBackColor = true;
            this.buttonSaveCurrency.Click += new System.EventHandler(this.buttonSaveCurrency_Click);
            // 
            // pictureBoxCurrencyRate
            // 
            this.pictureBoxCurrencyRate.Image = global::DepoMan.Properties.Resources.notok;
            this.pictureBoxCurrencyRate.Location = new System.Drawing.Point(341, 121);
            this.pictureBoxCurrencyRate.Name = "pictureBoxCurrencyRate";
            this.pictureBoxCurrencyRate.Size = new System.Drawing.Size(19, 17);
            this.pictureBoxCurrencyRate.TabIndex = 77;
            this.pictureBoxCurrencyRate.TabStop = false;
            // 
            // numericTextBoxCurrencyRate
            // 
            this.numericTextBoxCurrencyRate.AllowDecimal = false;
            this.numericTextBoxCurrencyRate.AllowSeparator = false;
            this.numericTextBoxCurrencyRate.Location = new System.Drawing.Point(92, 120);
            this.numericTextBoxCurrencyRate.Name = "numericTextBoxCurrencyRate";
            this.numericTextBoxCurrencyRate.Size = new System.Drawing.Size(249, 20);
            this.numericTextBoxCurrencyRate.TabIndex = 76;
            this.numericTextBoxCurrencyRate.TextChanged += new System.EventHandler(this.numericTextBoxCurrencyRate_TextChanged);
            this.numericTextBoxCurrencyRate.Validating += new System.ComponentModel.CancelEventHandler(this.numericTextBoxCurrencyRate_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 75;
            this.label2.Text = "Курс:";
            this.toolTip1.SetToolTip(this.label2, "курс валюты по отношению к базовой валюте в настройках");
            // 
            // EditCurrencyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(377, 200);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonSaveCurrency);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditCurrencyForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Добавить новую валюту";
            this.Load += new System.EventHandler(this.EditCurrencyForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSymbol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCountry)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCurrencyRate)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private NumericTextBox textBoxCurrencyCode;
        private LetterTextBox textBoxCurrencySymbol;
        private System.Windows.Forms.TextBox textBoxCurrencyCountry;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Button buttonSaveCurrency;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox textBoxCurrencyName;
        private System.Windows.Forms.PictureBox pictureBoxCode;
        private System.Windows.Forms.PictureBox pictureBoxSymbol;
        private System.Windows.Forms.PictureBox pictureBoxName;
        private System.Windows.Forms.PictureBox pictureBoxCountry;
        private System.Windows.Forms.PictureBox pictureBoxCurrencyRate;
        private NumericTextBox numericTextBoxCurrencyRate;
        private System.Windows.Forms.Label label2;
    }
}