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
        public int WORLD_MAX_X = 8;
        public int WORLD_MAX_Y = 8;

        public int REGION_MAX_X = 24;
        public int REGION_MAX_Y = 24;

        public int SECTOR_MAX_X = 49;
        public int SECTOR_MAX_Y = 49;

        // select options
        public int eNone = -1;
        public int eAny  =  0;

        // terrain
        public enum eTerrain { River, Lake, Shore, Sea, Coast, Canyon, Flat, Hill, Mountain }
    }
}
