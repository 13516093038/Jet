using Sirenix.OdinInspector;
using UnityEngine;

namespace Samples.OdinSamples.InspectersTest.Scripts
{
    public class EnableGUITest : MonoBehaviour
    {
        [ShowInInspector]
        public int GUIDisabledProperty{get{return 20;}}
        
        [ShowInInspector, EnableGUI]
        public int GUIEnabledProperty{get{return 20;}}
    }
}