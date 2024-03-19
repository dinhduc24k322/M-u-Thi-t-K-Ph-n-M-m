using Netflix2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netflix2.Controllers.Command
{
    public interface IUserCommand
    {
        void Execute(KhachHang user);
    }
}
