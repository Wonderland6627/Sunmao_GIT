using UnityEngine;

namespace MasterCraftsman.Extends
{
    public static class FloatExtends
    {
        /// <summary>
        /// 判断浮点数是否在range范围之内
        /// </summary>
        public static bool IsRange(this float value, float range)
        {
            if (range == 0)
            {
                return true;
            }
            if (range > 0)
            {
                if (value >= -range && value <= range)
                {
                    return true;
                }
                return false;
            }
            else
            {
                if (value >= range && value <= -range)
                {
                    return true;
                }
                return false;
            }
        }

        /// <summary>
        /// min1,max1 min2,max2之间取值
        /// </summary>
        public static float RandomBetwenen(float min1, float max1, float min2, float max2)
        {
            float value = 0f;

            float random1 = Random.Range(min1, max1);
            float random2 = Random.Range(min2, max2);

            float random = Random.Range(0, 100);
            if (random % 2 == 0)
            {
                value = random1;
            }
            else
            {
                value = random2;
            }

            return value;
        }
    }
}