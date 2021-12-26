using Business_layer.Bases;
using Data_access_Layer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Repositories
{
    public class WishlistRepository : BaseRepository<Wishlist>
    {
        private DbContext EC_DbContext;

        public WishlistRepository(DbContext EC_DbContext) : base(EC_DbContext)
        {
            this.EC_DbContext = EC_DbContext;
        }

        internal Wishlist GetById(string userId)
        {
            throw new NotImplementedException();
        }

        #region CRUB

        public List<Wishlist> GetAllWishlist()
        {
            return GetAll().ToList();
        }

        public bool InsertWishlist(Wishlist wishlist)
        {
            return Insert(wishlist);
        }
        public void UpdateWishlist(Wishlist wishlist)
        {
            Update(wishlist);
        }
        public void DeleteWishlist(int id)
        {
            Delete(id);
        }

        public bool CheckWishlistExists(Wishlist wishlist)
        {
            return GetAny(l => l.ID == wishlist.ID);
        }
        public Wishlist GetWishlistById(int id)
        {

            return GetWhere(l => l.ID== id)
                .Include(r => r.Products)
                .FirstOrDefault();
        }
        #endregion
    }
}
