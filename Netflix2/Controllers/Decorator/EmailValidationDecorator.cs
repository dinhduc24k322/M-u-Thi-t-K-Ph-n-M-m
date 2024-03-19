using Netflix2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Netflix2.Controllers.Decorator
{
    public class EmailValidationDecorator : IUserValidation
    {
        public XemPhimEntities database;
        public bool Validate(KhachHang khachHang, ModelStateDictionary modelState)
        {
            database = new XemPhimEntities();
            var isValid = true;
            var existingEmail = database.KhachHang.FirstOrDefault(k => k.Email == khachHang.Email);
            if (existingEmail != null)
            {
                modelState.AddModelError(String.Empty, "Địa chỉ Email đã được sử dụng, vui lòng chọn địa chỉ Email khác.");
                isValid = false;
            }
            return isValid;
        }
    }
}