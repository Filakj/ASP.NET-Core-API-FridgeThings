using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WhatYouGotDataAccess.Entities;
using WhatYouGotLibrary.Interfaces;

namespace WhatYouGotDataAccess.Repos
{
    public class FavoriteRepo : IFavoriteRepo
    {
        private FridgeThingsDBContext _context;

        public FavoriteRepo(FridgeThingsDBContext context)
        {
            _context = context;
        }

        public void AddFavorite(WhatYouGotLibrary.Models.Favorite favorite)
        {
            Entities.Favorite newFavorite = Mapper.Map(favorite);
            _context.Add(newFavorite);
        }

        public void DeleteFavoriteById(int id)
        {
            Entities.Favorite favorite = _context.Favorite.Find(id);
            _context.Remove(favorite);
        }

        public bool FavoriteByUserIdExists(int userId)
        {
            return _context.Favorite.Any(favorite => favorite.UserId == userId);
        }

        public bool FavoriteExists(int id)
        {
            return _context.Recipe.Any(e => e.Id == id);
        }

        public WhatYouGotLibrary.Models.Favorite GetFavoriteById(int id)
        {
            Entities.Favorite favorite = _context.Favorite.Find(id);

            return Mapper.Map(favorite);
        }

        public IEnumerable<WhatYouGotLibrary.Models.Favorite> GetFavorites()
        {
            IQueryable<Entities.Favorite> favorites = _context.Favorite;

            return favorites.Select(Mapper.Map);
        }

        public IEnumerable<WhatYouGotLibrary.Models.Favorite> GetFavoritesByUserId(int userId)
        {
            IQueryable<Favorite> favorites = from f in _context.Favorite
                                             where f.UserId == userId
                                             select f;

            return favorites.Select(Mapper.Map);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void UpdateFavorite(WhatYouGotLibrary.Models.Favorite favorite)
        {
            Entities.Favorite currentFavorite = _context.Favorite.Find(favorite.Id);
            Entities.Favorite newFavorite = Mapper.Map(favorite);

            _context.Entry(currentFavorite).CurrentValues.SetValues(newFavorite);
        }
    }
}
