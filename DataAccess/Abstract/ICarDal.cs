﻿using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ICarDal
    {
        void Delete(Car car);
        void Add(Car car);
        void Update(Car car);

        List<Car> GetAll();
        List<Car> GetById(int carId);
    }
}
