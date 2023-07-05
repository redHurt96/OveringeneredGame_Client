using _Project.Controllers.Base;
using _Project.Services;
using RH_Utilities.Extensions;
using UniRx;

namespace _Project.Controllers.Queries
{
    public class CreateWorldQuery : BaseQuery<CreateWorldMessage>
    {
        private readonly WorldViewFactory _factory;
        
        public CreateWorldQuery(IMessageReceiver receiver, WorldViewFactory factory) : base(receiver) => 
            _factory = factory;

        protected override void OnReceive(CreateWorldMessage message) => 
            _factory.Execute(message.Position.ToUnity(), message.Scale.ToUnity());
    }
}