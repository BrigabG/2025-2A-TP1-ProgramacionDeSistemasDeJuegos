using System.Collections.Generic;
using UnityEngine;

namespace Excercise1
{
    public class CharacterService : MonoBehaviour
    {
        public static CharacterService Instance { get; private set; }

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        
        private readonly Dictionary<string, ICharacter> _charactersById = new();

        public bool Register(string id, ICharacter character)
        {
            if (string.IsNullOrWhiteSpace(id) || character == null)
                return false;

            return _charactersById.TryAdd(id, character);
        }
        public bool Unregister(string id)
        {
            return _charactersById.Remove(id);
        }
        public ICharacter Get(string id)
        {
            _charactersById.TryGetValue(id, out var character);
            return character;
        }
    }
}