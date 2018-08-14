using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Common;
using Library.Resources;
using Library.Resources.Location;
using Csla;

namespace Library.Domain
{
    /// <summary>
    /// Item Criteria
    /// </summary>
    [Serializable]
    public class WorldMap_ItemCriteria : ItemCriteria_Base<WorldMap_ItemCriteria>
    {
        #region Properties

        public static readonly PropertyInfo<int?> MapX_Property = RegisterProperty<int?>(c => c.MapX);
        public int? MapX
        {
            get { return ReadProperty(MapX_Property); }
            set { LoadProperty(MapX_Property, value); }
        }

        public static readonly PropertyInfo<int?> MapY_Property = RegisterProperty<int?>(c => c.MapY);
        public int? MapY
        {
            get { return ReadProperty(MapY_Property); }
            set { LoadProperty(MapY_Property, value); }
        }

        public K_WORLD_MAP ToDto()
        {
            K_WORLD_MAP dto = new K_WORLD_MAP();

            dto.mapX = MapX;
            dto.mapY = MapY;

            base.ToDto(dto);

            return dto;
        }

        #endregion
    }

    /// <summary>
    /// List Criteria
    /// </summary>
    [Serializable]
    public class WorldMap_ListCriteria : ListCriteria_Base<WorldMap_ListCriteria>
    {
        #region Properties

        public static readonly PropertyInfo<int?> RegionID_Property = RegisterProperty<int?>(c => c.RegionID);
        public int? RegionID
        {
            get { return ReadProperty(RegionID_Property); }
            set { LoadProperty(RegionID_Property, value); }
        }

        public static readonly PropertyInfo<int?> MapX_Property = RegisterProperty<int?>(c => c.MapX);
        public int? MapX
        {
            get { return ReadProperty(MapX_Property); }
            set { LoadProperty(MapX_Property, value); }
        }

        public static readonly PropertyInfo<int?> MapY_Property = RegisterProperty<int?>(c => c.MapY);
        public int? MapY
        {
            get { return ReadProperty(MapY_Property); }
            set { LoadProperty(MapY_Property, value); }
        }

        public F_WORLD_MAP ToDto()
        {
            F_WORLD_MAP dto = new F_WORLD_MAP();

            dto.regionID = RegionID;
            dto.mapX     = MapX;
            dto.mapY     = MapY;

            base.ToDto (dto);

            return dto;
        }

        #endregion
    }

    /// <summary>
    /// ReadOnly Item
    /// </summary>
    [Serializable]
    public class WorldMap_InfoItem : InfoItem_Base<WorldMap_InfoItem, WorldMap_ItemCriteria>
    {
        #region Properties

        public static readonly PropertyInfo<int> MapX_Property = RegisterProperty<int>(c => c.MapX);
        public int MapX
        {
            get { return ReadProperty(MapX_Property); }
            set { LoadProperty(MapX_Property, value); }
        }

        public static readonly PropertyInfo<int> MapY_Property = RegisterProperty<int>(c => c.MapY);
        public int MapY
        {
            get { return ReadProperty(MapY_Property); }
            set { LoadProperty(MapY_Property, value); }
        }

        public void FromDto(D_WORLD_MAP dto)
        {
            MapX = dto.mapX;
            MapY = dto.mapY;

            base.FromDto(dto);
        }

        #endregion

        #region DataPortal

        private void Child_Fetch(D_WORLD_MAP dto) { FromDto(dto); }

        #endregion
    }

    /// <summary>
    /// ReadOnly List
    /// </summary>
    [Serializable]
    public class WorldMap_InfoList : InfoList_Base<WorldMap_InfoList, WorldMap_ListCriteria, WorldMap_InfoItem, WorldMap_ItemCriteria>
    {
        #region DataPortal

        private void DataPortal_Fetch (WorldMap_ListCriteria aCriteria)
        {
            IsReadOnly = false;
            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;

            // add elements of list from persistent store
            using (var ctx = DalFactory.GetManager (DalFactory.LOCATION_SCHEMA_NM))
            {
                var dal = ctx.GetProvider<I_WORLD_MAP>();
                var list = dal.SelectList(aCriteria.ToDto());

                foreach (var item in list)
                    Add (DataPortal.FetchChild<WorldMap_InfoItem>(item));
            }

            RaiseListChangedEvents = rlce;
            IsReadOnly = true;
        }

        #endregion
    }

    [Serializable]
    public class WorldMap_EditItem : EditItem_Base<WorldMap_EditItem, WorldMap_ItemCriteria>
    {
        #region Properties

        public static readonly PropertyInfo<int> MapX_Property = RegisterProperty<int>(c => c.MapX);
        [Required]
        public int MapX
        {
            get { return GetProperty(MapX_Property); }
            set { SetProperty(MapX_Property, value); }
        }

