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
    public class RentalManager : IRentalService
    {
        IRentalDal _RentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _RentalDal = rentalDal;
        }
        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {
            //ValidationTool.Validate(new RentalValidator(), rental);
            _RentalDal.Add(rental);
            return new SuccessResult(Messages.ProductNotAdded);
        }

        public IResult Delete(Rental rental)
        {
            if (rental.RentalId==0)
            {
                return new ErrorResult(Messages.ProductNotDeleted);
            }
            _RentalDal.Delete(rental);
            return new SuccessResult(Messages.ProductDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            if (DateTime.Now.Hour==23)
            {
                return new ErrorDataResult<List<Rental>>( Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Rental>>(_RentalDal.GetAll(),Messages.ProductLısted);
        }

        public IDataResult<List<Rental>> GetById(int rentalId)
        {
            if (DateTime.Now.Hour==23)
            {
                return new ErrorDataResult<List<Rental>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Rental>>(_RentalDal.GetAll(p => p.RentalId==rentalId), Messages.ProductLısted);
        }

        public IResult Update(Rental rental)
        {
            if (rental.RentalId==0)
            {
                return new ErrorResult(Messages.ProductNotUpdated);
            }
            _RentalDal.Update(rental);
            return new SuccessResult(Messages.ProductUpdated);

        }
    }
}
