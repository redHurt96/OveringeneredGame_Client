using _Project.Repositories;
using RH_Utilities.Extensions;
using UnityEngine;
using static UnityEngine.Object;
using static UnityEngine.Resources;

namespace _Project.Services
{
    public class CharacterViewFactory
    {
        private GameObject _resource;
        
        private readonly CharactersViewsRepository _repository;
        
        public CharacterViewFactory(CharactersViewsRepository repository) => 
            _repository = repository;

        public void Execute(CreateCharacterMessage message)
        {
            _resource ??= Load("Character") as GameObject;
            GameObject instance = Instantiate(_resource);

            instance.transform.position = message.Position.ToUnity();

            _repository.Add(message.CharacterId, instance.gameObject, message.IsLocal);
        }
    }
}