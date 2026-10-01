namespace Bankkonto_Simulering;

public class MenuHelper
{
    private int saldo = 0;

    public void Showmenu()
    {
        bool körs = true;

        while (körs)
        {
            Console.WriteLine();
            Console.WriteLine("Välkommen till bankkontot!");
            Console.WriteLine("Välj ett alternativ:");
            Console.WriteLine("1. Insättning");
            Console.WriteLine("2. Uttag");
            Console.WriteLine("3. Saldo");
            Console.WriteLine("4. Avsluta");

            string choice = Console.ReadLine() ?? "";

            switch (choice)
            {
                case "1":
                    Insättning();
                    break;
                case "2":
                    Uttag();
                    break;
                case "3":
                    VisaSaldo();
                    break;
                case "4":
                    Console.WriteLine("Avslutar...");
                    körs = false;
                    break;
                default:
                    Console.WriteLine("Ogiltigt val.");
                    break;
            }
            if (körs)
            {
                Console.WriteLine("Tryck på valfri tangent för att forsätta ...");
                Console.ReadKey();
            }
        }
    }

    private void Insättning()
    {
        Console.WriteLine("Hur mycket vill du sätta in?");

        if (!int.TryParse(Console.ReadLine(), out int belopp) || belopp <= 0)
        {
            Console.WriteLine("Ogiltigt belopp.");
            return;
        }

        saldo += belopp;
        Console.WriteLine($"Du satte in {belopp} kr.");
    }

    private void Uttag()
    {
        Console.WriteLine("Hur mycket vill du ta ut?");

        if (!int.TryParse(Console.ReadLine(), out int belopp) || belopp <= 0)
        {
            Console.WriteLine("Ogiltigt belopp.");
            return;
        }

        if (belopp > saldo)
        {
            Console.WriteLine("Du har inte tillräckligt med pengar.");
            Console.ReadKey();
            return;
        }

        saldo -= belopp;
        Console.WriteLine($"Du tog ut {belopp} kr.");
    }

    private void VisaSaldo()
    {
        Console.WriteLine($"Ditt saldo är: {saldo} kr");
    }
}

