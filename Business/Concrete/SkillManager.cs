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
    public class SkillManager:ISkillService
    {
        private readonly ISkillDal _skillDal;

        public SkillManager(ISkillDal skillDal)
        {
            _skillDal = skillDal;
        }

        public IDataResult<List<Skill>> TGetAll()
        {
            return new SuccessDataResult<List<Skill>>(_skillDal.GetAll(), "Listeleme işlemi başarılı");
        }

        public IDataResult<Skill> TGetById(int id)
        {
            return new SuccessDataResult<Skill>(_skillDal.Get(x => x.Id == id), "Id'ye göre listeleme işlemi başarılı");
        }

        public IResult TAdd(Skill skill)
        {
            _skillDal.Add(skill);
            return new SuccessResult("Ekleme işlemi başarılı");
        }

        public IResult TDelete(Skill skill)
        {
            _skillDal.Delete(skill);
            return new SuccessResult("Silme işlemi başarılı");
        }

        public IResult TUpdate(Skill skill)
        {
            _skillDal.Update(skill);
            return new SuccessResult("Güncelleme işlemi başarılı");
        }
    }
}
