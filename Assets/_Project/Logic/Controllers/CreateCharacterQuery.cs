using System;
using RH_Utilities.Extensions;
using UniRx;
using Zenject;
using static UnityEngine.Object;
using static UnityEngine.Resources;

namespace _Project.Controllers
{
    public class CreateCharacterQuery : IDisposable
    {
        private readonly CompositeDisposable _disposable;
        private readonly IInstantiator _instantiator;
        private readonly IMessageReceiver _receiver;

        public CreateCharacterQuery(IMessageReceiver receiver, IInstantiator instantiator)
        {
            _receiver = receiver;
            _instantiator = instantiator;
            _disposable = new();
            
            receiver
                .Receive<CreateCharacterMessage>()
                .Subscribe(CreateCharacter)
                .AddTo(_disposable);
        }

        public void Dispose() => 
            _disposable.Dispose();

        private void CreateCharacter(CreateCharacterMessage message)
        {
            CharacterObserver resource = Load<CharacterObserver>("Character");
            CharacterObserver instance = Instantiate(resource);
            
            instance.Setup(message);
            instance
                .GetComponent<MoveCharacterQuery>()
                .Setup(message.CharacterId, _receiver);
            
            if (message.IsLocal)
            {
                _instantiator
                    .Instantiate<InputSystem>()
                    .With(x => x.Setup(message.CharacterId))
                    .AddTo(_disposable);
            }
        }
    }
}
