using System.Collections.Generic;
using UnityEngine;

namespace _Project.Code.Runtime.Core.Updater
{
    public class GlobalUpdater : MonoBehaviour
    {
        private readonly HashSet<IUpdateable> _updateables = new();

        public void Initialize() => DontDestroyOnLoad(this);
        
        public void Add(IUpdateable updateable) => _updateables.Add(updateable);
        public void Remove(IUpdateable updateable) => _updateables.Remove(updateable);

        public void Update()
        {
            foreach (var item in _updateables) 
                item.Update(Time.deltaTime);
        }
    }
}