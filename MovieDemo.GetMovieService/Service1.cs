using HtmlAgilityPack;
using System;
using System.Collections;
using System.ServiceProcess;


namespace MovieDemo.GetMovieService
{
    public partial class Service1 : ServiceBase
    {

        private System.Timers.Timer timer;
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            timer = new System.Timers.Timer();
            timer.Interval = (60000);
            timer.AutoReset = true;
            timer.Enabled = true;
            timer.Start();
            timer.Elapsed += new System.Timers.ElapsedEventHandler(DemoMovieService);

            Console.WriteLine("--");
            Console.ReadLine();
        }

        protected override void OnStop()
        {
            //end

        }

        private void DemoMovieService(object sender, EventArgs e)
        {
            GetNowPlayingMovie();
            GetUpcomingMovie();
            GetTopRatedMovie();

        }

        static void GetNowPlayingMovie()
        {
            try
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
            catch (Exception)
            {

                throw;
            }

        }

        static void GetUpcomingMovie()
        {
            try
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
            catch (Exception)
            {

                throw;
            }

        }

        static void GetTopRatedMovie()
        {
            try
            {
                var linkName = "https://www.themoviedb.org/movie/top-rated";
                var nodeName = "//h2/a[contains(@href,'/movie/')]";

                var topDatedMovieList = GetMovie(linkName, nodeName);
                Console.WriteLine("-------------------------------------------");
                Console.WriteLine("Top Rated Movie List");
                for (int i = 0; i < topDatedMovieList.Count; i++)
                {
                    Console.WriteLine(i + 1 + "-" + topDatedMovieList[i]);
                }
            }
            catch (Exception)
            {

                throw;
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
    }
}
