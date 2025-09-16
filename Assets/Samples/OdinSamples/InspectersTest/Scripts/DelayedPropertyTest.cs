using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Samples.OdinSamples.InspectersTest.Scripts
{
    public class DelayedPropertyTest  : MonoBehaviour
    {
        [SerializeField, OnValueChanged("ValueChangeCallBack")]
        private int field;
        
        [ShowInInspector, OnValueChanged("ValueChangeCallBack")]
        public int Property { get; set; }
        
        [SerializeField, Delayed, OnValueChanged("ValueChangeCallBack")]
        private int delayedField;
        
        [ShowInInspector, OnValueChanged("ValueChangeCallBack"), DelayedProperty]
        public int DelayedProperty { get; set; }

        public void ValueChangeCallBack()
        {
            Debug.Log("数值变化");
        }
    }
}