using Sirenix.OdinInspector;
using UnityEngine;

namespace Samples.OdinSamples.InspectersTest.Scripts
{
    public class ReadOnlyTest : MonoBehaviour
    {
        [ShowInInspector, ReadOnly]
        private string myString = "这将显示为文本";

        [ShowInInspector, ReadOnly]
        private int myInt = 9001;

        [ShowInInspector, ReadOnly]
        private int[] myIntList = new int[] { 1, 2, 3, 4, 5, 6, 7, };
    }
}