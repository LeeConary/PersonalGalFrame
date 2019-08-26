﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
#if UNITY_EDITOR
public class SaveWindow : EditorWindow
{
    string txtName;

    private void OnGUI()
    {
        GUILayout.BeginVertical("Box");
        txtName = EditorGUILayout.TextField("脚本名字", txtName);
        if (GUILayout.Button("保存", GUILayout.Width(200)))
        {
            //保存逻辑
            string datas = UtilMethods<List<BaseData>>.EntityToJson(GlobalState.datas);
            string path = Application.dataPath + "/Resources/Scenarios/" + txtName + ".json";

            if (!File.Exists(path))
            {
                FileStream fs = new FileStream(path, FileMode.Create, FileAccess.ReadWrite);
                fs.Close();
            }
            File.WriteAllText(path, datas);

            GlobalState.lastEditScenarioPath = path;

            if (!string.IsNullOrEmpty(GlobalState.lastEditScenarioPath))
            {
                if (!File.Exists(GlobalState.editSaveData))
                {
                    FileStream fs = new FileStream(GlobalState.editSaveData, FileMode.Create, FileAccess.ReadWrite);
                    fs.Close();
                }
                File.WriteAllText(GlobalState.editSaveData, GlobalState.lastEditScenarioPath);
            }
        }
    }
}
#endif

