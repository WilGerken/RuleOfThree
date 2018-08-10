using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApocForms.Common
{
    public abstract class DATA_ACCESS_BASE <T,F,K>
        where T : Data_O_Base
        where F : Data_F_Base
        where K : Data_K_Base
    {
        /// <summary>
        /// filter query by active flag - add selected item if given in criteria
        /// </summary>
        /// <param name="aQuery"></param>
        /// <param name="aFilter"></param>
        protected IQueryable<T> CheckActiveAndSelected (IQueryable<T> aQuery, F aFilter)
        {
            if (aFilter.active_yn.HasValue)
            {
                if (aFilter.selected_id.HasValue)
                    aQuery = aQuery.Where (x => x.active_yn == aFilter.active_yn.Value || x.object_id == aFilter.selected_id);
                else
                    aQuery = aQuery.Where (x => x.active_yn == aFilter.active_yn.Value);
            }

            return aQuery;
        }
    }
}
