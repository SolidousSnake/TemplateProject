#if UNITY_EDITOR

using System.Linq;
using _Project.Code.Runtime.Core.Util;
using UnityEditor;
using UnityEngine.SceneManagement;

namespace _Project.Code.Runtime.Flow.Boot
{
    [InitializeOnLoad]
    public class BootFromAnyScene
    {
        static BootFromAnyScene()
        {
            EditorApplication.playModeStateChanged += Run;
        }

        private static void Run(PlayModeStateChange state)
        {
            if (state != PlayModeStateChange.EnteredPlayMode)
                return;

            EditorApplication.playModeStateChanged -= Run;
            
            var currentScene = SceneManager.GetActiveScene();
            
            if (currentScene.name == Constants.Scene.Boot)
                return;
            
            if (IsSceneInBuild(currentScene))
                SceneManager.LoadScene(Constants.Scene.Boot);
        }

        private static bool IsSceneInBuild(Scene currentScene) 
            => EditorBuildSettings.scenes.Any(s => s.path == currentScene.path);
    }
}
#endif