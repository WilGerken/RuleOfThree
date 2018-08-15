using System;
using System.Collections.Generic;
using Library.Common;

namespace Library.Resources.Location
{
    /// <summary>
    /// public interface for WorldMap items
    /// </summary>
    public interface I_MAP_WORLD
    {
        List<D_MAP_WORLD> SelectList (F_MAP_WORLD aFilter);
        void              DeleteList (F_MAP_WORLD aFilter);

        D_MAP_WORLD SelectItem (K_MAP_WORLD aKey);
        D_MAP_WORLD InsertItem (D_MAP_WORLD aDto);
        D_MAP_WORLD UpdateItem (D_MAP_WORLD aDto);
        void        DeleteItem (K_MAP_WORLD aKey);
    }

    /// <summary>
    /// filter object for WorldMap lists
    /// </summary>
    public class F_MAP_WORLD : Data_F_Base
    {
        public int?   regionID   { get; set; }
        public int?   mapX       { get; set; }
        public int?   mapY       { get; set; }

        /// <summary>
        /// default constructor
        /// </summary>
        public F_MAP_WORLD () { }
    }

    /// <summary>
    /// key object for WorldMap items
    /// </summary>
    public class K_MAP_WORLD : Data_K_Base
    {
        public int? mapX { get; set; }
        public int? mapY { get; set; }
    }

    /// <summary>
    /// data object for WorldMap items
    /// </summary>
    public class D_MAP_WORLD : Data_O_Base
    {
        public int mapX { get; set; }
        public int mapY { get; set; }

        /// <summary>
        /// default constructo
        /// </summary>
        public D_MAP_WORLD () : base () { }
    }
}