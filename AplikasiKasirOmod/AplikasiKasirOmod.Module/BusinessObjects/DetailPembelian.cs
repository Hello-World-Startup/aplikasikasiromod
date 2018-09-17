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
    public class DetailPembelian : XPObject
    { 
        public DetailPembelian(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            _KodeDetilPembelian = "DPBL" + GetMaxOid().ToString("D4");
            CreatedOn = DateTime.Now;
            CreatedBy = GetCurrentUser();
        }

        #region Object
              
        [Persistent("KodeDetilPembelian")]
        private string _KodeDetilPembelian;
        [PersistentAlias("_KodeDetilPembelian")]
        public string KodeDetilPembelian
        {
            get { return _KodeDetilPembelian; }
        }
        
        private MasterBarang _Barang;
        public MasterBarang Barang
        {
            get
            {
                return _Barang;
            }
            set
            {
                SetPropertyValue("Barang", ref _Barang, value);
            }
        }
        
        private double _JumlahBeli;
        public double JumlahBeli
        {
            get
            {
                return _JumlahBeli;
            }
            set
            {
                SetPropertyValue("JumlahBeli", ref _JumlahBeli, value);
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

        private decimal _HargaBeli;
        public decimal HargaBeli
        {
            get
            {
                return _HargaBeli;
            }
            set
            {
                SetPropertyValue("HargaBeli", ref _HargaBeli, value);
            }
        }
        
        private decimal _SubTotal;
        [ModelDefault("AllowEdit", "False")]
        public decimal SubTotal
        {
            get
            {
                return _SubTotal = Convert.ToDecimal(JumlahBeli)*HargaBeli;
            }
            set
            {
                SetPropertyValue("SubTotal", ref _SubTotal, value);
            }
        }

        private Pembelian _Pembelian;
        [Association("Pembelian-DetailPembelian",typeof(Pembelian))]
        public Pembelian Pembelian
        {
            get
            {
                return _Pembelian;
            }
            set
            {
                SetPropertyValue("Pembelian", ref _Pembelian, value);
            }
        }

        #endregion

        #region GetMaxOid()
        protected int GetMaxOid()
        {
            int x = 0;
            return x = Convert.ToInt32(Session.Evaluate<DetailPembelian>(DevExpress.Data.Filtering.CriteriaOperator.Parse("Max(Oid)"), null)) + 1;
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