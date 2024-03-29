﻿using Business_layer.Bases;
using Business_layer.ViewModel;
using Data_access_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.AppServices
{
    public class WishlistAppService : BaseAppService
    {
        public bool addProduct(string userId, int productId)
        {
            Wishlist wishlist = TheUnitOfWork.Wishlist.GetById(userId);
            Product product = TheUnitOfWork.Product.GetById(productId);
            bool find = false;
            bool productAdded = false;
            foreach (var item in wishlist.Products)
            {
                if (item.ProductID == productId)
                { find = true; }
            }
            if (!find)
            {
                wishlist.Products.Add(product);
                TheUnitOfWork.Commit();
                productAdded = true;
            }


            return productAdded;
        }
        public void removeProduct(string userId, int productId)
        {
            Wishlist wishlist = TheUnitOfWork.Wishlist.GetById(userId);
            Product product = TheUnitOfWork.Product.GetById(productId);
            wishlist.Products.Remove(product);
            TheUnitOfWork.Commit();
        }
        public Wishlist getWishlistByUserId(string  userId)
        {
            return TheUnitOfWork.Wishlist.GetById(userId);
        }
    }
}
