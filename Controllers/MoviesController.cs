using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieReview.API.Domain.Models;
using MovieReview.API.Domain.Services;
using MovieReview.API.Resources;

namespace MovieReview.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : Controller
    {

        private readonly IMovieService _movieService;
        private readonly IMapper _mapper;

        public MoviesController(IMovieService movieService, IMapper mapper)
        {
            _movieService = movieService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<MovieResource>> GetAllAsync()
        {
            var movies = await _movieService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Movie>, IEnumerable<MovieResource>>(movies);

            return resources;
        }

        // GET: api/Movies/joker
        [HttpGet("{NameSearch}", Name = "Get")]
        [Route("NameSearch/{NameSearch}")]
        [ProducesResponseType(typeof(MovieResource), 200)]
        public async Task<IEnumerable<MovieResource>> Get(string NameSearch)
        {
            IEnumerable<MovieResource> resources = null;

            if (string.IsNullOrWhiteSpace(NameSearch))
            {
                Response.StatusCode = 400;

                return resources;
            }

            var movies = await _movieService.SearchByTitle(NameSearch);

            resources = _mapper.Map<IEnumerable<Movie>, IEnumerable<MovieResource>>(movies);

            if (resources.Count()  == 0)
            {
                Response.StatusCode = 404;
            }

            

            return resources;
        }

        // GET: api/Movies/action
        [HttpGet("{GenreSearch}", Name = "GetTitleByGenre")]
        [Route("GenreSearch/{GenreSearch}")]
        [ProducesResponseType(typeof(MovieResource), 200)]
        public async Task<IEnumerable<MovieResource>> GetTitleByGenre(string GenreSearch)
        {
            IEnumerable<MovieResource> resources = null;

            if (string.IsNullOrWhiteSpace(GenreSearch))
            {
                Response.StatusCode = 400;

                return resources;
            }

            var movies = await _movieService.SearchByGenre(GenreSearch);

            resources = _mapper.Map<IEnumerable<Movie>, IEnumerable<MovieResource>>(movies);

            if (resources.Count() == 0)
            {
                Response.StatusCode = 404;
            }

            return resources;
        }

        [HttpGet("{ReleasedYearSearch}", Name = "GetTitleByReleaseYear")]
        [Route("ReleasedYearSearch/{ReleasedYearSearch}")]
        [ProducesResponseType(typeof(MovieResource), 200)]
        public async Task<IEnumerable<MovieResource>> GetTitleByReleaseYear(int ReleasedYearSearch)
        {
            IEnumerable<MovieResource> resources = null;

            if (ReleasedYearSearch < 1900)
            {
                Response.StatusCode = 400;

                return resources;
            }

            var movies = await _movieService.SearchByReleaseYear(ReleasedYearSearch);

            resources = _mapper.Map<IEnumerable<Movie>, IEnumerable<MovieResource>>(movies);

            if (resources.Count() == 0)
            {
                Response.StatusCode = 404;
            }

            return resources;
        }

        // GET: api/Movies/joker
        [HttpGet("{TopRatedMovies}", Name = "GetTopRatedMovies")]
        [Route("TopRatedMovies/{TopRatedMovies}")]
        [ProducesResponseType(typeof(MovieResource), 200)]
        public async Task<IEnumerable<MovieResource>> GetTopRatedMovies(int TopRatedMovies)
        {
            IEnumerable<MovieResource> resources = null;

            if (TopRatedMovies < 0)
            {
                Response.StatusCode = 400;

                return resources;
            }

            var movies = await _movieService.SearchTopMoviesByReview(TopRatedMovies);

            resources = _mapper.Map<IEnumerable<Movie>, IEnumerable<MovieResource>>(movies);

            if (resources.Count() == 0)
            {
                Response.StatusCode = 404;
            }
            return resources;
        }


        #region Built in Code
        //// GET: api/Movies
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET: api/Movies/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST: api/Movies
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT: api/Movies/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
        #endregion Built in Code
    }
}
