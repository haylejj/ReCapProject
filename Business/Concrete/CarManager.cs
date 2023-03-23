using Business.Abstract;
using Business.Contants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _CarDal;

        public CarManager(ICarDal carDal)
        {
            _CarDal=carDal;
        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            //ValidationTool.Validate(new CarValidator(),car);
            
            _CarDal.Add(car);
             return new SuccessResult(Messages.ProductAdded);
            
        }

        public IResult Delete(Car car)
        {
            if (car.CarName==null)
            {
                return new ErrorResult(Messages.ProductNotDeleted);
            }
            _CarDal.Delete(car);
            return new SuccessResult(Messages.ProductDeleted);
            
        }

        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour==23)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Car>>(_CarDal.GetAll(),Messages.ProductLısted);
            
        }

        public IDataResult<List<Car>> GetCarsByColorId(int colorid)
        {
           return new SuccessDataResult<List<Car>>(_CarDal.GetAll(p => p.ColorId==colorid),Messages.ProductLısted);
        }

        public IDataResult<List<Car>> GetsCarsByBrandId(int brandid)
        {
            return new SuccessDataResult<List<Car>>( _CarDal.GetAll(p=>p.BrandId==brandid),Messages.ProductLısted);
        }

        public IDataResult<List<Car>> GetsCarsByRentalId(int rentalid)
        {
            return new SuccessDataResult<List<Car>>(_CarDal.GetAll(p => p.CarId==rentalid), Messages.ProductLısted);
        }

        public IResult Update(Car car)
        {
            _CarDal.Update(car);
            return new SuccessResult(Messages.ProductUpdated);
        }
    }
}
