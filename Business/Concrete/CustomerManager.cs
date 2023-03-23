using Business.Abstract;
using Business.Contants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _CustomerDal;
        public CustomerManager(ICustomerDal customerDal)
        {
            _CustomerDal = customerDal;
        }
        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Add(Customer customer)
        {
            //ValidationTool.Validate(new CustomerValidator(),customer);
            _CustomerDal.Add(customer);
            return new SuccessResult(Messages.ProductAdded);
        }

        public IResult Delete(Customer customer)
        {
            if (customer.UserId==0)
            {
                return new ErrorResult(Messages.ProductNotDeleted);
            }
            _CustomerDal.Delete(customer);
            return new SuccessResult(Messages.ProductDeleted);
        }

        public IDataResult<List<Customer>> GetAll()
        {
            if (DateTime.Now.Hour==23)
            {
                return new ErrorDataResult<List<Customer>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Customer>>(_CustomerDal.GetAll(), Messages.ProductLısted);
        }

        public IDataResult<List<Customer>> GetById(int UserId)
        {
            if(DateTime.Now.Hour==23)
            {
                return new ErrorDataResult<List<Customer>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Customer>>(_CustomerDal.GetAll(p => p.UserId==UserId), Messages.ProductLısted);
        }

        public IResult Update(Customer customer)
        {
            if (customer.UserId==0)
            {
                return new ErrorResult(Messages.ProductNotUpdated);
            }
            _CustomerDal.Update(customer);
            return new SuccessResult(Messages.ProductUpdated);
        }
    }
}
