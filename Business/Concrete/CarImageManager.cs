using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
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
        public IResult Delete(CarImage carImage)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<CarImage>> GetById(int id)
        {
            var result = _carImageDal.GetAll(p => p.CarId == id);
            if (result == null)
            {
                return new ErrorDataResult<List<CarImage>>(); 
            }
            return new SuccessDataResult<List<CarImage>>();
        }

        [SecuredOperation("carImage.add, admin")]
        //[ValidationAspect(typeof(CarImageValidator))]
        public IResult Insert(CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckImageExists(carImage.CarId));


            if (result != null )
            {
                return result;
            }

            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.Added);
            //cannot convert to int to bool.
        }

        public IResult Update(CarImage carImage)
        {
            throw new NotImplementedException();
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

        
    


