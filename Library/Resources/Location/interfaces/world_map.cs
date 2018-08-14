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
        D_WORLD_MAP InsertItem (D_WORLD_MAP aDto);
        D_WORLD_MAP UpdateItem (D_WORLD_MAP aDto);
        void        DeleteItem (K_WORLD_MAP aKey);
    }

    /// <summary>
    /// filter object for WorldMap lists
    /// </summary>
    public class F_WORLD_MAP : Data_F_Base
    {
        public int?   regionID   { get; set; }
        public int?   mapX       { get; set; }
        public int?   mapY       { get; set; }

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
        public int? mapX { get; set; }
        public int? mapY { get; set; }
    }

    /// <summary>
    /// data object for WorldMap items
    /// </summary>
    public class D_WORLD_MAP : Data_O_Base
    {
        public int mapX { get; set; }
        public int mapY { get; set; }

        /// <summary>
        /// default constructo
        /// </summary>
        public D_WORLD_MAP () : base () { }
    }
}