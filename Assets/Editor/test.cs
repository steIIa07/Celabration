using UnityEditor;
using UnityEngine;

public class test : MonoBehaviour
{
    [SerializeField]
    ScriptableObject a, b, c, d;

    void Start()
    {
        EditorUtility.SetDirty(a);
        EditorUtility.SetDirty(b);
        EditorUtility.SetDirty(c);
        EditorUtility.SetDirty(d);
        AssetDatabase.SaveAssets();
    }
}