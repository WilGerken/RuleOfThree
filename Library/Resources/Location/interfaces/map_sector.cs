using System;
using System.Collections.Generic;
using Library.Common;

namespace Library.Resources.Location
{
    /// <summary>
    /// public interface for WorldMap items
    /// </summary>
    public interface I_MAP_SECTOR
    {
        List<D_MAP_SECTOR> SelectList (F_MAP_SECTOR aFilter);
        void               DeleteList (F_MAP_SECTOR aFilter);

        D_MAP_SECTOR SelectItem (K_MAP_SECTOR aKey);
        D_MAP_SECTOR InsertItem (D_MAP_SECTOR aDto);
        D_MAP_SECTOR UpdateItem (D_MAP_SECTOR aDto);
        void         DeleteItem (K_MAP_SECTOR aKey);
    }

    /// <summary>
    /// filter object for WorldMap lists
    /// </summary>
    public class F_MAP_SECTOR : Data_F_Base
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
        public F_MAP_SECTOR () { }
    }

    /// <summary>
    /// key object for WorldMap items
    /// </summary>
    public class K_MAP_SECTOR : Data_K_Base
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
    public class D_MAP_SECTOR : Data_O_Base
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
        public D_MAP_SECTOR () : base () { }
    }
}