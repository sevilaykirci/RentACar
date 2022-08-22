using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CreditCardManager : ICreditCardService
    {
        private readonly ICreditCardDal _creditCardDal;

        public CreditCardManager(ICreditCardDal creditCardDal)
        {
            _creditCardDal = creditCardDal;
        }

        public IDataResult<CreditCard> Get(string cardNumber, string expireYear, string expireMonth, string cvc, string cardHolderFullName)
        {
            var creditCard = GetCreditCardByCardInfo(cardNumber, expireYear, expireMonth, cvc, cardHolderFullName);

            if (creditCard!= null) 
            {
                return new SuccessDataResult<CreditCard>(/*creditCard*/);
            }
            return new ErrorDataResult<CreditCard>(null, Messages.CreditCardNotValid);
        }


        public IDataResult<CreditCard> GetById(int creditCardId)
        {
            var creditCard = _creditCardDal.Get(c => c.Id == creditCardId);

            if(creditCard != null)
            {
                return new SuccessDataResult<CreditCard>(creditCard, Messages.Listed);
            }

            return new ErrorDataResult<CreditCard>(null, Messages.CreditCardNotFound);
        }

        public IResult Update(CreditCard creditCard)
        {
            _creditCardDal.Update(creditCard);
            return new SuccessResult();
        }

        public IResult Validate(CreditCard creditCard)
        {
            var validateResult = GetCreditCardByCardInfo(creditCard.CardNumber, creditCard.ExpireYear, creditCard.ExpireMonth, creditCard.Cvc, creditCard.CardHolderFullName);
            if (validateResult != null)
            {
                return new SuccessResult();
            }

            return new ErrorResult(Messages.CreditCardNotValid);
        }

        private object GetCreditCardByCardInfo(string cardNumber, string expireYear, string expireMonth, string cvc, string cardHolderFullName)
        {
            return _creditCardDal.Get(c => c.CardNumber == cardNumber &&
                                            c.ExpireYear == expireYear &&
                                            c.ExpireMonth == expireMonth &&
                                            c.Cvc == cvc &&
                                            c.CardHolderFullName == cardHolderFullName.ToUpperInvariant()); // Convert Turkish characters into standard characters.
        }
    }

}
