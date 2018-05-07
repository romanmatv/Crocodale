using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Crocodale
{
    class Word
    {
        public string Text { get; set; }
        public string Category { get; set; }
        public int games { get; set; }
        public int success { get; set; }
    }
    public static class Globals
    {
        public const bool debug = true;
    }
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
