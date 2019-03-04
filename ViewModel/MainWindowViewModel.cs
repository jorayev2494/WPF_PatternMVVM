using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF_MVVM.Model;

namespace WPF_MVVM.ViewModel 
{
    class MainWindowViewModel : INotifyPropertyChanged
    {

        #region Создание Моделя Article

        private Article article;

        public MainWindowViewModel()
        {
            this.article = new Article();

            this.Title = "My First WPF MVVM";
            this.Author = "Yakub Jorayev";
            this.Price = Convert.ToInt32(100);
        }

        // Взаимодействие с свойством Моделя Article и его свойтсвами Title
        public string Title
        {
            get
            {
                return this.article.Title;   
            }
            set
            {
                if (this.article.Title != value)
                {
                    this.article.Title = value;
                    this.OnPropertyChanged("Title");
                }
            }
        }

        // Взаимодействие с свойством Моделя Article и его свойтсвами Author
        public string Author
        {
            get
            {
                return this.article.Author;
            }
            set
            {
                if (this.article.Author != value)
                {
                    this.article.Author = value;
                    this.OnPropertyChanged("Author");
                }
            }
        }

        // Взаимодействие с свойством Моделя Article и его свойтсвами Price
        public int Price
        {
            get
            {
                return this.article.Price;
            }
            set
            {
                if (this.article.Price != value)
                {
                    this.article.Price = value;
                    this.OnPropertyChanged("Price");
                }
            }
        }

        #endregion

        #region Реализация Property

        private int click;

        public int Click
        {
            get { return this.click; }
            set
            {
                this.click = value;
                this.OnPropertyChanged("Click");
            }
        }

        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propName = "")
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        #region 

        //public MainWindowViewModel()
        //{
        //    Task.Factory.StartNew(() =>
        //    {
        //        while (true)
        //        {
        //            Task.Delay(1000).Wait();

        //            this.Click++;
        //        }
        //    });
        //}

        #endregion

        #region Реализация Команды

        public ICommand ClickAdd
        {
            get
            {
                return new Command.DelegateCommand((obj) =>
                {
                    this.Click++;
                });
            }
        }

        #endregion


    }
}
