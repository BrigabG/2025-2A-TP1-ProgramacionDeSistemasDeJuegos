using System;
using UnityEngine;

namespace Excercise1
{
    public abstract class Character : MonoBehaviour, ICharacter
    {
        [SerializeField] public string id;
        private CharacterStats stats;
        protected virtual void OnEnable()
        {
            // Register with the CharacterService
            if (!CharacterService.Instance.Register(id, this))
                Debug.LogWarning($"[Character] Failed to register character with id '{id}' (already existed?)");
        }

        protected virtual void OnDisable()
        {
            // Unregister from the CharacterService
            if (!CharacterService.Instance.Unregister(id))
                Debug.LogWarning($"[Character] Failed to unregister character with id '{id}'");
        }
    }
}
