using Business_layer.Bases;
using Data_access_Layer;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Business_layer.Reprositories
{
    public class productReprository : BaseRepository<Product>
    {
        private DbContext EC_DbContext;

        public productReprository(DbContext EC_DbContext) : base(EC_DbContext)
        {
            this.EC_DbContext = EC_DbContext;
        }
        public List<Product> GetAllProduct()
        {
            return GetAll().ToList();
        }

        public bool InsertProduct(Product product)
        {
            return Insert(product);
        }
        public void UpdateProduct(Product product)
        {
            Update(product);
        }
        public void Deleteproduct(int id)
        {
            Delete(id);
        }
}
}

