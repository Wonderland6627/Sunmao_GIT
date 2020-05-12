/*
    Wonderland6627
    时间：2019.11.30
    说明：计算工程编译时间
*/
using System;
using UnityEditor;
using UnityEngine;

[InitializeOnLoad]
public class CompilerMeasurer
{
    const string compilingKey = "Compiling";
    const string compilingTimeKey = "comilingTimeKey";
    static bool compiling;

    static CompilerMeasurer()
    {
        compiling = EditorPrefs.GetBool(compilingKey, false);
        EditorApplication.update += Update;
    }

    static void Update()
    {
        if(compiling && !EditorApplication.isCompiling)
        {
            Debug.Log(string.Format("编译完成{0}", DateTime.Now));
            compiling = false;
            EditorPrefs.SetBool(compilingKey, false);

            string compilingTime = EditorPrefs.GetString(compilingTimeKey);
            long compilingTimeLong;
            if (!string.IsNullOrEmpty(compilingTime) && long.TryParse(compilingTime, out compilingTimeLong))
            {
                double duration = (DateTime.Now - DateTime.FromFileTime(compilingTimeLong)).TotalSeconds;
                Debug.Log(string.Format("<color=blue>编译用时{0}秒</color>", duration));
            }
        }
        else if(!compiling && EditorApplication.isCompiling)
        {
            Debug.Log(string.Format("编译开始{0}", DateTime.Now));
            compiling = true;
            EditorPrefs.SetBool(compilingKey, true);

            long compileTime = DateTime.Now.ToFileTime();
            EditorPrefs.SetString(compilingTimeKey, compileTime.ToString());
        }
    }
}