using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using AnneDocTique_WP8.Databases;

namespace AnneDocTique_WP8
{
    public partial class FiltrePage : PhoneApplicationPage
    {
        private static bool LastVDM_Toggle, LastCNF_Toggle, LastDTC_Toggle;
        private static bool RandomVDM_Toggle, RandomCNF_Toggle, RandomDTC_Toggle;
        private static bool TopVDM_RadioButton, TopCNF_RadioButton, TopDTC_RadioButton;
        private static bool FlopVDM_RadioButton, FlopCNF_RadioButton, FlopDTC_RadioButton;

        private AnecdoteDB AnecdoteDB;

        public FiltrePage()
        {
            InitializeComponent();
            
            AnecdoteDB = new AnecdoteDB(AnecdoteDB.DBConnectionString);
            this.DataContext = this;

            LoadConfig();
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            Filtres objet = null ;
            objet = AnecdoteDB.FiltresDB.Single(fil => fil.Nom == "LastVDM_Toggle");
            objet.Value = LastVDM_Toggle;
            AnecdoteDB.SubmitChanges();

            objet = AnecdoteDB.FiltresDB.Single(fil => fil.Nom == "LastCNF_Toggle");
            objet.Value = LastCNF_Toggle;
            AnecdoteDB.SubmitChanges();

            objet = AnecdoteDB.FiltresDB.Single(fil => fil.Nom == "LastDTC_Toggle");
            objet.Value = LastDTC_Toggle;
            AnecdoteDB.SubmitChanges();

            objet = AnecdoteDB.FiltresDB.Single(fil => fil.Nom == "RandomVDM_Toggle");
            objet.Value = RandomVDM_Toggle;
            AnecdoteDB.SubmitChanges();

            objet = AnecdoteDB.FiltresDB.Single(fil => fil.Nom == "RandomCNF_Toggle");
            objet.Value = RandomCNF_Toggle;
            AnecdoteDB.SubmitChanges();

            objet = AnecdoteDB.FiltresDB.Single(fil => fil.Nom == "RandomDTC_Toggle");
            objet.Value = RandomDTC_Toggle;
            AnecdoteDB.SubmitChanges();

            objet = AnecdoteDB.FiltresDB.Single(fil => fil.Nom == "TopVDM_RadioButton");
            objet.Value = TopVDM_RadioButton;
            AnecdoteDB.SubmitChanges();

            objet = AnecdoteDB.FiltresDB.Single(fil => fil.Nom == "TopCNF_RadioButton");
            objet.Value = TopCNF_RadioButton;
            AnecdoteDB.SubmitChanges();

            objet = AnecdoteDB.FiltresDB.Single(fil => fil.Nom == "TopDTC_RadioButton");
            objet.Value = TopDTC_RadioButton;
            AnecdoteDB.SubmitChanges();

            objet = AnecdoteDB.FiltresDB.Single(fil => fil.Nom == "FlopVDM_RadioButton");
            objet.Value = FlopVDM_RadioButton;
            AnecdoteDB.SubmitChanges();

            objet = AnecdoteDB.FiltresDB.Single(fil => fil.Nom == "FlopCNF_RadioButton");
            objet.Value = FlopCNF_RadioButton;
            AnecdoteDB.SubmitChanges();

            objet = AnecdoteDB.FiltresDB.Single(fil => fil.Nom == "FlopDTC_RadioButton");
            objet.Value = FlopDTC_RadioButton;
            AnecdoteDB.SubmitChanges();


            App.ViewModel.LoadData();
            
        }

        private void LoadConfig()
        {



            List<bool> list = new List<bool>();

            var req = from Filtres f in AnecdoteDB.FiltresDB
                      select f.Value;

            foreach (bool b in req)
                list.Add(b);

            ToggleSwitchLastVDM.IsChecked = list[0];
            ToggleSwitchLastCNF.IsChecked = list[1];
            ToggleSwitchLastDTC.IsChecked = list[2];

            ToggleSwitchRandomVDM.IsChecked = list[3];
            ToggleSwitchRandomCNF.IsChecked = list[4];
            ToggleSwitchRandomDTC.IsChecked = list[5];

            RadioButtonTopVDM.IsChecked = list[6];
            RadioButtonTopCNF.IsChecked = list[8];
            RadioButtonTopDTC.IsChecked = list[9];

            RadioButtonFlopVDM.IsChecked = list[7];
            RadioButtonFlopCNF.IsChecked = list[10];
            RadioButtonFlopDTC.IsChecked = list[11];
           

            
        }

        /*
         * Filter Last
         */

        private void LastVDMToggleSwitch_Checked(object sender, RoutedEventArgs e)
        {
            // Add code to perform some action here.
            LastVDM_Toggle = true;
            //App.ViewModel.RefreshLastFilter(LastVDM_Toggle, LastDTC_Toggle, LastCNF_Toggle);
        }

        private void LastVDMToggleSwitch_Unchecked(object sender, RoutedEventArgs e)
        {
            // Add code to perform some action here.
            LastVDM_Toggle = false;
            //App.ViewModel.RefreshLastFilter(LastVDM_Toggle, LastDTC_Toggle, LastCNF_Toggle);
        }

