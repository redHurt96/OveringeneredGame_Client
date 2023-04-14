using System;
using _Project.Services;
using External.Utilities;
using UniRx;
using static UnityEngine.GameObject;
using static UnityEngine.PrimitiveType;

namespace _Project.Controllers
{
    public class CreateCharacterReceiver : IDisposable
    {
        private readonly CompositeDisposable _disposable;
        private readonly ICreateCharacterService _createCharacterService;

        public CreateCharacterReceiver(IMessageReceiver messageReceiver, ICreateCharacterService createCharacterService)
        {
            _createCharacterService = createCharacterService;
            _disposable = new();
            
            messageReceiver
                .Receive<CreateCharacterMessage>()
                .ObserveOnMainThread()
                .Subscribe(CreateCharacter)
                .AddTo(_disposable);
        }

        private void CreateCharacter(CreateCharacterMessage message)
        {
            _createCharacterService.Execute(new(message.X, message.Y, message.Z));
            
            CreatePrimitive(Capsule)
                .With(x => x.name = "Character")
                .With(x => x.transform.position = new(message.X, message.Y, message.Z));
        }

        public void Dispose() => 
            _disposable.Dispose();
    }
}