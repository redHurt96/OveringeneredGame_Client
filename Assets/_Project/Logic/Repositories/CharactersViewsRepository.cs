using System.Collections.Generic;
using _Project.Controllers.Queries;

namespace _Project.Repositories
{
    public class CharactersViewsRepository
    {
        public bool HasLocalPlayer => !string.IsNullOrEmpty(LocalCharacterId);
        public string LocalCharacterId { get; private set; }
        
        private readonly Dictionary<string, CharacterView> _characters = new();

        public void Add(string characterId, CharacterView gameObject, bool isLocal)
        {
            _characters.Add(characterId, gameObject);

            if (isLocal)
                LocalCharacterId = characterId;
        }

        public void Remove(string characterId) => 
            _characters.Remove(characterId);

        public CharacterView Get(string characterId) => 
            _characters[characterId];
    }
}