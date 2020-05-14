/**
*	Author: #AUTHOR#
*	Version: #VERSION#
*	Date: #DATE#
*	Description: 
*/

using System;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public static class ToUTF8
{
    /// <summary>
    /// 把.cs转成UTF-8格式
    /// </summary>
    [MenuItem("Wonderland6627/Convert2UTF8")]
    public static void Convert2UTF8()
    {
        var dir = "Assets/Scripts/";//Directory.GetCurrentDirectory();
        foreach (var f in new DirectoryInfo(dir).GetFiles("*.cs", SearchOption.AllDirectories))
        {
            var s = File.ReadAllText(f.FullName, Encoding.Default);
            try
            {
                File.WriteAllText(f.FullName, s, Encoding.UTF8);
            }
            catch (Exception)
            {
                continue;
            }
        }
    }
}
