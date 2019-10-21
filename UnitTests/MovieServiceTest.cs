using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Moq;
using MovieRatingSystem.Core.ApplicationService;
using MovieRatingSystem.Core.ApplicationService.Services;
using MovieRatingSystem.Core.DomainService;
using MovieRatingSystem.Core.Entity;
using Xunit;

namespace UnitTests
{
    public class MovieServiceTest
    {

        [Theory]
        [InlineData(1, 3)]
        [InlineData(2, 1)]
        [InlineData(3, 0)]
        [InlineData(-13, 0)]
        /*
         * Validating reviewers-count of exact movies by movieId.
        */
        public void GetReviewersCount_Test(int movieId, int expectedResult)
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
            rating4.Setup(rating => rating.Reviewer).Returns(3);
            rating4.Setup(rating => rating.Movie).Returns(1);
            rating4.Setup(rating => rating.Grade).Returns(1);
            allRatings.Add(rating4.Object);

            Mock<IRepository<IRating>> ratingRepository = new Mock<IRepository<IRating>>();
            ratingRepository.Setup(repo => repo.ReadAll()).Returns(allRatings);

            IMovieService movieService = new MovieService(ratingRepository.Object);

            // Act
            var result = movieService.GetReviewersCount(movieId);

            //Assert
            Assert.Equal(expectedResult, result);                     
        }
        
        
        [Theory]
        [InlineData(1,3)]
        [InlineData(2,1)]
        [InlineData(3,0)]
        [InlineData(-3, 0)]
        public void GetAverageGrade_Test(int movieId, int expectedResult)
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
            rating4.Setup(rating => rating.Reviewer).Returns(3);
            rating4.Setup(rating => rating.Movie).Returns(1);
            rating4.Setup(rating => rating.Grade).Returns(1);
            allRatings.Add(rating4.Object);

            Mock<IRepository<IRating>> ratingRepository = new Mock<IRepository<IRating>>();
            ratingRepository.Setup(repo => repo.ReadAll()).Returns(allRatings);

            IMovieService movieService = new MovieService(ratingRepository.Object);

            //Act
            var result = movieService.GetAverageGrade(movieId);

