using KiwiPoker.Services;
using Ninject;
using Ninject.Modules;
using System;
using System.Reflection;
using System.Windows.Forms;

namespace KiwiPoker.WinForms
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //nInject will take care of all dependencies now
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            kernel.Load(new INinjectModule[]
        {
                new NinjectServicesModule()
        });
            var GameService = kernel.Get<IGameService>();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1(GameService));
        }
    }
}
