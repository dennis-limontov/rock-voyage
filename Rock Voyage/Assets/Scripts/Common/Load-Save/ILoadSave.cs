namespace RockVoyage
{
    public interface ILoadSave
    {
        public string Name { get; }

        public void Awake()
        {
            LoadSaveManager.loadSaveList.TryAdd(Name, this);
        }

        void Load(string loadData);

        string Save();

        public void OnDestroy()
        {
            LoadSaveManager.loadSaveList.Remove(Name);
        }
    }
}