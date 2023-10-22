using System.IO;

string cesta = "";

Console.WriteLine("Dobrý den,\nchcete zadat cestu k souboru ručně?\nOdpovězte: ano/ne");
if (Console.ReadLine() == "ano")
{
    Console.WriteLine("Zadejte cestu:");
    cesta = Console.ReadLine();
}
else
{
    cesta = @"C:\Users\sarka\Documents\C#\Czechitas\text.txt";
}

Console.WriteLine("Chcete do souboru přidávat řádky nebo vypsat soubor?\nOdpovězte: přidat řádky/vypsat soubor");
if (Console.ReadLine() == "přidat řádky")
{
    Console.WriteLine("Má se soubor přepsat nebo se mají řádky přidat na konec?\nOdpovězte: přepsat/přidat");
    if (Console.ReadLine() == "přepsat")
    {
        Console.WriteLine("Přidávejte řádky jak dlouho chcete. Pro ukončení zmáčkněte ENTER. ");
        string input = Console.ReadLine();
        List<string> listTextu = new List<string>();

        while (!string.IsNullOrEmpty(input))
        {
            listTextu.Add(input);
            input = Console.ReadLine();
        }

        string[] poleTextu = listTextu.ToArray();
        File.WriteAllLines(cesta, poleTextu);
    }
    else
    {
        Console.WriteLine("Přidávejte řádky jak dlouho chcete. Pro ukončení zmáčkněte ENTER. ");
        string input = Console.ReadLine();
        List<string> listTextu = new List<string>();

        while (!string.IsNullOrEmpty(input))
        {
            listTextu.Add(input);
            input = Console.ReadLine();
        }

        string[] poleTextu = listTextu.ToArray();
        File.AppendAllLines(cesta, poleTextu);
    }
}
else
{
    string vypisSouboru = File.ReadAllText(cesta);
    Console.WriteLine(vypisSouboru);
}

Console.ReadLine();