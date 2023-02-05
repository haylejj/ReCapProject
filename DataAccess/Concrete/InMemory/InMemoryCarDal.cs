using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars=new List<Car>()
            {
              new Car(){ColorId=1,BrandId=1,ModelYear=2015,CarId=1,DailyPrice=52000,CarName="Skoda Octavia"},
              new Car(){ColorId=2,BrandId=2,ModelYear=2013,CarId=2,DailyPrice=48000,CarName="WV Golf"}
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car Delete=_cars.SingleOrDefault(c => c.CarId==car.CarId);
            _cars.Remove(Delete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int carId)
        {
            return _cars.Where(c => c.CarId==carId).ToList();
        }

        public void Update(Car car)
        {
            Car Update = _cars.SingleOrDefault(c => c.CarId==car.CarId);
            Update.DailyPrice=car.DailyPrice;
            Update.CarName=car.CarName;
            Update.ModelYear=car.ModelYear;
            Update.BrandId=car.BrandId;
            Update.ColorId=car.ColorId;

        }
    }
}
