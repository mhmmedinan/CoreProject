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
    public class TestimonialManager:ITestimonialService
    {
        private readonly ITestimonialDal _testimonialsDal;

        public TestimonialManager(ITestimonialDal testimonialsDal)
        {
            _testimonialsDal = testimonialsDal;
        }

        public IDataResult<List<Testimonial>> TGetAll()
        {
            return new SuccessDataResult<List<Testimonial>>(_testimonialsDal.GetAll(), "Listeleme işlemi başarılı");
        }

        public IDataResult<Testimonial> TGetById(int id)
        {
            return new SuccessDataResult<Testimonial>(_testimonialsDal.Get(x => x.Id == id), "Id'ye göre listeleme işlemi başarılı");
        }

        public IResult TAdd(Testimonial testimonials)
        {
            _testimonialsDal.Add(testimonials);
            return new SuccessResult("Ekleme işlemi başarılı");
        }

        public IResult TDelete(Testimonial testimonials)
        {
            _testimonialsDal.Delete(testimonials);
            return new SuccessResult("Silme işlemi başarılı");
        }

        public IResult TUpdate(Testimonial testimonials)
        {
            _testimonialsDal.Update(testimonials);
            return new SuccessResult("Güncelleme işlemi başarılı");
        }
    }
}
