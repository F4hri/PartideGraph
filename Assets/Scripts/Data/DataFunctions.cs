using MemorySystem;

public class DataFunctions <T> where T : new()
{

    public static T content;


    public static void Load(string path)
    {
        content = MemoryFunctions.load<T>(path);
    }
    public static void Save(string path)
    {
        MemoryFunctions.save(content, path);
    }

    public static void Create(string path)
    {
        content = new T();
        Save(path);
    }
}
