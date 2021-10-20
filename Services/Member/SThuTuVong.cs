using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework;
using Entity;

namespace Services
{
    public class SThuTuVong
    {
        private static FThuTuVong db = new FThuTuVong();
        #region Name_Text
        public static List<EEThuTuVong> Name_Text(string Name_Text)
        {
            return db.Name_Text(Name_Text);
        }
        #endregion
    }
}
