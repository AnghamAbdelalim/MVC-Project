using Business_layer.Bases;
using Data_access_Layer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Business_layer.Reprositories
{
    public class categoryReprository : BaseRepository<Category>
    {
        private DbContext EC_DbContext;

        public categoryReprository (DbContext EC_DbContext) : base(EC_DbContext)
        {
            this.EC_DbContext = EC_DbContext;
        }
    public List<Category> GetAllCategory()
    {
        return GetAll().ToList();
    }

    public bool InsertCategory (Category category)
    {
        return Insert(category);
    }
      public void UpdateCategory(Category category)
     {
      Update(category);
      }
      public void DeleteCategory(int id)
     {
        Delete(id);
     }
       
}
}
