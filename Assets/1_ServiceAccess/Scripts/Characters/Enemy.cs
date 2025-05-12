using UnityEngine;

namespace Excercise1
{
    public class Enemy : Character
    {
        [SerializeField] private float speed = 5;
        private ICharacter _player;
        private string _logTag;
        
        public void SetTarget(ICharacter target)
        {
            if (target == null)
                Debug.LogError($"{_logTag} Player not found!");
            _player = target;
            
        }
        
        private void Reset()
            => id = nameof(Enemy);

        private void Awake()
            => _logTag = $"{name}({nameof(Enemy).Colored("#555555")}):";

        
        private void Update()
        {
            if (_player == null)
                return;
            var direction = _player.transform.position - transform.position;
            transform.position += direction.normalized * (speed * Time.deltaTime);
        }
    }
}