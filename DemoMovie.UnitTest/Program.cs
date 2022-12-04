using HtmlAgilityPack;
using System;

namespace DemoMovie.UnitTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        private static void LoadHTML()
        {
            var documentHtml = new HtmlWeb().Load("https://www.themoviedb.org/movie/now-playing");
            //documentHtml.LoadHtml();
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
            Console.WriteLine("----");
            if (movieTitle1 != null)
            {
                Console.WriteLine(movieTitle1.InnerText);
            }



            var movieTitles = document.DocumentNode.SelectNodes("//h2/a[contains(@href,'/movie/')]");
            var x = document.DocumentNode.ChildAttributes("a");

            foreach (var item in movieTitles)
            {
                Console.WriteLine("-------------------");

                Console.WriteLine(item.Attributes["title"].Value);
            }


        }
    }
}
