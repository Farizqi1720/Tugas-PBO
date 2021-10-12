using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_3
{
    public abstract class Karyawan
    {
        public string NamaDepan;
        public string NamaBelakang;
        public string NomorKTP;
        public Karyawan(string namaDepan, string namaBelakang, string nomorKTP)
        {
            NamaDepan = namaDepan;
            NamaBelakang = namaBelakang;
            NomorKTP = nomorKTP;
        }
        public string getNamaDepan
        {
            get
            { return NamaDepan; }
        }
        public string getNamaBelakang
        {
            get
            { return NamaBelakang; }
        }
        public string getNomorKTP
        {
            get
            { return NomorKTP; }
        }
        public override string ToString()
        {
            return string.Format("{0} {1}\nNomor KTP : {2}", NamaDepan, NamaBelakang, NomorKTP);
        }

        public abstract decimal Pendapatan();
    }

    public class GajiKaryawan : Karyawan
    {
        private decimal gajiMingguan;

        public GajiKaryawan(string namaDepan, string namaBelakang, string nomorKTP, decimal gajiMingguan)
            : base(namaDepan, namaBelakang, nomorKTP)
        { GajiMingguan = gajiMingguan; }
        public decimal GajiMingguan
        {
            get
            { return gajiMingguan; }
            set
            { gajiMingguan = ((value >= 0) ? value : 0); }
        }
        public override decimal Pendapatan()
        { return GajiMingguan; }
        public override string ToString()
        {
            return string.Format("Gaji Karyawan : {0}\n{1}: {2:C}", base.ToString(), "Gaji Mingguan", GajiMingguan);
        }
    }
    public class KaryawanPerjam : Karyawan
    {
        private decimal upah;
        private decimal jam;

        public KaryawanPerjam(string namaDepan, string namaBelakang, string nomorKTP, decimal upahPerjam, decimal jamKerja)
            : base(namaDepan, namaBelakang, nomorKTP)
        {
            Upah = upahPerjam;
            Jam = jamKerja;
        }
        public decimal Upah
        {
            get
            { return upah; }
            set
            { upah = (value >= 0) ? value : 0; }
        }
        public decimal Jam
        {
            get
            { return jam;}
            set
            { jam = ((value >= 0) && (value <= 168)) ? value : 0; }
        }
        public override decimal Pendapatan()
        {
            if (Jam <= 40)
                return Upah * Jam;
            else
                return (40 * Upah) + ((Jam - 40) * 1.5M);
        }
        public override string ToString()
        {
            return string.Format("Karyawan per jam : {0}\n{1}: {2:C}; {3}: {4:F2}", base.ToString(), "Upah/jam : ", Upah, "Jam Kerja : ", Jam);
        }
    }
    public class KomisiKaryawan : Karyawan
    {
        private decimal penjualanKotor;
        private decimal tingkatKomisi;

        public KomisiKaryawan(string namaDepan, string namaBelakang, string nomorKTP, decimal penjualanKotor, decimal tingkatKomisi)
            : base(namaDepan, namaBelakang, nomorKTP)
        {
            PenjualanKotor = penjualanKotor;
            TingkatKomisi = tingkatKomisi;
        }
        public decimal PenjualanKotor
        {
            get
            { return penjualanKotor; }
            set
            { penjualanKotor = (value >= 0) ? value : 0; }
        }
        public decimal TingkatKomisi
        {
            get
            { return tingkatKomisi; }
            set
            { tingkatKomisi = (value > 0 && value < 1) ? value : 0; }
        }
        public override decimal Pendapatan()
        { return TingkatKomisi * PenjualanKotor; }
        public override string ToString()
        {
            return string.Format("{0}: {1}\n{2}: {3:C}\n{4}: {5:F2}", "Komisi Karyawan : ", base.ToString(), "Penjualan Kotor : ", PenjualanKotor, "Tingkat Komisi : ", TingkatKomisi);
        }
    }
    public class TambahanKomisiKaryawan : KomisiKaryawan
    {
        private decimal gajiPokok;

        public TambahanKomisiKaryawan(string namaDepan, string namaBelakang, string nomorKTP, decimal penjualanKotor, decimal tingkatKomisi, decimal gajiPokok)
            : base(namaDepan, namaBelakang, nomorKTP, penjualanKotor, tingkatKomisi)
        { GajiPokok = gajiPokok; }
        public decimal GajiPokok
        {
            get
            { return gajiPokok; }
            set
            { gajiPokok = (value >= 0) ? value : 0; }
        }
        public override decimal Pendapatan()
        { return GajiPokok * base.Pendapatan(); }
        public override string ToString()
        {
            return string.Format("{0} {1}; {2}: {3:C}", "Gaji-Pokok : ", base.ToString(), "Gaji Pokok : ", GajiPokok);
        }
    }
    public class TesSistemDaftarGaji
    {
        static void Main(string[] args)
        {
            GajiKaryawan gajiKaryawan = new GajiKaryawan("John", "Smith", "111-11-1111", 800.00M);
            KaryawanPerjam karyawanPerjam = new KaryawanPerjam("Karen", "Price", "222-22-2222", 16.75M, 40.0M);
            KomisiKaryawan komisiKaryawan = new KomisiKaryawan("Sue", "Jones", "333-33-3333", 10000.00M, .06M);
            TambahanKomisiKaryawan tambahanKomisiKaryawan = new TambahanKomisiKaryawan("Bob", "Lewis", "444-44-4444", 5000.00M, .04M, 300.00M);

            Console.WriteLine("Karyawan diproses Secara Individual :\n");
            Console.WriteLine("{0}\n{1}: {2:C}\n", gajiKaryawan, "Diperoleh", gajiKaryawan.Pendapatan());
            Console.WriteLine("{0}\n{1}: {2:C}\n", karyawanPerjam, "Diperoleh", karyawanPerjam.Pendapatan());
            Console.WriteLine("{0}\n{1}: {2:C}\n", komisiKaryawan, "Diperoleh", komisiKaryawan.Pendapatan());
            Console.WriteLine("{0}\n{1}: {2:C}\n", tambahanKomisiKaryawan, "Diperoleh", tambahanKomisiKaryawan.Pendapatan());

            Karyawan[] karyawan = new Karyawan[4];

            karyawan[0] = gajiKaryawan;
            karyawan[1] = karyawanPerjam;
            karyawan[2] = komisiKaryawan;
            karyawan[3] = tambahanKomisiKaryawan;

            Console.WriteLine("Karyawan diproses Secara Polymorphically:\n");

            foreach (Karyawan karyawanSekarang in karyawan)
            {
                Console.WriteLine(karyawanSekarang);
                if (karyawanSekarang is TambahanKomisiKaryawan)
                {
                    TambahanKomisiKaryawan pegawai = (TambahanKomisiKaryawan)karyawanSekarang;

                    pegawai.GajiPokok *= 1.10M;
                    Console.WriteLine("Gaji pokok baru dengan kenaikan 10% adalah : {0:C}", pegawai.GajiPokok);
                }
                Console.WriteLine("Diperoleh {0:C}\n", karyawanSekarang.Pendapatan());
            }
            for (int j = 0; j < karyawan.Length; j++)
                Console.WriteLine("Karyawan {0} : {1}", j, karyawan[j].GetType());
            Console.ReadLine();
        }
    }
}
