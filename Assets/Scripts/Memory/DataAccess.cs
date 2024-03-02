using System;
using System.IO;
using UnityEngine;


namespace MemorySystem
{
    public class DataAccess
    {
        // Methode zum Schreiben von Daten in eine Datei
        public static void WriteFile(string text, string path)
        {
            File.WriteAllText(path, text);
        }

        // Methode zum Lesen von Daten aus einer Datei
        public static string ReadFile(string path)
        {
            return File.ReadAllText(path);
        }

        public static void CreateFolder(string path)
        {
            if (!Directory.Exists(path))
            {
                try
                {
                    // Ordner erstellen
                    Directory.CreateDirectory(path);
                    Debug.Log("Ordner erstellt: " + path);
                }
                catch (Exception e)
                {
                    Debug.LogError("Fehler beim Erstellen des Ordners: " + e.Message);
                }
            }
        }

        public static void DeleteFolder(string path)
        {
            try
            {
                // Stelle sicher, dass der Ordner existiert, bevor du ihn löschst
                if (Directory.Exists(path))
                {
                    // Lösche den Ordner und alle darin enthaltenen Dateien und Unterverzeichnisse
                    Directory.Delete(path, true);
                    Debug.Log("Ordner erfolgreich gelöscht: " + path);
                }
                else
                {
                    Debug.LogWarning("Der angegebene Ordner existiert nicht: " + path);
                }
            }
            catch (System.Exception e)
            {
                Debug.LogError("Fehler beim Löschen des Ordners: " + e.Message);
            }
        }
    }
}