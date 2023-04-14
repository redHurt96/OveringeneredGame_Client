using UniRx;
using UnityEngine;

namespace _Project.Controllers
{
    public class MoveCharacterSender
    {
        private readonly IMessagePublisher _publisher;

        public MoveCharacterSender(IMessagePublisher publisher) => 
            _publisher = publisher;

        public void Execute(Vector3 direction) =>
            _publisher.Publish<MoveCharacterMessage>(new()
            {
                X = direction.x,
                Y = direction.y,
                Z = direction.z,
            });
    }
}