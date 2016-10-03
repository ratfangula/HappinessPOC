using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HappinessPOC.Models;

namespace HappinessPOC.Data
{
    public class HappinessRepository : IHappinessRepository
    {
        private HappinessContext _ctx;

        public HappinessRepository()//HappinessContext ctx)
        {
            //_ctx = ctx;
            _ctx = new HappinessContext();
        }

        public HappyItem AddHappyItem(HappyItem item)
        {
            try {
                return _ctx.HappyItems.Add(item);
                
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public IQueryable<HappyItem> GetHappyItems()
        {
            return _ctx.HappyItems;
        }

        public bool Save()
        {
            try
            {
                return (_ctx.SaveChanges() > 0);
            } catch(Exception ex)
            {
                return false;
            }
        }
    }
}