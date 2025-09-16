using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

namespace Samples.OdinSamples.InspectersTest.Scripts
{
    public class GUIColorTest : MonoBehaviour
    {
        [GUIColor(0.3f, 0.8f, 0.8f, 1f)]
        public int ColoredInt1;

        [GUIColor(0.3f, 0.8f, 0.8f, 1f)]
        public int ColoredInt2;
        
        [GUIColor("GetButtonColor")]
        [Button(ButtonSizes.Gigantic)]
        private static void IAmFabulous()
        {
            Debug.Log("测试");
        }
        
        [Button(ButtonSizes.Large)]
        [GUIColor("@Color.Lerp(Color.red, Color.green, Mathf.Sin((float)EditorApplication.timeSinceStartup))")]
        private static void Expressive_One()
        {
        }

        [Button(ButtonSizes.Large)]
        [GUIColor("CustomColor")]
        private static void Expressive_Two()
        {
        }

# if UNITY_EDITOR
        public Color CustomColor()
        {
            return Color.Lerp(Color.red, Color.green, Mathf.Sin((float)EditorApplication.timeSinceStartup));
        }
# endif

        private static Color GetButtonColor()
        {
            Sirenix.Utilities.Editor.GUIHelper.RequestRepaint();
            return Color.HSVToRGB(Mathf.Cos((float)UnityEditor.EditorApplication.timeSinceStartup + 1f) * 0.225f + 0.325f, 1, 1);
        }

        [ButtonGroup]
        [GUIColor(0, 1, 0)]
        private void Apply()
        {
            Debug.Log("应用");
        }

        [ButtonGroup]
        [GUIColor(1, 0.6f, 0.4f)]
        private void Cancel()
        {
            Debug.Log("取消");
        }
    }
}