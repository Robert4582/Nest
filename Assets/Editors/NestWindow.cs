using System;
using UnityEditor;
using UnityEditor.SceneManagement;
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
        var window = (NestWindow)EditorWindow.GetWindow(typeof(NestWindow));
        window.Init();
    }

    private void OnDestroy()
    {
        EditorSceneManager.sceneOpened -= TryFindDataShowcase;
    }

    public void Init()
    {
        name = nameof(NestWindow);
        TryFindDataShowcase(new UnityEngine.SceneManagement.Scene(), OpenSceneMode.Single);
        EditorSceneManager.sceneOpened += TryFindDataShowcase;
    }

    public void TryFindDataShowcase(UnityEngine.SceneManagement.Scene scene, OpenSceneMode mode)
    {
        var obj = FindObjectOfType<ShaderArrayFiller>();
        if (obj != null)
        {
            Filler = obj;
        }
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
