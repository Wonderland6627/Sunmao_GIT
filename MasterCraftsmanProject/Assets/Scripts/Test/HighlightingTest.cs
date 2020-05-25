/**
*	Author: Wonderland6627
*	Version: 0.0
*	Date: 2020-05-25 16:10:11
*	Description: 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MasterCraftsman.Extends;

public class HighlightingTest : MonoBehaviour 
{
    private HighlightableObject hlObj;

    private void Start()
    {
        hlObj = gameObject.AddorGetComponent<HighlightableObject>();
        hlObj.FlashingOn();
    }
}
