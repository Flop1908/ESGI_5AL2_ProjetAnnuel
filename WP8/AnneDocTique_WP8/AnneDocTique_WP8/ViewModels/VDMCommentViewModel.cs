using AnneDocTique_WP8.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnneDocTique_WP8.ViewModels
{
    public class VDMCommentViewModel : INotifyPropertyChanged
    {

        /// <summary>
        /// Collection pour les objets VDMCommentViewModel.
        /// </summary>
        public ObservableCollection<VDMCommentItemViewModel> CommentItems { get; private set; }


        public VDMCommentViewModel()
        {
            this.CommentItems = new ObservableCollection<VDMCommentItemViewModel>();
        }

        public bool IsDataLoaded
        {
            get;
            private set;
        }

        public void LoadData()
        {
            string result;
            using (StreamReader streamReader = new StreamReader("VDMComment-8297676.json"))
            {
                result = streamReader.ReadToEnd();
            }

            var com = JsonConvert.DeserializeObject<Commentaire[]>(result);
            foreach (var commentaire in com)
            {
                this.CommentItems.Add(new VDMCommentItemViewModel()
                {
                    Id = commentaire.Id.ToString(),
                    Content = commentaire.Text,
                    Date = "Le " + commentaire.Date.ToString("dd/MM/yyyy à hh:mm"),
                    Author = commentaire.Author,
                    Thumbs = "Score : " + commentaire.Thumbs
                });
            }

            this.IsDataLoaded = true;

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
