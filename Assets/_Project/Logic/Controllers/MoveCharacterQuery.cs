using System;
using _Project.Repositories;
using RH_Utilities.Extensions;
using UniRx;

namespace _Project.Controllers
{
    public class MoveCharacterQuery : IDisposable
    {
        private readonly CompositeDisposable _disposable;
        private readonly CharactersViewsRepository _repository;

        public MoveCharacterQuery(CharactersViewsRepository repository, IMessageReceiver receiver)
        {
            _disposable = new();
            _repository = repository;
            
            receiver
                .Receive<UpdatePositionMessage>()
                .Subscribe(MoveCharacter)
                .AddTo(_disposable);
        }

        public void Dispose() => 
            _disposable.Dispose();

        private void MoveCharacter(UpdatePositionMessage message) =>
            _repository
                .Get(message.CharacterId)
                .transform.position = message.Position.ToUnity();
    }
}