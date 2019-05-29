using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RevisorAPI.Models
{
    public class Response
    {
        public bool responsecode { get; set; }

        public List<string> responsemessage{ get; set; }

        public Response(){

            responsemessage = new List<string>();

            }
    }


}