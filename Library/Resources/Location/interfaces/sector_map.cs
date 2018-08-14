using System;
using System.Collections.Generic;
using Library.Common;

namespace Library.Resources.Location
{
    /// <summary>
    /// public interface for WorldMap items
    /// </summary>
    public interface I_SECTOR_MAP
    {
        List<D_SECTOR_MAP> SelectList (F_SECTOR_MAP aFilter);
        void               DeleteList (F_SECTOR_MAP aFilter);

        D_SECTOR_MAP SelectItem (K_SECTOR_MAP aKey);
        D_SECTOR_MAP InsertItem (D_SECTOR_MAP aDto);
        D_SECTOR_MAP UpdateItem (D_SECTOR_MAP aDto);
        void         DeleteItem (K_SECTOR_MAP aKey);
    }

    /// <summary>
    /// filter object for WorldMap lists
    /// </summary>
    public class F_SECTOR_MAP : Data_F_Base
    {
        public int?   regionID      { get; set; }
        public int?   mapX          { get; set; }
        public int?   mapY          { get; set; }
        public int?   mapZ          { get; set; }
        public int?   mapT          { get; set; }
        public string terrainTypeCd { get; set; }

        /// <summary>
        /// default constructor
        /// </summary>
        public F_SECTOR_MAP () { }
    }

    /// <summary>
    /// key object for WorldMap items
    /// </summary>
    public class K_SECTOR_MAP : Data_K_Base
    {
        public int? regionID { get; set; }
        public int? mapX     { get; set; }
        public int? mapY     { get; set; }
        public int? mapZ     { get; set; }
        public int? mapT     { get; set; }
    }

    /// <summary>
    /// data object for WorldMap items
    /// </summary>
    public class D_SECTOR_MAP : Data_O_Base
    {
        public int              regionID      { get; set; }
        public int              mapX          { get; set; }
        public int              mapY          { get; set; }
        public int              mapZ          { get; set; }
        public int              mapT          { get; set; }
        public Ref.eTerrainType terrainTypeCd { get; set; }

        /// <summary>
        /// default constructo
        /// </summary>
        public D_SECTOR_MAP () : base () { }
    }
}