using Sirenix.OdinInspector;
using UnityEngine;

namespace Samples.OdinSamples.InspectersTest.Scripts
{
    public class PropertyOrderTest : MonoBehaviour
    {
        [PropertyOrder(1)]
        public int Second;

        [InfoBox("PropertyOrder用于更改inspector中属性的顺序", InfoMessageType.Info, VisibleIf = "VisibleFunction")]
        [PropertyOrder(-1)]
        public int First;

#if UNITY_EDITOR
        private bool VisibleFunction()
        {
            return true;
        }
#endif
    }
}