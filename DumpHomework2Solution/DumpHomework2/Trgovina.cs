using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.WebSockets;
using System.Numerics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics.X86;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Schema;
var valueOfArticlesSold = 0f;
Dictionary<int, Dictionary<int, List<dynamic>>> listOfArticleByBillID = new Dictionary<int, Dictionary<int, List<dynamic>>>();
int articleIndex = 0;
float finalPrice = 0f;
Dictionary<int, List<dynamic>> listOfArticleBill = new Dictionary<int, List<dynamic>>();
List<float> listOfFinalPrice = new();
List<int> listOfBillID = new();
var billID = 0;
List<int> articleQuantitiesBill = new();
int articleQuantityBill = 0;
List<string> articleNamesBill = new List<string>();
List<int> listOfArticlesSold = new();
var workerName = "";
var workerDOB = DateTime.Now;
List<string> listOfWorkerName= new()
{
    "Frane Radovic",
    "Ana Radovic",
    "Iva Sverko"
};
List<DateTime> listOfBillDates = new();
List<DateTime> listOfWorkerDOB = new()
{
    new DateTime(1900,11,17),
    new DateTime(1950,8,2),
    new DateTime(2000,2,20)
};
var priceReductionString = "";
var priceReduction = 0;
var priceIncreaseString = "";
int priceIncrease = 0;
var choiceString = "";
string confirmation = "";
string nameOfArticle = "";
int quantityOfArticle = 0;
float priceOfArticle = 0f;
DateTime DateOfExpirationOfArticle = DateTime.Now;
var choice = 0;
List<string> articleName = new()
{
    "frane",
    "ana",
    "iva"
};
List<int> articleQuantity = new()
{
    1,
    3,
    2
};
List<float> articlePrice = new()
{
    1.1f,
    3.3f,
    2.2f
};
List<DateTime> articleExpirationDate = new()
{
    new DateTime(1,1,1),
    new DateTime(3,3,3),
    new DateTime(2,2,2)
};
var backingUp = "";
void chooseAction()
{
    Console.Clear();
    Console.WriteLine("1 - Artikli\n2 - Radnici\n3 - Racuni\n4 - Statistika\n0 - Izlaz iz aplikacije");
    Console.WriteLine("Ako se zelite vratiti na prijasnju stranicu, napisite 'back' u bilo kojem unosu");
    Console.WriteLine("Upisite jedan od brojeva ponudenih");
    if (int.TryParse(Console.ReadLine(), out int choice))
    {
        switch (choice)
        {
            case 1:
                chooseActionArticle();
                break;
            case 2:
                chooseActionWorker();
                break;
            case 3:
                chooseActionBill();
                break;
            case 4:
                statistics();
                break;
            case 0:
                Console.Clear();
                Environment.Exit(0);
                break;
            default:
                Console.Clear();
                Console.WriteLine("1 - Artikli\n2 - Radnici\n3 - Racuni\n4 - Statistika\n0 - Izlaz iz aplikacije");
                chooseAction();
                break;
        }
    }
    else
    {
        Console.Clear();
        Console.WriteLine("1 - Artikli\n2 - Radnici\n3 - Racuni\n4 - Statistika\n0 - Izlaz iz aplikacije");
        chooseAction();
    }
}
void statistics()
{
    Console.Clear();
    Console.WriteLine("1 - Ukupan broj artikala u trgovini\n2 - Vrijednost artikala koji nisu jos prodani\n3 - Brijednost svih artikala koji su prodani\n4 - Stanje po mjesecima");
    Console.WriteLine("Upisite jedan od brojeva ponudenih");
    if (int.TryParse(Console.ReadLine(), out int choice))
    {
        switch (choice)
        {
            case 1:
                Console.WriteLine("Ovo je ukupan broj artikala u trgovini");
                var numberOfArticlesInStore = 0;
                for (int i = 0; i < articleQuantity.Count; i++)
                {
                    numberOfArticlesInStore += articleQuantity[i];
                }
                Console.WriteLine(numberOfArticlesInStore);
                Console.WriteLine("Napisite bilo sto i pritisnite tipku enter kada zelite ici natrag");
                backingUp = Console.ReadLine();
                statistics();
                break;
            case 2:
                Console.WriteLine("Ovo je ukupna vrijednost artikala koji se jos nisu prodali");
                var valueOfArticlesNotSold = 0f;
                for (int i = 0; i < articlePrice.Count; i++)
                {
                    valueOfArticlesNotSold += articlePrice[i] * articleQuantity[i];
                }
                Console.WriteLine(valueOfArticlesNotSold);
                Console.WriteLine("Napisite bilo sto i pritisnite tipku enter kada zelite ici natrag");
                backingUp = Console.ReadLine();
                statistics();
                break;
            case 3:
                Console.WriteLine("Ovo je ukupna vrijednost artikala koji su se prodali");
                Console.WriteLine(valueOfArticlesSold);
                Console.WriteLine("Napisite bilo sto i pritisnite tipku enter kada zelite ici natrag");
                backingUp = Console.ReadLine();
                statistics();
                break;
            case 4:
                Console.Clear();
                Console.WriteLine("Napisite datum koji zelite pogledati (M.D.Y)");
                var dateOfStatString = Console.ReadLine();
                if (DateTime.TryParse(dateOfStatString, out DateTime dateOfStat))
                {
                }
                else
                {
                    statistics();
                }
                Console.WriteLine("Napisite place radnika");
                var valueOfPayWorkersString = Console.ReadLine();
                if (float.TryParse(valueOfPayWorkersString, out float valueOfPayWorkers))
                {
                }
                else
                {
                    statistics();
                }
                Console.WriteLine("Napisite najam");
                var valueOfPayPlaceString = Console.ReadLine();
                if (float.TryParse(valueOfPayPlaceString, out float valueOfPayPlace))
                {
                }
                else
                {
                    statistics();
                }
                Console.WriteLine("Napisite ostale troskove");
                var valueOfPayRestString = Console.ReadLine();
                if (float.TryParse(valueOfPayRestString, out float valueOfPayRest))
                {
                }
                else
                {
                    statistics();
                }
                var earningsInMonth = 0f;
                for(int i = 0; i < listOfBillDates.Count; i++)
                {
                    if (listOfBillDates[i].Month == dateOfStat.Month && listOfBillDates[i].Year == dateOfStat.Year)
                    {
                        earningsInMonth += listOfFinalPrice[i];
                    }
                }
                Console.WriteLine(earningsInMonth);
                Console.WriteLine(valueOfPayWorkers);
                Console.WriteLine(valueOfPayRest);
                decimal finalAmount = 0;
                finalAmount = (((decimal)earningsInMonth * ((decimal)1 / 3)) - (decimal)valueOfPayWorkers) - (decimal)valueOfPayRest;
                Console.WriteLine("Finalni iznos u ovom mjesecu:");
                Console.WriteLine(finalAmount);
                Console.WriteLine("Napisite bilo sto i pritisnite tipku enter kada zelite ici natrag");
                backingUp = Console.ReadLine();
                statistics();
                break;
            default:
                statistics();
                break;
        }
    }else if(choiceString == "back")
    {
        chooseAction();
    }
    else
    {
        statistics();
    }
}
void chooseActionBill()
{
    Console.Clear();
    Console.WriteLine("1 - Unos novog računa\n2 - Ispis");
    var choiceString = Console.ReadLine();
    if (int.TryParse(choiceString, out choice))
    {
        switch (choice)
        {
            case 1:
                addNewBill();
                break;
            case 2:
                printingBill();
                break;
            default:
                chooseActionBill();
                break;
        }
    }
    else if (choiceString == "back")
    {
        chooseAction();
    }
    else
    {
        chooseActionBill();
    }
}
void addNewBill()
{
    Console.Clear();
    for (int i = 0; i < articleName.Count; i++)
    {
        Console.WriteLine($"ime - {articleName[i]} kolicina - {articleQuantity[i]} cijena- {articlePrice[i]} datum isteka- {articleExpirationDate[i]} ");
    }
    Console.WriteLine("Unesite kljucnu rijec 'exit' kada zelite finalizirati racun");
    Console.WriteLine("Unesite ime proizvoda");
    var nameOfArticleBill = Console.ReadLine();
    if (nameOfArticleBill == "exit")
    {
        Console.Clear();
        Console.WriteLine("Na racunu imate:");
        for (int i = 0; i < articleNamesBill.Count; i++)
        {
            Console.WriteLine($"{articleNamesBill[i]} - {articleQuantitiesBill[i]}");
        }
        Console.WriteLine("Za potvrditi racun upisite 'yes' a za ponistiti bilo sto drugo");
        confirmation = Console.ReadLine();
        if (confirmation == "yes")
        {
            Console.WriteLine("Ovo je Vas racun:");
            Console.WriteLine($"ID racuna - {billID}");
            listOfBillID.Add(billID);
            listOfBillDates.Add(DateTime.Now);
            Console.WriteLine($"Vrijeme izdavanja racuna - {listOfBillDates[billID]}");
            Console.WriteLine("Svi proizvodi i ukupna cijena proizvoda");
            finalPrice = 0f;
            for (int i = 0; i < articleName.Count; i++)
            {
                for (int j = 0; j < articleNamesBill.Count; j++)
                {
                    if (articleName[i] == articleNamesBill[j])
                    {
                        listOfArticleBill.Add(articleIndex, new List<dynamic> { articleName[i], articleQuantitiesBill[j] * articlePrice[i] });
                        Console.WriteLine($"{articleName[i]} - {articleQuantitiesBill[j] * articlePrice[i]}");
                        finalPrice += articleQuantitiesBill[j] * articlePrice[i];
                        articleIndex++;
                    }
                }
            }
            listOfArticleByBillID.Add(billID, listOfArticleBill);
            listOfArticleBill = new ();
            articleIndex = 0;
            Console.WriteLine($"Ukupna cijena - {finalPrice}");
            listOfFinalPrice.Add(finalPrice);
            valueOfArticlesSold += finalPrice;
            billID++;
            for (int i = 0; i < articleQuantitiesBill.Count; i++)
            {
                for (int j = 0; j < articleName.Count; j++)
                {
                    if (articleName[j] == articleNamesBill[i])
                    {
                        if (articleQuantity[j] == articleQuantitiesBill[i])
                        {
                            articleName.RemoveAt(j);
                            articlePrice.RemoveAt(j);
                            articleQuantity.RemoveAt(j);
                            articleExpirationDate.RemoveAt(j);
                        }
                    }
                }
                for (int j = 0; j < articleName.Count; j++)
                {
                    if (articleName[j] == articleNamesBill[i])
                    {
                        articleQuantity[j] = articleQuantity[j] - articleQuantitiesBill[i];
                    }
                }
            }
            articleNamesBill = new();
            articleQuantitiesBill = new();
            Console.WriteLine("Napisite bilo sto i pritisnite tipku enter kada zelite ici natrag");
            backingUp = Console.ReadLine();
            chooseActionBill();
        }
        else if(confirmation == "back")
        {
            chooseActionBill();
        }
        else
        {
            articleNamesBill = new();
            articleQuantitiesBill = new();
            chooseActionBill();
        }
    }
    else if(nameOfArticleBill == "back")
    {
        chooseActionBill();
    }
    else
    {
        if (articleNamesBill.Contains(nameOfArticleBill))
        {
            addNewBill();
        }
        if (articleName.Contains(nameOfArticleBill))
        {
            Console.WriteLine("Unesite kolicinu proizvoda");
            var articleQuantityBillString = Console.ReadLine();
            if (articleQuantityBillString == "exit")
            {
                Console.Clear();
                Console.WriteLine("Na racunu imate:");
                for (int i = 0; i < articleNamesBill.Count; i++)
                {
                    Console.WriteLine($"{articleNamesBill[i]} - {articleQuantitiesBill[i]}");
                }
                Console.WriteLine("Za potvrditi racun upisite 'yes' a za ponistiti bilo sto drugo");
                confirmation = Console.ReadLine();
                if (confirmation == "yes")
                {
                    Console.WriteLine("Ovo je Vas racun:");
                    Console.WriteLine($"ID racuna - {billID}");
                    listOfBillDates.Add(DateTime.Now);
                    Console.WriteLine($"Vrijeme izdavanja racuna - {listOfBillDates[billID]}");
                    Console.WriteLine("Svi proizvodi i ukupna cijena proizvoda");
                    float finalPrice = 0f;
                    for (int i = 0; i < articleName.Count; i++)
                    {
                        for (int j = 0; j < articleNamesBill.Count; j++)
                        {
                            if (articleName[i] == articleNamesBill[j])
                            {
                                Console.WriteLine($"{articleName[i]} - {articleQuantitiesBill[j] * articlePrice[i]}");
                                finalPrice += articleQuantitiesBill[j] * articlePrice[i];
                            }
                        }
                    }
                    Console.WriteLine($"Ukupna cijena - {finalPrice}");
                    billID++;
                    for (int i = 0; i < articleQuantitiesBill.Count; i++)
                    {
                        for (int j = 0; j < articleName.Count; j++)
                        {
                            if (articleName[j] == articleNamesBill[i])
                            {
                                if (articleQuantity[j] == articleQuantitiesBill[i])
                                {
                                    articleName.RemoveAt(j);
                                    articlePrice.RemoveAt(j);
                                    articleQuantity.RemoveAt(j);
                                    articleExpirationDate.RemoveAt(j);
                                }
                            }
                        }
                        for (int j = 0; j < articleName.Count; j++)
                        {
                            if (articleName[j] == articleNamesBill[i])
                            {
                                articleQuantity[j] = articleQuantity[j] - articleQuantitiesBill[i];
                            }
                        }
                    }
                    articleNamesBill = new();
                    articleQuantitiesBill = new();
                    Console.WriteLine("Napisite bilo sto i pritisnite tipku enter kada zelite ici natrag");
                    backingUp = Console.ReadLine();
                    chooseActionBill();
                }
                else if (confirmation == "back")
                {
                    chooseActionBill();
                }
                else
                {
                    articleNamesBill = new();
                    articleQuantitiesBill = new();
                    chooseActionBill();
                }
            }
            else if (articleQuantityBillString == "back")
            {
                chooseActionBill();
            }
            else
            {
                if (int.TryParse(articleQuantityBillString, out articleQuantityBill))
                {
                    for (int i = 0; i < articleName.Count; i++)
                    {
                        if (articleName[i] == nameOfArticleBill)
                        {
                            if (articleQuantityBill > articleQuantity[i])
                            {
                                addNewBill();
                            }
                            else
                            {
                            }
                        }
                    }
                    articleNamesBill.Add(nameOfArticleBill);
                    articleQuantitiesBill.Add(articleQuantityBill);
                    addNewBill();
                }
                else
                {
                    addNewBill();
                }
            }
        }
        else
        {
            addNewBill();
        }
    }
}
void printingBill()
{
    Console.Clear();
    Console.WriteLine("Ovo su svi vaši računi");
    for (int i = 0; i < listOfBillID.Count; i++)
    {
        Console.WriteLine($"ID - {listOfBillID[i]} datum iznosa - {listOfBillDates[i]} ukupna cijena - {listOfFinalPrice[i]} ");
    }
    Console.WriteLine("Odaberite koji račun želite vidjeti detaljnije");
    var choiceString = Console.ReadLine();
    if (int.TryParse(choiceString, out int choice))
    {
        for (int i = 0; i < listOfBillID.Count; i++)
        {
            if (choice == listOfBillID[i])
            {
                Console.WriteLine($"ID - {listOfBillID[i]}");
                Console.WriteLine($"Datum iznosa - {listOfBillDates[i]}");

                foreach (var outerKvp in listOfArticleByBillID)
                {
                    int outerKey = outerKvp.Key;

                    if (outerKey == choice)
                    {
                        Dictionary<int, List<object>> innerDictionary = outerKvp.Value;

                        foreach (var innerKvp in innerDictionary)
                        {
                            int innerKey = innerKvp.Key;
                            List<object> innerValue = innerKvp.Value;
                            string nameOfIndividualArticle = innerValue[0] as string;
                            float priceOfIndividualArticle = (float)innerValue[1];
                            Console.WriteLine($"{outerKey} - {innerKey} - {nameOfIndividualArticle} - {priceOfIndividualArticle}");
                        }
                        break;
                    }
                }

                Console.WriteLine("Napišite bilo što i pritisnite tipku Enter kada želite ići natrag");
                backingUp = Console.ReadLine();
                chooseActionBill();
                break;
            }
        }
    }else if(choiceString == "back")
    {
        chooseActionBill();
    }
    else
    {
        printingBill();
    }
}

