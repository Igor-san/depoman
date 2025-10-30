using System;
using System.Windows.Forms;
using System.Configuration;
using System.Collections.Generic;

namespace DepoMan.Classes
{
    /// <summary>
    /// Summary description for MRUMenuItem.
    /// </summary>
    public class MRUMenuItem : ToolStripMenuItem
    {
        string[] mru;
        int _count;
        int _maxcount;
        public string[] MRUFiles
        {
            get { return mru; }
        }

        public MRUMenuItem()
        {
            mru = new string[0];
        }


        public void InitializeFromConfig(string[] what, int maxcount)
        {

            if (what == null) return;

            this.DropDown.KeyDown += new KeyEventHandler(OnKeyDown);


            _maxcount = maxcount; //максимально возможная емкость
            mru = (string[])Array.CreateInstance(typeof(string), what.Length);
            for (int i = 0; i < what.Length; i++)
            {
               
                string nextString = what[i];
                if (nextString != null)
                {
                    mru[i] = nextString;
                    _count = mru.Length;
                    if ("" != mru[i])
                    {
                        ToolStripMenuItem mmru = new ToolStripMenuItem(mru[i], null, new EventHandler(OnMRUClick));
                        this.DropDownItems.Add(mmru);
                    }
                }
            }
        }

        public void Initialize(string[] files, int maxcount)
        {
            this.DropDown.KeyDown += new KeyEventHandler(OnKeyDown);
            _maxcount = maxcount; //максимально возможная емкость
            mru = files;
            _count = mru.Length;
            for (int i = 0; i < _count; i++)
            {
                if ("" != mru[i])
                {
                    ToolStripMenuItem mmru = new ToolStripMenuItem(mru[i], null, new EventHandler(OnMRUClick));
                    
                    this.DropDownItems.Add(mmru);
                    
                }
            }
        }
        public void FileOpened(string file)
        {

            int found =  - 1;
            for (int j = 0; j < _count; j++)
                       {
                           if (file == mru[j])
                           {
                               found = j;
                               break;
                           }
                       }

            if (found >= 0)
            {
                string tmp = mru[0];

                mru[0] = file;
                mru[found] = tmp;
            }
            else
            {

                if (_count < _maxcount)
                {
                    _count = _count + 1;
                    Array.Resize(ref mru, _count);
                    mru[_count-1] = String.Empty;//а то он равен null

                }

                for (int i = _count-1; i > 0; i--)
                {
                    
                    mru[i] = mru[i-1];
                    
                }
                if (_count == 0)
                {
                    _count = _count + 1;
                    Array.Resize(ref mru, _count);
                }
                mru[0] = file;
            }

            
            this.DropDownItems.Clear();
            for (int i = 0; i < _count; i++)
            {
                if ("" != mru[i])
                {
                    ToolStripMenuItem mmru = new ToolStripMenuItem(mru[i], null, new EventHandler(OnMRUClick));
                    this.DropDownItems.Add(mmru);
                }
            }
            if (MRUChanged != null)
            {
                MRUChanged(this, new EventArgs());
            }
        }
        /// <summary>
        /// Fired when a mru menuitem is clicked
        /// </summary>
        public event EventHandler MRUClicked;


        protected virtual void OnMRUClick(object o, EventArgs e)
        {
            if (MRUClicked != null)
            {
                MRUClicked(o, e);
            }
        }
        /// <summary>
        /// Fired when the mru is changed
        /// </summary>
        public event EventHandler MRUChanged;

  
        // Handle the KeyDown event to determine the type of character entered into the control.
        public  void OnKeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Delete)
            {
                foreach (ToolStripMenuItem item in this.DropDownItems)
                {
                    if (item.Selected)
                    {
                        this.DropDownItems.Remove(item); //Удаляем из визуального списка
                        RemoveMru(item.Text); // string[] mru; //Удаляем из массива
                        break;
                    }
                }
            }

        }

        public void RemoveMru(string value)
        {
            List<string> lst = new List<string>();

            for (int i = 0; i < mru.GetLength(0); i++)
            {
                string line=mru[i].Trim();
                if (line != "" & line != value) //заодно и от пустышек избавимся
                {
                    lst.Add(line);
                }
                
            }

            mru = lst.ToArray();
            _count = mru.GetLength(0);
        }
        
    }
}
