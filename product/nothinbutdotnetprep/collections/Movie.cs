using System;
using nothinbutdotnetprep.infrastructure.searching;

namespace nothinbutdotnetprep.collections
{
    public class Movie  : IEquatable<Movie>
    {
        public string title { get; set; }
        public ProductionStudio production_studio { get; set; }
        public Genre genre { get; set; }
        public int rating { get; set; }
        public DateTime date_published { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as Movie);
        }

        public bool Equals(Movie other)
        {
            if (other == null) return false;

            return ReferenceEquals(this,other) || is_equal_to_non_null_instance_of(other);
        }

        bool is_equal_to_non_null_instance_of(Movie other)
        {
            return this.title.Equals(other.title);
        }

        public override int GetHashCode()
        {
            return title.GetHashCode();
        }

        public static SearchCriteria is_published_between(int startingYear, int endingYear)
        {
            return m => m.date_published.Year >= startingYear && m.date_published.Year <= endingYear;
        }

        public static Criteria<Movie> is_in_genre(Genre genre)
        {
            return new IsInGenre(genre);
        }

        public static Criteria<Movie> is_published_by(ProductionStudio production_studio)
        {
            return new IsPublishedBy(production_studio);
        }

        public static Criteria<Movie> is_not_published_by_pixar()
        {
            return new NotCriteria<Movie>(is_published_by(ProductionStudio.Pixar));

        }

        public static Criteria<Movie> is_published_by_pixar(Movie m)
        {
            return new IsPublishedBy(ProductionStudio.Pixar);
        }

        public static Criteria<Movie> is_published_by_pixar_or_disney()
        {
            return is_published_by(ProductionStudio.Pixar)
                .or(is_published_by(ProductionStudio.Disney));

        }

        public static Criteria<Movie> is_published_after(int year)
        {
            return new AnonymousCriteria<Movie>(movie => movie.date_published.Year > year);
        }
    }
}