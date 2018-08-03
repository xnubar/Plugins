using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;

namespace Plugins
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static List<Assembly> assemblies;
        public App()
        {
            DirectoryInfo di = new DirectoryInfo("MyPlugins");
            var dll = di.GetFiles();
            assemblies  = new List<Assembly>();
            foreach (var item in dll)
            {
                assemblies.Add(Assembly.LoadFile(item.FullName));
            }
        }
  
    }
}



