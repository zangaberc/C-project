using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

/*
 * Žan Gaberc
 */
namespace Motorji
{
    internal class Program
    {
        // Razred
        class Motor
        {
            // Privatni atributi razreda
            private string ime;
            private string znamka;
            private string barva;
            private string model;
            private int maxHitrost;
            private double ccm;
            private double teza;
            private int letnik;

            // Lastnosti so javno dostopne za branje
            public string Ime
            {
                get => ime;
                // Set je zakomentiran, ker kasneje ne spreminamo vrednosti
                // set => ime = value;
            }

            public string Znamka
            {
                get => znamka;
                // set => znamka = value;
            }

            public string Barva
            {
                get => barva;
                // set => barva = value;
            }

            public string Model
            {
                get => model;
                // set => model = value;
            }

            public int MaxHitrost
            {
                get => maxHitrost;
                // set => maxHitrost = value;
            }

            public double Ccm
            {
                get => ccm;
                // set => ccm = value;
            }

            public double Teza
            {
                get => teza;
                // set => teza = value;
            }

            public int Letnik
            {
                get => letnik;
                // set => letnik = value;
            }

            public Motor()
            {
            }

            // V konstruktorju nastavimo vse vrednosti motorja
            public Motor(string ime, string znamka, string barva, string model, int maxHitrost, double ccm, double teza, int letnik)
            {
                this.ime = ime;
                this.znamka = znamka;
                this.barva = barva;
                this.model = model;
                this.maxHitrost = maxHitrost;
                this.ccm = ccm;
                this.teza = teza;
                this.letnik = letnik;
            }
        }

        class Izvedba
        {
            // Ustvarimo prazen seznam za objekte tipa Motor
            List<Motor> seznam = new List<Motor>(); //DODATNO

            private Motor vpisi()
            {
                // Nastavimo začetne vrednosti.
                string ime = "";
                string znamka = "";
                string barva = "";
                string model = "";
                int maxHitrost = 0;
                double ccm = 0;
                double teza = 0;
                int letnik = 0;

                // Zanka se izvaja toliko časa, dokler ne vpišemo ustrezne vrednosti. Ob ustrezni vrednosti zanko prekinemo z break. Ime mora biti dolgo vsaj 3 znake in krajše od 30 znakov. Znamka mora biti dolgo vsaj 3 znake in krajše od 30 znakov. ...
                while (true)
                {
                    Console.WriteLine("Vpiši ime");
                    ime = Console.ReadLine();

                    if (ime.Length >= 3 && ime.Length < 30)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Ime mora biti dolgo vsaj 3 znake in krajše od 30 znakov.");
                    }
                }

                while (true)
                {
                    Console.WriteLine("Vpiši znamko");
                    znamka = Console.ReadLine();
                    
                    if (znamka.Length >= 3 && znamka.Length < 30)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Znamka mora biti dolgo vsaj 3 znake in krajše od 30 znakov.");
                    }
                }

                while (true)
                {
                    Console.WriteLine("Vpiši barvo");
                    barva = Console.ReadLine();
                    
                    if (barva.Length >= 3 && barva.Length < 30)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Barva mora biti dolgo vsaj 3 znake in krajše od 30 znakov.");
                    }
                }