void addNewWorkerName()
{
    Console.Clear();
    Console.WriteLine("Unesite ime i prezime radnika");
    workerName = Console.ReadLine();
    if (workerName == "back")
    {
        chooseActionWorker();
    }
    else
    {
    }
}
void addNewWorker()
{
    Console.Clear();
    addNewWorkerName();
    addNewWorkerDOB();
}
void addNewWorkerDOB()
{
    Console.WriteLine($"Unesite datum rodenja radnika {workerName}");
    var DOBOfArticleString = Console.ReadLine();
    CultureInfo culture = new CultureInfo("en-GB");
    if (DateTime.TryParse(DOBOfArticleString, culture, DateTimeStyles.None, out workerDOB))
    {
        Console.WriteLine("Jeste li sigurni da zelite pohraniti promjene u sustav? Unesite 'yes' ili 'no'");
    }
    else if (DOBOfArticleString == "back")
    {
        chooseActionWorker();
    }
    else
    {
        Console.Clear();
        Console.WriteLine("Unesite ime radnika");
        Console.WriteLine(workerName);
        addNewWorkerDOB();
    }
    confirmation = Console.ReadLine();
    if (confirmation == "yes")
    {
        listOfWorkerName.Add(workerName);
        listOfWorkerDOB.Add(workerDOB);
        chooseActionWorker();
    }
    else if(confirmation == "back")
    {
        chooseActionWorker();
    }
    else
    {
        addNewWorker();
    }
}
void chooseActionWorker()
{
    Console.Clear();
    Console.WriteLine("1 - Unos radnika\n2 - Brisanje radnika\n3 - Uredivanje radnika\n4 - Ispis");
    Console.WriteLine("Odaberite jedan of ponudenih opcija");
    var choiceString = Console.ReadLine();
    if (int.TryParse(choiceString, out choice))
    {
        switch (choice)
        {
            case 1:
                addNewWorker();
                break;
            case 2:
                removeWorker();
                break;
            case 3:
                arrangementOfWorkers();
                break;
            case 4:
                printingOfWorkers();
                break;
            default:
                chooseActionArticle();
                break;
        }
    }
    else if (choiceString == "back")
    {
        chooseAction();
    }
    else
    {
        chooseActionArticle();
    }
}
void printingOfWorkers()
{
    Console.Clear();
    Console.WriteLine("Popis:");
    Console.WriteLine("1 - Svih radnika kako su spremljeni\n2 - Svih radnika kojima je rodendan u tekucem mjesecu");
    var choiceString = Console.ReadLine();
    if (int.TryParse(choiceString, out choice))
    {
        switch (choice)
        {
            case 1:
                Console.Clear();
                for (int i = 0; i < listOfWorkerName.Count; i++)
                {
                    Console.WriteLine($"{i} - ime: {listOfWorkerName[i]} Datum rodenja - {listOfWorkerDOB[i]}");
                }
                Console.WriteLine("Napisite bilo sto i pritisnite tipku enter kada zelite ici natrag");
                backingUp = Console.ReadLine();
                printingOfWorkers();
                break;
            case 2:
                Console.Clear();
                for (int i = listOfWorkerDOB.Count - 1; i >= 0; i--)
                {
                    if (listOfWorkerDOB[i].Month == DateTime.Now.Month)
                    {
                        Console.WriteLine($"{i} - ime: {listOfWorkerName[i]} Datum rodenja - {listOfWorkerDOB[i]}");
                    }
                }
                Console.WriteLine("Napisite bilo sto i pritisnite tipku enter kada zelite ici natrag");
                backingUp = Console.ReadLine();
                printingOfWorkers();
                break;
            default:
                chooseActionWorker();
                break;
        }
    }
    else if (choiceString == "back")
    {
        chooseActionWorker();
    }
    else
    {
        printingOfWorkers();
    }
}
void arrangementOfWorkers()
{
    Console.Clear();
    Console.WriteLine("Ovo su svi vasi radnici");
    for (int i = 0; i < listOfWorkerName.Count; i++)
    {
        Console.WriteLine($"Ime - {listOfWorkerName[i]} Datum rodenja - {listOfWorkerDOB[i]}");
    }
    Console.WriteLine("Odaberite kojeg radnika zelite promijeniti");
    var workerToChange = Console.ReadLine(); 
    if(workerToChange == "back")
    {
        chooseActionWorker();
    }
    if (listOfWorkerName.Contains(workerToChange))
    {
        Console.Clear();
        for (int i = 0; i < listOfWorkerName.Count; i++)
        {
            if (listOfWorkerName[i] == workerToChange)
            {
                Console.WriteLine($"Ime - {listOfWorkerName[i]} Datum rodenja - {listOfWorkerDOB[i]}");
                Console.WriteLine($"Odaberite sto zelite promijeniti\n1 - ime\n2 - Datum rodenja");
                choiceString = Console.ReadLine();
                if (int.TryParse(choiceString, out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            Console.Clear();
                            Console.WriteLine("Napisite novo ime");
                            var newWorkerName = Console.ReadLine();
                            if (newWorkerName != "back")
                            {
                                Console.WriteLine("Are you sure that you want to continue('yes')?");
                                confirmation = Console.ReadLine();
                                if (confirmation != "yes")
                                {
                                    listOfArticleBill = new();
                                    chooseActionWorker();
                                }
                                listOfWorkerName[i] = newWorkerName;
                                chooseActionWorker();
                            }
                            else
                            {
                                arrangementOfWorkers();
                            }
                            break;
                        case 2:
                            Console.Clear();
                            Console.WriteLine("Napisite novi datum rodenja");
                            var newWorkerDOBString = Console.ReadLine();
                            if (newWorkerDOBString != "back")
                            {
                                if (DateTime.TryParse(newWorkerDOBString, out DateTime newWorkerDOB))
                                {
                                    Console.WriteLine("Are you sure that you want to continue('yes')?");
                                    confirmation = Console.ReadLine();
                                    if (confirmation != "yes")
                                    {
                                        listOfArticleBill = new();
                                        chooseActionWorker();
                                    }
                                    listOfWorkerDOB[i] = newWorkerDOB;
                                    chooseActionWorker();
                                }
                                else
                                {
                                    arrangementOfWorkers();
                                }
                            }
                            else
                            {
                                arrangementOfWorkers();
                            }
                            break;
                        default:
                            arrangementOfWorkers();
                            break;
                    }
                }
                else if(choiceString == "back")
                {
                    arrangementOfWorkers();
                }
                else
                {
                    arrangementOfWorkers();
                }
            }
        }
    }
    else
    {
        arrangementOfWorkers();
    }
}
void removeWorker()
{
    Console.Clear();
    Console.WriteLine("1 - Brisanje radnika po imenu\n2 - Brisanje svih radnika koji imaju vise od 65 godina");
    var choiceString = Console.ReadLine();
    if (int.TryParse(choiceString, out choice))
    {
        switch (choice)
        {
            case 1:
                removeWorkerByName();
                break;
            case 2:
                removeWorkerByAge();
                break;
            default:
                chooseActionArticle();
                break;
        }
    }
    else if (choiceString == "back")
    {
        chooseActionWorker();
    }
    else
    {
        removeWorker();
    }
}
void removeWorkerByAge()
{
    Console.Clear();
    Console.WriteLine("Ovo su svi vasi radnici prije brisanja");
    foreach (var item in listOfWorkerName)
    {
        Console.WriteLine(item);
    }
    Console.WriteLine("Ovo su vasi radnici koji ce se izbrisati");
    for (int i = 0; i < listOfWorkerDOB.Count; i++)
    {
        if (listOfWorkerDOB[i] < DateTime.Now.AddYears(-65))
        {
            Console.WriteLine(listOfWorkerName[i]);
        }
    }
    Console.WriteLine("Jeste li sigurni da zelite izbrisati sve artikle kojima je prosao rok trajanja? Upisite 'yes' ili 'no'");
    confirmation = Console.ReadLine();
    if (confirmation == "yes")
    {
        Console.WriteLine("count: " + listOfWorkerDOB.Count);
        for (int i = listOfWorkerDOB.Count - 1; i >= 0; i--)
        {
            if (listOfWorkerDOB[i] < DateTime.Now.AddYears(-65))
            {
                listOfWorkerDOB.RemoveAt(i);
                listOfWorkerName.RemoveAt(i);
            }
        }
    }
    else if (confirmation == "back")
    {
        chooseActionWorker();
    }
    else
    {
        chooseActionWorker();
    }
    chooseActionWorker();
}
void removeWorkerByName()
{
    Console.Clear();
    Console.WriteLine("Ovo su svi vasi radnici");
    foreach (var item in listOfWorkerName)
    {
        Console.WriteLine(item);
    }
    Console.WriteLine("Odaberite kojeg radnika zelite izbrisati");
    var removeWorkerString = Console.ReadLine();
    if (removeWorkerString == "back")
    {
        chooseActionWorker();
    }
    else if (listOfWorkerName.Contains(removeWorkerString))
    {
        Console.WriteLine("Are you sure that you want to continue('yes')?");
        confirmation = Console.ReadLine();
        if (confirmation != "yes")
        {
            listOfArticleBill = new();
            chooseActionWorker();
        }
        for (int i = 0; i < listOfWorkerName.Count; i++)
        {
            if (listOfWorkerName[i] == removeWorkerString)
            {
                listOfWorkerDOB.RemoveAt(i);
                listOfWorkerName.RemoveAt(i);
            }
        }
    }
    else
    {
        removeWorkerByName();
    }
    chooseActionWorker();
}
void chooseActionArticle()
{
    Console.Clear();
    Console.WriteLine("1 - Unos artikla\n2 - Brisanje artikla\n3 - Uredivanje artikla\n4 - Ispis");
    Console.WriteLine("Odaberite jedan of ponudenih opcija");
    var choiceString = Console.ReadLine();
    if (int.TryParse(choiceString, out choice))
    {
        switch (choice)
        {
            case 1:
                addNewArticle();
                break;
            case 2:
                removeArticle();
                break;
            case 3:
                arrangementOfArticles();
                break;
            case 4:
                printingOfArticles();
                break;
            default:
                chooseActionArticle();
                break;
        }
    }
    else if (choiceString == "back")
    {
        chooseAction();
    }
    else
    {
        chooseActionArticle();
    }
}
void printingOfArticles()
{
    Console.Clear();
    Console.WriteLine("Popis:");
    Console.WriteLine("1 - Svih artikala kako su spremljeni\n2 - Svih artikala sortiranih po imenu\n3 - Svih artikala sortiranih po datumu silazno\n4 - Svih artikala sortiranih po datumu uzlazno\n5 - Svih artikala sortiranih po kolicini\n6 - Najprodavaniji artikal\n7 - Najmanje prodavan artikal");
    var choiceString = Console.ReadLine();
    if (int.TryParse(choiceString, out choice))
    {
        switch (choice)
        {
            case 1:
                Console.Clear();
                for (int i = 0; i < articleName.Count; i++)
                {
                    Console.WriteLine($"{i} - ime: {articleName[i]} kolicina: {articleQuantity[i]} cijena: {articlePrice[i]}EURA datum isteka: {articleExpirationDate[i]}");
                }
                Console.WriteLine("Napisite bilo sto i pritisnite tipku enter kada zelite ici natrag");
                backingUp = Console.ReadLine();
                printingOfArticles();
                break;
            case 2:
                Console.Clear();
                List<string> listOfSortedArticleName = new();
                listOfSortedArticleName = articleName.OrderBy(name => name).ToList();
                for (int i = 0; i < articleName.Count; i++)
                {
                    for (int j = 0; j < listOfSortedArticleName.Count; j++)
                    {
                        if (listOfSortedArticleName[i] == articleName[j])
                        {
                            Console.WriteLine($"{i} - ime: {articleName[j]} kolicina: {articleQuantity[j]} cijena: {articlePrice[j]} datum isteka: {articleExpirationDate[j]}");
                        }
                    }
                }
                Console.WriteLine("Napisite bilo sto i pritisnite tipku enter kada zelite ici natrag");
                backingUp = Console.ReadLine();
                printingOfArticles();
                break;
            case 3:
                List<DateTime> listOfSortedArticleExpirationDates = new();
                listOfSortedArticleExpirationDates = articleExpirationDate.OrderBy(date => date).ToList();
                Console.Clear();
                for (int i = 0; i < articleExpirationDate.Count; i++)
                {
                    for (int j = 0; j < articleExpirationDate.Count; j++)
                    {
                        if (listOfSortedArticleExpirationDates[i] == articleExpirationDate[j])
                        {
                            Console.WriteLine($"{i} - ime: {articleName[j]} kolicina: {articleQuantity[j]} cijena: {articlePrice[j]} datum isteka: {articleExpirationDate[j]}");
                        }
                    }
                }
                Console.WriteLine("Napisite bilo sto i pritisnite tipku enter kada zelite ici natrag");
                backingUp = Console.ReadLine();
                printingOfArticles();
                break;
            case 4:
                listOfSortedArticleExpirationDates = articleExpirationDate.OrderByDescending(date => date).ToList();
                Console.Clear();
                for (int i = 0; i < articleExpirationDate.Count; i++)
                {
                    for (int j = 0; j < articleExpirationDate.Count; j++)
                    {
                        if (listOfSortedArticleExpirationDates[i] == articleExpirationDate[j])
                        {
                            Console.WriteLine($"{i} - ime: {articleName[j]} kolicina: {articleQuantity[j]} cijena: {articlePrice[j]} datum isteka: {articleExpirationDate[j]}");
                        }
                    }
                }
                Console.WriteLine("Napisite bilo sto i pritisnite tipku enter kada zelite ici natrag");
                backingUp = Console.ReadLine();
                printingOfArticles();
                break;
            case 5:
                List<int> listOfSortedArticleQuantities = new List<int>(articleQuantity);
                listOfSortedArticleQuantities.Sort();
                listOfSortedArticleQuantities.Reverse();
                Console.Clear();
                for (int i = 0; i < listOfSortedArticleQuantities.Count; i++)
                {
                    for (int j = 0; j < articleQuantity.Count; j++)
                    {
                        if (listOfSortedArticleQuantities[i] == articleQuantity[j])
                        {
                            Console.WriteLine($"{i} - ime: {articleName[j]} kolicina: {articleQuantity[j]} cijena: {articlePrice[j]} datum isteka: {articleExpirationDate[j]}");
                        }
                    }
                }
                Console.WriteLine("Napisite bilo sto i pritisnite tipku enter kada zelite ici natrag");
                backingUp = Console.ReadLine();
                printingOfArticles();
                break;
            case 6:
                Console.Clear();
                var mostSoldArticle = 0;
                    for (int j = 1; j < listOfArticlesSold.Count; j++)
                    {
                        if (listOfArticlesSold[j] > listOfArticlesSold[j- 1])
                        {
                            mostSoldArticle = j;
                        }
                    }
                Console.WriteLine($"ime: {articleName[mostSoldArticle]} kolicina: {articleQuantity[mostSoldArticle]} cijena: {articlePrice[mostSoldArticle]} datum isteka: {articleExpirationDate[mostSoldArticle]}");
                Console.WriteLine($"prodalo se {listOfArticlesSold[mostSoldArticle]} tog artikla");
                Console.WriteLine("Napisite bilo sto i pritisnite tipku enter kada zelite ici natrag");
                backingUp = Console.ReadLine();
                printingOfArticles();
                break;
            case 7:
                Console.Clear();
                var leastSoldArticle = 0;
                for (int j = 1; j < listOfArticlesSold.Count; j++)
                {
                    if (listOfArticlesSold[j] < listOfArticlesSold[j - 1])
                    {
                        leastSoldArticle = j;
                    }
                }
                Console.WriteLine($"ime: {articleName[leastSoldArticle]} kolicina: {articleQuantity[leastSoldArticle]} cijena: {articlePrice[leastSoldArticle]} datum isteka: {articleExpirationDate[leastSoldArticle]}");
                Console.WriteLine($"prodalo se {listOfArticlesSold[leastSoldArticle]} tog artikla");
                Console.WriteLine("Napisite bilo sto i pritisnite tipku enter kada zelite ici natrag");
                backingUp = Console.ReadLine();
                printingOfArticles();
                break;
            default:
                chooseActionArticle();
                break;
        }
    }
    else if (choiceString == "back")
    {
        chooseActionArticle();
    }
    else
    {
        printingOfArticles();
    }
}
void removeArticle()
{
    Console.Clear();
    Console.WriteLine("1 - Brisanje artikala po imenu\n2 - Brisanje svih artikala kojima je rok trajanja prosao");
    var choiceString = Console.ReadLine();
    if (int.TryParse(choiceString, out choice))
    {
        switch (choice)
        {
            case 1:
                removeArticleByName();
                break;
            case 2:
                removeArticleByExpirationDate();
                break;
            default:
                chooseActionArticle();
                break;
        }
    }
    else if (choiceString == "back")
    {
        chooseActionArticle();
    }
    else
    {
        removeArticle();
    }
}
void chooseNameOfArticle()
{
    Console.Clear();
    Console.WriteLine("Unesite ime artikla");
    nameOfArticle = Console.ReadLine();
    if (nameOfArticle != "back")
    {
    }
    else
    {
        chooseActionArticle();
    }
}
void chooseQuantityOfArticle()
{
    Console.WriteLine($"Unesite kolicinu artikla {nameOfArticle}");
    string quantityOfArticleString = Console.ReadLine();
    if (int.TryParse(quantityOfArticleString, out quantityOfArticle))
    {
    }
    else if (quantityOfArticleString == "back")
    {
        chooseAction();
    }
    else
    {
        Console.Clear();
        Console.WriteLine("Unesite ime artikla");
        Console.WriteLine(nameOfArticle);
        chooseQuantityOfArticle();
    }
}
void choosePriceOfArticle()
{
    Console.WriteLine($"Unesite cijenu artikla {nameOfArticle} u eurima");
    string priceOfArticleString = Console.ReadLine();
    if (float.TryParse(priceOfArticleString, out priceOfArticle))
    {
    }
    else if (priceOfArticleString == "back")
    {
        chooseAction();
    }
    else
    {
        Console.Clear();
        Console.WriteLine("Unesite ime artikla");
        Console.WriteLine(nameOfArticle);
        Console.WriteLine($"Unesite kolicinu artikla {nameOfArticle}");
        Console.WriteLine(quantityOfArticle);
        choosePriceOfArticle();
    }
}
void chooseDateOfExpirationOfArticle()
{
    Console.WriteLine($"Unesite datum isteka artikla {nameOfArticle}");
    var DateOfExpirationOfArticleString = Console.ReadLine();
    CultureInfo culture = new CultureInfo("en-GB");
    if (DateTime.TryParse(DateOfExpirationOfArticleString, culture, DateTimeStyles.None, out DateOfExpirationOfArticle))
    {
        Console.WriteLine("Jeste li sigurni da zelite pohraniti promjene u sustav? Unesite 'yes' ili 'no'");
    }
    else if (DateOfExpirationOfArticleString == "back")
    {
        chooseAction();
    }
    else
    {
        Console.Clear();
        Console.WriteLine("Unesite ime artikla");
        Console.WriteLine(nameOfArticle);
        Console.WriteLine($"Unesite kolicinu artikla {nameOfArticle}");
        Console.WriteLine(quantityOfArticle);
        Console.WriteLine($"Unesite cijenu artikla {nameOfArticle} u eurima");
        Console.WriteLine(priceOfArticle);
        chooseDateOfExpirationOfArticle();
    }
    confirmation = Console.ReadLine();
    if (confirmation == "yes")
    {
        articleName.Add(nameOfArticle);
        articleQuantity.Add(quantityOfArticle);
        articlePrice.Add(priceOfArticle);
        articleExpirationDate.Add(DateOfExpirationOfArticle);
    }
    else if (confirmation == "back")
    {
        chooseActionArticle();
    }
    else
    {
        addNewArticle();
    }
}
void removeArticleByExpirationDate()
{
    Console.Clear();
    Console.WriteLine("Ovo su svi vasi artikli prije brisanja");
    foreach (var item in articleName)
    {
        Console.WriteLine(item);
    }
    Console.WriteLine("Ovo su vasi artikli koji ce se izbrisati");
    for (int i = 0; i < articleExpirationDate.Count; i++)
    {
        if (articleExpirationDate[i] > DateTime.Now)
        {
            Console.WriteLine(articleName[i]);
        }
    }
    Console.WriteLine("Jeste li sigurni da zelite izbrisati sve artikle kojima je prosao rok trajanja? Upisite 'yes' ili 'no'");
    confirmation = Console.ReadLine();
    if (confirmation == "yes")
    {
        for (int i = 0; i < articleExpirationDate.Count; i++)
        {
            if (articleExpirationDate[i] > DateTime.Now)
            {
                articleName.RemoveAt(i);
                articleQuantity.RemoveAt(i);
                articlePrice.RemoveAt(i);
                articleExpirationDate.RemoveAt(i);
            }
        }
    }
    else if (confirmation == "back")
    {
        removeArticle();
    }
    else
    {
        chooseActionArticle();
    }
}
void removeArticleByName()
{
    Console.Clear();
    Console.WriteLine("Ovo su svi vasi artikli");
    foreach (var item in articleName)
    {
        Console.WriteLine(item);
    }
    Console.WriteLine("Odaberite koji artikal zelite izbrisati");
    var removeArticleString = Console.ReadLine();
    if (removeArticleString == "back")
    {
        chooseActionArticle();
    }
    else if (articleName.Contains(removeArticleString))
    {
        Console.WriteLine("Are you sure that you want to continue('yes')?");
        confirmation = Console.ReadLine();
        if (confirmation != "yes")
        {
            removeArticleByName();
        }
        for (int i = 0; i < articleExpirationDate.Count; i++)
        {
            if (articleName[i] == removeArticleString)
            {
                articleName.RemoveAt(i);
                articleQuantity.RemoveAt(i);
                articlePrice.RemoveAt(i);
                articleExpirationDate.RemoveAt(i);
            }
        }
    }
    else
    {
        removeArticleByName();
    }
    chooseActionArticle();
}

