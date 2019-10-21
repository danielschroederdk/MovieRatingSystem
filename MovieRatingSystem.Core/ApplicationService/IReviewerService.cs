using System;
using System.Collections.Generic;

namespace MovieRatingSystem.Core.ApplicationService
{
    public interface IReviewerService
    {
        int GetNumberOfReviews(int reviewerId);

        double GetAverageReviewGrade(int reviewerId);

        int GetGradeCount(int reviewerId, int grade);

        List<int> GetReviewedMoviesSorted(int reviewerId);

        List<int> GetTopReviewers();
    }
}
