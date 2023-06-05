// Screen Sound
string welcomeMessage = "Boas vindas ao Screen Sound";
Dictionary<string, List<int>> bands = new Dictionary<string, List<int>>();
bands.Add("Dream Theater", new List<int> { 8, 2, 5 });
bands.Add("Metallica", new List<int>());

void DisplayLogo()
{
    Console.WriteLine(@"

░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░
");
    Console.WriteLine(welcomeMessage);
}

void DisplayMenuOptions()
{
    DisplayLogo();
    Console.WriteLine("\nDigite 1 para registrar uma banda");
    Console.WriteLine("Digite 2 para mostrar todas as bandas");
    Console.WriteLine("Digite 3 para avaliar uma banda");
    Console.WriteLine("Digite 4 para exibir a média de uma banda");
    Console.WriteLine("Digite 0 para sair");

    Console.Write("\nDigite a sua opção: ");
    string chosenOption = Console.ReadLine()!;
    int chosenOptionNumeric = int.TryParse(chosenOption, out int option) ? option : 9;

    switch (chosenOptionNumeric)
    {
        case 1:
            RegisterBand();
            break;
        case 2:
            ShowRegisteredBands();
            break;
        case 3:
            RateBand();
            break;
        case 4:
            GetBandAverage();
            break;
        case 0:
            Console.WriteLine("Tchau tchau :)");
            break;

        default:
            Console.Clear();
            DisplayMenuOptions();
            break;
    }
}

void RegisterBand()
{
    Console.Clear();
    PrintTextWithAsterisks("Registro de banda");
    Console.Write("Digite o nome da banda que deseja registrar: ");
    string bandName = Console.ReadLine()!;
    bands.Add(bandName, new List<int>());
    Console.WriteLine($"A banda {bandName} foi registrada com sucesso!");
    Thread.Sleep(1000);
    Console.Clear();
    DisplayMenuOptions();
}

void ShowRegisteredBands()
{
    Console.Clear();
    PrintTextWithAsterisks("Exibindo todas as bandas registradas");

    foreach (string band in bands.Keys)
    {
        Console.WriteLine(band);
    }

    Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
    Console.ReadKey();
    Console.Clear();
    DisplayMenuOptions();
}

void PrintTextWithAsterisks(string text)
{
    string asterisks = new string('*', text.Length);
    Console.WriteLine(asterisks);
    Console.WriteLine("\n");
    Console.WriteLine(text);
    Console.WriteLine("\n");
    Console.WriteLine(asterisks);
}

void RateBand()
{
    string bandName;
    while (true)
    {
        Console.Clear();
        PrintTextWithAsterisks("Avaliar de banda");
        Console.WriteLine("Digite o nome da banda que deseja avaliar: ");
        bands.Keys.ToList().ForEach(band => Console.WriteLine(band));
        bandName = Console.ReadLine()!;
        if (bands.ContainsKey(bandName)) break;

        Console.WriteLine("Banda não encontrada, digite 1 para avaliar outra banda ou 2 para voltar ao menu principal.");
        string chosenOption = Console.ReadLine()!;
        int chosenOptionNumeric = int.TryParse(chosenOption, out int option) ? option : 9;
        switch (chosenOptionNumeric)
        {
            case 1:
                continue;
            case 2:
                Console.Clear();
                DisplayMenuOptions();
                return;
            default:
                Console.Clear();
                DisplayMenuOptions();
                return;
        }
    }
    int bandRating;
    while (true)
    {
        Console.WriteLine("Digite a nota da banda: ");
        bandRating = int.TryParse(Console.ReadLine(), out int rating) ? rating : -1;
        if (bandRating >= 0 && bandRating <= 10) break;

        Console.WriteLine("Nota inválida, digite uma nota de 0 à 10.");
        Thread.Sleep(1500);
    }
    bands[bandName].Add(bandRating);
    Console.WriteLine($"A banda {bandName} foi avaliada com sucesso!");
    Thread.Sleep(1000);
    Console.Clear();
    DisplayMenuOptions();
}

void GetBandAverage()
{
    string bandName;
    while (true)
    {
        Console.Clear();
        PrintTextWithAsterisks("Média de banda");
        Console.WriteLine("Digite o nome da banda que deseja obter a média: ");
        bands.Keys.ToList().ForEach(band => Console.WriteLine(band));
        bandName = Console.ReadLine()!;
        if (bands.ContainsKey(bandName)) break;

        Console.WriteLine("Banda não encontrada, digite 1 para obter a média de outra banda ou 2 para voltar ao menu principal.");
        string chosenOption = Console.ReadLine()!;
        int chosenOptionNumeric = int.TryParse(chosenOption, out int option) ? option : 9;
        switch (chosenOptionNumeric)
        {
            case 1:
                continue;
            case 2:
                Console.Clear();
                DisplayMenuOptions();
                return;
            default:
                Console.Clear();
                DisplayMenuOptions();
                return;
        }
    }
    int average = (int)bands[bandName].Average();
    Console.WriteLine($"A média da banda {bandName} é {average}");
    Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
    Console.ReadKey();
    Console.Clear();
    DisplayMenuOptions();
}

DisplayMenuOptions();
