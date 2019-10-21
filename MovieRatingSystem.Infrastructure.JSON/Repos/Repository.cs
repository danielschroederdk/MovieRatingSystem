using System.Collections.Generic;
using System.IO;
using System.Linq;
using MovieRatingSystem.Core.DomainService;
using MovieRatingSystem.Core.Entity;
using Newtonsoft.Json;
using JsonReader = MovieRatingSystem.Core.Entity.Entities.JsonReader;

namespace MovieRatingSystem.Infrastructure.JSON.Repos
{
    public class Repository : IRepository<IRating>
    {
        private readonly List<IRating> _ratings;

        public Repository()
        {
            _ratings = JsonReader.Get().ToList();
        }
        public IRating Create(IRating value)
        {
            throw new System.NotImplementedException();
        }
        
        public List<IRating> ReadAll()
        {
            return _ratings;
        }
    }
}