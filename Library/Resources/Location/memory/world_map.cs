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
    public class WORLD_MAP : DATA_ACCESS_BASE<D_WORLD_MAP, F_WORLD_MAP, K_WORLD_MAP>, I_WORLD_MAP
    {
        // resource list

         static int _maxX = 9;
        private static int _maxY = 9;

        private static List<D_WORLD_MAP> _ResourceList = new List<D_WORLD_MAP>();

        static WORLD_MAP ()
        {
            for (int x = 0; x < _maxX; x++)
            {
                for (int y = 0; y<_maxY; y++)
                {
                    int id = 0;

                    _ResourceList.Add (new D_WORLD_MAP {
                        object_id = id++,
                        map_x_val = x,
                        map_y_val = y,
                        map_z_val = 0,
                        map_t_val = 0,
                        terrain_type_cd = Ref.eTerrain.Flat
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
            if (aFilter.map_x_val.HasValue)
            {
                lResult = lResult.Where (x => x.map_x_val == aFilter.map_x_val.Value);
            }

            if (aFilter.map_y_val.HasValue)
            {
                lResult = lResult.Where(x => x.map_y_val == aFilter.map_y_val.Value);
            }

            if (aFilter.map_z_val.HasValue)
            {
                lResult = lResult.Where(x => x.map_z_val == aFilter.map_z_val.Value);
            }

            if (aFilter.map_t_val.HasValue)
            {
                lResult = lResult.Where(x => x.map_t_val == aFilter.map_t_val.Value);
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
        /// <param name="aId"></param>
        /// <returns></returns>
        public D_WORLD_MAP SelectItem (K_WORLD_MAP aKey)
        {
            D_WORLD_MAP lResult = null;

            // apply key attributes
            if (aKey.object_id.HasValue)
                lResult = _ResourceList.Where(x => x.object_id == aKey.object_id).FirstOrDefault();

            // throw exception if not found
            if (lResult == null)
                throw new DllNotFoundException (string.Format ("WORLD_MAP Item not found for key {0}", aKey.object_id));

            // return result
            return lResult;
        }

        /// <summary>
        /// update an item in persistent store
        /// </summary>
        /// <param name="aDto"></param>
        public D_WORLD_MAP UpdateItem (D_WORLD_MAP aDto)
        {
            D_WORLD_MAP lItem = _ResourceList.Where (x => x.object_id == aDto.object_id).FirstOrDefault();

            lItem.map_x_val       = aDto.map_x_val;
            lItem.map_y_val       = aDto.map_y_val;
            lItem.map_z_val       = aDto.map_z_val;
            lItem.map_t_val       = aDto.map_t_val;
            lItem.terrain_type_cd = aDto.terrain_type_cd;

            return aDto;
        }

        /// <summary>
        /// remove an item from persistent store
        /// </summary>
        /// <param name="aId"></param>
        public void DeleteItem (K_WORLD_MAP aKey)
        {
        }
    }
}