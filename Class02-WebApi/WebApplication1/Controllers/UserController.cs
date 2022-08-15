using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using System;
using WebApplication1.Enum;

namespace WebApplication1.Controllers 
{
    [ApiController]
    [Route("api/v1/{controller}")]

    public class UserController : ControllerBase
    {
        private readonly List<User> _users = new List<User>
        {
               new User
            {
                Id = 1,
                Name = "Trajan",
                Age = 33,
                Gender = "m"
            },
            new User
            {
                Id = 2,
                Name = "Vlatko",
                Age = 23,
                Gender = "m"
            },
            new User
            {
                Id = 3,
                Name = "Stefan",
                Age = 29,
                Gender = "m"
            },
            new User
            {
                Id = 4,
                Name = "Aneta",
                Age = 31,
                Gender = "f"
            },
            new User
            {
                Id = 5,
                Name = "Aleksandar",
                Age = 18,
                Gender = "m"
            },
        };

        [HttpGet("{id}")]
        public ActionResult <User> GetUSer(int id)
        {
            if(id < 1)
            {
                return BadRequest(id);
            }
            var user = _users.FirstOrDefault(x => x.Id == id);
         if(user  == null)
            {
                return NotFound($"The user with {id} does not exists)");
            }
            return Ok(user);
        }
        [HttpGet("{name}/age/{age}")]
        public ActionResult <IEnumerable<User>> GetUsersByNameAndAge(string name ,int age)
        {
            var users = _users
                .Where(x => x
                   .Name
                   .Equals(name, StringComparison.InvariantCultureIgnoreCase))
                .Where(x => x.Age == age);
            return Ok(users);
        }

        // This is the same route as the one above
        [HttpGet("gender/{m}/age/{age}")]
        public ActionResult <IEnumerable<User>> GetUSersByAgeAndGender(string gender,int age)
        {
            if( age > 30)
            {
                return BadRequest();
            }
            var user = _users
                .Where(x => x.Gender.Equals(gender, StringComparison.InvariantCultureIgnoreCase))
                .Where(x => x.Age == age);
           if(user != null)
            {
                return Ok();
            }
            return NotFound();

        }
        
    }

    public class MovieController : ControllerBase
    {
        private readonly List<Movie> _movies = new List<Movie>
        {
            new Movie
            {
                Id = 1,
                Name = "Lord Of The Rings",
                genre = Enum.Genrecs.Action,
                Rating = 5,
                Year = 1998

            },
            new Movie
            {
                Id = 2,
                Name = "Bad Boys",
                genre = Enum.Genrecs.Comedy,
                Rating = 4,
                Year = 2006

            },
            new Movie
            {
                Id = 3,
                Name = "Star Wars",
                genre = Enum.Genrecs.Action,
                Rating = 5,
                Year = 2020
            },
            new Movie
            {
                Id = 4,
                Name = "Jumangee",
                genre = Enum.Genrecs.Comedy,
                Rating = 1,
                Year = 2003
            },
            new Movie
            {
                Id= 5,
                Name = "The Eyes",
                genre = Enum.Genrecs.Triller,
                Rating = 3,
                Year = 2010
            }
        };

        [HttpGet("id/{id}")]
        public ActionResult<IEnumerable<Movie>> GetMoviesById(int id)
        {
            if (id < 1)
            {
                return BadRequest();
            }
            var movie = _movies.FirstOrDefault(x => x.Id == id);
            if (movie == null)
            {
                return NotFound();
            }
            return Ok(movie);
        }
        [HttpGet("title/{title}")]
        public ActionResult<IEnumerable<Movie>> GetMovieByTitle(string title)
        {
            var movie = _movies.Where(x => x.Name.Equals(title, StringComparison.InvariantCultureIgnoreCase));
            if (movie == null)
            {
                return NotFound();
            }
            return Ok(movie);
        }

        [HttpGet("year/{year}")]
        public ActionResult<IEnumerable<Movie>> GetMovieByYear(int from, int to)
        {
            if (from < 1998 || to > 2020)
            {
                return BadRequest();
            }
            var moviesFromToYear = _movies.Where(x => x.Year >= from || x.Year <= to);
            if (moviesFromToYear == null)
            {
                return NotFound();
            }
            return Ok(moviesFromToYear);

        }

        [HttpGet("genre/{genre}/year/{year}")]
        public ActionResult<IEnumerable<Movie>> GetMovieByGenreAndYear(string genre, int year)
        {
          
            if (year < 1998 || year  > 2020)
            {
                return BadRequest();
            }
            var movies = _movies.Where(x => x.genre.ToString() == genre)
                .Where(x => x.Year == year);
            if(movies != null)
            {
                return Ok(movies);
            }
            return NotFound();
        }

    }
}
