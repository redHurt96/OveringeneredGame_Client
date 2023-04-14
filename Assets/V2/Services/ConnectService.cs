using System;
using System.Reflection;
using UniRx;
using UnityEngine;
using WebSocketSharp;
using static UnityEngine.JsonUtility;

namespace V2.Services
{
    public class ConnectService : IDisposable
    {
        private WebSocket _webSocket;
        
        private readonly MessageBroker _messageBroker;

        public ConnectService(MessageBroker messageBroker) => 
            _messageBroker = messageBroker;

        public void Start()
        {
            _webSocket = new("ws://localhost:5000");
            
            _webSocket.OnOpen += (sender, e) =>
            {
                Debug.Log("WebSocket connected");
            };
            
            _webSocket.OnMessage += (sender, e) =>
            {
                Debug.Log($"Received message: {e.Data}");

                string[] splitData = e.Data.Split(';');
                Type target = Type.GetType(splitData[0]);
                object fromJson = FromJson(splitData[1], target);
                
                MethodInfo method = typeof(MessageBroker).GetMethod("Publish");
                MethodInfo genericMethod = method.MakeGenericMethod(target);
                genericMethod.Invoke(_messageBroker, new[] { fromJson });
                
                //Default.Publish(fromJson);
            };
            
            _webSocket.Connect();
        }

        public void Dispose() => 
            _webSocket.Close();
    }
}
