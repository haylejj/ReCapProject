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
    public class UserManager : IUserService
    {
        IUserDal _UserDal;
        public UserManager(IUserDal userDal)
        {
            _UserDal= userDal;
        }
        [ValidationAspect(typeof(UserValidator))]
        public IResult Add(User user)
        {
            //ValidationTool.Validate(new UserValidator(), user);
            _UserDal.Add(user);
            return new SuccessResult(Messages.ProductAdded);
        }

        public IResult Delete(User user)
        {
            if (user.UserId==0)
            {
                return new ErrorResult(Messages.ProductNotDeleted);
            }
            return new SuccessResult(Messages.ProductDeleted);
        }

        public IDataResult<List<User>> GetAll()
        {
            if (DateTime.Now.Hour==23)
            {
                return new ErrorDataResult<List<User>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<User>>(_UserDal.GetAll(), Messages.ProductLısted);
        }

        public IDataResult<List<User>> GetById(int userId)
        {
            if (DateTime.Now.Hour==23)
            {
                return new ErrorDataResult<List<User>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<User>>(_UserDal.GetAll(p => p.UserId==userId), Messages.ProductLısted);
        }

        public IResult Update(User user)
        {
            if (user.UserId==0)
            {
                return new ErrorResult(Messages.ProductNotUpdated);
            }
            return new ErrorResult(Messages.ProductUpdated);
        }
    }
}
