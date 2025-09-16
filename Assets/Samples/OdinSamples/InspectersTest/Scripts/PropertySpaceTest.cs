using Sirenix.OdinInspector;
using UnityEngine;

namespace Samples.OdinSamples.InspectersTest.Scripts
{
    public class PropertySpaceTest : MonoBehaviour
    {
        [Space]
        public int unitySpace;

        [Space(5)]
        public int unitySpace1;
        [PropertySpace(1)]
        public int OdinSpace2;

        [ShowInInspector, PropertySpace]
        public int Property { get; set; }

        // 还可以控制PropertySpace属性前后的间距。
        [PropertySpace(SpaceBefore = 30, SpaceAfter = 30)]
        public int BeforeAndAfter;
        [PropertySpace(SpaceBefore = 30, SpaceAfter = 30)]
        public int BeforeAndAfter1;
    }
}