using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Library.Common;
using Library.Resources.Location;

namespace Library.Resources.Location.persist_db
{
    /// <summary>
    /// data access class
    /// </summary>
    public class WORLD_MAP : DATA_ACCESS_BASE <D_WORLD_MAP, F_WORLD_MAP, K_WORLD_MAP>, I_WORLD_MAP
    {
        /// <summary>
        /// select a list of items from persistent store for given filter
        /// </summary>
        /// <param name="aFilter"></param>
        /// <returns></returns>
        public List<D_WORLD_MAP> SelectList (F_WORLD_MAP aFilter)
        {
            List<D_WORLD_MAP> lResult = new List<D_WORLD_MAP>();
#if (NOTYET)
            using (var ctx = DbContextManager<RepositoryModel.ApocFormsEntities>.GetManager())
            {
                var lQuery = (from item in ctx.DbContext.WORLD_MAP
                              select new D_WORLD_MAP
                              {
                                  object_id    = item.id,
                                  event_dts    = item.event_dts,
                                  logger_nm    = item.logger_nm,
                                  thread_nm    = item.thread_nm,
                                  log_level_cd = item.log_level_cd,
                                  apoc_user_nm = item.apoc_user_nm,
                                  apoc_user_id = item.apoc_user_id,
                                  apoc_form_nm = item.apoc_form_nm,
                                  apoc_form_id = item.apoc_form_id,
                                  location_txt = item.location_txt,
                                  browser_nm   = item.browser_nm,
                                  request_url  = item.request_url,
                                  referrer_url = item.referrer_url,
                                  message_txt  = item.message_txt,
                                  stack_trace  = item.stack_trace,

                                  active_yn     = item.active_yn,
                                  create_by_uid = item.create_by_uid,
                                  create_on_dts = item.create_on_dts,
                                  update_by_uid = item.update_by_uid,
                                  update_on_dts = item.update_on_dts,
                                  version_key   = item.version_key
                              });

                if (aFilter.object_id.HasValue)
                    lQuery = lQuery.Where (x => x.object_id == aFilter.object_id.Value);

                if (aFilter.from_dts.HasValue)
                    lQuery = lQuery.Where (x => x.event_dts >= aFilter.from_dts.Value);

                if (aFilter.thru_dts.HasValue)
                    lQuery = lQuery.Where (x => x.event_dts <= aFilter.thru_dts.Value);

                if (! string.IsNullOrEmpty (aFilter.logger_nm))
                    lQuery = lQuery.Where (x => x.logger_nm == aFilter.logger_nm);

                if (! string.IsNullOrEmpty(aFilter.log_level_cd))
                    lQuery = lQuery.Where(x => x.logger_nm == aFilter.log_level_cd);

                lQuery = CheckActiveAndSelected (lQuery, aFilter);

                lResult = lQuery.ToList();
            }
#endif
            return lResult;
        }

        /// <summary>
        /// remove all matching items from persistent store
        /// </summary>
        /// <param name="aFilter"></param>
        public void DeleteList (F_WORLD_MAP aFilter)
        {

        }

        /// <summary>
        /// select an item from persistent store for given key
        /// </summary>
        /// <param name="aId"></param>
        /// <returns></returns>
        public D_WORLD_MAP SelectItem (K_WORLD_MAP aKey)
        {
#if (NOTYET)
            using (var ctx = DbContextManager<RepositoryModel.ApocFormsEntities>.GetManager())
            {
                var lQuery = (from item in ctx.DbContext.WORLD_MAP
                              select new D_WORLD_MAP
                              {
                                  object_id = item.id,
                                  event_dts = item.event_dts,
                                  logger_nm = item.logger_nm,
                                  thread_nm = item.thread_nm,
                                  log_level_cd = item.log_level_cd,
                                  apoc_user_nm = item.apoc_user_nm,
                                  apoc_user_id = item.apoc_user_id,
                                  apoc_form_nm = item.apoc_form_nm,
                                  apoc_form_id = item.apoc_form_id,
                                  location_txt = item.location_txt,
                                  browser_nm   = item.browser_nm,
                                  request_url  = item.request_url,
                                  referrer_url = item.referrer_url,
                                  message_txt  = item.message_txt,
                                  stack_trace  = item.stack_trace,

                                  active_yn     = item.active_yn,
                                  create_by_uid = item.create_by_uid,
                                  create_on_dts = item.create_on_dts,
                                  update_by_uid = item.update_by_uid,
                                  update_on_dts = item.update_on_dts,
                                  version_key   = item.version_key
                              });

                if (aKey.object_id.HasValue)
                    lQuery = lQuery.Where(x => x.object_id == aKey.object_id.Value);

                return lQuery.FirstOrDefault();
            }
#else
            return new D_WORLD_MAP();
#endif
        }

