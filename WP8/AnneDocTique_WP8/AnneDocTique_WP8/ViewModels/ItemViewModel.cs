using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace AnneDocTique_WP8.ViewModels
{
    public class ItemViewModel : INotifyPropertyChanged
    {

        private string _id;
        /// <summary>
        /// cette propriété est utilisée dans la vue pour afficher sa valeur à l'aide d'une liaison.
        /// </summary>
        public string Id
        {
            get
            {
                return _id;
            }
            set
            {
                if (value != _id)
                {
                    _id = value;
                    NotifyPropertyChanged("Id");
                }
            }
        }

        private string _content;
        public string Content
        {
            get
            {
                return _content;
            }
            set
            {
                if (value != _content)
                {
                    _content = value;
                    NotifyPropertyChanged("Content");
                }
            }
        }

        private string _note1;
        public string Note1
        {
            get
            {
                return _note1;
            }
            set
            {
                if (value != _note1)
                {
                    _note1 = value;
                    NotifyPropertyChanged("Note1");
                }
            }
        }

        private string _note2;
        public string Note2
        {
            get
            {
                return _note2;
            }
            set
            {
                if (value != _note2)
                {
                    _note2 = value;
                    NotifyPropertyChanged("Note2");
                }
            }
        }

        private string _date;
        public string Date
        {
            get
            {
                return _date;
            }
            set
            {
                if (value != _date)
                {
                    _date = value;
                    NotifyPropertyChanged("Date");
                }
            }
        }

        private string _author;
        public string Author
        {
            get
            {
                return _author;
            }
            set
            {
                if (value != _author)
                {
                    _author = value;
                    NotifyPropertyChanged("Author");
                }
            }
        }

        private string _type;
        public string Type
        {
            get
            {
                return _type;
            }
            set
            {
                if (value != _type)
                {
                    _type = value;
                    NotifyPropertyChanged("Type");
                }
            }
        }

        private string _color;
        public string Color
        {
            get
            {
                return _color;
            }
            set
            {
                if (value != _color)
                {
                    _color = value;
                    NotifyPropertyChanged("Color");
                }
            }
        }

        private string _color2;
        public string Color2
        {
            get
            {
                return _color2;
            }
            set
            {
                if (value != _color2)
                {
                    _color2 = value;
                    NotifyPropertyChanged("Color2");
                }
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}