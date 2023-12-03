/*
 * Code written by Linda Götenmark, ht 2023
 * ligo2200@student.miun.se
 * MidSweden University, course DT071G
 * moment 3 - guestbook
 * Class GuestBook
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace moment3
{
    public class GuestBook
    {
        // new list for guestbook entries
        private List<GuestBookEntry> entries = new List<GuestBookEntry>();

        // filepath for json-file
        private string filePath = @"guestbook.json";

        // method for adding entry
        public void AddEntry(string owner, string text)
        {

            GuestBookEntry newEntry = new GuestBookEntry(owner, text);
            entries.Add(newEntry);
        }

        // method for showing entry
        public void DisplayEntries()
        {
            if (entries.Count == 0)
            {
                Console.WriteLine("Inga gästboksinlägg att visa");
            }
            else
            {
                Console.WriteLine("GÄSTBOKSINLÄGG:");

                int index = 0;

                foreach (var entry in entries)
                {
                    Console.WriteLine($"[{index}], Namn: {entry.Owner}, Meddelande: {entry.Text}");
                    index++;
                }
            }
        }

        // method for deleting
        public void DeleteEntry(int index)
        {
            if (index >= 0 && index < entries.Count)
            {
                entries.RemoveAt(index);
                Console.WriteLine("Inlägg borttaget!");
            }
            else
            {
                Console.WriteLine("Ogiltig index. Inget inlägg raderades.");
            }
        }

        // method for saving data to json
        public void SaveToFile(string filePath)
        {

            // converting guestbook-list to json with indentation
            string json = JsonSerializer.Serialize(entries, new JsonSerializerOptions { WriteIndented = true });

            // write json string to filepath.
            File.WriteAllText(filePath, json);
        }

        // method for retrieving data from json
        public void LoadFromFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                entries = JsonSerializer.Deserialize<List<GuestBookEntry>>(json);
            }
            else
            {
                // if file doesnt exist, create neew empty list of entries
                entries = new List<GuestBookEntry>();
                Console.WriteLine("Filen finns inte. En ny fil har skapats.");
            }
        }

    }
}
