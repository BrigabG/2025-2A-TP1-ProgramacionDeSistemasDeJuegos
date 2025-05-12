using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Excercise1
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private List<SceneRef> scenes = new();
        
        private async void Start()
        {
            foreach (var scene in scenes)
            {
                var loadSceneAsync = SceneManager.LoadSceneAsync(scene.Index, LoadSceneMode.Additive);
                if (loadSceneAsync == null)
                    continue;
                await loadSceneAsync;
            }
            var assigner = Object.FindAnyObjectByType<TargetAssigner>();
            if (assigner != null)
                assigner.TryAssignAllTargets();
            else
                Debug.LogWarning("GameManager: No TargetAssigner found in the scene.");
        }
    }
}
