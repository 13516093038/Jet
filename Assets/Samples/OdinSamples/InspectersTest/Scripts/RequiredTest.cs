using Sirenix.OdinInspector;
using UnityEngine;

namespace Samples.OdinSamples.InspectersTest.Scripts
{
    public class RequiredTest : MonoBehaviour
    {
        [ShowInInspector, Required("测试自定义消息")]
        private GameObject gameObject0;
        
        [ShowInInspector, Required]
        private GameObject gameObject1;
        
        [Required("$ReturnStringFunction")]
        public GameObject GameObject_DynamicMessage1;
        
        [Required("$ReturnStringFunction", InfoMessageType.None)]
        public GameObject GameObject_None;
        [Required("$ReturnStringFunction", InfoMessageType.Info)]
        public GameObject GameObject_Info;
        [Required("$ReturnStringFunction", InfoMessageType.Warning)]
        public GameObject GameObject_Warning;
        [Required("$ReturnStringFunction",InfoMessageType.Error)]
        public GameObject GameObject_Error;
        
        public string ReturnStringFunction()
        {
            return "测试哦";
        }
    }
}