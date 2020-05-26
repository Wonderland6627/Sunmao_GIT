/**
*	Author: Wonderland6627
*	Version: 0.0
*	Date: 2020-05-25 16:23:03
*	Description: 拼接提示控制器
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MasterCraftsman
{
    public class JointTipsController : MonoBehaviour
    {
        public Color constTipsColor;
        public Color flashTipsColor;
        public List<JointTips> jointTipsList;
        public List<Material> jointMatsList;

        private Material transparentMat;
        private const string TransparentMatPath = "Materials/TransparentMat";

        private void Start()
        {
            InitProperty();
        }

        private void InitProperty()
        {
            transparentMat = ResourcesManager.Load<Material>(TransparentMatPath);

            Renderer[] rds = GetComponentsInChildren<Renderer>();
            var length = rds.Length;
            if (length > 0)
            {
                for (int i = 0; i < length; i++)
                {
                    var mat = rds[i].material;
                    jointMatsList.Add(mat);

                    var jtips = rds[i].gameObject.AddComponent<JointTips>();
                    jointTipsList.Add(jtips);
                }
            }
            ReplaceMats();
            FlashOnTips();
        }

        public void ReplaceMats()
        {
            if(jointMatsList.Count > 0)
            {
                jointTipsList.ForEach((item) =>
                {
                    item.GetComponent<Renderer>().sharedMaterial = transparentMat;
                });
            }
        }

        /// <summary>
        /// 提示常亮
        /// </summary>
        public void ConstantOnTips()
        {
            jointTipsList.ForEach((item) =>
                {
                    item.ConstantOn(constTipsColor);
                });
        }

        public void ConstantOffTips()
        {
            jointTipsList.ForEach((item) =>
            {
                item.ConstantOff();
            });
        }

        public void FlashOnTips()
        {
            jointTipsList.ForEach((item) =>
            {
                item.FlashOn(flashTipsColor);
            });
        }

        public void FlashOffTips()
        {
            jointTipsList.ForEach((item) =>
            {
                item.ConstantOff();
            });
        }
    }
}