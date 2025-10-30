namespace DepoMan.Forms
{
    partial class BanksForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BanksForm));
            this.SpinningProgressMain = new DepoMan.SpinningProgress.SpinningProgress();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonClearFilter = new System.Windows.Forms.Button();
            this.buttonLikeFind = new System.Windows.Forms.Button();
            this.textBoxLikeFind = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBoxRegNum = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxBankShortName = new System.Windows.Forms.ComboBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.comboBoxBik = new System.Windows.Forms.ComboBox();
            this.label23 = new System.Windows.Forms.Label();
            this.comboBoxBankFullName = new System.Windows.Forms.ComboBox();
            this.buttonBankSelect = new System.Windows.Forms.Button();
            this.buttonOpenBik = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dataGridViewMyBanks = new DepoMan.MyDataGridView();
            this.MyDelete = new DepoMan.Components.DeleteTextColumn();
            this.MyEdit = new DepoMan.Components.EditButtonColumn();
            this.MyIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MyBik = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MyRegNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewBik = new DepoMan.MyDataGridView();
            this.REGN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NEWNUM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NAMEN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NAMEP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusMessagePanel = new DepoMan.StatusMessagePanel();
            this.deleteTextColumn1 = new DepoMan.Components.DeleteTextColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStripMenu = new System.Windows.Forms.ToolStrip();
            this.toolStripCloseButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripNewButton = new System.Windows.Forms.ToolStripButton();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMyBanks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBik)).BeginInit();
            this.toolStripMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // SpinningProgressMain
            // 
            this.SpinningProgressMain.ActiveSegmentColour = System.Drawing.Color.Blue;
            this.SpinningProgressMain.AutoIncrementFrequency = 100D;
            this.SpinningProgressMain.BackColor = System.Drawing.Color.Transparent;
            this.SpinningProgressMain.InactiveSegmentColour = System.Drawing.Color.Navy;
            this.SpinningProgressMain.Location = new System.Drawing.Point(109, 169);
            this.SpinningProgressMain.Name = "SpinningProgressMain";
            this.SpinningProgressMain.Size = new System.Drawing.Size(28, 23);
            this.SpinningProgressMain.TabIndex = 71;
            this.SpinningProgressMain.TransistionSegment = 5;
            this.SpinningProgressMain.TransistionSegmentColour = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.SpinningProgressMain.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonClearFilter);
            this.groupBox2.Controls.Add(this.buttonLikeFind);
            this.groupBox2.Controls.Add(this.textBoxLikeFind);
            this.groupBox2.Location = new System.Drawing.Point(491, 141);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(377, 50);
            this.groupBox2.TabIndex = 70;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Похожее полное наименование:";
            // 
            // buttonClearFilter
            // 
            this.buttonClearFilter.Location = new System.Drawing.Point(339, 16);
            this.buttonClearFilter.Name = "buttonClearFilter";
            this.buttonClearFilter.Size = new System.Drawing.Size(35, 23);
            this.buttonClearFilter.TabIndex = 65;
            this.buttonClearFilter.Text = "X";
            this.buttonClearFilter.UseVisualStyleBackColor = true;
            this.buttonClearFilter.Click += new System.EventHandler(this.buttonClearFilter_Click);
            // 
            // buttonLikeFind
            // 
            this.buttonLikeFind.Location = new System.Drawing.Point(258, 16);
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
            this.textBoxLikeFind.Location = new System.Drawing.Point(6, 18);
            this.textBoxLikeFind.Name = "textBoxLikeFind";
            this.textBoxLikeFind.Size = new System.Drawing.Size(246, 20);
            this.textBoxLikeFind.TabIndex = 64;
            this.textBoxLikeFind.Text = "НОМОС";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBoxRegNum);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.comboBoxBankShortName);
            this.groupBox1.Controls.Add(this.label22);
            this.groupBox1.Controls.Add(this.label24);
            this.groupBox1.Controls.Add(this.comboBoxBik);
            this.groupBox1.Controls.Add(this.label23);
            this.groupBox1.Controls.Add(this.comboBoxBankFullName);
            this.groupBox1.Location = new System.Drawing.Point(491, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(379, 132);
            this.groupBox1.TabIndex = 68;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Поиск по:";
            // 
            // comboBoxRegNum
            // 
            this.comboBoxRegNum.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxRegNum.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.comboBoxRegNum.FormattingEnabled = true;
            this.comboBoxRegNum.Location = new System.Drawing.Point(120, 100);
            this.comboBoxRegNum.Name = "comboBoxRegNum";
            this.comboBoxRegNum.Size = new System.Drawing.Size(254, 21);
            this.comboBoxRegNum.TabIndex = 63;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 62;
            this.label1.Text = "Краткое название:";
            // 
            // comboBoxBankShortName
            // 
            this.comboBoxBankShortName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxBankShortName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.comboBoxBankShortName.FormattingEnabled = true;
            this.comboBoxBankShortName.Location = new System.Drawing.Point(120, 43);
            this.comboBoxBankShortName.Name = "comboBoxBankShortName";
            this.comboBoxBankShortName.Size = new System.Drawing.Size(254, 21);
            this.comboBoxBankShortName.TabIndex = 61;
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
            this.label24.Location = new System.Drawing.Point(3, 103);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(115, 13);
            this.label24.TabIndex = 60;
            this.label24.Text = "Регистрационный №:";
            // 
            // comboBoxBik
            // 
            this.comboBoxBik.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxBik.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.comboBoxBik.FormattingEnabled = true;
            this.comboBoxBik.Location = new System.Drawing.Point(120, 70);
            this.comboBoxBik.Name = "comboBoxBik";
            this.comboBoxBik.Size = new System.Drawing.Size(254, 21);
            this.comboBoxBik.TabIndex = 56;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(3, 73);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(32, 13);
            this.label23.TabIndex = 59;
            this.label23.Text = "БИК:";
            // 
            // comboBoxBankFullName
            // 
            this.comboBoxBankFullName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxBankFullName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.comboBoxBankFullName.FormattingEnabled = true;
            this.comboBoxBankFullName.Location = new System.Drawing.Point(120, 16);
            this.comboBoxBankFullName.Name = "comboBoxBankFullName";
            this.comboBoxBankFullName.Size = new System.Drawing.Size(254, 21);
            this.comboBoxBankFullName.TabIndex = 54;
            // 
            // buttonBankSelect
            // 
            this.buttonBankSelect.Location = new System.Drawing.Point(395, 169);
            this.buttonBankSelect.Name = "buttonBankSelect";
            this.buttonBankSelect.Size = new System.Drawing.Size(90, 23);
            this.buttonBankSelect.TabIndex = 67;
            this.buttonBankSelect.Text = "В мой список";
            this.buttonBankSelect.UseVisualStyleBackColor = true;
            this.buttonBankSelect.Click += new System.EventHandler(this.buttonBankSelect_Click);
            // 
            // buttonOpenBik
            // 
            this.buttonOpenBik.Location = new System.Drawing.Point(7, 168);
            this.buttonOpenBik.Name = "buttonOpenBik";
            this.buttonOpenBik.Size = new System.Drawing.Size(96, 24);
            this.buttonOpenBik.TabIndex = 66;
            this.buttonOpenBik.Text = "Открыть БИК";
            this.toolTip1.SetToolTip(this.buttonOpenBik, "Открыть полный справочник банков");
            this.buttonOpenBik.UseVisualStyleBackColor = true;
            this.buttonOpenBik.Click += new System.EventHandler(this.buttonOpenBik_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dataGridViewMyBanks);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel1.Controls.Add(this.SpinningProgressMain);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1.Controls.Add(this.buttonOpenBik);
            this.splitContainer1.Panel1.Controls.Add(this.buttonBankSelect);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridViewBik);
            this.splitContainer1.Size = new System.Drawing.Size(873, 421);
            this.splitContainer1.SplitterDistance = 197;
            this.splitContainer1.TabIndex = 72;
            // 
            // dataGridViewMyBanks
            // 
            this.dataGridViewMyBanks.AllowUserToAddRows = false;
            this.dataGridViewMyBanks.AllowUserToDeleteRows = false;
            this.dataGridViewMyBanks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMyBanks.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MyDelete,
            this.MyEdit,
            this.MyIndex,
            this.MyName,
            this.MyBik,
            this.MyRegNum});
            this.dataGridViewMyBanks.Location = new System.Drawing.Point(7, 4);
            this.dataGridViewMyBanks.MultiSelect = false;
            this.dataGridViewMyBanks.Name = "dataGridViewMyBanks";
            this.dataGridViewMyBanks.ReadOnly = true;
            this.dataGridViewMyBanks.RowHeadersVisible = false;
            this.dataGridViewMyBanks.Size = new System.Drawing.Size(478, 159);
            this.dataGridViewMyBanks.TabIndex = 69;
            this.dataGridViewMyBanks.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewMyBanks_CellClick);
            this.dataGridViewMyBanks.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataGridViewMyBanks_CellPainting);
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
            this.MyEdit.ReadOnly = true;
            this.MyEdit.Resizable = System.Windows.Forms.DataGridViewTriState.False;
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
            this.MyName.HeaderText = "Наименование";
            this.MyName.Name = "MyName";
            this.MyName.ReadOnly = true;
            this.MyName.ToolTipText = "Полное наименование";
            this.MyName.Width = 200;
            // 
            // MyBik
            // 
            this.MyBik.DataPropertyName = "bik";
            this.MyBik.HeaderText = "БИК";
            this.MyBik.Name = "MyBik";
            this.MyBik.ReadOnly = true;
            this.MyBik.Width = 75;
            // 
            // MyRegNum
            // 
            this.MyRegNum.DataPropertyName = "regn";
            this.MyRegNum.HeaderText = "Рег.№";
            this.MyRegNum.Name = "MyRegNum";
            this.MyRegNum.ReadOnly = true;
            this.MyRegNum.Width = 60;
            // 
            // dataGridViewBik
            // 
            this.dataGridViewBik.AllowUserToAddRows = false;
            this.dataGridViewBik.AllowUserToDeleteRows = false;
            this.dataGridViewBik.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewBik.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.REGN,
            this.NEWNUM,
            this.NAMEN,
            this.NAMEP});
            this.dataGridViewBik.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewBik.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewBik.Name = "dataGridViewBik";
            this.dataGridViewBik.ReadOnly = true;
            this.dataGridViewBik.Size = new System.Drawing.Size(873, 220);
            this.dataGridViewBik.TabIndex = 65;
            this.dataGridViewBik.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewBik_CellDoubleClick);
            // 
            // REGN
            // 
            this.REGN.DataPropertyName = "REGN";
            this.REGN.HeaderText = "Рег.№";
            this.REGN.Name = "REGN";
            this.REGN.ReadOnly = true;
            this.REGN.Width = 65;
            // 
            // NEWNUM
            // 
            this.NEWNUM.DataPropertyName = "bik";
            this.NEWNUM.HeaderText = "БИК";
            this.NEWNUM.Name = "NEWNUM";
            this.NEWNUM.ReadOnly = true;
            this.NEWNUM.Width = 80;
            // 
            // NAMEN
            // 
            this.NAMEN.DataPropertyName = "name";
            this.NAMEN.HeaderText = "Наименование";
            this.NAMEN.Name = "NAMEN";
            this.NAMEN.ReadOnly = true;
            this.NAMEN.ToolTipText = "Краткое наименование";
            this.NAMEN.Width = 200;
            // 
            // NAMEP
            // 
            this.NAMEP.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NAMEP.DataPropertyName = "fullname";
            this.NAMEP.HeaderText = "Полное наименование";
            this.NAMEP.Name = "NAMEP";
            this.NAMEP.ReadOnly = true;
            this.NAMEP.ToolTipText = "Полное наименование";
            // 
            // statusMessagePanel
            // 
            this.statusMessagePanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.statusMessagePanel.Location = new System.Drawing.Point(0, 446);
            this.statusMessagePanel.Name = "statusMessagePanel";
            this.statusMessagePanel.ProgressVisible = true;
            this.statusMessagePanel.Size = new System.Drawing.Size(873, 77);
            this.statusMessagePanel.TabIndex = 3;
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
            this.dataGridViewTextBoxColumn1.DataPropertyName = "REGN";
            this.dataGridViewTextBoxColumn1.HeaderText = "Рег.№";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 65;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "NEWNUM";
            this.dataGridViewTextBoxColumn2.HeaderText = "БИК";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.ToolTipText = "Полное наименование";
            this.dataGridViewTextBoxColumn2.Width = 80;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "NAMEN";
            this.dataGridViewTextBoxColumn3.HeaderText = "Наименование";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.ToolTipText = "Краткое наименование";
            this.dataGridViewTextBoxColumn3.Width = 200;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "NAMEP";
            this.dataGridViewTextBoxColumn4.HeaderText = "Полное наименование";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.ToolTipText = "Полное наименование";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "id";
            this.dataGridViewTextBoxColumn5.HeaderText = "Индекс";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 50;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "name";
            this.dataGridViewTextBoxColumn6.HeaderText = "Наименование";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.ToolTipText = "Полное наименование";
            this.dataGridViewTextBoxColumn6.Width = 200;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "bik";
            this.dataGridViewTextBoxColumn7.HeaderText = "БИК";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.ToolTipText = "Краткое наименование";
            this.dataGridViewTextBoxColumn7.Width = 75;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn8.DataPropertyName = "regn";
            this.dataGridViewTextBoxColumn8.HeaderText = "Рег.№";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.ToolTipText = "Полное наименование";
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
            this.toolStripMenu.Size = new System.Drawing.Size(873, 25);
            this.toolStripMenu.TabIndex = 77;
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
            // BanksForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 523);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusMessagePanel);
            this.Controls.Add(this.toolStripMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BanksForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Банки";
            this.Load += new System.EventHandler(this.BanksForm_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMyBanks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBik)).EndInit();
            this.toolStripMenu.ResumeLayout(false);
            this.toolStripMenu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private StatusMessagePanel statusMessagePanel;
        internal DepoMan.SpinningProgress.SpinningProgress SpinningProgressMain;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonClearFilter;
        private System.Windows.Forms.Button buttonLikeFind;
        private System.Windows.Forms.TextBox textBoxLikeFind;
        private MyDataGridView dataGridViewMyBanks;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBoxRegNum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxBankShortName;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.ComboBox comboBoxBik;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.ComboBox comboBoxBankFullName;
        private System.Windows.Forms.Button buttonBankSelect;
        private System.Windows.Forms.Button buttonOpenBik;
        private MyDataGridView dataGridViewBik;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private Components.DeleteTextColumn deleteTextColumn1;
        private Components.DeleteTextColumn MyDelete;
        private Components.EditButtonColumn MyEdit;
        private System.Windows.Forms.DataGridViewTextBoxColumn MyIndex;
        private System.Windows.Forms.DataGridViewTextBoxColumn MyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn MyBik;
        private System.Windows.Forms.DataGridViewTextBoxColumn MyRegNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn REGN;
        private System.Windows.Forms.DataGridViewTextBoxColumn NEWNUM;
        private System.Windows.Forms.DataGridViewTextBoxColumn NAMEN;
        private System.Windows.Forms.DataGridViewTextBoxColumn NAMEP;
        private System.Windows.Forms.ToolStrip toolStripMenu;
        private System.Windows.Forms.ToolStripButton toolStripCloseButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripNewButton;

    }
}