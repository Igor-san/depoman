using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DepoMan.Components
{
 public static class Extensions
  {
      /// <summary>
      /// Расширение для перевода дня недели на русский DaysOfWeek.ToRus
      /// </summary>
      /// <param name="day"></param>
      /// <returns></returns>
      public static string ToRus(this DayOfWeek day)
      {
          switch (day)
          {
              case DayOfWeek.Friday: return "Пятница";
              case DayOfWeek.Monday: return "Понедельник";
              case DayOfWeek.Saturday: return "Суббота";
              case DayOfWeek.Sunday: return "Воскресенье";
              case DayOfWeek.Thursday: return "Четверг";
              case DayOfWeek.Tuesday: return "Вторник";
              case DayOfWeek.Wednesday: return "Среда";
              default: throw new ArgumentOutOfRangeException("day");
          }
      }

    public static void ShowDropDown(this DateTimePicker dtPicker)
    {
      
      int x = dtPicker.Width - 10;
      int y = dtPicker.Height / 2;

      int lParam = x + y * 0x00010000;
      InteropStuff.SendMessage(dtPicker.Handle, InteropStuff.WM_LBUTTONDOWN, 1, lParam);      
      //DateTimePicker
    }
    public static void ShowDropDown(this CalendarEditingControl dtPicker)
    {
      (dtPicker as DateTimePicker).ShowDropDown();
    }
  }
}

