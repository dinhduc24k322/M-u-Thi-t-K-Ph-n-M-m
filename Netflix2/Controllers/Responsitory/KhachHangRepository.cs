using Netflix2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Netflix2.Controllers.Responsitory
{
    public class KhachHangRepository
    {
        private XemPhimEntities database;

        public KhachHangRepository()
        {
            database = new XemPhimEntities();
        }

        public KhachHang GetById(int id)
        {
            return database.KhachHang.FirstOrDefault(i => i.MaKH == id);
        }

        public void Delete(KhachHang entity)
        {
            database.KhachHang.Remove(entity);
            database.SaveChanges();
        }

        public void Dispose()
        {
            database.Dispose();
        }
    }
}