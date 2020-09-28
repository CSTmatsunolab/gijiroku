﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WadaiChange : MonoBehaviour
{
    public GameObject[] Button;
    public InputField inputField;
    public Text[] text;
    int dropdown2;

    //Dropdownを格納する変数
    [SerializeField] private Dropdown dropdown;

    // Start is called before the first frame update
    void Start()
    {
        inputField = inputField.GetComponent<InputField>();
        dropdown2 = dropdown.value;
    }

    /*
    private void Update()
    {
        if(dropdown.value != dropdown2)
        {
            InputField form = GameObject.Find("InputField").GetComponent<InputField>();
            form.text = "";
            dropdown2 = dropdown.value;
        }

        /*
        //DropdownのValueが0のとき（赤が選択されているとき）
        if (dropdown.value == 0)
        {

        }
        //DropdownのValueが1のとき（青が選択されているとき）
        else if (dropdown.value == 1)
        {
            InputField form = GameObject.Find("InputField").GetComponent<InputField>();
            form.text = "";
        }
        //DropdownのValueが2のとき（黄が選択されているとき）
        else if (dropdown.value == 2)
        {

        }
        //DropdownのValueが3のとき（白が選択されているとき）
        else if (dropdown.value == 3)
        {

        }
        //DropdownのValueが4のとき（黒が選択されているとき）
        else if (dropdown.value == 4)
        {

        }
        else if (dropdown.value == 5)
        {

        }
        //DropdownのValueが3のとき（白が選択されているとき）
        else if (dropdown.value == 6)
        {

        }
        //DropdownのValueが4のとき（黒が選択されているとき）
        else if (dropdown.value == 7)
        {

        }
    }
    */


    // オプションが変更されたときに実行するメソッド
    public void InputText()
    {
        if (dropdown.value != dropdown2)
        {
            InputField form = GameObject.Find("InputField").GetComponent<InputField>();
            form.text = "";
            dropdown2 = dropdown.value;
        }
        text[dropdown.value].text = inputField.text;
    }





}