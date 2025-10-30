namespace DepoMan
{
    partial class FormMain
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

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPageDeposits = new System.Windows.Forms.TabPage();
            this.dateTimePickerNowDate = new System.Windows.Forms.DateTimePicker();
            this.checkBoxHideClosed = new System.Windows.Forms.CheckBox();
            this.checkBoxNowDate = new System.Windows.Forms.CheckBox();
            this.dataGridViewDeposits = new DepoMan.MyDataGridView();
            this.labelErrorProvider = new System.Windows.Forms.Label();
            this.panelDepositInfo = new System.Windows.Forms.Panel();
            this.labelAmountInfo = new System.Windows.Forms.Label();
            this.statusStripMain = new System.Windows.Forms.StatusStrip();
            this.statusDBLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.infoDBLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripMenu = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripNewButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripCheckDeadline = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonAmountInfo = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonCheckPercentDeadline = new System.Windows.Forms.ToolStripButton();
            this.tabPageTest = new System.Windows.Forms.TabPage();
            this.buttonDeadlineDeposits = new System.Windows.Forms.Button();
            this.buttonOverdueDepositsToText = new System.Windows.Forms.Button();
            this.textBoxTest = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.contextMenuStripTray = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.createNewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.referenceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.banksReferenceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.currencyReferenceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientsReferenceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.errorProviderDeposit = new System.Windows.Forms.ErrorProvider(this.components);
            this.notifyIconMain = new System.Windows.Forms.NotifyIcon(this.components);
            this.statusMessagePanel = new DepoMan.StatusMessagePanel();
            this.tabControlMain.SuspendLayout();
            this.tabPageDeposits.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDeposits)).BeginInit();
            this.panelDepositInfo.SuspendLayout();
            this.statusStripMain.SuspendLayout();
            this.toolStripMenu.SuspendLayout();
            this.tabPageTest.SuspendLayout();
            this.contextMenuStripTray.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderDeposit)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabPageDeposits);
            this.tabControlMain.Controls.Add(this.tabPageTest);
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.Location = new System.Drawing.Point(0, 24);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(960, 459);
            this.tabControlMain.TabIndex = 1;
            // 
            // tabPageDeposits
            // 
            this.tabPageDeposits.Controls.Add(this.dateTimePickerNowDate);
            this.tabPageDeposits.Controls.Add(this.checkBoxHideClosed);
            this.tabPageDeposits.Controls.Add(this.checkBoxNowDate);
            this.tabPageDeposits.Controls.Add(this.dataGridViewDeposits);
            this.tabPageDeposits.Controls.Add(this.labelErrorProvider);
            this.tabPageDeposits.Controls.Add(this.panelDepositInfo);
            this.tabPageDeposits.Controls.Add(this.statusStripMain);
            this.tabPageDeposits.Controls.Add(this.toolStripMenu);
            this.tabPageDeposits.Location = new System.Drawing.Point(4, 22);
            this.tabPageDeposits.Name = "tabPageDeposits";
            this.tabPageDeposits.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDeposits.Size = new System.Drawing.Size(952, 433);
            this.tabPageDeposits.TabIndex = 0;
            this.tabPageDeposits.Text = "Депозиты";
            this.tabPageDeposits.UseVisualStyleBackColor = true;
            // 
            // dateTimePickerNowDate
            // 
            this.dateTimePickerNowDate.Location = new System.Drawing.Point(343, 6);
            this.dateTimePickerNowDate.Name = "dateTimePickerNowDate";
            this.dateTimePickerNowDate.Size = new System.Drawing.Size(159, 20);
            this.dateTimePickerNowDate.TabIndex = 3;
            // 
            // checkBoxHideClosed
            // 
            this.checkBoxHideClosed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxHideClosed.AutoSize = true;
            this.checkBoxHideClosed.Checked = true;
            this.checkBoxHideClosed.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxHideClosed.Location = new System.Drawing.Point(814, 6);
            this.checkBoxHideClosed.Name = "checkBoxHideClosed";
            this.checkBoxHideClosed.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBoxHideClosed.Size = new System.Drawing.Size(130, 17);
            this.checkBoxHideClosed.TabIndex = 79;
            this.checkBoxHideClosed.Text = "Скрывать закрытые";
            this.toolTip1.SetToolTip(this.checkBoxHideClosed, "Скрывать закрытые депозиты");
            this.checkBoxHideClosed.UseVisualStyleBackColor = true;
            this.checkBoxHideClosed.CheckedChanged += new System.EventHandler(this.checkBoxHideClosed_CheckedChanged);
            // 
            // checkBoxNowDate
            // 
            this.checkBoxNowDate.AutoSize = true;
            this.checkBoxNowDate.Location = new System.Drawing.Point(166, 6);
            this.checkBoxNowDate.Name = "checkBoxNowDate";
            this.checkBoxNowDate.Size = new System.Drawing.Size(171, 17);
            this.checkBoxNowDate.TabIndex = 5;
            this.checkBoxNowDate.Text = "Считать сегодняшней датой:";
            this.checkBoxNowDate.UseVisualStyleBackColor = true;
            // 
            // dataGridViewDeposits
            // 
            this.dataGridViewDeposits.AllowUserToAddRows = false;
            this.dataGridViewDeposits.AllowUserToDeleteRows = false;
            this.dataGridViewDeposits.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDeposits.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewDeposits.Location = new System.Drawing.Point(3, 28);
            this.dataGridViewDeposits.Name = "dataGridViewDeposits";
            this.dataGridViewDeposits.Size = new System.Drawing.Size(946, 336);
            this.dataGridViewDeposits.TabIndex = 5;
            this.dataGridViewDeposits.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewDeposits_CellClick);
            this.dataGridViewDeposits.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewDeposits_CellDoubleClick);
            this.dataGridViewDeposits.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataGridViewDeposits_CellPainting);
            this.dataGridViewDeposits.CellParsing += new System.Windows.Forms.DataGridViewCellParsingEventHandler(this.dataGridViewDeposits_CellParsing);
            this.dataGridViewDeposits.CellToolTipTextNeeded += new System.Windows.Forms.DataGridViewCellToolTipTextNeededEventHandler(this.dataGridViewDeposits_CellToolTipTextNeeded);
            this.dataGridViewDeposits.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewDeposits_CellValidated);
            this.dataGridViewDeposits.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dataGridViewDeposits_CellValidating);
            this.dataGridViewDeposits.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridViewDeposits_DataError);
            // 
            // labelErrorProvider
            // 
            this.labelErrorProvider.AutoSize = true;
            this.labelErrorProvider.Location = new System.Drawing.Point(699, 258);
            this.labelErrorProvider.Name = "labelErrorProvider";
            this.labelErrorProvider.Size = new System.Drawing.Size(90, 13);
            this.labelErrorProvider.TabIndex = 11;
            this.labelErrorProvider.Text = "labelErrorProvider";
            // 
            // panelDepositInfo
            // 
            this.panelDepositInfo.Controls.Add(this.labelAmountInfo);
            this.panelDepositInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelDepositInfo.Location = new System.Drawing.Point(3, 364);
            this.panelDepositInfo.Name = "panelDepositInfo";
            this.panelDepositInfo.Size = new System.Drawing.Size(946, 41);
            this.panelDepositInfo.TabIndex = 78;
            // 
            // labelAmountInfo
            // 
            this.labelAmountInfo.AutoSize = true;
            this.labelAmountInfo.Location = new System.Drawing.Point(15, 15);
            this.labelAmountInfo.Name = "labelAmountInfo";
            this.labelAmountInfo.Size = new System.Drawing.Size(64, 13);
            this.labelAmountInfo.TabIndex = 0;
            this.labelAmountInfo.Text = "Amount Info";
            this.toolTip1.SetToolTip(this.labelAmountInfo, "Сколько всего вкладов и в какой валюте");
            // 
            // statusStripMain
            // 
            this.statusStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusDBLabel,
            this.toolStripStatusLabel1,
            this.infoDBLabel});
            this.statusStripMain.Location = new System.Drawing.Point(3, 405);
            this.statusStripMain.Name = "statusStripMain";
            this.statusStripMain.Size = new System.Drawing.Size(946, 25);
            this.statusStripMain.SizingGrip = false;
            this.statusStripMain.TabIndex = 8;
            this.statusStripMain.Text = "statusStrip1";
            // 
            // statusDBLabel
            // 
            this.statusDBLabel.Name = "statusDBLabel";
            this.statusDBLabel.Size = new System.Drawing.Size(53, 20);
            this.statusDBLabel.Text = "Закрыта";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.AutoSize = false;
            this.toolStripStatusLabel1.Enabled = false;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(10, 20);
            this.toolStripStatusLabel1.Text = "|";
            // 
            // infoDBLabel
            // 
            this.infoDBLabel.Name = "infoDBLabel";
            this.infoDBLabel.Size = new System.Drawing.Size(39, 20);
            this.infoDBLabel.Text = "Инфо";
            // 
            // toolStripMenu
            // 
            this.toolStripMenu.AutoSize = false;
            this.toolStripMenu.CanOverflow = false;
            this.toolStripMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.toolStripNewButton,
            this.toolStripSeparator2,
            this.toolStripCheckDeadline,
            this.toolStripSeparator3,
            this.toolStripButtonAmountInfo,
            this.toolStripButtonCheckPercentDeadline});
            this.toolStripMenu.Location = new System.Drawing.Point(3, 3);
            this.toolStripMenu.Name = "toolStripMenu";
            this.toolStripMenu.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.toolStripMenu.Size = new System.Drawing.Size(946, 25);
            this.toolStripMenu.TabIndex = 77;
            this.toolStripMenu.Text = "toolStrip1";
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
            this.toolStripNewButton.Click += new System.EventHandler(this.toolStripNewButton_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripCheckDeadline
            // 
            this.toolStripCheckDeadline.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripCheckDeadline.Image = ((System.Drawing.Image)(resources.GetObject("toolStripCheckDeadline.Image")));
            this.toolStripCheckDeadline.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripCheckDeadline.Name = "toolStripCheckDeadline";
            this.toolStripCheckDeadline.Size = new System.Drawing.Size(23, 22);
            this.toolStripCheckDeadline.Text = "Проверить истечение сроков";
            this.toolStripCheckDeadline.Click += new System.EventHandler(this.toolStripCheckDeadline_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonAmountInfo
            // 
            this.toolStripButtonAmountInfo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonAmountInfo.Image = global::DepoMan.Properties.Resources.coins16;
            this.toolStripButtonAmountInfo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAmountInfo.Name = "toolStripButtonAmountInfo";
            this.toolStripButtonAmountInfo.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonAmountInfo.Text = "Информация по вкладам";
            this.toolStripButtonAmountInfo.Click += new System.EventHandler(this.toolStripButtonAmountInfo_Click);
            // 
            // toolStripButtonCheckPercentDeadline
            // 
            this.toolStripButtonCheckPercentDeadline.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonCheckPercentDeadline.Image = global::DepoMan.Properties.Resources.percent16;
            this.toolStripButtonCheckPercentDeadline.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonCheckPercentDeadline.Name = "toolStripButtonCheckPercentDeadline";
            this.toolStripButtonCheckPercentDeadline.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonCheckPercentDeadline.Text = "Проверка сроков выплаты процентов";
            this.toolStripButtonCheckPercentDeadline.Click += new System.EventHandler(this.toolStripButtonCheckPercentDeadline_Click);
            // 
            // tabPageTest
            // 
            this.tabPageTest.Controls.Add(this.buttonDeadlineDeposits);
            this.tabPageTest.Controls.Add(this.buttonOverdueDepositsToText);
            this.tabPageTest.Controls.Add(this.textBoxTest);
            this.tabPageTest.Location = new System.Drawing.Point(4, 22);
            this.tabPageTest.Name = "tabPageTest";
            this.tabPageTest.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTest.Size = new System.Drawing.Size(952, 433);
            this.tabPageTest.TabIndex = 1;
            this.tabPageTest.Text = "Test";
            this.tabPageTest.UseVisualStyleBackColor = true;
            // 
            // buttonDeadlineDeposits
            // 
            this.buttonDeadlineDeposits.Location = new System.Drawing.Point(301, 120);
            this.buttonDeadlineDeposits.Name = "buttonDeadlineDeposits";
            this.buttonDeadlineDeposits.Size = new System.Drawing.Size(133, 23);
            this.buttonDeadlineDeposits.TabIndex = 2;
            this.buttonDeadlineDeposits.Text = "DeadlineDeposits";
            this.buttonDeadlineDeposits.UseVisualStyleBackColor = true;
            this.buttonDeadlineDeposits.Click += new System.EventHandler(this.buttonDeadlineDeposits_Click);
            // 
            // buttonOverdueDepositsToText
            // 
            this.buttonOverdueDepositsToText.Location = new System.Drawing.Point(301, 31);
            this.buttonOverdueDepositsToText.Name = "buttonOverdueDepositsToText";
            this.buttonOverdueDepositsToText.Size = new System.Drawing.Size(133, 23);
            this.buttonOverdueDepositsToText.TabIndex = 1;
            this.buttonOverdueDepositsToText.Text = "OverdueDeposits";
            this.buttonOverdueDepositsToText.UseVisualStyleBackColor = true;
            this.buttonOverdueDepositsToText.Click += new System.EventHandler(this.buttonOverdueDepositsToText_Click);
            // 
            // textBoxTest
            // 
            this.textBoxTest.Location = new System.Drawing.Point(8, 6);
            this.textBoxTest.Multiline = true;
            this.textBoxTest.Name = "textBoxTest";
            this.textBoxTest.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxTest.Size = new System.Drawing.Size(272, 399);
            this.textBoxTest.TabIndex = 0;
            // 
            // contextMenuStripTray
            // 
            this.contextMenuStripTray.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showToolStripMenuItem,
            this.выходToolStripMenuItem});
            this.contextMenuStripTray.Name = "contextMenuStripTray";
            this.contextMenuStripTray.Size = new System.Drawing.Size(125, 48);
            this.toolTip1.SetToolTip(this.contextMenuStripTray, "Выход из программы");
            // 
            // showToolStripMenuItem
            // 
            this.showToolStripMenuItem.Name = "showToolStripMenuItem";
            this.showToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.showToolStripMenuItem.Text = "Показать";
            this.showToolStripMenuItem.ToolTipText = "Зазвернуть программу";
            this.showToolStripMenuItem.Click += new System.EventHandler(this.showToolStripMenuItem_Click);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.ToolTipText = "Выход из программы";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.referenceToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(960, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFileToolStripMenuItem,
            this.saveFileToolStripMenuItem,
            this.toolStripMenuItem1,
            this.createNewToolStripMenuItem,
            this.toolStripMenuItem2});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.fileToolStripMenuItem.Text = "Файл";
            // 
            // openFileToolStripMenuItem
            // 
            this.openFileToolStripMenuItem.Name = "openFileToolStripMenuItem";
            this.openFileToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.openFileToolStripMenuItem.Text = "Открыть";
            this.openFileToolStripMenuItem.Click += new System.EventHandler(this.openFileToolStripMenuItem_Click);
            // 
            // saveFileToolStripMenuItem
            // 
            this.saveFileToolStripMenuItem.Name = "saveFileToolStripMenuItem";
            this.saveFileToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.saveFileToolStripMenuItem.Text = "Сохранить";
            this.saveFileToolStripMenuItem.Click += new System.EventHandler(this.saveFileToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(129, 6);
            // 
            // createNewToolStripMenuItem
            // 
            this.createNewToolStripMenuItem.Name = "createNewToolStripMenuItem";
            this.createNewToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.createNewToolStripMenuItem.Text = "Создать";
            this.createNewToolStripMenuItem.ToolTipText = "Создать новую базу данных";
            this.createNewToolStripMenuItem.Click += new System.EventHandler(this.createNewToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(129, 6);
            // 
            // referenceToolStripMenuItem
            // 
            this.referenceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.banksReferenceToolStripMenuItem,
            this.currencyReferenceToolStripMenuItem,
            this.clientsReferenceToolStripMenuItem});
            this.referenceToolStripMenuItem.Name = "referenceToolStripMenuItem";
            this.referenceToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.referenceToolStripMenuItem.Text = "Справочники";
            // 
            // banksReferenceToolStripMenuItem
            // 
            this.banksReferenceToolStripMenuItem.Name = "banksReferenceToolStripMenuItem";
            this.banksReferenceToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.banksReferenceToolStripMenuItem.Text = "Банки";
            this.banksReferenceToolStripMenuItem.Click += new System.EventHandler(this.banksReferenceToolStripMenuItem_Click);
            // 
            // currencyReferenceToolStripMenuItem
            // 
            this.currencyReferenceToolStripMenuItem.Name = "currencyReferenceToolStripMenuItem";
            this.currencyReferenceToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.currencyReferenceToolStripMenuItem.Text = "Валюты";
            this.currencyReferenceToolStripMenuItem.Click += new System.EventHandler(this.currencyReferenceToolStripMenuItem_Click);
            // 
            // clientsReferenceToolStripMenuItem
            // 
            this.clientsReferenceToolStripMenuItem.Name = "clientsReferenceToolStripMenuItem";
            this.clientsReferenceToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.clientsReferenceToolStripMenuItem.Text = "Клиенты";
            this.clientsReferenceToolStripMenuItem.Click += new System.EventHandler(this.clientsReferenceToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.optionsToolStripMenuItem.Text = "Настройки";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.aboutToolStripMenuItem.Text = "О программе";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.exitToolStripMenuItem.Text = "Выход";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // errorProviderDeposit
            // 
            this.errorProviderDeposit.ContainerControl = this;
            // 
            // notifyIconMain
            // 
            this.notifyIconMain.ContextMenuStrip = this.contextMenuStripTray;
            this.notifyIconMain.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIconMain.Icon")));
            this.notifyIconMain.Text = "Депозитный менеджер";
            this.notifyIconMain.Visible = true;
            this.notifyIconMain.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIconMain_MouseDoubleClick);
            // 
            // statusMessagePanel
            // 
            this.statusMessagePanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.statusMessagePanel.Location = new System.Drawing.Point(0, 483);
            this.statusMessagePanel.Name = "statusMessagePanel";
            this.statusMessagePanel.ProgressVisible = true;
            this.statusMessagePanel.Size = new System.Drawing.Size(960, 89);
            this.statusMessagePanel.TabIndex = 0;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 572);
            this.Controls.Add(this.tabControlMain);
            this.Controls.Add(this.statusMessagePanel);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Депозитный менеджер";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.Resize += new System.EventHandler(this.FormMain_Resize);
            this.tabControlMain.ResumeLayout(false);
            this.tabPageDeposits.ResumeLayout(false);
            this.tabPageDeposits.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDeposits)).EndInit();
            this.panelDepositInfo.ResumeLayout(false);
            this.panelDepositInfo.PerformLayout();
            this.statusStripMain.ResumeLayout(false);
            this.statusStripMain.PerformLayout();
            this.toolStripMenu.ResumeLayout(false);
            this.toolStripMenu.PerformLayout();
            this.tabPageTest.ResumeLayout(false);
            this.tabPageTest.PerformLayout();
            this.contextMenuStripTray.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderDeposit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private StatusMessagePanel statusMessagePanel;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPageDeposits;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createNewToolStripMenuItem;
        private MyDataGridView dataGridViewDeposits;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.StatusStrip statusStripMain;
        private System.Windows.Forms.ToolStripStatusLabel statusDBLabel;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        public System.Windows.Forms.ToolStripStatusLabel infoDBLabel;
        private System.Windows.Forms.ErrorProvider errorProviderDeposit;
        private System.Windows.Forms.Label labelErrorProvider;
        private System.Windows.Forms.ToolStripMenuItem referenceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem banksReferenceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem currencyReferenceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientsReferenceToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStripMenu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripNewButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripCheckDeadline;
        private System.Windows.Forms.NotifyIcon notifyIconMain;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripTray;
        private System.Windows.Forms.ToolStripMenuItem showToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.Panel panelDepositInfo;
        private System.Windows.Forms.Label labelAmountInfo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolStripButtonAmountInfo;
        private System.Windows.Forms.TabPage tabPageTest;
        private System.Windows.Forms.TextBox textBoxTest;
        private System.Windows.Forms.Button buttonOverdueDepositsToText;
        private System.Windows.Forms.Button buttonDeadlineDeposits;
        private System.Windows.Forms.CheckBox checkBoxHideClosed;
        private System.Windows.Forms.DateTimePicker dateTimePickerNowDate;
        private System.Windows.Forms.CheckBox checkBoxNowDate;
        private System.Windows.Forms.ToolStripButton toolStripButtonCheckPercentDeadline;
    }
}

