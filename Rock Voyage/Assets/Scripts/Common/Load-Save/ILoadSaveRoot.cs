namespace RockVoyage
{
    public interface ILoadSaveRoot
    {
        public string Name { get; }

        public void Reset()
        {

        }
    }

    public static class ILoadSaveExtensions
    {
        public static void AddLoadSaveable(this ILoadSaveRoot instance)
        {
            if (instance.Name != null)
            {
                LoadSaveManager.Add(instance.Name, instance);
            }
        }

        public static void RemoveLoadSaveable(this ILoadSaveRoot instance)
        {
            if (instance.Name != null)
            {
                LoadSaveManager.Remove(instance.Name);
            }
        }
    }
}