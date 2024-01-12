// Controllers/MoviesController.cs
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Modules;

[ApiController]
[Route("api/[controller]")]
public class MoviesController : ControllerBase
{
    private static List<Movie> _movies = new List<Movie>
    {
        new Movie { Id = 1, Title = "Inception", Genre = "Sci-Fi", Year = 2010 },
        new Movie { Id = 2, Title = "The Shawshank Redemption", Genre = "Drama", Year = 1994 }
    };

    // GET: api/movies
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_movies);
    }

    // GET: api/movies/1
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var movie = _movies.FirstOrDefault(m => m.Id == id);
        if (movie == null)
        {
            return NotFound();
        }
        return Ok(movie);
    }

    // POST: api/movies
    [HttpPost]
    public IActionResult Post([FromBody] Movie movie)
    {
        movie.Id = _movies.Count + 1;
        _movies.Add(movie);
        return CreatedAtAction(nameof(GetById), new { id = movie.Id }, movie);
    }

    // PUT: api/movies/1
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] Movie updatedMovie)
    {
        var existingMovie = _movies.FirstOrDefault(m => m.Id == id);
        if (existingMovie == null)
        {
            return NotFound();
        }

        existingMovie.Title = updatedMovie.Title;
        existingMovie.Genre = updatedMovie.Genre;
        existingMovie.Year = updatedMovie.Year;

        return NoContent();
    }

    // DELETE: api/movies/1
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var movie = _movies.FirstOrDefault(m => m.Id == id);
        if (movie == null)
        {
            return NotFound();
        }

        _movies.Remove(movie);
        return NoContent();
    }
}
