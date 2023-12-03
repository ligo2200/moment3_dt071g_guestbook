/* 
 * Code written by Linda Götenmark, ht 2023
 * ligo2200@student.miun.se
 * MidSweden University, course DT071G
 * moment 3 - program guestbook
 */

using System;

namespace moment3
{
    class Program
    {
        static void Main(string[] args)
        {
            // new instance of GuestBook
            GuestBook guestBook = new GuestBook();

            // upload list of entries if list exists
            guestBook.LoadFromFile("guestbook.json");

            ShowMenu(guestBook);
        }

        static void ShowMenu(GuestBook guestBook)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Meny:");
                Console.WriteLine("1. Lägg till Gästboksinlägg");
                Console.WriteLine("2. Radera Gästboksinlägg");
                Console.WriteLine("X. Avsluta programmet");

                // show guestbook entries
                guestBook.DisplayEntries();

                string choice = Console.ReadLine();

                switch (choice.ToUpper())
                {
                    case "1":
                        AddGuestBookEntry(guestBook);
                        break;
                    case "2":
                        RemoveGuestBookEntry(guestBook);
                        break;
                    case "X":
                        guestBook.SaveToFile("guestbook.json");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Ogiltigt val. Försök igen.");
                        break;
                }
            }
        }

        static void AddGuestBookEntry(GuestBook guestBook)
        {
            Console.Write("Ange namn: ");
            string owner = Console.ReadLine();

            Console.Write("Ange meddelande: ");
            string text = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(owner) && !string.IsNullOrWhiteSpace(text))
            {
                guestBook.AddEntry(owner, text);
                Console.WriteLine("Inlägget har lagts till.");
            }
            else
            {
                Console.WriteLine("Felaktig inmatning. Försök igen.");
            }

            Console.WriteLine("Tryck på valfri tangent för att uppdatera gästboksinläggen.");
            Console.ReadKey();
        }

        static void RemoveGuestBookEntry(GuestBook guestBook)
        {
            Console.Write("Ange index för inlägget som ska raderas: ");
            if (int.TryParse(Console.ReadLine(), out int index))
            {
                guestBook.DeleteEntry(index);
            }
            else
            {
                Console.WriteLine("Ogiltigt index. Inget inlägg raderat.");
            }

            Console.WriteLine("Tryck på valfri tangent för att uppdatera gästbooksinläggen.");
            Console.ReadKey();
        }
    }
}

