using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DepoMan.Components
{
    class LetterTextBox : TextBox
    {
        bool skipEvent = false;

        /// <summary>
        /// Принимать только латинские буквы
        /// </summary>
        public bool OnlyLatin
        { get; set; }

        public LetterTextBox()
        {
     
        }

        // Checks current input characters 
        // and updates control with valid characters only. 
        public void UpdateText(char newKey)
        {


           
            string input;

     
            if (this.SelectionLength == 0)
            {
                input = this.Text.Insert(this.SelectionStart, newKey.ToString()); //Так вставяляет, но если выделили буквы, то не на их место, а просто сдвигает
            }
            else
            {
                input = this.Text.Remove(this.SelectionStart, this.SelectionLength); //удалим выделеные символы
                input = input.Insert(this.SelectionStart, newKey.ToString()); //вставим в новую строку
            }

            if (input.Length > this.MaxLength)
                input = input.Remove(this.MaxLength); //Заодно и избавимся от лишних символов

            string updatedText = "";
            int cSize = 0;

            char[] inputChars = input.ToCharArray();

            // Reversing input to handle separators. Нужно ли это?
            char[] rInputChars = inputChars.Reverse().ToArray();

            StringBuilder sb = new StringBuilder();

            bool validKey = false;

            for (int x = 0; x < rInputChars.Length; x++)
            {


               // Maintaining correct group size for digits. 
                if (Char.IsLetter(rInputChars[x]))
                {
                    // Increment cSize only after processing groupSeparators.
                    cSize++;
                    validKey = true;
                }

                if (validKey)
                {
                    sb.Insert(0, rInputChars[x].ToString());
                }

                validKey = false;
            }

            updatedText = sb.ToString().ToUpper();

            // Updates text box. 
            this.Text = updatedText;
            // Updates cursor position. 
            this.SelectionStart = this.Text.Length;
            
        }

        // Restricts the entry of characters to digits (including hexadecimal), the negative sign, 
        // the decimal point, and editing keystrokes (backspace). 
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);

            string keyInput = e.KeyChar.ToString();

            if (OnlyLatin)
            {
                if (Regex.Match(keyInput, @"[a-zA-Z]").Success)
                {
                    UpdateText(e.KeyChar);
                    e.Handled = true;
                }
            }
            else if (Char.IsLetter(e.KeyChar))
            {
                UpdateText(e.KeyChar);
                e.Handled = true;
            }

            if (e.KeyChar == '\b')
            {
                // Allows Backspace key.
            }

            else if (e.KeyChar == '\r')
            {
                UpdateText(e.KeyChar);
                ///// Validate input when Enter key is pressed. 
                // Take other action.
            }

            else
            {
                // Consume this invalid key and beep.
                e.Handled = true;
                // MessageBeep();
            }

        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            // InputModeEditor.SetInputMode(this, InputMode.Numeric);
        }
        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);

            if (skipEvent)
            {
                skipEvent = false;
                return;
            }
        
        }
    }
}
