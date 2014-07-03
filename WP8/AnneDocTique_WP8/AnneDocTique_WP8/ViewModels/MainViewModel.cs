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
        public ObservableCollection<ItemViewModel> FavorisItems { get; private set; }

        Random random = new Random();

        private int veriflastVDM = 0, veriflastDTC = 0, veriflastCNF = 0;
        private int verifrandomVDM = 0, verifrandomDTC = 0, verifrandomCNF = 0;

        public MainViewModel()
        {
            this.Items = new ObservableCollection<ItemViewModel>();
            this.TopItems = new ObservableCollection<ItemViewModel>();
            this.FlopItems = new ObservableCollection<ItemViewModel>();
            this.RandomItems = new ObservableCollection<ItemViewModel>();
            this.FavorisItems = new ObservableCollection<ItemViewModel>();

            this.LastDico = new Dictionary<object, DateTime>();
            this.RandomDico = new Dictionary<object, DateTime>();

            this.LastDTC = new List<DTC>();
            this.RandomDTC = new List<DTC>();

            AnecdoteDB = new AnecdoteDB(AnecdoteDB.DBConnectionString);
        }

       

        public bool IsDataLoaded
        {
            get;
            private set;
        }
        

        /// <summary>
        /// Ajoute les objets ItemViewModel dans les collection Items, etc... selon les filtres stockés dans la base local.
        /// </summary>
        public void LoadData()
        {
            this.LastDico.Clear();
            this.RandomDico.Clear();
            this.Items.Clear();
            this.RandomItems.Clear();
            this.RandomDTC.Clear();
            this.LastDTC.Clear();
            this.TopItems.Clear();
            this.FlopItems.Clear();


            List<bool> list = new List<bool>();

            var req = from Filtres f in AnecdoteDB.FiltresDB
                      select f.Value;

            foreach (bool b in req)
                list.Add(b);

            if (!list[0] && !list[1] && !list[2]) this.Items.Add(new ItemViewModel() { Content = "Aucune anecdote sélectionnée dans vos filtres" });


            LoadLastVDM(1, list[0]);
            LoadLastCNF(1, list[1]);
            LoadLastDTC(list[2]);

            if (!list[3] && !list[4] && !list[5]) this.RandomItems.Add(new ItemViewModel() { Content = "Aucune anecdote sélectionnée dans vos filtres" });

            LoadRandomVDM(1, list[3]);
            LoadRandomCNF(1, list[4]);
            LoadRandomDTC(list[5]);

            if (list[6]) LoadTopVDM(1);
            else if (list[8]) LoadTopCNF(1);
            else if (list[9]) LoadLastDTC(list[9]);

            if (list[7]) LoadFlopVDM(1);
            else if (list[10]) LoadFlopCNF(1);
            else if (list[11]) LoadLastDTC(list[11]); ;

  

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
        
        // Page Dernières
        public void LoadLastAll()
        {
            this.Items.Clear();
            int index = 0, j = 1;
            var item = this.LastDico.OrderByDescending(i => i.Value);
            for (int cpt = 1; cpt < item.Count(); cpt++)
            {
                if (cpt % 3 == 0 && this.LastDTC.Count > index)
                {
                    
                    this.Items.Add(new ItemViewModel() { 
                        Content = this.LastDTC[index].Text.Replace("<br>", "\n"), 
                        Type = this.LastDTC[index].Type, 
                        Id = this.LastDTC[index].Id.ToString(),                      
                        Note1 = "(*) " + this.LastDTC[index].Good.ToString(),
                        Note2 = "(-) " + this.LastDTC[index].Bad.ToString(),
                        Color = "#559955", 
                        Color2 = "Transparent"
                    });
                    index++;
                }
                else
                {
                    if (typeof(VDM) == item.ElementAt(cpt - j).Key.GetType())
                    {
                        VDM vdm = (VDM)item.ElementAt(cpt - j).Key;
                        this.Items.Add(new ItemViewModel()
                        {
                            Content = vdm.Text,
                            Note1 = "Je valide, c'est une VDM " + vdm.Agree,
                            Note2 = "Tu l'as bien mérité " + vdm.Deserved,
                            Date = vdm.Date.ToString("Le dd/MM/yyyy à HH:mm"),
                            Author = vdm.Author,
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
                            Note1 = "Moyenne : " + note.ToString() + "/10",
                            Date = cnf.Date.ToString("Le dd/mm/yyyy à hh:mm"), 
                            Type = cnf.Type,
                            Id = cnf.Id.ToString(),
                            Color = "#bfad82",
                            Color2 = "lightgreen"
                        });
                    }
                }
            }
            veriflastCNF = 0;
            veriflastVDM = 0;
            veriflastDTC = 0;
        }

        // Page Aléatoires
        public void LoadRandomAll()
        {
            this.RandomItems.Clear();
            int index = 0, j = 1;
            var item = this.RandomDico.OrderByDescending(i => i.Value);
            for (int cpt = 1; cpt < item.Count(); cpt++)
            {
                if (cpt % 3 == 0 && this.RandomDTC.Count > index)
                {
                    this.RandomItems.Add(new ItemViewModel()
                    {
                        Content = this.RandomDTC[index].Text.Replace("<br>", "\n"),
                        Type = this.RandomDTC[index].Type,
                        Id = this.RandomDTC[index].Id.ToString(),
                        Note1 = "(*) " + this.RandomDTC[index].Good.ToString(),
                        Note2 = "(-) " + this.RandomDTC[index].Bad.ToString(),
                        Color = "#559955",
                        Color2 = "Transparent"
                    });
                    index++;
                }
                else
                {
                    if (typeof(VDM) == item.ElementAt(cpt - j).Key.GetType())
                    {
                        VDM vdm = (VDM)item.ElementAt(cpt - j).Key;
                        this.RandomItems.Add(new ItemViewModel()
                        {
                            Content = vdm.Text,
                            Note1 = "Je valide, c'est une VDM " + vdm.Agree,
                            Note2 = "Tu l'as bien mérité " + vdm.Deserved,
                            Date = vdm.Date.ToString("Le dd/MM/yyyy à HH:mm"),
                            Author = vdm.Author,
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
                        this.RandomItems.Add(new ItemViewModel()
                        {
                            Content = cnf.Texte,
                            Note1 = "Moyenne : " + note.ToString() + "/10",
                            Date = cnf.Date.ToString("Le dd/mm/yyyy à hh:mm"),
                            Type = cnf.Type,
                            Id = cnf.Id.ToString(),
                            Color = "#bfad82",
                            Color2 = "lightgreen"
                        });
                    }
                }
            }
            verifrandomCNF = 0;
            verifrandomVDM = 0;
            verifrandomDTC = 0;
        }

        //Page Favoris
        public void LoadFavoris()
        {
            this.FavorisItems.Clear();
            var req = from Favoris f in AnecdoteDB.FavorisDB
                      select f;

            foreach (Favoris favoris in req)
                this.FavorisItems.Add(new ItemViewModel()
                {
                    Content = favoris.Content,
                    Author = favoris.Author,
                    Date = favoris.Date,
                    Note1 = favoris.Vote1,
                    Note2 = favoris.Vote2,
                    Color = favoris.Color1,
                    Color2 = favoris.Color2
                });

            
        }


        /// <summary>
        /// Requêtes pour récupérer les anecdotes CNF
        /// </summary>

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
                    this.TopItems.Add(new ItemViewModel() {
                        Content = anecdote.Texte,
                        Note1 = "Moyenne : " + note.ToString() + "/10",
                        Date = anecdote.Date.ToString("Le dd/mm/yyyy à hh:mm"),
                        Type = anecdote.Type,
                        Id = anecdote.Id.ToString(),
                        Color = "#bfad82",
                        Color2 = "lightgreen"
                    });
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
                    this.FlopItems.Add(new ItemViewModel() {
                        Content = anecdote.Texte,
                        Note1 = "Moyenne : " + note.ToString() + "/10",
                        Date = anecdote.Date.ToString("Le dd/mm/yyyy à hh:mm"),
                        Type = anecdote.Type,
                        Id = anecdote.Id.ToString(),
                        Color = "#bfad82",
                        Color2 = "lightgreen"
                    });
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


        /// <summary>
        /// Requêtes pour récupérer les anecdotes VDM
        /// </summary>


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
                    this.TopItems.Add(new ItemViewModel() {
                        Content = anecdote.Text,
                        Note1 = "Je valide, c'est une VDM " + anecdote.Agree,
                        Note2 = "Tu l'as bien mérité " + anecdote.Deserved,
                        Date = anecdote.Date.ToString("Le dd/MM/yyyy à HH:mm"),
                        Author = anecdote.Author,
                        Type = anecdote.Type,
                        Id = anecdote.Id.ToString(),
                        Color = "#c9d8ed",
                        Color2 = "#4c93d6"
                    });
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
                    this.FlopItems.Add(new ItemViewModel() {
                        Content = anecdote.Text,
                        Note1 = "Je valide, c'est une VDM " + anecdote.Agree,
                        Note2 = "Tu l'as bien mérité " + anecdote.Deserved,
                        Date = anecdote.Date.ToString("Le dd/MM/yyyy à HH:mm"),
                        Author = anecdote.Author,
                        Type = anecdote.Type,
                        Id = anecdote.Id.ToString(),
                        Color = "#c9d8ed",
                        Color2 = "#4c93d6"
                    });
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


        /// <summary>
        /// Requêtes pour récupérer les anecdotes DTC
        /// </summary>


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