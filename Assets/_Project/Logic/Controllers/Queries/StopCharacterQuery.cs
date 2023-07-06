using _Project.Controllers.Base;
using _Project.Repositories;
using UniRx;

namespace _Project.Controllers.Queries
{
    public class StopCharacterQuery : BaseQuery<StopCharacterMessage>
    {
        private readonly CharactersViewsRepository _repository;

        public StopCharacterQuery(CharactersViewsRepository repository, IMessageReceiver receiver) : base(receiver) => 
            _repository = repository;

        protected override void OnReceive(StopCharacterMessage message) =>
            _repository
                .Get(message.CharacterId)
                .Stop();
    }
}