using UnityEngine;

namespace _Project.Code.Runtime.Data.Config
{
    [CreateAssetMenu(menuName = "_Project/Config/Level")]
    public class LevelConfig : ScriptableObject
    {
        [field: SerializeField] public string Name { get; private set; }
    }
}