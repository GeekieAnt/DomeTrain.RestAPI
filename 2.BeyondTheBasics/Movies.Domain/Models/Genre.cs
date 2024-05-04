using System.Text.Json.Serialization;

namespace Movies.Domain.Models
{
    public class Genre
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        [JsonIgnore]
        public List<Movie> Movies { get; set; } = new();
    }
}
