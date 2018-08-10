using System;

namespace ApocForms.Common
{
    /// <summary>
    /// base class for filter objects
    /// </summary>
    public abstract class Data_F_Base
    {
        public int?  object_id { get; set; }
        public int?  selected_id { get; set; }
        public bool? active_yn { get; set; }

        public int?  user_id   { get; set; }
    }

    /// <summary>
    /// base class for keys
    /// </summary>
    public abstract class Data_K_Base
    {
        public int? object_id { get; set; }
    }

    /// <summary>
    /// base class for data objects
    /// </summary>
    public abstract class Data_O_Base
    {
        public int      object_id     { get; set; }
        public bool     active_yn     { get; set; }
        public int      create_by_uid { get; set; }
        public DateTime create_on_dts { get; set; }
        public int      update_by_uid { get; set; }
        public DateTime update_on_dts { get; set; }
        public byte[]   version_key   { get; set; }

        protected Data_O_Base ()
        {
            object_id     = -1;
            active_yn     = true;
            create_by_uid = update_by_uid = AppInfo.UserID;
            create_on_dts = update_on_dts = DateTime.Now;
        }


    }
}
