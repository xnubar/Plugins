using Plugin;
using Plugins.Tools;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TranslatePlugin;
using WeatherPlugin;

namespace Plugins.ViewModel
{
    public class OptionsViewModel : ViewModel
    {
        private ObservableCollection<string> options;
        public ObservableCollection<string> Options
        {
            get { return options; }
            set
            {
                options = value;
                NotifyPropertyChanged(nameof(Options));
            }
        }
        private string input;
        public string Input
        {
            get { return input; }
            set
            {
                input = value;
                NotifyPropertyChanged(nameof(Input));
            }
        }

        public OptionsViewModel(MainViewModel main)
        {
            Options = new ObservableCollection<string>();
            Options.Add("Movie");
            Options.Add("Translate");
            Options.Add("Weather");
            Search = new RelayCommand(new Action<object>(SearchBtn));
            NextGo += main.MainWindowView_NextGo;
        }

        public RelayCommand Search { get; set; }
        private async void SearchBtn(object obj)
        {

            if (!String.IsNullOrEmpty(Input))
            {
                if (SelectedCommand == 0)
                {
                    var item = App.assemblies[0].GetTypes().First();

                    if (item.GetInterface("IPlugin") != null)
                    {
                        IPlugin i = Activator.CreateInstance(item) as IPlugin;
                        var data = await i.Do(Input);
                        MovieViewModel.Movie = data;
                       
                    }
                    NextGo(Model.ViewType.Movie, new EventArgs());
                }

                else if (SelectedCommand == 1)
                {
                    var item = App.assemblies[1].GetTypes().First();

                    if (item.GetInterface("IPlugin") != null)
                    {

                        IPlugin i = Activator.CreateInstance(item) as IPlugin;
                        var data = await i.Do(Input);

               
                    TranslateViewModel.TranslatedText = data.text[0];
                   
                     }
                    NextGo(Model.ViewType.Translate, new EventArgs());
                }
                else if (SelectedCommand == 2)
                {
                    var item = App.assemblies[2].GetTypes().First();

                    if (item.GetInterface("IPlugin") != null)
                    {

                        IPlugin i = Activator.CreateInstance(item) as IPlugin;
                        dynamic data = await i.Do(Input);
                        WeatherViewModel.WeatherInfo = data;                      
                    }
                    NextGo(Model.ViewType.Weather, new EventArgs());
                }
            }
            else
            {
                MessageBox.Show("You can't leave textbox empty.", "WARNING", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }
        private int selectedCommand;
        public int SelectedCommand
        {
            get { return selectedCommand; }

            set
            {
                if (!Equals(selectedCommand, value))
                {
                    selectedCommand = value;
                    NotifyPropertyChanged(nameof(SelectedCommand));
                }
            }
        }


        public event EventHandler NextGo;


    }
}
