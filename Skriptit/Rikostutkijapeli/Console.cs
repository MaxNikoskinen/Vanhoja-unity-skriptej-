//https://polygonplanet.com/
//Copyright © 2016 Polygon Planet. All rights reserved.
//This source file is protected under UNITYS Asset Store Terms of Service and EULA which can be viewed here https://unity3d.com/legal/as_terms

#pragma warning disable 0168 //Variable declared, but not used.
#pragma warning disable 0219 //Variable assigned, but not used.
#pragma warning disable 0414 //Private field assigned, but not used.

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Console : MonoBehaviour
{
    [Header("UI")]
    public TMP_Text terminalText;

    [Header("Log Colors")]
    public string assertColor = "cyan";
    public string errorColor = "red";
    public string exceptionColor = "orange";
    public string logColor = "white";
    public string warningColor = "yellow";

    [Header("Variables")]
    public int maxLogs = 100;
    public bool spam = false;
    public bool restrictLogs = true;
    public bool logToFile = false;

    [Header("StatusShowIndicator")]
    public GameObject spamStatusIndicator;
    public GameObject restrictLogsStatusIndicator;
    public GameObject logToFileStatusIndicator;

    //Variables
    private bool visible;
    private List<Log> logs;
    private string fullLog;

    private void Awake()
    {
        logs = new List<Log>();
    }

    private void OnEnable()
    {
        Application.logMessageReceived += HandleLog;
    }

    private void OnDisable()
    {
        Application.logMessageReceived -= HandleLog;
    }

    private void Update()
    {
        if (spam == true)
        {
            Debug.Log("<color=red>Spam</color>");
        }
    }

    private void OnGUI()
    {
        ShowLog();
        if (logToFile == true)
        {
            File.WriteAllText(Application.persistentDataPath + "/log.txt", fullLog);
        }

        if (spam == true)
        {
            spamStatusIndicator.SetActive(true);
        }
        else
        {
            spamStatusIndicator.SetActive(false);
        }
        if (restrictLogs == true)
        {
            restrictLogsStatusIndicator.SetActive(true);
        }
        else
        {
            restrictLogsStatusIndicator.SetActive(false);
        }
        if (logToFile == true)
        {
            logToFileStatusIndicator.SetActive(true);
        }
        else
        {
            logToFileStatusIndicator.SetActive(false);
        }
    }

    private void HandleLog(string message, string stackTrace, LogType logType)
    {
        Log log = new Log()
        {
            message = message,
            stackTrace = stackTrace,
            logType = logType
        };
        logs.Add(log);  
        TrimExcessLogs();
    }

    private void TrimExcessLogs()
    {
        if (!restrictLogs)
        {
            return;
        }
        else
        {
            var amountToRemove = Mathf.Max(logs.Count - maxLogs, 0);
            if (amountToRemove == 0)
            {
                return;
            }
            else
            {
                logs.RemoveRange(0, amountToRemove);
            }
        }
    }

    public void Clear()
    {
        logs.Clear();
    }

    private void ShowLog()
    {
        fullLog = "";
        int i = new int();
        foreach (Log log in logs)
        {
            if (logs[i].logType == LogType.Assert)
            {
                fullLog = fullLog + "<color=" + assertColor + ">" + logs[i].message + "</color>" + "\r\n";
            }
            else if (logs[i].logType == LogType.Error)
            {
                fullLog = fullLog + "<color=" + errorColor + ">" + logs[i].message + "</color>" + "\r\n";
            }
            else if (logs[i].logType == LogType.Exception)
            {
                fullLog = fullLog + "<color=" + exceptionColor + ">" + logs[i].message + "</color>" + "\r\n";
            }
            else if (logs[i].logType == LogType.Log)
            {
                fullLog = fullLog + "<color=" + logColor + ">" + logs[i].message + "</color>" + "\r\n";
            }
            else if (logs[i].logType == LogType.Warning)
            {
                fullLog = fullLog + "<color=" + warningColor + ">" + logs[i].message + "</color>" + "\r\n";
            }
            i++;
        }
        terminalText.text = fullLog;
    }

    public void ChangeSpam()
    {
        spam = !spam;
    }

    public void RestrictLogs()
    {
        restrictLogs = !restrictLogs;
    }

    public void LogToFile()
    {
        logToFile = !logToFile;
    }
}

[Serializable]
public class Log
{
    public string message;
    public string stackTrace;
    public LogType logType;
}