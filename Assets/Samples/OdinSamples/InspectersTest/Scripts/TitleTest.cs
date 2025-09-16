using Sirenix.OdinInspector;
using UnityEngine;

namespace Samples.OdinSamples.InspectersTest.Scripts
{
    public class TitleTest : MonoBehaviour
    {
        [Title("Static title")]
        public int C;

        [Title("Static title", "Static subtitle")]
        public int E;
        
        [Title("Non bold title", "$MySubtitle", bold: false)]
        public int I;

        [Title("Non bold title", "With no line seperator", horizontalLine: false, bold: false)]
        public int K;


        private string MySubtitle()
        {
            return "测试副标题！";
        }
    }
}