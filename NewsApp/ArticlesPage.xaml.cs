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
    public sealed partial class ArticlesPage : Page
    {
        private StorageService storageService;
        private INewsService newsService;
        private ObservableCollection<Article> articles;
        private NewsSource source;

        public ArticlesPage()
        {
            this.InitializeComponent();

            storageService = new StorageService();
            newsService = new NewsService();
            articles = new ObservableCollection<Article>();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            source = (NewsSource) e.Parameter;
            LoadArticles(source.Id);

            try
            {
                List<Article> favourites = await storageService.GetArticlesFromStorage();
            } catch (FileNotFoundException exc)
            {
                // Handle exception accordingly
                // Debug.WriteLine();
            }
            
            base.OnNavigatedTo(e);
        }

        private async void LoadArticles(string sourceId)
        {
            // Call GetArticles() and await the task
            var articlesList = await newsService.GetArticles(sourceId);

            // Clear() the articles ObservableCollection
            // So that if the page is navigated to for a 2nd time there will not be duplicated content
            articles.Clear();

            // Add each NewsSource to the ObservableCollection
            foreach (var article in articlesList.Articles)
            {
                // If the UrlToImage is null then replace with a random image
                if(string.IsNullOrEmpty(article.UrlToImage))
                {
                    //article.UrlToImage = "http://placehold.it/350x150";
                    article.UrlToImage = "https://unsplash.it/200/300/?random";
                }

                articles.Add(article);
            }
        }

        private void ListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            Article article = (Article) e.ClickedItem;

            storageService.AddToFavourites(article);
            storageService.SaveArticles();   
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }
    }
}