        /// <summary>
        /// insert an item into persistent store
        /// </summary>
        /// <param name="aDto"></param>
        public D_WORLD_MAP InsertItem (D_WORLD_MAP aDto)
        {
#if (NOTYET)
            using (var ctx = DbContextManager<RepositoryModel.ApocFormsEntities>.GetManager())
            {
                // create new persistent object
                var data = new WORLD_MAP ();

                data.event_dts    = aDto.event_dts;
                data.logger_nm    = aDto.logger_nm;
                data.thread_nm    = aDto.thread_nm;
                data.log_level_cd = aDto.log_level_cd;
                data.apoc_user_nm = aDto.apoc_user_nm;
                data.apoc_user_id = aDto.apoc_user_id;
                data.apoc_form_nm = aDto.apoc_form_nm;
                data.apoc_form_id = aDto.apoc_form_id;
                data.location_txt = aDto.location_txt;
                data.browser_nm   = aDto.browser_nm;
                data.request_url  = aDto.request_url;
                data.referrer_url = aDto.referrer_url;
                data.message_txt  = aDto.message_txt;
                data.stack_trace  = aDto.stack_trace;

                data.active_yn     = aDto.active_yn;
                data.create_by_uid = aDto.create_by_uid;
                data.create_on_dts = aDto.create_on_dts;
                data.update_by_uid = aDto.update_by_uid;
                data.update_on_dts = aDto.update_on_dts;

                // persist object and save changes
                ctx.DbContext.WORLD_MAP.Add(data);
                ctx.DbContext.SaveChanges();

                aDto.object_id     = data.id;
                aDto.create_by_uid = aDto.update_by_uid = data.create_by_uid;
                aDto.create_on_dts = aDto.update_on_dts = data.create_on_dts;
                aDto.version_key   = data.version_key;
            }
#endif
            return aDto;
        }

        /// <summary>
        /// update an item in persistent store
        /// </summary>
        /// <param name="aDto"></param>
        public D_WORLD_MAP UpdateItem (D_WORLD_MAP aDto)
        {
#if (NOTYET)
            using (var ctx = DbContextManager<RepositoryModel.ApocFormsEntities>.GetManager())
            {
                var data = ctx.DbContext.WORLD_MAP.Find (aDto.object_id);

                // compare versions
                if (! aDto.version_key.SequenceEqual<byte>(data.version_key))
                    throw new Exception ("version key mismatch");

                // update persisted object
                data.event_dts    = aDto.event_dts;
                data.logger_nm    = aDto.logger_nm;
                data.thread_nm    = aDto.thread_nm;
                data.log_level_cd = aDto.log_level_cd;
                data.apoc_user_nm = aDto.apoc_user_nm;
                data.apoc_user_id = aDto.apoc_user_id;
                data.apoc_form_nm = aDto.apoc_form_nm;
                data.apoc_form_id = aDto.apoc_form_id;
                data.location_txt = aDto.location_txt;
                data.browser_nm   = aDto.browser_nm;
                data.request_url  = aDto.request_url;
                data.referrer_url = aDto.referrer_url;
                data.message_txt  = aDto.message_txt;
                data.stack_trace  = aDto.stack_trace;

                data.active_yn     = aDto.active_yn;
                data.create_by_uid = aDto.create_by_uid;
                data.create_on_dts = aDto.create_on_dts;
                data.update_by_uid = aDto.update_by_uid;
                data.update_on_dts = aDto.update_on_dts;

                // save changes
                ctx.DbContext.SaveChanges();

                aDto.update_by_uid = data.update_by_uid;
                aDto.update_on_dts = data.update_on_dts;
                aDto.version_key   = data.version_key;
            }
#endif
            return aDto;
        }

        /// <summary>
        /// remove an item from persistent store
        /// </summary>
        /// <param name="aId"></param>
        public void DeleteItem (K_WORLD_MAP aKey)
        {
#if (NOTYET)
            using (var ctx = DbContextManager<RepositoryModel.ApocFormsEntities>.GetManager ())
            {
                var data = ctx.DbContext.WORLD_MAP.Find (aKey.object_id);

                ctx.DbContext.WORLD_MAP.Remove (data);
                ctx.DbContext.SaveChanges();
            }
#endif
        }
    }
}