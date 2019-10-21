using System;
using System.Diagnostics;

namespace MovieRatingSystem.Core.Entity.Entities
{
    public static class Executioner
    {
        private const int REPEATS = 5;
        private const int MAX_BENCHMARK_TIME_IN_SECONDS = 4;
        
        public static bool DO(Action actions)
        {
            double elapsedTime = 0;
            var sw = new Stopwatch();
            
            for (var i = 0; i < REPEATS; i++)
            {
                sw.Start();
                actions.Invoke();
                sw.Stop();
                elapsedTime += sw.ElapsedMilliseconds;
            }
            
            return elapsedTime / REPEATS / 1000.0 < MAX_BENCHMARK_TIME_IN_SECONDS;
        }
    }
}