                while (true)
                {
                    Console.WriteLine("Vpiši model");
                    model = Console.ReadLine();
                    
                    if (model.Length >= 3 && model.Length < 30)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Model mora biti dolgo vsaj 3 znake in krajše od 30 znakov.");
                    }
                }

                while (true)
                {
                    Console.WriteLine("Vpiši maksimalno hitrost");
                    // Če uporabnik ne vpiše ustrezne številske vrednosti, bo izpisalo spodnjo napako (Maksmilana hitrost mora biti večja od 40km/h in manjša od 300km/h.").
                    try
                    {
                        maxHitrost = int.Parse(Console.ReadLine());
                    }
                    catch (Exception e)
                    {
                    }

                    if (maxHitrost >= 40 && maxHitrost <= 300)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Maksmilana hitrost mora biti večja od 40km/h in manjša od 300km/h.");
                    }
                }

                while (true)
                {
                    Console.WriteLine("Vpiši ccm");
                    try
                    {
                        ccm = double.Parse(Console.ReadLine());
                    }
                    catch (Exception e)
                    {
                    }

                    if (ccm >= 1000 && ccm <= 2000)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Ccm mora biti od 1000 do 2000.");
                    }
                }

                while (true)
                {
                    Console.WriteLine("Vpiši težo");
                    try
                    {
                        teza = double.Parse(Console.ReadLine());
                    }
                    catch (Exception e)
                    {
                    }

                    if (teza >= 10 && teza <= 1000)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Teža mora biti od 10kg do 1000kg.");
                    }
                }

                while (true)
                {
                    Console.WriteLine("Vpiši letnik");
                    try
                    {
                        letnik = int.Parse(Console.ReadLine());
                    }
                    catch (Exception e)
                    {
                    }
                    
                    if ((letnik + "").Length == 4) // ali if (letnik > 1800 && letnik < 2020)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Letnik mora biti sestavljen iz 4 številk.");
                    }
                }

                // Ustvarimo nov objekt motorja
                Motor motor = new Motor(ime, znamka, barva, model, maxHitrost, ccm, teza, letnik);
                return motor;
            }
            
            public void dodajanje()
            {
                Motor motor = vpisi();
                
                // Motor dodamo v seznam
                seznam.Add(motor);
            }

            public void spremeni()
            {
                int stevilka = -1;
                
                // Uporabnik mora vpisati ustrezno zaporedno številko motorja. Ob neveljavni vrednosti mora akcijo ponoviti. Ob vnosu številke spremenimo podatke motorja.
                while (true)
                {
                    Console.WriteLine("Vpiši zaporedno številko motorja: 1 - " + seznam.Count);
                    try
                    {
                        stevilka = int.Parse(Console.ReadLine());
                    }
                    catch (Exception e)
                    {
                    }

                    if (stevilka < 1 || stevilka > seznam.Count)
                    {
                        Console.WriteLine("Neveljavna številka");
                    }
                    else
                    {
                        Motor motor = vpisi();
                        seznam[stevilka - 1] = motor;

                        break;
                    }
                }
            }
            
            
            public void izbrisi()
            {
                int stevilka = -1;
                
                // Uporabnik mora vpisati ustrezno zaporedno številko motorja. Ob neveljavni vrednosti mora akcijo ponoviti. Ob vnosu številke izbrišemo motor iz seznama.
                while (true)
                {
                    Console.WriteLine("Vpiši zaporedno številko motorja: 1 - " + seznam.Count);
                    try
                    {
                        stevilka = int.Parse(Console.ReadLine());
                    }
                    catch (Exception e)
                    {
                    }

                    if (stevilka < 1 || stevilka > seznam.Count)
                    {
                        Console.WriteLine("Neveljavna številka");
                    }
                    else
                    {
                        seznam.RemoveAt(stevilka - 1);
                        Console.WriteLine("Motor je bil izbrisan");

                        break;
                    }
                }
            }

            // Vpišemo ime datoteke v katero želimo shraniti. Vsak posamezen motor se shrani v posamezno vrstico. V vrstici so zapisani vsi podatki motorja.
            // Če datoteka v katero želimo zapisati že obstaja, nas program vpraša ali želimo obdržati obstoječe shranjene podatke v datoteki in pripisati nove.
            // Če želimo, podatke pripiše v datoteko, drugače pa obstoječe podatke povozi z novimi.
            public void shrani()
            {
                Console.WriteLine("Vpiši ime datoteke");
                string imeDatoteke = Console.ReadLine();

                string text = "";

                foreach (var motor in seznam)
                {
                    text += motor.Ime + ";" + motor.Znamka + ";" + motor.Barva + ";" + motor.Model + ";" +
                            motor.MaxHitrost + ";" + motor.Ccm + ";" + motor.Teza + ";" + motor.Letnik + "\n";
                }

                if (File.Exists(imeDatoteke))
                {
                    Console.WriteLine("Želiš obdržati obstoječe shranjene podatke v datoteki in pripisati nove? (da / ne)");
                    string odgovor = Console.ReadLine();

                    if (odgovor == "da")
                    {
                        try
                        {
                            File.AppendAllText(imeDatoteke, text);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Napaka pri dpiranju/pisanju datoteke");
                        }
                    }
                    else
                    {
                        try {
                            File.WriteAllText(imeDatoteke, text);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Napaka pri dpiranju/pisanju datoteke");
                        }
                    }
                }
                else
                {
                    try {
                        File.WriteAllText(imeDatoteke, text);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Napaka pri odpiranju/pisanju datoteke");
                    }
                }
            }

            // Pri nalaganju podatkov vpišemo ime datoteke. Če imamo v seznamu že obstoječe podatke, nas vpraša ali želimo obdržati obstoječe podatke in pripisati nove.
            // Če je odgovor da, podatke pripiše v seznam. Če je odgovor ne, pred dodajanje seznam še pobriše.
            public void nalozi()
            {
                while (true)
                {
                    try
                    {
                        Console.WriteLine("Vpiši ime datoteke");
                        string imeDatoteke = Console.ReadLine();

                        string[] vrstice = File.ReadAllLines(imeDatoteke);


                        if (seznam.Count > 0)
                        {
                            Console.WriteLine("Želiš obdržati obstoječe podatke in pripisati nove? (da / ne)");
                            string odgovor = Console.ReadLine();

                            if (odgovor == "da")
                            {

                            }
                            else
                            {
                                seznam.Clear();
                            }
                        }

                        foreach (var vrstica in vrstice)
                        {
                            string[] podatki = vrstica.Split(';');
                            Motor motor = new Motor(podatki[0], podatki[1], podatki[2], podatki[3],
                                int.Parse(podatki[4]), Double.Parse(podatki[5]), Double.Parse(podatki[6]),
                                int.Parse(podatki[7]));
                            seznam.Add(motor);
                        }

                        break;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Napaka pri odpiranju/branju datoteke");
                    }
                }
            }

            // Izpišemo vse podatke iz seznma v konzolo
            public void izpis()
            {
                string text = "";

                foreach (var motor in seznam)
                {
                    Console.WriteLine(motor.Ime + ", " + motor.Znamka + ", " + motor.Barva + ", " + motor.Model + ", " +
                                      motor.MaxHitrost + ", " + motor.Ccm + ", " + motor.Teza + ", " + motor.Letnik);
                }
            }

            // Pobrišemo seznam
            public void izbrisiVse()
            {
                seznam.Clear();
            }
            
            // Preštejemo število objektov
            public void steviloObjektov()
            {
                Console.WriteLine("Število objektov je " + seznam.Count);
            }

            // Sortiramo seznam motorjev po hitrosti.
            public void sortiraj()
            {
                seznam = seznam.OrderBy(element => element.MaxHitrost).ToList();
                Console.WriteLine("Seznam je bil sortiran po hitrosti motorjev.");
            }
        }
        
        public static void Main(string[] args)
        {
            string meni = "1 Dodajanje novega objekta\n" +
                          "2 Brisanje izbranega objekta\n" +
                          "3 Spreminjanje izbranega objekta\n" +
                          "4 Shranjevanje objektov v datoteko\n" +
                          "5 Nalaganje objektov iz datoteke v polje objektov\n" +
                          "6 Izbriši vse\n" +
                          "7 Število objektov\n" +
                          "8 Izpis\n" +
                          "9 Sortiranje po hitrosti\n\n";
            
            Izvedba izvedba = new Izvedba();

            while (true)
            {
                Console.WriteLine(meni);
                Console.WriteLine("Izberi številko iz menija");
                int stevilka = int.Parse(Console.ReadLine());
                
                
                // Uporabnik izbere številko iz menija
                switch (stevilka)
                {
                    case 1:
                    {
                        izvedba.dodajanje();
                        break;
                    }
                    case 2:
                    {
                        izvedba.izbrisi();
                        break;
                    }
                    case 3:
                    {
                        izvedba.spremeni();
                        break;
                    }
                    case 4:
                    {
                        izvedba.shrani();
                        break;
                    }
                    case 5:
                    {
                        izvedba.nalozi();
                        break;
                    }
                    case 6:
                    {
                        izvedba.izbrisiVse(); // DODATNO
                        break;
                    }
                    case 7:
                    {
                        izvedba.steviloObjektov();  // DODATNO
                        break;
                    }
                    case 8:
                    {
                        izvedba.izpis();
                        break;
                    }
                    case 9:
                    {
                        izvedba.sortiraj(); // DODATNO
                        break;
                    }
                    default:
                    {
                        return;
                    }
                }
            }
        }
    }
}