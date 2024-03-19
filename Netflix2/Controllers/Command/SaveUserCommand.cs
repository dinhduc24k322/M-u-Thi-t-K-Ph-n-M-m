using Netflix2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Netflix2.Controllers.Command
{
    public class SaveUserCommand : IUserCommand
    {
        public void Execute(KhachHang user)
        {
            using (XemPhimEntities database = new XemPhimEntities())
            {
                KhachHang existingUser = database.KhachHang.FirstOrDefault(i => i.MaKH == user.MaKH);

                if (existingUser != null)
                {
                    // Cập nhật thông tin người dùng
                    existingUser.TenDangNhap = user.TenDangNhap;
                    existingUser.HoTenKH = user.HoTenKH;
                    existingUser.MatKhau = user.MatKhau;
                    existingUser.Email = user.Email;
                }
                else
                {
                    // Thêm người dùng mới vào cơ sở dữ liệu
                    database.KhachHang.Add(user);
                }

                database.SaveChanges(); // Lưu thay đổi vào cơ sở dữ liệu
            }
        }
    }
}