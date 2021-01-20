﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using MonobitEngine;
using System.IO;
using System.ComponentModel;
using System;
using System.Linq;

public class MargeCsv : MonobitEngine.MonoBehaviour
{

    string MargefilePath;
    string InputPath;

    // Start is called before the first frame update
    void Start()
    {
        Clear();
        //Debug.Log("start");
    }

    void Clear()
    {
        for (int i = 0; i < 9; i++)
        {
            MargePathName(i);
            string ClearPath = Application.dataPath + MargefilePath;
            using (var fileStream = new FileStream(ClearPath, FileMode.Open))
            {
                // ストリームの長さを0に設定します。
                // 結果としてファイルのサイズが0になります。
                fileStream.SetLength(0);
            }
            
        }
    }

    /*
    [MunRPC, MenuItem("Example/Copy Something")]
    public void Share(string folder)
    {
        FileUtil.CopyFileOrDirectory(folder, "Assets/MargeFolder");
    }
    */


    //フォルダのコピー生成
    
    [MunRPC,MenuItem("Example/Copy Something")]
    public void CopySomething(string timeStamp)
    {
        FileUtil.CopyFileOrDirectory("Assets/MargeCSVLogFiles", "Assets/MargeFolder/" + timeStamp);
        Debug.Log("コピーしました");
        
        //IEnumerable<string> subFolders = System.IO.Directory.EnumerateDirectories("Assets", "MargeFolder", System.IO.SearchOption.AllDirectories);
        //monobitView.RPC("Share", MonobitTargets.Others, subFolders);
    }
    

    //マージファイルに書き込み
    [MunRPC]
    public void RecvChat(string list, int i, int cnt)
    {
        Debug.Log("recvchatしました");
        MargePathName(i);
        string CSVWriteFilePath = Application.dataPath + MargefilePath;
        Debug.Log(MargefilePath);
        using (StreamWriter streamWriter = new StreamWriter(CSVWriteFilePath, true))
        {
            streamWriter.Write(list);
            streamWriter.WriteLine();
        }
        //monobitView.RPC("MargeSort", MonobitTargets.Host);

        if(i == 8 && cnt == 0)
        {
            MargeSort();
        }
    }

    //一文ずつ送信
    [MunRPC]
    public void Send()
    {
        Debug.Log("sendしました");
        Clear();
        int cnt;

        for (int i = 0; i < 9; i++)
        {
            InputPathName(i);
            string CSVFilePath = Application.dataPath + InputPath;
            //書き込み先ファイルの指定


            var fs = new FileStream(CSVFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

            //　ストリームで読み込みと書き込み
            using (StreamReader streamReader = new StreamReader(fs))

            {
                List<string> lists = new List<string>();

                while (!streamReader.EndOfStream)
                {
                    lists.AddRange(streamReader.ReadLine().Split('\n'));
                }
                cnt = lists.Count();
                foreach (var list in lists)
                {
                    cnt--;
                    monobitView.RPC("RecvChat", MonobitTargets.Host, list, i, cnt);
                }
            }
        }

        /*
        if (!MonobitEngine.MonobitNetwork.isHost)
        {
            Debug.Log("ホストじゃないよ");
        }
        else
        {
            MargeSort();
        }
        */

    }

    DateTime time;
    string timeStamp;

    //outputボタンをクリックした時に送信
    public void ClickFlag()
    {
        time = DateTime.Now;
        timeStamp = time.ToString("yyyy_MMdd_HH_mm_ss");
        monobitView.RPC("Send", MonobitTargets.All);
    }

    //ソート関数
    //[MunRPC]
    public void MargeSort()
    {
        Debug.Log("margeしました");
        for (int i = 0; i < 9; i++)
        {
            MargePathName(i);
            string SortFilePath = Application.dataPath + MargefilePath;
            List<string> lists = new List<string>();
            using (FileStream fileStream = File.Open(SortFilePath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                using (StreamReader streamReader = new StreamReader(fileStream))
                using (StreamWriter streamWriter = new StreamWriter(fileStream))
                {
                    while (!streamReader.EndOfStream)
                    {
                        lists.AddRange(streamReader.ReadLine().Split('\n'));
                    }

                    lists.Sort();

                    fileStream.SetLength(0);

                    foreach (var list in lists)
                    {
                        streamWriter.Write(list);
                        streamWriter.WriteLine();
                    }
                }
            }
        }
        Debug.Log("margeしました2");

        monobitView.RPC("CopySomething", MonobitTargets.Host, timeStamp);

        //ソート前のリスト
        //Debug.Log("ソート前のリスト" + string.Join("", sortlists));
        //ShowListContentsInTheDebugLog(sortlists);
        //sortlists.Sort();
        //ソート後のリスト
        //Debug.Log("ソート後のリスト" + string.Join("", sortlists));
    }

    public void SortFlag()
    {
        monobitView.RPC("MargeSort", MonobitTargets.All);
    }


    void MargePathName(int number)
    {
        switch (number)
        {
            case 0:
                MargefilePath = @"/MargeCSVLogFiles/MargeCSVLogFile0.csv";
                break;
            case 1:
                MargefilePath = @"/MargeCSVLogFiles/MargeCSVLogFile1.csv";
                break;
            case 2:
                MargefilePath = @"/MargeCSVLogFiles/MargeCSVLogFile2.csv";
                break;
            case 3:
                MargefilePath = @"/MargeCSVLogFiles/MargeCSVLogFile3.csv";
                break;
            case 4:
                MargefilePath = @"/MargeCSVLogFiles/MargeCSVLogFile4.csv";
                break;
            case 5:
                MargefilePath = @"/MargeCSVLogFiles/MargeCSVLogFile5.csv";
                break;
            case 6:
                MargefilePath = @"/MargeCSVLogFiles/MargeCSVLogFile6.csv";
                break;
            case 7:
                MargefilePath = @"/MargeCSVLogFiles/MargeCSVLogFile7.csv";
                break;
            case 8:
                MargefilePath = @"/MargeCSVLogFiles/MargeCSVLogFile.csv";
                break;
            default:
                break;
        }
    }

    void InputPathName(int number)
    {
        switch (number)
        {
            case 0:
                InputPath = @"/CSVLogFiles/CSVLogFile0.csv";
                break;
            case 1:
                InputPath = @"/CSVLogFiles/CSVLogFile1.csv";
                break;
            case 2:
                InputPath = @"/CSVLogFiles/CSVLogFile2.csv";
                break;
            case 3:
                InputPath = @"/CSVLogFiles/CSVLogFile3.csv";
                break;
            case 4:
                InputPath = @"/CSVLogFiles/CSVLogFile4.csv";
                break;
            case 5:
                InputPath = @"/CSVLogFiles/CSVLogFile5.csv";
                break;
            case 6:
                InputPath = @"/CSVLogFiles/CSVLogFile6.csv";
                break;
            case 7:
                InputPath = @"/CSVLogFiles/CSVLogFile7.csv";
                break;
            case 8:
                InputPath = @"/CSVLogFiles/CSVLogFile.csv";
                break;
            default:
                break;
        }
    }
}
