
using Newtonsoft.Json;
using RevisorAPI.Models;
using RevisorAPI.Repository.Registration;
using RevisorAPI.Repository.ReviewRepository;
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
    public class ReviewController : ApiController
    {

        private readonly IReview reviewRepository;
        public ReviewController()
        {
            reviewRepository = new ReviewRepository();
        }

        [HttpGet]
        [Route("Review/AddReview/{email}/{MovieID}/{MovieTitle}/{MovieYear}/{Reviews}")]
        public async Task<HttpResponseMessage> AddReview(string email, string MovieID, string MovieTitle, string MovieYear, string Reviews)
        {

            try
            {

                List<string> request_response = new List<string> { };

                //Response Creator
                Response response = new Response();

                //To check if the provided user email is present in DB
                RegistrationRepository regrep = new RegistrationRepository();
                var checkuser = await regrep.CheckUserExistance(email);


                //If the user is not present in DB
                if (checkuser.Count() == 0)
                {


                    response.responsecode = false;
                    response.responsemessage.Add("Cannot add Review as the provided email doesnot exist");
                    //string requestJSON = JsonConvert.SerializeObject(request, Formatting.Indented);

                    //request_response.Add("false");
                    //request_response.Add("Cannot add Review as the provided email doesnot exist");
                    //return Request.CreateResponse(HttpStatusCode.OK, response, MediaTypeHeaderValue.Parse("application/json"));
                    return this.Request.CreateResponse<Response>(HttpStatusCode.OK, response, MediaTypeHeaderValue.Parse("application/json"));

                }

                //If user is present in DB
                else
                {

                    var review = await reviewRepository.AddReview(email, MovieID, MovieTitle, MovieYear, Reviews);

                    response.responsecode = review;
                    response.responsemessage.Add("Review added Successfully");
                    return this.Request.CreateResponse<Response>(HttpStatusCode.OK, response, MediaTypeHeaderValue.Parse("application/json"));


                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message, MediaTypeHeaderValue.Parse("application/json"));
            }

        }

        



        [HttpGet]
        [Route("Review/RemoveReview/{email}/{MovieID}/{MovieTitle}/{MovieYear}/{Reviews}")]
        public async Task<HttpResponseMessage> RemoveReview(string email, string MovieID, string MovieTitle, string MovieYear, string Reviews)
        {
            List<string> request_response = new List<string> { };
            try
            {

                //To check if the provided favourite is present in DB
                var checkReview = await reviewRepository.GetReview(email, MovieID, MovieTitle, MovieYear, Reviews);

                //Response Creator
                Response response = new Response();

                //If the user is not present in DB
                if (checkReview.Count() == 0)
                {
                    //request_response.Add("false");
                    //request_response.Add("Provided Review doesnot exist");
                    //return Request.CreateResponse(HttpStatusCode.OK, request_response, MediaTypeHeaderValue.Parse("application/json"));
                    response.responsecode = false;
                    response.responsemessage.Add("Provided Review doesnot exist");
                    return this.Request.CreateResponse<Response>(HttpStatusCode.OK, response, MediaTypeHeaderValue.Parse("application/json"));


                }

                //If user is present in DB
                else
                {

                    #region Success resopnse


                    var response2 = await reviewRepository.RemoveReview(email, MovieID, MovieTitle, MovieYear, Reviews);
                    //request_response.Add(response2.ToString());
                    //request_response.Add("Review removed Successfully");
                    //return Request.CreateResponse(HttpStatusCode.OK, request_response, MediaTypeHeaderValue.Parse("application/json"));
                    response.responsecode = response2;
                    response.responsemessage.Add("Review removed Successfully");
                    return this.Request.CreateResponse<Response>(HttpStatusCode.OK, response, MediaTypeHeaderValue.Parse("application/json"));




                    #endregion

                }

            }
            catch (Exception ex)
            {
                //request_response.Add("False");
                //
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message, MediaTypeHeaderValue.Parse("application/json"));
            }

        }


    }
}
