using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KY.WinForm
{
    static class Program
    {
        public static IContainer container;
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        public static T Resove<T>() {
         return   container.Resolve<T>();
        }
    }



}
/*
 1.增加autofac依赖注入框架，其他窗口调用通过 autofac的console方式调用。
     
*/