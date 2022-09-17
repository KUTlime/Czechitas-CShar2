IMenu menu = new Menu();
IOrderCollector orderCollector = new OrderCollector();
Console.WriteLine(StringLiterals.Order.WelcomeMessage);
Console.WriteLine(menu.GetMenu());
CollectOrdersFromUser(menu, orderCollector);
Console.WriteLine();
Console.WriteLine(orderCollector.GetCompleteOrder());
Console.ReadKey();

static void CollectOrdersFromUser(IMenu menu, IOrderCollector orderCollector)
{
    var nextPrompt = StringLiterals.Order.FirstPrompt;
    do
    {
        Console.WriteLine(nextPrompt);
        nextPrompt = Console.ReadLine()?.Trim().ToLowerInvariant() switch
        {
            "hotovo" => null,
            { } order => HandleOrder(order, menu, orderCollector),
            _ => StringLiterals.Menu.NotOnMenu
        };
    } while (nextPrompt is not null);
}

static string HandleOrder(string order, IMenu menu, IOrderCollector orderCollector)
{
    var orderItem = new MenuItem(order);
    if (menu.IsOnMenu(orderItem))
    {
        orderCollector.TakeOrder(orderItem);
        return StringLiterals.Order.OtherPrompt;
    }

    return StringLiterals.Menu.NotOnMenu;
}

class Menu : IMenu
{
    private readonly HashSet<MenuItem> _menuItems = new (){new ("Burger"), new ("Fries"), new ("Strips"), new ("Nachos"), new ("Mayonnaise"), new ("Ketchup")};

    public string GetMenu() => StringLiterals.Menu.Prefix + string.Join(", ", GetItems().Select(i => i.Name));

    public IEnumerable<MenuItem> GetItems() => _menuItems;

    public bool IsOnMenu(MenuItem menuItem) => _menuItems.Contains(menuItem);
}

class OrderCollector : IOrderCollector
{
    private readonly List<MenuItem> _orders = new();

    public string GetCompleteOrder() => StringLiterals.Order.Prefix + string.Join(",", _orders.Select(o => o.Name)) + StringLiterals.Order.Suffix;

    public void TakeOrder(MenuItem menuItem) => _orders.Add(menuItem);

    public bool IsEmpty() => _orders.Any();
}

public interface IMenu
{
    string GetMenu();
    IEnumerable<MenuItem> GetItems();
    bool IsOnMenu(MenuItem menuItem);
}

public interface IOrderCollector
{
    string GetCompleteOrder();
    void TakeOrder(MenuItem menuItem);
    bool IsEmpty();
}

public sealed record MenuItem(string Name)
{
    public bool Equals(MenuItem? other) => string.CompareOrdinal(Name.ToLowerInvariant(), other?.Name.ToLowerInvariant()) == 0;

    public override int GetHashCode() => Name.ToLowerInvariant().GetHashCode();
}

internal static class StringLiterals
{
    public static class Menu
    {
        public static string Prefix => "V nabidce mame: ";
        public static string NotOnMenu => "To nemame, a dal?";

    }

    public static class Order
    {
        public static string WelcomeMessage => "Vítejte u Křupavé Czechitky!";
        public static string FirstPrompt => "Co si date?";
        public static string OtherPrompt => "Vyborne, a dal?";
        public static string Prefix => "Vase objednavka: ";
        public static string Suffix => " je pripravena, dobrou chut 🙂";
        public static string OrderCompleted => "hotovo";
    }
}