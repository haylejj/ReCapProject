using Business.Abstract;
using Business.Contants;
using Business.ValidationRules.FluentValidation;
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
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal=brandDal;
        }

        public IResult Add(Brand brand)
        {
            ValidationTool.Validate(new BrandValidator(), brand);
            _brandDal.Add(brand);
            return new SuccessResult(Messages.ProductAdded);
        }

        public IResult Delete(Brand brand)
        {
            if (brand.BrandName==null)
            {
                return new ErrorResult(Messages.ProductNotDeleted);
            }
            _brandDal.Delete(brand);
            return new SuccessResult(Messages.ProductDeleted);
        }

        public IDataResult<List<Brand>> GetAll()
        {
            if (DateTime.Now.Hour==23)
            {
                return new ErrorDataResult<List<Brand>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(),Messages.ProductLısted);
        }

        public IDataResult<List<Brand>> GetById(int brandId)
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(p=>p.BrandId == brandId),Messages.ProductLısted);
        }

        public IResult Update(Brand brand)
        {
            if (brand.BrandName==null)
            {
                return new ErrorResult(Messages.ProductNotUpdated);
            }
            _brandDal.Update(brand);
            return new SuccessResult(Messages.ProductUpdated);
        }
    }
}
