using System;
using System.Collections.Generic;
using Library.Common;

namespace Library.Resources.Location
{
    /// <summary>
    /// public interface for WorldMap items
    /// </summary>
    public interface I_REGION_MAP
    {
        List<D_REGION_MAP> SelectList (F_REGION_MAP aFilter);
        void               DeleteList (F_REGION_MAP aFilter);

        D_REGION_MAP SelectItem (K_REGION_MAP aKey);
        D_REGION_MAP InsertItem (D_REGION_MAP aDto);
        D_REGION_MAP UpdateItem (D_REGION_MAP aDto);
        void         DeleteItem (K_REGION_MAP aKey);
    }

    /// <summary>
    /// filter object for WorldMap lists
    /// </summary>
    public class F_REGION_MAP : Data_F_Base
    {
        public int?   worldID      { get; set; }
        public int?   sectorID     { get; set; }
        public int?   mapX         { get; set; }
        public int?   mapY         { get; set; }
        public string regionTypeCd { get; set; }

        /// <summary>
        /// default constructor
        /// </summary>
        public F_REGION_MAP () { }
    }

    /// <summary>
    /// key object for WorldMap items
    /// </summary>
    public class K_REGION_MAP : Data_K_Base
    {
        public int? worldID { get; set; }
        public int? mapX    { get; set; }
        public int? mapY    { get; set; }
    }

    /// <summary>
    /// data object for WorldMap items
    /// </summary>
    public class D_REGION_MAP : Data_O_Base
    {
        public int             worldID       { get; set; }
        public int             mapX          { get; set; }
        public int             mapY          { get; set; }
        public Ref.eRegionType regionTypeCd  { get; set; }

        /// <summary>
        /// default constructo
        /// </summary>
        public D_REGION_MAP () : base () { }
    }
}