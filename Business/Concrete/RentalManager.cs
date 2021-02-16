﻿using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }
        public IResult Add(Rental rental)
        {
            var rentalReturnDate = _rentalDal.GetAll(r => r.CarId == rental.CarId);

            if (rentalReturnDate.Count > 0)
            {
                foreach (var rentalReturnDatee in rentalReturnDate)
                {
                    if (rentalReturnDatee.ReturnDate == null)
                    {
                        return new ErrorResult(Messages.RentalReturnDateIsNull);
                    }
                }
            }

            _rentalDal.Add(rental); 
           return new SuccessResult(Messages.RentalAdded);
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.RentalListed);
        }

        public IDataResult<Rental> GetById(int rentalId)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.Id == rentalId));
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails());
        }

        public IResult Update(Rental rental)
        {
            var updatedRental = _rentalDal.Get(r => r.CarId == rental.CarId);
            if (updatedRental.ReturnDate != null)
            {
                return new ErrorResult(Messages.RentalReturnDateIsNull);
            }

            updatedRental.ReturnDate = DateTime.Now;
            _rentalDal.Update(updatedRental);
            return new SuccessResult(Messages.RentalUpdated);
        }
        
    }
}
