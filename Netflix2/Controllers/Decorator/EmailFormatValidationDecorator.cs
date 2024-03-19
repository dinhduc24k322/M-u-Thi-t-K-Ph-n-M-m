using Netflix2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace Netflix2.Controllers.Decorator
{
    public class EmailFormatValidationDecorator : IUserValidation
    {
        public bool Validate(KhachHang khachHang, ModelStateDictionary modelState)
        {
            var isValid = true;
            if (String.IsNullOrEmpty(khachHang.Email) || !Regex.IsMatch(khachHang.Email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
            {
                modelState.AddModelError(String.Empty, "Email không hợp lệ");
                isValid = false;
            }
            return isValid;
        }
    }
}