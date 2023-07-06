using _Project.Controllers.Queries;
using _Project.Repositories;
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
            CharacterView characterToRemove = _repository.Get(characterId);
            Destroy(characterToRemove.gameObject);
            
            _repository.Remove(characterId);
        }
    }
}