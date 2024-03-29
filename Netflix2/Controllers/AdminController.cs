﻿using Netflix2.Controllers.Command;
using Netflix2.Controllers.Iterator;
using Netflix2.Controllers.Observer;
using Netflix2.Controllers.Responsitory;
using Netflix2.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace Netflix2.Controllers
{
    public class AdminController : Controller, IKhachHangObserver
    {
        private KhachHangRepository khachHangRepository;

        private KhachHangSubject khachHangSubject = new KhachHangSubject();
        // GET: Admin
        XemPhimEntities database = new XemPhimEntities();
        // GET: Admin
        //Hiện thông tin các bộ Phim
        public AdminController()
        {
            khachHangRepository = new KhachHangRepository();
        }
        public ActionResult QuanLyPhim()
        {
            //using (var dbContext = new XemPhimEntities())
            //{

            //    var items = dbContext.Phim.ToList();

            //    return View(items);
            //}
            var phimList = database.Phim.ToList();
            var phimIterator = new PhimIterator(phimList);
            // lấy từng bộ phim trong danh sách phim 
            var items = new List<Phim>();
            while (phimIterator.HasNext())
            {
                items.Add((Phim)phimIterator.Next());

            }
            return View(items);

        }

        public ActionResult AddPhim(Phim phim)
        {
            if (ModelState.IsValid)
            {
                if (String.IsNullOrEmpty(phim.TenPhim) || phim.TenPhim.Length < 1 || phim.TenPhim.Length > 50)
                    ModelState.AddModelError(String.Empty, "Tên Phim không được để trống và phải có ít nhất 1 ký tự, không quá 50 ký tự");
                if (String.IsNullOrEmpty(phim.URLPhim))
                    ModelState.AddModelError(String.Empty, "Url không được để trống");
                if (String.IsNullOrEmpty(phim.HinhMinhHoa))
                    ModelState.AddModelError(String.Empty, "Hình minh họa không được để trống");
                if (String.IsNullOrEmpty(phim.ThoiLuong))
                    ModelState.AddModelError(String.Empty, "Thời lượng không được để trống");         
                else
                {
                    if (!TimeSpan.TryParse(phim.ThoiLuong, out _))
                    {
                        ModelState.AddModelError("ThoiLuong", "Thời Lượng không hợp lệ. Hãy nhập giá trị kiểu thời gian đúng.");
                    }
                }
                if (ModelState.IsValid)
                {
                    database.Phim.Add(phim);
                    database.SaveChanges();
                }
                else
                {
                    return View();
                }
            }
            return RedirectToAction("QuanLyPhim");
        }
        public ActionResult SuaPhim(int Id)
        {
            XemPhimEntities database = new XemPhimEntities();
            Phim e = database.Phim.Where(i => i.IdPhim == Id).FirstOrDefault();

            database.Dispose();
            return View(e);
        }
        public ActionResult LuuPhim(Phim s)
        {
            XemPhimEntities database = new XemPhimEntities();
            Phim e = database.Phim.Where(i => i.IdPhim == s.IdPhim).FirstOrDefault();
            e.TieuDe = s.TieuDe;
            e.ChiTietPhim = s.ChiTietPhim;
            e.TenPhim = s.TenPhim;
            e.URLPhim = s.URLPhim;
            e.NamSanXuat = s.NamSanXuat;
            e.ChiTietPhim = s.ChiTietPhim;
            e.DaoDien = s.DaoDien;
            e.DienVien = s.DienVien;
            e.HinhMinhHoa = s.HinhMinhHoa;
            e.TheLoai = s.TheLoai;
            database.SaveChanges();
            database.Dispose();
            return Redirect("QuanLyPhim");
        }
        public ActionResult XoaPhim(int Id)
        {
            XemPhimEntities database = new XemPhimEntities();
            Phim e = database.Phim.Where(i => i.IdPhim == Id).FirstOrDefault();

            database.Dispose();
            return View(e);
        }
        public ActionResult XacNhanXoaPhim(Phim s)
        {
            XemPhimEntities database = new XemPhimEntities();
            Phim e = database.Phim.Where(i => i.IdPhim == s.IdPhim).FirstOrDefault();

            database.Phim.Remove(e);
            database.SaveChanges();
            database.Dispose();
            return Redirect("QuanLyPhim");
        }
        public ActionResult QuanLyUser()
        {
            using (var dbContext = new XemPhimEntities())
            {
                var items = dbContext.KhachHang.ToList();

                return View(items);
            }
        }
        public ActionResult AddUser(KhachHang khachHang)
        {
            if (ModelState.IsValid)
            {
                var existingEmail = database.KhachHang.FirstOrDefault(k => k.Email == khachHang.Email);
                if (existingEmail != null)
                {
                    ModelState.AddModelError(String.Empty, "Địa chỉ Email đã được sử dụng, vui lòng chọn địa chỉ Email khác.");
                }
                if (String.IsNullOrEmpty(khachHang.TenDangNhap) || khachHang.TenDangNhap.Length < 1 || !Regex.IsMatch(khachHang.TenDangNhap, "^[a-zA-Z0-9 ]*$"))
                {
                    ModelState.AddModelError(String.Empty, "Tên Đăng Nhập không hợp lệ");
                }

                if (String.IsNullOrEmpty(khachHang.HoTenKH) || khachHang.HoTenKH.Length < 1 )
                {
                    ModelState.AddModelError(String.Empty, "Họ Và Tên không hợp lệ");
                }

                if (String.IsNullOrEmpty(khachHang.Email) || !Regex.IsMatch(khachHang.Email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
                {
                    ModelState.AddModelError(String.Empty, "Email không hợp lệ");
                }

                if (String.IsNullOrEmpty(khachHang.MatKhau))
                {
                    ModelState.AddModelError(String.Empty, "Mật Khẩu không được để trống");
                }

                if (ModelState.IsValid)
                {
                    database.KhachHang.Add(khachHang);
                    database.SaveChanges();
                    return RedirectToAction("QuanLyUser");
                }
            }
            // Nếu ModelState không hợp lệ, quay lại view để hiển thị lỗi
            return View();
        }
        //public ActionResult SuaUser(int Id)
        //{
        //    XemPhimEntities database = new XemPhimEntities();
        //    KhachHang e = database.KhachHang.Where(i => i.MaKH == Id).FirstOrDefault();

        //    if (e != null)
        //    {
        //        // Kiểm tra hợp lệ cho email, họ tên và tên đăng nhập
        //        if (String.IsNullOrEmpty(e.TenDangNhap) || e.TenDangNhap.Length < 1 || !Regex.IsMatch(e.TenDangNhap, "^[a-zA-Z0-9 ]*$"))
        //        {
        //            ModelState.AddModelError(String.Empty, "Tên Đăng Nhập không hợp lệ");
        //        }

        //        if (String.IsNullOrEmpty(e.HoTenKH) || e.HoTenKH.Length < 1)
        //        {
        //            ModelState.AddModelError(String.Empty, "Họ Và Tên không hợp lệ");
        //        }

        //        if (String.IsNullOrEmpty(e.Email) || !e.Email.EndsWith("@gmail.com", StringComparison.OrdinalIgnoreCase))
        //        {
        //            ModelState.AddModelError(String.Empty, "Email không hợp lệ. Vui lòng nhập lại email");
        //        }

        //        return View(e);
        //    }

        //    database.Dispose();
        //    return RedirectToAction("QuanLyUser");
        //}
        public ActionResult SuaUser(int Id)
        {
            using (XemPhimEntities database = new XemPhimEntities())
            {
                KhachHang e = database.KhachHang.FirstOrDefault(i => i.MaKH == Id);

                if (e != null)
                {
                    ValidateUser(e);

                    return View(e);
                }

                return RedirectToAction("QuanLyUser");
            }
        }

        private void ValidateUser(KhachHang user)
        {
            if (String.IsNullOrEmpty(user.TenDangNhap) || user.TenDangNhap.Length < 1 || !Regex.IsMatch(user.TenDangNhap, "^[a-zA-Z0-9 ]*$"))
            {
                ModelState.AddModelError(String.Empty, "Tên Đăng Nhập không hợp lệ");
            }

            if (String.IsNullOrEmpty(user.HoTenKH) || user.HoTenKH.Length < 1)
            {
                ModelState.AddModelError(String.Empty, "Họ Và Tên không hợp lệ");
            }

            if (String.IsNullOrEmpty(user.Email) || !user.Email.EndsWith("@gmail.com", StringComparison.OrdinalIgnoreCase))
            {
                ModelState.AddModelError(String.Empty, "Email không hợp lệ. Vui lòng nhập lại email");
            }
        }
        public void Update(KhachHang khachHang)
        {
            // Xử lý cập nhật khi có thay đổi
            // Ví dụ: gửi email hoặc cập nhật dữ liệu khác
        }
        //public ActionResult LuuUser(KhachHang s)
        //{
        //    XemPhimEntities database = new XemPhimEntities();
        //    KhachHang e = database.KhachHang.Where(i => i.MaKH == s.MaKH).FirstOrDefault();
        //    e.TenDangNhap = s.TenDangNhap;
        //    e.HoTenKH = s.HoTenKH;
        //    e.MatKhau = s.MatKhau;
        //    e.Email = s.Email;

        //    database.SaveChanges();
        //    database.Dispose();
        //    return Redirect("QuanLyUser");
        //}
        public ActionResult LuuUser(KhachHang s)
        {
            IUserCommand saveUserCommand = new SaveUserCommand();
            saveUserCommand.Execute(s);

            return RedirectToAction("QuanLyUser");
        }
        //public ActionResult XoaUser(int Id)
        //{
        //    XemPhimEntities database = new XemPhimEntities();
        //    KhachHang e = database.KhachHang.Where(i => i.MaKH == Id).FirstOrDefault();

        //    database.Dispose();
        //    return View(e);
        //}
        public ActionResult XoaUser(int Id)
        {
            KhachHang e = khachHangRepository.GetById(Id);

            if (e == null)
            {
                // Xử lý trường hợp không tìm thấy người dùng
                return RedirectToAction("QuanLyUser");
            }

            khachHangRepository.Delete(e);
            khachHangRepository.Dispose();

            return RedirectToAction("QuanLyUser");
        }
        public ActionResult XacNhanXoaUser(KhachHang s)
        {
            XemPhimEntities database = new XemPhimEntities();
            KhachHang e = database.KhachHang.Where(i => i.MaKH == s.MaKH).FirstOrDefault();

            database.KhachHang.Remove(e);
            database.SaveChanges();
            database.Dispose();
            return Redirect("QuanLyUser");
        }
    }
}