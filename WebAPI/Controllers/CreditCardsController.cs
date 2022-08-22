﻿using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditCardsController : ControllerBase
    {
        private readonly ICustomerCreditCardService _customerCreditCardService;

        public CreditCardsController(ICustomerCreditCardService customerCreditCardService)
        {
            _customerCreditCardService = customerCreditCardService;
        }

        [HttpPost("getcreditcardsbycustomerid")]
        public IActionResult GetCreditCardsByCustomerId([FromBody] int customerId)
        {
            var result = _customerCreditCardService.GetSavedCreditCardsByCustomerId(customerId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("savecreditcard")]
        public IActionResult SaveCreditCard(CustomerCreditCardModel customerCreditCardModel)
        {
            var result = _customerCreditCardService.SaveCustomerCreditCard(customerCreditCardModel);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("deletecreditcard")]
        public IActionResult DeleteCreditCard(CustomerCreditCardModel customerCreditCardModel)
        {
            var result = _customerCreditCardService.DeleteCustomerCreditCard(customerCreditCardModel);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }

    //public ActionResult Get(string cardNumber, string expireYear, string expireMonth, string cvc, string cardHolderFullName)
    //{
    //    var result = _creditCardService.Get(cardNumber, expireYear, expireMonth, cvc, cardHolderFullName);
    //    if (result.Success)
    //    {
    //        return Ok(result);
    //    }
    //    return BadRequest(result);
    //}
    //public ActionResult GetById(int creditCardId)
    //{
    //    var result = _creditCardService.GetById(creditCardId);
    //    if (result.Success)
    //    {
    //        return Ok(result);
    //    }
    //    return BadRequest(result);
    //}
    
}
