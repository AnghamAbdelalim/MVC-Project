using Business_layer.Bases;
using Data_access_Layer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Reprositories
{
    public  class PaymentReprository : BaseRepository<Payment>
    {
        private DbContext EC_DbContext;

        public    PaymentReprository(DbContext EC_DbContext) : base(EC_DbContext)
    {
        this.EC_DbContext = EC_DbContext;
    }
    #region CRUB

    public List<Payment> GetAllPayment()
    {
        return GetAll().ToList();
    }

    public bool InsertPayment(Payment payment)
    {
        return Insert(payment);
    }
    public void UpdatePaymentr(Payment payment)
    {
        Update(payment);
    }
    public void DeletePayment(int id)
    {
        Delete(id);
    }

    public bool CheckPaymentExists(Payment payment)
    {
        return GetAny(l => l.PaymentID == payment.PaymentID);
    }



        public Payment GetPaymentById(int id)
        {
            return GetFirstOrDefault(l => l.PaymentID == id);
        }
        #endregion

    }
}
    