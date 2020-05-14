/********************************************************************
	purpose:	閬靛惊Mono缁ф壙绾跨殑鍗曚欢瀹炵幇绫伙紙闈炵嚎绋嬪畨鍏級
*********************************************************************/
using System.Collections.Generic;
using UnityEngine;

public class GenericSingletonStat
{
    public delegate void DestroyDelegate();
    public static HashSet<DestroyDelegate> DestroyInstanceDelegate = new HashSet<DestroyDelegate>();
}

/// <summary>
/// 鍩虹被缁ф壙鏍戜腑鏈塎onoBehaviour绫荤殑鍗曚欢瀹炵幇锛岃繖绉嶅崟浠跺疄鐜版湁鍒╀簬鍑忓皯瀵瑰満鏅爲鐨勬煡璇㈡搷浣?
/// </summary>
public class GenericSingleton<T> : MonoBehaviour where T : Component
{
    // 鍗曚欢瀛愮被瀹炰緥
    private static T _instance;

    public static T Instance
    {
        get
        {
            return GetInstance();
        }
    }

    /// <summary>
    /// Awake娑堟伅锛岀‘淇濆崟浠跺疄渚嬬殑鍞竴鎬? 鍒犻櫎鏂板垱寤虹殑instance, 瑕佺‘淇濆瓙绫讳笉瑕佷娇鐢ˋwake
    /// </summary>
    protected virtual void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = GetComponent<T>();
            DontDestroyOnLoad(gameObject);
        }

        GenericSingletonStat.DestroyInstanceDelegate.Add(DestroyInstance);
    }

    // 鍦ㄥ崟浠朵腑锛屾瘡涓墿浠剁殑destroyed鏍囧織璁捐涓婂簲璇ュ垎鍓插湪涓嶅悓鐨勫瓨鍌ㄤ釜绌洪棿涓紝鍥犳锛屽拷鐣#鐨勮繖涓彁绀?
    // ReSharper disable once StaticFieldInGenericType
    // private static bool _destroyed;

    public static bool IsValidate()
    {
        return _instance != null;
    }

    /// <summary>
    /// 鑾峰緱鍗曚欢瀹炰緥锛屾煡璇㈠満鏅腑鏄惁鏈夎绉嶇被鍨嬶紝濡傛灉鏈夊瓨鍌ㄩ潤鎬佸彉閲忥紝濡傛灉娌℃湁锛屾瀯寤轰竴涓甫鏈夎繖涓猚omponent鐨刧ameobject
    /// 杩欑鍗曚欢瀹炰緥鐨凣ameObject鐩存帴鎸傛帴鍦╞ootroot鑺傜偣涓嬶紝鍦ㄥ満鏅腑鐨勭敓鍛藉懆鏈熷拰娓告垙鐢熷懡鍛ㄦ湡鐩稿悓锛屽垱寤鸿繖涓崟浠跺疄渚嬬殑妯″潡
    /// 蹇呴』閫氳繃DestroyInstance鑷绠＄悊鍗曚欢鐨勭敓鍛藉懆鏈?
    /// </summary>
    /// <returns>杩斿洖鍗曚欢瀹炰緥</returns>
    public static T GetInstance()
    {
        if (_instance == null/* && !_destroyed*/)
        {
            _instance = (T)FindObjectOfType(typeof(T));
            if (_instance == null)
            {
                var go = new GameObject(typeof(T).Name);

                _instance = go.AddComponent<T>();

                if (Application.isPlaying) // 闃叉缂栬緫鍣ㄥ唴浣跨敤鍑洪敊
                {
                    DontDestroyOnLoad(go);
                }
            }
        }
        return _instance;
    }

    /// <summary>
    /// 鍒犻櫎鍗曚欢瀹炰緥,杩欑缁ф壙鍏崇郴鐨勫崟浠剁敓鍛藉懆鏈熷簲璇ョ敱妯″潡鏄剧ず绠＄悊
    /// </summary>
    public static void DestroyInstance()
    {
        if (_instance != null)
        {
            Destroy(_instance.gameObject);
        }
        _instance = null;
    }

    /// <summary>
    /// OnDestroy娑堟伅锛岀‘淇濆崟浠剁殑闈欐€佸疄渚嬩細闅忕潃GameObject閿€姣?
    /// </summary>
    protected virtual void OnDestroy()
    {
        if (_instance != null && _instance.gameObject == gameObject)
        {
            _instance = null;
        }
        //_destroyed = true;
    }
}