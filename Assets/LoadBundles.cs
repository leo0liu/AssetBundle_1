using UnityEngine;
using System.Collections;

public class LoadBundles : MonoBehaviour {

    
    void Start()
    {
        StartCoroutine(Load());
    }

    //用协程,使加载过程平滑不卡顿
    IEnumerator Load()
    {
        //设置需要加载物体的路径
        string _path ="file:///"+ Application.dataPath + "/bundles/people";
        Debug.Log(_path);
        //设置www加载方式
        WWW www = WWW.LoadFromCacheOrDownload(_path,2);
        yield return www;

        //初始化assetBundle
        AssetBundle bundle = www.assetBundle;

        //初始化AssetBundle的请求,说明加载哪一个物体
        AssetBundleRequest request = bundle.LoadAssetAsync("Sphere");
        yield return request;

        //把加载的物体强制转化成 GameObject
        GameObject prefab=request.asset as GameObject;

        //把这个预制创建出来
        Instantiate(prefab);

        //clean,清理哪些加载过程中的缓存
        bundle.Unload(false);
        www.Dispose();

    }



}
