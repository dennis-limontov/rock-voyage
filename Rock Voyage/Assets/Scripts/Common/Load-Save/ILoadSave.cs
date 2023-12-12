namespace RockVoyage
{
    public interface ILoadSave
    {
        public string Name { get; }

        public void Awake()
        {
            LoadSaveManager.Add(Name, this);
        }

        void Load(string loadData);

        string Save();

        public void OnDestroy()
        {
            LoadSaveManager.Remove(Name);
        }
    }
}