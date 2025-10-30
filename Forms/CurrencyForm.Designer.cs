namespace DepoMan.Forms
{
    partial class CurrencyForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CurrencyForm));
            this.buttonOpenOkv = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.buttonCurrencySelect = new System.Windows.Forms.Button();
            this.groupBoxLike = new System.Windows.Forms.GroupBox();
            this.buttonClearFilter = new System.Windows.Forms.Button();
            this.buttonLikeFind = new System.Windows.Forms.Button();
            this.textBoxLikeFind = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.toolStripMenu = new System.Windows.Forms.ToolStrip();
            this.toolStripCloseButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripNewButton = new System.Windows.Forms.ToolStripButton();
            this.dataGridViewMyCurrency = new DepoMan.MyDataGridView();
            this.dataGridViewExtCurrency = new DepoMan.MyDataGridView();
            this.ExtCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExtSymbol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExtName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExtCountry = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusMessagePanel = new DepoMan.StatusMessagePanel();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MyDelete = new DepoMan.Components.DeleteTextColumn();
            this.MyEdit = new DepoMan.Components.EditButtonColumn();
            this.MyIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MyCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MySymbol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MyCountry = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBoxLike.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolStripMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMyCurrency)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewExtCurrency)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonOpenOkv
            // 
            this.buttonOpenOkv.Location = new System.Drawing.Point(5, 195);
            this.buttonOpenOkv.Name = "buttonOpenOkv";
            this.buttonOpenOkv.Size = new System.Drawing.Size(103, 23);
            this.buttonOpenOkv.TabIndex = 72;
            this.buttonOpenOkv.Text = "Открыть ОКВ";
            this.toolTip1.SetToolTip(this.buttonOpenOkv, "Открыть общероссийский классификатор валют");
            this.buttonOpenOkv.UseVisualStyleBackColor = true;
            this.buttonOpenOkv.Click += new System.EventHandler(this.buttonImport_Click);
            // 
            // buttonCurrencySelect
            // 
            this.buttonCurrencySelect.Location = new System.Drawing.Point(486, 194);
            this.buttonCurrencySelect.Name = "buttonCurrencySelect";
            this.buttonCurrencySelect.Size = new System.Drawing.Size(90, 23);
            this.buttonCurrencySelect.TabIndex = 73;
            this.buttonCurrencySelect.Text = "В мой список";
            this.buttonCurrencySelect.UseVisualStyleBackColor = true;
            this.buttonCurrencySelect.Click += new System.EventHandler(this.buttonCurrencySelect_Click);
            // 
            // groupBoxLike
            // 
            this.groupBoxLike.Controls.Add(this.buttonClearFilter);
            this.groupBoxLike.Controls.Add(this.buttonLikeFind);
            this.groupBoxLike.Controls.Add(this.textBoxLikeFind);
            this.groupBoxLike.Location = new System.Drawing.Point(114, 186);
            this.groupBoxLike.Name = "groupBoxLike";
            this.groupBoxLike.Size = new System.Drawing.Size(334, 37);
            this.groupBoxLike.TabIndex = 74;
            this.groupBoxLike.TabStop = false;
            this.groupBoxLike.Text = "Похожее наименование:";
            // 
            // buttonClearFilter
            // 
            this.buttonClearFilter.Location = new System.Drawing.Point(291, 12);
            this.buttonClearFilter.Name = "buttonClearFilter";
            this.buttonClearFilter.Size = new System.Drawing.Size(35, 23);
            this.buttonClearFilter.TabIndex = 65;
            this.buttonClearFilter.Text = "X";
            this.buttonClearFilter.UseVisualStyleBackColor = true;
            this.buttonClearFilter.Click += new System.EventHandler(this.buttonClearFilter_Click);
            // 
            // buttonLikeFind
            // 
            this.buttonLikeFind.Location = new System.Drawing.Point(210, 12);
            this.buttonLikeFind.Name = "buttonLikeFind";
            this.buttonLikeFind.Size = new System.Drawing.Size(75, 23);
            this.buttonLikeFind.TabIndex = 63;
            this.buttonLikeFind.Text = "Найти";
            this.buttonLikeFind.UseVisualStyleBackColor = true;
            this.buttonLikeFind.Click += new System.EventHandler(this.buttonLikeFind_Click);
            // 
            // textBoxLikeFind
            // 
            this.textBoxLikeFind.AcceptsTab = true;
            this.textBoxLikeFind.Location = new System.Drawing.Point(6, 15);
            this.textBoxLikeFind.Name = "textBoxLikeFind";
            this.textBoxLikeFind.Size = new System.Drawing.Size(198, 20);
            this.textBoxLikeFind.TabIndex = 64;
            this.textBoxLikeFind.Text = "Рубль";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dataGridViewMyCurrency);
            this.splitContainer1.Panel1.Controls.Add(this.groupBoxLike);
            this.splitContainer1.Panel1.Controls.Add(this.buttonOpenOkv);
            this.splitContainer1.Panel1.Controls.Add(this.buttonCurrencySelect);
            this.splitContainer1.Panel1.Controls.Add(this.toolStripMenu);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridViewExtCurrency);
            this.splitContainer1.Size = new System.Drawing.Size(689, 428);
            this.splitContainer1.SplitterDistance = 224;
            this.splitContainer1.TabIndex = 75;
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
            this.toolStripMenu.Size = new System.Drawing.Size(689, 25);
            this.toolStripMenu.TabIndex = 76;
            this.toolStripMenu.Text = "toolStrip1";
            this.toolStripMenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStripMenu_ItemClicked);
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
            // dataGridViewMyCurrency
            // 
            this.dataGridViewMyCurrency.AllowUserToAddRows = false;
            this.dataGridViewMyCurrency.AllowUserToDeleteRows = false;
            this.dataGridViewMyCurrency.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMyCurrency.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MyDelete,
            this.MyEdit,
            this.MyIndex,
            this.MyCode,
            this.MySymbol,
            this.Rate,
            this.MyName,
            this.MyCountry});
            this.dataGridViewMyCurrency.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridViewMyCurrency.Location = new System.Drawing.Point(0, 25);
            this.dataGridViewMyCurrency.MultiSelect = false;
            this.dataGridViewMyCurrency.Name = "dataGridViewMyCurrency";
            this.dataGridViewMyCurrency.ReadOnly = true;
            this.dataGridViewMyCurrency.RowHeadersVisible = false;
            this.dataGridViewMyCurrency.Size = new System.Drawing.Size(689, 155);
            this.dataGridViewMyCurrency.TabIndex = 70;
            this.dataGridViewMyCurrency.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewMyCurrency_CellClick);
            this.dataGridViewMyCurrency.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataGridViewMyCurrency_CellPainting);
            // 
            // dataGridViewExtCurrency
            // 
            this.dataGridViewExtCurrency.AllowUserToAddRows = false;
            this.dataGridViewExtCurrency.AllowUserToDeleteRows = false;
            this.dataGridViewExtCurrency.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewExtCurrency.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ExtCode,
            this.ExtSymbol,
            this.ExtName,
            this.ExtCountry});
            this.dataGridViewExtCurrency.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewExtCurrency.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewExtCurrency.MultiSelect = false;
            this.dataGridViewExtCurrency.Name = "dataGridViewExtCurrency";
            this.dataGridViewExtCurrency.ReadOnly = true;
            this.dataGridViewExtCurrency.RowHeadersVisible = false;
            this.dataGridViewExtCurrency.Size = new System.Drawing.Size(689, 200);
            this.dataGridViewExtCurrency.TabIndex = 71;
            this.dataGridViewExtCurrency.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewExtCurrency_CellDoubleClick);
            // 
            // ExtCode
            // 
            this.ExtCode.DataPropertyName = "Code";
            this.ExtCode.HeaderText = "Код";
            this.ExtCode.Name = "ExtCode";
            this.ExtCode.ReadOnly = true;
            this.ExtCode.Width = 50;
            // 
            // ExtSymbol
            // 
            this.ExtSymbol.DataPropertyName = "symbol";
            this.ExtSymbol.HeaderText = "Символ";
            this.ExtSymbol.Name = "ExtSymbol";
            this.ExtSymbol.ReadOnly = true;
            this.ExtSymbol.Width = 60;
            // 
            // ExtName
            // 
            this.ExtName.DataPropertyName = "name";
            this.ExtName.HeaderText = "Наименование";
            this.ExtName.Name = "ExtName";
            this.ExtName.ReadOnly = true;
            this.ExtName.ToolTipText = "Полное наименование";
            this.ExtName.Width = 230;
            // 
            // ExtCountry
            // 
            this.ExtCountry.DataPropertyName = "country";
            this.ExtCountry.HeaderText = "Страна";
            this.ExtCountry.Name = "ExtCountry";
            this.ExtCountry.ReadOnly = true;
            this.ExtCountry.Width = 280;
            // 
            // statusMessagePanel
            // 
            this.statusMessagePanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.statusMessagePanel.Location = new System.Drawing.Point(0, 428);
            this.statusMessagePanel.Name = "statusMessagePanel";
            this.statusMessagePanel.ProgressVisible = true;
            this.statusMessagePanel.Size = new System.Drawing.Size(689, 77);
            this.statusMessagePanel.TabIndex = 4;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "id";
            this.dataGridViewTextBoxColumn1.HeaderText = "Индекс";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 50;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "symbol";
            this.dataGridViewTextBoxColumn2.HeaderText = "Символ";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 60;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "name";
            this.dataGridViewTextBoxColumn3.HeaderText = "Наименование";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.ToolTipText = "Полное наименование";
            this.dataGridViewTextBoxColumn3.Width = 200;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "country";
            this.dataGridViewTextBoxColumn4.HeaderText = "Страна";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.ToolTipText = "Полное наименование";
            this.dataGridViewTextBoxColumn4.Width = 200;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "country";
            this.dataGridViewTextBoxColumn5.HeaderText = "";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 25;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "id";
            this.dataGridViewTextBoxColumn6.HeaderText = "Индекс";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 50;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "symbol";
            this.dataGridViewTextBoxColumn7.HeaderText = "Символ";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 60;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "name";
            this.dataGridViewTextBoxColumn8.HeaderText = "Наименование";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.ToolTipText = "Полное наименование";
            this.dataGridViewTextBoxColumn8.Width = 200;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "country";
            this.dataGridViewTextBoxColumn9.HeaderText = "Страна";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Width = 200;
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
            this.MyEdit.HeaderText = "Р";
            this.MyEdit.Name = "MyEdit";
            this.MyEdit.ReadOnly = true;
            this.MyEdit.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.MyEdit.ToolTipText = "Редактировать валюту";
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
            // MyCode
            // 
            this.MyCode.DataPropertyName = "code";
            this.MyCode.HeaderText = "Код";
            this.MyCode.Name = "MyCode";
            this.MyCode.ReadOnly = true;
            this.MyCode.Width = 50;
            // 
            // MySymbol
            // 
            this.MySymbol.DataPropertyName = "symbol";
            this.MySymbol.HeaderText = "Символ";
            this.MySymbol.Name = "MySymbol";
            this.MySymbol.ReadOnly = true;
            this.MySymbol.Width = 60;
            // 
            // Rate
            // 
            this.Rate.DataPropertyName = "rate";
            this.Rate.HeaderText = "Курс";
            this.Rate.Name = "Rate";
            this.Rate.ReadOnly = true;
            this.Rate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Rate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Rate.ToolTipText = "Курс валюты к основной валюте";
            this.Rate.Width = 50;
            // 
            // MyName
            // 
            this.MyName.DataPropertyName = "name";
            this.MyName.HeaderText = "Наименование";
            this.MyName.Name = "MyName";
            this.MyName.ReadOnly = true;
            this.MyName.ToolTipText = "Полное наименование";
            this.MyName.Width = 200;
            // 
            // MyCountry
            // 
            this.MyCountry.DataPropertyName = "country";
            this.MyCountry.HeaderText = "Страна";
            this.MyCountry.Name = "MyCountry";
            this.MyCountry.ReadOnly = true;
            this.MyCountry.Width = 220;
            // 
            // CurrencyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(689, 505);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusMessagePanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CurrencyForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Валюты";
            this.Load += new System.EventHandler(this.CurrencyForm_Load);
            this.groupBoxLike.ResumeLayout(false);
            this.groupBoxLike.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.toolStripMenu.ResumeLayout(false);
            this.toolStripMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMyCurrency)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewExtCurrency)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private StatusMessagePanel statusMessagePanel;
        private MyDataGridView dataGridViewMyCurrency;
        private MyDataGridView dataGridViewExtCurrency;
        private System.Windows.Forms.Button buttonOpenOkv;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button buttonCurrencySelect;
        private System.Windows.Forms.GroupBox groupBoxLike;
        private System.Windows.Forms.Button buttonClearFilter;
        private System.Windows.Forms.Button buttonLikeFind;
        private System.Windows.Forms.TextBox textBoxLikeFind;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExtCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExtSymbol;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExtName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExtCountry;
        private System.Windows.Forms.ToolStrip toolStripMenu;
        private System.Windows.Forms.ToolStripButton toolStripCloseButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripNewButton;
        private Components.DeleteTextColumn MyDelete;
        private Components.EditButtonColumn MyEdit;
        private System.Windows.Forms.DataGridViewTextBoxColumn MyIndex;
        private System.Windows.Forms.DataGridViewTextBoxColumn MyCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn MySymbol;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rate;
        private System.Windows.Forms.DataGridViewTextBoxColumn MyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn MyCountry;
    }
}