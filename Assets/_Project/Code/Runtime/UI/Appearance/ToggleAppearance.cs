namespace _Project.Code.Runtime.UI.Appearance
{
    public class ToggleAppearance : BaseViewAppearance
    {
        public override void Open() => gameObject.SetActive(true);
        public override void Close() =>  gameObject.SetActive(false);
    }
}