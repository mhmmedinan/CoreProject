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
    public class FeatureManager:IFeatureService
    {
        private IFeatureDal _featureDal;

        public FeatureManager(IFeatureDal featureDal)
        {
            _featureDal = featureDal;
        }

        public IDataResult<List<Feature>> TGetAll()
        {
            return new SuccessDataResult<List<Feature>>(_featureDal.GetAll(), "Listeleme işlemi başarılı");
        }

        public IDataResult<Feature> TGetById(int id)
        {
            return new SuccessDataResult<Feature>(_featureDal.Get(x => x.Id == id), "Id'ye göre listeleme işlemi başarılı");
        }

        public IResult TAdd(Feature feature)
        {
            _featureDal.Add(feature);
            return new SuccessResult("Ekleme işlemi başarılı");
        }

        public IResult TDelete(Feature feature)
        {
            _featureDal.Delete(feature);
            return new SuccessResult("Silme işlemi başarılı");
        }

        public IResult TUpdate(Feature feature)
        {
            _featureDal.Update(feature);
            return new SuccessResult("Güncelleme işlemi başarılı");
        }
    }
}
