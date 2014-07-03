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
using AnneDocTique_WP8.ViewModels;
using AnneDocTique_WP8.Databases;

namespace AnneDocTique_WP8
{
    public partial class MainPage : PhoneApplicationPage
    {
        private AnecdoteDB AnecdoteDB;

        // Constructeur
        public MainPage()
        {
            InitializeComponent();
            AnecdoteDB = new AnecdoteDB(AnecdoteDB.DBConnectionString);
            ShowSplash();
            // Affecter l'exemple de données au contexte de données du contrôle ListBox
            DataContext = App.ViewModel;

            
            BuildLocalizedApplicationBar();
        }

        // Charger les données pour les éléments ViewModel
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (!App.ViewModel.IsDataLoaded)
            {
                App.ViewModel.LoadData();
                App.ViewModel.LoadFavoris();
            }
        }

        // Exemple de code pour la conception d'une ApplicationBar localisée
        private void BuildLocalizedApplicationBar()
        {
            
            ApplicationBar = new ApplicationBar();

            ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/Images/sync.png", UriKind.Relative));
            
            appBarButton.Text = AppResources.AppBarButtonText; 
            appBarButton.Click += appBarButton_Click;
            ApplicationBar.Buttons.Add(appBarButton);

            // Crée un nouvel élément de menu avec la chaîne localisée d'AppResources.
            ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
            appBarMenuItem.Click += appBarMenuItem_Click;
            ApplicationBar.MenuItems.Add(appBarMenuItem);

            ApplicationBar.IsVisible = false;
            ApplicationBar.Opacity = 0.5;
        }
        
        private void appBarMenuItem_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/FiltrePage.xaml", UriKind.Relative));
        }

        private void appBarButton_Click(object sender, EventArgs e)
        {

            if (MainPivot.SelectedIndex == 0)
                App.ViewModel.AppBarRefreshLast();
            else if (MainPivot.SelectedIndex == 1) ;
            else if (MainPivot.SelectedIndex == 2) ;
            else if (MainPivot.SelectedIndex == 3)
                App.ViewModel.AppBarRefreshRandom();
            

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
                ApplicationBar.IsVisible = true;

            }
            );
        }

        void backroungWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            //here we can load data
            Thread.Sleep(3000);           
        }

        private void StackPanel_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            var currentItem = ((sender as StackPanel).DataContext) as ItemViewModel;
            NavigationService.Navigate(new Uri("/DetailPage.xaml?content=" + currentItem.Content + "&note1=" + currentItem.Note1 +
                                                "&note2=" + currentItem.Note2 + "&type=" + currentItem.Type + "&id=" + currentItem.Id + 
                                                "&author=" + currentItem.Author + "&date=" + currentItem.Date, UriKind.Relative));
        }

    }
}