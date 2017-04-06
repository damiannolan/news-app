using NewsApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Streams;

namespace NewsApp.Services
{
    public class StorageService
    {
        private List<Article> favourites;

        public StorageService()
        {
            this.favourites = new List<Article>();
        }

        /*
         *  http://bsubramanyamraju.blogspot.ie/2015/08/universal-apps-how-to-store-list-of.html 
         */
        public async void SaveArticles()
        {
            // Get a handle on the storage file
            StorageFile file = await ApplicationData.Current.LocalFolder.CreateFileAsync("MyList", CreationCollisionOption.ReplaceExisting);

            // Open File
            IRandomAccessStream raStream = await file.OpenAsync(FileAccessMode.ReadWrite);

            // Write the List<Article> to the file
            using (IOutputStream outStream = raStream.GetOutputStreamAt(0))
            {

                // Serialize the Session State. 

                DataContractSerializer serializer = new DataContractSerializer(typeof(List<Article>));

                serializer.WriteObject(outStream.AsStreamForWrite(), favourites);

                await outStream.FlushAsync();
                outStream.Dispose();
                raStream.Dispose();
            }
            
        }

        public async Task<List<Article>> GetArticlesFromStorage()
        {
            favourites = new List<Article>();

            // Serilize the List<Article> from the file
            var Serializer = new DataContractSerializer(typeof(List<Article>));
            using (var stream = await ApplicationData.Current.LocalFolder.OpenStreamForReadAsync("MyList"))
            {
                favourites = (List<Article>)Serializer.ReadObject(stream);
            }

            // Return the List<Article> of favourites
            return favourites;
        }

        public void AddToFavourites(Article article)
        {
            this.favourites.Add(article);
        }

    }
}
