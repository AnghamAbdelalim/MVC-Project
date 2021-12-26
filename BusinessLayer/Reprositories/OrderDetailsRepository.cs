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
    public class OrderDetailsRepository : BaseRepository<OrderDetails>
    {
        private DbContext EC_DbContext;

        public OrderDetailsRepository(DbContext EC_DbContext) : base(EC_DbContext)
        {
            this.EC_DbContext = EC_DbContext;
        }
        #region CRUB

        public List<OrderDetails> GetAllOrderDetail()
        {
            return GetAll().ToList();
        }

        public bool InsertOrderDetail(OrderDetails orderDetail)
        {
            return Insert(orderDetail);
        }
        public void UpdateOrder(OrderDetails orderDetail)
        {
            Update(orderDetail);
        }
        public void DeleteorderDetail(int id)
        {
            Delete(id);
        }

        public bool CheckOrderExists(OrderDetails orderDetail)
        {
            return GetAny(l => l.OrderDetailId == orderDetail.OrderDetailId);
        }
    /*
        public Order GetOrderById(int id)
        {
            return GetFirstOrDefault(l => l.Id == id);
        }
    */
        #endregion


    }
}
