using DepoMan.Classes;
using DepoMan.Components;
namespace DepoMan.Forms
{
    partial class EditBankForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditBankForm));
            this.buttonSaveBank = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBoxShortName = new System.Windows.Forms.PictureBox();
            this.pictureBoxBik = new System.Windows.Forms.PictureBox();
            this.textBoxRegNum = new System.Windows.Forms.TextBox();
            this.textBoxBik = new DepoMan.Components.NumericTextBox();
            this.textBoxBankShortName = new System.Windows.Forms.TextBox();
            this.textBoxBankFullName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.buttonCancel = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxShortName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBik)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonSaveBank
            // 
            this.buttonSaveBank.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSaveBank.Location = new System.Drawing.Point(300, 141);
            this.buttonSaveBank.Name = "buttonSaveBank";
            this.buttonSaveBank.Size = new System.Drawing.Size(100, 23);
            this.buttonSaveBank.TabIndex = 0;
            this.buttonSaveBank.Text = "Добавить";
            this.buttonSaveBank.UseVisualStyleBackColor = true;
            this.buttonSaveBank.Click += new System.EventHandler(this.buttonAddNewBank_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pictureBoxShortName);
            this.groupBox1.Controls.Add(this.pictureBoxBik);
            this.groupBox1.Controls.Add(this.textBoxRegNum);
            this.groupBox1.Controls.Add(this.textBoxBik);
            this.groupBox1.Controls.Add(this.textBoxBankShortName);
            this.groupBox1.Controls.Add(this.textBoxBankFullName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label22);
            this.groupBox1.Controls.Add(this.label24);
            this.groupBox1.Controls.Add(this.label23);
            this.groupBox1.Location = new System.Drawing.Point(4, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(396, 133);
            this.groupBox1.TabIndex = 69;
            this.groupBox1.TabStop = false;
            // 
            // pictureBoxShortName
            // 
            this.pictureBoxShortName.Image = global::DepoMan.Properties.Resources.notok;
            this.pictureBoxShortName.Location = new System.Drawing.Point(371, 42);
            this.pictureBoxShortName.Name = "pictureBoxShortName";
            this.pictureBoxShortName.Size = new System.Drawing.Size(19, 17);
            this.pictureBoxShortName.TabIndex = 72;
            this.pictureBoxShortName.TabStop = false;
            // 
            // pictureBoxBik
            // 
            this.pictureBoxBik.Image = global::DepoMan.Properties.Resources.notok;
            this.pictureBoxBik.Location = new System.Drawing.Point(371, 72);
            this.pictureBoxBik.Name = "pictureBoxBik";
            this.pictureBoxBik.Size = new System.Drawing.Size(19, 17);
            this.pictureBoxBik.TabIndex = 71;
            this.pictureBoxBik.TabStop = false;
            // 
            // textBoxRegNum
            // 
            this.textBoxRegNum.Location = new System.Drawing.Point(122, 100);
            this.textBoxRegNum.Name = "textBoxRegNum";
            this.textBoxRegNum.Size = new System.Drawing.Size(249, 20);
            this.textBoxRegNum.TabIndex = 69;
            // 
            // textBoxBik
            // 
            this.textBoxBik.AllowDecimal = false;
            this.textBoxBik.AllowSeparator = false;
            this.textBoxBik.Location = new System.Drawing.Point(120, 70);
            this.textBoxBik.Name = "textBoxBik";
            this.textBoxBik.Size = new System.Drawing.Size(251, 20);
            this.textBoxBik.TabIndex = 68;
            this.textBoxBik.TextChanged += new System.EventHandler(this.textBoxBik_TextChanged);
            this.textBoxBik.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxBik_KeyDown);
            this.textBoxBik.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxBik_Validating);
            // 
            // textBoxBankShortName
            // 
            this.textBoxBankShortName.Location = new System.Drawing.Point(120, 40);
            this.textBoxBankShortName.Name = "textBoxBankShortName";
            this.textBoxBankShortName.Size = new System.Drawing.Size(251, 20);
            this.textBoxBankShortName.TabIndex = 65;
            this.textBoxBankShortName.TextChanged += new System.EventHandler(this.textBoxBankShortName_TextChanged);
            this.textBoxBankShortName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxBankShortName_KeyDown);
            this.textBoxBankShortName.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxBankShortName_Validating);
            // 
            // textBoxBankFullName
            // 
            this.textBoxBankFullName.Location = new System.Drawing.Point(120, 13);
            this.textBoxBankFullName.Name = "textBoxBankFullName";
            this.textBoxBankFullName.Size = new System.Drawing.Size(251, 20);
            this.textBoxBankFullName.TabIndex = 0;
            this.textBoxBankFullName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxBankFullName_KeyDown);
            this.textBoxBankFullName.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxBankFullName_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 62;
            this.label1.Text = "Краткое название:";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(3, 17);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(99, 13);
            this.label22.TabIndex = 58;
            this.label22.Text = "Полное название:";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(3, 104);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(115, 13);
            this.label24.TabIndex = 60;
            this.label24.Text = "Регистрационный №:";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(3, 74);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(32, 13);
            this.label23.TabIndex = 59;
            this.label23.Text = "БИК:";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonCancel.CausesValidation = false;
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(12, 141);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(100, 23);
            this.buttonCancel.TabIndex = 70;
            this.buttonCancel.Text = "Отменить";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // EditBankForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(404, 169);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonSaveBank);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditBankForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Добавить новый банк";
            this.Load += new System.EventHandler(this.NewBankForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxShortName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBik)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonSaveBank;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxBankShortName;
        private System.Windows.Forms.TextBox textBoxBankFullName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label23;
        private NumericTextBox textBoxBik;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox textBoxRegNum;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.PictureBox pictureBoxShortName;
        private System.Windows.Forms.PictureBox pictureBoxBik;
    }
}