using System;
using System.Collections.Generic;

namespace MemorySystem
{
    public class IDFunctions
    {
        public static string path = "IDs.json";
        public static List<double> IDs;
        
        public static double GetUniqueID()
        {
            Random random = new Random();

            // Erzeuge eine zufällige double-ID
            double newID = random.NextDouble();

            // Überprüfe, ob die ID bereits existiert
            while (IDs.Contains(newID))
            {
                newID = random.NextDouble();
            }
            IDs.Add(newID);
            save();
            return newID;
        }
        public static void load()
        {
           IDs =  MemoryFunctions.load<List<double>>(path);
        }

        public static void save()
        {
            MemoryFunctions.save(IDs, path);
        }
        public static void RemoveID(double ID)
        {
            IDs.Remove(ID);
        }

    }
}
