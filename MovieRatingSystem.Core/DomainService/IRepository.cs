using System;
using System.Collections.Generic;

namespace MovieRatingSystem.Core.DomainService
{
    public interface IRepository<T>
    {
        T Create(T value);

        List<T> ReadAll();

    }
}
