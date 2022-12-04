using HtmlAgilityPack;
using System;
using System.Collections;

namespace DemoMovie.UnitTest
{
    internal class Program
    {
        static void Main(string[] args)
        {

            GetNowPlayingMovie();
            GetUpcomingMovie();
            GetTopRatedMovie();

            Console.ReadLine();
        }


        static void GetNowPlayingMovie()
        {
            var linkName = "https://www.themoviedb.org/movie/now-playing";
            var nodeName = "//h2/a[contains(@href,'/movie/')]";

            var playingMovieList = GetMovie(linkName, nodeName);
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("Playing Movie List");
            for (int i = 0; i < playingMovieList.Count; i++)
            {
                Console.WriteLine(i + 1 + "-" + playingMovieList[i]);
            }

        }

        static void GetUpcomingMovie()
        {
            var linkName = "https://www.themoviedb.org/movie/upcoming";
            var nodeName = "//h2/a[contains(@href,'/movie/')]";

            var upcomingMovieList = GetMovie(linkName, nodeName);
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("Upcoming Movie List");
            for (int i = 0; i < upcomingMovieList.Count; i++)
            {
                Console.WriteLine(i + 1 + "-" + upcomingMovieList[i]);
            }

        }

        static void GetTopRatedMovie()
        {
            var linkName = "https://www.themoviedb.org/movie/top-rated";
            var nodeName = "//h2/a[contains(@href,'/movie/')]";

            var topDatedMovieList = GetMovie(linkName, nodeName);
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("Top Rated Movie List");
            for (int i = 0; i < topDatedMovieList.Count; i++)
            {
                Console.WriteLine(i+1+"-"+topDatedMovieList[i]);
            }

        }



        /// <summary>
        /// Verilecek link için node/nodları getirecek olan method
        /// </summary>
        /// <param name="link"></param>
        /// <param name="categoryName"></param>
        /// <param name="nodeDescription"></param>
        private static ArrayList GetMovie(string link, string nodeDescription)
        {
            var document = new HtmlWeb().Load(link);
            var movieTitles = document.DocumentNode.SelectNodes(nodeDescription);
            ArrayList arrayList = new ArrayList();
            foreach (var movieTitleItem in movieTitles)
            {
                //Console.WriteLine(movieTitleItem.InnerText);
                arrayList.Add(movieTitleItem.InnerText);

            }

            return arrayList;
        }

        private static void ComingWebTag()
        {
            //birden fazla film kategorisi getirilmelidir
            //popüler,
            //https://www.themoviedb.org/tv/airing-today
            //https://www.themoviedb.org/tv/on-the-air
            //https://www.themoviedb.org/tv/top-rated

            var document = new HtmlWeb().Load("https://www.themoviedb.org/movie");
            var title = document.DocumentNode.SelectSingleNode("//*[@id='media_v4']/div/div/div[1]/h3");

            //Console.WriteLine(title.InnerText);

            var movieTitle1 = document.DocumentNode.SelectSingleNode("//a[contains(@class,'image')]");
            var movieRelaseDate = document.DocumentNode.SelectNodes("//*[@id='page_1']/div[1]/div[2]/p");


            Console.WriteLine("----");

            if (movieTitle1 != null)
            {
                Console.WriteLine(movieTitle1.InnerText);
            }



            var movieTitles = document.DocumentNode.SelectNodes("//h2/a[contains(@href,'/movie/')]");
            var deger = document.DocumentNode.ChildAttributes("a");

            foreach (var item in movieTitles)
            {
                Console.WriteLine("-------------------");

                Console.WriteLine(item.Attributes["title"].Value);
            }


        }



    }
}
