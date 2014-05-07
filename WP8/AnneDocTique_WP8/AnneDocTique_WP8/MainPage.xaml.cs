using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using AnneDocTique_WP8.Resources;
using System.Windows.Controls.Primitives;
using System.ComponentModel;
using System.Threading;

namespace AnneDocTique_WP8
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructeur
        public MainPage()
        {
            InitializeComponent();
            //ShowSplash();
            // Affecter l'exemple de données au contexte de données du contrôle ListBox
            DataContext = App.ViewModel;

            // Exemple de code pour la localisation d'ApplicationBar
            BuildLocalizedApplicationBar();
        }

        // Charger les données pour les éléments ViewModel
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (!App.ViewModel.IsDataLoaded)
            {
                App.ViewModel.LoadData();
            }
        }

        // Exemple de code pour la conception d'une ApplicationBar localisée
        private void BuildLocalizedApplicationBar()
        {
            // Définit l'ApplicationBar de la page sur une nouvelle instance d'ApplicationBar.
            ApplicationBar = new ApplicationBar();

            // Crée un bouton et définit la valeur du texte sur la chaîne localisée issue d'AppResources.
            
            ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/Images/sync.png", UriKind.Relative));
            appBarButton.Text = AppResources.AppBarButtonText;
            appBarButton.Click += appBarButton_Click;
            ApplicationBar.Buttons.Add(appBarButton);

            // Crée un nouvel élément de menu avec la chaîne localisée d'AppResources.
            ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
            appBarMenuItem.Click += appBarMenuItem_Click;
            ApplicationBar.MenuItems.Add(appBarMenuItem);
            
        }
        
        private void appBarMenuItem_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/FiltrePage.xaml", UriKind.Relative));
        }

        private void appBarButton_Click(object sender, EventArgs e)
        {
            App.ViewModel.LoadRandomCNFData();
        }

        private Popup popup;
        private BackgroundWorker backroungWorker;

        private void ShowSplash()
        {
            this.popup = new Popup();
            this.popup.Child = new SplashScreen();
            this.popup.IsOpen = true;
            StartLoadingData();
        }

        private void StartLoadingData()
        {
            backroungWorker = new BackgroundWorker();
            backroungWorker.DoWork += new DoWorkEventHandler(backroungWorker_DoWork);
            backroungWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backroungWorker_RunWorkerCompleted);
            backroungWorker.RunWorkerAsync();
        }

        void backroungWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Dispatcher.BeginInvoke(() =>
            {
                this.popup.IsOpen = false;

            }
            );
        }

        void backroungWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            //here we can load data
            Thread.Sleep(1000);
        }
    }
}