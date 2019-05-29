using RevisorAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace RevisorAPI.Repository.FavouriteRepository
{
    interface IFavourite
    {
        Task <bool> Addfavourite(string email, string MovieID, string MovieTitle, string MovieYear);

        Task<bool> Removefavourite(string email, string MovieID, string MovieTitle, string MovieYear);

        Task<IEnumerable<Favourite>> GetFavourites(string email, string MovieID, string MovieTitle, string MovieYear);


        Task<IEnumerable<Favourite>> GetFavourites(string email);
    }
}