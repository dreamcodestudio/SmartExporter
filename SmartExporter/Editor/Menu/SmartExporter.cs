using UnityEngine;
using UnityEditor;

public class SmartExporter
{
    #region PRIVATE_VARIABLES

    private const string menuTitle = "Assets/IndieYP/SmartExport";

    #endregion

    [MenuItem(menuTitle)]
    static void Export()
    {
        var selectedObjs = Selection.objects;
        var assetPathNames = new string[selectedObjs.Length];
        for ( var i = 0; i < selectedObjs.Length; i++ )
        {
            assetPathNames[i] = AssetDatabase.GetAssetPath(selectedObjs[i]);
        }
        var packageName = "packageName";
        if ( selectedObjs.Length == 1 )
            packageName = selectedObjs[0].name;
        var savePath = EditorUtility.SaveFilePanel("Save package to folder", "", packageName, "unitypackage");
        if(string.IsNullOrEmpty( savePath ))
            return;
        AssetDatabase.ExportPackage( assetPathNames, savePath, ExportPackageOptions.IncludeDependencies );
        EditorUtility.DisplayDialog( "Export done", "To path : " + savePath, "OK" );
    }
}
