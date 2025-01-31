using System;
using System.Collections.Generic;
using System.IO;

namespace JournalApp
{
    public class Journal
    {
        private List<Entry> entries = new List<Entry>();

        public void AddEntry(Entry entry)
        {
            entries.Add(entry);
            Console.WriteLine("Entry added successfully!");
        }

        public void DisplayEntries()
        {
            if (entries.Count == 0)
            {
                Console.WriteLine("No entries to display.");
                return;
            }

            foreach (var entry in entries)
            {
                Console.WriteLine(entry.ToString());
                Console.WriteLine("-------------------------");
            }
        }

        public void SaveToFile(string filename)
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                foreach (var entry in entries)
                {
                    writer.WriteLine($"{entry.Date}~|~{entry.Prompt}~|~{entry.Response}");
                }
            }
            Console.WriteLine("Journal saved successfully!");
        }

        public void LoadFromFile(string filename)
        {
            if (File.Exists(filename))
            {
                entries.Clear();
                foreach (var line in File.ReadAllLines(filename))
                {
                    string[] parts = line.Split("~|~");
                    if (parts.Length == 3)
                    {
                        entries.Add(new Entry(parts[1], parts[2], parts[0]));
                    }
                }
                Console.WriteLine("Journal loaded successfully!");
            }
            else
            {
                Console.WriteLine("File not found.");
            }
        }
    }
}
