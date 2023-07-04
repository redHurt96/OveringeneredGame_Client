using System;
using UniRx;

namespace _Project.Controllers
{
    public class MoveCharacterCommand : IDisposable
    {
        private readonly CompositeDisposable _disposable;
        private readonly SocketConnection _connection;

        public MoveCharacterCommand(IMessageReceiver receiver, SocketConnection connection)
        {
            _connection = connection;
            _disposable = new();
            
            receiver
                .Receive<MoveMessage>()
                .Subscribe(SendMoveCharacter)
                .AddTo(_disposable);
        }

        public void Dispose() => 
            _disposable.Dispose();

        private void SendMoveCharacter(MoveMessage message) => 
            _connection.SendMessage(message);
    }
}