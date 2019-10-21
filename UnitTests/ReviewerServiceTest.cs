using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using MovieRatingSystem.Core.ApplicationService;
using MovieRatingSystem.Core.ApplicationService.Services;
using MovieRatingSystem.Core.DomainService;
using MovieRatingSystem.Core.Entity;
using Xunit;

namespace UnitTests
{
    public class ReviewerServiceTest
    {
        [Theory]
        [InlineData(1, 3)]
        [InlineData(2, 1)]
        [InlineData(3, 0)]
        [InlineData(-3, 0)]
        public void GetNumberOfReviews_Test(int reviewerId, int expectedResult)
        {
            //Arrange
            List<IRating> allRatings = new List<IRating>();

            Mock<IRating> rating1 = new Mock<IRating>();
            rating1.Setup(rating => rating.Reviewer).Returns(1);
            rating1.Setup(rating => rating.Movie).Returns(1);
            rating1.Setup(rating => rating.Grade).Returns(3);
            allRatings.Add(rating1.Object);

            Mock<IRating> rating2 = new Mock<IRating>();
            rating2.Setup(rating => rating.Reviewer).Returns(2);
            rating2.Setup(rating => rating.Movie).Returns(1);
            rating2.Setup(rating => rating.Grade).Returns(5);
            allRatings.Add(rating2.Object);

            Mock<IRating> rating3 = new Mock<IRating>();
            rating3.Setup(rating => rating.Reviewer).Returns(1);
            rating3.Setup(rating => rating.Movie).Returns(2);
            rating3.Setup(rating => rating.Grade).Returns(1);
            allRatings.Add(rating3.Object);

            Mock<IRating> rating4 = new Mock<IRating>();
            rating4.Setup(rating => rating.Reviewer).Returns(1);
            rating4.Setup(rating => rating.Movie).Returns(3);
            rating4.Setup(rating => rating.Grade).Returns(5);
            allRatings.Add(rating4.Object);

            Mock<IRepository<IRating>> ratingRepository = new Mock<IRepository<IRating>>();
            ratingRepository.Setup(repo => repo.ReadAll()).Returns(allRatings);

            IReviewerService reviewerService = new ReviewerService(ratingRepository.Object);

            // Act
            var result = reviewerService.GetNumberOfReviews(reviewerId);

            //Assert
            Assert.Equal(expectedResult, result);

        }

        [Theory]
        [InlineData(1, 3)]
        [InlineData(2, 5)]
        [InlineData(3, 0)]
        [InlineData(-9, 0)]
        public void GetAverageReview_Test(int reviewerId, int expectedResult)
        {
            //Arrange
            List<IRating> allRatings = new List<IRating>();

            Mock<IRating> rating1 = new Mock<IRating>();
            rating1.Setup(rating => rating.Reviewer).Returns(1);
            rating1.Setup(rating => rating.Movie).Returns(1);
            rating1.Setup(rating => rating.Grade).Returns(3);
            allRatings.Add(rating1.Object);

            Mock<IRating> rating2 = new Mock<IRating>();
            rating2.Setup(rating => rating.Reviewer).Returns(2);
            rating2.Setup(rating => rating.Movie).Returns(1);
            rating2.Setup(rating => rating.Grade).Returns(5);
            allRatings.Add(rating2.Object);

            Mock<IRating> rating3 = new Mock<IRating>();
            rating3.Setup(rating => rating.Reviewer).Returns(1);
            rating3.Setup(rating => rating.Movie).Returns(2);
            rating3.Setup(rating => rating.Grade).Returns(1);
            allRatings.Add(rating3.Object);

            Mock<IRating> rating4 = new Mock<IRating>();
            rating4.Setup(rating => rating.Reviewer).Returns(1);
            rating4.Setup(rating => rating.Movie).Returns(3);
            rating4.Setup(rating => rating.Grade).Returns(5);
            allRatings.Add(rating4.Object);

            Mock<IRepository<IRating>> ratingRepository = new Mock<IRepository<IRating>>();
            ratingRepository.Setup(repo => repo.ReadAll()).Returns(allRatings);

            IReviewerService reviewerService = new ReviewerService(ratingRepository.Object);

            // Act
            var result = reviewerService.GetAverageReviewGrade(reviewerId);

            //Assert
            Assert.Equal(expectedResult, result);

        }

        [Theory]
        [InlineData(1, 3, 2)]
        [InlineData(1, 5, 1)]
        [InlineData(2, 5, 1)]
        [InlineData(2, 3, 0)]
        [InlineData(3, 3, 0)]
        [InlineData(1, 0, 0)]
        [InlineData(2, 6, 0)]
        public void GetGradeCount_Test(int reviewerId, int grade, int expectedResult)
        {
            //Arrange
            List<IRating> allRatings = new List<IRating>();

            Mock<IRating> rating1 = new Mock<IRating>();
            rating1.Setup(rating => rating.Reviewer).Returns(1);
            rating1.Setup(rating => rating.Movie).Returns(1);
            rating1.Setup(rating => rating.Grade).Returns(3);
            allRatings.Add(rating1.Object);

            Mock<IRating> rating2 = new Mock<IRating>();
            rating2.Setup(rating => rating.Reviewer).Returns(2);
            rating2.Setup(rating => rating.Movie).Returns(1);
            rating2.Setup(rating => rating.Grade).Returns(5);
            allRatings.Add(rating2.Object);

            Mock<IRating> rating3 = new Mock<IRating>();
            rating3.Setup(rating => rating.Reviewer).Returns(1);
            rating3.Setup(rating => rating.Movie).Returns(2);
            rating3.Setup(rating => rating.Grade).Returns(3);
            allRatings.Add(rating3.Object);

            Mock<IRating> rating4 = new Mock<IRating>();
            rating4.Setup(rating => rating.Reviewer).Returns(1);
            rating4.Setup(rating => rating.Movie).Returns(3);
            rating4.Setup(rating => rating.Grade).Returns(5);
            allRatings.Add(rating4.Object);

            Mock<IRepository<IRating>> ratingRepository = new Mock<IRepository<IRating>>();
            ratingRepository.Setup(repo => repo.ReadAll()).Returns(allRatings);

            IReviewerService reviewerService = new ReviewerService(ratingRepository.Object);

            // Act
            var result = reviewerService.GetGradeCount(reviewerId, grade);

            //Assert
            Assert.Equal(expectedResult, result);

        }

