using System;
using System.Collections.Generic;
using System.Text;
using WhatYouGotLibrary.Models;

namespace WhatYouGotLibrary.Interfaces
{
    public interface IFavoriteRepo
    {
        IEnumerable<Favorite> GetFavorites();

        Favorite GetFavoriteById(int id);

        void UpdateFavorite(Favorite favorite);

        void SaveChanges();

        void AddFavorite(Favorite favorite);

        void DeleteFavoriteById(int id);

        bool FavoriteExists(int id);
    }
}
