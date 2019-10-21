using System;
using System.Collections.Generic;
using System.Linq;
using MovieRatingSystem.Core.DomainService;
using MovieRatingSystem.Core.Entity;

namespace MovieRatingSystem.Core.ApplicationService.Services
{
    public class MovieService : IMovieService
    {
        private readonly IRepository<IRating> _ratingRepository;

        public MovieService(IRepository<IRating> ratingRepository)
        {
            _ratingRepository = ratingRepository;
        }

        public int GetReviewersCount(int movieId)
        {
            return _ratingRepository.ReadAll().
                Count(r => r.Movie == movieId);
        }

        public double GetAverageGrade(int movieId)
        {
            var movieRatings = _ratingRepository.ReadAll().
                Where(r => r.Movie == movieId).ToList();
            
            if (!movieRatings.Any())
            {
                return 0;
            }
            return movieRatings.Average(r => r.Grade);
        }

        public int GetGradeCount(int movieId, int grade)
        {
            return _ratingRepository.ReadAll().
                Count(r => r.Movie == movieId && r.Grade == grade);
        }

        public List<int> GetMoviesWithHighestTopGradeCount()
        {
            throw new NotImplementedException();
        }

        public List<int> GetMoviesWithHighestAverageGrade(int numberOfMovies)
        {
            return _ratingRepository.ReadAll()
                .OrderByDescending(rating => GetAverageGrade(rating.Movie))
                .Take(numberOfMovies)
                .Select(rating => rating.Movie)
                .Distinct()
                .ToList();
        }

        public List<int> GetReviewersSorted(int movieId)
        {
            return _ratingRepository.ReadAll().
                Where(r => r.Movie == movieId).
                OrderByDescending(r => r.Grade).
                ThenByDescending(r=>r.Date).
                Select(r => r.Reviewer).
                ToList();
        }
    }
}
