using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace Fitadel
{
    internal class Program
    {
        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;

        [DllImport("user32.dll")]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);

        [STAThread]
        static void Main(string[] args)
        {
            WriteLine("Init has been called");
            WriteLine("Press a key to be used as the macro-starter, ONE THAT YOU DON'T USE.");
            WriteLine("Warning, the macro is starting on the F key. Compile from source, if you want to use another one.");

            while (true)
            {
                if (Keyboard.IsKeyDown(Key.F))
                {
                    for (int i = 0; i < 5; i++)
                    {
                        SendKeys.SendWait("E");
                        Thread.Sleep(1);
                        Point currentPosition = System.Windows.Forms.Cursor.Position;
                        mouse_event(MOUSEEVENTF_LEFTDOWN, currentPosition.X, currentPosition.Y, 0, 0);
                        Thread.Sleep(1);
                        mouse_event(MOUSEEVENTF_LEFTUP, currentPosition.X, currentPosition.Y, 0, 0);
                    }
                }

                Thread.Sleep(1);
            }
        }

        public static void WriteLine(string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("FITADEL");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("++");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("]");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(" " + message + "\n");
        }
    }
}
