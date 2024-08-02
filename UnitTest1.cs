namespace ASM2
{
    public class SinhVien
    {
        public string id { get; set; }
        public string hoTen { get; set; }
        public string maLop { get; set; }
        public string tenLop { get; set; }
        public string maSv { get; set; }

        public SinhVien()
        {
        }

        public SinhVien(string id, string hoTen, string maLop, string tenLop, string maSv)
        {
            this.id = id;
            this.hoTen = hoTen;
            this.maLop = maLop;
            this.tenLop = tenLop;
            this.maSv = maSv;
        }
    }
    public class Sinhvienpoly
    {
        public List<SinhVien> _sinhviens = new List<SinhVien>();

        public void Them(SinhVien sv)
        {
            if (sv.tenLop != null && sv.tenLop.Any(x => !char.IsLetterOrDigit(x) && !char.IsWhiteSpace(x)))
            {
                throw new ArgumentException("Tenlop không được chứa ký tự đặc biệt");
            }
            else if (sv.tenLop.Length > 10 || sv.tenLop == null || sv.tenLop =="")
            {
                throw new ArgumentException("Tenlop không được quá 10 ký tự hoặc null");
            }
            else if(sv.maLop.Length > 10 || sv.maLop == null || sv.maLop == "")
            {
                throw new ArgumentException("maLop không được quá 10 ký tự hoặc rỗng");
            }
            else if (sv.id.Length > 10 ||sv.id == null || sv.id == "")
            {
                throw new ArgumentException("id không được quá 10 ký tự hoặc rỗng");
            }
            else if (sv.hoTen.Length > 20 || sv.hoTen == null || sv.hoTen == "")
            {
                throw new ArgumentException("hoTen không được quá 20 ký tự hoặc rỗng");
            }
            else if (sv.maSv.Length > 10 || sv.maSv == null || sv.maSv == "")
            {
                throw new ArgumentException("maSv không được quá 10 ký tự hoặc rỗng");
            }
            _sinhviens.Add(sv);
        }
        public SinhVien TimTheoMasv(string masv)
        {
            return _sinhviens.FirstOrDefault(sv => sv.maSv == masv);
        }
        public List<SinhVien> GetList() { return _sinhviens; }
    }
    public class Bai2
    {
        
        public Sinhvienpoly _sinhvienpoly;
        [SetUp]
        public void Setup()
        {
            _sinhvienpoly = new Sinhvienpoly();
        }
        [Test]
        public void ThemThanhCong()
        {
            
            var sv = new SinhVien("1", "Nguyen Tuan Anh", "SD18407", "SOF304", "PH45765");
            _sinhvienpoly.Them(sv);
            Assert.AreEqual(1, _sinhvienpoly.GetList().Count);
        }
        [Test]
        public void Them_HoTenException1_empty()
        {
            var svManager = new Sinhvienpoly();
            var sv = new SinhVien("2","", "SD18407", "SOF304", "PH45765");
            svManager.Them(sv);
            Assert.AreEqual(1, svManager._sinhviens.Count);
        }

        [Test]
        public void Them_HoTenException2_21kytu()
        {
            var svManager = new Sinhvienpoly();
            var sv = new SinhVien("3", "NguyenTuanAnhNguyenAn", "SD18407", "SOF304", "PH45765");
            svManager.Them(sv);
            Assert.AreEqual(1, svManager._sinhviens.Count);
        }
        [Test]
        public void Them_HoTenException3_20kytu()
        {
            var svManager = new Sinhvienpoly();
            var sv = new SinhVien("4", "NguyenTuanAnhNguyenA", "SD18407", "SOF304", "PH45765");
            svManager.Them(sv);
            Assert.AreEqual(1, svManager._sinhviens.Count);
        }
        [Test]
        public void Them_maLop_empty()
        {
            var svManager = new Sinhvienpoly();
            var sv = new SinhVien("4", "NguyenTuanAnh", "", "SOF304", "PH45765");
            svManager.Them(sv);
            Assert.AreEqual(1, svManager._sinhviens.Count);
        }
        [Test]
        public void Them_maLop_10kytu()
        {
            var svManager = new Sinhvienpoly();
            var sv = new SinhVien("4", "NguyenTuanAnh", "SD10407777", "SOF304", "PH45765");
            svManager.Them(sv);
            Assert.AreEqual(1, svManager._sinhviens.Count);
        }
        [Test]
        public void Them_maLop_11kytu()
        {
            var svManager = new Sinhvienpoly();
            var sv = new SinhVien("4", "NguyenTuanAnh", "SD10407777A", "SOF304", "PH45765");
            svManager.Them(sv);
            Assert.AreEqual(1, svManager._sinhviens.Count);
        }
        [Test]
        public void Them_tenLop_empty()
        {
            var svManager = new Sinhvienpoly();
            var sv = new SinhVien("4", "NguyenTuanAnh", "SD10407", "", "PH45765");
            svManager.Them(sv);
            Assert.AreEqual(1, svManager._sinhviens.Count);
        }
        [Test]
        public void Them_tenLop_10kytu()
        {
            var svManager = new Sinhvienpoly();
            var sv = new SinhVien("4", "NguyenTuanAnh", "SD10407", "SOF3041234", "PH45765");
            svManager.Them(sv);
            Assert.AreEqual(1, svManager._sinhviens.Count);
        }
        [Test]
        public void Them_tenLop_11kytu()
        {
            var svManager = new Sinhvienpoly();
            var sv = new SinhVien("4", "NguyenTuanAnh", "SD10407", "SOF30412345", "PH45765");
            svManager.Them(sv);
            Assert.AreEqual(1, svManager._sinhviens.Count);
        }




        ///////////////////////////////////////
        ///TEST CASE TenLop không chứa ký tự đặc biệt
        [Test]
        public void TenLop_KiTuDacBiet()
        {
            var svManager = new Sinhvienpoly();
            var sv = new SinhVien("4", "NguyenTuanAnh", "SD10407", "SOF304@", "PH45765");
            svManager.Them(sv);
            Assert.AreEqual(1, svManager._sinhviens.Count);
        }


        //////////////////////////////////////////
        ///Tìm kiếm theo masv
        [Test]
        public void Tim_ThanhCong()
        {
            var sv = new SinhVien("1", "Nguyen Tuan Anh", "SD18407", "SOF304", "PH45765");
            _sinhvienpoly.Them(sv);
            var svTim = _sinhvienpoly.TimTheoMasv("PH45765");
            Assert.IsNotNull(svTim);
            Assert.AreEqual("PH45765", svTim.maSv);
        }
        [Test]
        public void Tim_ThatBai_rong()
        {
            var sv = new SinhVien("1", "Nguyen Tuan Anh", "SD18407", "SOF304", "PH45765");
            _sinhvienpoly.Them(sv);
            var svTim = _sinhvienpoly.TimTheoMasv("");
            Assert.IsNotNull(svTim);
            Assert.AreEqual("PH45765", svTim.maSv);
        }
        [Test]
        public void Tim_ThatBai_KhongTonTai()
        {
            var sv = new SinhVien("1", "Nguyen Tuan Anh", "SD18407", "SOF304", "PH45765");
            _sinhvienpoly.Them(sv);
            var svTim = _sinhvienpoly.TimTheoMasv("PH12");
            Assert.IsNotNull(svTim);
            Assert.AreEqual("PH45765", svTim.maSv);
        }
        [Test]
        public void Tim_ThatBai_Tuongduong()
        {
            var sv = new SinhVien("1", "Nguyen Tuan Anh", "SD18407", "SOF304", "PH45765");
            _sinhvienpoly.Them(sv);
            var svTim = _sinhvienpoly.TimTheoMasv(new string('A',20));
            Assert.IsNotNull(svTim);
            Assert.AreEqual("PH45765", svTim.maSv);
        }
        [Test]
        public void Tim_ThatBai_null()
        {
            var sv = new SinhVien("1", "Nguyen Tuan Anh", "SD18407", "SOF304", "PH45765");
            _sinhvienpoly.Them(sv);
            var svTim = _sinhvienpoly.TimTheoMasv(null);
            Assert.IsNotNull(svTim);
            Assert.AreEqual("PH45765", svTim.maSv);
        }

    }
}