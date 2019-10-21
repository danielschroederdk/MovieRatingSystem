using MovieRatingSystem.Core.ApplicationService.Services;
using MovieRatingSystem.Core.Entity.Entities;
using Xunit;

namespace PerformanceTest
{
    public class ReviewerService_PerformanceTests : IClassFixture<PerformanceTestFixture>
    {
        private readonly ReviewerService _reviewerService;
        
        public ReviewerService_PerformanceTests(PerformanceTestFixture dbFixture)
        {
            _reviewerService = dbFixture.reviewerService;
        }
        
        [Fact]
        public void GetGradeCount_Performance_Test()
        {
            Assert.True(Executioner.DO(() => _reviewerService.GetGradeCount(1,5)));
        }
        
        [Fact]
        public void GetNumberOfReviews_Performance_Test()
        {
            Assert.True(Executioner.DO(() => _reviewerService.GetNumberOfReviews(1)));
        }
        
        [Fact]
        public void GetAverageReviewGrade_Performance_Test()
        {
            Assert.True(Executioner.DO(() => _reviewerService.GetAverageReviewGrade(1)));
        }
        
        [Fact]
        public void GetReviewedMoviesSorted_Performance_Test()
        {
            Assert.True(Executioner.DO(() => _reviewerService.GetReviewedMoviesSorted(1)));
        }
        
        /*
        [Fact]
        public void GetTopReviewers_Performance_Test()
        {
            Assert.True(Executioner.DO(() => _reviewerService.GetTopReviewers()));
        }
        */
    }
}