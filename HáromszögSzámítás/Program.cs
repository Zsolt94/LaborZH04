using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HáromszögSzámítás
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             A terület számításához a Hérón képletet fogom alkalmazni. 

             A programot felkészítem a a következőkre: 
                - oldal megadásnál nem szám használata,
                - tizedespont és vessző használata is megfelelő (alapvetően nem hiba)
                - nem megfelelő oldalhosszak megadása (amiből nem készíthető háromszög)
                - negatív oldalhosszak megadása
                - ismétlésnél nem "i", vagy "n" lenyomása
                - fájlba írásnál bármilyen felmerülő hiba esetén a hibaüzenet kijelzése

             Az eredmények mentésénél hozzáfűzöm mindig az utolsó sor után az új eredményeket,
             minden futtatást időbélyeggel látok el (DateTime.Now használatával).
            
             Az első futtatás fogja hozná létre a txt-t, de a tömörített fájlban már benne van.
            */

            double a = 0, b = 0, c = 0;
            List<string> calculationResults = new List<string>(); //eredmények
            bool newCalc = true; //ismétléshez

            Console.WriteLine("Háromszög terület, kerület számító alkalmazás\n");
                       

            do
            {
                
                while (true)
                {

                    // a oldal bekérés
                    while (true)
                    {
                        Console.Write("Kérem az 'a' oldal hosszát: ");
                        string inputA = Console.ReadLine();
                        string cleanInputA = inputA.Replace('.', ',');

                        if (double.TryParse(cleanInputA, out a))
                        {
                            if (a > 0)
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("HIBA: Az oldalhossz csak pozitív szám lehet!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("HIBA: Érvénytelen bemenet. Számot adj meg!");
                        }
                    } 

                    // b oldal bekérés
                    while (true)
                    {
                        Console.Write("Kérem az 'b' oldal hosszát: ");
                        string inputB = Console.ReadLine();
                        string cleanInputB = inputB.Replace('.', ',');

                        if (double.TryParse(cleanInputB, out b))
                        {
                            if (b > 0)
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("HIBA: Az oldalhossz csak pozitív szám lehet!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("HIBA: Érvénytelen bemenet. Számot adj meg!");
                        }
                    } 

                    // c oldal bekérés
                    while (true)
                    {
                        Console.Write("Kérem az 'c' oldal hosszát: ");
                        string inputC = Console.ReadLine();
                        string cleanInputC = inputC.Replace('.', ',');

                        if (double.TryParse(cleanInputC, out c))
                        {
                            if (c > 0)
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("HIBA: Az oldalhossz csak pozitív szám lehet!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("HIBA: Érvénytelen bemenet. Számot adj meg!");
                        }
                    } 

                    
                    if (a + b > c && a + c > b && b + c > a)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("\nHIBA: A megadott oldalak nem alkotnak háromszöget!");
                        Console.WriteLine("Add meg újra az oldalakat.\n");
                    }
                } 

                
                double perimeter = a + b + c; //kerület
                double s = perimeter / 2.0; // félkerület (területhez)
                double area = Math.Sqrt(s * (s - a) * (s - b) * (s - c)); //terület

                Console.WriteLine("\n--- EREDMÉNY ---");
                Console.WriteLine($"A háromszög kerülete: {perimeter:F2}");
                Console.WriteLine($"A háromszög területe: {area:F2}");
                Console.WriteLine("-----------------\n");

                
                string resultLine = $"Adatok: a={a}, b={b}, c={c} | Kerület = {perimeter:F2}, Terület = {area:F2}";
                calculationResults.Add(resultLine);

                
                
                while (true)
                {
                    Console.Write("Szeretnél újabb számítást végezni? (i/n): ");
                    string answer = Console.ReadLine().ToLower(); 

                    if (answer == "i" || answer == "igen")
                    {
                        newCalc = true;
                        Console.Clear();
                        break;
                    }
                    if (answer == "n" || answer == "nem")
                    {
                        newCalc = false;
                        break;
                    }

                    Console.WriteLine("HIBA: 'i' (igen) vagy 'n' (nem) betűvel válaszolj.");
                }

            } while (newCalc);



            //fájlba írás
            Console.WriteLine("\nEredmények mentése...");
            try
            {
                
                List<string> finalFileContent = new List<string>();
                finalFileContent.Add($"--- Mentés ideje: {DateTime.Now} ---");
                finalFileContent.AddRange(calculationResults); 
                finalFileContent.Add("-------------------------------------\n");
                File.AppendAllLines("haromszog.txt", finalFileContent); 
                Console.WriteLine("Sikeres mentés a 'haromszog.txt' fájlba.");
            }
            catch (Exception ex)
            {                
                Console.WriteLine($"HIBA: A fájlba írás sikertelen volt! {ex.Message}");
            }


            Console.WriteLine("\nProgram vége! Nyomj meg egy gombot a kilépéshez...");
            Console.ReadKey(true);
        }
    }
}