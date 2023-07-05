using _Project.Controllers.Base;
using RH_Utilities.Extensions;
using UniRx;
using UnityEngine;
using static UnityEngine.Object;
using static UnityEngine.Resources;

namespace _Project.Controllers.Queries
{
    public class CreateWorldQuery : BaseQuery<CreateWorldMessage>
    {
        public CreateWorldQuery(IMessageReceiver receiver) : base(receiver) {}

        protected override void OnReceive(CreateWorldMessage message)
        {
            GameObject resource = Load("Ground") as GameObject;
            Instantiate(resource, message.Position.ToUnity(), Quaternion.identity)
                .With(x => x.transform.localScale = message.Scale.ToUnity());
        }
    }
}