﻿using System.Collections.Generic;

namespace QLCL.Models
{
    public class CongNhanModels
    {
        public string MaCongNhan;
        public string TenCongNhan;
        public bool GioiTinh;
        public int NamSinh;
        public string NuocVe;
        public string MaDiemCL;

        public ICollection<CN_TCModels> CN_TCs { get; set; }
    }
}
