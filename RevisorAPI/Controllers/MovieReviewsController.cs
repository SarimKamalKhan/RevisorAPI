using RevisorAPI.Repository.MovieReviewRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;

namespace RevisorAPI.Controllers
{
    public class MovieReviewsController : ApiController
    {
        private readonly MovieReviewRepository movieReviewRepository;
        public MovieReviewsController()
        {
            movieReviewRepository = new MovieReviewRepository();
        }

        [HttpGet]
        public async Task<HttpResponseMessage> GetIMDBMovieReviewsByObjectID(string id, string sID)
        {
            try
            {
                var allMovies = await movieReviewRepository.GetIMDBMovieReviewsByObjectID(id, sID);
                return Request.CreateResponse(HttpStatusCode.OK, allMovies, MediaTypeHeaderValue.Parse("application/json"));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message, MediaTypeHeaderValue.Parse("application/json"));
            }
        }

        [HttpGet]
        public async Task<HttpResponseMessage> GetROTTMovieReviewsByObjectID(string id, string sID)
        {
            try
            {
                var allMovies = await movieReviewRepository.GetROTTMovieReviewsByObjectID(id, sID);
                return Request.CreateResponse(HttpStatusCode.OK, allMovies, MediaTypeHeaderValue.Parse("application/json"));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message, MediaTypeHeaderValue.Parse("application/json"));
            }
        }

        [HttpGet]
        public async Task<HttpResponseMessage> GetMTCMovieReviewsByObjectID(string id, string sID)
        {
            try
            {
                var allMovies = await movieReviewRepository.GetMTCMovieReviewsByObjectID(id, sID);
                return Request.CreateResponse(HttpStatusCode.OK, allMovies, MediaTypeHeaderValue.Parse("application/json"));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message, MediaTypeHeaderValue.Parse("application/json"));
            }
        }
    }
}
