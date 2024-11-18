namespace Converter
{
    internal class Program
    {
        static void Main(string[] args)
        {
//Looper programmet indtil afsluttet

                bool keepRunning = true;

                while (keepRunning)
                {
                    Console.WriteLine("Velkommen til IP-konverteringsprogrammet!");
                    Console.WriteLine("Vælg en mulighed:");
                    Console.WriteLine("1. Omform IP-adresse til binær");
                    Console.WriteLine("2. Omform binær kode til IP-adresse");
                    Console.WriteLine("3. Afslut programmet");

                    string? choice = Console.ReadLine();

                    if (choice == "1")
                    {
                        Console.WriteLine("Indtast en IP-adresse (f.eks. 192.168.0.1):");
                        string? ipAddress = Console.ReadLine();
                        string? binaryResult = ConvertIpToBinary(ipAddress);
                        if (binaryResult != null)
                        {
                            Console.WriteLine($"Den binære version af {ipAddress} er: {binaryResult}");
                        }
                    }
                    else if (choice == "2")
                    {
                        Console.WriteLine("Indtast en binær kode (f.eks. 11000000.10101000.00000000.00000001):");
                        string? binaryInput = Console.ReadLine();
                        string? ipResult = ConvertBinaryToIp(binaryInput);
                        if (ipResult != null)
                        {
                            Console.WriteLine($"IP-adressen for binær kode {binaryInput} er: {ipResult}");
                        }
                    }
                    else if (choice == "3")
                    {
                        Console.WriteLine("Afsluttet");
                        keepRunning = false;
                    }
                    else
                    {
                        Console.WriteLine("Ugyldigt valg, prøv igen.");
                    }

                    Console.WriteLine();
                }
            }
        //Omform fra IP adresse til binær kode
            static string? ConvertIpToBinary(string ipAddress)
            {
                string[] segments = ipAddress.Split('.');
                if (segments.Length != 4)
                {
                    Console.WriteLine("Fejl: Ugyldig IP-adresse.");
                    return null;
                }

                string binaryIp = "";
                foreach (string segment in segments)
                {
                if (int.TryParse(segment, out int number) && number >= 0 && number <= 255)
                {
                    string binarySegment = "";
                    for (int i = 7; i >= 0; i--)
                    {
                        binarySegment += (number & (1 << i)) != 0 ? "1" : "0";
                    }
                    binaryIp += binarySegment + ".";
                }
                else
                {
                    Console.WriteLine("Fejl: Ugyldigt segment i IP-adresse.");
                    return null;
                }
            }

                return binaryIp.TrimEnd('.');
            }

            static string? ConvertBinaryToIp(string binaryInput)
            {
                string[] segments = binaryInput.Split('.');
                if (segments.Length != 4)
                {
                    Console.WriteLine("Fejl: Ugyldig binær kode.");
                    return null;
                }

                string ipAddress = "";
                foreach (string segment in segments)
                {
                    if (segment.Length != 8)
                    {
                        Console.WriteLine("Fejl: Hvert segment skal være 8 bits langt.");
                        return null;
                    }

                    int decimalValue = 0;
                    for (int i = 0; i < 8; i++)
                    {
                        if (segment[i] == '1')
                        {
                            decimalValue += 1 << (7 - i);
                        }
                        else if (segment[i] != '0')
                        {
                            Console.WriteLine("Fejl: Binær kode må kun indeholde 0 og 1.");
                            return null;
                        }
                    }
                    ipAddress += decimalValue + ".";
                }

                return ipAddress.TrimEnd('.');
            }
        }

    }


