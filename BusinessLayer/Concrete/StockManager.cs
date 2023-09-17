using BusinessLayer.Abstract;
using BusinessLayer.Costants;
using Core.Utilities.Results;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class StockManager : IStockService
    {
        IStockDal _stockDal;

        public StockManager(IStockDal stockDal)
        {
            _stockDal = stockDal;
        }

        public IResult TAdd(Stock t)
        {
            _stockDal.Insert(t);
            return new SuccessResult(ResultMessages.SuccesMessage);
        }

        public IResult TDelete(Stock t)
        {
            _stockDal.Delete(t);
            return new SuccessResult(ResultMessages.SuccesMessage);
        }

        public IDataResult<List<Stock>> TGetList()
        {
            return new SuccessDataResult<List<Stock>>(_stockDal.GetList(), ResultMessages.SuccesMessage);
        }

        public IDataResult<Stock> TGeyByID(int id)
        {
            return new SuccessDataResult<Stock>(_stockDal.GetByID(id), ResultMessages.SuccesMessage);
        }

        public IResult TUpdate(Stock t)
        {
            _stockDal.Update(t);
            return new SuccessResult(ResultMessages.SuccesMessage);
        }
    }
}
