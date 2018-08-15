using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Library.Common;

namespace Library.Resources.Location.memory
{
    /// <summary>
    /// data access class
    /// </summary>
    public class MAP_SECTOR : DATA_ACCESS_BASE<D_MAP_SECTOR, F_MAP_SECTOR, K_MAP_SECTOR>, I_MAP_SECTOR
    {
        // resource list

        public static List<D_MAP_SECTOR> _ResourceList = new List<D_MAP_SECTOR>();

        static MAP_SECTOR ()
        {
            for (int x = 0; x <= Ref.SECTOR_DIM_X; x++)
            {
                for (int y = 0; y <= Ref.SECTOR_DIM_Y ; y++)
                {
                    int id = 0;

                    _ResourceList.Add (new D_MAP_SECTOR {
                        objectID = id++,
                        mapX = x,
                        mapY = y,
                        mapZ = 0,
                        mapT = 0,
                        terrainTypeCd = Ref.eTerrainType.Flat
                    });
                }
            }
        }

        /// <summary>
        /// select a list of items from persistent store for given filter
        /// </summary>
        /// <param name="aFilter"></param>
        /// <returns></returns>
        public List<D_MAP_SECTOR> SelectList (F_MAP_SECTOR aFilter)
        {
            IEnumerable<D_MAP_SECTOR> lResult = _ResourceList;

            // apply filter attributes
            if (aFilter.regionID.HasValue)
            {
                lResult = lResult.Where(x => x.regionID == aFilter.regionID.Value);
            }

            if (aFilter.mapX.HasValue)
            {
                lResult = lResult.Where (x => x.mapX == aFilter.mapX.Value);
            }

            if (aFilter.mapY.HasValue)
            {
                lResult = lResult.Where(x => x.mapY == aFilter.mapY.Value);
            }

            if (aFilter.mapZ.HasValue)
            {
                lResult = lResult.Where(x => x.mapZ == aFilter.mapZ.Value);
            }

            if (aFilter.mapT.HasValue)
            {
                lResult = lResult.Where(x => x.mapT == aFilter.mapT.Value);
            }

            // check base criteria
            if (aFilter.objectID.HasValue)
            {
                lResult = lResult.Where(x => x.objectID == aFilter.objectID.Value);
            }

            // return result
            return lResult.ToList<D_MAP_SECTOR>();
        }

        /// <summary>
        /// remove all matching items from persistent store
        /// </summary>
        /// <param name="aFilter"></param>
        public void DeleteList (F_MAP_SECTOR aFilter)
        {
            throw new NotImplementedException ("MAP_SECTOR.DeleteList not implemented");
        }

        /// <summary>
        /// select an item from persistent store for given key
        /// </summary>
        /// <param name="aKey"></param>
        /// <returns></returns>
        public D_MAP_SECTOR SelectItem (K_MAP_SECTOR aKey)
        {
            D_MAP_SECTOR lResult = null;

            // apply key attributes
            if (aKey.objectID.HasValue)
                lResult = _ResourceList.Where (x => x.objectID == aKey.objectID).FirstOrDefault();

            // throw exception if not found
            if (lResult == null)
                throw new DllNotFoundException (string.Format ("MAP_SECTOR Item not found for key {0}", aKey.objectID));

            // return result
            return lResult;
        }

        /// <summary>
        /// insert an item into persistent store
        /// </summary>
        /// <param name="aDto"></param>
        public D_MAP_SECTOR InsertItem (D_MAP_SECTOR aDto)
        {
            int lID = 0;

            if (_ResourceList.Count > 0)
                lID = _ResourceList.Select (x => x.objectID).Max() + 1;

            // create new item
            D_MAP_SECTOR lItem = new D_MAP_SECTOR
            {
                objectID      = lID,
                regionID      = aDto.regionID,
                mapX          = aDto.mapX,
                mapY          = aDto.mapY,
                mapZ          = aDto.mapZ,
                mapT          = aDto.mapT,
                terrainTypeCd = aDto.terrainTypeCd
            };

            // insert new item
            lock (_ResourceList)
            {
                _ResourceList.Add (lItem);

            }

            return aDto;
        }

        /// <summary>
        /// update an item in persistent store
        /// </summary>
        /// <param name="aDto"></param>
        public D_MAP_SECTOR UpdateItem (D_MAP_SECTOR aDto)
        {
            // fetch indicated item
            D_MAP_SECTOR lItem = _ResourceList.Where (x => x.objectID == aDto.objectID).FirstOrDefault();

            // update item
            lock (lItem)
            {
                lItem.regionID      = aDto.regionID;
                lItem.mapX          = aDto.mapX;
                lItem.mapY          = aDto.mapY;
                lItem.mapZ          = aDto.mapZ;
                lItem.mapT          = aDto.mapT;
                lItem.terrainTypeCd = aDto.terrainTypeCd;
            }

            return aDto;
        }

        /// <summary>
        /// remove an item from persistent store
        /// </summary>
        /// <param name="aKey"></param>
        public void DeleteItem (K_MAP_SECTOR aKey)
        {
        }
    }
}