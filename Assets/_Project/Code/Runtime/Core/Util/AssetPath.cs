namespace _Project.Code.Runtime.Core.Util
{
    public static class AssetPath
    {
        public static class Config
        {
            private const string MainFolder = "Config/";
            public const string Level = MainFolder + "Level";
        }
        
        public static class Prefab
        {
            private const string MainFolder = "Prefab/";

            public static class UI
            {
                public const string SelectLevelButton = MainFolder + "UI/Button/Select Level Button Prefab";
            }
        }
    }
}