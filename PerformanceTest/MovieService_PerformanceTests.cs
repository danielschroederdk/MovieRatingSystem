using System;
using System.Diagnostics;
using MovieRatingSystem.Core.ApplicationService.Services;
using MovieRatingSystem.Core.DomainService;
using MovieRatingSystem.Core.Entity;
using MovieRatingSystem.Core.Entity.Entities;
using MovieRatingSystem.Infrastructure.JSON.Repos;
using Xunit;

namespace PerformanceTest
{
    public class MovieService_PerformanceTests : IClassFixture<PerformanceTestFixture>
    {
        private readonly MovieService _movieService;
        
        public MovieService_PerformanceTests(PerformanceTestFixture dbFixture)
        {
            _movieService = dbFixture.movieService;
        }
        
        [Fact]
        public void GetGradeCount_Performance_Test()
        {
            Assert.True(Executioner.DO(() => _movieService.GetGradeCount(1,5)));
        }
        
        [Fact]
        public void GetReviewersCount_Performance_Test()
        {
            Assert.True(Executioner.DO(() => _movieService.GetReviewersCount(1)));
        }
        
        [Fact]
        public void GetAverageGrade_Performance_Test()
        {
            Assert.True(Executioner.DO(() => _movieService.GetAverageGrade(1)));
        }
        
        
        /*[Fact]
        public void GetMoviesWithHighestAverageGrade_Performance_Test()
        {
            Assert.True(Executioner.DO(() => _movieService.GetMoviesWithHighestAverageGrade(5)));
        }*/
        
        
        [Fact]
        public void GetReviewersSorted_Performance_Test()
        {
            Assert.True(Executioner.DO(() => _movieService.GetReviewersSorted(1)));
        }
    }
}