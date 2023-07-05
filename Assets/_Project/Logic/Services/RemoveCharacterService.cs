using _Project.Repositories;
using UnityEngine;
using static UnityEngine.Object;

namespace _Project.Services
{
    public class RemoveCharacterService
    {
        private readonly CharactersViewsRepository _repository;

        public RemoveCharacterService(CharactersViewsRepository repository) => 
            _repository = repository;

        public void Execute(string characterId)
        {
            GameObject characterToRemove = _repository.Get(characterId);
            Destroy(characterToRemove);
            
            _repository.Remove(characterId);
        }
    }
}