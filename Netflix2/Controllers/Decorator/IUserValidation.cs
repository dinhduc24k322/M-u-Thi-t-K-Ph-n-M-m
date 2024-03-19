using Netflix2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Netflix2.Controllers.Decorator
{
    internal interface IUserValidation
    {
        bool Validate(KhachHang khachHang, ModelStateDictionary modelState);

    }
}
