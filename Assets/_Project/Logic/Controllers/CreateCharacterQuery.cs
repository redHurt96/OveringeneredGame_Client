using System;
using _Project.Services;
using UniRx;

namespace _Project.Controllers
{
    public class CreateCharacterQuery : IDisposable
    {
        private readonly CompositeDisposable _disposable;
        private readonly CharacterViewFactory _factory;

        public CreateCharacterQuery(IMessageReceiver receiver, CharacterViewFactory factory)
        {
            _factory = factory;
            _disposable = new();
            
            receiver
                .Receive<CreateCharacterMessage>()
                .Subscribe(CreateCharacter)
                .AddTo(_disposable);
        }

        public void Dispose() => 
            _disposable.Dispose();

        private void CreateCharacter(CreateCharacterMessage message) => 
            _factory.Execute(message);
    }
}
