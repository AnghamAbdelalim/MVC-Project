
using BL.Repositories;
using Business_layer.Reprositories;
using BusinessLayer.Reprositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_layer.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        #region Methode
        int Commit();
        #endregion
        OrderRepository Order { get; }
        OrderDetailsRepository OrderDetails { get; }
        AccountRepository Account { get; }
        RoleRepository Role { get; }
        ShipperRepository Shipper { get; }
        productReprository Product { get; }
        categoryReprository Category { get; }

        ShoppingCartRepository ShoppingCart { get; }
        WishlistRepository Wishlist { get; }
        PaymentReprository Payment  { get; }
        CartDetailsReprository CartDetails { get; }
    }
}