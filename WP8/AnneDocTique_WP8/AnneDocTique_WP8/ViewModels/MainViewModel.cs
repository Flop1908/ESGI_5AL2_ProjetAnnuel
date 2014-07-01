using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using AnneDocTique_WP8.Resources;
using System.Net;
using System.Windows;
using AnneDocTique_WP8.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using AnneDocTique_WP8.Databases;

namespace AnneDocTique_WP8.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private AnecdoteDB AnecdoteDB;

        private string ws = "http://ralf-esgi.com/app6/ServiceHello.svc/";
        public Dictionary<object, DateTime> LastDico { get; set; }
        public Dictionary<object, DateTime> RandomDico { get; set; }

        /// <summary>
        /// Collection pour les objets ItemViewModel.
        /// </summary>
        public ObservableCollection<ItemViewModel> Items { get; private set; }
        public ObservableCollection<ItemViewModel> TopItems { get; private set; }
        public ObservableCollection<ItemViewModel> FlopItems { get; private set; }
        public ObservableCollection<ItemViewModel> RandomItems { get; private set; }

        Random random = new Random();

        public MainViewModel()
        {
            this.Items = new ObservableCollection<ItemViewModel>();
            this.TopItems = new ObservableCollection<ItemViewModel>();
            this.FlopItems = new ObservableCollection<ItemViewModel>();
            this.RandomItems = new ObservableCollection<ItemViewModel>();

            this.LastDico = new Dictionary<object, DateTime>();
            this.RandomDico = new Dictionary<object, DateTime>();

            AnecdoteDB = new AnecdoteDB(AnecdoteDB.DBConnectionString);
        }

        

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
            this.LastDico.Clear();
            this.RandomDico.Clear();

            List<bool> list = new List<bool>();

            var req = from Filtres f in AnecdoteDB.FiltresDB
                      select f.Value;

            foreach (bool b in req)
                list.Add(b);

            if (list[0]) LoadLastVDM(1);
            if (list[1]) LoadLastCNF(1);
            if (list[2]) ;

            if (list[3]) LoadRandomVDM(1);
            if (list[4]) LoadRandomCNF(1);
            if (list[5]) ;

            if (list[6]) LoadTopVDM(1);
            else if (list[8]) LoadTopCNF(1);
            else if (list[9]) ;

            if (list[7]) LoadFlopVDM(1);
            else if (list[10]) LoadFlopCNF(1);
            else if (list[11]) ;

            //LoadLastAll(); 
            //LoadRandomAll();

            this.IsDataLoaded = true;

        }

        public void AppBarRefreshLast()
        {
            this.LastDico.Clear();

            List<bool> list = new List<bool>();

            var req = from Filtres f in AnecdoteDB.FiltresDB
                      select f.Value;

            foreach (bool b in req)
                list.Add(b);

            if (list[0]) LoadLastVDM(1);
            if (list[1]) LoadLastCNF(1);
            if (list[2]) ;

            this.IsDataLoaded = true;
        }

        public void AppBarRefreshRandom()
        {
            this.RandomDico.Clear();
            
            List<bool> list = new List<bool>();

            var req = from Filtres f in AnecdoteDB.FiltresDB
                      select f.Value;

            foreach (bool b in req)
                list.Add(b);

            
            if (list[3]) LoadRandomVDM(1);
            if (list[4]) LoadRandomCNF(1);
            if (list[5]) ;

            this.IsDataLoaded = true;
        }
        

        public void RefreshLastFilter(bool VDM_Filter, bool DTC_Filter, bool CNF_Filter)
        {
            this.LastDico.Clear();
            if (VDM_Filter || DTC_Filter || CNF_Filter)
            {
                if (VDM_Filter) LoadLastVDM(1);
                //if (DTC_Filter) LoadLastVDM(0);
                if (CNF_Filter) LoadLastCNF(1);
            }
            else
            {
                this.Items.Clear();
                this.Items.Add(new ItemViewModel() { Content = "Aucune anecdote sélectionnée dans vos filtres" });
            }
        }

        public void RefreshRandomFilter(bool VDM_Filter, bool DTC_Filter, bool CNF_Filter)
        {
            
            this.RandomDico.Clear();

            if (VDM_Filter || DTC_Filter || CNF_Filter)
            {
                if (VDM_Filter) LoadRandomVDM(1);
                //if (DTC_Filter) LoadLastVDM(0);
                if (CNF_Filter) LoadRandomCNF(1);
            }
            else
            {
                this.RandomItems.Clear();
                this.RandomItems.Add(new ItemViewModel() { Content = "Aucune anecdote sélectionnée dans vos filtres" });
            }
        }

        public bool RefreshTopFilter(string Anecdote)
        {
            this.TopItems.Clear();
            switch (Anecdote)
            {
                case "VDM":
                    LoadTopVDM(1);
                    return true;
                case "DTC" : 
                case "CNF" :
                    LoadTopCNF(1);
                    return true;
                default :
                    return false;
            }
        }

        public bool RefreshFlopFilter(string Anecdote)
        {
            this.FlopItems.Clear();
            switch (Anecdote)
            {
                case "VDM":
                    LoadFlopVDM(0);
                    return true;
                case "DTC":
                case "CNF":
                    LoadFlopCNF(1);
                    return true;
                default:
                    return false;
            }
        }

        public void LoadLastAll()
        {
            this.Items.Clear();            
            foreach (var item in this.LastDico.OrderByDescending(i => i.Value))
            {
                if (typeof(VDM) == item.Key.GetType())
                {
                    VDM vdm = (VDM)item.Key;
                    this.Items.Add(new ItemViewModel() { Content = vdm.Text, Note1 = "Je valide, c'est une VDM " + vdm.Agree, 
                                                        Note2 = "Tu l'as bien mérité " + vdm.Deserved, Date = vdm.Date.ToShortDateString() });
                }
                else if (typeof(CNF) == item.Key.GetType())
                {
                    CNF cnf = (CNF)item.Key;
                    double note = Math.Round(((double)cnf.Points / cnf.Vote) * 2, 2);
                    this.Items.Add(new ItemViewModel() { Content = cnf.Texte, Note1 = note.ToString() + "/10", Date = cnf.Date.ToShortDateString() });
                }
            }
            
        }

        public void LoadRandomAll()
        {
            this.RandomItems.Clear();
            foreach (var item in RandomDico.OrderByDescending(i => i.Value))
            {
                if (typeof(VDM) == item.Key.GetType())
                {
                    VDM vdm = (VDM)item.Key;
                    this.RandomItems.Add(new ItemViewModel() { Content = vdm.Text, Note1 = "Je valide, c'est une VDM " + vdm.Agree, Note2 = "Tu l'as bien mérité " + vdm.Deserved });
                }
                else if (typeof(CNF) == item.Key.GetType())
                {
                    CNF cnf = (CNF)item.Key;
                    double note = Math.Round(((double)cnf.Points / cnf.Vote) * 2, 2);
                    this.RandomItems.Add(new ItemViewModel() { Content = cnf.Texte, Note1 = note.ToString() + "/10"});
                }
            }
        }
   


        public void LoadLastCNF(int nbpage)
        {
            string param = "last/" + nbpage;
            WebClient client = new WebClient();
            client.DownloadStringCompleted += client_RetreiveLastCNFCompleted;
            client.DownloadStringAsync(new Uri(ws + "CNF_RetreiveAnecdote/" + param + "?Unused=" + random.Next().ToString()));
        }

        public void LoadTopCNF(int nbpage)
        {
            string param = "top/" + nbpage;
            WebClient client = new WebClient();
            client.DownloadStringCompleted += client_RetreiveTopCNFCompleted;
            client.DownloadStringAsync(new Uri(ws + "CNF_RetreiveAnecdote/" + param + "?Unused=" + random.Next().ToString()));
        }

        public void LoadFlopCNF(int nbpage)
        {
            string param = "flop/" + nbpage;
            WebClient client = new WebClient();
            client.DownloadStringCompleted += client_RetreiveFlopCNFCompleted;
            client.DownloadStringAsync(new Uri(ws + "CNF_RetreiveAnecdote/" + param + "?Unused=" + random.Next().ToString()));
        }

        public void LoadRandomCNF(int nbpage)
        {
            string param = "random/" + nbpage;
            WebClient client = new WebClient();
            client.DownloadStringCompleted += client_RetreiveRandomCNFCompleted;
            client.DownloadStringAsync(new Uri(ws + "CNF_RetreiveAnecdote/" + param + "?Unused=" + random.Next().ToString()));
        }

        private void client_RetreiveLastCNFCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            
            if (e.Error == null)
            {
                var cnf = JsonConvert.DeserializeObject<CNF[]>(e.Result);
                foreach (var anecdote in cnf)
                {
                    this.LastDico.Add(anecdote, anecdote.Date);
                }
                LoadLastAll();
            }
        }

        private void client_RetreiveTopCNFCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                var cnf = JsonConvert.DeserializeObject<CNF[]>(e.Result);
                foreach (var anecdote in cnf)
                {
                    double note = Math.Round(((double)anecdote.Points / anecdote.Vote) * 2, 2);
                    this.TopItems.Add(new ItemViewModel() { Content = anecdote.Texte, Note1 = note.ToString() + "/10" });
                }
            }
        }

        private void client_RetreiveFlopCNFCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                var cnf = JsonConvert.DeserializeObject<CNF[]>(e.Result);
                foreach (var anecdote in cnf)
                {
                    double note = Math.Round(((double)anecdote.Points / anecdote.Vote) * 2, 2);
                    this.FlopItems.Add(new ItemViewModel() { Content = anecdote.Texte, Note1 = note.ToString() + "/10" });
                }
            }
        }      
        
        private void client_RetreiveRandomCNFCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            
            if (e.Error == null)
            {
                var cnf = JsonConvert.DeserializeObject<CNF[]>(e.Result);
                foreach (var anecdote in cnf)
                {
                    this.RandomDico.Add(anecdote, anecdote.Date);
                }
                LoadRandomAll();
            }
        }




        public void LoadLastVDM(int nbpage)
        {
            string param = "last/" + nbpage;
            WebClient client = new WebClient();
            client.DownloadStringCompleted += client_RetreiveLastVDMCompleted;
            client.DownloadStringAsync(new Uri(ws + "VDM_RetreiveAnecdote/" + param + "?Unused=" + random.Next().ToString()));
        }

        public void LoadTopVDM(int nbpage)
        {
            string param = "top/" + nbpage;
            WebClient client = new WebClient();
            client.DownloadStringCompleted += client_RetreiveTopVDMCompleted;
            client.DownloadStringAsync(new Uri(ws + "VDM_RetreiveAnecdote/" + param + "?Unused=" + random.Next().ToString()));
        }

        public void LoadFlopVDM(int nbpage)
        {
            string param = "flop/" + nbpage;
            WebClient client = new WebClient();
            client.DownloadStringCompleted += client_RetreiveFlopVDMCompleted;
            client.DownloadStringAsync(new Uri(ws + "VDM_RetreiveAnecdote/" + param + "?Unused=" + random.Next().ToString()));
        }

        public void LoadRandomVDM(int nbpage)
        {
            
            string param = "random/" + nbpage;
            WebClient client = new WebClient();
            
            client.DownloadStringCompleted += client_RetreiveRandomVDMCompleted;
            client.DownloadStringAsync(new Uri(ws + "VDM_RetreiveAnecdote/" + param + "?Unused=" + random.Next().ToString()));
        }

        private void client_RetreiveLastVDMCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            
            if (e.Error == null)
            {
                var vdm = JsonConvert.DeserializeObject<VDM[]>(e.Result);
                foreach (var anecdote in vdm)
                {
                    this.LastDico.Add(anecdote, anecdote.Date);                   
                }
                LoadLastAll();
            }
        }

        private void client_RetreiveTopVDMCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                var vdm = JsonConvert.DeserializeObject<VDM[]>(e.Result);
                foreach (var anecdote in vdm)
                {
                    this.TopItems.Add(new ItemViewModel() { Content = anecdote.Text, Note1 = "Je valide, c'est une VDM " + anecdote.Agree, Note2 = "Tu l'as bien mérité " + anecdote.Deserved });
                }
            }
        }

        private void client_RetreiveFlopVDMCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                var vdm = JsonConvert.DeserializeObject<VDM[]>(e.Result);
                foreach (var anecdote in vdm)
                {
                    this.FlopItems.Add(new ItemViewModel() { Content = anecdote.Text, Note1 = "Je valide, c'est une VDM " + anecdote.Agree, Note2 = "Tu l'as bien mérité " + anecdote.Deserved });
                }
            }
        }        

        private void client_RetreiveRandomVDMCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                var vdm = JsonConvert.DeserializeObject<VDM[]>(e.Result);
                foreach (var anecdote in vdm)
                {
                    this.RandomDico.Add(anecdote, anecdote.Date);
                }
                LoadRandomAll();
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