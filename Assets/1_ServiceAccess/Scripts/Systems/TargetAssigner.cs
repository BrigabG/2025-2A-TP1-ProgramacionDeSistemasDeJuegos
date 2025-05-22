using UnityEngine;

namespace Excercise1
{
    public class TargetAssigner : MonoBehaviour
    {
        [SerializeField] private string playerId = "Player";
        
        public void TryAssignAllTargets()
        {
            var player = CharacterService.Instance.Get(playerId);
            if (player == null)
            {
                Debug.LogError($"TargetAssigner: no Character with id '{playerId}'");
                return;
            }
            var enemies = Object.FindObjectsByType<Enemy>(FindObjectsSortMode.None);
            if (enemies.Length == 0)
                Debug.LogWarning("TargetAssigner: no Enemy instances found.");

            foreach (var enemy in enemies)
                enemy.SetTarget(player);
        }
    }

}
