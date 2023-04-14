using UniRx;
using UnityEngine;

namespace V2.Services
{
    public class CreateCharacterReceiver
    {
        private readonly MessageBroker _messageBroker;

        public CreateCharacterReceiver(MessageBroker messageBroker) => 
            _messageBroker = messageBroker;

        public void Start() {}
            // _messageBroker
            //     .Receive<CreateCharacterMessage>(x => CreateCharacter(x));

        private void CreateCharacter(CreateCharacterMessage message)
        {
            GameObject primitive = GameObject.CreatePrimitive(PrimitiveType.Capsule);
            primitive.name = "Character";
            primitive.transform.position = new(message.X, message.Y, message.Z);
        }
    }
}