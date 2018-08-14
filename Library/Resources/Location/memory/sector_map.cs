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
    public class SECTOR_MAP : DATA_ACCESS_BASE<D_SECTOR_MAP, F_SECTOR_MAP, K_SECTOR_MAP>, I_SECTOR_MAP
    {
        // resource list

        public static List<D_SECTOR_MAP> _ResourceList = new List<D_SECTOR_MAP>();

        static SECTOR_MAP ()
        {
            for (int x = 0; x <= Ref.SECTOR_DIM_X; x++)
            {
                for (int y = 0; y <= Ref.SECTOR_DIM_Y ; y++)
                {
                    int id = 0;

                    _ResourceList.Add (new D_SECTOR_MAP {
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
        public List<D_SECTOR_MAP> SelectList (F_SECTOR_MAP aFilter)
        {
            IEnumerable<D_SECTOR_MAP> lResult = _ResourceList;

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
            return lResult.ToList<D_SECTOR_MAP>();
        }

        /// <summary>
        /// remove all matching items from persistent store
        /// </summary>
        /// <param name="aFilter"></param>
        public void DeleteList (F_SECTOR_MAP aFilter)
        {
            throw new NotImplementedException ("SECTOR_MAP.DeleteList not implemented");
        }

        /// <summary>
        /// select an item from persistent store for given key
        /// </summary>
        /// <param name="aKey"></param>
        /// <returns></returns>
        public D_SECTOR_MAP SelectItem (K_SECTOR_MAP aKey)
        {
            D_SECTOR_MAP lResult = null;

            // apply key attributes
            if (aKey.objectID.HasValue)
                lResult = _ResourceList.Where (x => x.objectID == aKey.objectID).FirstOrDefault();

            // throw exception if not found
            if (lResult == null)
                throw new DllNotFoundException (string.Format ("SECTOR_MAP Item not found for key {0}", aKey.objectID));

            // return result
            return lResult;
        }

        /// <summary>
        /// insert an item into persistent store
        /// </summary>
        /// <param name="aDto"></param>
        public D_SECTOR_MAP InsertItem (D_SECTOR_MAP aDto)
        {
            int lID = 0;

            if (_ResourceList.Count > 0)
                lID = _ResourceList.Select (x => x.objectID).Max() + 1;

            // create new item
            D_SECTOR_MAP lItem = new D_SECTOR_MAP
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
        public D_SECTOR_MAP UpdateItem (D_SECTOR_MAP aDto)
        {
            // fetch indicated item
            D_SECTOR_MAP lItem = _ResourceList.Where (x => x.objectID == aDto.objectID).FirstOrDefault();

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
        public void DeleteItem (K_SECTOR_MAP aKey)
        {
        }
    }
}