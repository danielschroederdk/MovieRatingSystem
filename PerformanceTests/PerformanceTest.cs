using System;
using System.Diagnostics;
using MovieRatingSystem.Core.ApplicationService.Services;
using MovieRatingSystem.Core.DomainService;
using MovieRatingSystem.Core.Entity;
using MovieRatingSystem.Infrastructure.JSON.Repos;


namespace PerformanceTests
{
    public class PerformanceTest
    {
        static void Main(string[] args)
        {
            IRepository<IRating> ratings = new Repository();
            MovieService movieService = new MovieService(ratings);
            ReviewerService reviewerService = new ReviewerService(ratings);
            
            
            Console.WriteLine(ratings.ReadAll().Count);
            
            //Movies
            PrintTimeInSeconds(() => movieService.GetReviewersCount(1),1);
            PrintTimeInSeconds(() => movieService.GetAverageGrade(1),1);
            PrintTimeInSeconds(() => movieService.GetGradeCount(1,2),1);
            //PrintTimeInSeconds(() => movieService.GetMoviesWithHighestTopGradeCount(),1);
            //PrintTimeInSeconds(() => movieService.GetMoviesWithHighestAverageGrade(5),1);
            PrintTimeInSeconds(() => movieService.GetReviewersSorted(1),1);
            
            //Reviewers
            PrintTimeInSeconds(() => reviewerService.GetNumberOfReviews(1),1);
            PrintTimeInSeconds(() => reviewerService.GetAverageReviewGrade(1),1);
            PrintTimeInSeconds(() => reviewerService.GetGradeCount(1,2),1);
            PrintTimeInSeconds(() => reviewerService.GetReviewedMoviesSorted(1),1);
            //PrintTimeInSeconds(() => reviewerService.GetTopReviewers(),1);


        }
        
        static void PrintTimeInSeconds(Action actions, int repeats)
        {
            for (int i = 0; i < repeats; i++)
            {
                Stopwatch stopwatch = Stopwatch.StartNew();
                actions.Invoke();
                stopwatch.Stop();
                Console.WriteLine("    Time = {0:f5}", stopwatch.ElapsedMilliseconds / 1000.0);
            }
            Console.WriteLine();
        }
            
            
    }
}