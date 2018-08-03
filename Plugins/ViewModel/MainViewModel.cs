using Plugins.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Plugins.ViewModel
{
    public class MainViewModel : ViewModel
    {   


        private ViewModel _currentViewModel;
        private ViewType _viewType;
        public ViewModel CurrentViewModel
        {
            get { return _currentViewModel; }
            set
            {
                _currentViewModel = value;
                NotifyPropertyChanged(nameof(Header));
                NotifyPropertyChanged(nameof(CurrentViewModel));
            }
        }
        public MainViewModel()
        {
            try
            {

                CurrentViewModel = new OptionsViewModel(this);
                Header = "Options";
                _viewType = Model.ViewType.Options;
                NextGo += this.MainWindowView_NextGo;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public event EventHandler NextGo;

        /// <summary>
        /// Loading pages due to View type
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void MainWindowView_NextGo(object sender, EventArgs e)
        {

            if ((sender is ViewType) == true)
            {
                if ((ViewType)sender == ViewType.Options)
                {
                    Header = "Options";
                    CurrentViewModel = new OptionsViewModel(this);
                }
                else if ((ViewType)sender == ViewType.Movie)
                {
                    Header = "Movies";
                    CurrentViewModel = new MovieViewModel(this);
                }
                else if ((ViewType)sender == ViewType.Translate)
                {
                    Header = "Translate";
                    CurrentViewModel = new TranslateViewModel(this);
                }
                else if ((ViewType)sender == ViewType.Weather)
                {
                    Header = "Weather";
                    CurrentViewModel = new WeatherViewModel(this);
                }

            }
            else
            {
                Header = "Options";
            }
        }
    }


}