            //Assert
            Assert.Equal(expectedResult,result);
        }

        [Theory]
        [InlineData(1, 3, 2)]
        [InlineData(1, 5, 1)]
        [InlineData(1, 4, 0)]
        [InlineData(2, 5, 1)]
        [InlineData(2, 1, 0)]
        [InlineData(3, 3, 0)]
        [InlineData(1, 0, 0)]
        [InlineData(3, 6, 0)]
        public void GetGradeCount_Test(int movieId, int grade, int expectedResult)
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
            rating2.Setup(rating => rating.Grade).Returns(3);
            allRatings.Add(rating2.Object);

            Mock<IRating> rating3 = new Mock<IRating>();
            rating3.Setup(rating => rating.Reviewer).Returns(3);
            rating3.Setup(rating => rating.Movie).Returns(1);
            rating3.Setup(rating => rating.Grade).Returns(5);
            allRatings.Add(rating3.Object);

            Mock<IRating> rating4 = new Mock<IRating>();
            rating4.Setup(rating => rating.Reviewer).Returns(1);
            rating4.Setup(rating => rating.Movie).Returns(2);
            rating4.Setup(rating => rating.Grade).Returns(5);
            allRatings.Add(rating4.Object);

            Mock<IRepository<IRating>> ratingRepository = new Mock<IRepository<IRating>>();
            ratingRepository.Setup(repo => repo.ReadAll()).Returns(allRatings);

            IMovieService movieService = new MovieService(ratingRepository.Object);

            //Act
            var result = movieService.GetGradeCount(movieId, grade);

            //Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void GetMoviesWithHighestTopGradeCount_Test()
        {
            //Arrange
            List<IRating> allRatings = new List<IRating>();

            Mock<IRating> rating1 = new Mock<IRating>();
            rating1.Setup(rating => rating.Reviewer).Returns(1);
            rating1.Setup(rating => rating.Movie).Returns(1);
            rating1.Setup(rating => rating.Grade).Returns(5);
            allRatings.Add(rating1.Object);

            Mock<IRating> rating2 = new Mock<IRating>();
            rating2.Setup(rating => rating.Reviewer).Returns(2);
            rating2.Setup(rating => rating.Movie).Returns(1);
            rating2.Setup(rating => rating.Grade).Returns(5);
            allRatings.Add(rating2.Object);

            Mock<IRating> rating3 = new Mock<IRating>();
            rating3.Setup(rating => rating.Reviewer).Returns(3);
            rating3.Setup(rating => rating.Movie).Returns(2);
            rating3.Setup(rating => rating.Grade).Returns(5);
            allRatings.Add(rating3.Object);

            Mock<IRating> rating4 = new Mock<IRating>();
            rating4.Setup(rating => rating.Reviewer).Returns(4);
            rating4.Setup(rating => rating.Movie).Returns(2);
            rating4.Setup(rating => rating.Grade).Returns(5);
            allRatings.Add(rating4.Object);

            Mock<IRating> rating5 = new Mock<IRating>();
            rating5.Setup(repo => repo.Reviewer).Returns(3);
            rating5.Setup(repo => repo.Movie).Returns(3);
            rating5.Setup(repo => repo.Grade).Returns(5);
            allRatings.Add(rating5.Object);

            Mock<IRepository<IRating>> ratingRepository = new Mock<IRepository<IRating>>();
            ratingRepository.Setup(repo => repo.ReadAll()).Returns(allRatings);

            IMovieService movieService = new MovieService(ratingRepository.Object);

            var expectedResult = new List<int>() { 1, 2 };

            //Act
            var result = movieService.GetMoviesWithHighestTopGradeCount();

            //Assert
            Assert.True(!expectedResult.Except(result).Any() && expectedResult.Count == result.Count);
        }

        [Fact]
        public void GetMoviesWithHighestAverageGrade_Test()
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
            rating3.Setup(rating => rating.Reviewer).Returns(2);
            rating3.Setup(rating => rating.Movie).Returns(2);
            rating3.Setup(rating => rating.Grade).Returns(5);
            allRatings.Add(rating3.Object);

            Mock<IRating> rating4 = new Mock<IRating>();
            rating4.Setup(rating => rating.Reviewer).Returns(3);
            rating4.Setup(rating => rating.Movie).Returns(3);
            rating4.Setup(rating => rating.Grade).Returns(1);
            allRatings.Add(rating4.Object);

            Mock<IRepository<IRating>> ratingRepository = new Mock<IRepository<IRating>>();
            ratingRepository.Setup(repo => repo.ReadAll()).Returns(allRatings);

            IMovieService movieService = new MovieService(ratingRepository.Object);

            //Arrange
            var expectedResult1 = new List<int>() { 2, 1 };
            var expectedResult2 = new List<int>() { 2, 1, 3 };
            var expectedResult3 = new List<int>();


            //Act
            var result1 = movieService.GetMoviesWithHighestAverageGrade(2).ToList();
            var result2 = movieService.GetMoviesWithHighestAverageGrade(6).ToList();
            var result3 = movieService.GetMoviesWithHighestAverageGrade(0).ToList();

            //Assert
            Assert.Equal(expectedResult1, result1);
            Assert.Equal(expectedResult2, result2);
            Assert.Equal(expectedResult3, result3);
        }

        [Fact]
        public void GetReviewersSorted_Test()
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
            rating2.Setup(rating => rating.Reviewer).Returns(2);
            rating2.Setup(rating => rating.Movie).Returns(1);
            rating2.Setup(rating => rating.Grade).Returns(3);
            rating1.Setup(rating => rating.Date).Returns(DateTime.Now.AddDays(-1));
            allRatings.Add(rating2.Object);

            Mock<IRating> rating3 = new Mock<IRating>();
            rating3.Setup(rating => rating.Reviewer).Returns(3);
            rating3.Setup(rating => rating.Movie).Returns(1);
            rating3.Setup(rating => rating.Grade).Returns(5);
            allRatings.Add(rating3.Object);

            Mock<IRating> rating4 = new Mock<IRating>();
            rating4.Setup(rating => rating.Reviewer).Returns(3);
            rating4.Setup(rating => rating.Movie).Returns(2);
            rating4.Setup(rating => rating.Grade).Returns(1);
            allRatings.Add(rating4.Object);
            

            Mock<IRepository<IRating>> ratingRepository = new Mock<IRepository<IRating>>();
            ratingRepository.Setup(repo => repo.ReadAll()).Returns(allRatings);

            IMovieService movieService = new MovieService(ratingRepository.Object);

            var expectedResult1 = new List<int>() {3, 1, 2};
            var expectedResult2 = new List<int>() {3};
            var expectedResult3 = new List<int>();
            
            //Act
            var result1 = movieService.GetReviewersSorted(1);
            var result2 = movieService.GetReviewersSorted(2);
            var result3 = movieService.GetReviewersSorted(3);
            
            //Assert
            Assert.Equal(expectedResult1, result1);
            Assert.Equal(expectedResult2, result2);
            Assert.Equal(expectedResult3, result3);
            

        }

    }
}
