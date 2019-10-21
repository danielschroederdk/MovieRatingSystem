using System;
using System.Collections.Generic;
using MovieRatingSystem.Core.ApplicationService.Services;
using MovieRatingSystem.Core.DomainService;
using MovieRatingSystem.Core.Entity;
using MovieRatingSystem.Infrastructure.JSON.Repos;

namespace PerformanceTest
{
    public class PerformanceTestFixture : IDisposable
    {
        public IRepository<IRating> ratings { get; private set; }
        public MovieService movieService { get; private set; }
        public ReviewerService reviewerService { get; private set; }
        
        public PerformanceTestFixture()
        {
            ratings = new Repository();
            movieService = new MovieService(ratings);
            reviewerService = new ReviewerService(ratings);

        }
        
        public void Dispose()
        {
        }
    }
}