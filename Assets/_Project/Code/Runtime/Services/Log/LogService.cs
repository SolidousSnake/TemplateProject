using UnityEngine;

namespace _Project.Code.Runtime.Services.Log
{
    public class LogService : ILogService
    {
        public void Log(string message) => Debug.Log(message);
        public void LogWarning(string message) => Debug.LogWarning(message);
        public void LogError(string message) => Debug.LogError(message);
    }
}