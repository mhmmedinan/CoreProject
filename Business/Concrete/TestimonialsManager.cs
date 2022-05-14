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
    public class TestimonialsManager:ITestimonialsService
    {
        private readonly ITestimonialsDal _testimonialsDal;

        public TestimonialsManager(ITestimonialsDal testimonialsDal)
        {
            _testimonialsDal = testimonialsDal;
        }

        public IDataResult<List<Testimonials>> TGetAll()
        {
            return new SuccessDataResult<List<Testimonials>>(_testimonialsDal.GetAll(), "Listeleme işlemi başarılı");
        }

        public IDataResult<Testimonials> TGetById(int id)
        {
            return new SuccessDataResult<Testimonials>(_testimonialsDal.Get(x => x.Id == id), "Id'ye göre listeleme işlemi başarılı");
        }

        public IResult TAdd(Testimonials testimonials)
        {
            _testimonialsDal.Add(testimonials);
            return new SuccessResult("Ekleme işlemi başarılı");
        }

        public IResult TDelete(Testimonials testimonials)
        {
            _testimonialsDal.Delete(testimonials);
            return new SuccessResult("Silme işlemi başarılı");
        }

        public IResult TUpdate(Testimonials testimonials)
        {
            _testimonialsDal.Update(testimonials);
            return new SuccessResult("Güncelleme işlemi başarılı");
        }
    }
}
