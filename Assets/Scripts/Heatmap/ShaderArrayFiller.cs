using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ShaderArrayFiller : MonoBehaviour, IDataFetcher<Vector3>
{
    public Material material;
    public string name;            // The name of the array
    public Vector3[] array;        // The values

    public List<Vector3> Fetch(string dataName)
    {
        Debug.Log("fetching points!");
        return SetupTest(1023);
    }

    public List<Vector3> SetupTest(int size)
    {
        var list = new List<Vector3>();
        for (int i = 0; i < size/5; i++)
        {
            var vec = new Vector3(Random.Range(0, 30), Random.Range(0, 30), Random.Range(0, 30));
            list.Add(vec);
        }
        for (int i = size / 5; i < size; i++)
        {
            var vec = new Vector3(Random.Range(-50, 50), Random.Range(-50, 50), Random.Range(-50, 50));
            list.Add(vec);
        }
        return list;
    }

    public void UpdatePoints()
    {
        Debug.Log("updating points!");
        // Requires an array called "[name]"
        // and an int called "[name]_Length"
        material.SetInt(name + "_Length", array.Length);
        for (int i = 0; i < array.Length; i++)
            material.SetVectorArray(name, array.Select(t=>(Vector4)t).ToList());
    }
}