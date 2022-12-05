using HtmlAgilityPack;
using System;
using System.Collections;
using System.ServiceProcess;
using MovieDemo.GetMovieService.Model;


namespace MovieDemo.GetMovieService
{
    public partial class Service1 : ServiceBase
    {

        private System.Timers.Timer timer;
        DemoMovie_DBEntities db = new DemoMovie_DBEntities()
;
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

            Console.WriteLine("-------------");
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

        private int AddMovie(string movieName, int movieCategoryId)
        {
            try
            {
                var getMovie = db.Movie.Find(movieName);

                if (getMovie == null)
                {

                    Movie movie = new Movie();
                    movie.MovieName = movieName;
                    movie.MovieCategoryId = movieCategoryId;
                    movie.AverageScore = 0;
                    movie.CreateDate = DateTime.Now;
                    db.Movie.Add(movie);

                    if (db.SaveChanges() > 0)
                    {
                        return ResponseType.DataEkendi.GetHashCode();
                    }
                    return ResponseType.EklenirkenHata.GetHashCode();
                }
                return ResponseType.DataMevcut.GetHashCode();
            }
            catch (Exception)
            {
                return ResponseType.VeriEklerkenHataVerdi.GetHashCode();
            }
        }

        private int AddMovieCategory( string movieCategoryName)
        {
            try
            {
                var getMovieCategory = db.Movie.Find(movieCategoryName);

                if (getMovieCategory == null)
                {
                    MovieCategory movieCategory = new MovieCategory();
                    movieCategory.CategoryName = movieCategoryName;
                    movieCategory.CreateDate = DateTime.Now;
                    db.MovieCategory.Add(movieCategory);

                    if (db.SaveChanges() > 0)
                    {
                        return ResponseType.DataEkendi.GetHashCode();
                    }
                    return ResponseType.EklenirkenHata.GetHashCode();
                }
                return ResponseType.DataMevcut.GetHashCode();
            }
            catch (Exception)
            {
                return ResponseType.VeriEklerkenHataVerdi.GetHashCode();
            }
        }



        void GetNowPlayingMovie()
        {
            try
            {
                var linkName = "https://www.themoviedb.org/movie/now-playing";
                var nodeName = "//h2/a[contains(@href,'/movie/')]";

                var playingMovieList = GetMovie(linkName, nodeName);
                Console.WriteLine("-------------------------------------------");
                Console.WriteLine("Playing Movie List");

                AddMovieCategory(MovieCategoryEnum.NowPlaying.ToString());

                for (int i = 0; i < playingMovieList.Count; i++)
                {
                    //Console.WriteLine(i + 1 + "-" + playingMovieList[i]);
                    AddMovie(playingMovieList[i].ToString(), MovieCategoryEnum.NowPlaying.GetHashCode());
                }
            }
            catch (Exception)
            {

                ResponseType.KontrolEdinizHataOlustu.GetHashCode();
            }

        }

        void GetUpcomingMovie()
        {
            try
            {
                var linkName = "https://www.themoviedb.org/movie/upcoming";
                var nodeName = "//h2/a[contains(@href,'/movie/')]";

                var upcomingMovieList = GetMovie(linkName, nodeName);
                Console.WriteLine("-------------------------------------------");
                Console.WriteLine("Upcoming Movie List");
                AddMovieCategory(MovieCategoryEnum.Upcoming.ToString());


                for (int i = 0; i < upcomingMovieList.Count; i++)
                {
                   // Console.WriteLine(i + 1 + "-" + upcomingMovieList[i]);
                    AddMovie(upcomingMovieList[i].ToString(), MovieCategoryEnum.Upcoming.GetHashCode());

                }
            }
            catch (Exception)
            {

                ResponseType.KontrolEdinizHataOlustu.GetHashCode();
            }

        }

        void GetTopRatedMovie()
        {
            try
            {
                var linkName = "https://www.themoviedb.org/movie/top-rated";
                var nodeName = "//h2/a[contains(@href,'/movie/')]";

                var topDatedMovieList = GetMovie(linkName, nodeName);
                Console.WriteLine("-------------------------------------------");
                Console.WriteLine("Top Rated Movie List");

                AddMovieCategory(MovieCategoryEnum.TopRated.ToString());


                for (int i = 0; i < topDatedMovieList.Count; i++)
                {
                    Console.WriteLine(i + 1 + "-" + topDatedMovieList[i]);
                    AddMovie(topDatedMovieList[i].ToString(), MovieCategoryEnum.TopRated.GetHashCode());

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
