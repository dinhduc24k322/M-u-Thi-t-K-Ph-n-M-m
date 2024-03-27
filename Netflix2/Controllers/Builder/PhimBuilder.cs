using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Netflix2.Models;

namespace Netflix2.Pattern.Builder
{
    public class PhimBuilder : IPhimBuilder
    {
        int IdPhim { get; set; }
        string TieuDe { get; set; }
         string TenPhim { get; set; }
         Nullable<System.DateTime> NamSanXuat { get; set; }
         string TheLoai { get; set; }
         string ThoiLuong { get; set; }
         string URLPhim { get; set; }
         string HinhMinhHoa { get; set; }
         string ChiTietPhim { get; set; }
         string DienVien { get; set; }
         string DaoDien { get; set; }

        public PhimBuilder setURLPhim(string urlphim)
        {
            this.URLPhim = urlphim;
            return this;
        }

        public PhimBuilder setChiTietPhim(string chitietphim)
        {
            this.ChiTietPhim = chitietphim;
            return this;
        }

        public PhimBuilder setDaoDien(string daodien)
        {
            this.DaoDien = daodien;
            return this;
        }

        public PhimBuilder setDienVien(string dienvien)
        {
            this.DienVien = dienvien;
            return this;
        }

        public PhimBuilder setHinhMinhHoa(string hinhminhhoa)
        {
            this.HinhMinhHoa = hinhminhhoa;
            return this;
        }

        public PhimBuilder setIdPhim(int idphim)
        {
            this.IdPhim = idphim;
            return this;
        }

        public PhimBuilder setNamSanXuat(DateTime? namsanxuat)
        {
            this.NamSanXuat = namsanxuat;
            return this;
        }

        public PhimBuilder setTenPhim(string tenphim)
        {
            this.TenPhim = tenphim;
            return this;
        }

        public PhimBuilder setTheLoai(string theloai)
        {
            this.TheLoai = theloai;
            return this;
        }

        public PhimBuilder setThoiLuong(string thoiluong)
        {
            this.ThoiLuong = thoiluong;
            return this;
        }

        public PhimBuilder setTieuDe(string tieude)
        {
            this.TieuDe = tieude;
            return this;
        }

        public Phim Build()
        {
            return new Phim
            {
                IdPhim = this.IdPhim,
                TieuDe = this.TieuDe,
                TenPhim = this.TenPhim,
                NamSanXuat = this.NamSanXuat,
                ThoiLuong = this.ThoiLuong,
                TheLoai = this.TheLoai,
                URLPhim = this.URLPhim,
                HinhMinhHoa = this.HinhMinhHoa,
                ChiTietPhim = this.ChiTietPhim,
                DaoDien = this.DaoDien,
                DienVien = this.DienVien,

            };
        }     

        
    }
}
