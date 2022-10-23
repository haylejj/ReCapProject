using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
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
              new Car(){ColorId=1,BrandId=1,ModelYear=2015,Id=1,DailyPrice=52000,Description="Skoda Octavia"},
              new Car(){ColorId=2,BrandId=2,ModelYear=2013,Id=2,DailyPrice=48000,Description="WV Golf"}
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car Delete=_cars.SingleOrDefault(c => c.Id==car.Id);
            _cars.Remove(Delete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(int carId)
        {
            return _cars.Where(c => c.Id==carId).ToList();
        }

        public void Update(Car car)
        {
            Car Update = _cars.SingleOrDefault(c => c.Id==car.Id);
            Update.DailyPrice=car.DailyPrice;
            Update.Description=car.Description;
            Update.ModelYear=car.ModelYear;
            Update.BrandId=car.BrandId;
            Update.ColorId=car.ColorId;

        }
    }
}
