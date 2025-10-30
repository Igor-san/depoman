using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DepoMan.Components
{
    class NumericTextBox : TextBox
    {

        bool allowDecimal = false;
        bool allowSeparator = false;
        bool skipEvent = false;

        int decimalCount = 0;
        int separatorCount = 0;

        NumberFormatInfo numberFormatInfo;
        string decimalSeparator;
        string groupSeparator;
        string negativeSign;
        int[] groupSize;


        public NumericTextBox()
        {
            numberFormatInfo = System.Globalization.CultureInfo.CurrentCulture.NumberFormat;
            decimalSeparator = numberFormatInfo.NumberDecimalSeparator;
            groupSeparator = numberFormatInfo.NumberGroupSeparator;
            groupSize = numberFormatInfo.NumberGroupSizes;
            negativeSign = numberFormatInfo.NegativeSign;
        }

        // Restricts the entry of characters to digits (including hexadecimal), the negative sign, 
        // the decimal point, and editing keystrokes (backspace). 
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);

            string keyInput = e.KeyChar.ToString();

            if (Char.IsDigit(e.KeyChar))
            {
                UpdateText(e.KeyChar);
                e.Handled = true;
            }

            if (Char.IsSeparator(e.KeyChar))
            {
                UpdateText(e.KeyChar);
                e.Handled = true;
            }

            // Allows one decimal separator as input. 
            else if (keyInput.Equals(decimalSeparator))
            {
                if (allowDecimal)
                {
                    UpdateText(e.KeyChar);
                }
                e.Handled = true;
            }

            // Application should support a method to temporarily 
            // change input modes to allow input of decimal 
            // character on widest range of keyboards, especially 
            // 12-key keyboards (no Sym button). InputMode will reset 
            // to Numeric after next key press. 
            // Alternative method: 
            // else if (Char.IsPunctuation(e.KeyChar)) 
            else if (keyInput.Equals("*"))
            {
                if (allowDecimal && decimalCount == 0)
                {
                    ///!!! InputModeEditor.SetInputMode(this, InputMode.AlphaABC); Для смартфонов, требует Microsoft.WindowsCE.Forms
                    // Supports reset for devices  
                    // where KeyUp fires last.
                    skipEvent = true;
                }
                e.Handled = true;
            }

            // Allows separator. 
            else if (keyInput.Equals(groupSeparator))
            {
                if (allowSeparator)
                {
                    UpdateText(e.KeyChar);
                }
                e.Handled = true;
            }

            // Allows negative sign if the negative sign is the initial character. 
            else if (keyInput.Equals(negativeSign))
            {
                UpdateText(e.KeyChar);
                e.Handled = true;
            }

            else if (e.KeyChar == '\b')
            {
                // Allows Backspace key.
            }

            else if (e.KeyChar == '\r')
            {
                UpdateText(e.KeyChar);
                // Validate input when Enter key is pressed. 
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
            // Restores text box to Numeric mode if it was 
            // changed for decimal entry.
            ///!!!InputModeEditor.SetInputMode(this, InputMode.Numeric);
        }

        public bool AllowDecimal
        {
            get
            {
                return allowDecimal;
            }
            set
            {
                allowDecimal = value;
            }
        }

        public bool AllowSeparator
        {
            get
            {
                return allowSeparator;
            }
            set
            {
                allowSeparator = value;
            }
        }

        public int IntValue
        {
            get
            {
                try
                {
                    return Int32.Parse(this.Text, NumberStyles.AllowThousands | NumberStyles.AllowLeadingSign);
                }
                catch (FormatException e)
                {
                    
                    return 0;
                }
                catch (OverflowException e)
                {
  
                    return 0;
                }
            }
        }

        public decimal DecimalValue
        {
            get
            {
                try
                {
                    return Decimal.Parse(this.Text, NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands | NumberStyles.AllowLeadingSign);
                }
                catch (FormatException e)
                {
                  
                    return 0;
                }
            }
        }

        // Checks current input characters 
        // and updates control with valid characters only. 
        public void UpdateText(char newKey)
        {
            decimalCount = 0;
            separatorCount = 0;
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

            // char[] tokens = new char[] { decimalSeparator.ToCharArray()[0] }; 
            // NOTE: Supports decimalSeparator with a length == 1. 
            char token = decimalSeparator.ToCharArray()[0];
            string[] groups = input.Split(token);

            // Returning input to left of decimal. 
            char[] inputChars = groups[0].ToCharArray();
            // Reversing input to handle separators. 
            char[] rInputChars = inputChars.Reverse().ToArray();
            StringBuilder sb = new StringBuilder();

            bool validKey = false;

            for (int x = 0; x < rInputChars.Length; x++)
            {

                if (rInputChars[x].ToString().Equals(groupSeparator))
                {
                    continue;
                }

                // Checking for decimalSeparator is not required in 
                // current implementation. Current implementation eliminates 
                // all digits to the right of extraneous decimal characters. 
                if (rInputChars[x].ToString().Equals(decimalSeparator))
                {
                    if (!allowDecimal | decimalCount > 0)
                    {
                        continue;
                    }

                    //validKey = true;
                }

                if (rInputChars[x].ToString().Equals(negativeSign))
                {
                    // Ignore negativeSign unless processing first character. 
                    if (x < (rInputChars.Length - 1))
                    {
                        continue;
                    }
                    sb.Insert(0, rInputChars[x].ToString());
                    x++;
                    continue;
                }

                if (allowSeparator)
                {
                    // NOTE: Does not support multiple groupSeparator sizes. 
                    if (cSize > 0 && cSize % groupSize[0] == 0)
                    {
                        sb.Insert(0, groupSeparator);
                        separatorCount++;
                    }
                }

                // Maintaining correct group size for digits. 
                if (Char.IsDigit(rInputChars[x]))
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

            updatedText = sb.ToString();

            if (allowDecimal && groups.Length > 1)
            {
                char[] rightOfDecimals = groups[1].ToCharArray();
                StringBuilder sb2 = new StringBuilder();

                foreach (char dec in rightOfDecimals)
                {
                    if (Char.IsDigit(dec))
                    {
                        sb2.Append(dec);
                    }
                }
                updatedText += decimalSeparator + sb2.ToString();
            }
            // Updates text box. 
            this.Text = updatedText;
            // Updates cursor position. 
            this.SelectionStart = this.Text.Length;
        }
    }
}
