using HappinessPOC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HappinessPOC.Data
{
    public interface IHappinessRepository
    {
        IQueryable<HappyItem> GetHappyItems();
        HappyItem AddHappyItem(HappyItem item);
        bool Save();
    }
}