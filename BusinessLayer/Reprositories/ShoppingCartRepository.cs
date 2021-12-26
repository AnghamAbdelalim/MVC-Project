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
    public class ShoppingCartRepository : BaseRepository<ShoppingCart>
    {
        private DbContext EC_DbContext;

        public ShoppingCartRepository(DbContext EC_DbContext) : base(EC_DbContext)
        {
            this.EC_DbContext = EC_DbContext;
        }
        #region CRUB

        public List<ShoppingCart> GetAllShoppingCart()
        {
            return GetAll().ToList();
        }

        public bool InsertShoppingCart(ShoppingCart shoppingCart)
        {
            return Insert(shoppingCart);
        }
        public void UpdateShoppingCart(ShoppingCart product)
        {
            Update(product);
        }
        public void DeleteShoppingCart(int id)
        {
            Delete(id);
        }

        public bool CheckShoppingCartExists(ShoppingCart shoppingCart)
        {
            return GetAny(l => l.ShoppingCartId == shoppingCart.ShoppingCartId);
        }
        public ShoppingCart GetShoppingCartById(int id)
        {
            return GetWhere(l => l.ShoppingCartId == id)
                .Include(r => r.CartDetails)
                .FirstOrDefault();
        }
        #endregion
    }
}