void addNewArticle()
{
    Console.Clear();
    chooseNameOfArticle();
    chooseQuantityOfArticle();
    choosePriceOfArticle();
    chooseDateOfExpirationOfArticle();
    chooseActionArticle();
}
void arrangementOfArticles()
{
    Console.Clear();
    Console.WriteLine("1 - Uredivanje zasebnih proizvoda\n2 - Popust/poskupljenje na sve proizvode unutar trgovine");
    choiceString = Console.ReadLine();
    if (int.TryParse(choiceString, out int choice))
    {
        switch (choice)
        {
            case 1:
                arrangementOfOneArticle();
                break;
            case 2:
                arrangementOfAllArticles();
                break;
            default:
                arrangementOfArticles();
                break;
        }
    }
    else if (choiceString == "back")
    {
        chooseActionArticle();
    }
    else
    {
        arrangementOfAllArticles();
    }
}
void arrangementOfAllArticles()
{
    Console.Clear();
    Console.WriteLine("Zelite li 'poskupiti' ili 'pojeftiniti' proizvode");
    choiceString = Console.ReadLine();
    if (choiceString == "poskupiti")
    {
        Console.WriteLine("Ovo su svi vasi proizvodi");
        for (int i = 0; i < articleName.Count; i++)
        {
            Console.WriteLine($"ime: {articleName[i]} kolicina: {articleQuantity[i]} cijena: {articlePrice[i]}EURA datum isteka: {articleExpirationDate[i]}");
        }
        Console.WriteLine("Za koliko zelite poskupiti proizvode? Upisite samo broj od 1 - 100 oznacavajuci postotak poskupljenja bez znaka '%'");
        priceIncreaseString = Console.ReadLine();
        if (int.TryParse(priceIncreaseString, out priceIncrease))
        {
            for (int i = 0; i < articlePrice.Count; i++)
            {
                articlePrice[i] += articlePrice[i] * ((float)priceIncrease / 100);
            }
            arrangementOfArticles();
        }
        else if (priceIncreaseString == "back")
        {
            arrangementOfArticles();
        }
        else
        {
            arrangementOfArticles();
        }
    }
    else if (choiceString == "pojeftiniti")
    {
        Console.WriteLine("Ovo su svi vasi proizvodi");
        for (int i = 0; i < articleName.Count; i++)
        {
            Console.WriteLine($"ime: {articleName[i]} kolicina: {articleQuantity[i]} cijena: {articlePrice[i]}EURA datum isteka: {articleExpirationDate[i]}");
        }
        Console.WriteLine("Za koliko zelite pojeftiniti proizvode? Upisite samo broj od 1 - 100 oznacavajuci postotak pojeftinjenja bez znaka '%'");
        priceReductionString = Console.ReadLine();
        if (int.TryParse(priceReductionString, out priceReduction))
        {
            for (int i = 0; i < articlePrice.Count; i++)
            {
                articlePrice[i] -= articlePrice[i] * ((float)priceReduction / 100);
            }
            arrangementOfArticles();

        }
        else if (priceReductionString == "back")
        {
            arrangementOfArticles();
        }
        else
        {
            arrangementOfArticles();
        }
    }
    else if (choiceString == "back")
    {
        arrangementOfArticles();
    }
    else
    {
        arrangementOfAllArticles();
    }
}
void arrangementOfOneArticle()
{
    Console.Clear();
    Console.WriteLine("Ovo su svi vasi proizvodi");
    for (int i = 0; i < articleName.Count; i++)
    {
        Console.WriteLine($"ime: {articleName[i]} kolicina: {articleQuantity[i]} cijena: {articlePrice[i]}EURA datum isteka: {articleExpirationDate[i]}");
    }
    Console.WriteLine("Odaberite koji proizvod zelite promijeniti");
    var articleToChange = Console.ReadLine();
    if (articleName.Contains(articleToChange))
    {
        Console.Clear();
        for (int i = 0; i < articleName.Count; i++)
        {
            if (articleName[i] == articleToChange)
            {
                Console.WriteLine($"Odaberite sto zelite promijeniti\n1 - Ime({articleName[i]})\n2 - Kolicinu({articleQuantity[i]})\n3 - Cijenu({articlePrice[i]})\n4 - DatumIsteka({articleExpirationDate[i]})");
                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            Console.Clear();
                            Console.WriteLine("Napisite novo ime");
                            var newArticleName = Console.ReadLine();
                            if (newArticleName != "back")
                            {
                                Console.WriteLine("Are you sure that you want to continue('yes')?");
                                confirmation = Console.ReadLine();
                                if (confirmation != "yes")
                                {
                                    listOfArticleBill = new();
                                    chooseActionArticle();
                                }
                                articleName[i] = newArticleName;
                                chooseActionArticle();
                            }
                            else
                            {
                                arrangementOfArticles();
                            }
                            break;
                        case 2:
                            Console.Clear();
                            Console.WriteLine("Napisite novu kolicinu");
                            var newArticleQuantityString = Console.ReadLine();
                            if (newArticleQuantityString != "back")
                            {
                                if (int.TryParse(newArticleQuantityString, out int newArticleQuantity))
                                {
                                    Console.WriteLine("Are you sure that you want to continue('yes')?");
                                    confirmation = Console.ReadLine();
                                    if (confirmation != "yes")
                                    {
                                        listOfArticleBill = new();
                                        chooseActionArticle();
                                    }
                                    if (newArticleQuantity == 0)
                                    {
                                        articleName.RemoveAt(i);
                                        articlePrice.RemoveAt(i);
                                        articleQuantity.RemoveAt(i);
                                        articleExpirationDate.RemoveAt(i);
                                        chooseActionArticle();
                                    }
                                    else {
                                    if (listOfArticlesSold.Count < articleQuantity.Count)
                                    {
                                        for (int j= 0; j < (articleQuantity.Count - listOfArticlesSold.Count) + 2; j++)
                                        {
                                            listOfArticlesSold.Add(0);
                                        }
                                    }
                                    listOfArticlesSold[i] = articleQuantity[i] - newArticleQuantity;
                                    articleQuantity[i] = newArticleQuantity;
                                    chooseActionArticle();
                                }
                                }
                                else
                                {
                                    arrangementOfOneArticle();
                                }
                            }
                            else
                            {
                                arrangementOfArticles();
                            }
                            break;
                        case 3:
                            Console.Clear();
                            Console.WriteLine("Napisite novu cijenu");
                            var newArticlePriceString = Console.ReadLine();
                            if (newArticlePriceString != "back")
                            {

                                if (float.TryParse(newArticlePriceString, out float newArticlePrice))
                                {
                                    Console.WriteLine("Are you sure that you want to continue('yes')?");
                                    confirmation = Console.ReadLine();
                                    if (confirmation != "yes")
                                    {
                                        listOfArticleBill = new();
                                        chooseActionArticle();
                                    }
                                    articlePrice[i] = newArticlePrice;
                                    chooseActionArticle();
                                }
                                else
                                {
                                    arrangementOfOneArticle();
                                }
                            }
                            else
                            {
                                arrangementOfArticles();
                            }
                            break;
                        case 4:
                            Console.Clear();
                            Console.WriteLine("Napisite novi datum isteka");
                            var newArticleExpirationDateString = Console.ReadLine();
                            if (newArticleExpirationDateString != "back")
                            {
                                if (DateTime.TryParse(newArticleExpirationDateString, out DateTime newArticleExpirationDate))
                                {
                                    Console.WriteLine("Are you sure that you want to continue('yes')?");
                                    confirmation = Console.ReadLine();
                                    if (confirmation != "yes")
                                    {
                                        listOfArticleBill = new();
                                        chooseActionArticle();
                                    }
                                    articleExpirationDate[i] = newArticleExpirationDate;
                                    chooseActionArticle();
                                }
                                else
                                {
                                    arrangementOfOneArticle();
                                }
                            }
                            else
                            {
                                arrangementOfArticles();
                            }
                            break;
                        default:
                            arrangementOfOneArticle();
                            break;
                    }
                }
                else
                {
                    arrangementOfOneArticle();
                }
            }
        }
    }
    else if (articleToChange == "back")
    {
        arrangementOfArticles();
    }
    else
    {
        arrangementOfAllArticles();
    }
}
chooseAction();