using Netflix2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Netflix2.Controllers.Decorator
{
    public class PasswordValidationDecorator : IUserValidation
    {
        public bool Validate(KhachHang khachHang, ModelStateDictionary modelState)
        {
            var isValid = true;
            if (String.IsNullOrEmpty(khachHang.MatKhau))
            {
                modelState.AddModelError(String.Empty, "Mật Khẩu không được để trống");
                isValid = false;
            }
            return isValid;
        }
    }
}