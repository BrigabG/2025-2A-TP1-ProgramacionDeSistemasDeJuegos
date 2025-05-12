using UnityEngine;

namespace Excercise1
{
    public class Player : Character
    {
        [SerializeField] private PlayerStats stats;
        private Renderer _renderer;


        private void Awake()
            => _renderer = GetComponent<Renderer>();
        private void Reset()
            => id = nameof(Player);

        private void Update()
        {
            transform.position = new Vector3(Mathf.Cos(Time.time * stats.speed) * stats.amplitude,
                                             Mathf.Sin(Time.time * stats.speed) * stats.amplitude,
                                             transform.position.z);
            _renderer.material.color = stats.color;
        }
    }
}