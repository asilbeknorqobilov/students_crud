using System;
using System.Collections.Generic;
using System.Linq;

class Talaba
{
    public string Ism { get; set; }
    public string Familiya { get; set; }
    public int TugilganYil { get; set; }
    public string Telefon { get; set; }

    public override string ToString()
    {
        return $"Ism: {Ism}, Familiya: {Familiya}, Tug'ilgan yil: {TugilganYil}, Telefon: {Telefon}";
    }
}

class TALABA_GURUHI
{
    private List<Talaba> talabalar = new List<Talaba>();

    public void TalabaQoshish(Talaba talaba)
    {
        talabalar.Add(talaba);
    }

    public void TalabaOchirish(string ochirish)
    {
        talabalar.RemoveAll(t => t.Familiya == ochirish || t.Ism == ochirish ||
                                 t.TugilganYil.ToString() == ochirish || t.Telefon == ochirish);
    }

    public Talaba TalabaIzlash(string qidiruvAlomati)
    {
        return talabalar.Find(t =>
            t.Familiya == qidiruvAlomati || t.Ism == qidiruvAlomati ||
            t.TugilganYil.ToString() == qidiruvAlomati || t.Telefon == qidiruvAlomati);
    }

    public void Tartiblash()
    {
        talabalar.Sort((x, y) => string.Compare(x.Familiya, y.Familiya));
    }

    public void TalabalarniChopEtish()
    {
        foreach (var talaba in talabalar)
        {
            Console.WriteLine(talaba);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        TALABA_GURUHI guruh = new TALABA_GURUHI();

        Console.WriteLine("Talabalar soni");
        int n = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Quyidagi ketma-ketlikda kiriting:1.Ism,2.Familiya,Tug'ilgan yili,Telefon");
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"{i+1}-chi talaba");
                    Talaba talaba = new Talaba
                    { 
                        Ism = Convert.ToString(Console.ReadLine()) , Familiya = Convert.ToString(Console.ReadLine()),TugilganYil = 
                        Convert.ToInt32(Console.ReadLine()),Telefon = Convert.ToString(Console.ReadLine())
                    };
                    guruh.TalabaQoshish(talaba);
        }

        guruh.TalabalarniChopEtish();
        Console.WriteLine();

        // Qidiruv
        Console.WriteLine("Izlanayotgan talaba ma'lumoti");
        Talaba izlanganTalaba = guruh.TalabaIzlash(Convert.ToString(Console.ReadLine()));
        if (izlanganTalaba != null)
        {
            Console.WriteLine("Topilgan talaba: " + izlanganTalaba);
        }
        else
        {
            Console.WriteLine("Talaba topilmadi.");
        }

        Console.WriteLine();

        // Tartiblash
        guruh.Tartiblash();
        Console.WriteLine();

        // O'chirish
        Console.WriteLine("O'chiriladigan talaba ma'lumoti");
        guruh.TalabaOchirish(Convert.ToString(Console.ReadLine()));
        Console.WriteLine("Qolgan talabalar");
        guruh.TalabalarniChopEtish();
    }
}