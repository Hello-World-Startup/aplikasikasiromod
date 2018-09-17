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
    public class MasterSupplier : XPObject
    { 
        public MasterSupplier(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            _KodeSupplier = "SPL" + GetMaxOid().ToString("D4");
            CreatedOn = DateTime.Now;
            CreatedBy = GetCurrentUser();
        }

        #region Object

        [Persistent("KodeSupplier")]
        private string _KodeSupplier;
        [PersistentAlias("_KodeSupplier")]
        [Size(7)]
        public string KodeSupplier
        {
            get { return _KodeSupplier; }
        }

        private string _NamaSupplier;
        [Size(25)]
        public string NamaSupplier
        {
            get
            {
                return _NamaSupplier;
            }
            set
            {
                SetPropertyValue("NamaSupplier", ref _NamaSupplier, value);
            }
        }

        private string _Contact;
        [Size(12)]
        public string Contact
        {
            get
            {
                return _Contact;
            }
            set
            {
                SetPropertyValue("Contact", ref _Contact, value);
            }
        }

        private string _Email;
        [Size(50)]
        public string Email
        {
            get
            {
                return _Email;
            }
            set
            {
                SetPropertyValue("Email", ref _Email, value);
            }
        }
        
        private string _Alamat;
        [Size(SizeAttribute.Unlimited)]
        public string Alamat
        {
            get
            {
                return _Alamat;
            }
            set
            {
                SetPropertyValue("Alamat", ref _Alamat, value);
            }
        }
        
        private string _Kota;
        [Size(50)]
        public string Kota
        {
            get
            {
                return _Kota;
            }
            set
            {
                SetPropertyValue("Kota", ref _Kota, value);
            }
        }
        
        private string _KodePos;
        [Size(5)]
        public string KodePos
        {
            get
            {
                return _KodePos;
            }
            set
            {
                SetPropertyValue("KodePos", ref _KodePos, value);
            }
        }
        #endregion

        #region GetMaxOid()
        protected int GetMaxOid()
        {
            int x = 0;
            return x = Convert.ToInt32(Session.Evaluate<MasterSupplier>(DevExpress.Data.Filtering.CriteriaOperator.Parse("Max(Oid)"), null)) + 1;
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