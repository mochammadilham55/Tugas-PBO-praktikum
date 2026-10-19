using System;
using System.Collections.Generic;

public class Item
{
    public string Judul;
    public int Tahun;

    public Item(string judul, int tahun)
    {
        Judul = judul;
        Tahun = tahun;
    }

    public virtual void Deskripsi()
    {
        Console.WriteLine($"Item: {Judul} ({Tahun})");
    }

    public virtual void InfoItem()
    {
        Console.WriteLine($"Judul: {Judul}");
        Console.WriteLine($"Tahun: {Tahun}");
    }
}

public class Buku : Item
{
    public string Penulis;

    public Buku(string judul, int tahun, string penulis) : base(judul, tahun)
    {
        Penulis = penulis;
    }

    public void CekPenulis()
    {
        Console.WriteLine($"Buku ini ditulis oleh: {Penulis}");
    }

    public override void InfoItem()
    {
        base.InfoItem();
        Console.WriteLine($"Penulis : {Penulis}");
    }

    public override void Deskripsi()
    {
        Console.WriteLine($"Buku: {Judul} oleh {Penulis}, terbit tahun {Tahun}.");
    }

}
public class Majalah : Item
{
    public int Edisi;

    public Majalah(string judul, int tahun, int edisi) : base(judul, tahun)
    {
        Edisi = edisi;
    }

    public void InfoEdisi()
    {
        Console.WriteLine($"Majalah ini edisi ke-{Edisi}");
    }

    public override void InfoItem()
    {
        base.InfoItem();
        Console.WriteLine($"Edisi: {Edisi}");
    }

    public override void Deskripsi()
    {
        Console.WriteLine($"Majalah: {Judul}, edisi {Edisi}, tahun {Tahun}.");
    }
}
public class Novel : Buku
{
    public Novel(string judul, int tahun, string penulis) : base(judul, tahun, penulis) { }

    public override void Deskripsi()
    {
        Console.WriteLine($"Novel: {Judul} oleh {Penulis}, terbit {Tahun}.");
    }

    public void BacaSinopsis()
    {
        Console.WriteLine($"Sinopsis novel '{Judul}': Kisah menarik penuh konflik dan emosi karya {Penulis}.");
    }
}

public class Komik : Buku
{
    public Komik(string judul, int tahun, string penulis) : base(judul, tahun, penulis) { }

    public override void Deskripsi()
    {
        Console.WriteLine($"Komik: {Judul} oleh {Penulis}, terbit tahun {Tahun}.");
    }

    public void TampilkanIlustrasi()
    {
        Console.WriteLine($"Menampilkan ilustrasi dari komik '{Judul}'...");
    }
}

public class MajalahAnak : Majalah
{
    public MajalahAnak(string judul, int tahun, int edisi) : base(judul, tahun, edisi) { }

    public override void Deskripsi()
    {
        Console.WriteLine($"Majalah Anak: {Judul}, edisi {Edisi}, tahun {Tahun}.");
    }

    public void KategoriAnak()
    {
        Console.WriteLine($"'{Judul}' termasuk kategori bacaan anak usia 5-12 tahun.");
    }
}

public class MajalahTeknologi : Majalah
{
    public MajalahTeknologi(string judul, int tahun, int edisi) : base(judul, tahun, edisi) { }

    public override void Deskripsi()
    {
        Console.WriteLine($"Majalah Teknologi: {Judul}, edisi {Edisi}, tahun {Tahun}.");
    }

    public void TopikTeknologi()
    {
        Console.WriteLine($"'{Judul}' membahas topik teknologi terkini seperti AI dan gadget.");
    }
}

public class Perpustakaan
{
    private List<Item> daftarItem = new List<Item>();

    public void TambahItem(Item item)
    {
        daftarItem.Add(item);
        Console.WriteLine($"'{item.Judul}' berhasil ditambahkan ke perpustakaan.");
    }

    public void DaftarItem()
    {
        Console.WriteLine("\nDAFTAR ITEM DI PERPUSTAKAAN");
        foreach (Item item in daftarItem)
        {
            item.Deskripsi();   
        }
    }
}

public class Program
{
    public static void Main()
    {
        Perpustakaan perpus = new Perpustakaan();

        Novel novel1 = new Novel("Bulan", 2002, "Tereliye");
        Komik komik1 = new Komik("Naruto", 2010, "Budi");
        Majalah majalah1 = new Majalah("National Geographic", 2023, 45);
        MajalahAnak majalahAnak1 = new MajalahAnak("Doraemon", 2024, 150);
        MajalahTeknologi majalahTek1 = new MajalahTeknologi("CHIP", 2024, 87);

        perpus.TambahItem(novel1);
        perpus.TambahItem(komik1);
        perpus.TambahItem(majalahAnak1);
        perpus.TambahItem(majalahTek1);

        perpus.DaftarItem();


        Console.WriteLine("\nDEMONSTRASI POLYMORPHISM");
        Item[] semuaItem = { novel1, komik1, majalahAnak1, majalahTek1 };
        foreach (Item item in semuaItem)
        {
            item.Deskripsi();  
        }

        Console.WriteLine("\nMETHOD KHUSUS");
        novel1.BacaSinopsis();
        komik1.TampilkanIlustrasi();
        majalahAnak1.KategoriAnak();
        majalahTek1.TopikTeknologi();

        Console.WriteLine("\n\nPERTANYAAN");


        Console.WriteLine("\nPertanyaan 1");
        novel1.Deskripsi();
        majalah1.Deskripsi();


        Console.WriteLine("\npertanyaan 2");
        novel1.BacaSinopsis();


        Console.WriteLine("\nPertanyaan 3");
        novel1.InfoItem(); 


        Console.WriteLine("\nPertanyaan 4");
        majalahTek1.TopikTeknologi();


        Console.WriteLine("\nPertanyaan 5");
        Item itemKomik = new Komik("Naruto", 2010, "Budi");
        itemKomik.Deskripsi();

    }



}
