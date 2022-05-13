using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;

namespace Business.Abstract
{
    public interface IGenericService<T>
    {
        IDataResult<List<T>> TGetAll();

        IDataResult<T> TGetById(int id);
        IResult TAdd(T entity);
        IResult TDelete(T entity);
        IResult TUpdate(T entity);

    }
}
