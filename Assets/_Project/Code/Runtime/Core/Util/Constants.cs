﻿namespace _Project.Code.Runtime.Core.Util
{
    public static class Constants
    {
        public const int DefaultCollectionCapacity = 32;
        public const string PlayerProgress = "/playerdata.data";
        
        public static class Time
        {
            public const float ResumedValue = 1f;
            public const float PausedValue = 0f;
        }
        
        public static class Scene
        {
            public const string Boot = "Boot";
            public const string Game = "Game";
            public const string Lobby = "Lobby";
        }

        public static class Audio
        {
            public const float DefaultValue = 1f;
            public const float MuteValue = -80;
            public const float MaxValue = 20f;
            
            public const string Master = "Master";
            public const string Music = "Music";
            public const string SFX = "SFX";
        }
    }
}