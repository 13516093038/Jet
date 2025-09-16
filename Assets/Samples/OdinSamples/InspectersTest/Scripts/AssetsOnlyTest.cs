using Sirenix.OdinInspector;
using UnityEngine;

namespace Samples.OdinSamples.AssetsOnlyAttribute.Scripts
{
    public class AssetsOnlyTest : MonoBehaviour
    {
           [Sirenix.OdinInspector.AssetsOnly, SerializeField]
            GameObject assetsOnly;
        
           [SceneObjectsOnly, SerializeField]
           private GameObject sceneObjects;
    }
}