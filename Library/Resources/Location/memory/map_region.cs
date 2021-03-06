﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Library.Common;

namespace Library.Resources.Location.memory
{
    /// <summary>
    /// data access class
    /// </summary>
    public class MAP_REGION : DATA_ACCESS_BASE<D_MAP_REGION, F_MAP_REGION, K_MAP_REGION>, I_MAP_REGION
    {
        // resource list

        public static List<D_MAP_REGION> _ResourceList = new List<D_MAP_REGION>();

        static MAP_REGION ()
        {
            // basic map
            for (int x = 0; x <= Ref.REGION_DIM_X; x++)
            {
                for (int y = 0; y <= Ref.REGION_DIM_Y; y++)
                {
                    int lID = 0;

                    _ResourceList.Add (new D_MAP_REGION {
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
        public List<D_MAP_REGION> SelectList (F_MAP_REGION aFilter)
        {
            IEnumerable<D_MAP_REGION> lResult = _ResourceList;

            // apply filter attributes
            if (aFilter.sectorID.HasValue)
            {
                lResult = lResult.Where (x => MAP_SECTOR._ResourceList.Select (y => y.regionID).Contains (x.objectID));
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
            return lResult.ToList<D_MAP_REGION>();
        }

        /// <summary>
        /// remove all matching items from persistent store
        /// </summary>
        /// <param name="aFilter"></param>
        public void DeleteList (F_MAP_REGION aFilter)
        {
            throw new NotImplementedException ("MAP_REGION.DeleteList not implemented");
        }

        /// <summary>
        /// select an item from persistent store for given key
        /// </summary>
        /// <param name="aKey"></param>
        /// <returns></returns>
        public D_MAP_REGION SelectItem (K_MAP_REGION aKey)
        {
            D_MAP_REGION lResult = null;

            // apply key attributes
            if (aKey.objectID.HasValue)
                lResult = _ResourceList.Where(x => x.objectID == aKey.objectID).FirstOrDefault();

            // throw exception if not found
            if (lResult == null)
                throw new DllNotFoundException (string.Format ("MAP_REGION Item not found for key {0}", aKey.objectID));

            // return result
            return lResult;
        }

        /// <summary>
        /// insert an item into persistent store
        /// </summary>
        /// <param name="aDto"></param>
        public D_MAP_REGION InsertItem (D_MAP_REGION aDto)
        {
            int lID = 0;

            if (_ResourceList.Count > 0)
                lID = _ResourceList.Select (x => x.objectID).Max() + 1;

            // create new item
            D_MAP_REGION lItem = new D_MAP_REGION
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
        public D_MAP_REGION UpdateItem (D_MAP_REGION aDto)
        {
            // fetch indicated item
            D_MAP_REGION lItem = _ResourceList.Where (x => x.objectID == aDto.objectID).FirstOrDefault();

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
        public void DeleteItem (K_MAP_REGION aKey)
        {
            lock (_ResourceList)
            {

            }
        }
    }
}