using _Project.Controllers.Base;
using _Project.Services;
using UniRx;

namespace _Project.Controllers.Queries
{
    public class CreateCharacterQuery : BaseQuery<CreateCharacterMessage>
    {
        private readonly CharacterViewFactory _characterViewFactory;

        public CreateCharacterQuery(IMessageReceiver receiver, CharacterViewFactory characterViewFactory) : base(receiver) => 
            _characterViewFactory = characterViewFactory;

        protected override void OnReceive(CreateCharacterMessage message) => 
            _characterViewFactory.Execute(message);
    }
}
