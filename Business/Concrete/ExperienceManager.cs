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
    public class ExperienceManager:IExperienceService
    {
        private readonly IExperienceDal _experienceDal;

        public ExperienceManager(IExperienceDal experienceDal)
        {
            _experienceDal = experienceDal;
        }

        public IDataResult<List<Experience>> TGetAll()
        {
            return new SuccessDataResult<List<Experience>>(_experienceDal.GetAll(), "Listeleme işlemi başarılı");
        }

        public IDataResult<Experience> TGetById(int id)
        {
            return new SuccessDataResult<Experience>(_experienceDal.Get(x => x.Id == id), "Id'ye göre listeleme işlemi başarılı");
        }

        public IResult TAdd(Experience experience)
        {
            _experienceDal.Add(experience);
            return new SuccessResult("Ekleme işlemi başarılı");
        }

        public IResult TDelete(Experience experience)
        {
            _experienceDal.Delete(experience);
            return new SuccessResult("Silme işlemi başarılı");
        }

        public IResult TUpdate(Experience experience)
        {
            _experienceDal.Update(experience);
            return new SuccessResult("Güncelleme işlemi başarılı");
        }
    }
}
