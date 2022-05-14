using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class PortfolioManager:IPortfolioService
    {
        private readonly IPortfolioDal _portfolioDal;

        public PortfolioManager(IPortfolioDal portfolioDal)
        {
            _portfolioDal = portfolioDal;
        }

        public IDataResult<List<Portfolio>> TGetAll()
        {
            return new SuccessDataResult<List<Portfolio>>(_portfolioDal.GetAll(), "Listeleme işlemi başarılı");
        }

        public IDataResult<Portfolio> TGetById(int id)
        {
            return new SuccessDataResult<Portfolio>(_portfolioDal.Get(x => x.Id == id), "Id'ye göre listeleme işlemi başarılı");
        }

        public IResult TAdd(Portfolio portfolio)
        {
            _portfolioDal.Add(portfolio);
            return new SuccessResult("Ekleme işlemi başarılı");
        }

        public IResult TDelete(Portfolio portfolio)
        {
            _portfolioDal.Delete(portfolio);
            return new SuccessResult("Silme işlemi başarılı");
        }

        public IResult TUpdate(Portfolio portfolio)
        {
            _portfolioDal.Update(portfolio);
            return new SuccessResult("Güncelleme işlemi başarılı");
        }
    }
}
