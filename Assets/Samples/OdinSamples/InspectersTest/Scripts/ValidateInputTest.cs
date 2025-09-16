using Sirenix.OdinInspector;
using UnityEngine;

namespace Samples.OdinSamples.InspectersTest.Scripts
{
    public class ValidateInputTest :  MonoBehaviour
    {
        [SerializeField, ValidateInput("MustBeNull", "这个字段应该为空。")]
        private MyScripty defaultMessage;
        
        [ReadOnly]
        public string dynamicMessage = "这个物体不应该为空！";
        [ValidateInput("CheckGameObject", "$dynamicMessage", InfoMessageType.None)]
        public GameObject targetObj_None = null;
        [ValidateInput("CheckGameObject", "$dynamicMessage", InfoMessageType.Info)]
        public GameObject targetObj_Info = null;
        [ValidateInput("CheckGameObject", "$dynamicMessage", InfoMessageType.Warning)]
        public GameObject targetObj_Warning = null;
        [ValidateInput("CheckGameObject", "$dynamicMessage", InfoMessageType.Error)]
        public GameObject targetObj_Error = null;
        
        private bool CheckGameObject(GameObject tempObj)
        {
            return tempObj != null;
        }
        
        private bool MustBeNull(MyScripty scripty)
        {
            return scripty == null;
        }
    }
}