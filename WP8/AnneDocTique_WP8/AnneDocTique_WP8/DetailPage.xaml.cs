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
using Microsoft.Phone.Tasks;
using AnneDocTique_WP8.Databases;

namespace AnneDocTique_WP8
{
    public partial class DetailPage : PhoneApplicationPage
    {

        private AnecdoteDB AnecdoteDB;

        public DetailPage()
        {
            InitializeComponent();

            AnecdoteDB = new AnecdoteDB(AnecdoteDB.DBConnectionString);
            DataContext = App.VDMCommentViewModel;
            
            BuildLocalizedApplicationBar();
        }


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (!App.VDMCommentViewModel.IsDataLoaded)
            {
                App.VDMCommentViewModel.LoadData();
            }

            base.OnNavigatedTo(e);
            TbContent.Text = NavigationContext.QueryString["content"];
            TbNote1.Text = NavigationContext.QueryString["note1"];
            TbNote2.Text = NavigationContext.QueryString["note2"];
            TbAuthor.Text = NavigationContext.QueryString["author"];
            TbDate.Text = NavigationContext.QueryString["date"];

            title.Text = "Commentaires " + NavigationContext.QueryString["type"] + " #" + NavigationContext.QueryString["id"];
        }


        private void BuildLocalizedApplicationBar()
        {
            
            ApplicationBar = new ApplicationBar();

            ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/Images/favs.addto.png", UriKind.Relative));

            appBarButton.Text = "Ajouter aux favoris";
            appBarButton.Click += appBarButton_Click;
            ApplicationBar.Buttons.Add(appBarButton);

            ApplicationBar.Opacity = 0.5;

            
            ApplicationBarMenuItem appBarMenuItemShareRS = new ApplicationBarMenuItem("Partager sur réseaux sociaux");
            appBarMenuItemShareRS.Click += appBarMenuItemShareRS_Click;
            ApplicationBar.MenuItems.Add(appBarMenuItemShareRS);

            ApplicationBarMenuItem appBarMenuItemShareEmail = new ApplicationBarMenuItem("Partager par email");
            appBarMenuItemShareEmail.Click += appBarMenuItemShareEmail_Click;
            ApplicationBar.MenuItems.Add(appBarMenuItemShareEmail);

            ApplicationBarMenuItem appBarMenuItemShareSMS = new ApplicationBarMenuItem("Partager par sms");
            appBarMenuItemShareSMS.Click += appBarMenuItemShareSMS_Click;
            ApplicationBar.MenuItems.Add(appBarMenuItemShareSMS);


            

        }

        // Ajout favoris
        private void appBarButton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(NavigationContext.QueryString["id"]);
            var req = AnecdoteDB.FavorisDB.Where(ane => ane.IdFav == id);

            if (req.Count() > 0)
            {
                MessageBox.Show("Anecdote déjà présente dans vos favoris !");
            }
            else
            {
                AnecdoteDB.FavorisDB.InsertOnSubmit(
                    new Favoris
                    {
                        IdFav = id,
                        Content = NavigationContext.QueryString["content"],
                        Type = NavigationContext.QueryString["type"],
                        Date = NavigationContext.QueryString["date"],
                        Author = NavigationContext.QueryString["author"],
                        Vote1 = NavigationContext.QueryString["note1"],
                        Vote2 = NavigationContext.QueryString["note2"]
                    }
                );
                AnecdoteDB.SubmitChanges();
                MessageBox.Show("Anecdote ajouté dans vos favoris !");
                App.ViewModel.LoadFavoris();
            }
        }

        private void appBarMenuItemShareSMS_Click(object sender, EventArgs e)
        {
            SmsComposeTask smsComposeTask = new SmsComposeTask()
            {
                Body = NavigationContext.QueryString["content"]
            };

            smsComposeTask.Show();
        }

        private void appBarMenuItemShareEmail_Click(object sender, EventArgs e)
        {
            EmailComposeTask emailComposeTask = new EmailComposeTask()
            {
                Subject = NavigationContext.QueryString["type"] + "#" + NavigationContext.QueryString["id"],
                Body = NavigationContext.QueryString["content"]
            };

            emailComposeTask.Show();
        }

        private void appBarMenuItemShareRS_Click(object sender, EventArgs e)
        {
            ShareStatusTask shareStatusTask = new ShareStatusTask();
            shareStatusTask.Status = NavigationContext.QueryString["content"];
            shareStatusTask.Show();
        }
    }
}