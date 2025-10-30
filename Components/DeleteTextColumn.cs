using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DepoMan.Components
{
    public sealed class DeleteTextColumn : DataGridViewColumn
    {
        public DeleteTextColumn()
        {
            this.CellTemplate =  new DeleteTextCell();
            this.Width = 22;
            this.CellTemplate.Style.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.CellTemplate.Style.ForeColor = Color.Red;
            this.Resizable = DataGridViewTriState.False;
            ReadOnly = true;

        }
    }
    public class DeleteTextCell : DataGridViewTextBoxCell
    {
        private bool _enabled=true;              // Is the button enabled
        
    
        // Button Enabled Property
        public bool Enabled
        {
            get
            {
                return _enabled;
            }

            set
            {
                _enabled = value;
            }
        }

        protected override void Paint(System.Drawing.Graphics graphics, System.Drawing.Rectangle clipBounds, System.Drawing.Rectangle cellBounds, int rowIndex, DataGridViewElementStates cellState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
        {
            formattedValue=value = "x";
            if (this.Enabled) cellStyle.ForeColor = Color.Red;
            else cellStyle.ForeColor = Color.Gray;
            base.Paint(graphics, clipBounds, cellBounds, rowIndex, cellState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts);


        }

    }
}

