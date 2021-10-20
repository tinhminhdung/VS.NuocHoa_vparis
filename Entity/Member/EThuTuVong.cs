using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Entity
{
    public class EEThuTuVong
    {
        #region[Entity Private]
        private int _ID;
        private int _IDThanhVien;
        private long _ThuTuSet;
        #endregion

        #region[Properties]
        public int ID { get { return _ID; } set { _ID = value; } }
        public int IDThanhVien { get { return _IDThanhVien; } set { _IDThanhVien = value; } }
        public long ThuTuSet { get { return _ThuTuSet; } set { _ThuTuSet = value; } }
        #endregion

    }
}
