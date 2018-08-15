using System;
using System.Collections.Generic;
using Library.Common;

namespace Library.Resources.Location
{
    /// <summary>
    /// public interface for WorldMap items
    /// </summary>
    public interface I_MAP_REGION
    {
        List<D_MAP_REGION> SelectList (F_MAP_REGION aFilter);
        void               DeleteList (F_MAP_REGION aFilter);

        D_MAP_REGION SelectItem (K_MAP_REGION aKey);
        D_MAP_REGION InsertItem (D_MAP_REGION aDto);
        D_MAP_REGION UpdateItem (D_MAP_REGION aDto);
        void         DeleteItem (K_MAP_REGION aKey);
    }

    /// <summary>
    /// filter object for WorldMap lists
    /// </summary>
    public class F_MAP_REGION : Data_F_Base
    {
        public int?   worldID      { get; set; }
        public int?   sectorID     { get; set; }
        public int?   mapX         { get; set; }
        public int?   mapY         { get; set; }
        public string regionTypeCd { get; set; }

        /// <summary>
        /// default constructor
        /// </summary>
        public F_MAP_REGION () { }
    }

    /// <summary>
    /// key object for WorldMap items
    /// </summary>
    public class K_MAP_REGION : Data_K_Base
    {
        public int? worldID { get; set; }
        public int? mapX    { get; set; }
        public int? mapY    { get; set; }
    }

    /// <summary>
    /// data object for WorldMap items
    /// </summary>
    public class D_MAP_REGION : Data_O_Base
    {
        public int             worldID       { get; set; }
        public int             mapX          { get; set; }
        public int             mapY          { get; set; }
        public Ref.eRegionType regionTypeCd  { get; set; }

        /// <summary>
        /// default constructo
        /// </summary>
        public D_MAP_REGION () : base () { }
    }
}