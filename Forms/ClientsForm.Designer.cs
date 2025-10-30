namespace DepoMan.Forms
{
    partial class ClientsForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientsForm));
            this.dataGridViewMyClients = new MyDataGridView();
            this.MyDelete = new DepoMan.Components.DeleteTextColumn();
            this.MyEdit = new DepoMan.Components.EditButtonColumn();
            this.MyIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deleteTextColumn1 = new DepoMan.Components.DeleteTextColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewButtonColumn1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolStripMenu = new System.Windows.Forms.ToolStrip();
            this.toolStripCloseButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripNewButton = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMyClients)).BeginInit();
            this.toolStripMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewMyClients
            // 
            this.dataGridViewMyClients.AllowUserToAddRows = false;
            this.dataGridViewMyClients.AllowUserToDeleteRows = false;
            this.dataGridViewMyClients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMyClients.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MyDelete,
            this.MyEdit,
            this.MyIndex,
            this.MyName});
            this.dataGridViewMyClients.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewMyClients.Location = new System.Drawing.Point(0, 25);
            this.dataGridViewMyClients.MultiSelect = false;
            this.dataGridViewMyClients.Name = "dataGridViewMyClients";
            this.dataGridViewMyClients.RowHeadersVisible = false;
            this.dataGridViewMyClients.Size = new System.Drawing.Size(429, 253);
            this.dataGridViewMyClients.TabIndex = 70;
            this.dataGridViewMyClients.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewMyClients_CellClick);
            this.dataGridViewMyClients.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataGridViewMyClients_CellPainting);
            // 
            // MyDelete
            // 
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Red;
            this.MyDelete.DefaultCellStyle = dataGridViewCellStyle1;
            this.MyDelete.Frozen = true;
            this.MyDelete.HeaderText = "Х";
            this.MyDelete.Name = "MyDelete";
            this.MyDelete.ReadOnly = true;
            this.MyDelete.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.MyDelete.ToolTipText = "Удалить из списка";
            this.MyDelete.Width = 20;
            // 
            // MyEdit
            // 
            this.MyEdit.Frozen = true;
            this.MyEdit.HeaderText = "Р";
            this.MyEdit.Name = "MyEdit";
            this.MyEdit.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.MyEdit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.MyEdit.ToolTipText = "Редактировать";
            this.MyEdit.Width = 22;
            // 
            // MyIndex
            // 
            this.MyIndex.DataPropertyName = "id";
            this.MyIndex.HeaderText = "Индекс";
            this.MyIndex.Name = "MyIndex";
            this.MyIndex.ReadOnly = true;
            this.MyIndex.Width = 50;
            // 
            // MyName
            // 
            this.MyName.DataPropertyName = "name";
            this.MyName.HeaderText = "ФИО";
            this.MyName.Name = "MyName";
            this.MyName.ToolTipText = "ФИО";
            this.MyName.Width = 300;
            // 
            // deleteTextColumn1
            // 
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Red;
            this.deleteTextColumn1.DefaultCellStyle = dataGridViewCellStyle2;
            this.deleteTextColumn1.Frozen = true;
            this.deleteTextColumn1.HeaderText = "Х";
            this.deleteTextColumn1.Name = "deleteTextColumn1";
            this.deleteTextColumn1.ReadOnly = true;
            this.deleteTextColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.deleteTextColumn1.ToolTipText = "Удалить из списка";
            this.deleteTextColumn1.Width = 20;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "id";
            this.dataGridViewTextBoxColumn1.Frozen = true;
            this.dataGridViewTextBoxColumn1.HeaderText = "Индекс";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn1.ToolTipText = "Редактировать";
            this.dataGridViewTextBoxColumn1.Width = 50;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "name";
            this.dataGridViewTextBoxColumn2.HeaderText = "ФИО";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.ToolTipText = "ФИО";
            this.dataGridViewTextBoxColumn2.Width = 300;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "name";
            this.dataGridViewTextBoxColumn3.HeaderText = "ФИО";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ToolTipText = "ФИО";
            this.dataGridViewTextBoxColumn3.Width = 300;
            // 
            // dataGridViewButtonColumn1
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Red;
            this.dataGridViewButtonColumn1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewButtonColumn1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dataGridViewButtonColumn1.Frozen = true;
            this.dataGridViewButtonColumn1.HeaderText = "Х";
            this.dataGridViewButtonColumn1.Name = "dataGridViewButtonColumn1";
            this.dataGridViewButtonColumn1.ReadOnly = true;
            this.dataGridViewButtonColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewButtonColumn1.Text = "x";
            this.dataGridViewButtonColumn1.ToolTipText = "Удалить из списка";
            this.dataGridViewButtonColumn1.UseColumnTextForButtonValue = true;
            this.dataGridViewButtonColumn1.Width = 20;
            // 
            // toolStripMenu
            // 
            this.toolStripMenu.AutoSize = false;
            this.toolStripMenu.CanOverflow = false;
            this.toolStripMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripCloseButton,
            this.toolStripSeparator1,
            this.toolStripNewButton});
            this.toolStripMenu.Location = new System.Drawing.Point(0, 0);
            this.toolStripMenu.Name = "toolStripMenu";
            this.toolStripMenu.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.toolStripMenu.Size = new System.Drawing.Size(429, 25);
            this.toolStripMenu.TabIndex = 72;
            this.toolStripMenu.Text = "toolStrip1";
            this.toolStripMenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
            // 
            // toolStripCloseButton
            // 
            this.toolStripCloseButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripCloseButton.Image = global::DepoMan.Properties.Resources.exit_red_16;
            this.toolStripCloseButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripCloseButton.Name = "toolStripCloseButton";
            this.toolStripCloseButton.Size = new System.Drawing.Size(23, 22);
            this.toolStripCloseButton.Text = "Закрыть форму";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripNewButton
            // 
            this.toolStripNewButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripNewButton.Image = global::DepoMan.Properties.Resources.add_new;
            this.toolStripNewButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripNewButton.Name = "toolStripNewButton";
            this.toolStripNewButton.Size = new System.Drawing.Size(23, 22);
            this.toolStripNewButton.Text = "Добавить новый";
            // 
            // ClientsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 278);
            this.Controls.Add(this.dataGridViewMyClients);
            this.Controls.Add(this.toolStripMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ClientsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Клиенты";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ClientsForm_FormClosing);
            this.Load += new System.EventHandler(this.ClientsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMyClients)).EndInit();
            this.toolStripMenu.ResumeLayout(false);
            this.toolStripMenu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MyDataGridView dataGridViewMyClients;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn1;
        private Components.DeleteTextColumn MyDelete;
        private Components.EditButtonColumn MyEdit;
        private System.Windows.Forms.DataGridViewTextBoxColumn MyIndex;
        private System.Windows.Forms.DataGridViewTextBoxColumn MyName;
        private Components.DeleteTextColumn deleteTextColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStrip toolStripMenu;
        private System.Windows.Forms.ToolStripButton toolStripCloseButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripNewButton;
    }
}