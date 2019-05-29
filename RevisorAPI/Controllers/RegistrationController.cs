using RevisorAPI.Models;
using RevisorAPI.Repository.Registration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web.Http;

namespace RevisorAPI.Controllers
{
    public class RegistrationController : ApiController
    {

        private readonly IRegistration registrationRepository;
        public RegistrationController()
        {
            registrationRepository = new RegistrationRepository();
        }

        [HttpGet]
        [Route("registration/UserRegistration/{email}/{password}")]
        public async Task<HttpResponseMessage> UserRegistration(string email, string password)
        {
            //Response creator
            Response response = new Response();

            try
            {
                List<string> request_response = new List<string> { };
                Register reg = new Register();
                reg.email = email;
                reg.password = password;

                //to check if user already exist in DB
                RegistrationRepository regrep = new RegistrationRepository();
                var checkuser = await regrep.CheckUserExistance(email, password);




                //If user doesnot exist in DB
                if (checkuser.Count() == 0)
                {



                    try
                    {
                        MailAddress m = new MailAddress(email);

                        var register = await registrationRepository.User_Registration(email, password);

                        response.responsecode = register;
                        response.responsemessage.Add("User Registration is Succcessful");
                        return this.Request.CreateResponse<Response>(HttpStatusCode.OK, response, MediaTypeHeaderValue.Parse("application/json"));

                    }
                    catch (FormatException a)
                    {

                      
                        response.responsecode = false;
                        response.responsemessage.Add("Provided email is not in correct format");
                        //response.responsemessage.Add(a.ToString());
                        return this.Request.CreateResponse<Response>(HttpStatusCode.OK, response, MediaTypeHeaderValue.Parse("application/json"));


                    }

                }

                //If user exist in DB
                else
                {
                  

                    response.responsecode = false;
                    response.responsemessage.Add("User Already Exist");
         
                    return this.Request.CreateResponse<Response>(HttpStatusCode.OK, response, MediaTypeHeaderValue.Parse("application/json"));

                }


            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message, MediaTypeHeaderValue.Parse("application/json"));
            }


        }



        [HttpGet]
        [Route("registration/Login/{email}/{password}")]
        public async Task<HttpResponseMessage> UserLogin(string email, string password)
        {
            //Response creator
            Response response = new Response();

            try
            {
                List<string> request_response = new List<string> { };
                Register reg = new Register();
                reg.email = email;
                reg.password = password;

                //to check if user already exist in DB
                RegistrationRepository regrep = new RegistrationRepository();
                var checkuser = await regrep.CheckUserExistance(email, password);




                //If user doesnot exist in DB
                if (checkuser.Count() == 0)
                {
                   
                    response.responsecode = false;
                    response.responsemessage.Add("User Login Failed - User ID or Password is invalid");

                    return this.Request.CreateResponse<Response>(HttpStatusCode.OK, response, MediaTypeHeaderValue.Parse("application/json"));

                }

                //If user exist in DB
                else
                {
                 
                    response.responsecode = true;
                    response.responsemessage.Add("User Login is Succcessful");

                    return this.Request.CreateResponse<Response>(HttpStatusCode.OK, response, MediaTypeHeaderValue.Parse("application/json"));

                }


            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message, MediaTypeHeaderValue.Parse("application/json"));
            }


        }

    }
}


