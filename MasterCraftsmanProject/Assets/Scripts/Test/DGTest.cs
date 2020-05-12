/**
*	Author: Wonderland6627
*	Date: 2020-05-12 21:36:24
*	Version: 0.0
*	Description: DGTest
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DGTest : MonoBehaviour 
{
    public GameObject cube;

    private void Start()
    {
        cube.transform.DOLocalMoveX(10, 2f).SetEase(Ease.Linear);
    }
}
