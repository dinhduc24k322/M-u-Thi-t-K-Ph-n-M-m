using Netflix2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Netflix2.Controllers.Observer
{
    public class KhachHangSubject
    {
        private List<IKhachHangObserver> observers = new List<IKhachHangObserver>();

        public void AttachObserver(IKhachHangObserver observer)
        {
            observers.Add(observer);
        }

        public void DetachObserver(IKhachHangObserver observer)
        {
            observers.Remove(observer);
        }

        public void NotifyObservers(KhachHang khachHang)
        {
            foreach (var observer in observers)
            {
                observer.Update(khachHang);
            }
        }
    }
}