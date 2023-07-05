using _Project.Controllers.Base;
using _Project.Repositories;
using UniRx;

namespace _Project.Controllers.Queries
{
    public class RemoveCharacterQuery : BaseQuery<RemoveCharacterMessage>
    {
        private readonly CharactersViewsRepository _repository;

        public RemoveCharacterQuery(CharactersViewsRepository repository, IMessageReceiver receiver) : base(receiver) => 
            _repository = repository;

        protected override void OnReceive(RemoveCharacterMessage message) => 
            _repository.Remove(message.CharacterId);
    }
}