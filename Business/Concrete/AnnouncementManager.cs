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
    public class AnnouncementManager:IAnnouncementService
    {
        private readonly IAnnouncementDal _announcementDal;

        public AnnouncementManager(IAnnouncementDal announcementDal)
        {
            _announcementDal = announcementDal;
        }
        public IDataResult<List<Announcement>> TGetAll()
        {
            return new SuccessDataResult<List<Announcement>>(_announcementDal.GetAll(), "Listeleme işlemi başarılı");
        }

        public IDataResult<Announcement> TGetById(int id)
        {
            return new SuccessDataResult<Announcement>(_announcementDal.Get(x => x.Id == id), "Id'ye göre listeleme işlemi başarılı");
        }

        public IResult TAdd(Announcement announcement)
        {
            _announcementDal.Add(announcement);
            return new SuccessResult("Ekleme işlemi başarılı");
        }

        public IResult TDelete(Announcement announcement)
        {
            _announcementDal.Delete(announcement);
            return new SuccessResult("Silme işlemi başarılı");
        }

        public IResult TUpdate(Announcement announcement)
        {
            _announcementDal.Update(announcement);
            return new SuccessResult("Güncelleme işlemi başarılı");
        }

        public IDataResult<List<Announcement>> GetAllOrderByDesc()
        {
            return new SuccessDataResult<List<Announcement>>(_announcementDal.GetAll().OrderByDescending(x => x.Date)
                .ToList());
        }

        
    }
}
