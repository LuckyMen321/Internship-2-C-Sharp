
using System.Runtime.CompilerServices;

Console.WriteLine("1 - Artikli\n2 - Radnici\n3 - Racuni\n4 - Statistika\n0 - Izlaz iz aplikacije");
void chooseAction()
{
    var choice1 = 0;

    if(int.TryParse(Console.ReadLine(), out choice1))
    {
        switch (choice1)
        {
            case 1:
                Console.Clear();
                Console.WriteLine("1 - Unos artikla\n2 - Brisanje artikla\n3 - Uredivanje artikla\n4 - Ispis");
                break;
            case 2:
                Console.Clear();
                Console.WriteLine("1 - Unos radnika\n2 - Brisanje radnika\n3 - Uredivanje radnika\n4 - Ispis");
                break;
            case 3:
                Console.Clear();
                Console.WriteLine("1 - Unos novog računa\n2 - Ispis");
                break;
            case 4:
                Console.Clear();
                Console.WriteLine("1 - Ukupan broj artikala u trgovini\n2 - Vrijednost artikala koji nisu jos prodani\n3 - Brijednost svih artikala koji su prodani\n4 - Stanje po mjesecima");
                break;
            case 0:
                Console.Clear();
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Upisite jedan od brojeva ponudenih");
                chooseAction();
                break;
        }
    }
    else
    {
        Console.WriteLine("Upisite jedan od brojeva ponudenih");
        chooseAction();
    }
}
chooseAction();