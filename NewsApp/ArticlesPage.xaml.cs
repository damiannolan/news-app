using NewsApp.Models;
using NewsApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private INewsService newsService;
        private ObservableCollection<Article> articles;

        public ArticlesPage()
        {
            this.InitializeComponent();

            newsService = new NewsService();
            articles = new ObservableCollection<Article>();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var sourceId = e.Parameter.ToString();

            LoadArticles(sourceId);

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
                articles.Add(article);
            }
        }
    }
}
