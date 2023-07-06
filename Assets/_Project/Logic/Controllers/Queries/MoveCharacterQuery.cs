using _Project.Controllers.Base;
using _Project.Repositories;
using RH_Utilities.Extensions;
using UniRx;

namespace _Project.Controllers.Queries
{
    public class MoveCharacterQuery : BaseQuery<UpdatePositionMessage>
    {
        private readonly CharactersViewsRepository _repository;

        public MoveCharacterQuery(CharactersViewsRepository repository, IMessageReceiver receiver) : base(receiver) => 
            _repository = repository;

        protected override void OnReceive(UpdatePositionMessage message) =>
            _repository
                .Get(message.CharacterId)
                .With(x => x.Move(message.Position.ToUnity()))
                .With(x => x.Rotate(message.LookDirection.ToUnity()));
    }
}