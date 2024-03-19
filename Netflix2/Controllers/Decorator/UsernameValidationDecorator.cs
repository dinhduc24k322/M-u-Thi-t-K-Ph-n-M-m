using Netflix2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace Netflix2.Controllers.Decorator
{
    public class UsernameValidationDecorator : IUserValidation
    {
        public bool Validate(KhachHang khachHang, ModelStateDictionary modelState)
        {
            var isValid = true;
            if (String.IsNullOrEmpty(khachHang.TenDangNhap) || khachHang.TenDangNhap.Length < 1 || !Regex.IsMatch(khachHang.TenDangNhap, "^[a-zA-Z0-9 ]*$"))
            {
                modelState.AddModelError(String.Empty, "Tên Đăng Nhập không hợp lệ");
                isValid = false;
            }
            return isValid;
        }
    }
}