using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using static System.Console;

namespace VendingMachine
{
    public class VendingMachine : IVending
    {
        private List<BaseProduct> productsList = new List<BaseProduct>();
        private readonly int[] denomination = { 1, 5, 10, 20, 50, 100, 500, 1000 };
        private int  moneyPool = 0;



        public void LoadProducts()
        {
            productsList.Add(new DrinkProducts("Öl", 100));
            productsList.Add(new DrinkProducts("Julmust", 50));
            productsList.Add(new CandyProducts("Chocklad", 10));
            productsList.Add(new CandyProducts("Sega råttor", 2));
            productsList.Add(new FruitProduct("banan", 1));
            productsList.Add(new FruitProduct("Kiwi", 1000));

        }

        public void WriteStartinfo()
        {
            WriteLine("*************************************************");
            WriteLine("Ange vad du vill göra");
            WriteLine("Tryck 1 för att sätta in pengar");
            WriteLine("Tryck 2 för att handla");
            WriteLine("Tryck 3 för att få tillbaka växeln");
            WriteLine("Tryck 4 för att visa alla produkter");
            WriteLine("Tryck -1 för att avsluta programmet");
        }


        public void Run()
        {
            bool keepOnRunning = true;
            LoadProducts();
            WriteLine("Välkommen till växelmaskinen");

            while (keepOnRunning)
            {
                WriteStartinfo();
                try
                {
                    switch (Int32.Parse(ReadLine()))
                    {
                        case 1:
                            InsertMoney();
                            break;
                        case 2:
                            Purchase();
                            break;
                        case 3:
                            EndTransaction();
                            break;
                        case 4:
                            ShowAll();
                            break;
                        case -1:
                            System.Environment.Exit(1);
                            break;
                        default:
                            WriteLine("Felaktigt val");
                            break;
                    }
                }
                catch (Exception)
                {
                    WriteLine("Felaktigt val");
                }
            }
        }



       public bool ValidDenomination(int money)
        {
            if (denomination.Contains(money))
                return true;
            else
                return false;
        }


        public void EndTransaction()
        {
            WriteLine("Utväxling utav kontanter");
            for (int i = denomination.Length-1; i > -1; i--)
            {
                int nrOfDenom = moneyPool / (int)denomination[i];
                WriteLine("Antal:" + denomination[i] + "=" + nrOfDenom);
                if(nrOfDenom >0)
                    moneyPool %= (int)denomination[i];
            }

            moneyPool = 0;

        }

        public void InsertMoney()
        {
            int money = 0;
            try
            {
                WriteLine("Ange belopp på dina kontanter");
                money = Int32.Parse(ReadLine());
            }
            catch (Exception)
            {
                WriteLine("Felaktigt format, endast heltaal");
            }
            if (ValidDenomination(money))
                moneyPool += money;
            else
                WriteLine("Felaktig valör");

            WriteLine("Totalt beloppp på kontot: " + moneyPool);
        }

        public void Purchase()
        {
            ShowAll();
            WriteLine("Ange ID för produkten som du vill köpa");
            try
            {
                int id = Int32.Parse(ReadLine());
                BaseProduct bp =   productsList.Find(f => f.GetId() == id);
                if (bp.GetPrice() > moneyPool)
                    WriteLine("Sorry du har inte råd");
                else 
                {
                    moneyPool -= bp.GetPrice();
                    WriteLine(bp.Usage());
                    WriteLine("Du har " + moneyPool + "kr kvar att handla för");
                }
            }
            catch (Exception)
            {

                WriteLine("Felaktigt val");
            }

        }

        public void ShowAll()
        {
            foreach (var item in productsList)
            {
                WriteLine(item);
            }
        }
    }
}
