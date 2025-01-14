﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;




public class CreateJson : MonoBehaviour
{
    static DataClass dataList = new DataClass();
    static RespoinseData jsonData = new RespoinseData();

    static DataClass errordataList = new DataClass();
    public static void ResetData()
	{
        dataList.lessonClasses.Clear();
        dataList.LEClasses.Clear();
        errordataList.lessonClasses.Clear();
        errordataList.LEClasses.Clear();

    }
    public static void SetErrorDataList(lessonClass data, lessonErrorClass lec)
    {
        errordataList.lessonClasses.Add(data);
        errordataList.LEClasses.Add(lec);
    }
    public static void SetDataList(lessonClass data)
    {
        dataList.lessonClasses.Add(data);
    }
    public static void SetDataList(ChallengeData data)
    {
        dataList.challengeDatas.Add(data);
    }

    public static DataClass GetErrorDataList()
	{
        return errordataList;

    }

    public static void SetDataList(string className,string taskname)
    {
        dataList.taskName = taskname;
        dataList.mainClassName = className;
    }

    public static bool CheckData(string name, string fileName)
    {
        try
        {
            var data = dataList.lessonClasses.Find(x => x.fileName == fileName && x.name == name).fileName;
            if (data == "")
                return false;
        }
        catch
        {
            return false;
        }
        
        return true;
    }
    public static bool CheckErrerData(string name, string fileName)
    {
        try
        {
            var data = errordataList.lessonClasses.Find(x => x.fileName == fileName && x.name == name).fileName;
            if (data == "")
                return false;
        }
        catch
        {
            return false;
        }

        return true;
    }

    public static void WriteJson()
    {
        
        jsonData.message = JsonUtility.ToJson((dataList));
        Debug.Log(jsonData);
        
    }
    public static string GetJsonData()
    {
        Debug.Log(jsonData.message);
        return jsonData.message;
    }
    [System.Serializable]
    public class RespoinseData
    {
        public string message;
    }
}