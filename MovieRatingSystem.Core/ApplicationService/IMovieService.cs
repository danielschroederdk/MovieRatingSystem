using System;
using System.Collections.Generic;

namespace MovieRatingSystem.Core.ApplicationService
{
    public interface IMovieService
    {
        int GetReviewersCount(int movieId);

        double GetAverageGrade(int movieId);

        int GetGradeCount(int movieId, int grade);

        List<int> GetMoviesWithHighestTopGradeCount();

        List<int> GetMoviesWithHighestAverageGrade(int numberOfMovies);

        List<int> GetReviewersSorted(int movieId);

    }
}
