using _Project.Code.Runtime.Data.Enum;
using UnityEngine;

namespace _Project.Code.Runtime.Data.Config
{
    [CreateAssetMenu(menuName = "_Project/Config/Wallet/Currency")]
    public class CurrencyConfig : ScriptableObject
    {
        [field: SerializeField] public CurrencyType Type { get; private set; }
        [field: SerializeField] public Sprite Icon { get; private set; }
    }
}