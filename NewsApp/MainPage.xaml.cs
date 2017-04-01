using NewsApp.Models;
using NewsApp.Services;
using System;
using System.Collections.Generic;
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
        private List<NewsSource> NewsSources;

        public MainPage()
        {
            this.InitializeComponent();

            newsService = new NewsService();
            loadNewsSources();
        }
        
/*        private async void button_Click(object sender, RoutedEventArgs e)
        {
            var sources = await newsService.GetSources();
            this.NewsSources = sources.Sources;
        }
*/
        private async void loadNewsSources()
        {
            var sources = await newsService.GetSources();
            this.NewsSources = sources.Sources;
        }

        private void ListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            
        }
    }
}
