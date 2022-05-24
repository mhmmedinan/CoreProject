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
    public class ToDoListManager:IToDoListService
    {
        private readonly IToDoListDal _toDoListDal;

        public ToDoListManager(IToDoListDal toDoListDal)
        {
            _toDoListDal = toDoListDal;
        }

        public IDataResult<List<ToDoList>> TGetAll()
        {
            return new SuccessDataResult<List<ToDoList>>(_toDoListDal.GetAll(), "Listeleme işlemi başarılı");
        }

        public IDataResult<ToDoList> TGetById(int id)
        {
            return new SuccessDataResult<ToDoList>(_toDoListDal.Get(x => x.Id == id), "Id'ye göre listeleme işlemi başarılı");
        }

        public IResult TAdd(ToDoList toDoList)
        {
            _toDoListDal.Add(toDoList);
            return new SuccessResult("Ekleme işlemi başarılı");
        }

        public IResult TDelete(ToDoList toDoList)
        {
            _toDoListDal.Delete(toDoList);
            return new SuccessResult("Silme işlemi başarılı");
        }

        public IResult TUpdate(ToDoList toDoList)
        {
            _toDoListDal.Update(toDoList);
            return new SuccessResult("Güncelleme işlemi başarılı");
        }
    }
}
