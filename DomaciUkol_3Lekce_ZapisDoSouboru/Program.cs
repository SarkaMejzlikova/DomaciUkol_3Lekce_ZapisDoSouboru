using System.Collections;
using System.IO;


internal class Program
{
    private static void Main(string[] args)
    {
        string cesta = "";

        Console.WriteLine("Dobrý den,\nchcete zadat cestu k souboru ručně?\nOdpovězte zadáním čísla: 1 - ano / 2 - ne");
        int odpovedCesta = KontrolaOdpovedi(Console.ReadLine());
        
        switch(odpovedCesta)
        {
            case (int)Cesta.ano:
                Console.WriteLine("Zadejte cestu:");
                cesta = Console.ReadLine();
            break;

            case (int)Cesta.ne:
                cesta = @"C:\Users\sarka\Documents\C#\Czechitas\text.txt";
            break;

        }

        Console.WriteLine("Chcete do souboru přidávat řádky nebo vypsat soubor?\nOdpovězte zadáním čísla: 1 - přidat řádky / 2 - vypsat soubor");
        int odpovedPridatVypsat = KontrolaOdpovedi(Console.ReadLine());

        switch (odpovedPridatVypsat)
        {
            case (int)PridatRadkyVypsatSoubor.pridatRadky:

                Console.WriteLine("Má se soubor přepsat nebo se mají řádky přidat na konec?\nOdpovězte zadáním čísla: 1 - přepsat / 2 - přidat");
                int odpovedPrepsatPridat = KontrolaOdpovedi(Console.ReadLine());

                switch (odpovedPrepsatPridat)
                {
                    case (int)PripsatPridat.prepsat:

                        string[] poleProPrepsani = PridavaniTextu();
                        File.WriteAllLines(cesta, poleProPrepsani);
                    break;

                    case (int)PripsatPridat.pridat:

                        string[] poleProPridani = PridavaniTextu();
                        File.AppendAllLines(cesta, poleProPridani);
                    break;
                }
            break;

            case (int)PridatRadkyVypsatSoubor.vypsatSoubor:

                string vypisSouboru = File.ReadAllText(cesta);
                Console.WriteLine(vypisSouboru);
            break;
        }
    
    }

    enum Cesta
    {
        ano = 1,
        ne = 2
    }

    enum PridatRadkyVypsatSoubor
    {
        pridatRadky = 1,
        vypsatSoubor = 2
    }

    enum PripsatPridat
    {
        prepsat = 1,
        pridat = 2
    }

    public static int KontrolaOdpovedi(string odpovedi)
    {
        int kontrolaOdpovedi;
        while (!int.TryParse(odpovedi, out kontrolaOdpovedi) || kontrolaOdpovedi < 1 || kontrolaOdpovedi > 2)
        {
            Console.WriteLine("Zřejmě jste jako odpověď nezadali 1 nebo 2, zkuste to znovu:");
            odpovedi = Console.ReadLine();
        }
        return kontrolaOdpovedi;
    }

    public static string[] PridavaniTextu()
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
        return poleTextu;
    }

}