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
    [NavigationItem("Master")]
    [DeferredDeletion(false)]
    public class MasterKategori : XPObject
    { 
        public MasterKategori(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            _KodeKategori = "KTG" + GetMaxOid().ToString("D4");
            CreatedOn = DateTime.Now;
            CreatedBy = GetCurrentUser();
        }

        #region Object

        [Persistent("KodeKategori")]
        private string _KodeKategori;
        [PersistentAlias("_KodeKategori")]
        [Size(7)]
        public string KodeKategori
        {
            get { return _KodeKategori; }
        }

        private string _NamaKategori;
        [Size(25)]
        public string NamaKategori
        {
            get
            {
                return _NamaKategori;
            }
            set
            {
                SetPropertyValue("NamaKategori", ref _NamaKategori, value);
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

        #endregion

        #region GetMaxOid()
        protected int GetMaxOid()
        {
            int x = 0;
            return x = Convert.ToInt32(Session.Evaluate<MasterKategori>(DevExpress.Data.Filtering.CriteriaOperator.Parse("Max(Oid)"), null)) + 1;
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