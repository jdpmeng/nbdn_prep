using System;
using System.Collections.Generic;
using nothinbutdotnetprep.infrastructure;
using nothinbutdotnetprep.infrastructure.searching;

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
            return all_movies_matching(new AnonymousCriteria<Movie>(x => true));
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

        public delegate bool Predicate<T>(T item);

        public IEnumerable<Movie> all_movies_matching(Criteria<Movie> criteria)
        {
            return movies.all_items_matching(criteria);
        }

        bool is_by_pixar(Movie movie)
        {
            return movie.production_studio == ProductionStudio.Pixar;
        }

        public IEnumerable<Movie> all_movies_published_by_pixar()
        {
            return
                all_movies_matching(
                    new AnonymousCriteria<Movie>(movie => movie.production_studio == ProductionStudio.Pixar));
        }

        public IEnumerable<Movie> all_movies_published_between_years(int startingYear, int endingYear)
        {
            return
                all_movies_matching(
                    new AnonymousCriteria<Movie>(Movie.is_published_between(startingYear, endingYear).Invoke));
        }

        public IEnumerable<Movie> all_movies_published_by_pixar_or_disney()
        {
            return all_movies_matching(Movie.is_published_by_pixar_or_disney());

        }

        public IEnumerable<Movie> all_movies_not_published_by_pixar()
        {
            return all_movies_matching(Movie.is_not_published_by_pixar());
        }

        public IEnumerable<Movie> all_movies_published_after(int year)
        {
            return all_movies_matching(Movie.is_published_after(year));
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

        public IEnumerable<Movie> all_kid_movies()
        {
            foreach (var m in movies)
                if (m.genre == Genre.kids)
                    yield return m;
        }

        public IEnumerable<Movie> all_action_movies()
        {
            foreach (var m in movies)
                if (m.genre == Genre.action)
                    yield return m;
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