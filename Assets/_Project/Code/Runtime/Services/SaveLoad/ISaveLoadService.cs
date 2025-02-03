using _Project.Code.Runtime.Data.Persistent;

namespace _Project.Code.Runtime.Services.SaveLoad
{
    public interface ISaveLoadService
    {
        public void Save(PlayerProgress playerProgress);
        public PlayerProgress Load();
        public void Reset();
    }
}