        public static readonly PropertyInfo<int> MapY_Property = RegisterProperty<int>(c => c.MapY);
        [Required]
        public int MapY
        {
            get { return GetProperty(MapY_Property); }
            set { SetProperty(MapY_Property, value); }
        }

        public void FromDto(D_WORLD_MAP dto)
        {
            using (BypassPropertyChecks)
            {
                MapX = dto.mapX;
                MapY = dto.mapY;

                base.FromDto (dto);
            }
        }

        public D_WORLD_MAP ToDto()
        {
            D_WORLD_MAP dto = new D_WORLD_MAP();

            dto.mapX = MapX;
            dto.mapY = MapY;

            base.ToDto (dto);

            return dto;
        }

        #endregion

        #region DataPortal

        [RunLocal]
        protected override void DataPortal_Create()
        {
            base.DataPortal_Create();
        }

        private void DataPortal_Fetch(WorldMap_ItemCriteria aKey)
        {
            using (var dalManager = DalFactory.GetManager(DalFactory.LOCATION_SCHEMA_NM))
            {
                var dal = dalManager.GetProvider<I_WORLD_MAP>();
                var data = dal.SelectItem(aKey.ToDto());

                FromDto(data);
            }
        }

        private void Child_Fetch(D_WORLD_MAP dto) { FromDto(dto); }

        [Transactional(TransactionalTypes.TransactionScope)]
        protected override void DataPortal_Insert()
        {
            using (var dalManager = DalFactory.GetManager(DalFactory.LOCATION_SCHEMA_NM))
            {
                var dal = dalManager.GetProvider<I_WORLD_MAP>();
                var data = dal.InsertItem(ToDto());

                FromDto(data);
            }
        }

        [Transactional(TransactionalTypes.TransactionScope)]
        protected override void DataPortal_Update()
        {
            using (var dalManager = DalFactory.GetManager(DalFactory.LOCATION_SCHEMA_NM))
            {
                UpdateOnDts = DateTime.Now;
                UpdateByUid = AppInfo.UserID;

                var dal = dalManager.GetProvider<I_WORLD_MAP>();
                var data = dal.UpdateItem(ToDto());

                FromDto(data);
            }
        }

        [Transactional(TransactionalTypes.TransactionScope)]
        protected override void DataPortal_DeleteSelf()
        {
            using (var dalManager = DalFactory.GetManager(DalFactory.LOCATION_SCHEMA_NM))
            {
                var dal = dalManager.GetProvider<I_WORLD_MAP>();

                dal.DeleteItem(new K_WORLD_MAP { objectID = this.ObjectID });
            }
        }

        //protected override void DataPortal_DeleteSelf()
        //{
        //    using (BypassPropertyChecks)
        //        DataPortal_Delete(this.Id);
        //}

        //private void DataPortal_Delete(int id)
        //{
        //    using (var ctx = ProjectTracker.Dal.DalFactory.GetManager())
        //    {
        //        Resources.Clear();
        //        FieldManager.UpdateChildren(this);
        //        var dal = ctx.GetProvider<ProjectTracker.Dal.IProjectDal>();
        //        dal.Delete(id);
        //    }
        //}
        #endregion
    }

    /// <summary>
    /// Unit of Work Getter
    /// </summary>
    [Serializable]
    public class WorldMap_EditItem_Getter : EditItem_Getter_Base<WorldMap_EditItem, WorldMap_ItemCriteria>
    {
        #region DataPortal

        protected override void DataPortal_Fetch(WorldMap_ItemCriteria aCriteria)
        {
            if (aCriteria.HasKey)
                EditItem = WorldMap_EditItem.GetItem(aCriteria);
            else
                EditItem = WorldMap_EditItem.NewItem(aCriteria);
        }

        #endregion
    }

    /// <summary>
    /// Editable List
    /// </summary>
    [Serializable]
    public class WorldMap_EditList : EditList_Base<WorldMap_EditList, WorldMap_ListCriteria, WorldMap_EditItem, WorldMap_ItemCriteria>
    {
        #region DataPortal

        private void DataPortal_Fetch(WorldMap_ListCriteria aCriteria)
        {
            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;

            using (var ctx = DalFactory.GetManager(DalFactory.LOCATION_SCHEMA_NM))
            {
                var dal = ctx.GetProvider<I_WORLD_MAP>();
                var list = dal.SelectList(aCriteria.ToDto());

                foreach (var item in list)
                    Add(DataPortal.FetchChild<WorldMap_EditItem>(item));
            }

            RaiseListChangedEvents = rlce;
        }

        [Transactional(TransactionalTypes.TransactionScope)]
        protected override void DataPortal_Update()
        {
            using (var ctx = DalFactory.GetManager(DalFactory.LOCATION_SCHEMA_NM))
            {
                Child_Update();
            }
        }

        #endregion
    }
}
