using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Samples.OdinSamples.InspectersTest.Scripts
{
    public class ValueDropdownTest : MonoBehaviour
    {
        [Title("下拉框")]
        [SerializeField, PropertySpace(40, 0), ValueDropdown("TextureSizes")]
        private int someSize1;
        
        private static int[] TextureSizes = new int[] { 32, 64, 128, 256, 512, 1024, 2048, 4096 };

        [Title("通用下拉框", "key-value形式")]
        [SerializeField, ValueDropdown("FriendlyTextureSizes")]
        private int someSize2;
        
        private static IEnumerable FriendlyTextureSizes = new ValueDropdownList<int>()
        {
            { "Small", 256 },
            { "Medium", 512 },
            { "Large", 1024 },
        };
        
        [Title("通用下拉框", "排序下拉对比组")]
        [SerializeField, ValueDropdown("SortList1"), PropertySpace(40, 0)]
        private int someSize3;
        
        private IEnumerable SortList1 = new ValueDropdownList<int>()
        {
            { "Small", 256 },
            { "Medium", 512 },
            { "Large", 1024 },
            { "A", 128 },
        };
        
        [Title("下拉框", "排序下拉框")]
        [SerializeField, ValueDropdown("SortList2", SortDropdownItems = true), PropertySpace(0, 40)]
        private int someSize4;
        private IEnumerable SortList2 = new ValueDropdownList<int>()
        {
            { "Small", 256 },
            { "Medium", 512 },
            { "Large", 1024 },
            { "A", 128 },
        };
        
        
        [Title("下拉框", "带标题下拉框")]
        [PropertySpace(0, 40)]
        [ValueDropdown("TextureSizes", DropdownTitle = "下拉条标题")]
        public int SomeSize5;
        
        [Title("下拉框", "设置下拉框高度")]
        [PropertySpace(0, 40)]
        [ValueDropdown("TextureSizes", DropdownHeight = 80)]
        public int SomeSize6;
        
        [Title("下拉框", "设置下拉框宽度")]
        [PropertySpace(0, 40)]
        [ValueDropdown("TextureSizes", DropdownWidth = 100)]
        public int SomeSize7;
        
        [Title("下拉框", "树形视图")]
        /*【FlattenTreeView】是否使用平铺的树形视图*/
        [PropertySpace(0, 40)]
        [SerializeField, ValueDropdown("TreeViewOfInts", SortDropdownItems = true)]//默认为false，如果设置为true则禁用树形结构使用平铺模式
        private int someSize8;
        
        [Title("下拉框", "双击")]
        /*【DoubleClickToConfirm】需要双击才能确地选中的内容*/
        [PropertySpace(0, 40)]
        [ValueDropdown("TreeViewOfInts", DoubleClickToConfirm = true)]//需要双击才能选中
        public int SomeSize9;
        
        /// <summary>
        /// 以“/”符号作为类别分隔符
        /// </summary>
        private IEnumerable TreeViewOfInts = new ValueDropdownList<int>()
        {
            { "Node 1 / Node 1.1", 1 },
            { "Node 1 / Node 1.2", 2 },
            { "Node 2 / Node 2.1", 3 },
            { "Node 3 / Node 3.1", 4 },
            { "Node 3 / Node 3.2", 5 },
            { "Node 1 / Node 3.1 / Node 3.1.1", 6 },
            { "Node 1 / Node 3.1 / Node 3.1.2", 7 },
            { "Node 1", -1 },
            { "Node 2", -2 },
            { "Node 3", -3 },
            { "Node 4", -4 },
        };
        
        /*【HideChildProperties】是否隐藏此类型所含有的属性信息*/
        [ValueDropdown("RangVector3", HideChildProperties = true)]//
        public Vector3 vector3HideChildProperties;
        [PropertySpace(0, 40)]
        [ValueDropdown("RangVector3", HideChildProperties = false)]//
        public Vector3 vector3ShowChildProperties;

        public IEnumerable<Vector3> RangVector3()
        {
            return Enumerable.Range(0, 10).Select(i => new Vector3(i, i, i));
        }
    }
}