using Netflix2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Netflix2.Controllers.Iterator
{
    public class PhimIterator : InterfaceIterator
    {
        private readonly List<Phim> _phimList;
        // biết vị trí hiển thị danh sách
        private int position = 0;

        public PhimIterator(List<Phim> phimList)
        {
            _phimList = phimList;
        }

        // Kiểm coi có được chuyển trang không 
        public bool HasNext()
        {
            return position < _phimList.Count;

        }

        public object Next()
        {
            if (HasNext())
            {
                return _phimList[position++];

            }
            return null;
        }

    }
}