namespace DepoMan.Forms
{
    partial class ErrorWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ErrorWindow));
            this.tbErrorMessage = new System.Windows.Forms.TextBox();
            this.buttonAppClose = new System.Windows.Forms.Button();
            this.buttonAppNotClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbErrorMessage
            // 
            resources.ApplyResources(this.tbErrorMessage, "tbErrorMessage");
            this.tbErrorMessage.Name = "tbErrorMessage";
            // 
            // buttonAppClose
            // 
            resources.ApplyResources(this.buttonAppClose, "buttonAppClose");
            this.buttonAppClose.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonAppClose.Name = "buttonAppClose";
            this.buttonAppClose.UseVisualStyleBackColor = true;
            // 
            // buttonAppNotClose
            // 
            resources.ApplyResources(this.buttonAppNotClose, "buttonAppNotClose");
            this.buttonAppNotClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonAppNotClose.Name = "buttonAppNotClose";
            this.buttonAppNotClose.UseVisualStyleBackColor = true;
            // 
            // ErrorWindow
            // 
            this.AcceptButton = this.buttonAppClose;
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonAppNotClose;
            this.Controls.Add(this.buttonAppNotClose);
            this.Controls.Add(this.buttonAppClose);
            this.Controls.Add(this.tbErrorMessage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ErrorWindow";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbErrorMessage;
        private System.Windows.Forms.Button buttonAppClose;
        private System.Windows.Forms.Button buttonAppNotClose;
    }
}