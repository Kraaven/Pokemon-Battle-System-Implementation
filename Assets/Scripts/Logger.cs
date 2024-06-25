using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Logger : MonoBehaviour
{
    // Start is called before the first frame update

    private static StreamWriter Gamelogger;
    void Start()
    {
        if (!Directory.Exists(Application.dataPath + "/Logs"))
        {
            Directory.CreateDirectory(Application.dataPath + "/Logs");
        }
        
        Gamelogger = new StreamWriter(File.Create(Application.dataPath + $"/Logs/Log_{GetDateName()}.txt"));
    }

    private void OnDisable()
    {
        CloseLogger();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private string GetDateName()
    {
        var info = DateTime.Now;
        var msg = $"{info.Day}.{info.Month}.{info.Year}-[{info.Hour}.{info.Minute}]";
        return msg;
    }

    public static void LogEvent(string evt)
    {
        Gamelogger.WriteLine(evt);
    }

    public void CloseLogger()
    {
        Gamelogger.Close();
    }
}
