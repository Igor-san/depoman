using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DepoMan
{
    /// <summary>
    /// Тип информационного сообщения.
    /// </summary>
    public enum MessagesTypes
    {
        Info, //Просто информация, подключились, на сервере столько-то ордеров, новых ордеров нет. Может не отображаться, если задано
        Attention, //Важная информация, например, новый ордер
        Warning, //Внимание!
        Error, //Ошибка
        Success //Порядок
    }

    public partial class StatusMessagePanel : UserControl
    {
        private int _PanelBottomHeight;
        private bool _StopProcess;

        public delegate void EventHandler(Object sender, EventArgs e);
        public event EventHandler StopButtonClick;
  
        /// <summary>
        /// Скрыть/показать Прогресс бар
        /// </summary>
        public bool ProgressVisible
        {
            get{return panelProgressBar.Visible;}
            set { panelProgressBar.Visible = value; }
        }

        public bool StopProcess
        {
            get
            {
                return _StopProcess;
            }
        }

        public StatusMessagePanel()
        {
            InitializeComponent();

            _PanelBottomHeight = this.Height;
            buttonCollapseStatusBar.Tag = 1;
        }

        public void StartProcess(bool value, int Maximum)
        {
            _StopProcess = false;
            if (value)
            {

                stopProcessButton.Enabled = true;
                stopProcessButton.Focus();
                ProgressBar.Value = 0;
                ProgressBar.Step = 1;
                //ProgressBar.Step = Maximum / 100;
                ProgressBar.Maximum = Maximum;
            }
            else
            {
                stopProcessButton.Enabled = false;
                ProgressBar.Value = 0;

            }

        }

        /// <summary>
        /// Вывод сообщения в окно
        /// </summary>
        /// <param name="text">текст сообщения</param>
        public void StatusMessage(string text)
        {
            StatusMessage(text, false);
        }

        /// <summary>
        /// Очистка окна сообщения
        /// </summary>
        public void StatusClear() 
        {
            textBoxMessages.Clear();
        }

        /// <summary>
        /// Выводим сообщение в окно лога
        /// </summary>
        /// <param name="text">сообщение</param>
        /// <param name="inStart">true- сообщение в начало лога,false -в конец</param>
        public void StatusMessage(string text, bool inStart)
        {
            if (textBoxMessages == null) return; //иногда при закрытии программы это еще вызывается и вылетает 

            if (inStart)
                textBoxMessages.Text = text + Environment.NewLine + textBoxMessages.Text;
            else
            {

                textBoxMessages.AppendText(text + Environment.NewLine);
            }

        }

        public void StatusMessage(string msg, MessagesTypes type)
        {
            System.Drawing.FontStyle newFontStyle;
            string symbol = "";
            switch (type)
            {
                case MessagesTypes.Info:
                    //if (!checkBoxShowInfoMessages.Checked) return; //не показываем информационные сообщения
                    symbol = "";
                    //notifyIconMain.BalloonTipIcon = ToolTipIcon.None;
                    break;
                case MessagesTypes.Attention: symbol = "! "; //Важная инфа к вниманию
                    newFontStyle = FontStyle.Bold;
                    textBoxMessages.SelectionFont = new Font(
                            textBoxMessages.Font.FontFamily,
                            textBoxMessages.Font.Size,
                            newFontStyle
                         );
                    textBoxMessages.SelectionColor = Color.Green;
                    textBoxMessages.SelectedText = symbol;
                    //notifyIconMain.BalloonTipIcon = ToolTipIcon.Info;
                    break;

                case MessagesTypes.Warning: symbol = "!! "; //Предупреждение
                    newFontStyle = FontStyle.Bold;
                    textBoxMessages.SelectionFont = new Font(
                            textBoxMessages.Font.FontFamily,
                            textBoxMessages.Font.Size,
                            newFontStyle
                         );

                    textBoxMessages.SelectionColor = Color.LightPink;
                    textBoxMessages.SelectedText = symbol;
                    //notifyIconMain.BalloonTipIcon = ToolTipIcon.Warning;
                    break;
                case MessagesTypes.Error: symbol = "!!! "; //Ошибка
                    newFontStyle = FontStyle.Bold;
                    textBoxMessages.SelectionFont = new Font(
                           textBoxMessages.Font.FontFamily,
                           textBoxMessages.Font.Size,
                           newFontStyle
                        );
                    textBoxMessages.SelectionColor = Color.Red;
                    textBoxMessages.SelectedText = symbol;
                    //notifyIconMain.BalloonTipIcon = ToolTipIcon.Error;
                    break;
            }

            newFontStyle = FontStyle.Regular;
            textBoxMessages.SelectionFont = new Font(
                    textBoxMessages.Font.FontFamily,
                    textBoxMessages.Font.Size,
                    newFontStyle
                 );
            string time = DateTime.Now.ToString();
            textBoxMessages.SelectionColor = Color.Blue; //выбираем цвет отображения
            textBoxMessages.SelectedText = time + ": "; //задаем выделения текста и выводим его


            textBoxMessages.SelectionColor = Color.Black;
            textBoxMessages.AppendText(msg + Environment.NewLine);
   
        }

        private void logClearButton_Click(object sender, EventArgs e)
        {
            textBoxMessages.Clear();
            //textBoxMessages.Rtf = "";
        }

        private void stopProcessButton_Click(object sender, EventArgs e)
        {
            _StopProcess = true;
            stopProcessButton.Enabled = false;
            if (StopButtonClick!=null)
                 StopButtonClick.Invoke(sender, e);
        }

        /// <summary>
        /// Развернуть окно сообщений
        /// </summary>
        public void UnHidePanel()
        {
            if (Convert.ToInt16(buttonCollapseStatusBar.Tag) == 1) //Уже развернут
            {
                return;

            }
            else
            {
                this.Height = _PanelBottomHeight;
                buttonCollapseStatusBar.Image = global::DepoMan.Properties.Resources.CollapseIcon;
                toolTip1.SetToolTip(this.buttonCollapseStatusBar, "Свернуть окно сообщений");
                buttonCollapseStatusBar.Tag = 1;

            }
        }
        /// <summary>
        /// Свернуть окно сообщений
        /// </summary>
        public void HidePanel()
        {
            if (Convert.ToInt16(buttonCollapseStatusBar.Tag) == 0) //Уже свернут
            {
                return;

            }
            else
            {
                this.Height = panelProgressBar.Height;
                buttonCollapseStatusBar.Image = global::DepoMan.Properties.Resources.ExpandIcon;
                buttonCollapseStatusBar.Tag = 0;
                toolTip1.SetToolTip(this.buttonCollapseStatusBar, "Развернуть окно сообщений");

            }
        }

        private void buttonCollapseStatusBar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt16(buttonCollapseStatusBar.Tag) == 1) //Развернут, надо свернуть
            {

                this.Height = panelProgressBar.Height;
                buttonCollapseStatusBar.Image = global::DepoMan.Properties.Resources.ExpandIcon;
                buttonCollapseStatusBar.Tag = 0;
                toolTip1.SetToolTip(this.buttonCollapseStatusBar, "Развернуть окно сообщений");

            }
            else //надо развернуть
            {
                this.Height = _PanelBottomHeight;
                buttonCollapseStatusBar.Image = global::DepoMan.Properties.Resources.CollapseIcon;
                toolTip1.SetToolTip(this.buttonCollapseStatusBar, "Свернуть окно сообщений");
                buttonCollapseStatusBar.Tag = 1;
            }

            panelProgressBar.Focus(); //чтобы не было обведена кнопка buttonCollapseStatusBar
            this.Parent.Refresh(); //чтобы не оставалось следов от панели panelBottom
        }

        private void textBoxMessages_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
