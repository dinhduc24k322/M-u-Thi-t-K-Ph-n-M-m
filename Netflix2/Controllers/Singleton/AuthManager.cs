using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Netflix2.Models;

namespace Netflix2.Pattern.Singleton
{
    public class AuthManager
    {
        private static AuthManager instance;
        private XemPhimEntities db;

        private AuthManager()
        {
            db = new XemPhimEntities();
        }

        public static AuthManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AuthManager();
                }
                return instance;
            }
        }

        public KhachHang AuthenticaseKhachhang(string tendangnhap, string matkhau)
        {
            return db.KhachHang.FirstOrDefault(u => u.TenDangNhap == tendangnhap && u.MatKhau == matkhau);
        }




    }
}
