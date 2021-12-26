using Business_layer.Bases;
using Business_layer.ViewModel;
using Data_access_Layer;
using System;
using System.Collections.Generic;
using System.Text;


namespace Business_layer.AppServices
{
     public class CategoryAppService : BaseAppService
    {
        public List<categoryViewModelcs> GetAllCategory()
        {

            return Mapper.Map<List<categoryViewModelcs>>(TheUnitOfWork.Category.GetAllCategory());
        }

        public categoryViewModelcs GetCategory(int id)
        {
            return Mapper.Map<categoryViewModelcs>(TheUnitOfWork.Category.GetById(id));
        }
        public bool SaveNewCategory(categoryViewModelcs categoryViewModel)
        {
            bool result = false;
            var category = Mapper.Map<Category>(categoryViewModel);
            if (TheUnitOfWork.Category.Insert(category))
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return result;
        }

        //categoryViewModelcs categoryViewModel
        public bool UpdateCategory(categoryViewModelcs categoryViewModel)
        {
            var category = Mapper.Map<Category>(categoryViewModel);
            
            TheUnitOfWork.Category.Update(category);
            TheUnitOfWork.Commit();

            return true;
        }


        public bool DeleteCategory(int id)
        {
            bool result = false;

            TheUnitOfWork.Category.Delete(id);
            result = TheUnitOfWork.Commit() > new int();

            return result;
        }

    }
}
