 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MasterCraftsman.Extends
{
    public static class DataStructureExtends
    {
        /// <summary>
        /// 防止空栈Pop
        /// </summary>
        public static T SafePop<T>(this Stack<T> stack)
        {
            if (stack.Count > 0)
            {
                return stack.Pop();
            }
            return default(T);
        }

        /// <summary>
        /// 防止空栈Peek
        /// </summary>
        public static T SafePeek<T>(this Stack<T> stack)
        {
            if (stack.Count > 0)
            {
                return stack.Peek();
            }
            return default(T);
        }
    }
}
