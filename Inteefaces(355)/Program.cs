using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_4
{
    public interface HarusDibayar
    { decimal DapatkanJumlahPembayaran(); }
    public class Faktur : HarusDibayar
    {
        public string NomorBagian;
        public string DeskripsiBagian;
        private int kuantitas;
        private decimal hargaPerItem;

        public Faktur(string nomorBagian, string deskripsiBagian, int kuantitas, decimal hargaPerItem)
        {
            NomorBagian = nomorBagian;
            DeskripsiBagian = deskripsiBagian;
            Kuantitas = kuantitas;
            HargaPerItem = hargaPerItem;
        }
        public string getNomorBagian
        {
            get
            { return NomorBagian; }
            set
            { NomorBagian = value;}
        }
        public string getDeskripsiBagian
        {
            get
            { return DeskripsiBagian; }
            set
            { DeskripsiBagian = value; }
        }
        public int Kuantitas
        {
            get
            { return kuantitas; }
            set
            { kuantitas = (value < 0) ? 0 : value; }
        }
        public decimal HargaPerItem
        {
            get
            { return hargaPerItem; }
            set
            { hargaPerItem = (value < 0) ? 0 : value; }
        }
        public override string ToString()
        {
            return string.Format("{0}: \n{1}: {2} ({3}) \n{4}: {5} \n{6}: {7:C}", "Faktur", "Nomor Bagian", NomorBagian, DeskripsiBagian, "Kuantitas", Kuantitas, "Harga per Item", HargaPerItem);
        }
        public decimal DapatkanJumlahPembayaran()
        {
            return Kuantitas * HargaPerItem;
        }
    }
    public abstract class Karyawan : HarusDibayar
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

        public abstract decimal DapatkanJumlahPembayaran();
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
        public override decimal DapatkanJumlahPembayaran()
        { return GajiMingguan; }
        public override string ToString()
        {
            return string.Format("Gaji Karyawan : {0}\n{1}: {2:C}", base.ToString(), "Gaji Mingguan", GajiMingguan);
        }
    }
    public class TesInterfaceHarusDibayar
    {
        static void Main(string[] args)
        {
            HarusDibayar[] objekHarusDibayar = new HarusDibayar[4];

            objekHarusDibayar[0] = new Faktur("01234", "Kursi", 2, 375.00M);
            objekHarusDibayar[1] = new Faktur("56789", "Ban", 4, 79.95M);
            objekHarusDibayar[2] = new GajiKaryawan("John", "Smith", "111-11-1111", 800.00M);
            objekHarusDibayar[3] = new GajiKaryawan("Lisa", "Barnes", "888-88-8888", 1200.00M);

            Console.WriteLine("Faktur dan Karyawan akan diproses secara polymorphisme");

            foreach (HarusDibayar PembayaranSekarang in objekHarusDibayar)
            {
                Console.WriteLine("{0} \n{1}: {2:C}\n", PembayaranSekarang, "Tanggal Jatuh Tempo", PembayaranSekarang.DapatkanJumlahPembayaran());
            }
            Console.ReadLine();
        }
    }
}
