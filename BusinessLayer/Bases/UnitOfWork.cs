using BL.Repositories;
using Business_layer.Interfaces;
using Business_layer.Reprositories;
using BusinessLayer.Reprositories;
using Data_access_Layer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_layer.Bases
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Common Properties
        private DbContext EC_DbContext { get; set; }

        #endregion

        #region Constructors
        public UnitOfWork()
        {
            EC_DbContext = new ApplicationDBContext();//
            // Avoid load navigation properties
            EC_DbContext.Configuration.LazyLoadingEnabled = false;
        }
        #endregion

        #region Methods
        public int Commit()
        {
            return EC_DbContext.SaveChanges();
        }

        public void Dispose()
        {
            EC_DbContext.Dispose();
        }
        #endregion


        public OrderRepository order;//=> throw new NotImplementedException();
        public OrderRepository Order
        {
            get
            {
                if (order == null)
                    order = new OrderRepository(EC_DbContext);
                return order;
            }
        }

        public OrderDetailsRepository orderDetails;//=> throw new NotImplementedException();
        public OrderDetailsRepository OrderDetails
        {
            get
            {
                if (orderDetails == null)
                    orderDetails = new OrderDetailsRepository(EC_DbContext);
                return orderDetails;
            }
        }

        public AccountRepository account;//=> throw new NotImplementedException();
        public AccountRepository Account
        {
            get
            {
                if (account == null)
                    account = new AccountRepository(EC_DbContext);
                return account;
            }
        }

        public RoleRepository role;//=> throw new NotImplementedException();
        public RoleRepository Role
        {
            get
            {
                if (role == null)
                    role = new RoleRepository(EC_DbContext);
                return role;
            }
        }


        public ShipperRepository shipper;//=> throw new NotImplementedException();
        public ShipperRepository Shipper
        {
            get
            {
                if (shipper == null)
                    shipper = new ShipperRepository(EC_DbContext);
                return shipper;
            }
        }
        public WishlistRepository wishlist;//=> throw new NotImplementedException();
        public WishlistRepository Wishlist
        {
            get
            {
                if (wishlist == null)
                    wishlist = new WishlistRepository(EC_DbContext);
                return wishlist;
            }
        }
        public categoryReprository category;//=> throw new NotImplementedException();
        public categoryReprository Category
        {
            get
            {
                if (category == null)
                    category = new categoryReprository(EC_DbContext);
                return category;
            }
        }
        public productReprository product;//=> throw new NotImplementedException();
        public productReprository Product
        {
            get
            {
                if (product == null)
                    product = new productReprository(EC_DbContext);
                return product;
            }
        }
        public CartDetailsReprository cartDetails;//=> throw new NotImplementedException();
        public CartDetailsReprository CartDetails
        {
            get
            {
                if (cartDetails == null)
                    cartDetails = new CartDetailsReprository(EC_DbContext);
                return cartDetails;
            }
        }
        public ShoppingCartRepository  shoppingCart;//=> throw new NotImplementedException();
        public ShoppingCartRepository ShoppingCart
        {
            get
            {
                if (shoppingCart == null)
                   shoppingCart = new ShoppingCartRepository(EC_DbContext);
                return shoppingCart;
            }
}
        public PaymentReprository payment;//=> throw new NotImplementedException();
        public PaymentReprository Payment
        {
            get
            {
                if (payment == null)
                    payment = new PaymentReprository(EC_DbContext);
                return payment;
            }
        }
    }
}
