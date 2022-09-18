// program, kt. načte 2 čísla a zobrazí jejich součet
Console.WriteLine("program, kt. načte 2 čísla a zobrazí jejich součet");
Console.Write("Zadejte prvni cislo: ");
var firstNumber = double.Parse(Console.ReadLine());

Console.Write("Zadejte druhe cislo: ");
var secondNumber = double.Parse(Console.ReadLine());

var result = firstNumber + secondNumber;
Console.WriteLine("Soucet: " + firstNumber + " + " + secondNumber + " = " + result + "\n");

Console.WriteLine("program, který se zeptá na počet hvězdiček a potom je v cyklu zobrazí na konzoli.");
Console.WriteLine("Kolik hvezdicek mam zobrazit na konzoli? Odpoved: ");
Console.WriteLine(new string('*', int.Parse(Console.ReadLine())));

Console.WriteLine("Program lučišník, který vystřelí všechny šípy.");
var lucisnik = new Lucistnik();
lucisnik.VystrelVsechnySipy();

int lowerBound = 0;
int upperBound = 1000;
int myTip = new Random().Next(lowerBound, upperBound);

GuessNumber.Play(myTip, lowerBound, upperBound);

Console.ReadKey();

internal static class GuessNumber
{
    public static void Play(int guessedNumber, int lowerBound, int upperBound)
    {
        Console.WriteLine("Lets play the game!");
        Console.WriteLine($"We are looking for the value of the number X, somewhere between {lowerBound} and {upperBound}");
        Console.Write("What is your initial tip? ");
        int currentTip = int.Parse(Console.ReadLine());
        while (currentTip != guessedNumber)
        {
            if (currentTip > guessedNumber)
            {
                Console.Write($"{currentTip} is greater than X. Try it again: ");
            }
            if (currentTip < guessedNumber)
            {
                Console.Write($"{currentTip} is smaller than X. Try it again: ");
            }
            currentTip = int.Parse(Console.ReadLine());
        }

        Console.WriteLine($"You are right! The X is {guessedNumber}");
    }
}


public class Lucistnik
{
    private int _pocetSipu;

    public Lucistnik(int pocetSipu = 10)
    {
        _pocetSipu = pocetSipu;
    }

    public bool Vystrel()
    {
        if (_pocetSipu == 0)
        {
            Console.WriteLine("Nemam sipy");
            return false;
        }

        _pocetSipu--;
        Console.WriteLine("Vzdy se strefim primo do prostred!");
        return true;
    }

    public void VystrelVsechnySipy()
    {
        while (Vystrel())
        {
        }
    }
}