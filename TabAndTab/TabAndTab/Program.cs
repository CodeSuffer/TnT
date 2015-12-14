using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TabAndTab
{
    static class Program
    {
        /// <summary>
        /// 해당 응용 프로그램의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            args = new string[1];
            args[0] = @"C:\";
            if (args.Length == 0)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                new BrowserForm(@"C:\").Show();
                Application.Run();
            }
            else if(args.Length == 1)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                new BrowserForm(args[0]).Show();
                Application.Run();
            }
        }
    }
}
