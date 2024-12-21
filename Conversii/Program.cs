namespace Conversii
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Introduceti baza initiala (intre 2 si 16): ");
            int b1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Introduceti baza (sa fie intre 2 si 16) in care doriti sa convertiti numarul: ");
            int b2 = int.Parse(Console.ReadLine());

            if (b1 < 2 || b1 > 16 || b2 < 2 || b2 > 16)
            {
                Console.WriteLine("Bazele trebuie sa fie intre 2 si 16!");
                return;
            }

            Console.WriteLine($"Introduceti numarul in baza {b1}: ");
            string numar = Console.ReadLine();

            // Separăm partea întreagă de partea fracționară
            string[] parti = numar.Split('.');
            string parteIntreaga = parti[0];
            string parteFractionara;
            if (parti.Length>1)
            {
                parteFractionara=parti[1];
            }
            else
            {
                parteFractionara = "";
            }
          
            // Convertim partea întreagă în baza 10
            int intreaga10 = 0;
            for (int i = 0; i < parteIntreaga.Length; i++)
            {
                char cifra = parteIntreaga[i];
                int valoare = ConversieHexaInInt(cifra);
                intreaga10 = intreaga10 * b1 + valoare;
            }

            // Convertim partea fracționară în baza 10
            double fractionara10 = 0;
            double factor = 1.0 / b1;
            for (int i = 0; i < parteFractionara.Length; i++)
            {
                char cifra = parteFractionara[i];
                int valoare = ConversieHexaInInt(cifra);
                fractionara10 += valoare * factor;
                factor /= b1;
            }

            // Convertim partea întreagă din baza 10 în baza b2
            string intreagaB2 = "";
            if (intreaga10 == 0)
            {
                intreagaB2 = "0";
            }
            else
            {
                while (intreaga10 > 0)
                {
                    int rest = intreaga10 % b2;
                    intreagaB2 = ConversieIntInHexa(rest) + intreagaB2;
                    intreaga10 /= b2;
                }
            }

            // Convertim partea fracționară din baza 10 în baza b2
            string fractionaraB2 = "";
            int maxIteratii = 10; // Limităm la 10 cifre pentru partea fracționară
            while (fractionara10 > 0 && maxIteratii-- > 0)
            {
                fractionara10 *= b2;
                fractionaraB2 += ConversieIntInHexa((int)fractionara10);
                fractionara10 -= (int)fractionara10;
            }

            // Combinăm rezultatul final
            string rezultatFinal = fractionaraB2.Length > 0 ? $"{intreagaB2}.{fractionaraB2}" : intreagaB2;
            Console.WriteLine($"Numărul {numar} din baza {b1} este {rezultatFinal} în baza {b2}.");
        }

        static int ConversieHexaInInt(char c)
        {
            if (c == '0') return 0;
            if (c == '1') return 1;
            if (c == '2') return 2;
            if (c == '3') return 3;
            if (c == '4') return 4;
            if (c == '5') return 5;
            if (c == '6') return 6;
            if (c == '7') return 7;
            if (c == '8') return 8;
            if (c == '9') return 9;
            if (c == 'A' || c == 'a') return 10;
            if (c == 'B' || c == 'b') return 11;
            if (c == 'C' || c == 'c') return 12;
            if (c == 'D' || c == 'd') return 13;
            if (c == 'E' || c == 'e') return 14;
            if (c == 'F' || c == 'f') return 15;

            throw new ArgumentException("Caracter invalid pentru baza specificată.");
        }

        static char ConversieIntInHexa(int n)
        {
            if (n == 0) return '0';
            if (n == 1) return '1';
            if (n == 2) return '2';
            if (n == 3) return '3';
            if (n == 4) return '4';
            if (n == 5) return '5';
            if (n == 6) return '6';
            if (n == 7) return '7';
            if (n == 8) return '8';
            if (n == 9) return '9';
            if (n == 10) return 'A';
            if (n == 11) return 'B';
            if (n == 12) return 'C';
            if (n == 13) return 'D';
            if (n == 14) return 'E';
            if (n == 15) return 'F';

            throw new ArgumentException("Număr invalid pentru conversia în baza 16.");
        }
    }
}
