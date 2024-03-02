using UnityEngine;
using UnityEngine.UI;

namespace MemorySystem
{
    public class ResourceFunctions : MonoBehaviour
    {


        public static GameObject LoadPrefab(string path)
        {
            // Lade das Prefab aus den Ressourcen
            GameObject prefab = Resources.Load<GameObject>("Prefabs/" + path);

            if (prefab != null)
            {
                // Instanziere das Prefab
                GameObject instantiatedObject = Instantiate(prefab, Vector3.zero, Quaternion.identity);
                return instantiatedObject;
                // Hier kannst du weitere Aktionen mit der instanziierten GameObject-Instanz durchführen
            }
            else
            {
                Debug.LogError("Prefab konnte nicht aus den Ressourcen geladen werden. Stelle sicher, dass der Pfad korrekt ist.");
                return null;
            }
        }

        public static Sprite LoadImage(string path)
        {
            Sprite image = Resources.Load<Sprite>("Images/" + path);
            return image;
        }


        public static AudioClip LoadSound(string path)
        {
            // Implementiere die Logik zum Laden eines Sounds als AudioClip
            // Beispiel: return Resources.Load<AudioClip>(name);
            return null;
        }

        public static TerrainData LoadTerrain(string path)
        {
            TerrainData terrain = Resources.Load<TerrainData>(path);
            return terrain;
        }
    }
}