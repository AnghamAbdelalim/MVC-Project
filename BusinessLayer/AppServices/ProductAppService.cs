using Business_layer.Bases;
using Business_layer.ViewModel;
using Data_access_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business_layer.AppServices
{
    public class ProductAppService : BaseAppService
    {
        public List<productViewModel> GetAllProduct()
        {

            return Mapper.Map<List<productViewModel>>(TheUnitOfWork.Product.GetAllProduct());
        }

        public productViewModel GetProduct(int id)
        {
            return Mapper.Map<productViewModel>(TheUnitOfWork.Product.GetById(id));
        }

        public bool SaveNewProduct(productViewModel productViewModel)
        {
            bool result = false;
            var product = Mapper.Map<Product>(productViewModel);
            if (TheUnitOfWork.Product.Insert(product))
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return result;
        }


        public bool UpdateProduct(productViewModel productViewModel)
        {
            var product = Mapper.Map<Product>(productViewModel);

            TheUnitOfWork.Product.Update(product);
            TheUnitOfWork.Commit();

            return true;
        }


        public bool DeleteProduct(int id)
        {
            bool result = false;

            TheUnitOfWork.Product.Delete(id);
            result = TheUnitOfWork.Commit() > new int();

            return result;
        }

        public List<productViewModel> Search(string ProductName)

        {

            IQueryable<Product> products = TheUnitOfWork.Product.GetAll().Where(p => p.ProductName.Contains(ProductName));
            return Mapper.Map<List<productViewModel>>(products);
        }
    }
}

