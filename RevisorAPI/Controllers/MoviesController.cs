using RevisorAPI.Models;
using RevisorAPI.Repository;
using RevisorAPI.Repository.MovieRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace RevisorAPI.Controllers
{
    public class MoviesController : ApiController
    {
        private readonly IMovieRepository movieRepository;
        public MoviesController() {
            movieRepository = new MovieRepository();
        }

        [HttpGet]
        public async Task<HttpResponseMessage> GetAllMovies()
        {
            try
            {
                var allMovies = await movieRepository.GetAllMovie();
                return Request.CreateResponse(HttpStatusCode.OK, allMovies, MediaTypeHeaderValue.Parse("application/json"));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message, MediaTypeHeaderValue.Parse("application/json"));
            }
        }

        [HttpGet]
        public async Task<HttpResponseMessage> GetMoviesByTitle(string id)
        {
            try
            {
                var movie = await movieRepository.GetMovieByTitle(id);
                return Request.CreateResponse(HttpStatusCode.OK, movie, MediaTypeHeaderValue.Parse("application/json"));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message, MediaTypeHeaderValue.Parse("application/json"));
            }
        }

        [HttpGet]
        public async Task<HttpResponseMessage> GetMoviesByObjectID(string id, string sID)
        {
            try
            {
                var movie = await movieRepository.GetMovieByObjectID(id, sID);
                return Request.CreateResponse(HttpStatusCode.OK, movie, MediaTypeHeaderValue.Parse("application/json"));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message, MediaTypeHeaderValue.Parse("application/json"));
            }
        }
    }
}
