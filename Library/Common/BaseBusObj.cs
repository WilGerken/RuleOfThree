using System;
using System.ComponentModel.DataAnnotations;
using Csla;

namespace ApocForms.Common
{
    /// <summary>
    /// item criteria base class
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Serializable]
    public abstract class ItemCriteria_Base<T> : CriteriaBase<T>
            where T : ItemCriteria_Base<T>
    {
        public static readonly PropertyInfo<int?> ObjectId_Property = RegisterProperty<int?>(c => c.ObjectId);
        public int? ObjectId
        {
            get { return ReadProperty(ObjectId_Property); }
            set { LoadProperty(ObjectId_Property, value); }
        }

        public bool HasKey {  get { return ObjectId.HasValue; } }

        protected void ToDto (Data_K_Base dto)
        {
            dto.object_id = ObjectId;
        }
    }

    /// <summary>
    /// list criteria base class
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Serializable]
    public abstract class ListCriteria_Base<T> : CriteriaBase<T> 
        where T : ListCriteria_Base<T>
    {
        /// <summary>
        /// select option value
        /// </summary>
        public static readonly PropertyInfo<int?> SelectOptionValue_Property = RegisterProperty<int?>(c => c.SelectOption_Value);
        public int? SelectOption_Value
        {
            get { return ReadProperty(SelectOptionValue_Property); }
            set { LoadProperty(SelectOptionValue_Property, value); }
        }

        /// <summary>
        /// select option text
        /// </summary>
        public static readonly PropertyInfo<string> SelectOptionText_Property = RegisterProperty<string>(c => c.SelectOption_Text);
        public string SelectOption_Text
        {
            get { return ReadProperty(SelectOptionText_Property); }
            set { LoadProperty(SelectOptionText_Property, value); }
        }

        /// <summary>
        /// persistent object id
        /// </summary>
        public static readonly PropertyInfo<int?> ObjectId_Property = RegisterProperty<int?>(c => c.ObjectId);
        public int? ObjectId
        {
            get { return ReadProperty(ObjectId_Property); }
            set { LoadProperty(ObjectId_Property, value); }
        }

        /// <summary>
        /// persistent object id
        /// </summary>
        public static readonly PropertyInfo<int?> SelectedId_Property = RegisterProperty<int?>(c => c.SelectedId);
        public int? SelectedId
        {
            get { return ReadProperty(SelectedId_Property); }
            set { LoadProperty(SelectedId_Property, value); }
        }

        /// <summary>
        /// persistent object active state
        /// </summary>
        public static readonly PropertyInfo<bool?> ActiveYn_Property = RegisterProperty<bool?>(c => c.ActiveYn);
        public bool? ActiveYn
        {
            get { return ReadProperty(ActiveYn_Property); }
            set { LoadProperty(ActiveYn_Property, value); }
        }

        protected void ToDto (Data_F_Base dto)
        {
            dto.object_id   = ObjectId;
            dto.selected_id = SelectedId;
            dto.active_yn   = ActiveYn;
        }
    }

    /// <summary>
    /// readonly item base class
    /// </summary>
    /// <typeparam name="I"></typeparam>
    /// <typeparam name="K"></typeparam>
    [Serializable]
    public abstract class InfoItem_Base<I,K> : ReadOnlyBase<I>
        where I : InfoItem_Base<I, K>
        where K : ItemCriteria_Base<K>
    {
        #region Properties

        /// <summary>
        /// persistent object id
        /// </summary>
        public static readonly PropertyInfo<int> ObjectId_Property = RegisterProperty<int>(c => c.ObjectId);
        [Required]
        public int ObjectId
        {
            get { return GetProperty(ObjectId_Property); }
            set { LoadProperty(ObjectId_Property, value); }
        }

        /// <summary>
        /// persistent object active state
        /// </summary>
        public static readonly PropertyInfo<bool> ActiveYn_Property = RegisterProperty<bool>(c => c.ActiveYn);
        [Required]
        public bool ActiveYn
        {
            get { return GetProperty(ActiveYn_Property); }
            set { LoadProperty(ActiveYn_Property, value); }
        }

        protected void FromDto (Data_O_Base dto)
        {
            ObjectId = dto.object_id;
            ActiveYn = dto.active_yn;
        }
        #endregion

        #region DataPortal

        public static I GetItem (K aKey)
        {
            return DataPortal.Fetch<I>(aKey);
        }

        protected override void DataPortal_OnDataPortalInvoke(DataPortalEventArgs eva)
        {
            base.DataPortal_OnDataPortalInvoke(eva);
        }

        protected override void DataPortal_OnDataPortalInvokeComplete(DataPortalEventArgs eva)
        {
            base.DataPortal_OnDataPortalInvokeComplete(eva);
        }

        protected override void Child_OnDataPortalException(DataPortalEventArgs eva, Exception ex)
        {
            base.DataPortal_OnDataPortalException(eva, ex);
        }

        #endregion
    }

    /// <summary>
    /// editable list base class
    /// </summary>
    /// <typeparam name="L">base list type</typeparam>
    /// <typeparam name="F">base list criteria type</typeparam>
    /// <typeparam name="I">base item type</typeparam>
    /// <typeparam name="K">base item criteria type</typeparam>
    [Serializable]
    public abstract class InfoList_Base<L, F, I, K> : ReadOnlyListBase<L, I>
        where L : ReadOnlyListBase<L, I>
        where F : ListCriteria_Base<F>, new()
        where I : InfoItem_Base<I, K>
        where K : ItemCriteria_Base<K>, new()
    {
        #region Client Side

        public static void GetList(EventHandler<DataPortalResult<L>> callback)
        {
            GetList(new F(), callback);
        }

        public static void GetList(F aCriteria, EventHandler<DataPortalResult<L>> callback)
        {
            DataPortal.BeginFetch<L>(aCriteria, callback);
        }

        public static L GetList()
        {
            return GetList (new F());
        }

        public static L GetList (F aCriteria)
        {
            return DataPortal.Fetch<L>(aCriteria);
        }

        #endregion
    }

    /// <summary>
    /// base edit item class
    /// </summary>
    /// <typeparam name="I">base item type</typeparam>
    /// <typeparam name="K">base item criteria type</typeparam>
    [Serializable]
    public abstract class EditItem_Base<I,K> : BusinessBase<I> 
        where I : EditItem_Base<I,K>
        where K : ItemCriteria_Base<K>
    {
        #region Properties

        public static readonly PropertyInfo<int> ObjectId_Property = RegisterProperty<int>(c => c.ObjectId);
        [Required]
        public int ObjectId
        {
            get { return GetProperty(ObjectId_Property); }
            set { SetProperty(ObjectId_Property, value); }
        }

        public static readonly PropertyInfo<bool> ActiveYn_Property = RegisterProperty<bool>(c => c.ActiveYn);
        [Required]
        public bool ActiveYn
        {
            get { return GetProperty(ActiveYn_Property); }
            set { SetProperty(ActiveYn_Property, value); }
        }

        public static readonly PropertyInfo<int> CreateByUid_Property = RegisterProperty<int>(c => c.CreateByUid);
        [Required]
        public int CreateByUid
        {
            get { return GetProperty(CreateByUid_Property); }
            set { SetProperty(CreateByUid_Property, value); }
        }

        public static readonly PropertyInfo<DateTime> CreateOnDts_Property = RegisterProperty<DateTime>(c => c.CreateOnDts);
        [Required]
        public DateTime CreateOnDts
        {
            get { return GetProperty(CreateOnDts_Property); }
            set { SetProperty(CreateOnDts_Property, value); }
        }

        public static readonly PropertyInfo<int> UpdateByUid_Property = RegisterProperty<int>(c => c.UpdateByUid);
        [Required]
        public int UpdateByUid
        {
            get { return GetProperty(UpdateByUid_Property); }
            set { SetProperty(UpdateByUid_Property, value); }
        }

        public static readonly PropertyInfo<DateTime> UpdateOnDts_Property = RegisterProperty<DateTime>(c => c.UpdateOnDts);
        [Required]
        public DateTime UpdateOnDts
        {
            get { return GetProperty(UpdateOnDts_Property); }
            set { SetProperty(UpdateOnDts_Property, value); }
        }

        public static readonly PropertyInfo<byte[]> VersionKey_Property = RegisterProperty<byte[]>(c => c.VersionKey);
        public byte[] VersionKey
        {
            get { return GetProperty(VersionKey_Property); }
            set { SetProperty(VersionKey_Property, value); }
        }

        #endregion

        #region Methods

        protected void FromDto (Data_O_Base dto)
        {
            ObjectId    = dto.object_id;
            ActiveYn    = dto.active_yn;
            CreateByUid = dto.create_by_uid;
            CreateOnDts = dto.create_on_dts;
            UpdateByUid = dto.update_by_uid;
            UpdateOnDts = dto.update_on_dts;
            VersionKey  = dto.version_key;
        }

        protected void ToDto (Data_O_Base dto)
        {
            dto.object_id     = ObjectId;
            dto.active_yn     = ActiveYn;
            dto.create_by_uid = CreateByUid;
            dto.create_on_dts = CreateOnDts;
            dto.update_by_uid = UpdateByUid;
            dto.update_on_dts = UpdateOnDts;
            dto.version_key   = VersionKey;
        }

        #endregion

        #region DataPortal

        public static void NewItem (K aCriteria, EventHandler<DataPortalResult<I>> callBack)
        {
            DataPortal.BeginCreate<I>(callBack);
        }

        public static void GetItem (K aCriteria, EventHandler<DataPortalResult<I>> callBack)
        {
            DataPortal.BeginFetch<I>(aCriteria, callBack);
        }

        public static I NewItem (K aCriteria)
        {
            return DataPortal.Create<I>(aCriteria);
        }

        public static I GetItem (K aCriteria)
        {
            return DataPortal.Fetch<I>(aCriteria);
        }

        protected override void DataPortal_Create()
        {
            using (BypassPropertyChecks)
            {
                ObjectId    = -1;
                CreateOnDts = UpdateOnDts = DateTime.Now;
                CreateByUid = UpdateByUid = AppInfo.UserID;
                ActiveYn    = true;
            }

            base.DataPortal_Create();
        }

        protected override void DataPortal_OnDataPortalInvoke (DataPortalEventArgs eva)
        {
            base.DataPortal_OnDataPortalInvoke(eva);
        }

        protected override void DataPortal_OnDataPortalInvokeComplete(DataPortalEventArgs eva)
        {
            base.DataPortal_OnDataPortalInvokeComplete(eva);
        }

        protected override void Child_OnDataPortalException(DataPortalEventArgs eva, Exception ex)
        {
            base.DataPortal_OnDataPortalException(eva, ex);
        }

        #endregion
    }

    /// <summary>
    /// unit of work getter base class
    /// </summary>
    /// <typeparam name="I">base item type</typeparam>
    /// <typeparam name="K">base item criteria type</typeparam>
    [Serializable]
    public abstract class EditItem_Getter_Base<I, K> : ReadOnlyBase<EditItem_Getter_Base<I, K>>
        where I : EditItem_Base<I, K>
        where K : ItemCriteria_Base<K>, new()
    {
        #region Properties

        public static PropertyInfo<I> EditItem_Property = RegisterProperty<I>(c => c.EditItem);
        public I EditItem
        {
            get { return GetProperty(EditItem_Property); }
            protected set { LoadProperty(EditItem_Property, value); }
        }

        #endregion

        #region DataPortal

        public static void NewItem (K aCriteria, EventHandler<DataPortalResult<EditItem_Getter_Base<I, K>>> callback)
        {
            DataPortal.BeginFetch<EditItem_Getter_Base<I, K>>(aCriteria, (o, e) =>
            {
                if (e.Error != null)
                    throw e.Error;

                callback(o, e);
            });
        }

        public static void GetItem (K aCriteria, EventHandler<DataPortalResult<EditItem_Getter_Base<I, K>>> callback)
        {
            DataPortal.BeginFetch<EditItem_Getter_Base<I, K>>(aCriteria, (o, e) =>
            {
                if (e.Error != null)
                    throw e.Error;

                callback(o, e);
            });
        }

        public void NewItem (K aCriteria)
        {
            DataPortal.Fetch<EditItem_Getter_Base<I, K>>(aCriteria);
        }

        public void GetItem (K aCriteria)
        {
            DataPortal.Fetch<EditItem_Getter_Base<I, K>> (aCriteria);
        }

        protected abstract void DataPortal_Fetch (K aCriteria);

        #endregion
    }

    /// <summary>
    /// editable list base class
    /// </summary>
    /// <typeparam name="L">base list type</typeparam>
    /// <typeparam name="F">base list criteria type</typeparam>
    /// <typeparam name="I">base item type</typeparam>
    /// <typeparam name="K">base item criteria type</typeparam>
    [Serializable]
    public abstract class EditList_Base<L,F,I,K> : BusinessListBase<L,I>
        where L : BusinessListBase<L,I>
        where F : ListCriteria_Base<F>, new()
        where I : EditItem_Base<I,K>
        where K : ItemCriteria_Base<K>, new()
    {
        #region Client Side

        public static void GetList (EventHandler<DataPortalResult<L>> callback)
        {
            GetList (new F(), callback);
        }

        public static void GetList (F aCriteria, EventHandler<DataPortalResult<L>> callback)
        {
            DataPortal.BeginFetch<L> (aCriteria, callback);
        }

        public static L GetList()
        {
            return GetList (new F());
        }

        public static L GetList (F aCriteria)
        {
            return DataPortal.Fetch<L> (aCriteria);
        }

        #endregion
    }
}
