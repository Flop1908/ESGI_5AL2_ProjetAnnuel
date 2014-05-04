using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using AnneDocTique_WP8.Resources;
using System.Net;
using System.Windows;
using AnneDocTique_WP8.Models;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace AnneDocTique_WP8.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            this.Items = new ObservableCollection<ItemViewModel>();
            this.TopItems = new ObservableCollection<ItemViewModel>();
            this.FlopItems = new ObservableCollection<ItemViewModel>();
            this.RandomItems = new ObservableCollection<ItemViewModel>();
        }

        /// <summary>
        /// Collection pour les objets ItemViewModel.
        /// </summary>
        public ObservableCollection<ItemViewModel> Items { get; private set; }
        public ObservableCollection<ItemViewModel> TopItems { get; private set; }
        public ObservableCollection<ItemViewModel> FlopItems { get; private set; }
        public ObservableCollection<ItemViewModel> RandomItems { get; private set; }

        private string _sampleProperty = "Sample Runtime Property Value";
        /// <summary>
        /// Exemple de propriété ViewModel ; cette propriété est utilisée dans la vue pour afficher sa valeur à l'aide d'une liaison
        /// </summary>
        /// <returns></returns>
        public string SampleProperty
        {
            get
            {
                return _sampleProperty;
            }
            set
            {
                if (value != _sampleProperty)
                {
                    _sampleProperty = value;
                    NotifyPropertyChanged("SampleProperty");
                }
            }
        }

        /// <summary>
        /// Exemple de propriété qui retourne une chaîne localisée
        /// </summary>
        public string LocalizedSampleProperty
        {
            get
            {
                return AppResources.SampleProperty;
            }
        }

        public bool IsDataLoaded
        {
            get;
            private set;
        }

        /// <summary>
        /// Crée et ajoute quelques objets ItemViewModel dans la collection Items.
        /// </summary>
        public void LoadData()
        {
            LoadLastCNF(10, "1");
            LoadTopCNF(10, "1");
            LoadFlopCNF(10, "1");
            LoadRandomCNF(10, "1");

            // Exemple de données ; remplacer par des données réelles
            /*this.Items.Add(new ItemViewModel() { LineOne = "runtime one", LineTwo = "Maecenas praesent accumsan bibendum", LineThree = "Facilisi faucibus habitant inceptos interdum lobortis nascetur pharetra placerat pulvinar sagittis senectus sociosqu" });
            this.Items.Add(new ItemViewModel() { LineOne = "runtime two", LineTwo = "Dictumst eleifend facilisi faucibus", LineThree = "Suscipit torquent ultrices vehicula volutpat maecenas praesent accumsan bibendum dictumst eleifend facilisi faucibus" });
            this.Items.Add(new ItemViewModel() { LineOne = "runtime three", LineTwo = "Habitant inceptos interdum lobortis", LineThree = "Habitant inceptos interdum lobortis nascetur pharetra placerat pulvinar sagittis senectus sociosqu suscipit torquent" });
            this.Items.Add(new ItemViewModel() { LineOne = "runtime four", LineTwo = "Nascetur pharetra placerat pulvinar", LineThree = "Ultrices vehicula volutpat maecenas praesent accumsan bibendum dictumst eleifend facilisi faucibus habitant inceptos" });
            this.Items.Add(new ItemViewModel() { LineOne = "runtime five", LineTwo = "Maecenas praesent accumsan bibendum", LineThree = "Maecenas praesent accumsan bibendum dictumst eleifend facilisi faucibus habitant inceptos interdum lobortis nascetur" });
            this.Items.Add(new ItemViewModel() { LineOne = "runtime six", LineTwo = "Dictumst eleifend facilisi faucibus", LineThree = "Pharetra placerat pulvinar sagittis senectus sociosqu suscipit torquent ultrices vehicula volutpat maecenas praesent" });
            this.Items.Add(new ItemViewModel() { LineOne = "runtime seven", LineTwo = "Habitant inceptos interdum lobortis", LineThree = "Accumsan bibendum dictumst eleifend facilisi faucibus habitant inceptos interdum lobortis nascetur pharetra placerat" });
            this.Items.Add(new ItemViewModel() { LineOne = "runtime eight", LineTwo = "Nascetur pharetra placerat pulvinar", LineThree = "Pulvinar sagittis senectus sociosqu suscipit torquent ultrices vehicula volutpat maecenas praesent accumsan bibendum" });
            this.Items.Add(new ItemViewModel() { LineOne = "runtime nine", LineTwo = "Maecenas praesent accumsan bibendum", LineThree = "Facilisi faucibus habitant inceptos interdum lobortis nascetur pharetra placerat pulvinar sagittis senectus sociosqu" });
            this.Items.Add(new ItemViewModel() { LineOne = "runtime ten", LineTwo = "Dictumst eleifend facilisi faucibus", LineThree = "Suscipit torquent ultrices vehicula volutpat maecenas praesent accumsan bibendum dictumst eleifend facilisi faucibus" });
            this.Items.Add(new ItemViewModel() { LineOne = "runtime eleven", LineTwo = "Habitant inceptos interdum lobortis", LineThree = "Habitant inceptos interdum lobortis nascetur pharetra placerat pulvinar sagittis senectus sociosqu suscipit torquent" });
            this.Items.Add(new ItemViewModel() { LineOne = "runtime twelve", LineTwo = "Nascetur pharetra placerat pulvinar", LineThree = "Ultrices vehicula volutpat maecenas praesent accumsan bibendum dictumst eleifend facilisi faucibus habitant inceptos" });
            this.Items.Add(new ItemViewModel() { LineOne = "runtime thirteen", LineTwo = "Maecenas praesent accumsan bibendum", LineThree = "Maecenas praesent accumsan bibendum dictumst eleifend facilisi faucibus habitant inceptos interdum lobortis nascetur" });
            this.Items.Add(new ItemViewModel() { LineOne = "runtime fourteen", LineTwo = "Dictumst eleifend facilisi faucibus", LineThree = "Pharetra placerat pulvinar sagittis senectus sociosqu suscipit torquent ultrices vehicula volutpat maecenas praesent" });
            this.Items.Add(new ItemViewModel() { LineOne = "runtime fifteen", LineTwo = "Habitant inceptos interdum lobortis", LineThree = "Accumsan bibendum dictumst eleifend facilisi faucibus habitant inceptos interdum lobortis nascetur pharetra placerat" });
            this.Items.Add(new ItemViewModel() { LineOne = "runtime sixteen", LineTwo = "Nascetur pharetra placerat pulvinar", LineThree = "Pulvinar sagittis senectus sociosqu suscipit torquent ultrices vehicula volutpat maecenas praesent accumsan bibendum" });
            */
            this.IsDataLoaded = true;
        }

        /// <summary>
        /// CNF part
        /// </summary>
        /// <param name="nbcnf">nombre d'anecdote</param>
        /// <param name="nbpage">numero de la page</param>
        private void LoadLastCNF(int nbcnf, string nbpage)
        {
            string param = "last/" + nbcnf + "/" + nbpage;
            WebClient client = new WebClient();
            client.DownloadStringCompleted += client_RetreiveLastAnecdoteCompleted;
            client.DownloadStringAsync(new Uri("http://ralf-esgi.com/myapp/ServiceHello.svc/CNF_RetreiveAnecdote/"+ param));
        }
       
        private void LoadTopCNF(int nbcnf, string nbpage)
        {
            string param = "top/" + nbcnf + "/" + nbpage;
            WebClient client = new WebClient();
            client.DownloadStringCompleted += client_RetreiveTopAnecdoteCompleted;
            client.DownloadStringAsync(new Uri("http://ralf-esgi.com/myapp/ServiceHello.svc/CNF_RetreiveAnecdote/" + param));
        }

        private void LoadFlopCNF(int nbcnf, string nbpage)
        {
            string param = "flop/" + nbcnf + "/" + nbpage;
            WebClient client = new WebClient();
            client.DownloadStringCompleted += client_RetreiveFlopAnecdoteCompleted;
            client.DownloadStringAsync(new Uri("http://ralf-esgi.com/myapp/ServiceHello.svc/CNF_RetreiveAnecdote/" + param));
        }

        private void LoadRandomCNF(int nbcnf, string nbpage)
        {
            string param = "alea/" + nbcnf + "/" + nbpage;
            WebClient client = new WebClient();
            client.DownloadStringCompleted += client_RetreiveRandomAnecdoteCompleted;
            client.DownloadStringAsync(new Uri("http://ralf-esgi.com/myapp/ServiceHello.svc/CNF_RetreiveAnecdote/" + param));
        }

        private void client_RetreiveRandomAnecdoteCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                var cnf = JsonConvert.DeserializeObject<CNF[]>(e.Result);
                foreach (var anecdote in cnf)
                {
                    double note = Math.Round(((double)anecdote.Points / anecdote.Vote) * 2, 2);
                    this.RandomItems.Add(new ItemViewModel() { LineOne = anecdote.Fact, LineTwo = note.ToString() + "/10" });
                }
            }
        }

        private void client_RetreiveFlopAnecdoteCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                var cnf = JsonConvert.DeserializeObject<CNF[]>(e.Result);
                foreach (var anecdote in cnf)
                {
                    double note = Math.Round(((double)anecdote.Points / anecdote.Vote) * 2, 2);
                    this.FlopItems.Add(new ItemViewModel() { LineOne = anecdote.Fact, LineTwo = note.ToString() + "/10" });
                }
            }
        }

        private void client_RetreiveTopAnecdoteCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                var cnf = JsonConvert.DeserializeObject<CNF[]>(e.Result);
                foreach (var anecdote in cnf)
                {
                    double note = Math.Round(((double)anecdote.Points / anecdote.Vote) * 2, 2);
                    this.TopItems.Add(new ItemViewModel() { LineOne = anecdote.Fact, LineTwo = note.ToString() + "/10" });
                }
            }
        }

        private void client_RetreiveLastAnecdoteCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                var cnf = JsonConvert.DeserializeObject<CNF[]>(e.Result);
                foreach (var anecdote in cnf)
                {
                    double note = Math.Round(((double)anecdote.Points / anecdote.Vote) * 2, 2);
                    this.Items.Add(new ItemViewModel() { LineOne = anecdote.Fact, LineTwo = note.ToString() + "/10" });
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