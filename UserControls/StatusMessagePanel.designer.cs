namespace DepoMan
{
    partial class StatusMessagePanel
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте 
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panelStatusMessage = new System.Windows.Forms.Panel();
            this.textBoxMessages = new System.Windows.Forms.RichTextBox();
            this.bottomLeftPanel = new System.Windows.Forms.Panel();
            this.logClearButton = new System.Windows.Forms.Button();
            this.panelProgressBar = new System.Windows.Forms.Panel();
            this.ProgressBar = new System.Windows.Forms.ProgressBar();
            this.stopProcessButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonCollapseStatusBar = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panelStatusMessage.SuspendLayout();
            this.bottomLeftPanel.SuspendLayout();
            this.panelProgressBar.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelStatusMessage
            // 
            this.panelStatusMessage.Controls.Add(this.textBoxMessages);
            this.panelStatusMessage.Controls.Add(this.panelProgressBar);
            this.panelStatusMessage.Controls.Add(this.bottomLeftPanel);
            this.panelStatusMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelStatusMessage.Location = new System.Drawing.Point(0, 0);
            this.panelStatusMessage.Name = "panelStatusMessage";
            this.panelStatusMessage.Size = new System.Drawing.Size(495, 75);
            this.panelStatusMessage.TabIndex = 30;
            // 
            // textBoxMessages
            // 
            this.textBoxMessages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxMessages.Location = new System.Drawing.Point(17, 20);
            this.textBoxMessages.Name = "textBoxMessages";
            this.textBoxMessages.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.textBoxMessages.Size = new System.Drawing.Size(478, 55);
            this.textBoxMessages.TabIndex = 37;
            this.textBoxMessages.Text = "";
            this.textBoxMessages.TextChanged += new System.EventHandler(this.textBoxMessages_TextChanged);
            // 
            // bottomLeftPanel
            // 
            this.bottomLeftPanel.Controls.Add(this.logClearButton);
            this.bottomLeftPanel.Controls.Add(this.panel1);
            this.bottomLeftPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.bottomLeftPanel.Location = new System.Drawing.Point(0, 0);
            this.bottomLeftPanel.Name = "bottomLeftPanel";
            this.bottomLeftPanel.Size = new System.Drawing.Size(17, 75);
            this.bottomLeftPanel.TabIndex = 13;
            // 
            // logClearButton
            // 
            this.logClearButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.logClearButton.FlatAppearance.BorderSize = 0;
            this.logClearButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logClearButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.logClearButton.Location = new System.Drawing.Point(0, 20);
            this.logClearButton.Name = "logClearButton";
            this.logClearButton.Size = new System.Drawing.Size(17, 21);
            this.logClearButton.TabIndex = 0;
            this.logClearButton.Text = "x";
            this.logClearButton.UseVisualStyleBackColor = true;
            this.logClearButton.Click += new System.EventHandler(this.logClearButton_Click);
            // 
            // panelProgressBar
            // 
            this.panelProgressBar.Controls.Add(this.ProgressBar);
            this.panelProgressBar.Controls.Add(this.stopProcessButton);
            this.panelProgressBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelProgressBar.Location = new System.Drawing.Point(17, 0);
            this.panelProgressBar.Name = "panelProgressBar";
            this.panelProgressBar.Size = new System.Drawing.Size(478, 20);
            this.panelProgressBar.TabIndex = 33;
            // 
            // ProgressBar
            // 
            this.ProgressBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProgressBar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ProgressBar.Location = new System.Drawing.Point(0, 0);
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(408, 20);
            this.ProgressBar.TabIndex = 1;
            // 
            // stopProcessButton
            // 
            this.stopProcessButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.stopProcessButton.Enabled = false;
            this.stopProcessButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.stopProcessButton.Location = new System.Drawing.Point(408, 0);
            this.stopProcessButton.Name = "stopProcessButton";
            this.stopProcessButton.Size = new System.Drawing.Size(70, 20);
            this.stopProcessButton.TabIndex = 0;
            this.stopProcessButton.Text = "Стоп";
            this.stopProcessButton.UseVisualStyleBackColor = true;
            this.stopProcessButton.Click += new System.EventHandler(this.stopProcessButton_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonCollapseStatusBar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(17, 20);
            this.panel1.TabIndex = 14;
            // 
            // buttonCollapseStatusBar
            // 
            this.buttonCollapseStatusBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonCollapseStatusBar.FlatAppearance.BorderSize = 0;
            this.buttonCollapseStatusBar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCollapseStatusBar.Image = global::DepoMan.Properties.Resources.CollapseIcon;
            this.buttonCollapseStatusBar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonCollapseStatusBar.Location = new System.Drawing.Point(0, 0);
            this.buttonCollapseStatusBar.Name = "buttonCollapseStatusBar";
            this.buttonCollapseStatusBar.Size = new System.Drawing.Size(17, 15);
            this.buttonCollapseStatusBar.TabIndex = 10;
            this.buttonCollapseStatusBar.TabStop = false;
            this.buttonCollapseStatusBar.Tag = "1";
            this.buttonCollapseStatusBar.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.buttonCollapseStatusBar.UseVisualStyleBackColor = true;
            this.buttonCollapseStatusBar.Click += new System.EventHandler(this.buttonCollapseStatusBar_Click);
            // 
            // StatusMessagePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelStatusMessage);
            this.Name = "StatusMessagePanel";
            this.Size = new System.Drawing.Size(495, 75);
            this.panelStatusMessage.ResumeLayout(false);
            this.bottomLeftPanel.ResumeLayout(false);
            this.panelProgressBar.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelStatusMessage;
        private System.Windows.Forms.Panel bottomLeftPanel;
        private System.Windows.Forms.Button logClearButton;
        private System.Windows.Forms.Panel panelProgressBar;
        private System.Windows.Forms.Button stopProcessButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonCollapseStatusBar;
        private System.Windows.Forms.ToolTip toolTip1;
        public System.Windows.Forms.ProgressBar ProgressBar;
        private System.Windows.Forms.RichTextBox textBoxMessages;
    }
}
