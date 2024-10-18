using System.ComponentModel.DataAnnotations.Schema;

namespace moviepoint.Models
{
    public class ActorMovie
    {
        [ForeignKey("Actor")]
        public int ActorsId { get; set; }

        [ForeignKey("Movie")]
        public int MoviesId { get; set; }

        public Actor Actor { get; set; }
        public Movie Movie { get; set; }
    }
}
