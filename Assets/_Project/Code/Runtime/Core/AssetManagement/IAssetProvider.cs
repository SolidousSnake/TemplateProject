﻿using UnityEngine;

namespace _Project.Code.Runtime.Core.AssetManagement
{
    public interface IAssetProvider
    {
        public T Load<T>(string path) where T : Object;

        public T[] LoadMany<T>(string path) where T : Object;
    }
}