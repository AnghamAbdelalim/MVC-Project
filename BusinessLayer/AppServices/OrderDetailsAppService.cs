using Business_layer.Bases;
using Business_layer.ViewModel;
using Data_access_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_layer.AppServices
{
    public class OrderDetailsAppService : BaseAppService
    {
        #region CURD

        public List<OrderDetailsViewModel> GetAllOrderDetails()
        {

            return Mapper.Map<List<OrderDetailsViewModel>>(TheUnitOfWork.OrderDetails.GetAllOrderDetail());
        }
        public OrderDetailsViewModel GetOrderDetails(int id)
          {
              return Mapper.Map<OrderDetailsViewModel>(TheUnitOfWork.OrderDetails.GetById(id));
          }



        public bool SaveNewOrdeDetails(OrderDetailsViewModel orderDetailsViewModel)
        {
            bool result = false;
            var orderDetail = Mapper.Map<OrderDetails>(orderDetailsViewModel);
            if (TheUnitOfWork.OrderDetails.Insert(orderDetail))
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return result;
        }


        public bool UpdatOrdeDetails(OrderDetailsViewModel orderDetailsViewModel)
        {
            var orderDetail = Mapper.Map<OrderDetails>(orderDetailsViewModel);
            TheUnitOfWork.OrderDetails.Update(orderDetail);
            TheUnitOfWork.Commit();

            return true;
        }


        public bool DeleteOrderDetails(int id)
        {
            bool result = false;

            TheUnitOfWork.OrderDetails.Delete(id);
            result = TheUnitOfWork.Commit() > new int();

            return result;
        }

       /* public bool CheckOrderDetailsExists(OrderDetailsViewModel orderDetailsViewModel)
        {
             OrderDetails orderDetail = Mapper.Map<OrderDetails>(orderDetailsViewModel);
            return TheUnitOfWork.OrderDetails.CheckOrderExists(orderDetail);
        }*/
        #endregion

    }
}
