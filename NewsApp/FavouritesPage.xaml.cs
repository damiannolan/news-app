using NewsApp.Models;
using NewsApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace NewsApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class FavouritesPage : Page
    {
        ObservableCollection<Article> favourites;
        StorageService storageService;

        public FavouritesPage()
        {
            this.InitializeComponent();
            favourites = new ObservableCollection<Article>();
            storageService = new StorageService();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            textBlock.Text = "";
            try
            {
                List<Article> favouritesList = await storageService.GetArticlesFromStorage();

                foreach (var article in favouritesList)
                {
                    favourites.Add(article);
                }
            } catch (Exception exc)
            {
                textBlock.Text = "No Favourites Found";

                //favourites.Add(new Article { Author = " ", Title = "No favourites found", Description = " ", UrlToImage = "https://unsplash.it/200/300/?random", PublishedAt = " ", Url = " " });
            }
            
            base.OnNavigatedTo(e);
        }

        private void ListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            
        }
    }
}
