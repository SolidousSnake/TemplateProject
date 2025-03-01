﻿using System;
using System.Collections.Generic;
using VContainer;
using Object = UnityEngine.Object;

namespace _Project.Code.Runtime.Core.AssetManagement
{
    public class ConfigProvider
    {
        [Inject] private IAssetProvider _assetProvider;
        private readonly Dictionary<Type, Object> _singleConfigs = new();
        
        public void LoadSingle<T>(string path) where T : Object => _singleConfigs[typeof(T)] = _assetProvider.Load<T>(path);
        
        public T[] LoadMany<T>(string path) where T : Object => _assetProvider.LoadMany<T>(path);
        
        public T GetSingle<T>() where T : Object => _singleConfigs[typeof(T)] as T;
        
        public void Release<T>() where T : Object => _singleConfigs.Remove(typeof(T));
    }
}