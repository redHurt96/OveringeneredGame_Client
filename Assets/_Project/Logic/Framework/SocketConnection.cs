using System;
using System.Linq;
using System.Reflection;
using UniRx;
using WebSocketSharp;
using static UniRx.MainThreadDispatcher;
using static UnityEngine.Assertions.Assert;
using static UnityEngine.Debug;
using static UnityEngine.JsonUtility;

namespace _Project.Framework
{
    public class SocketConnection : IDisposable
    {
        private WebSocket _webSocket;

        private readonly IMessagePublisher _messagePublisher;

        public SocketConnection(IMessagePublisher messagePublisher) => 
            _messagePublisher = messagePublisher;

        public void Execute()
        {
            _webSocket = new("ws://localhost:5000");
            
            _webSocket.OnOpen += (sender, e) =>
            {
                Log("WebSocket connected");
            };
            
            _webSocket.OnMessage += (sender, e) =>
            {
                Log($"Received message: {e.Data}");

                string[] splitData = e.Data.Split(';');

                Assembly messagesAssemble = AppDomain.CurrentDomain
                    .GetAssemblies()
                    .First(x => x.FullName.Contains("OverengeeneredGame.Messages"));
                Type target = messagesAssemble.GetType(splitData[0]);
                object fromJson = FromJson(splitData[1], target);
                
                MethodInfo method = typeof(MessageBroker).GetMethod("Publish");
                IsNotNull(method);
                
                MethodInfo genericMethod = method.MakeGenericMethod(target);
                
                Send(_ => genericMethod.Invoke(_messagePublisher, new[] { fromJson }), this);
            };
            
            _webSocket.Connect();
        }

        public void Dispose() => 
            _webSocket.Close();
    }
}
