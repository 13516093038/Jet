using Sirenix.OdinInspector;
using UnityEngine;

namespace Samples.OdinSamples.InspectersTest.Scripts
{
    public class DetailedInfoBoxTest : MonoBehaviour
    {
        [SerializeField, DetailedInfoBox("简介消息", "默认情况下VisibleIf为True,所以此消息可见", InfoMessageType = InfoMessageType.None)]
        private string noneMessage = "无";

        [SerializeField,
         DetailedInfoBox("简介消息", "默认情况下VisibleIf为True，所以此消息框可见", InfoMessageType = InfoMessageType.Info)]
        private string infoMessage = "无";

        [SerializeField,
         DetailedInfoBox("简介消息", "默认情况下VisibleIf为True，所以此消息框可见", InfoMessageType = InfoMessageType.Warning)]
        private string warningMessage = "无";

        [SerializeField,
         DetailedInfoBox("简介消息", "默认情况下VisibleIf为True，所以此消息框可见", InfoMessageType = InfoMessageType.Error)]
        private string errorMessage = "无";

        [SerializeField, DetailedInfoBox("简介消息", "默认情况下VisibleIf为True。" +
                                 "所以此消息框可见.还可以通过一个方法的返回值（bool）来控制消息框是否显示，" +
                                 "例如在这个函数中判断此字段是否为null，如果为null在出现弹窗提示等。",
            InfoMessageType = InfoMessageType.None, VisibleIf = "VisibleFunction")]
        private string haveVisibleIfMessage = "";

        [SerializeField, DetailedInfoBox("简介消息", "还可以通过一个方法的返回值（bool）来控制消息框是否显示，例如在这个函数中判断此字段是否为null，如果为null在出现弹窗提示等。",
            InfoMessageType = InfoMessageType.Error, VisibleIf = "NoVisibleFunction")]
        private string noVisibleIfMessage = "";

        public bool VisibleFunction()
        {
            /*
             * 根据情况下选择返回true或者false，让对应的消息框显示或者不显示
             */
            return true;
        }

        public bool NoVisibleFunction()
        {
            return string.IsNullOrEmpty(noVisibleIfMessage);
        }
    }
}