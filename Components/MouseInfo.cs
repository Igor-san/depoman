using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DepoMan.Components
{
    public struct MouseInfo
    {
        private int _ctrlStatus;
        private bool _left;
        private bool _middle;
        private bool _right;
        private bool _leftAndRight;

        public int ControlStatus { get { return _ctrlStatus; } }
        public bool Left { get { return _left; } }
        public bool Right { get { return _right; } }
        public bool Middle { get { return _middle; } }
        public bool LeftAndRight { get { return _leftAndRight; } }


        public MouseInfo(int ctrlStatus)
        {
            _ctrlStatus = ctrlStatus;
            _left = ((ctrlStatus & (int)MouseButtons.Left) == (int)MouseButtons.Left);
            _right = ((ctrlStatus & (int)MouseButtons.Right) == (int)MouseButtons.Right);
            _middle = ((ctrlStatus & (int)MouseButtons.Middle) == (int)MouseButtons.Middle);
            _leftAndRight = ((ctrlStatus & (int)(MouseButtons.Left | MouseButtons.Right)) == (int)(MouseButtons.Left | MouseButtons.Right));
        }
        public MouseInfo(MouseButtons btns)
            : this((int)btns)
        {
        }

        public override string ToString()
        {
            return string.Format(
              "Left: {0} | " +
              "Right: {1} | " +
              "Middle: {2} | " +
              "LeftAndRight: {3} | {4:F0}",
              BoolToString(Left), BoolToString(Right), BoolToString(Middle), BoolToString(LeftAndRight), this.ControlStatus);
        }

        private static string BoolToString(bool val)
        {
            return val ? "Yes" : "No ";
        }
    }
}
