/**
*	Author: #AUTHOR#
*	Version: #VERSION#
*	Date: #DATE#
*	Description: 
*/

using UnityEditor;
using UnityEngine;
using System.IO;
using System.Text;

public class AddFileHeadComment : UnityEditor.AssetModificationProcessor
{
    /// <summary>
    /// 此函数在Asset被创建完，文件已经生成到磁盘上，但是没有生成.meta文件和Import之前被调用
    /// </summary>
    /// <param name="newFileMeta">newFileMeta是由创建文件的path加上.meta组成的</param>
    public static void OnWillCreateAsset(string newFileMeta)
    {
        string newFilePath = newFileMeta.Replace(".meta", "");
        string fileExt = Path.GetExtension(newFilePath);
        if (fileExt != ".cs")
        {
            return;
        }
        //注意，Application.datapath会根据使用平台不同而不同
        string realPath = Application.dataPath.Replace("Assets", "") + newFilePath;
        string scriptContent = File.ReadAllText(realPath);

        //这里实现自定义的一些规则
        scriptContent = scriptContent.Replace("#AUTHOR#", "Wonderland6627");
        scriptContent = scriptContent.Replace("#VERSION#", MasterCraftsman.Version.SoftwareVersion);
        scriptContent = scriptContent.Replace("#DATE#", System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

        File.WriteAllText(realPath, scriptContent, Encoding.UTF8);
    }
}