using UnityEngine;
using UnityEditor;

public class ExportAssetBundles {

    [MenuItem("Assets/Build AssetBundle From Selection - Track dependencies")]
    static void ExportResource () {

        // 保存ウィンドウのパネルを表示
        string path = EditorUtility.SaveFilePanel ("Save Resource", "", "New Resource", "unity3d");
        if (path.Length != 0) {

            // アクティブなセレクションに対してリソースファイルをビルド
            Object[] selection = Selection.GetFiltered(typeof(Object), SelectionMode.DeepAssets);

            BuildPipeline.BuildAssetBundle( Selection.activeObject, selection, path, 
                BuildAssetBundleOptions.CollectDependencies | BuildAssetBundleOptions.CompleteAssets, BuildTarget.iOS);
                Selection.objects = selection;
        }
    }
}