using System;
using System.Collections.Generic;
using System.IO;

namespace _06.Phones
{
    public class Program
    {
        private static Dictionary<string, List<int>> keys = new Dictionary<string, List<int>>();
        private static Dictionary<int, string> records = new Dictionary<int, string>();
        private static int currRecord = 0;

        public static void Main()
        {
            StreamReader recordsReader = new StreamReader("Phones.txt");
            using (recordsReader)
            {
                string record = recordsReader.ReadLine();
                while (record != null)
                {
                    records.Add(currRecord, record);
                    AddInKeys(record);
                    currRecord++;
                    record = recordsReader.ReadLine();
                }
            }

            StreamReader commandsReader = new StreamReader("commands.txt");
            using (commandsReader)
            {
                string command = commandsReader.ReadLine().Trim().ToLower();
                while (command != null)
                {
                    command = command.Trim().ToLower();

                    var commandParts = command.Split('(');
                    if (commandParts[0] == "find")
                    {
                        var argsLength = commandParts[1].Length;
                        Find(commandParts[1].Remove(argsLength - 1));
                    }

                    command = commandsReader.ReadLine();
                }
            }
        }

        private static void Find(string args)
        {
            var result = new List<string>();

            if (args.Contains(","))
            {
                result = FindByNameAndTown(args);
            }
            else
            {
                result = FindByName(args);
            }

            Console.WriteLine(string.Join("\r\n", result));
        }
  
        private static List<string> FindByName(string args)
        {
            List<string> foundRecords = new List<string>();

            args = args.Trim().ToLower();
            try
            {
                var recordsKeys = keys[args];

                foreach (var key in recordsKeys)
                {
                    foundRecords.Add(records[key]);
                }
            }
            catch (KeyNotFoundException ex)
            {
                foundRecords.Add(ex.Message);
            }

            return foundRecords;
        }

        private static List<string> FindByNameAndTown(string args)
        {
            List<string> result = new List<string>();

            var parts = args.Split(',');
            var name = parts[0];
            var town = parts[1].Trim().ToLower();

            var resultForName = FindByName(name);

            foreach (var recordByName in resultForName)
            {
                var currRecord = recordByName.ToLower();
                if (currRecord.Contains(town))
                {
                    result.Add(recordByName);
                }
            }

            return result;
        }
  
        private static void AddInKeys(string record)
        {
            var parts = record.Split('|');

            var fullName = parts[0].ToLower();
            var nameParts = fullName.Trim().Split(' ');
            var town = parts[1].Trim().ToLower();
            var phone = parts[2].Trim();

            AddOnKey(fullName);
            foreach (var namePart in nameParts)
            {
                AddOnKey(namePart);
            }

            AddOnKey(town);
            AddOnKey(phone);
        }

        private static void AddOnKey(string key)
        {
            try
            {
                keys[key].Add(currRecord);
            }
            catch(KeyNotFoundException ex)
            {
                keys.Add(key, new List<int> { currRecord });
            }
        }
    }
}
