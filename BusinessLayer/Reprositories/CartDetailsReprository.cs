using Business_layer.Bases;
using Data_access_Layer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Reprositories
{
 public     class CartDetailsReprository: BaseRepository<CartDetails>
    {
        private DbContext EC_DbContext;

        public CartDetailsReprository(DbContext EC_DbContext) : base(EC_DbContext)
    {
        this.EC_DbContext = EC_DbContext;
    }
    #region CRUB

    public List<CartDetails> GetAllCartDetails()
    {
        return GetAll().ToList();
    }

    public bool InsertCartDetails(CartDetails CartDetails)
    {
        return Insert(CartDetails);
    }
    public void UpdateCartDetails(CartDetails CartDetails)
    {
        Update(CartDetails);
    }
    public void DeleteCartDetails(int id)
    {
        Delete(id);
    }

    public bool CheckCartDetailsExists(CartDetails CartDetails)
    {
        return GetAny(l => l.CartDetailId== CartDetails.CartDetailId);
    }
        public CartDetails GetCartDetailssById(int id)
    {
        return GetFirstOrDefault(l => l.CartDetailId == id);
    }
    #endregion
}
}

