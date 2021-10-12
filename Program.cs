using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10_1
{
    public class KomisiKaryawan : object
    {
        public string NamaDepan;
        public string NamaBelakang;
        public string NomorKTP;
        private decimal penjualanKotor;
        private decimal tingkatKomisi;

        public KomisiKaryawan(string namaDepan, string namaBelakang, string nomorKTP, decimal penjualanKotor, decimal tingkatKomisi)
        {
            NamaDepan = namaDepan;
            NamaBelakang = namaBelakang;
            NomorKTP = nomorKTP;
            PenjualanKotor = penjualanKotor;
            TingkatKomisi = tingkatKomisi;
        }
        public void setNamaDepan(string namaDepan)
        { NamaDepan = namaDepan; }
        public string getNamaDepan()
        { return NamaDepan; }
        public void setNamaBelakang(string namaBelakang)
        { NamaBelakang = namaBelakang; }
        public string getNamaBelakang()
        { return NamaBelakang; }
        public void setNomorKTP(string nomorKTP)
        { NomorKTP = nomorKTP; }
        public string getNomorKTP()
        { return NomorKTP; }

        public decimal PenjualanKotor
        {
            get
            { return penjualanKotor; }
            set
            { penjualanKotor = (value < 0) ? 0 : value; }
        }

        public decimal TingkatKomisi
        {
            get
            { return tingkatKomisi; }
            set
            { tingkatKomisi = (value > 0 && value < 1) ? value : 0; }
        }

        public decimal Pendapatan()
        { return tingkatKomisi * penjualanKotor; }

        public override string ToString()
        {
            return string.Format("Nama Depan : {0} \nNama Belakang : {1} \nNomor KTP : {2} \nPenjualan Kotor : {3} \nTingkat Komisi : {4}", NamaDepan, NamaBelakang, NomorKTP, penjualanKotor, tingkatKomisi);
        }

        public class KomisiTambahanKaryawan : KomisiKaryawan
        {
            private decimal gajiPokok;

            public KomisiTambahanKaryawan(string namaDepan, string namaBelakang, string nomorKTP, decimal penjualanKotor, decimal tingkatKomisi, decimal gajiPokok)
                : base(namaDepan, namaBelakang, nomorKTP, penjualanKotor, tingkatKomisi)
            {
                GajiPokok = gajiPokok;
            }
            public decimal GajiPokok
            {
                get
                { return gajiPokok; }
                set
                { gajiPokok = (value < 0) ? 0 : value; }
            }
            public decimal Pendapatan()
            {
                return tingkatKomisi * penjualanKotor;
            }
        }

        static void Main(string[] args)
        {
            KomisiKaryawan karyawan = new KomisiKaryawan("Sue", "Jones", "222-22-222", 10000.00M, .06M);
            Console.WriteLine("Informasi karyawan diperoleh dari properti dan metode : \n");
            Console.WriteLine("Nama Depan : {0}", karyawan.NamaDepan);
            Console.WriteLine("Nama Belakang : {0}", karyawan.NamaBelakang);
            Console.WriteLine("Nomor KTP : {0}", karyawan.NomorKTP);
            Console.WriteLine("Penjualan Kotornya : {0:C}", karyawan.PenjualanKotor);
            Console.WriteLine("Tingkat Komisinya : {0:F2}", karyawan.TingkatKomisi);
            Console.WriteLine("Pendapatannya : {0:C}", karyawan.Pendapatan());

            karyawan.PenjualanKotor = 5000.00M;
            karyawan.TingkatKomisi = .1M;
            Console.WriteLine("\n{0}:\n\n{1}", "Informasi karyawan yang diperbarui diperoleh dari ToString", karyawan);
            Console.WriteLine("Pendapatan : {0:C}", karyawan.Pendapatan());
            Console.Read();
        }
    }
}