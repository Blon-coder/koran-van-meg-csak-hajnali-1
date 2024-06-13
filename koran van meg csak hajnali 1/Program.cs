using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace koran_van_meg_csak_hajnali_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Tanarur ezt egy indiai haver es a chatgpt segitsegevel sikerult osszelegozzam ne nezze ki belolem hogy egy este alatt ilyen okos leszek de probalkozom
            {
                while (true)
                {
                    Console.WriteLine("Jelszo alkoto keszitette(nagyjabol): bardi janos");

                    int length;
                    while (true)
                    {
                        Console.Write("Add meg a jelszo hosszusagat: ");
                        if (int.TryParse(Console.ReadLine(), out length) && length > 0)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Egy szamot kertem nem almafat");
                        }
                    }

                    Console.Write("Legyen kisbetu? (i/n): ");
                    bool includeLowercase = Console.ReadLine().ToLower() == "i";

                    Console.Write("legyen nagybetu? (i/n): ");
                    bool includeUppercase = Console.ReadLine().ToLower() == "i";

                    Console.Write("szamok legyenek? (i/n): ");
                    bool includeNumbers = Console.ReadLine().ToLower() == "i";

                    Console.Write("nagyon biztonsagos jelszot szeretnel (i/n): ");
                    bool includeSpecial = Console.ReadLine().ToLower() == "i";

                    try
                    {
                        // Itt megy le a jelszo csinalas savale
                        string password = GeneratePassword(length, includeLowercase, includeUppercase, includeNumbers, includeSpecial);
                        Console.WriteLine("Itt a jelszavad: " + password);
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                    Console.Write("tetszik ez vagy kersz egy masikat? (kerek/nem kerek): ");
                    if (Console.ReadLine().ToLower() != "kerek")
                    {
                        break;
                    }
                }
            }

             string GeneratePassword(int length, bool includeLowercase, bool includeUppercase, bool includeNumbers, bool includeSpecial)
            {
                string lowerChars = "abcdefghijklmnopqrstuvwxyz";
                string upperChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                string numberChars = "1234567890";
                string specialChars = "!@#$%^&*()_-+=<>?";
                 //itt az van hogy milyen karaktereket adjon hozza a program
                string validChars = "";
                if (includeLowercase) validChars += lowerChars;
                if (includeUppercase) validChars += upperChars;
                if (includeNumbers) validChars += numberChars;
                if (includeSpecial) validChars += specialChars;

                if (string.IsNullOrEmpty(validChars))
                {
                    throw new ArgumentException("Bazdmeg ennyi eszed van hogy semmilyen karaktert nem kersz");
                }

                Random random = new Random();
                char[] password = new char[length];

                for (int i = 0; i < length; i++)
                {
                    password[i] = validChars[random.Next(validChars.Length)];
                }

                return new string(password);
            }
        }
    }
    }

