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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace NewsApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        private INewsService newsService;
        private ObservableCollection<NewsSource> newsSources;
        
        public MainPage()
        {
            this.InitializeComponent();

            newsService = new NewsService();
            newsSources = new ObservableCollection<NewsSource>();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // Call LoadNewsSources() to hit the NewsApi
            LoadNewsSources();
          
            base.OnNavigatedTo(e);

        }

        private async void LoadNewsSources()
        {
            // Call GetSources() and await the task
            var sources = await newsService.GetSources();

            // Clear() the newSources ObservableCollection
            // So that if the page is navigated to for a 2nd time there will not be duplicated content
            newsSources.Clear();

            // Add each NewsSource to the ObservableCollection
            foreach (var source in sources.Sources)
            {
                newsSources.Add(source);
            }

            // newsSources = sources.Sources /*** Not working like this - UI won't update. Have to invoke .Add() ***/
        }

        private void ListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            NewsSource source = (NewsSource) e.ClickedItem;

            // Navigate to the articles page and pass the source Id to fetch appropriate content
            this.Frame.Navigate(typeof(ArticlesPage), source.Id);
        }
    }
}