        [Fact]
        public void GetReviewedMoviesSorted_Test()
        {
            //Arrange
            List<IRating> allRatings = new List<IRating>();

            Mock<IRating> rating1 = new Mock<IRating>();
            rating1.Setup(rating => rating.Reviewer).Returns(1);
            rating1.Setup(rating => rating.Movie).Returns(1);
            rating1.Setup(rating => rating.Grade).Returns(3);
            rating1.Setup(rating => rating.Date).Returns(DateTime.Now);
            allRatings.Add(rating1.Object);

            Mock<IRating> rating2 = new Mock<IRating>();
            rating2.Setup(rating => rating.Reviewer).Returns(1);
            rating2.Setup(rating => rating.Movie).Returns(2);
            rating2.Setup(rating => rating.Grade).Returns(3);
            rating2.Setup(rating => rating.Date).Returns(DateTime.Now.AddDays(-1));
            allRatings.Add(rating2.Object);

            Mock<IRating> rating3 = new Mock<IRating>();
            rating3.Setup(rating => rating.Reviewer).Returns(1);
            rating3.Setup(rating => rating.Movie).Returns(3);
            rating3.Setup(rating => rating.Grade).Returns(5);
            allRatings.Add(rating3.Object);

            Mock<IRating> rating4 = new Mock<IRating>();
            rating4.Setup(rating => rating.Reviewer).Returns(2);
            rating4.Setup(rating => rating.Movie).Returns(1);
            rating4.Setup(rating => rating.Grade).Returns(1);
            allRatings.Add(rating4.Object);

            Mock<IRepository<IRating>> ratingRepository = new Mock<IRepository<IRating>>();
            ratingRepository.Setup(repo => repo.ReadAll()).Returns(allRatings);

            IReviewerService reviewerService = new ReviewerService(ratingRepository.Object);

            var expectedResult1 = new List<int>() { 3, 1, 2 };
            var expectedResult2 = new List<int>() { 1 };
            var expectedResult3 = new List<int>();

            // Act
            var result1 = reviewerService.GetReviewedMoviesSorted(1);
            var result2 = reviewerService.GetReviewedMoviesSorted(2);
            var result3 = reviewerService.GetReviewedMoviesSorted(3);

            //Assert
            Assert.Equal(expectedResult1, result1);
            Assert.Equal(expectedResult2, result2);
            Assert.Equal(expectedResult3, result3);

        }

        [Fact]
        public void GetTopReviewers_Test()
        {
            //Arrange
            List<IRating> allRatings = new List<IRating>();

            Mock<IRating> rating1 = new Mock<IRating>();
            rating1.Setup(rating => rating.Reviewer).Returns(1);
            rating1.Setup(rating => rating.Movie).Returns(1);
            rating1.Setup(rating => rating.Grade).Returns(3);
            rating1.Setup(rating => rating.Date).Returns(DateTime.Now);
            allRatings.Add(rating1.Object);

            Mock<IRating> rating2 = new Mock<IRating>();
            rating2.Setup(rating => rating.Reviewer).Returns(1);
            rating2.Setup(rating => rating.Movie).Returns(2);
            rating2.Setup(rating => rating.Grade).Returns(3);
            rating2.Setup(rating => rating.Date).Returns(DateTime.Now.AddDays(-1));
            allRatings.Add(rating2.Object);

            Mock<IRating> rating3 = new Mock<IRating>();
            rating3.Setup(rating => rating.Reviewer).Returns(2);
            rating3.Setup(rating => rating.Movie).Returns(3);
            rating3.Setup(rating => rating.Grade).Returns(5);
            allRatings.Add(rating3.Object);

            Mock<IRating> rating4 = new Mock<IRating>();
            rating4.Setup(rating => rating.Reviewer).Returns(2);
            rating4.Setup(rating => rating.Movie).Returns(1);
            rating4.Setup(rating => rating.Grade).Returns(1);
            allRatings.Add(rating4.Object);

            Mock<IRating> rating5 = new Mock<IRating>();
            rating5.Setup(rating => rating.Reviewer).Returns(3);
            rating5.Setup(rating => rating.Movie).Returns(1);
            rating5.Setup(rating => rating.Grade).Returns(5);
            allRatings.Add(rating5.Object);

            Mock<IRepository<IRating>> ratingRepository = new Mock<IRepository<IRating>>();
            ratingRepository.Setup(repo => repo.ReadAll()).Returns(allRatings);

            IReviewerService reviewerService = new ReviewerService(ratingRepository.Object);

            var expectedResult = new List<int>() { 1, 2 };

            // Act
            var result = reviewerService.GetTopReviewers();

            //Assert
            Assert.True(!expectedResult.Except(result).Any() && expectedResult.Count == result.Count);

        }
    }
}
