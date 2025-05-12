using System;
using UnityEngine;

namespace Excercise1
{
    public class Enemy : Character
    {
        [SerializeField] private EnemyStats stats;
        private ICharacter _player;
        private string _logTag;
        private Renderer _renderer;
        
        public void SetTarget(ICharacter target)
        {
            if (target == null)
                Debug.LogError($"{_logTag} Player not found!");
            _player = target;
            
        }
        
        private void Reset()
            => id = nameof(Enemy);

        private void Awake()
        {
            _logTag = $"{name}({nameof(Enemy).Colored("#555555")}):";
            _renderer = GetComponent<Renderer>();
        }
           

        
        private void Update()
        {
            if (_player == null)
                return;
            var direction = _player.transform.position - transform.position;
            transform.position += direction.normalized * (stats.speed * Time.deltaTime);
            _renderer.material.color = stats.color;
        }
    }
}