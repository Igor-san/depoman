using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using DepoMan.Classes;

namespace DepoMan
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();

            //this.Text = String.Format("{0}", AssemblyTitle);
            this.labelProductName.Text = AssemblyProduct;
            this.textBoxVersion.Text = String.Format("Version {0}", AssemblyVersion.ToString()) + " (" + DecodeDate(AssemblyVersion) + ")";
            this.labelCompanyName.Text = AssemblyCopyright;
            this.textBoxDescription.Text = AssemblyDescription;
            this.linkLabel1.Links[0].LinkData = "www.homesoft.ru";
            this.linkLabel1.Text = "www.homesoft.ru";
        }

   
        #region Assembly Attribute Accessors

        public string AssemblyTitle
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public Version AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version;
            }
        }


        public string AssemblyDescription
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        public string AssemblyProduct
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        public string AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        public string AssemblyCompany
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }
        #endregion
        

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Determine which link was clicked within the LinkLabel.
            //this.linkLabel1.Links[linkLabel1.Links.IndexOf(e.Link)].Visited = true;

            // Display the appropriate link based on the value of the 
            // LinkData property of the Link object.
            string target = e.Link.LinkData as string;

            // If the value looks like a URL, navigate to it.
            // Otherwise, display it in a message box.
            if (null != target && target.StartsWith("www"))
            {
                System.Diagnostics.Process.Start(target);
            }
            else
            {
                //MessageBox.Show("Item clicked: " + target);
            }
        }


        private string DecodeDate(Version version)
        {
            var buildDateTime = new DateTime(2000, 1, 1).Add(new TimeSpan(
    TimeSpan.TicksPerDay * version.Build));// + // days since 1 January 2000
    //TimeSpan.TicksPerSecond * 2 * version.Revision)); // seconds since midnight, (multiply by 2 to get original)
            return buildDateTime.ToShortDateString();
        }

        private void AboutForm_Load(object sender, EventArgs e)
        {
            textBoxUserDataPath.Text=Common.UserAppDataPath;
            textBoxAppDataPath.Text = Common.ProgramDataPath;

            tabControl1.DrawMode = TabDrawMode.OwnerDrawFixed;
            //tabControl1.Appearance = TabAppearance.Buttons;
            tabControl1.ItemSize = new System.Drawing.Size(0, 1);
            tabControl1.SizeMode = TabSizeMode.Fixed;
            tabControl1.TabStop = false;
            

            string prtb="";
            if (Common.Portable) prtb="Есть право записи в инсталляцию";
            labelPortable.Text = prtb;
        }

        private void ToggleTabs()
        {
            if (tabControl1.SelectedTab != tabPageInfo)
            {
                tabControl1.SelectedTab = tabPageInfo;
                toolStripToggleButton.ToolTipText="Информация о программе";
                //toolTip1.SetToolTip((toolStripToggleButton as Control), "Информация о программе");
            }
            else
            {
                tabControl1.SelectedTab = tabPageAbout;
                toolStripToggleButton.ToolTipText="Информация о путях к файлам";
                //toolTip1.SetToolTip(toolStripToggleButton, "Информация о путях к файлам");
            }
        }

        private void toolStripMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem == toolStripCloseButton)
            {
                Close();
            }
            else if (e.ClickedItem == toolStripToggleButton)
            {
                ToggleTabs();
            }
        }
    

    }
}
