using System;
using System.Collections.Generic;
using System.Linq;
using MovieRatingSystem.Core.DomainService;
using MovieRatingSystem.Core.Entity;

namespace MovieRatingSystem.Core.ApplicationService.Services
{
    public class ReviewerService : IReviewerService
    {
        private readonly IRepository<IRating> _ratingRepository;

        public ReviewerService(IRepository<IRating> ratingRepository)
        {
            _ratingRepository = ratingRepository;
        }

        public int GetNumberOfReviews(int reviewerId)
        {
            return _ratingRepository.ReadAll().
                 Where(r => r.Reviewer == reviewerId).
                 Count();
        }     

        public double GetAverageReviewGrade(int reviewerId)
        {
            var reviewedMovies = _ratingRepository.ReadAll().
                Where(r => r.Reviewer == reviewerId);

            if(!reviewedMovies.Any())
            {
                return 0;
            }
            return reviewedMovies.Average(r => r.Grade);
        }

        public int GetGradeCount(int reviewerId, int grade)
        {
            return _ratingRepository.ReadAll().
                Count(r => r.Reviewer == reviewerId && r.Grade == grade);
        }

        public List<int> GetReviewedMoviesSorted(int reviewerId)
        {
            return _ratingRepository.ReadAll().
                Where(r => r.Reviewer == reviewerId).
                OrderByDescending(r => r.Grade).
                ThenByDescending(r => r.Date).
                Select(r => r.Movie).
                ToList();
        }

        public List<int> GetTopReviewers()
        {
            throw new NotImplementedException();
        }
    }
}
