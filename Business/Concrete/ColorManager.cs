using Business.Abstract;
using Business.Contants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
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
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal=colorDal;
        }
        [ValidationAspect(typeof(ColorValidator))]
        public IResult Add(Color color)
        {
            //ValidationTool.Validate(new ColorValidator(), color);
                _colorDal.Add(color);
                return new SuccessResult(Messages.ProductAdded);
            
        }

        public IResult Delete(Color color)
        {
            if (color.ColorName==null)
            {
                return new ErrorResult(Messages.ProductNotDeleted);
            }
            else
            {
                return new SuccessResult(Messages.ProductDeleted);
            }
        }

        public IDataResult<List<Color>> GetAll()
        {
            if (DateTime.Now.Hour==23)
            {
                return new ErrorDataResult<List<Color>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(), Messages.ProductLısted);
        }

        public IDataResult<List<Color>> GetById(int colorId)
        {
            if (DateTime.Now.Hour==23)
            {
                return new ErrorDataResult<List<Color>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(p=>p.ColorId==colorId), Messages.ProductLısted);
        }

        public IResult Update(Color color)
        {
            return new SuccessResult(Messages.ProductUpdated);
        }
    }
}
