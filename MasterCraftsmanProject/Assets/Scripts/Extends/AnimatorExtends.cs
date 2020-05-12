using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MasterCraftsman.Extends
{
    public static class AnimatorExtends
    {
        /// <summary>
        /// 通过动画片段名称获取其长度 注意是clipname 不是statename
        /// </summary>
        public static float GetClipLengthByName(this Animator animator, string clipName)
        {
            AnimationClip[] animationClips = animator.runtimeAnimatorController.animationClips;
            foreach (var item in animationClips)
            {
                if (item.name == clipName)
                {
                    return item.length;
                }
            }
            return 0;
        }
    }
}