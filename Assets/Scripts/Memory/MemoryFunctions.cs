using Newtonsoft.Json;
using System.IO;
using UnityEngine;

namespace MemorySystem
{
    public class MemoryFunctions
    {
      
        public static void save<T>(T toSave, string path)
        {
            string json = JsonConvert.SerializeObject(toSave,new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            DataAccess.WriteFile(json, Path.Combine(Application.persistentDataPath, path));
        }

        public static T load<T>(string path)
        {
            string json = DataAccess.ReadFile(Path.Combine(Application.persistentDataPath,path));
            T toLoad = JsonConvert.DeserializeObject<T>(json);
            return toLoad;
        }

        public static bool pathExists(string path)
        {
            string dataPath = Path.Combine(Application.persistentDataPath, path);
            return File.Exists(dataPath);  
        }

        public static void CreateFolder(string path, string name)
        {
            string folderPath = Path.Combine(Application.persistentDataPath, path,name);
            DataAccess.CreateFolder(folderPath);
        }
        public static void DeleteFolder(string path, string name)
        {
            string folderPath = Path.Combine(Application.persistentDataPath, path, name);
            DataAccess.DeleteFolder(folderPath);
        }
    }
}