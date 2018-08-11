using System;
using System.Collections.Generic;
using Library.Common;

namespace Library.Resources.Location
{
    /// <summary>
    /// public interface for WorldMap items
    /// </summary>
    public interface I_WORLD_MAP
    {
        List<D_WORLD_MAP> SelectList (F_WORLD_MAP aFilter);
        void              DeleteList (F_WORLD_MAP aFilter);

        D_WORLD_MAP SelectItem (K_WORLD_MAP aKey);
        D_WORLD_MAP UpdateItem (D_WORLD_MAP aDto);
        void        DeleteItem (K_WORLD_MAP aKey);
    }

    /// <summary>
    /// filter object for WorldMap lists
    /// </summary>
    public class F_WORLD_MAP : Data_F_Base
    {
        public int?   map_x_val       { get; set; }
        public int?   map_y_val       { get; set; }
        public int?   map_z_val       { get; set; }
        public int?   map_t_val       { get; set; }
        public string terrain_type_cd { get; set; }

        /// <summary>
        /// default constructor
        /// </summary>
        public F_WORLD_MAP () { }
    }

    /// <summary>
    /// key object for WorldMap items
    /// </summary>
    public class K_WORLD_MAP : Data_K_Base
    {

    }

    /// <summary>
    /// data object for WorldMap items
    /// </summary>
    public class D_WORLD_MAP : Data_O_Base
    {
        public int          map_x_val       { get; set; }
        public int          map_y_val       { get; set; }
        public int          map_z_val       { get; set; }
        public int          map_t_val       { get; set; }
        public Ref.eTerrain terrain_type_cd { get; set; }

        /// <summary>
        /// default constructo
        /// </summary>
        public D_WORLD_MAP () : base () { }
    }
}