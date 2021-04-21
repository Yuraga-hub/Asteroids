using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreTxt;
    [SerializeField] private TextMeshProUGUI livesTxt;
    [SerializeField] private TextMeshProUGUI wavesTxt;
    [SerializeField] private TextMeshProUGUI recordTxt;



    public void UpdateScore(string value)
    {
        scoreTxt.text = value;
    }

    public void UpdateLives(string value)
    {
        livesTxt.text = value;
    }

    public void UpdateWave(string value)
    {
        wavesTxt.text = value;
    }
    public void UpdateRecord(string value)
    {
        recordTxt.text = value;
    }
    

}
