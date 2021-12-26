
using Business_layer.AppServices;
using Business_layer.Bases;
using Business_layer.ViewModel;
using Data_access_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BusinessLayer.AppServices
{
    public class ShoppingCartAppService : BaseAppService
    {
        #region CURD

        public List<ShoppingCart> GetAllShoppingCart()
        {

            return TheUnitOfWork.ShoppingCart.GetAllShoppingCart();
        }

        public ShoppingCart GetShoppingCart(int id)
        {
            return TheUnitOfWork.ShoppingCart.GetShoppingCartById(id);
        }




        public bool SaveNewShoppingCart(ShoppingCart shoppingCart)
        {
            bool result = false;

            if (TheUnitOfWork.ShoppingCart.Insert(shoppingCart))
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return result;
        }


        public bool UpdateShoppingCart(ShoppingCart shoppingCart)
        {
            TheUnitOfWork.ShoppingCart.Update(shoppingCart);
            TheUnitOfWork.Commit();

            return true;
        }



        public bool DeleteShoppingCart(int id)
        {
            bool result = false;

            TheUnitOfWork.ShoppingCart.Delete(id);
            result = TheUnitOfWork.Commit() > new int();

            return result;
        }


        public bool CheckShoppingCartsExists(ShoppingCart shoppingCart)
        {
            return TheUnitOfWork.ShoppingCart.CheckShoppingCartExists(shoppingCart);
        }
        public void AddProduct(int userId, int productId)
        {
            ShoppingCartAppService shoppingCartAppService = new ShoppingCartAppService();
            ProductAppService ProductsAppService = new ProductAppService();
            ShoppingCart shoppingCart = shoppingCartAppService.GetShoppingCart(userId);
            if (shoppingCart == null)
            {
                shoppingCart = new ShoppingCart();
                shoppingCart.ShoppingCartId = userId;
                shoppingCart.TotalPrice = 0;
                shoppingCartAppService.SaveNewShoppingCart(shoppingCart);
            }
            if (shoppingCart.CartDetails == null)
            {
                shoppingCart.CartDetails = new List<CartDetails>();
                shoppingCart.CartDetails.Add(new CartDetails() { ProductQuantity = 1, ProductId = productId });
                shoppingCart.TotalPrice += ProductsAppService.GetProduct(productId).ProductPrice;
            }
            else
            {
                bool productAlreadyAdded = false;
                foreach (CartDetails cartDetails in shoppingCart.CartDetails)
                {
                    if (cartDetails.ProductId == productId)
                    {
                        productAlreadyAdded = true;
                    }
                }
                if (!productAlreadyAdded)
                {
                    shoppingCart.CartDetails.Add(new CartDetails() { ProductQuantity = 1, ProductId = productId });
                    shoppingCart.TotalPrice += ProductsAppService.GetProduct(productId).ProductPrice;
                }
            }
            shoppingCartAppService.UpdateShoppingCart(shoppingCart);
        }
        #endregion

    }
}

   /* public class ShoppingCartAppService : BaseAppService
    {
        #region CURD

        public List<ShoppingCart> GetAllShoppingCart()
        {

            return TheUnitOfWork.ShoppingCart.GetAllShoppingCart();
        }
        
        public ShoppingCart GetShoppingCart(int  id)
        {
            return TheUnitOfWork.ShoppingCart.GetShoppingCartById(id);
        }

       


        public bool SaveNewShoppingCart(ShoppingCart shoppingCart
        {
            bool result = false;
           
            if (TheUnitOfWork.ShoppingCart.Insert(shoppingCart))
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return result;
        }


        public bool UpdateShoppingCart(ShoppingCart shoppingCart)
        {
            TheUnitOfWork.ShoppingCart.Update(shoppingCart);
            TheUnitOfWork.Commit();

            return true;
        }



        public bool DeleteShoppingCart( int id)
        {
            bool result = false;

            TheUnitOfWork.ShoppingCart.Delete(id);
            result = TheUnitOfWork.Commit() > new int();

            return result;
        }

       
        public bool CheckShoppingCartsExists(ShoppingCart shoppingCart)
        {
            return TheUnitOfWork.ShoppingCart.CheckShoppingCartExists(shoppingCart);
        }
        public void AddProduct(int  userId, int productId)
        {
            ShoppingCartAppService shoppingCartAppService = new ShoppingCartAppService();
            ProductAppService ProductsAppService = new ProductAppService();
            ShoppingCart shoppingCart = shoppingCartAppService.GetShoppingCart(userId);
            if (shoppingCart == null)
            {
                shoppingCart = new ShoppingCart();
                shoppingCart.ShoppingCartId = userId;
                shoppingCart.CartDetails.tota= 0;
                shoppingCartAppService.SaveNewShoppingCart(shoppingCart);
            }
            if (shoppingCart.CartDetails == null)
            {
                shoppingCart.= new List<CartDetails>();
                shoppingCart.CartDetails.Add(new CartDetails() {ProductQuantity= 1, ProductId = productId });
                shoppingCart.TotalPrice += ProductsAppService.GetProduct(productId).ProductPrice;
            }
            else
            {
                bool productAlreadyAdded = false;
                foreach (ShoppingCartProducts  shoppingCartProducts in shoppingCart.ShoppingCartProducts)
                {
                    if (shoppingCartProducts.productId == productId)
                    {
                        productAlreadyAdded = true;
                    }
                }
                if (!productAlreadyAdded)
                {
                    shoppingCart.ShoppingCartProducts.Add(new ShoppingCartProducts() { Quantity = 1, productId = productId });
                    shoppingCart.TotalPrice += ProductsAppService.GetProduct(productId).Price;
                }
            }
            shoppingCartAppService.UpdateShoppingCart(shoppingCart);
        }
        #endregion

    }*/

