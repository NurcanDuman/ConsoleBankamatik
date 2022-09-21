using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankamatik
{
    internal class Program
    {
        static double bakiye = 250;
        static string sifre = "ab18";
        static void Main(string[] args)
        {
            KartIslem();
            Console.ReadLine();
        }
        private static void AnaMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Yapmak istediğiniz işlemi seçiniz \nPara çekmek için = 1 \nPara yatırmak için = 2 \nPara transferleri için = 3 \nEğitim ödemeleri için = 4 \nÖdemeler için = 5 \nBilgi Güncelleme için = 6 \nbasınız");
            
            try
            {
                int islem = Convert.ToInt32(Console.ReadLine());

                switch (islem)
                {
                    case 1:
                        ParaCek();
                        break;
                    case 2:
                        ParaYatir();
                        break;
                    case 3:
                        ParaTransferleri();
                        break;
                    case 4:
                        EgitimOdemeleri();
                        break;
                    case 5:
                        Odeme();
                        break;
                    case 6:
                        BilgiGuncelleme();
                        break;
                    default:
                        Console.WriteLine("Geçersiz işlem");
                        break;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private static void ParaCek()
        {
            BakiyeKontrol();
            SonIslem();
        }
        private static void ParaYatir()
        {
            Console.WriteLine("Kredi Kartına para yatırmak için 1 \nKendi hesabınıza yatırmak için 2 \nbasınız");
            try{
                int paraYatirIslem = Convert.ToInt32(Console.ReadLine());
                if (paraYatirIslem == 1)
                {
                    Console.WriteLine("12 haneli kart numarasını giriniz: ");
                    string kartNo = Console.ReadLine();
                    if (kartNo.Length == 12)
                    {
                        BakiyeKontrol();
                    }
                    else
                    {
                        Console.WriteLine("Girilen kart numarası 12 haneli olmalı! ");
                        ParaYatir();
                    }
                }
                else if (paraYatirIslem == 2)
                {
                    Console.WriteLine("Yatırmak istediğiniz tutarı giriniz: ");
                    double yeni = Convert.ToDouble(Console.ReadLine());
                    bakiye = yeni + bakiye;
                    Console.WriteLine("Yeni bakiyeniz: " + bakiye);
                    SonIslem();
                }
                else { Console.WriteLine("Geçersiz işlem"); }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private static void ParaTransferleri()
        {
            Console.WriteLine("Başka hesaba EFT için 1 \nBaşka hesaba havale için 2 \nBasınız: ");
            try
            {
                int paraTransfer = Convert.ToInt32(Console.ReadLine());
                if (paraTransfer == 1)
                {
                    Console.WriteLine("EFT numarasını giriniz: ");
                    string eftNo = Console.ReadLine();
                    string kontrol = "tr";

                    int sayac = 0;
                    if (eftNo.IndexOf(kontrol) == -1)
                    {
                        Console.WriteLine("Lütfen EFT numarasının başına tr ekleyiniz! ");
                        ParaTransferleri();
                    }
                    else
                    {
                        if (eftNo.Length == 12)
                        {
                            BakiyeKontrol();
                        }
                        else
                        {
                            Console.WriteLine("Girilen kart numarası 12 haneli olmalı! ");
                            ParaTransferleri();
                        }
                        SonIslem();
                    }
                }
                else if (paraTransfer == 2)
                {
                    Console.WriteLine("12 haneli kart numarasını giriniz: ");
                    string kartNo = Console.ReadLine();
                    if (kartNo.Length == 11)
                    {
                        BakiyeKontrol();
                    }
                    else
                    {
                        Console.WriteLine("Girilen hesap numarası 11 haneli olmalı! ");
                        ParaTransferleri();
                    }
                }
                else { Console.WriteLine("Geçersiz işlem"); }
                SonIslem();
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private static void EgitimOdemeleri()
        {
            Console.WriteLine("Eğitim ödemeleri işlemleriniz için çalışmalarımız devam ediyor :) ");
            SonIslem();
        }
        private static void Odeme()
        {
            Console.WriteLine("Elektrik faturası için 1 \nTelefon faturası için 2 \nİnternet faturası için 3 \nSu faturası için 4 \nOGS ödemeleri için 5 \nbasınız: ");
            try
            {
                int odemeler = Convert.ToInt32(Console.ReadLine());
                BakiyeKontrol();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private static void BilgiGuncelleme()
        {
            Console.WriteLine("Şifreyi değiştirmek için 1'e basınız ");
            
            try
            {
                string degisiklik = Console.ReadLine();
                if (degisiklik == "1")
                {
                    Console.WriteLine("Yeni şifrenizi giriniz: ");
                    string yeniSifre = Console.ReadLine();
                    sifre = yeniSifre;
                }
                else { Console.WriteLine("Geçersiz işlem "); }
                SonIslem();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private static void KartIslem()
        {
            Console.WriteLine("Kartlı işlem için 1'e \nKartsız işlemler için 2'ye basınız");
            try
            {
                int KartIslem = Convert.ToInt32(Console.ReadLine());

                if (KartIslem == 1)
                {
                    Console.WriteLine("Kartlı işlemi seçtiniz");
                    for (int i = 0; i < 3; i++)
                    {
                        Console.WriteLine("Şifreyi giriniz");
                        string sif = Console.ReadLine();
                        if (sif == sifre)
                        {
                            Console.WriteLine("Şifreyi doğru girdiniz");
                            AnaMenu();
                        }

                        else
                        {
                            Console.WriteLine("Şifreyi yanlış girdiniz");
                        }
                    }
                    Console.WriteLine("Şifreyi 3 kere yanlış girdiniz!");
                }

                else if (KartIslem == 2)
                {
                    Console.WriteLine("Kartsız işlemi seçtiniz");
                }
                else
                {
                    Console.WriteLine("Geçersiz işlem");
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void SonIslem()
        {
            Console.WriteLine("Ana menüye dönmek için 9 \nÇıkmak için 0 \nbasınız");
            try
            {
                int sonIslem = Convert.ToInt32(Console.ReadLine());
                if (sonIslem == 9)
                {
                    AnaMenu();
                }
                else if (sonIslem == 0)
                {
                    Console.Read();
                }
                else { Console.WriteLine("Geçersiz işlem"); }
            }

            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
        private static double BakiyeKontrol()
        {
            Console.WriteLine("Tutarı giriniz: ");

            try
            {
                double tutar = Convert.ToDouble(Console.ReadLine());

                if (tutar > bakiye)
                {
                    Console.WriteLine("Tutar mevcut bakiyenizden büyük: ");
                    SonIslem();
                }
                else
                {
                    bakiye = bakiye - tutar;
                    Console.WriteLine("Yeni bakiyeniz: " + bakiye);
                    SonIslem();
                }
            }
            
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return bakiye;
        }
    }
}