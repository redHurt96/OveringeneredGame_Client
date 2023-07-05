using RH_Utilities.Extensions;
using UnityEngine;
using static UnityEngine.Object;
using static UnityEngine.Resources;

namespace _Project.Services
{
    public class WorldViewFactory
    {
        public void Execute(Vector3 position, Vector3 scale) =>
            Instantiate(Load("Ground") as GameObject, position, Quaternion.identity)
                .With(x => x.transform.localScale = scale);
    }
}