namespace QLCL.Models
{
    public class CN_TCModels
    {
        public string MaCongNhan { get; set; }
        public string MaTrieuChung { get; set; }

        public CongNhanModels CongNhan { get; set; }
        public TrieuChungModels TrieuChung { get; set; }
    }
}
