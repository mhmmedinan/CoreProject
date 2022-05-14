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
    public class ServiceManager:IServiceService
    {
        private readonly IServiceDal _serviceDal;

        public ServiceManager(IServiceDal serviceDal)
        {
            _serviceDal = serviceDal;
        }

        public IDataResult<List<Service>> TGetAll()
        {
            return new SuccessDataResult<List<Service>>(_serviceDal.GetAll(), "Listeleme işlemi başarılı");
        }

        public IDataResult<Service> TGetById(int id)
        {
            return new SuccessDataResult<Service>(_serviceDal.Get(x => x.Id == id), "Id'ye göre listeleme işlemi başarılı");
        }

        public IResult TAdd(Service service)
        {
            _serviceDal.Add(service);
            return new SuccessResult("Ekleme işlemi başarılı");
        }

        public IResult TDelete(Service service)
        {
            _serviceDal.Delete(service);
            return new SuccessResult("Silme işlemi başarılı");
        }

        public IResult TUpdate(Service service)
        {
            _serviceDal.Update(service);
            return new SuccessResult("Güncelleme işlemi başarılı");
        }
    }
}
