using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public int record;

    

    private void Awake()
    {
        if  (PlayerPrefs.HasKey("Record"))
        {
            LoadPrefs();
        }
        else
        {
            InitPrefs();
        }
    }


    public void SaveStats()
    {
        PlayerPrefs.SetInt("Record", record);
        PlayerPrefs.Save();
        
    }

    public void LoadPrefs()
    {

        record = PlayerPrefs.GetInt("Record", record);
    }


    public void InitPrefs()
    {
        PlayerPrefs.SetInt("Record", 0);
        record = 0;
        
    }
}
