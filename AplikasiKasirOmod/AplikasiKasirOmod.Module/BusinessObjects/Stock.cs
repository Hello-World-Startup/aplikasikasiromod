using System;
using System.Linq;
using System.Text;
using DevExpress.Xpo;
using DevExpress.ExpressApp;
using System.ComponentModel;
using DevExpress.ExpressApp.DC;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using System.Collections.Generic;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;

namespace AplikasiKasirOmod.Module.BusinessObjects
{
    [DefaultClassOptions]
    [DeferredDeletion(false)]
    public class Stock : XPObject
    {
        public Stock(Session session) : base(session) { }
        private double _Jumlah;
        public double Jumlah
        {
            get { return _Jumlah; }
            set
            {
                if (value < 0) value = 0;
                SetPropertyValue("Jumlah", ref _Jumlah, value);
            }
        }       
    }
}