using System;

namespace Library.Common
{
    public class Ref
    {
        public enum AppUser { Admin = 0, Staff }
        public enum AppRole { Any   = 0, Admin, Staff, Guild, Player, Guest }

        // rule and scale

        public enum eRule  { Red  =  0, Green,   Blue }
        public enum eScale { Evil = -1, Neutral, Good }

        public class Rule
        {
            public eRule Value { get; private set; }

            public Rule ( eRule aValue ) { Value = aValue; }

            public eScale Compare (eRule aOther)
            {
                return ( Value == aOther ? eScale.Neutral : ( Value > aOther ? eScale.Good : eScale.Evil ) );
            }
        }

        // map limits
        public const int WORLD_DIM_X = 1;
        public const int WORLD_DIM_Y = 1;

        public const int REGION_DIM_X = 5;
        public const int REGION_DIM_Y = 5;

        public const int SECTOR_DIM_X = 50;
        public const int SECTOR_DIM_Y = 50;
        public const int SECTOR_DIM_Z = 3;

        // select options
        public int eNone = -1;
        public int eAny  =  0;

        // terrain
        public enum eRegionType  { Flat  = 1, Hill, Mountain, Lake, Sea }
        public enum eTerrainType { River = 1, Lake, Shore, Sea, Coast, Canyon, Flat, Hill, Mountain }
    }
}
