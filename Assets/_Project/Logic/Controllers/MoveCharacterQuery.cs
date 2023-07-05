using RH_Utilities.Attributes;
using RH_Utilities.Extensions;
using UniRx;
using UnityEngine;

namespace _Project.Controllers
{
    public class MoveCharacterQuery : MonoBehaviour
    {
        [SerializeField, ReadOnly] private string _characterId;
        
        private CompositeDisposable _disposable;

        public void Setup(string characterId, IMessageReceiver receiver)
        {
            _characterId = characterId;
            _disposable = new();
            
            receiver
                .Receive<UpdatePositionMessage>()
                .Subscribe(MoveCharacter)
                .AddTo(_disposable);
        }

        private void OnDestroy() => 
            _disposable.Dispose();

        private void MoveCharacter(UpdatePositionMessage message)
        {
            if (message.CharacterId == _characterId)
                transform.position = message.Position.ToUnity();
        }
    }
}