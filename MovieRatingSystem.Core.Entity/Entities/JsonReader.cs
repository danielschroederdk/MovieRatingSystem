using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace MovieRatingSystem.Core.Entity.Entities
{
	public class JsonReader
	{
		private const string filePath = "/Users/devz/Documents/Repositories/CSharp/Movie-Rating-System/MovieRatingSystem/PerformanceTests/ratings.json";
		
		public static IEnumerable<IRating> Get()
		{
			List<Rating> ratings = new List<Rating>();
			using (StreamReader streamReader = new StreamReader(filePath))
			using (JsonTextReader reader = new JsonTextReader(streamReader))
			{
				try
				{
					while (reader.Read())
					{
						if (reader.TokenType == JsonToken.StartObject)
						{
							Rating mr = ReadOneMovieRating(reader);
							ratings.Add(mr);
						}
					}
				}
				catch (JsonReaderException e)
				{
					Console.WriteLine(e.Message);
				}
			}
			return ratings;
		}


		private static Rating ReadOneMovieRating(JsonTextReader reader)
		{
			Rating m = new Rating();
			for (int i = 0; i < 4; i++)
			{
				reader.Read();
				switch (reader.Value)
				{
					case "Reviewer": m.Reviewer = (int)reader.ReadAsInt32(); break;
					case "Movie": m.Movie = (int)reader.ReadAsInt32(); break;
					case "Grade": m.Grade = (int)reader.ReadAsInt32(); break;
					case "Date": m.Date = (DateTime)reader.ReadAsDateTime(); break;
					default: throw new InvalidDataException("no such token: " + reader.Value);
				}
			}
			return m;
		}
	}
}
