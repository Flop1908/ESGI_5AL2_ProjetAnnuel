using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnneDocTique_WP8.ViewModels
{
    public class VDMCommentItemViewModel : INotifyPropertyChanged
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

        private string _thumbs;
        public string Thumbs
        {
            get
            {
                return _thumbs;
            }
            set
            {
                if (value != _thumbs)
                {
                    _thumbs = value;
                    NotifyPropertyChanged("Thumbs");
                }
            }
        }

        

        private string _bordercolor;
        public string BorderColor
        {
            get
            {
                return _bordercolor;
            }
            set
            {
                if (value != _bordercolor)
                {
                    _bordercolor = value;
                    NotifyPropertyChanged("BorderColor");
                }
            }
        }

        private string _VoteColor;
        public string VoteColor
        {
            get
            {
                return _VoteColor;
            }
            set
            {
                if (value != _VoteColor)
                {
                    _VoteColor = value;
                    NotifyPropertyChanged("VoteColor");
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
