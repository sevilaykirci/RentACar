using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Helpers.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }
      

        public IDataResult<List<CarImage>> GetByCarId(int id)
        {
            var result = _carImageDal.GetAll(p => p.CarId == id);
            if (result == null)
            {
                return new ErrorDataResult<List<CarImage>>(); 
            }
            return new SuccessDataResult<List<CarImage>>(result);
        }

        [SecuredOperation("carImage.add, admin")]
        //[ValidationAspect(typeof(CarImageValidator))]
        public IResult Insert(IFormFile file,CarImage carImage) //file:resim carmimage:class
        {
            IResult result = BusinessRules.Run(CheckImageLimitExceeded(carImage.CarId));
            if (result.Success)
            {
                carImage.ImagePath = FileHelper.Add(file);
                carImage.Date = DateTime.Now;
                _carImageDal.Add(carImage);
                return new SuccessResult(Messages.Added);
            }
            else
            {
                return new ErrorResult("ERROR");
            }
        }

        public IResult Update(CarImage carImage)
        {
            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.Updated);
        }

        public IResult Delete(CarImage carImage)
        {
            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.Deleted);
        }

        private IResult CheckImageLimitExceeded(int carId)
        {
            var carImageCount = _carImageDal.GetAll(p => p.CarId == carId).Count;
            if (carImageCount>=5)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }

        private IResult CheckImageExists(int carId)
        {
            var result = _carImageDal.GetAll(p => p.CarId == carId).Any();
            if (result)
            {
                return new SuccessResult() ;
            }
            return new ErrorResult();
        }


        
        
    }
}

        
    


