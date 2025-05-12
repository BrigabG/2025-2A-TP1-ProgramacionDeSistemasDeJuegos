using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Excercise1
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private List<SceneRef> scenes = new();
        void AssignTargets()
        {
            var player = CharacterService.Instance.Get("Player");
            foreach (var enemy in FindObjectsOfType<Enemy>())
                enemy.SetTarget(player);
        }

        private async void Start()
        {
            foreach (var scene in scenes)
            {
                var loadSceneAsync = SceneManager.LoadSceneAsync(scene.Index, LoadSceneMode.Additive);
                if (loadSceneAsync == null)
                    continue;
                await loadSceneAsync;
            }
            AssignTargets();
        }
        
    }
    
}
