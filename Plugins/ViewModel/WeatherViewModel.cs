using Plugins.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Plugins.ViewModel
{
    public class WeatherViewModel:ViewModel
    {
        public static dynamic WeatherInfo { get; set; }
        public WeatherViewModel(MainViewModel main)
        {
           
            BackToMenu = new RelayCommand(new Action<object>(LoadMenu));
            NextGo += main.MainWindowView_NextGo;
        }
        public event EventHandler NextGo;
        public RelayCommand BackToMenu { get; set; }
        private void LoadMenu(object obj)
        {
            NextGo(Model.ViewType.Options, new EventArgs());
        }
    }
}
