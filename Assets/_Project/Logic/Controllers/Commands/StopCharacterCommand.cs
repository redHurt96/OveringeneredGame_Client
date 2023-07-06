using System;
using UniRx;

namespace _Project.Controllers.Commands
{
    public class StopCharacterCommand : IDisposable
    {
        private readonly CompositeDisposable _disposable;
        private readonly SocketConnection _connection;

        public StopCharacterCommand(IMessageReceiver receiver, SocketConnection connection)
        {
            _connection = connection;
            _disposable = new();
            
            receiver
                .Receive<StopMovementMessage>()
                .Subscribe(SendStopCharacter)
                .AddTo(_disposable);
        }

        public void Dispose() => 
            _disposable.Dispose();

        private void SendStopCharacter(StopMovementMessage message) => 
            _connection.SendMessage(message);
    }
}