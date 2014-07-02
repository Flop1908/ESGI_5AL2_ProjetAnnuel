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
using System.IO;

namespace AnneDocTique_WP8.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private AnecdoteDB AnecdoteDB;

        private string ws = "http://ralf-esgi.com/app6/ServiceHello.svc/";
        public Dictionary<object, DateTime> LastDico { get; set; }
        public Dictionary<object, DateTime> RandomDico { get; set; }
        List<DTC> LastDTC { get; set; }
        List<DTC> RandomDTC { get; set; }

        /// <summary>
        /// Collection pour les objets ItemViewModel.
        /// </summary>
        public ObservableCollection<ItemViewModel> Items { get; private set; }
        public ObservableCollection<ItemViewModel> TopItems { get; private set; }
        public ObservableCollection<ItemViewModel> FlopItems { get; private set; }
        public ObservableCollection<ItemViewModel> RandomItems { get; private set; }

        Random random = new Random();

        private int veriflastVDM = 0, veriflastDTC = 0, veriflastCNF = 0;
        private int verifrandomVDM = 0, verifrandomDTC = 0, verifrandomCNF = 0;

        public MainViewModel()
        {
            this.Items = new ObservableCollection<ItemViewModel>();
            this.TopItems = new ObservableCollection<ItemViewModel>();
            this.FlopItems = new ObservableCollection<ItemViewModel>();
            this.RandomItems = new ObservableCollection<ItemViewModel>();

            this.LastDico = new Dictionary<object, DateTime>();
            this.RandomDico = new Dictionary<object, DateTime>();

            this.LastDTC = new List<DTC>();
            this.RandomDTC = new List<DTC>();

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
            //this.LastDico.Clear();
            //this.RandomDico.Clear();
            //this.Items.Clear();
            //this.RandomItems.Clear();
            //this.RandomDTC.Clear();
            //this.LastDTC.Clear();

            //List<bool> list = new List<bool>();

            //var req = from Filtres f in AnecdoteDB.FiltresDB
            //          select f.Value;

            //foreach (bool b in req)
            //    list.Add(b);

            //if (!list[0] && !list[1] && !list[2]) this.Items.Add(new ItemViewModel() { Content = "Aucune anecdote sélectionnée dans vos filtres" });


            //LoadLastVDM(1, list[0]);
            //LoadLastCNF(1, list[1]);
            //LoadLastDTC(list[2]);

            //if (!list[3] && !list[4] && !list[5]) this.RandomItems.Add(new ItemViewModel() { Content = "Aucune anecdote sélectionnée dans vos filtres" });

            //LoadRandomVDM(1, list[3]);
            //LoadRandomCNF(1, list[4]);
            //LoadRandomDTC(list[5]);

            //if (list[6]) LoadTopVDM(1);
            //else if (list[8]) LoadTopCNF(1);
            //else if (list[9]) ;

            //if (list[7]) LoadFlopVDM(1);
            //else if (list[10]) LoadFlopCNF(1);
            //else if (list[11]) ;

            //CNF = #bfad82 text = noir note = e9ca8f
            //VDM = c9d8ed + 4c93d6 - 0062bd
            //DTC = 559955 - a0c188 + 559955

            ScreenTopCNF();
            ScreenCNFLast();
            ScreenDTCLast();
            ScreenVDMLast();
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

            LoadLastVDM(1, list[0]);
            LoadLastCNF(1, list[1]);
            LoadLastDTC(list[2]);

        }

        public void AppBarRefreshRandom()
        {
            this.RandomDico.Clear();
            
            List<bool> list = new List<bool>();

            var req = from Filtres f in AnecdoteDB.FiltresDB
                      select f.Value;

            foreach (bool b in req)
                list.Add(b);

            
            LoadRandomVDM(1, list[3]);
            LoadRandomCNF(1, list[4]);
            LoadRandomDTC(list[5]);

        }
        

        public void RefreshLastFilter(bool VDM_Filter, bool DTC_Filter, bool CNF_Filter)
        {
            this.LastDico.Clear();
            if (!VDM_Filter && !DTC_Filter && !CNF_Filter)
            {
                this.Items.Clear();
                this.Items.Add(new ItemViewModel() { Content = "Aucune anecdote sélectionnée dans vos filtres" });
            }
            else
            {
                LoadLastVDM(1, VDM_Filter);
                LoadLastDTC(DTC_Filter);
                LoadLastCNF(1, CNF_Filter);
                
            }
        }

        public void RefreshRandomFilter(bool VDM_Filter, bool DTC_Filter, bool CNF_Filter)
        {         
            this.RandomDico.Clear();

            if (!VDM_Filter && !DTC_Filter && !CNF_Filter)
            {
                this.RandomItems.Clear();
                this.RandomItems.Add(new ItemViewModel() { Content = "Aucune anecdote sélectionnée dans vos filtres" });
            }
            else
            {
                
                LoadRandomVDM(1, VDM_Filter);
                LoadRandomDTC(DTC_Filter);
                LoadRandomCNF(1, CNF_Filter);
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
                    LoadFlopVDM(1);
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
            int index = 0, j = 0;
            var item = this.LastDico.OrderByDescending(i => i.Value);
            for (int cpt = 1; cpt < item.Count(); cpt++)
            //foreach (var item in this.LastDico.OrderByDescending(i => i.Value))
            {
                if (cpt % 3 == 0 && this.LastDTC.Count > index)
                {
                    
                    this.Items.Add(new ItemViewModel() { 
                        Content = this.LastDTC[index].Text.Replace("<br>", "\n"), 
                        Type = this.LastDTC[index].Type, 
                        Id = this.LastDTC[index].Id.ToString(),
                        Color = "#559955", 
                        Color2 = "Transparent"
                    });
                    index++;
                    j++;
                }
                else
                {
                    if (typeof(VDM) == item.ElementAt(cpt-j).Key.GetType())
                    {
                        VDM vdm = (VDM)item.ElementAt(cpt - j).Key;
                        this.Items.Add(new ItemViewModel()
                        {
                            Content = vdm.Text,
                            Note1 = "Je valide, c'est une VDM " + vdm.Agree,
                            Note2 = "Tu l'as bien mérité " + vdm.Deserved,
                            Date = vdm.Date.ToShortDateString(),
                            Type = vdm.Type,
                            Id = vdm.Id.ToString(),
                            Color = "#c9d8ed",
                            Color2 = "#4c93d6"
                        });
                    }
                    else if (typeof(CNF) == item.ElementAt(cpt - j).Key.GetType())
                    {
                        CNF cnf = (CNF)item.ElementAt(cpt - j).Key;
                        double note = Math.Round(((double)cnf.Points / cnf.Vote) * 2, 2);
                        this.Items.Add(new ItemViewModel() 
                        { 
                            Content = cnf.Texte, 
                            Note1 = note.ToString() + "/10", 
                            Date = cnf.Date.ToShortDateString(), 
                            Type = cnf.Type,
                            Id = cnf.Id.ToString(),
                            Color = "#bfad82",
                            Color2 = "lightgreen"
                        });
                    }
                    //else if (typeof(DTC) == item.Key.GetType())
                    //{
                    //    DTC dtc = (DTC)item.Key;
                    //    this.Items.Add(new ItemViewModel() { Content = dtc.Text });
                    //}
                }
            }
            veriflastCNF = 0;
            veriflastVDM = 0;
            veriflastDTC = 0;
        }

        public void LoadRandomAll()
        {
            this.RandomItems.Clear();
            int index = 0, j = 0; ;
            var item = this.RandomDico.OrderByDescending(i => i.Value);
            for (int cpt = 1; cpt < item.Count(); cpt++)
            //foreach (var item in RandomDico.OrderByDescending(i => i.Value))
            {
                if (cpt % 3 == 0 && this.RandomDTC.Count > index)
                {
                    this.RandomItems.Add(new ItemViewModel() { Content = this.RandomDTC[index].Text });
                    index++;
                    j++;
                }
                else
                {
                    if (typeof(VDM) == item.ElementAt(cpt - j).Key.GetType())
                    {
                        VDM vdm = (VDM)item.ElementAt(cpt - j).Key;
                        this.RandomItems.Add(new ItemViewModel() { Content = vdm.Text, Note1 = "Je valide, c'est une VDM " + vdm.Agree, Note2 = "Tu l'as bien mérité " + vdm.Deserved });
                    }
                    else if (typeof(CNF) == item.ElementAt(cpt - j).Key.GetType())
                    {
                        CNF cnf = (CNF)item.ElementAt(cpt - j).Key;
                        double note = Math.Round(((double)cnf.Points / cnf.Vote) * 2, 2);
                        this.RandomItems.Add(new ItemViewModel() { Content = cnf.Texte, Note1 = note.ToString() + "/10" });
                    }
                    //else if (typeof(DTC) == item.Key.GetType())
                    //{
                    //    DTC dtc = (DTC)item.Key;
                    //    this.RandomItems.Add(new ItemViewModel() { Content = dtc.Text });
                    //}
                }
            }

            verifrandomCNF = 0;
            verifrandomVDM = 0;
            verifrandomDTC = 0;
        }
   


        public void LoadLastCNF(int nbpage, bool show)
        {
            if (show)
            {
                string param = "last/" + nbpage;
                WebClient client = new WebClient();
                client.DownloadStringCompleted += client_RetreiveLastCNFCompleted;
                client.DownloadStringAsync(new Uri(ws + "CNF_RetreiveAnecdote/" + param + "?Unused=" + random.Next().ToString()));
            }
            else veriflastCNF++;

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

        public void LoadRandomCNF(int nbpage, bool show)
        {
            if (show)
            {
                string param = "random/" + nbpage;
                WebClient client = new WebClient();
                client.DownloadStringCompleted += client_RetreiveRandomCNFCompleted;
                client.DownloadStringAsync(new Uri(ws + "CNF_RetreiveAnecdote/" + param + "?Unused=" + random.Next().ToString()));
            }
            else verifrandomCNF++;
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
                //LoadLastAll();
                veriflastCNF++;
                if (veriflastCNF != 0 && veriflastVDM != 0 && veriflastDTC != 0)
                {
                    LoadLastAll();
                }
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
                //LoadRandomAll();
                verifrandomCNF++;
                if (verifrandomCNF != 0 && verifrandomVDM != 0 && verifrandomDTC != 0)
                {
                    LoadRandomAll();
                }
            }
        }




        public void LoadLastVDM(int nbpage, bool show)
        {
            if (show)
            {
                string param = "last/" + nbpage;
                WebClient client = new WebClient();
                client.DownloadStringCompleted += client_RetreiveLastVDMCompleted;
                client.DownloadStringAsync(new Uri(ws + "VDM_RetreiveAnecdote/" + param + "?Unused=" + random.Next().ToString()));
            }
            else veriflastVDM++;
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

        public void LoadRandomVDM(int nbpage, bool show)
        {
            if (show)
            {
                string param = "random/" + nbpage;
                WebClient client = new WebClient();
                client.DownloadStringCompleted += client_RetreiveRandomVDMCompleted;
                client.DownloadStringAsync(new Uri(ws + "VDM_RetreiveAnecdote/" + param + "?Unused=" + random.Next().ToString()));
            }
            else verifrandomVDM++;
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
                //LoadLastAll();
                veriflastVDM++;
                if (veriflastCNF != 0 && veriflastVDM != 0 && veriflastDTC != 0)
                {
                    LoadLastAll();
                }
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
                //LoadRandomAll();
                verifrandomVDM++;
                if (verifrandomCNF != 0 && verifrandomVDM != 0 && verifrandomDTC != 0)
                {
                    LoadRandomAll();
                }
            }
        }

        private void LoadLastDTC(bool show)
        {
            if (show)
            {
                string result;
                using (StreamReader streamReader = new StreamReader("DTCLast.json"))
                {
                    result = streamReader.ReadToEnd();
                }

                var dtc = JsonConvert.DeserializeObject<DTC[]>(result);
                foreach (var anecdote in dtc)
                {
                    this.LastDTC.Add(anecdote);
                }
                veriflastDTC++;
                if (veriflastCNF != 0 && veriflastVDM != 0 && veriflastDTC != 0)
                {
                    LoadLastAll();
                }
            }
            else veriflastDTC++;
        }

        private void LoadRandomDTC(bool show)
        {
            if (show)
            {
                string result;
                using (StreamReader streamReader = new StreamReader("DTCLast.json"))
                {
                    result = streamReader.ReadToEnd();
                }

                var dtc = JsonConvert.DeserializeObject<DTC[]>(result);
                foreach (var anecdote in dtc)
                {
                    this.RandomDTC.Add(anecdote);
                }
                verifrandomDTC++;
                if (verifrandomCNF != 0 && verifrandomVDM != 0 && verifrandomDTC != 0)
                {
                    LoadRandomAll();
                }
            }
            else verifrandomDTC++;
        }

        //Mélange des 3
        //TOP CNF
        //Comment VDM

        private void ScreenTopCNF() 
        {
            string result;
            using (StreamReader streamReader = new StreamReader("CNFTop.json"))
            {
                result = streamReader.ReadToEnd();
            }

            var cnf = JsonConvert.DeserializeObject<CNF[]>(result);
            foreach (var anecdote in cnf)
            {
                double note = Math.Round(((double)anecdote.Points / anecdote.Vote) * 2, 2);
                this.TopItems.Add(new ItemViewModel() { Content = anecdote.Texte, Note1 = note.ToString() + "/10" });
            }

        }
        private void ScreenDTCLast() 
        {
            string result;
            using (StreamReader streamReader = new StreamReader("DTCLast.json"))
            {
                result = streamReader.ReadToEnd();
            }

            var dtc = JsonConvert.DeserializeObject<DTC[]>(result);
            foreach (var anecdote in dtc)
            {
                this.LastDTC.Add(anecdote);
            }
            veriflastDTC++;
            if (veriflastCNF != 0 && veriflastVDM != 0 && veriflastDTC != 0)
            {
                LoadLastAll();
            }
        }
        private void ScreenVDMLast() 
        {
            string result;
            using (StreamReader streamReader = new StreamReader("VDMLast.json"))
            {
                result = streamReader.ReadToEnd();
            }

            var vdm = JsonConvert.DeserializeObject<VDM[]>(result);
            foreach (var anecdote in vdm)
            {
                this.LastDico.Add(anecdote, anecdote.Date); 
            }
            veriflastVDM++;
            if (veriflastCNF != 0 && veriflastVDM != 0 && veriflastDTC != 0)
            {
                LoadLastAll();
            }
        }
        private void ScreenCNFLast()
        {
            string result;
            using (StreamReader streamReader = new StreamReader("CNFLast.json"))
            {
                result = streamReader.ReadToEnd();
            }

            var cnf = JsonConvert.DeserializeObject<CNF[]>(result);
            foreach (var anecdote in cnf)
            {
                this.LastDico.Add(anecdote, anecdote.Date);
            }
            veriflastCNF++;
            if (veriflastCNF != 0 && veriflastVDM != 0 && veriflastDTC != 0)
            {
                LoadLastAll();
            }
        }
        private void LoadVDMComment() { }


        

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