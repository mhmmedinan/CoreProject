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
    public class SocialMediaManager:ISocialMediaService
    {
        private ISocialMediaDal _socialMediaDal;

        public SocialMediaManager(ISocialMediaDal socialMediaDal)
        {
            _socialMediaDal = socialMediaDal;
        }

        public IDataResult<List<SocialMedia>> TGetAll()
        {
            return new SuccessDataResult<List<SocialMedia>>(_socialMediaDal.GetAll(), "Listeleme işlemi başarılı");
        }

        public IDataResult<SocialMedia> TGetById(int id)
        {
            return new SuccessDataResult<SocialMedia>(_socialMediaDal.Get(x => x.Id == id), "Id'ye göre listeleme işlemi başarılı");
        }

        public IResult TAdd(SocialMedia socialMedia)
        {
            _socialMediaDal.Add(socialMedia);
            return new SuccessResult("Ekleme işlemi başarılı");
        }

        public IResult TDelete(SocialMedia socialMedia)
        {
            _socialMediaDal.Delete(socialMedia);
            return new SuccessResult("Silme işlemi başarılı");
        }

        public IResult TUpdate(SocialMedia socialMedia)
        {
            _socialMediaDal.Update(socialMedia);
            return new SuccessResult("Güncelleme işlemi başarılı");
        }
    }
}
