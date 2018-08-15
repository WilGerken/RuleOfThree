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
    public class MAP_WORLD : DATA_ACCESS_BASE<D_MAP_WORLD, F_MAP_WORLD, K_MAP_WORLD>, I_MAP_WORLD
    {
        // resource list

        public static List<D_MAP_WORLD> _ResourceList = new List<D_MAP_WORLD>();

        static MAP_WORLD ()
        {
            for (int x = 0; x <= Ref.WORLD_DIM_X; x++)
            {
                for (int y = 0; y <= Ref.WORLD_DIM_Y; y++)
                {
                    int lID = 0;

                    _ResourceList.Add (new D_MAP_WORLD
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
        public List<D_MAP_WORLD> SelectList (F_MAP_WORLD aFilter)
        {
            IEnumerable<D_MAP_WORLD> lResult = _ResourceList;

            // apply filter attributes
            if (aFilter.regionID.HasValue)
            {
                lResult = lResult.Where (x => MAP_REGION._ResourceList.Select (y => y.worldID).Contains (x.objectID));
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
            return lResult.ToList<D_MAP_WORLD>();
        }

        /// <summary>
        /// remove all matching items from persistent store
        /// </summary>
        /// <param name="aFilter"></param>
        public void DeleteList (F_MAP_WORLD aFilter)
        {
            throw new NotImplementedException ("MAP_WORLD.DeleteList not implemented");
        }

        /// <summary>
        /// select an item from persistent store for given key
        /// </summary>
        /// <param name="aKey"></param>
        /// <returns></returns>
        public D_MAP_WORLD SelectItem (K_MAP_WORLD aKey)
        {
            D_MAP_WORLD lResult = null;

            // apply key attributes
            if (aKey.objectID.HasValue)
                lResult = _ResourceList.Where (x => x.objectID == aKey.objectID).FirstOrDefault();

            // throw exception if not found
            if (lResult == null)
                throw new DllNotFoundException (string.Format ("MAP_WORLD Item not found for key {0}", aKey.objectID));

            // return result
            return lResult;
        }

        /// <summary>
        /// insert an item into persistent store
        /// </summary>
        /// <param name="aDto"></param>
        public D_MAP_WORLD InsertItem (D_MAP_WORLD aDto)
        {
            int lID = 0;

            if (_ResourceList.Count > 0)
                lID = _ResourceList.Select (x => x.objectID).Max() + 1;

            // create new item
            D_MAP_WORLD lItem = new D_MAP_WORLD
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
        public D_MAP_WORLD UpdateItem (D_MAP_WORLD aDto)
        {
            // fetch indicated item
            D_MAP_WORLD lItem = _ResourceList.Where (x => x.objectID == aDto.objectID).FirstOrDefault();

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
        public void DeleteItem (K_MAP_WORLD aKey)
        {
            lock (_ResourceList)
            {

            }
        }
    }
}