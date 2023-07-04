using System;
using System.Reflection;
using UniRx;
using WebSocketSharp;
using static UniRx.MainThreadDispatcher;
using static UnityEngine.Debug;

namespace _Project
{
    public class SocketConnection : IDisposable
    {
        private WebSocket _webSocket;

        private readonly IMessagePublisher _messagePublisher;
        private readonly MessagesParser _messageParser;

        public SocketConnection(IMessagePublisher messagePublisher)
        {
            _messagePublisher = messagePublisher;
            _messageParser = new();
        }

        public void Execute()
        {
            _webSocket = new("ws://localhost:5000");
            _webSocket.OnOpen += (_, _) => Log("WebSocket connected");
            _webSocket.OnMessage += (sender, e) =>
            {
                Log($"Received message: {e.Data}");

                (Type target, object message) parsed = _messageParser.Deserialize(e.Data);
                MethodInfo method = typeof(MessageBroker).GetMethod("Publish");
                MethodInfo genericMethod = method.MakeGenericMethod(parsed.target);
                
                Send(_ => genericMethod.Invoke(_messagePublisher, new[] { parsed.message }), this);
            };
            
            _webSocket.Connect();
        }

        public void SendMessage<T>(T message)
        {
            string serialized = _messageParser.Serialize(message);
            Log($"Sent {serialized}");
            _webSocket.Send(serialized);
        }

        public void Dispose() => 
            _webSocket.Close();
    }
}
