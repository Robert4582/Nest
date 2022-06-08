using System;
using UnityEditor;
using UnityEngine;

public class NestWindow : EditorWindow
{
    public string dataName;
    public IDataFetcher<Vector3> dataFetcher;
    public ShaderArrayFiller Filler;

    // Add menu item named "My Window" to the Window menu
    [MenuItem("Window/Nest")]
    public static void ShowWindow()
    {
        //Show existing window instance. If one doesn't exist, make one.
        EditorWindow.GetWindow(typeof(NestWindow)).name = nameof(NestWindow);
    }

    void OnGUI()
    {

        var fieldVal = EditorGUILayout.ObjectField(Filler, typeof(UnityEngine.Object), true) as GameObject;
        if (fieldVal != null)
            Filler = fieldVal.GetComponent<ShaderArrayFiller>();

        GUILayout.Label("Base Settings", EditorStyles.boldLabel);
        dataName = EditorGUILayout.TextField("Data Name", dataName);

        if (GUILayout.Button("Fetch Data"))
        {
            dataFetcher = Filler;
            Filler.array = dataFetcher.Fetch(dataName).ToArray();
            Filler.UpdatePoints();
        }
    }
}
