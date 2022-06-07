﻿using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICarDal : IEntityRepository<Car>
    {
        List<CarDetailDto> GetAllDto(Expression<Func<Car, bool>> filter = null);
        CarDetailDto GetDtoById(Expression<Func<Car, bool>> filter);
    }
}
