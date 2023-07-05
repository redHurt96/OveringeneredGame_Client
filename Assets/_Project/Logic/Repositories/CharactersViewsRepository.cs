using System.Collections.Generic;
using UnityEngine;

namespace _Project.Repositories
{
    public class CharactersViewsRepository
    {
        public bool HasLocalPlayer => !string.IsNullOrEmpty(LocalCharacterId);
        public string LocalCharacterId { get; private set; }
        
        private readonly Dictionary<string, GameObject> _characters = new();

        public void Add(string characterId, GameObject gameObject, bool isLocal)
        {
            _characters.Add(characterId, gameObject);

            if (isLocal)
                LocalCharacterId = characterId;
        }

        public void Remove(string characterId) => 
            _characters.Remove(characterId);

        public GameObject Get(string characterId) => 
            _characters[characterId];
    }
}