/**
*	Author: Wonderland6627
*	Date: 2020-05-13 22:36:21
*	Version: 0.0
*	Description: 按钮按下事件
*/

using UnityEngine.UI;
using MasterCraftsman.Extends;

namespace MasterCraftsman
{
    public class ButtonClickListener : UIActionListener
    {
        Button attachedButton;
        void Start()
        {
            attachedButton = GetComponent<Button>();
            attachedButton.AddButtonClickEvent(Do);
        }

        void OnDestroy()
        {
            if (attachedButton != null && attachedButton.onClick != null)
            {
                attachedButton.onClick.RemoveListener(Do);
            }
        }
    }
}