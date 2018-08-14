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
    public class WORLD_MAP : DATA_ACCESS_BASE<D_WORLD_MAP, F_WORLD_MAP, K_WORLD_MAP>, I_WORLD_MAP
    {
        // resource list

        public static List<D_WORLD_MAP> _ResourceList = new List<D_WORLD_MAP>();

        static WORLD_MAP ()
        {
            for (int x = 0; x <= Ref.WORLD_DIM_X; x++)
            {
                for (int y = 0; y <= Ref.WORLD_DIM_Y; y++)
                {
                    int lID = 0;

                    _ResourceList.Add (new D_WORLD_MAP
                    {
                        objectID = lID++,
                        mapX     = x,
                        mapY     = y
                    });
                }
            }
        }

        /// <summary>
        /// select a list of items from persistent store for given filter
        /// </summary>
        /// <param name="aFilter"></param>
        /// <returns></returns>
        public List<D_WORLD_MAP> SelectList (F_WORLD_MAP aFilter)
        {
            IEnumerable<D_WORLD_MAP> lResult = _ResourceList;

            // apply filter attributes
            if (aFilter.regionID.HasValue)
            {
                lResult = lResult.Where (x => REGION_MAP._ResourceList.Select (y => y.worldID).Contains (x.objectID));
            }

            if (aFilter.mapX.HasValue)
            {
                lResult = lResult.Where (x => x.mapX == aFilter.mapX.Value);
            }

            if (aFilter.mapY.HasValue)
            {
                lResult = lResult.Where (x => x.mapY == aFilter.mapY.Value);
            }

            // check base criteria
            if (aFilter.objectID.HasValue)
            {
                lResult = lResult.Where(x => x.objectID == aFilter.objectID.Value);
            }

            // return result
            return lResult.ToList<D_WORLD_MAP>();
        }

        /// <summary>
        /// remove all matching items from persistent store
        /// </summary>
        /// <param name="aFilter"></param>
        public void DeleteList (F_WORLD_MAP aFilter)
        {
            throw new NotImplementedException ("WORLD_MAP.DeleteList not implemented");
        }

        /// <summary>
        /// select an item from persistent store for given key
        /// </summary>
        /// <param name="aKey"></param>
        /// <returns></returns>
        public D_WORLD_MAP SelectItem (K_WORLD_MAP aKey)
        {
            D_WORLD_MAP lResult = null;

            // apply key attributes
            if (aKey.objectID.HasValue)
                lResult = _ResourceList.Where (x => x.objectID == aKey.objectID).FirstOrDefault();

            // throw exception if not found
            if (lResult == null)
                throw new DllNotFoundException (string.Format ("WORLD_MAP Item not found for key {0}", aKey.objectID));

            // return result
            return lResult;
        }

        /// <summary>
        /// insert an item into persistent store
        /// </summary>
        /// <param name="aDto"></param>
        public D_WORLD_MAP InsertItem (D_WORLD_MAP aDto)
        {
            int lID = 0;

            if (_ResourceList.Count > 0)
                lID = _ResourceList.Select (x => x.objectID).Max() + 1;

            // create new item
            D_WORLD_MAP lItem = new D_WORLD_MAP
            { 
                objectID = lID,
                mapX     = aDto.mapX,
                mapY     = aDto.mapY,
            };

            // insert new item into list
            lock (_ResourceList)
            {
            }

            return aDto;
        }

        /// <summary>
        /// update an item in persistent store
        /// </summary>
        /// <param name="aDto"></param>
        public D_WORLD_MAP UpdateItem (D_WORLD_MAP aDto)
        {
            // fetch indicated item
            D_WORLD_MAP lItem = _ResourceList.Where (x => x.objectID == aDto.objectID).FirstOrDefault();

            // update item
            lock (lItem)
            {
                lItem.mapX = aDto.mapX;
                lItem.mapY = aDto.mapY;
            }

            return aDto;
        }

        /// <summary>
        /// remove an item from persistent store
        /// </summary>
        /// <param name="aKey"></param>
        public void DeleteItem (K_WORLD_MAP aKey)
        {
            lock (_ResourceList)
            {

            }
        }
    }
}