using Business_layer.Bases;
using Business_layer.ViewModel;
using BusinessLayer.ViewModel;
using Data_access_Layer;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.AppServices
{
    class CartDetailsAppServiece: BaseAppService
    {

        #region CURD

        public List<CartDetailsViewModel> GetAllCartDetailsr()
    {


        return Mapper.Map<List<CartDetailsViewModel>>(TheUnitOfWork.CartDetails.GetAllCartDetails());
    }
    public CartDetailsViewModel GetCartDetails(int id)
    {
        return Mapper.Map<CartDetailsViewModel>(TheUnitOfWork.CartDetails.GetById(id));
    }



    public bool SaveNewSCartDetails(CartDetailsViewModel CartDetailsViewModel)
    {
        bool result = false;
        var shipper = Mapper.Map<Shipper>(CartDetailsViewModel);
        if (TheUnitOfWork.Shipper.Insert(shipper))
        {
            result = TheUnitOfWork.Commit() > new int();
        }
        return result;
    }


    public bool UpdatCartDetails(CartDetailsViewModel CartDetailsViewModel)
    {
        var shipper = Mapper.Map<Shipper>(CartDetailsViewModel);
        TheUnitOfWork.Shipper.Update(shipper);
        TheUnitOfWork.Commit();

        return true;
    }


    public bool DeleteSCartDetails(int id)
    {
        bool result = false;

        TheUnitOfWork.CartDetails.Delete(id);
        result = TheUnitOfWork.Commit() > new int();

        return result;
    }

    public bool CheckCartDetailsExists(CartDetailsViewModel CartDetailsiewModel)
    {
        var shipper = Mapper.Map<Shipper>(CartDetailsiewModel);
        return TheUnitOfWork.Shipper.CheckShipperExists(shipper);
    }
    #endregion

}
}
