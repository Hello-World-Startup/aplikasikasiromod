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
    [NavigationItem("Penjualan")]
    [DeferredDeletion(false)]
    public class DetailPenjualan : XPObject
    { 
        public DetailPenjualan(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            _KodeDetailPenjualan = "DPJL" + GetMaxOid().ToString("D4");            
            CreatedOn = DateTime.Now;
            CreatedBy = GetCurrentUser();
        }

        #region Object

        [Persistent("KodeDetailPenjualan")]
        private string _KodeDetailPenjualan;
        [PersistentAlias("_KodeDetailPenjualan")]
        public string KodeDetailPenjualan
        {
            get { return _KodeDetailPenjualan; }
        }

        private MasterMenu _Menu;
        public MasterMenu Menu
        {
            get
            {
                return _Menu;
            }
            set
            {
                SetPropertyValue("Menu", ref _Menu, value);
            }
        }

        private double _Jumlah;
        public double Jumlah
        {
            get
            {
                return _Jumlah;
            }
            set
            {
                SetPropertyValue("Jumlah", ref _Jumlah, value);
            }
        }

        private MasterSatuan _Satuan;
        public MasterSatuan Satuan
        {
            get
            {
                return _Satuan;
            }
            set
            {
                SetPropertyValue("Satuan", ref _Satuan, value);
            }
        }

        private decimal _Harga;
        public decimal Harga
        {
            get
            {
                return _Harga;
            }
            set
            {
                SetPropertyValue("Harga", ref _Harga, value);
            }
        }
        
        private decimal _SubTotal;
        public decimal SubTotal
        {
            get
            {
                return _SubTotal;
            }
            set
            {
                SetPropertyValue("SubTotal", ref _SubTotal, value);
            }
        }


        private Penjualan _Penjualan;
        [Association("Penjualan-DetailPenjualan",typeof(Penjualan))]
        public Penjualan Penjualan
        {
            get
            {
                return _Penjualan;
            }
            set
            {
                SetPropertyValue("Penjualan", ref _Penjualan, value);
            }
        }
        #endregion

        #region GetMaxOid()
        protected int GetMaxOid()
        {
            int x = 0;
            return x = Convert.ToInt32(Session.Evaluate<DetailPenjualan>(DevExpress.Data.Filtering.CriteriaOperator.Parse("Max(Oid)"), null)) + 1;
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