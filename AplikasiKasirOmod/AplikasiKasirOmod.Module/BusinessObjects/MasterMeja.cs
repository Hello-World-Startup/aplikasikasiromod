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
    public class MasterMeja : XPObject
    { 
        public MasterMeja(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            _KodeMeja = "KMJ" + GetMaxOid().ToString("D4");
            CreatedOn = DateTime.Now;
            CreatedBy = GetCurrentUser();
        }

        #region Object

        [Persistent("KodeMeja")]
        private string _KodeMeja;
        [PersistentAlias("_KodeMeja")]
        public string KodeMeja
        {
            get { return _KodeMeja; }
        }
                
        private int _NomorMeja;
        public int NomorMeja
        {
            get
            {
                return _NomorMeja;
            }
            set
            {
                SetPropertyValue("NomorMeja", ref _NomorMeja, value);
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
            return x = Convert.ToInt32(Session.Evaluate<MasterMeja>(DevExpress.Data.Filtering.CriteriaOperator.Parse("Max(Oid)"), null)) + 1;
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