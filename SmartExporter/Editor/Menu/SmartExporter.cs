using UnityEngine;
using UnityEditor;

public class SmartExporter
{
    #region PRIVATE_VARIABLES

    private const string menuDependenciesTitle = "Assets/IndieYP/SmartExport/Dependencies";
    private const string menuFolderTitle = "Assets/IndieYP/SmartExport/Folder";

    #endregion

    [MenuItem(menuDependenciesTitle)]
    static void ExportDependencies()
    {
        Export(ExportPackageOptions.IncludeDependencies);
    }

    [MenuItem(menuFolderTitle)]
    static void ExportFolder()
    {
        Export( ExportPackageOptions.Recurse );
    }

    private static void Export(ExportPackageOptions exportPackageOptions)
    {
        var selectedObjs = Selection.objects;
        var assetPathNames = new string[selectedObjs.Length];
        for (var i = 0; i < selectedObjs.Length; i++)
        {
            assetPathNames[i] = AssetDatabase.GetAssetPath(selectedObjs[i]);
        }
        var packageName = "packageName";
        if (selectedObjs.Length == 1)
            packageName = selectedObjs[0].name;
        var savePath = EditorUtility.SaveFilePanel("Save package to folder", "", packageName, "unitypackage");
        if (string.IsNullOrEmpty(savePath))
            return;
        AssetDatabase.ExportPackage(assetPathNames, savePath, exportPackageOptions);
        EditorUtility.DisplayDialog("Export done", "To path : " + savePath, "OK");
    }
}
