using AutoMapper;
using Business_layer.Configur;
using Business_layer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_layer.Bases
{
    public class BaseAppService : IDisposable
    {
        #region Vars
        protected IUnitOfWork TheUnitOfWork { get; set; }

        protected readonly IMapper Mapper = MapperConfig.Mapper;
        #endregion

        #region CTR
        public BaseAppService()
        {
            TheUnitOfWork = new UnitOfWork();
        }

        public void Dispose()
        {
            TheUnitOfWork.Dispose();
        }
        #endregion
    }
}
