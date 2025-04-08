using System;

class Karyawan
{
    private string Nama { get; set; }
    private string ID { get; set; }
    private double GajiPokok { get; set; }

    public Karyawan(string nama, string id, double gajiPokok)
    {
        this.Nama = nama;
        this.ID = id;
        this.GajiPokok = gajiPokok;
    }

    public string getNama() => Nama;
    public string getID() => ID;
    public double getGajiPokok() => GajiPokok;

    public virtual double HitungGaji()
    {
        return GajiPokok;
    }
}

class KaryawanTetap : Karyawan
{
    public KaryawanTetap(string nama, string id, double gajiPokok)
        : base(nama, id, gajiPokok) { }

    public override double HitungGaji()
    {
        return getGajiPokok() + 500000;
    }
}

class KaryawanKontrak : Karyawan
{
    public KaryawanKontrak(string nama, string id, double gajiPokok)
        : base(nama, id, gajiPokok) { }

    public override double HitungGaji()
    {
        return getGajiPokok() - 200000;
    }
}

class KaryawanMagang : Karyawan
{
    public KaryawanMagang(string nama, string id, double gajiPokok)
        : base(nama, id, gajiPokok) { }
}

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Aplikasi Data Karyawan ===");
            Console.WriteLine("1. Karyawan Tetap");
            Console.WriteLine("2. Karyawan Kontrak");
            Console.WriteLine("3. Karyawan Magang");
            Console.WriteLine("4. Keluar");
            Console.Write("Masukkan pilihan (1/2/3/4): ");
            string pilihan = Console.ReadLine();

            if (pilihan == "4")
            {
                Console.WriteLine("Terima kasih! Program selesai.");
                break;
            }

            Console.WriteLine();
            Console.Write("Masukkan Nama: ");
            string nama = Console.ReadLine();
            Console.Write("Masukkan ID Karyawan: ");
            string id = Console.ReadLine();

            double gajiPokok;
            while (true)
            {
                Console.Write("Masukkan Gaji Pokok: Rp.");
                if (double.TryParse(Console.ReadLine(), out gajiPokok)) break;
                Console.WriteLine("Input tidak valid. Harus berupa angka.");
            }

            Karyawan karyawan = null;

            if (pilihan == "1")
            {
                karyawan = new KaryawanTetap(nama, id, gajiPokok);
            }
            else if (pilihan == "2")
            {
                karyawan = new KaryawanKontrak(nama, id, gajiPokok);
            }
            else if (pilihan == "3")
            {
                karyawan = new KaryawanMagang(nama, id, gajiPokok);
            }
            else
            {
                Console.WriteLine("Pilihan tidak valid! Tekan Enter untuk kembali ke menu.");
                Console.ReadLine();
                continue;
            }

            Console.WriteLine();
            Console.WriteLine($"Gaji Akhir {karyawan.getNama()} (ID: {karyawan.getID()}): Rp.{karyawan.HitungGaji()}");
            Console.WriteLine("\nTekan Enter untuk kembali ke menu utama...");
            Console.ReadLine();
        }
    }
}
