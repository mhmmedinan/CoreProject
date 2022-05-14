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
    public class ContactManager:IContactService
    {
        private readonly IContactDal _contactDal;

        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }

        public IDataResult<List<Contact>> TGetAll()
        {
            return new SuccessDataResult<List<Contact>>(_contactDal.GetAll(), "Listeleme işlemi başarılı");
        }

        public IDataResult<Contact> TGetById(int id)
        {
            return new SuccessDataResult<Contact>(_contactDal.Get(x => x.Id == id), "Id'ye göre listeleme işlemi başarılı");
        }

        public IResult TAdd(Contact contact)
        {
            _contactDal.Add(contact);
            return new SuccessResult("Ekleme işlemi başarılı");
        }

        public IResult TDelete(Contact contact)
        {
            _contactDal.Delete(contact);
            return new SuccessResult("Silme işlemi başarılı");
        }

        public IResult TUpdate(Contact contact)
        {
            _contactDal.Update(contact);
            return new SuccessResult("Güncelleme işlemi başarılı");
        }
    }
}
