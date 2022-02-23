using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Services.ChirngauzSquare.Services;
using Services.Infrustucture.Parametr;

namespace FunctionGraph
{
  static class Program
  {
    private static IContainer _container;
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
      RegisterTypes();
      Application.SetHighDpiMode(HighDpiMode.SystemAware);
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run(_container.Resolve<MainForm>());
    }

    private static void RegisterTypes()
    {
      var builder = new ContainerBuilder();
      builder.RegisterType<ChirngauzSquareServices>().As<IChirngauzSquareInfrastructure>();
      builder.RegisterType<MainForm>();
      _container = builder.Build();
    }

  }
}
