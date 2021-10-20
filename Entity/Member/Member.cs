using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Entity
{
    public class Member
    {
        #region[Entity Private]
        private int _ID;
        private string _PasWord;
        private string _HoVaTen;
        private int _GioiTinh;
        private string _NgaySinh;
        private string _DiaChi;
        private string _DienThoai;
        private string _Email;
        private string _AnhDaiDien;
        private DateTime _NgayTao;
        private string _Key;
        private int _TrangThai;
        private string _Lang;
        private int _GioiThieu;
        private string _MTRee;
        private string _TienHoaHong;
        private int _SoNguPhan;
        private int _TrangThaiMuaHang;
        private int _TongTrucTiep;
        private string _TongTienDaRut;
        private int _TrangThaiMuaHangDatTongTien;
        private int _CapBac;
        private string _IDLuuTam;
        private string _CoPhan;
        private string _TongTienDaMuaHang;
        private int _F1MuaHangDeTinhThuong;
        private int _TrangThaiF1MuaHang;
        private string _ViVip;
        private string _ViVipDaMuaHang;
        private string _ViCoPhanSo;

        private int _F1MuaHangThuongSoCoPhan;
        private int _TrangThaiF1MuaHangSoCoPhan;
        #endregion

        #region[Properties]
        public int ID { get { return _ID; } set { _ID = value; } }
        public string PasWord { get { return _PasWord; } set { _PasWord = value; } }
        public string HoVaTen { get { return _HoVaTen; } set { _HoVaTen = value; } }
        public int GioiTinh { get { return _GioiTinh; } set { _GioiTinh = value; } }
        public string NgaySinh { get { return _NgaySinh; } set { _NgaySinh = value; } }
        public string DiaChi { get { return _DiaChi; } set { _DiaChi = value; } }
        public string DienThoai { get { return _DienThoai; } set { _DienThoai = value; } }
        public string Email { get { return _Email; } set { _Email = value; } }
        public string AnhDaiDien { get { return _AnhDaiDien; } set { _AnhDaiDien = value; } }
        public DateTime NgayTao { get { return _NgayTao; } set { _NgayTao = value; } }
        public string Key { get { return _Key; } set { _Key = value; } }
        public int TrangThai { get { return _TrangThai; } set { _TrangThai = value; } }
        public string Lang { get { return _Lang; } set { _Lang = value; } }
        public int GioiThieu { get { return _GioiThieu; } set { _GioiThieu = value; } }
        public string MTRee { get { return _MTRee; } set { _MTRee = value; } }
        public string TienHoaHong { get { return _TienHoaHong; } set { _TienHoaHong = value; } }
        public int SoNguPhan { get { return _SoNguPhan; } set { _SoNguPhan = value; } }
        public int TrangThaiMuaHang { get { return _TrangThaiMuaHang; } set { _TrangThaiMuaHang = value; } }
        public int TongTrucTiep { get { return _TongTrucTiep; } set { _TongTrucTiep = value; } }
        public string TongTienDaRut { get { return _TongTienDaRut; } set { _TongTienDaRut = value; } }
        public int TrangThaiMuaHangDatTongTien { get { return _TrangThaiMuaHangDatTongTien; } set { _TrangThaiMuaHangDatTongTien = value; } }
        public int CapBac { get { return _CapBac; } set { _CapBac = value; } }
        public string IDLuuTam { get { return _IDLuuTam; } set { _IDLuuTam = value; } }
        public string CoPhan { get { return _CoPhan; } set { _CoPhan = value; } }
        public string TongTienDaMuaHang { get { return _TongTienDaMuaHang; } set { _TongTienDaMuaHang = value; } }
        public int F1MuaHangDeTinhThuong { get { return _F1MuaHangDeTinhThuong; } set { _F1MuaHangDeTinhThuong = value; } }
        public int TrangThaiF1MuaHang { get { return _TrangThaiF1MuaHang; } set { _TrangThaiF1MuaHang = value; } }
        public string ViVip { get { return _ViVip; } set { _ViVip = value; } }
        public string ViVipDaMuaHang { get { return _ViVipDaMuaHang; } set { _ViVipDaMuaHang = value; } }
        public string ViCoPhanSo { get { return _ViCoPhanSo; } set { _ViCoPhanSo = value; } }
        public int F1MuaHangThuongSoCoPhan { get { return _F1MuaHangThuongSoCoPhan; } set { _F1MuaHangThuongSoCoPhan = value; } }
        public int TrangThaiF1MuaHangSoCoPhan { get { return _TrangThaiF1MuaHangSoCoPhan; } set { _TrangThaiF1MuaHangSoCoPhan = value; } }
        #endregion
    }
}
