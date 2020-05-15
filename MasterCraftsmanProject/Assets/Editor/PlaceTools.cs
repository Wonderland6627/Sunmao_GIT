using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public static class PlaceTools
{
    [MenuItem("Wonderland6627/PlaceTools/PlaceBox")]
    public static void PlaceBoxOnFloor()
    {
        Transform transform = Selection.activeTransform;
        if(transform == null)
        {
            Debug.LogError("NoSelectionTransform");
        }

        bool isCollider = true;//是否自带碰撞器，有的话不需要移除
        BoxCollider collider = transform.GetComponent<BoxCollider>();
        if (collider == null)
        {
            isCollider = false;
            collider = transform.gameObject.AddComponent<BoxCollider>();
        }

        Ray ray = new Ray(transform.position, Vector3.down);
        RaycastHit hit;
        if(Physics.Raycast(ray,out hit))
        {
            if (hit.collider)//向下的射线所遇到的物体有碰撞器
            {
                Debug.Log(hit.collider.name);
                if(transform.localScale.y == 1)//物体y轴上没有缩放，碰撞器的高度数据准确
                {
                    float offsetY = collider.size.y / 2;
                    float targetPosY = hit.point.y + offsetY;
                    Vector3 offsetVec = new Vector3(transform.localPosition.x, targetPosY, transform.localPosition.z);
                    transform.localPosition = offsetVec;
                }
                else
                {
                    Debug.LogError("Y!=1");
                }
            }
        }

        if (!isCollider)
        {
            Object.DestroyImmediate(collider);
        }
    }

    [MenuItem("Wonderland6627/PlaceTools/PlaceSphere")]
    public static void PlaceSphereOnFloor()
    {
        Transform transform = Selection.activeTransform;
        if (transform == null)
        {
            Debug.LogError("NoSelectionTransform");
        }

        bool isCollider = true;//是否自带碰撞器，有的话不需要移除
        SphereCollider collider = transform.GetComponent<SphereCollider>();
        if (collider == null)
        {
            isCollider = false;
            collider = transform.gameObject.AddComponent<SphereCollider>();
        }

        Ray ray = new Ray(transform.position, Vector3.down);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider)//向下的射线所遇到的物体有碰撞器
            {
                Debug.Log(hit.collider.name);
                if (transform.localScale.y == 1)//物体y轴上没有缩放，碰撞器的高度数据准确
                {
                    float offsetY = collider.radius;
                    float targetPosY = hit.point.y + offsetY;
                    Vector3 offsetVec = new Vector3(transform.localPosition.x, targetPosY, transform.localPosition.z);
                    transform.localPosition = offsetVec;
                }
                else
                {
                    Debug.LogError("Y!=1");
                }
            }
        }

        if (!isCollider)
        {
            Object.DestroyImmediate(collider);
        }
    }

    [MenuItem("Wonderland6627/PlaceTools/PlaceCapsule")]
    public static void PlaceCapsuleOnFloor()
    {
        Transform transform = Selection.activeTransform;
        if (transform == null)
        {
            Debug.LogError("NoSelectionTransform");
        }

        bool isCollider = true;//是否自带碰撞器，有的话不需要移除
        CapsuleCollider collider = transform.GetComponent<CapsuleCollider>();
        if (collider == null)
        {
            isCollider = false;
            collider = transform.gameObject.AddComponent<CapsuleCollider>();
        }

        Ray ray = new Ray(transform.position, Vector3.down);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider)//向下的射线所遇到的物体有碰撞器
            {
                Debug.Log(hit.collider.name);
                if (transform.localScale.y == 1)//物体y轴上没有缩放，碰撞器的高度数据准确
                {
                    float offsetY = collider.height / 2;
                    float targetPosY = hit.point.y + offsetY;
                    Vector3 offsetVec = new Vector3(transform.localPosition.x, targetPosY, transform.localPosition.z);
                    transform.localPosition = offsetVec;
                }
                else
                {
                    Debug.LogError("Y!=1");
                }
            }
        }

        if (!isCollider)
        {
            Object.DestroyImmediate(collider);
        }
    }

    //private static void CheckCollider(Transform transform, Object targetCollider)//检查碰撞器种类
    //{
    //    var collider = transform.GetComponent<Collider>();
    //    if(!(collider is Types.get targetCollider))
    //    {

    //    }
    //}
}
