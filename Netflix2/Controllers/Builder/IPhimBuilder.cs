using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netflix2.Pattern.Builder
{
    internal interface IPhimBuilder
    {
        PhimBuilder setIdPhim(int idphim);
        PhimBuilder setTieuDe(string tieude);
        PhimBuilder setTenPhim(string tenphim);
        PhimBuilder setNamSanXuat(Nullable<System.DateTime> namsanxuat);
        PhimBuilder setTheLoai(string theloai);
        PhimBuilder setThoiLuong(string thoiluong);
        PhimBuilder setURLPhim(string urlphim);
        PhimBuilder setHinhMinhHoa(string hinhminhhoa);
        PhimBuilder setChiTietPhim(string chitietphim);
        PhimBuilder setDienVien(string dienvien);
        PhimBuilder setDaoDien(string daodien);


    }
}
