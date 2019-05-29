using RevisorAPI.Models;
using RevisorAPI.Repository.FavouriteRepository;
using RevisorAPI.Repository.Registration;
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
    public class FavouritesController : ApiController
    {

        private readonly IFavourite favouriteRepository;
        public FavouritesController()
        {
            favouriteRepository = new FavouriteRepository();
        }


        [HttpGet]
        [Route("Favourite/Addfavourite/{email}/{MovieID}/{MovieTitle}/{MovieYear}")]
        public async Task<HttpResponseMessage> Addfavourite(string email, string MovieID, string MovieTitle, string MovieYear)
        {
            List<string> request_response = new List<string> { };

            //Response creator
            Response response = new Response();


            //To check if the provided user email is present in DB
            RegistrationRepository regrep = new RegistrationRepository();
            var checkuser = await regrep.CheckUserExistance(email);


            //If the user is not present in DB
            if (checkuser.Count() == 0)
            {
                response.responsecode = false;
                response.responsemessage.Add("Cannot add favourite as the provided email doesnot exist");
                return this.Request.CreateResponse<Response>(HttpStatusCode.OK, response, MediaTypeHeaderValue.Parse("application/json"));


            }

            //If user is present in DB
            else
            {

                var register = await favouriteRepository.Addfavourite(email, MovieID, MovieTitle, MovieYear);
             
                response.responsecode = register;
                response.responsemessage.Add("Favourite added Successfully");
                return this.Request.CreateResponse<Response>(HttpStatusCode.OK, response, MediaTypeHeaderValue.Parse("application/json"));


            }


        }



        [HttpGet]
        [Route("Favourite/Removefavourite/{email}/{MovieID}/{MovieTitle}/{MovieYear}")]
        public async Task<HttpResponseMessage> Removefavourite(string email, string MovieID, string MovieTitle, string MovieYear)
        {
            List<string> request_response = new List<string> { };

            //Response creator
            Response response = new Response();

            //To check if the provided favourite is present in DB
            var checkFavourite = await favouriteRepository.GetFavourites(email, MovieID, MovieTitle, MovieYear);


            //If the favourite is not present in DB
            if (checkFavourite.Count() == 0)
            {
             

                response.responsecode = false;
                response.responsemessage.Add("Provided Favourite doesnot exist");
                return this.Request.CreateResponse<Response>(HttpStatusCode.OK, response, MediaTypeHeaderValue.Parse("application/json"));

            }

            //If favourite is present in DB
            else
            {



                var response2 = await favouriteRepository.Removefavourite(email, MovieID, MovieTitle, MovieYear);
                 response.responsecode = response2;
                response.responsemessage.Add("Favourite removed Successfully");
                return this.Request.CreateResponse<Response>(HttpStatusCode.OK, response, MediaTypeHeaderValue.Parse("application/json"));


            }


        }


        [HttpGet]
        [Route("Favourite/GetFavourites/{email}")]
        public async Task<HttpResponseMessage> GetFavourites(string email)
        {
            List<string> request_response = new List<string> { };

            //Response creator
            Response response = new Response();

            //To check if the provided favourite is present in DB
            var checkFavourite = await favouriteRepository.GetFavourites(email);


            //If the user is not present in DB
            if (checkFavourite.Count() == 0)
            {
                //request_response.Add("false");
                //request_response.Add("No Favourite exist against provided email");
                //return Request.CreateResponse(HttpStatusCode.OK, request_response, MediaTypeHeaderValue.Parse("application/json"));
                response.responsecode = false;
                response.responsemessage.Add("No Favourite exist against provided email");
                return this.Request.CreateResponse<Response>(HttpStatusCode.OK, response, MediaTypeHeaderValue.Parse("application/json"));

            }

            //If user is present in DB
            else
            {

                return Request.CreateResponse(HttpStatusCode.OK, checkFavourite, MediaTypeHeaderValue.Parse("application/json"));


            }


        }

    }
}
