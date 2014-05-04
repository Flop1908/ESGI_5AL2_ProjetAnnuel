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

namespace AnneDocTique_WP8
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructeur
        public MainPage()
        {
            InitializeComponent();

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
            ApplicationBar.MenuItems.Add(appBarMenuItem);
        }

        private void appBarButton_Click(object sender, EventArgs e)
        {
            App.ViewModel.LoadData();
        }
    }
}