public interface ILetani
{
    void Let();
}

public interface IMluveni
{
    void Mluv();
}

public class Papousek : ILetani, IMluveni
{
    public string Jmeno { get; }

	// Kdyby ses chtěla někdy blýsknout svou znalostí C#, tak tyto 1řádkové metody se dají přepsat do
    public Papousek(string jmeno) => Jmeno = jmeno;

    public void Let() => Console.WriteLine($"{Jmeno}: Letim");

    public void Mluv() => Console.WriteLine($"{Jmeno}: Ahoy kapitan, ahoy kapitan.");
}
	
public class Korela : ILetani, IMluveni
{
    public string Jmeno { get; }

    public Korela(string jmeno) => Jmeno = jmeno;

    public void Let() => Console.WriteLine($"{Jmeno}: Letim");

    public void Mluv() => Console.WriteLine($"{Jmeno}: Preju dobry den, preju dobry den.");
}

public class Andulka : ILetani
{
    public string Jmeno { get; }

    public Andulka(string jmeno) => Jmeno = jmeno;

    public void Let() => Console.WriteLine($"{Jmeno}: Letim");
}
					
public class Program
{
    public static void Main()
    {
        var seznamPtacku = new List<ILetani>
        {
            new Papousek("Drahos"),
            new Andulka("Roska"),
            new Korela("Anita")
        };

        foreach (var ptak in seznamPtacku)
        {
            ptak.Let();
            if (ptak is IMluveni mluviciPtak)
            {
                mluviciPtak.Mluv();
            }
            Console.WriteLine();
        }

        Console.ReadLine();
    }
}