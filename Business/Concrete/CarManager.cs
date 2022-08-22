
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete 
{
    public class CarManager : ICarService
    {
        /*EfCarDal _cardal = new EfCarDal(); Bu yontem bellegi yorar. */
        ICarDal _carDal;
       

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        [CacheAspect]
        //[SecuredOperation("admin")]
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarListed);
        }

        public IDataResult<List<Car>> GetAllByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(x => x.ColorId == id));
        }

        public IDataResult<List<CarDetailDto>> GetAllDto()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetAllDto(),Messages.CarListed);
        }

        public IDataResult<List<CarDetailDto>> GetAllDtoByColorId(int id)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetAllDto(x => x.ColorId == id),Messages.CarListed);
        }

        public IDataResult<List<CarDetailDto>> GetAllDtoByBrandId(int id)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetAllDto(x => x.BrandId == id), Messages.CarListed);
        }


        [CacheAspect]
        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(x => x.Id == id), Messages.CarListed);
        }

        public IDataResult<CarDetailDto> GetDtoById(int id)
        {
            return new SuccessDataResult<CarDetailDto>(_carDal.GetDtoById(x => x.Id == id) , Messages.CarListed);
        }

        // [ValidationAspect(typeof(productvalidator))]
        
        //[SecuredOperation("car.add,admin")]
        [ValidationAspect(typeof(CarValidator))] //add metodunu dogrula car validatoru kullanarak
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Insert(Car car)
        {

            //validation
            //validation kullanimi
            //_logger.Log();

            //try
            //{
            //    _carDal.Add(car);
            //    return new Result(Messages.Added);
            //}
            //catch (Exception)
            //{

            //    _logger.Log();
            //}
            //return new ErrorResult();

            _carDal.Add(car);
            return new SuccessResult(Messages.Added);
        }

        [CacheRemoveAspect("ICarService.Get")]
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.Updated);
        }
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.Deleted);
        }

    }
}
