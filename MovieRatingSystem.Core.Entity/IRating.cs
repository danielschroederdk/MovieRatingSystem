using System;
namespace MovieRatingSystem.Core.Entity
{
    public interface IRating
    {
        int Reviewer { get; }
        int Movie { get; }
        int Grade { get;  }
        DateTime Date { get; }
    }
}
