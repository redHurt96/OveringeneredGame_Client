using System;
using _Project.Repositories;
using RH_Utilities.Extensions;
using UniRx;

namespace _Project.Controllers
{
    public class RemoveCharacterQuery : IDisposable
    {
        private readonly CompositeDisposable _disposable;
        private readonly CharactersViewsRepository _repository;

        public RemoveCharacterQuery(CharactersViewsRepository repository, IMessageReceiver receiver)
        {
            _disposable = new();
            _repository = repository;
            
            receiver
                .Receive<RemoveCharacterMessage>()
                .Subscribe(RemoveCharacter)
                .AddTo(_disposable);
        }

        public void Dispose() => 
            _disposable.Dispose();

        private void RemoveCharacter(RemoveCharacterMessage message) =>
            _repository.Remove(message.CharacterId);
    }
}