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
    public class AboutManager:IAboutService
    {
        private readonly IAboutDal _aboutDal;

        public AboutManager(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }

        public IDataResult<List<About>> TGetAll()
        {
            return new SuccessDataResult<List<About>>(_aboutDal.GetAll(), "Listeleme işlemi başarılı");
        }

        public IDataResult<About> TGetById(int id)
        {
            return new SuccessDataResult<About>(_aboutDal.Get(x => x.Id == id),"Id'ye göre listeleme işlemi başarılı");
        }

        public IResult TAdd(About about)
        {
            _aboutDal.Add(about);
            return new SuccessResult("Ekleme işlemi başarılı");
        }

        public IResult TDelete(About about)
        {
            _aboutDal.Delete(about);
            return new SuccessResult("Silme işlemi başarılı");
        }

        public IResult TUpdate(About about)
        {
            _aboutDal.Update(about);
            return new SuccessResult("Güncelleme işlemi başarılı");
        }
    }
}
