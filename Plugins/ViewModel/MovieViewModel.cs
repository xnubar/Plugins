using Plugins.Tools;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Plugins.ViewModel
{
    public class MovieViewModel : ViewModel
    {
        public static dynamic Movie;
        private ObservableCollection<dynamic> movies;
        public ObservableCollection<dynamic> Movies
        {
            get
            {
                return movies;
            }
            set
            {
                movies = value;
                NotifyPropertyChanged(nameof(Movies));
            }
        }
        public MovieViewModel(MainViewModel main)
        {
            Movies=new ObservableCollection<dynamic>();
            Movies.Add(Movie);
            BackToMenu = new RelayCommand(new Action<object>(LoadMenu));
            NextGo += main.MainWindowView_NextGo;
        }
        public RelayCommand BackToMenu { get; set; }
        private void LoadMenu(object obj)
        {
            NextGo(Model.ViewType.Options, new EventArgs());
        }
        public event EventHandler NextGo;
    }
}
