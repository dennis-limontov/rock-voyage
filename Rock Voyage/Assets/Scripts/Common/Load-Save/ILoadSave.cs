namespace RockVoyage
{
    public interface ILoadSave
    {
        public void Awake()
        {
            LoadSaveManager.loadSaveList.Add(this);
        }

        void Load(string loadData);

        string Save();
    }
}