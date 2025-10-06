using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication10
{
    [Serializable]
    public class SinhVien
    {
        public string HoTen { get; set; }
        public string Email { get; set; }
        public string SDT { get; set; }
        public DateTime NgaySinh { get; set; }  
        public string GioiTinh { get; set; }
        public string KhoaHoc { get; set; }
    }


}