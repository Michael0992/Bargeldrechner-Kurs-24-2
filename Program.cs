namespace Bargeldrechner
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.OutputEncoding = System.Text.Encoding.UTF8; //Umstellung der Konsole von UTF16 auf UTF8

			string[] geld = { "500€ Schein","200€ Schein","100€ Schein","50€ Schein","20€ Schein","10€ Schein","5€ Schein","2€ Münze","1€ Münze","50 Cent","20 Cent","10 Cent","5 Cent","2 Cent","1 Cent" };
			int[] scheineUndMuenzen = { 50000, 20000, 10000, 5000, 2000, 1000, 500, 200, 100, 50, 20, 10, 5, 2, 1 };
			decimal gegeben;

            Console.Write("Geben Sie den zu zahlenden Betrag ein: ");
			decimal betrag = Convert.ToDecimal(Console.ReadLine());
			while (true)
			{
				Console.Write("Geben Sie den gezahlten Betrag ein: ");
				gegeben = Convert.ToDecimal(Console.ReadLine());

				if (gegeben > betrag)
				{
					break;
				}
				else if(gegeben == betrag)
				{
                    Console.WriteLine("Der gegebene Betrag passt genau!");
					return;
                }
				Console.WriteLine("Der Betrag ist zu niedrig");			
			}
	
			decimal rueckgeld = gegeben - betrag;
            Console.WriteLine($"Rückgeld: {rueckgeld:C}");

			int rueckgeldInCent = (int)(rueckgeld * 100);          

			for (int i = 0; i < scheineUndMuenzen.Length; i++)
			{
				int anzahl = rueckgeldInCent / scheineUndMuenzen[i];

				if(anzahl > 0)
				{
                    Console.WriteLine($"{anzahl} x {geld[i]}");
					rueckgeldInCent = rueckgeldInCent % scheineUndMuenzen[i];

					// 25 / 5 = 5 rest 0
					// 25 % 5 = 0

					//26 % 5 = 1

					//2838 % 2000 = 838

					//1338 % 500 = 338  weil 500 zwei mal in 1338 reinpasst und der Rest 338 ist.
					//usw ...
                }
			}


        }
	}
}
