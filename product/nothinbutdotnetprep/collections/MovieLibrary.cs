using System;
using System.Collections.Generic;
using nothinbutdotnetprep.infrastructure;

namespace nothinbutdotnetprep.collections
{
    public class MovieLibrary
    {
        IList<Movie> movies;

        public MovieLibrary(IList<Movie> list_of_movies)
        {
            this.movies = list_of_movies;
        }

        public IEnumerable<Movie> all_movies()
        {
            return movies.one_at_a_time();
        }

        public void add(Movie movie)
        {
            if (already_contains(movie)) return;

            movies.Add(movie);
        }

        bool already_contains(Movie movie)
        {
            return movies.Contains(movie);
        }

        public IEnumerable<Movie> sort_all_movies_by_title_ascending
        {
            get
            {
                var dict = new SortedDictionary<String, Movie>();
                foreach (var m in movies)
                    dict.Add(m.title, m);
                var l = new List<Movie>();
                foreach (var key in dict.Keys)
                {
                    l.Add(dict[key]);
                }
                return l;
            }
        }

        public IEnumerable<Movie> sort_all_movies_by_title_descending
        {
            get
            {
                var dict = new SortedDictionary<String, Movie>();
                foreach (var m in movies)
                    dict.Add(m.title, m);

                var l = new List<Movie>();

                foreach (var key in dict.Keys)
                {
                    l.Add(dict[key]);
                }
                var marr = l.ToArray();
                Array.Reverse(marr);

                return marr;
            }
        }

        public IEnumerable<Movie> sort_all_movies_by_movie_studio_and_year_published()
        {
            var moviesSortedByYearAsc = this.sort_all_movies_by_date_published_ascending();
            var moviesSortedByStudioAndYear = new List<Movie>();

            var studios = new[]
            {
                ProductionStudio.MGM,
                ProductionStudio.Pixar,
                ProductionStudio.Dreamworks,
                ProductionStudio.Universal,
                ProductionStudio.Disney
            };

            for (var i = 0; i < studios.Length; i++)
            {
                var s = studios[i];
                foreach (var m in moviesSortedByYearAsc)
                {
                    if (m.production_studio == s)
                        moviesSortedByStudioAndYear.Add(m);
                }
            }

            return moviesSortedByStudioAndYear;
        }

        public IEnumerable<Movie> sort_all_movies_by_date_published_descending()
        {
            var m = new List<Movie>(sort_all_movies_by_date_published_ascending());
            var marr = m.ToArray();
            Array.Reverse(marr);
            return marr;
        }

        public IEnumerable<Movie> sort_all_movies_by_date_published_ascending()
        {
            var dict = new SortedDictionary<DateTime, Movie>();

            foreach (var m in movies)
                dict.Add(m.date_published, m);

            var l = new List<Movie>();

            foreach (var key in dict.Keys)
                l.Add(dict[key]);

            var marr = l.ToArray();

            return marr;
        }
    }
}