using _Project.Controllers.Queries;
using _Project.Repositories;
using RH_Utilities.Extensions;
using static UnityEngine.Object;
using static UnityEngine.Resources;

namespace _Project.Services
{
    public class CharacterViewFactory
    {
        private readonly CharacterView _resource;
        private readonly CharactersViewsRepository _repository;
        
        public CharacterViewFactory(CharactersViewsRepository repository)
        {
            _repository = repository;
            _resource = Load<CharacterView>("Character");
        }

        public void Execute(CreateCharacterMessage message)
        {
            CharacterView instance = Instantiate(_resource);

            instance.Move(message.Position.ToUnity());
            instance.Stop();
            
            _repository.Add(message.CharacterId, instance, message.IsLocal);
        }
    }
}