﻿using System;
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
    public class MapSector_ItemCriteria : ItemCriteria_Base<MapSector_ItemCriteria>
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

        public K_MAP_SECTOR ToDto()
        {
            K_MAP_SECTOR dto = new K_MAP_SECTOR();

            dto.regionID = RegionID;
            dto.mapX     = MapX;
            dto.mapY     = MapY;

            base.ToDto(dto);

            return dto;
        }

        #endregion
    }

    /// <summary>
    /// List Criteria
    /// </summary>
    [Serializable]
    public class MapSector_ListCriteria : ListCriteria_Base<MapSector_ListCriteria>
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

        public static readonly PropertyInfo<int?> MapZ_Property = RegisterProperty<int?>(c => c.MapZ);
        public int? MapZ
        {
            get { return ReadProperty(MapZ_Property); }
            set { LoadProperty(MapZ_Property, value); }
        }

        public static readonly PropertyInfo<int?> MapT_Property = RegisterProperty<int?>(c => c.MapT);
        public int? MapT
        {
            get { return ReadProperty(MapT_Property); }
            set { LoadProperty(MapT_Property, value); }
        }

        public F_MAP_SECTOR ToDto()
        {
            F_MAP_SECTOR dto = new F_MAP_SECTOR();

            dto.regionID = RegionID;
            dto.mapX     = MapX;
            dto.mapY     = MapY;
            dto.mapZ     = MapZ;
            dto.mapT     = MapT;

            base.ToDto (dto);

            return dto;
        }

        #endregion
    }

    /// <summary>
    /// ReadOnly Item
    /// </summary>
    [Serializable]
    public class MapSector_InfoItem : InfoItem_Base<MapSector_InfoItem, MapSector_ItemCriteria>
    {
        #region Properties

        public static readonly PropertyInfo<int> RegionID_Property = RegisterProperty<int>(c => c.RegionID);
        public int RegionID
        {
            get { return ReadProperty(RegionID_Property); }
            set { LoadProperty(RegionID_Property, value); }
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

        public static readonly PropertyInfo<int> MapZ_Property = RegisterProperty<int>(c => c.MapZ);
        public int MapZ
        {
            get { return ReadProperty(MapZ_Property); }
            set { LoadProperty(MapZ_Property, value); }
        }

        public static readonly PropertyInfo<int> MapT_Property = RegisterProperty<int>(c => c.MapT);
        public int MapT
        {
            get { return ReadProperty(MapT_Property); }
            set { LoadProperty(MapT_Property, value); }
        }

        public static readonly PropertyInfo<Ref.eTerrainType> TerrainTypeCd_Property = RegisterProperty<Ref.eTerrainType>(c => c.TerrainTypeCd);
        public Ref.eTerrainType TerrainTypeCd
        {
            get { return ReadProperty(TerrainTypeCd_Property); }
            set { LoadProperty(TerrainTypeCd_Property, value); }
        }

        public void FromDto(D_MAP_SECTOR dto)
        {
            RegionID      = dto.regionID;
            MapX          = dto.mapX;
            MapY          = dto.mapY;
            MapZ          = dto.mapZ;
            MapT          = dto.mapT;
            TerrainTypeCd = dto.terrainTypeCd;

            base.FromDto(dto);
        }

        #endregion

        #region DataPortal

        private void Child_Fetch(D_MAP_SECTOR dto) { FromDto(dto); }

        #endregion
    }

    /// <summary>
    /// ReadOnly List
    /// </summary>
    [Serializable]
    public class MapSector_InfoList : InfoList_Base<MapSector_InfoList, MapSector_ListCriteria, MapSector_InfoItem, MapSector_ItemCriteria>
    {
        #region DataPortal

        private void DataPortal_Fetch (MapSector_ListCriteria aCriteria)
        {
            IsReadOnly = false;
            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;

            // add elements of list from persistent store
            using (var ctx = DalFactory.GetManager (DalFactory.LOCATION_SCHEMA_NM))
            {
                var dal = ctx.GetProvider<I_MAP_SECTOR>();
                var list = dal.SelectList(aCriteria.ToDto());

                foreach (var item in list)
                    Add (DataPortal.FetchChild<MapSector_InfoItem>(item));
            }

            RaiseListChangedEvents = rlce;
            IsReadOnly = true;
        }

        #endregion
    }

    [Serializable]
    public class MapSector_EditItem : EditItem_Base<MapSector_EditItem, MapSector_ItemCriteria>
    {
        #region Properties

        public static readonly PropertyInfo<int> RegionID_Property = RegisterProperty<int>(c => c.RegionID);
        [Required]
        public int RegionID
        {
            get { return GetProperty(RegionID_Property); }
            set { SetProperty(RegionID_Property, value); }
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

        public static readonly PropertyInfo<int> MapZ_Property = RegisterProperty<int>(c => c.MapZ);
        [Required]
        public int MapZ
        {
            get { return GetProperty(MapZ_Property); }
            set { SetProperty(MapZ_Property, value); }
        }

        public static readonly PropertyInfo<int> MapT_Property = RegisterProperty<int>(c => c.MapT);
        [Required]
        public int MapT
        {
            get { return GetProperty(MapT_Property); }
            set { SetProperty(MapT_Property, value); }
        }

        [Required]
        public static readonly PropertyInfo<Ref.eTerrainType> TerrainTypeCd_Property = RegisterProperty<Ref.eTerrainType>(c => c.TerrainTypeCd);
        public Ref.eTerrainType TerrainTypeCd
        {
            get { return GetProperty(TerrainTypeCd_Property); }
            set { SetProperty(TerrainTypeCd_Property, value); }
        }

        public void FromDto (D_MAP_SECTOR dto)
        {
            using (BypassPropertyChecks)
            {
                RegionID      = dto.regionID;
                MapX          = dto.mapX;
                MapY          = dto.mapY;
                MapZ          = dto.mapZ;
                MapT          = dto.mapT;
                TerrainTypeCd = dto.terrainTypeCd;

                base.FromDto (dto);
            }
        }

        public D_MAP_SECTOR ToDto()
        {
            D_MAP_SECTOR dto = new D_MAP_SECTOR();

            dto.regionID      = RegionID;
            dto.mapX          = MapX;
            dto.mapY          = MapY;
            dto.mapZ          = MapZ;
            dto.mapT          = MapT;
            dto.terrainTypeCd = TerrainTypeCd;

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

        private void DataPortal_Fetch(MapSector_ItemCriteria aKey)
        {
            using (var dalManager = DalFactory.GetManager(DalFactory.LOCATION_SCHEMA_NM))
            {
                var dal = dalManager.GetProvider<I_MAP_SECTOR>();
                var data = dal.SelectItem(aKey.ToDto());

                FromDto(data);
            }
        }

        private void Child_Fetch(D_MAP_SECTOR dto) { FromDto(dto); }

        [Transactional(TransactionalTypes.TransactionScope)]
        protected override void DataPortal_Insert()
        {
            using (var dalManager = DalFactory.GetManager (DalFactory.LOCATION_SCHEMA_NM))
            {
                var dal = dalManager.GetProvider<I_MAP_SECTOR>();
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

                var dal = dalManager.GetProvider<I_MAP_SECTOR>();
                var data = dal.UpdateItem(ToDto());

                FromDto(data);
            }
        }

        [Transactional(TransactionalTypes.TransactionScope)]
        protected override void DataPortal_DeleteSelf()
        {
            using (var dalManager = DalFactory.GetManager(DalFactory.LOCATION_SCHEMA_NM))
            {
                var dal = dalManager.GetProvider<I_MAP_SECTOR>();

                dal.DeleteItem(new K_MAP_SECTOR { objectID = this.ObjectID });
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
    public class MapSector_EditItem_Getter : EditItem_Getter_Base<MapSector_EditItem, MapSector_ItemCriteria>
    {
        #region DataPortal

        protected override void DataPortal_Fetch(MapSector_ItemCriteria aCriteria)
        {
            if (aCriteria.HasKey)
                EditItem = MapSector_EditItem.GetItem(aCriteria);
            else
                EditItem = MapSector_EditItem.NewItem(aCriteria);
        }

        #endregion
    }

    /// <summary>
    /// Editable List
    /// </summary>
    [Serializable]
    public class MapSector_EditList : EditList_Base<MapSector_EditList, MapSector_ListCriteria, MapSector_EditItem, MapSector_ItemCriteria>
    {
        #region DataPortal

        private void DataPortal_Fetch(MapSector_ListCriteria aCriteria)
        {
            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;

            using (var ctx = DalFactory.GetManager(DalFactory.LOCATION_SCHEMA_NM))
            {
                var dal = ctx.GetProvider<I_MAP_SECTOR>();
                var list = dal.SelectList(aCriteria.ToDto());

                foreach (var item in list)
                    Add(DataPortal.FetchChild<MapSector_EditItem>(item));
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
