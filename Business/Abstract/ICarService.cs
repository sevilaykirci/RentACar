using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IDataResult<List<CarDetailDto>> GetAllDto();
        IDataResult<List<Car>> GetAllByColorId(int id);
        IDataResult<List<CarDetailDto>> GetAllDtoByColorId(int id);
        IDataResult<Car> GetById(int id);
        IDataResult<CarDetailDto> GetDtoById(int id);
        IResult Insert(Car car);
        IResult Delete(Car car);
        IResult Update(Car car);
    }
}
