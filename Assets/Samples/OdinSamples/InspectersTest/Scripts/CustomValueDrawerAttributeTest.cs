using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

namespace Samples.OdinSamples.Inspecters.Scripts
{
    public class CustomValueDrawerAttributeTest : MonoBehaviour
    {
        [SerializeField, CustomValueDrawer("HaveLabelName")]
        private string haveLabelName ;
        
        [SerializeField, CustomValueDrawer("NoLabelName")]
        private string noLabelName ;

        [SerializeField] 
        private float max;
        
        [SerializeField] 
        private float min;

        [SerializeField, CustomValueDrawer("StaticCustomDrawerStatic")]
        private float CustomDrawerStatic;
        
        [SerializeField, CustomValueDrawer("StaticCustomDrawerDynamic")] 
        private float CustomDrawerDynamic;
        
        [SerializeField, CustomValueDrawer("MyStaticCustomDrawerArray")]
        private float[] CustomDrawerArray = new float[] { 3f, 5f, 6f };

#if UNITY_EDITOR
        
#endif
        private float MyStaticCustomDrawerArray(float value)
        {
            return EditorGUILayout.Slider("sliderTest", value, min, max);
        }

        private string HaveLabelName(string temp, GUIContent label)
        {
            return EditorGUILayout.TextField("TestLabelName", "TestTemp");
        }

        private string NoLabelName(string temp, GUIContent label)
        {
            return EditorGUILayout.TextField(temp);
        }

        private float StaticCustomDrawerStatic(float value, GUIContent label)
        {
            return EditorGUILayout.Slider(label, value, 0, 10);
        }
        
        private float StaticCustomDrawerDynamic(float value, GUIContent label)
        {
            return EditorGUILayout.Slider(label, value, min, max);
        }
    }
}