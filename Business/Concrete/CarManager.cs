using Business.Abstract;
using Business.Contants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
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

        public IResult Add(Car car)
        {
            if (car.CarName.Length>2 &&  car.DailyPrice>0)
            {
                _CarDal.Add(car);
                return new SuccessResult(Messages.ProductAdded);
                
            }
            else
            {
                return new ErrorResult(Messages.ProductNotAdded);
            }
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
            return new SuccessDataResult<List<Car>>(_CarDal.GetAll(p => p.Id==rentalid), Messages.ProductLısted);
        }

        public IResult Update(Car car)
        {
            _CarDal.Update(car);
            return new SuccessResult(Messages.ProductUpdated);
        }
    }
}
