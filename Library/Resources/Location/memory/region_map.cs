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
    public class REGION_MAP : DATA_ACCESS_BASE<D_REGION_MAP, F_REGION_MAP, K_REGION_MAP>, I_REGION_MAP
    {
        // resource list

        public static List<D_REGION_MAP> _ResourceList = new List<D_REGION_MAP>();

        static REGION_MAP ()
        {
            // basic map
            for (int x = 0; x <= Ref.REGION_DIM_X; x++)
            {
                for (int y = 0; y <= Ref.REGION_DIM_Y; y++)
                {
                    int lID = 0;

                    _ResourceList.Add (new D_REGION_MAP {
                        objectID = lID++,
                        worldID  = 0,
                        mapX     = x,
                        mapY     = y
                    });
                }
            }

            // terrain changes
        }

        /// <summary>
        /// select a list of items from persistent store for given filter
        /// </summary>
        /// <param name="aFilter"></param>
        /// <returns></returns>
        public List<D_REGION_MAP> SelectList (F_REGION_MAP aFilter)
        {
            IEnumerable<D_REGION_MAP> lResult = _ResourceList;

            // apply filter attributes
            if (aFilter.sectorID.HasValue)
            {
                lResult = lResult.Where (x => SECTOR_MAP._ResourceList.Select (y => y.regionID).Contains (x.objectID));
            }

            if (aFilter.worldID.HasValue)
            {
                lResult = lResult.Where(x => x.worldID == aFilter.worldID.Value);
            }

            if (aFilter.mapX.HasValue)
            {
                lResult = lResult.Where (x => x.mapX == aFilter.mapX.Value);
            }

            if (aFilter.mapY.HasValue)
            {
                lResult = lResult.Where(x => x.mapY == aFilter.mapY.Value);
            }

            // check base criteria
            if (aFilter.objectID.HasValue)
            {
                lResult = lResult.Where(x => x.objectID == aFilter.objectID.Value);
            }

            // return result
            return lResult.ToList<D_REGION_MAP>();
        }

        /// <summary>
        /// remove all matching items from persistent store
        /// </summary>
        /// <param name="aFilter"></param>
        public void DeleteList (F_REGION_MAP aFilter)
        {
            throw new NotImplementedException ("REGION_MAP.DeleteList not implemented");
        }

        /// <summary>
        /// select an item from persistent store for given key
        /// </summary>
        /// <param name="aKey"></param>
        /// <returns></returns>
        public D_REGION_MAP SelectItem (K_REGION_MAP aKey)
        {
            D_REGION_MAP lResult = null;

            // apply key attributes
            if (aKey.objectID.HasValue)
                lResult = _ResourceList.Where(x => x.objectID == aKey.objectID).FirstOrDefault();

            // throw exception if not found
            if (lResult == null)
                throw new DllNotFoundException (string.Format ("REGION_MAP Item not found for key {0}", aKey.objectID));

            // return result
            return lResult;
        }

        /// <summary>
        /// insert an item into persistent store
        /// </summary>
        /// <param name="aDto"></param>
        public D_REGION_MAP InsertItem (D_REGION_MAP aDto)
        {
            int lID = 0;

            if (_ResourceList.Count > 0)
                lID = _ResourceList.Select (x => x.objectID).Max() + 1;

            // create new item
            D_REGION_MAP lItem = new D_REGION_MAP
            { 
                objectID = lID,
                worldID  = aDto.worldID, 
                mapX     = aDto.mapX,
                mapY     = aDto.mapY
            };

            // insert new item into ist
            lock (_ResourceList)
            {

            }

            return aDto;
        }

        /// <summary>
        /// update an item in persistent store
        /// </summary>
        /// <param name="aDto"></param>
        public D_REGION_MAP UpdateItem (D_REGION_MAP aDto)
        {
            // fetch indicated item
            D_REGION_MAP lItem = _ResourceList.Where (x => x.objectID == aDto.objectID).FirstOrDefault();

            // update item
            lock (lItem)
            {
                lItem.worldID = aDto.worldID;
                lItem.mapX    = aDto.mapY;
                lItem.mapY    = aDto.mapX;
            }

            return aDto;
        }

        /// <summary>
        /// remove an item from persistent store
        /// </summary>
        /// <param name="aKey"></param>
        public void DeleteItem (K_REGION_MAP aKey)
        {
            lock (_ResourceList)
            {

            }
        }
    }
}