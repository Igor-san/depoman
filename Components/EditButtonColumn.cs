using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using DepoMan.Properties;

namespace DepoMan.Components
{
    // Create a column class to display the Save buttons.
    public class EditButtonColumn : DataGridViewButtonColumn
    {
        public EditButtonColumn()
        {
            this.CellTemplate = new EditButtonCell();
            this.Width = 22;

            this.Resizable = DataGridViewTriState.False;

        }
    }

    // Create a cell class to display the Save button cells. It is derived from the 
    // abstract class DataGridViewImageButtonCell. The only method that has to be 
    // implemented is LoadImages to load the Normal, Hot and Disabled Save images.
    public class EditButtonCell : DataGridViewImageButtonCell
    {
        public override void LoadImages()
        {

            _buttonImageNormal = Resources.edit_button_enabled;// Image..FromFile("C:\\Users\\prakt1\\Desktop\\Add.png");
            _buttonImageDisabled = Resources.edit_button_disabled;// Image.FromFile("C:\\Users\\prakt1\\Desktop\\Add.png");

        }
    }

    // An abastract class that implements the functionality of an image button
    // except for a single abstract method to load the Normal, Hot and Disabled 
    // images that represent the icon that is displayed on the button. The loading
    // of these images is done in each derived concrete class.
    public abstract class DataGridViewImageButtonCell : DataGridViewButtonCell
    {
        private bool _enabled;                // Is the button enabled
        private PushButtonState _buttonState; // What is the button state
        protected Image _buttonImageHot;      // The hot image
        protected Image _buttonImageNormal;   // The normal image
        protected Image _buttonImageDisabled; // The disabled image
        private int _buttonImageOffset;       // The amount of offset or border around the image

        protected DataGridViewImageButtonCell()
        {
            // In my project, buttons are disabled by default
            _enabled = false;
            _buttonState = PushButtonState.Normal; // PushButtonState.Disabled;

            // Changing this value affects the appearance of the image on the button.
            _buttonImageOffset = 2;

            // Call the routine to load the images specific to a column.
            LoadImages();
        }

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
                _buttonState = value ? PushButtonState.Normal : PushButtonState.Disabled;
            }
        }

        // PushButton State Property
        public PushButtonState ButtonState
        {
            get { return _buttonState; }
            set { _buttonState = value; }
        }

        // Image Property
        // Returns the correct image based on the control's state.
        public Image ButtonImage
        {
            get
            {
                switch (_buttonState)
                {
                    case PushButtonState.Disabled:
                        return _buttonImageDisabled;

                    case PushButtonState.Hot:
                        return _buttonImageHot;

                    case PushButtonState.Normal:
                        return _buttonImageNormal;

                    case PushButtonState.Pressed:
                        return _buttonImageNormal;

                    case PushButtonState.Default:
                        return _buttonImageNormal;

                    default:
                        return _buttonImageNormal;
                }
            }
        }

        protected override void Paint(Graphics graphics,
            Rectangle clipBounds, Rectangle cellBounds, int rowIndex,
            DataGridViewElementStates elementState, object value,
            object formattedValue, string errorText,
            DataGridViewCellStyle cellStyle,
            DataGridViewAdvancedBorderStyle advancedBorderStyle,
            DataGridViewPaintParts paintParts)
        {
            //base.Paint(graphics, clipBounds, cellBounds, rowIndex, elementState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts);


            // Draw the cell background, if specified.
            if ((paintParts & DataGridViewPaintParts.Background) ==
                DataGridViewPaintParts.Background)
            {
                SolidBrush cellBackground =
                    new SolidBrush(cellStyle.BackColor);
                graphics.FillRectangle(cellBackground, cellBounds);
                cellBackground.Dispose();
            }

            // Draw the cell borders, if specified.
            if ((paintParts & DataGridViewPaintParts.Border) ==
                DataGridViewPaintParts.Border)
            {
                PaintBorder(graphics, clipBounds, cellBounds, cellStyle, advancedBorderStyle);
            }


            // Calculate the area in which to draw the button.
            // Adjusting the following algorithm and values affects
            // how the image will appear on the button.
            Rectangle buttonArea = cellBounds;

            Rectangle buttonAdjustment =
                BorderWidths(advancedBorderStyle);

            buttonArea.X += buttonAdjustment.X;
            buttonArea.Y += buttonAdjustment.Y;
            buttonArea.Height -= buttonAdjustment.Height;
            buttonArea.Width -= buttonAdjustment.Width;

            /*
            Rectangle imageArea = new Rectangle(
                buttonArea.X + _buttonImageOffset,
                buttonArea.Y + _buttonImageOffset,
                16,
                16);

            ButtonRenderer.DrawButton(graphics, buttonArea, ButtonImage, imageArea, false, ButtonState); Это рисует с бордюром
            */
            _buttonImageOffset = 4;
            Rectangle imageArea = new Rectangle(
                buttonArea.X + _buttonImageOffset,
                buttonArea.Y + _buttonImageOffset,
                14,
                14);

            graphics.DrawImage(ButtonImage, imageArea); //Рисуем без бордюра

        }

        // An abstract method that must be created in each derived class.
        // The images in the derived class will be loaded here.
        public abstract void LoadImages();
    }
}