        private void LastDTCToggleSwitch_Checked(object sender, RoutedEventArgs e)
        {
            // Add code to perform some action here.
            LastDTC_Toggle = true;
            //App.ViewModel.RefreshLastFilter(LastVDM_Toggle, LastDTC_Toggle, LastCNF_Toggle);
        }

        private void LastDTCToggleSwitch_Unchecked(object sender, RoutedEventArgs e)
        {
            // Add code to perform some action here.
            LastDTC_Toggle = false;
            //App.ViewModel.RefreshLastFilter(LastVDM_Toggle, LastDTC_Toggle, LastCNF_Toggle);
        }

        private void LastCNFToggleSwitch_Checked(object sender, RoutedEventArgs e)
        {
            // Add code to perform some action here.
            LastCNF_Toggle = true;
            //App.ViewModel.RefreshLastFilter(LastVDM_Toggle, LastDTC_Toggle, LastCNF_Toggle);
        }

        private void LastCNFToggleSwitch_Unchecked(object sender, RoutedEventArgs e)
        {
            // Add code to perform some action here.
            LastCNF_Toggle = false;
            //App.ViewModel.RefreshLastFilter(LastVDM_Toggle, LastDTC_Toggle, LastCNF_Toggle);
        }

        /*
         * Filter Random
         */

        private void RandomVDMToggleSwitch_Checked(object sender, RoutedEventArgs e)
        {
            // Add code to perform some action here.
            RandomVDM_Toggle = true;
            //App.ViewModel.RefreshRandomFilter(RandomVDM_Toggle, RandomDTC_Toggle, RandomCNF_Toggle);
        }

        private void RandomVDMToggleSwitch_Unchecked(object sender, RoutedEventArgs e)
        {
            // Add code to perform some action here.
            RandomVDM_Toggle = false;
            //App.ViewModel.RefreshRandomFilter(RandomVDM_Toggle, RandomDTC_Toggle, RandomCNF_Toggle);
        }

        private void RandomDTCToggleSwitch_Checked(object sender, RoutedEventArgs e)
        {
            // Add code to perform some action here.
            RandomDTC_Toggle = true;
            //App.ViewModel.RefreshRandomFilter(RandomVDM_Toggle, RandomDTC_Toggle, RandomCNF_Toggle);
        }

        private void RandomDTCToggleSwitch_Unchecked(object sender, RoutedEventArgs e)
        {
            // Add code to perform some action here.
            RandomDTC_Toggle = false;
            //App.ViewModel.RefreshRandomFilter(RandomVDM_Toggle, RandomDTC_Toggle, RandomCNF_Toggle);
        }

        private void RandomCNFToggleSwitch_Checked(object sender, RoutedEventArgs e)
        {
            // Add code to perform some action here.
            RandomCNF_Toggle = true;
            //App.ViewModel.RefreshRandomFilter(RandomVDM_Toggle, RandomDTC_Toggle, RandomCNF_Toggle);
        }

        private void RandomCNFToggleSwitch_Unchecked(object sender, RoutedEventArgs e)
        {
            // Add code to perform some action here.
            RandomCNF_Toggle = false;
            //App.ViewModel.RefreshRandomFilter(RandomVDM_Toggle, RandomDTC_Toggle, RandomCNF_Toggle);
        }

        /*
         * Filter Top
         */

        private void TopVDMRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            // Add code to perform some action here.
            TopVDM_RadioButton = true;
            TopCNF_RadioButton = false;
            TopDTC_RadioButton = false;
            //App.ViewModel.RefreshTopFilter("VDM");
        }

        private void TopDTCRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            // Add code to perform some action here.
            TopVDM_RadioButton = false;
            TopCNF_RadioButton = false;
            TopDTC_RadioButton = true;
            //App.ViewModel.RefreshTopFilter("DTC");
        }

        private void TopCNFRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            // Add code to perform some action here.
            TopVDM_RadioButton = false;
            TopCNF_RadioButton = true;
            TopDTC_RadioButton = false;
            //App.ViewModel.RefreshTopFilter("CNF");
        }

        /*
         * Filter Flop
         */

        private void FlopVDMRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            // Add code to perform some action here.
            FlopVDM_RadioButton = true;
            FlopCNF_RadioButton = false;
            FlopDTC_RadioButton = false;
            //App.ViewModel.RefreshFlopFilter("VDM");
        }

        private void FlopDTCRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            // Add code to perform some action here.
            FlopVDM_RadioButton = false;
            FlopCNF_RadioButton = false;
            FlopDTC_RadioButton = true;
            //App.ViewModel.RefreshFlopFilter("DTC");
        }

        private void FlopCNFRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            // Add code to perform some action here.
            FlopVDM_RadioButton = false;
            FlopCNF_RadioButton = true;
            FlopDTC_RadioButton = false;
            //App.ViewModel.RefreshFlopFilter("CNF");
        }


    }
}