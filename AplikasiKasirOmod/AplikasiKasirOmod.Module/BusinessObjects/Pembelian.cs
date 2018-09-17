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
    [NavigationItem("Pembelian")]
    [DeferredDeletion(false)]
    public class Pembelian : XPObject
    { 
        public Pembelian(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            _KodePembelian = "PBL" + GetMaxOid().ToString("D4");
            CreatedOn = DateTime.Now;
            CreatedBy = GetCurrentUser();
            _TanggalPembelian = DateTime.Now;
        }
        
        #region Object

        [Persistent("TanggalPembelian")]
        private DateTime _TanggalPembelian;
        [Persistent("KodePembelian")]
        private string _KodePembelian;
        [PersistentAlias("_KodePembelian")]
        public string KodePembelian
        {
            get { return _KodePembelian; }
        }


        [PersistentAlias("_TanggalPembelian")]
        public DateTime TanggalPembelian
        {
            get { return _TanggalPembelian; }
        }
        

        private MasterSupplier _Supplier;
        public MasterSupplier Supplier
        {
            get
            {
                return _Supplier;
            }
            set
            {
                SetPropertyValue("Supplier", ref _Supplier, value);
            }
        }
        
        private string _NomorNota;
        [Size(20)]
        public string NomorNota
        {
            get
            {
                return _NomorNota;
            }
            set
            {
                SetPropertyValue("NomorNota", ref _NomorNota, value);
            }
        }


        private string _Keterangan;
        [Size(SizeAttribute.Unlimited)]
        public string Keterangan
        {
            get
            {
                return _Keterangan;
            }
            set
            {
                SetPropertyValue("Keterangan", ref _Keterangan, value);
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

        [Association("Pembelian-DetailPembelian",typeof(DetailPembelian))]
        [DevExpress.Xpo.Aggregated]
        public XPCollection<DetailPembelian>DetailPembelian
        {
            get
            {
                return GetCollection<DetailPembelian>("DetailPembelian");
            }
        }
        #endregion

        #region GetMaxOid()
        protected int GetMaxOid()
        {
            int x = 0;
            return x = Convert.ToInt32(Session.Evaluate<Pembelian>(DevExpress.Data.Filtering.CriteriaOperator.Parse("Max(Oid)"), null)) + 1;
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