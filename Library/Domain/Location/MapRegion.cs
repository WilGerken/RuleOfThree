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
    public class MapRegion_ItemCriteria : ItemCriteria_Base<MapRegion_ItemCriteria>
    {
        #region Properties

        public static readonly PropertyInfo<int?> WorldID_Property = RegisterProperty<int?>(c => c.WorldID);
        public int? WorldID
        {
            get { return ReadProperty(WorldID_Property); }
            set { LoadProperty(WorldID_Property, value); }
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

        public K_MAP_REGION ToDto()
        {
            K_MAP_REGION dto = new K_MAP_REGION();

            dto.worldID = WorldID;
            dto.mapX    = MapX;
            dto.mapY    = MapY;

            base.ToDto(dto);

            return dto;
        }

        #endregion
    }

    /// <summary>
    /// List Criteria
    /// </summary>
    [Serializable]
    public class MapRegion_ListCriteria : ListCriteria_Base<MapRegion_ListCriteria>
    {
        #region Properties

        public static readonly PropertyInfo<int?> WorldID_Property = RegisterProperty<int?>(c => c.WorldID);
        public int? WorldID
        {
            get { return ReadProperty(WorldID_Property); }
            set { LoadProperty(WorldID_Property, value); }
        }

        public static readonly PropertyInfo<int?> SectorID_Property = RegisterProperty<int?>(c => c.SectorID);
        public int? SectorID
        {
            get { return ReadProperty(SectorID_Property); }
            set { LoadProperty(SectorID_Property, value); }
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

        public F_MAP_REGION ToDto()
        {
            F_MAP_REGION dto = new F_MAP_REGION();

            dto.worldID  = WorldID;
            dto.sectorID = SectorID;
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
    public class MapRegion_InfoItem : InfoItem_Base<MapRegion_InfoItem, MapRegion_ItemCriteria>
    {
        #region Properties

        public static readonly PropertyInfo<int> WorldID_Property = RegisterProperty<int>(c => c.WorldID);
        public int WorldID
        {
            get { return ReadProperty(WorldID_Property); }
            set { LoadProperty(WorldID_Property, value); }
        }

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

        public static readonly PropertyInfo<Ref.eRegionType> RegionTypeCd_Property = RegisterProperty<Ref.eRegionType>(c => c.RegionTypeCd);
        public Ref.eRegionType RegionTypeCd
        {
            get { return ReadProperty(RegionTypeCd_Property); }
            set { LoadProperty(RegionTypeCd_Property, value); }
        }

        public void FromDto(D_MAP_REGION dto)
        {
            WorldID      = dto.worldID;
            MapX         = dto.mapX;
            MapY         = dto.mapY;
            RegionTypeCd = dto.regionTypeCd;

            base.FromDto(dto);
        }

        #endregion

        #region DataPortal

        private void Child_Fetch(D_MAP_REGION dto) { FromDto(dto); }

        #endregion
    }

    /// <summary>
    /// ReadOnly List
    /// </summary>
    [Serializable]
    public class MapRegion_InfoList : InfoList_Base<MapRegion_InfoList, MapRegion_ListCriteria, MapRegion_InfoItem, MapRegion_ItemCriteria>
    {
        #region DataPortal

        private void DataPortal_Fetch (MapRegion_ListCriteria aCriteria)
        {
            IsReadOnly = false;
            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;

            // add elements of list from persistent store
            using (var ctx = DalFactory.GetManager (DalFactory.LOCATION_SCHEMA_NM))
            {
                var dal = ctx.GetProvider<I_MAP_REGION>();
                var list = dal.SelectList(aCriteria.ToDto());

                foreach (var item in list)
                    Add (DataPortal.FetchChild<MapRegion_InfoItem>(item));
            }

            RaiseListChangedEvents = rlce;
            IsReadOnly = true;
        }

        #endregion
    }

    [Serializable]
    public class MapRegion_EditItem : EditItem_Base<MapRegion_EditItem, MapRegion_ItemCriteria>
    {
        #region Properties

        public static readonly PropertyInfo<int> WorldID_Property = RegisterProperty<int>(c => c.WorldID);
        [Required]
        public int WorldID
        {
            get { return GetProperty(WorldID_Property); }
            set { SetProperty(WorldID_Property, value); }
        }

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

        [Required]
        public static readonly PropertyInfo<Ref.eRegionType> RegionTypeCd_Property = RegisterProperty<Ref.eRegionType>(c => c.RegionTypeCd);
        public Ref.eRegionType RegionTypeCd
        {
            get { return GetProperty(RegionTypeCd_Property); }
            set { SetProperty(RegionTypeCd_Property, value); }
        }

        public void FromDto (D_MAP_REGION dto)
        {
            using (BypassPropertyChecks)
            {
                WorldID      = dto.worldID;
                MapX         = dto.mapX;
                MapY         = dto.mapY;
                RegionTypeCd = dto.regionTypeCd;

                base.FromDto (dto);
            }
        }

        public D_MAP_REGION ToDto()
        {
            D_MAP_REGION dto = new D_MAP_REGION();

            dto.worldID      = WorldID;
            dto.mapX         = MapX;
            dto.mapY         = MapY;
            dto.regionTypeCd = RegionTypeCd;

            base.ToDto (dto);

            return dto;
        }

        public static readonly PropertyInfo<MapSector_EditList> SectorList_Property =
            RegisterProperty<MapSector_EditList>(p => p.SectorList, RelationshipTypes.Child | RelationshipTypes.LazyLoad);
        public MapSector_EditList SectorList
        {
            get
            {
                return LazyGetProperty(SectorList_Property,
                    () => DataPortal.Fetch<MapSector_EditList>(new MapSector_ListCriteria { RegionID = ReadProperty (ObjectID_Property) }));
            }
            private set { LoadProperty(SectorList_Property, value); }
        }

        #endregion

        #region DataPortal

        [RunLocal]
        protected override void DataPortal_Create()
        {
            base.DataPortal_Create();
        }

        private void DataPortal_Fetch(MapRegion_ItemCriteria aKey)
        {
            using (var dalManager = DalFactory.GetManager(DalFactory.LOCATION_SCHEMA_NM))
            {
                var dal = dalManager.GetProvider<I_MAP_REGION>();
                var data = dal.SelectItem(aKey.ToDto());

                FromDto(data);
            }
        }

        private void Child_Fetch(D_MAP_REGION dto) { FromDto(dto); }

        [Transactional(TransactionalTypes.TransactionScope)]
        protected override void DataPortal_Insert()
        {
            using (var dalManager = DalFactory.GetManager (DalFactory.LOCATION_SCHEMA_NM))
            {
                var dal = dalManager.GetProvider<I_MAP_REGION>();
                var data = dal.InsertItem (ToDto());

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

                var dal = dalManager.GetProvider<I_MAP_REGION>();
                var data = dal.UpdateItem(ToDto());

                FromDto(data);
            }
        }

        [Transactional(TransactionalTypes.TransactionScope)]
        protected override void DataPortal_DeleteSelf()
        {
            using (var dalManager = DalFactory.GetManager(DalFactory.LOCATION_SCHEMA_NM))
            {
                var dal = dalManager.GetProvider<I_MAP_REGION>();

                dal.DeleteItem(new K_MAP_REGION { objectID = this.ObjectID });
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
    public class MapRegion_EditItem_Getter : EditItem_Getter_Base<MapRegion_EditItem, MapRegion_ItemCriteria>
    {
        #region DataPortal

        protected override void DataPortal_Fetch(MapRegion_ItemCriteria aCriteria)
        {
            if (aCriteria.HasKey)
                EditItem = MapRegion_EditItem.GetItem(aCriteria);
            else
                EditItem = MapRegion_EditItem.NewItem(aCriteria);
        }

        #endregion
    }

    /// <summary>
    /// Editable List
    /// </summary>
    [Serializable]
    public class MapRegion_EditList : EditList_Base<MapRegion_EditList, MapRegion_ListCriteria, MapRegion_EditItem, MapRegion_ItemCriteria>
    {
        #region DataPortal

        private void DataPortal_Fetch(MapRegion_ListCriteria aCriteria)
        {
            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;

            using (var ctx = DalFactory.GetManager(DalFactory.LOCATION_SCHEMA_NM))
            {
                var dal = ctx.GetProvider<I_MAP_REGION>();
                var list = dal.SelectList(aCriteria.ToDto());

                foreach (var item in list)
                    Add(DataPortal.FetchChild<MapRegion_EditItem>(item));
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
