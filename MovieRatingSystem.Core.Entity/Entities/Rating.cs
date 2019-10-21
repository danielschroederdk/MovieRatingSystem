using System;
namespace MovieRatingSystem.Core.Entity
{
    public class Rating : IRating
    {
        public int Reviewer { get; set; }

        public int Movie { get; set; }

        public int Grade { get; set; }

        public DateTime Date { get; set; }

        public Rating(int reviewerId, int movieId, int grade, DateTime date)
        {
            Reviewer = reviewerId;
            Movie = movieId;
            Grade = grade;
            Date = date;
        }

        public Rating()
        {
            
        }
    }
}
