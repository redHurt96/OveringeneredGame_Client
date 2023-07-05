using _Project.Controllers.Base;
using _Project.Services;
using UniRx;

namespace _Project.Controllers.Queries
{
    public class RemoveCharacterQuery : BaseQuery<RemoveCharacterMessage>
    {
        private readonly RemoveCharacterService _removeCharacterService;

        public RemoveCharacterQuery(RemoveCharacterService removeCharacterService, IMessageReceiver receiver) : base(receiver) => 
            _removeCharacterService = removeCharacterService;

        protected override void OnReceive(RemoveCharacterMessage message) => 
            _removeCharacterService.Execute(message.CharacterId);
    }
}