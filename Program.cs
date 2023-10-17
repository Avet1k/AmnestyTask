namespace AmnestyTask;
class Program
{
    static void Main(string[] args)
    {
        List<Prisoner> prisoners = new List<Prisoner>
        {
            new ("Данилова А.Я.", Crimes.AntiGoverment),
            new ("Волкова Е.Д.", Crimes.Murder),
            new ("Савельева Е.С.", Crimes.Theft),
            new ("Никитина К.А.", Crimes.Theft),
            new ("Попова С.М.", Crimes.Murder),
            new ("Васильева А.О.", Crimes.AntiGoverment),
            new ("Тихонова В.Т.", Crimes.Theft),
            new ("Ефимова С.Ю.", Crimes.AntiGoverment)
        };

        Prison prison = new Prison(prisoners);
        
        prison.ShowInfo();
        
        prison.Amnesty(Crimes.AntiGoverment);
        
        Console.WriteLine();
        prison.ShowInfo();
    }
}

public class Crimes
{
    public const string AntiGoverment = "Антиправительственное";
    public const string Murder = "Убийство";
    public const string Theft = "Кража";
}

class Prisoner
{
    public Prisoner(string name, string crime)
    {
        Name = name;
        Crime = crime;
    }
    
    public string Name { get; private set; }
    public string Crime { get; private set; }

    public void ShowInfo()
    {
        Console.WriteLine($"Заключённый: {Name}. Преступление: {Crime}.");
    }
}

class Prison
{
    private List<Prisoner> _prisoners;

    public Prison(List<Prisoner> prisoners)
    {
        _prisoners = prisoners;
    }

    public void ShowInfo()
    {
        foreach (Prisoner prisoner in _prisoners)
            prisoner.ShowInfo();
    }

    public void Amnesty(string crime)
    {
        _prisoners = _prisoners.Where(prisoner => prisoner.Crime != Crimes.AntiGoverment).ToList();
    }
}