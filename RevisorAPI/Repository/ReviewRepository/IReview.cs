using RevisorAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevisorAPI.Repository.ReviewRepository
{
    interface IReview
    {
   
            Task<bool> AddReview(string email, string MovieID, string MovieTitle, string MovieYear, string Reviews);

            Task<bool> RemoveReview(string email, string MovieID, string MovieTitle, string MovieYear, string Reviews);

        Task<IEnumerable<Review>> GetReview(string email, string MovieID, string MovieTitle, string MovieYear, string Reviews);
    }
}
