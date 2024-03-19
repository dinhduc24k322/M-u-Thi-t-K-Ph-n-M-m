using Netflix2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Netflix2.Controllers.Decorator
{
    public class FullNameValidationDecorator : IUserValidation
    {
        public bool Validate(KhachHang khachHang, ModelStateDictionary modelState)
        {
            var isValid = true;
            if (String.IsNullOrEmpty(khachHang.HoTenKH) || khachHang.HoTenKH.Length < 1)
            {
                modelState.AddModelError(String.Empty, "Họ Và Tên không hợp lệ");
                isValid = false;
            }
            return isValid;
        }
    }
}