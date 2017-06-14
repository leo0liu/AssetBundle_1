using UnityEditor;


public class ExporBundles  {

    //利用菜单栏,制作一个按钮
    [MenuItem ("Assets/ExportBundles")]

    //导出
    static void Export()
    {
        BuildPipeline.BuildAssetBundles("bundles"); //bundels在asset路径上创建一个文件夹保存导出的东西
    }
}
