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
using DevExpress.Persistent.BaseImpl.PermissionPolicy;

namespace AplikasiKasirOmod.Module.BusinessObjects
{
    [DefaultClassOptions]
    [NavigationItem("Kasir")]
    [DeferredDeletion(false)]
    public class Kasir : XPObject
    { 
        public Kasir(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            _KodePenjualan = "PJL" + GetMaxOid().ToString("D4");
            _NomorNota = DateTime.Now.ToString("ddMMyy") + GetMaxOid().ToString("D4");
            CreatedOn = DateTime.Now;
            CreatedBy = GetCurrentUser();
            _TanggalPenjualan = DateTime.Now;
        }

        #region Object

        [Persistent("TanggalPenjualan")]
        private DateTime _TanggalPenjualan;
        [Persistent("KodePenjualan")]
        private string _KodePenjualan;
        [PersistentAlias("_KodePenjualan")]
        public string KodePenjualan
        {
            get { return _KodePenjualan; }
        }

        [Persistent("NomorNota")]
        private string _NomorNota;
        [PersistentAlias("_NomorNota")]
        public string NomorNota
        {
            get { return _NomorNota; }
        }


        [PersistentAlias("_TanggalPenjualan")]
        public DateTime TanggalPenjualan
        {
            get { return _TanggalPenjualan; }
        }

        private string _Pelanggan;
        [Size(20)]
        public string Pelanggan
        {
            get
            {
                return _Pelanggan;
            }
            set
            {
                SetPropertyValue("Pelanggan", ref _Pelanggan, value);
            }
        }

        private decimal _TotalHarga;
        public decimal TotalHarga
        {
            get
            {
                return _TotalHarga;
            }
            set
            {
                SetPropertyValue("TotalHarga", ref _TotalHarga, value);
            }
        }

        [Association("Kasir-DetailKasir",typeof(DetailKasir))]
        [DevExpress.Xpo.Aggregated]
        public XPCollection<DetailKasir> DetailKasir
        {
            get
            {
                return GetCollection<DetailKasir>("DetailKasir");
            }
        }

        #endregion


        #region GetMaxOid()
        protected int GetMaxOid()
        {
            int x = 0;
            return x = Convert.ToInt32(Session.Evaluate<Kasir>(DevExpress.Data.Filtering.CriteriaOperator.Parse("Max(Oid)"), null)) + 1;
        }
        #endregion

        #region GetCurrentUser()
        PermissionPolicyUser GetCurrentUser()
        {
            return Session.GetObjectByKey<PermissionPolicyUser>(SecuritySystem.CurrentUserId);
        }
        #endregion

        #region OnSaving()
        protected override void OnSaving()
        {
            base.OnSaving();
            UpdatedOn = DateTime.Now;
            UpdatedBy = GetCurrentUser();
        }
        #endregion

        #region Created & Update Tracking

        private PermissionPolicyUser _CreatedBy;
        [ModelDefault("AllowEdit", "False")]
        public PermissionPolicyUser CreatedBy
        {
            get
            {
                return _CreatedBy;
            }
            set
            {
                SetPropertyValue("CreatedBy", ref _CreatedBy, value);
            }
        }

        private DateTime _CreatedOn;
        [ModelDefault("AllowEdit", "False"), ModelDefault("DisplayFormat", "G")]
        public DateTime CreatedOn
        {
            get
            {
                return _CreatedOn;
            }
            set
            {
                SetPropertyValue("CreatedOn", ref _CreatedOn, value);
            }
        }

        private PermissionPolicyUser _UpdatedBy;
        [ModelDefault("AllowEdit", "False")]
        public PermissionPolicyUser UpdatedBy
        {
            get
            {
                return _UpdatedBy;
            }
            set
            {
                SetPropertyValue("UpdatedBy", ref _UpdatedBy, value);
            }
        }

        private DateTime _UpdatedOn;
        [ModelDefault("AllowEdit", "False"), ModelDefault("DisplayFormat", "G")]
        public DateTime UpdatedOn
        {
            get
            {
                return _UpdatedOn;
            }
            set
            {
                SetPropertyValue("UpdatedOn", ref _UpdatedOn, value);
            }
        }
        #endregion
    }
}