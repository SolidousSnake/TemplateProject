using _Project.Code.Runtime.UI.Appearance;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Project.Code.Runtime.UI.View.States.Lobby
{
    [RequireComponent(typeof(BaseViewAppearance))]
    public class ShopStateView : MonoBehaviour
    {
        [FormerlySerializedAs("_behaviour")] [SerializeField] private BaseViewAppearance _appearance;

        public void Open() => _appearance.Open();
        public void Close() => _appearance.Close();
    }
}