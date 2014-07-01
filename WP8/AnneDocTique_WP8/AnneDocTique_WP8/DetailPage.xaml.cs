using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace AnneDocTique_WP8
{
    public partial class DetailPage : PhoneApplicationPage
    {
        public DetailPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            TbContent.Text = NavigationContext.QueryString["content"];
            TbNote1.Text = NavigationContext.QueryString["note1"];
            TbNote2.Text = NavigationContext.QueryString["note2"];
        }
    }
}