using System;
using UnityEditor;
using UnityEditor.Experimental.AssetImporters;
using UnityEngine;

namespace CSharp.Editor.Utils
{
    public class UFGameObjectUtils
    {
        private const string UtilsPrefix = "Tools/EditorUtils";

        [MenuItem(UtilsPrefix + "/ClearMissingScript")]
        public static void ClearMissingMonoBehaviours()
        {
            try
            {
                AssetDatabase.StartAssetEditing();
                var guids = AssetDatabase.FindAssets("t:prefab");
                foreach (var guid in guids)
                {
                    var path = AssetDatabase.GUIDToAssetPath(guid);
                    var go = AssetDatabase.LoadAssetAtPath<GameObject>(path);
                    if (go)
                    {
                        if (GameObjectUtility.GetMonoBehavioursWithMissingScriptCount(go) > 0)
                            GameObjectUtility.RemoveMonoBehavioursWithMissingScript(go);
                    }
                }
            }
            finally
            {
                AssetDatabase.StopAssetEditing();
            }
        }
    }
}