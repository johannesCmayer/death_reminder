using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SetTimeLeft : MonoBehaviour
{
    TextMeshProUGUI myText;
    public Button redeemButton;
    public static DeathTimer timer = new DeathTimer(85, new System.DateTime(1995,02,13));

    string saveFile;
    private void Awake() {
        print(Application.persistentDataPath);
        saveFile = $"{Application.persistentDataPath}/save";
        myText = GetComponent<TextMeshProUGUI>();
        if (System.IO.File.Exists(saveFile)){
            using (System.IO.StreamReader file = new System.IO.StreamReader(saveFile)){
                myText.text = file.ReadLine();
            }
        }
        else
        {
            UpdateText(false);
        }
    }
    
    public bool TextOutOfDate {get {return myText.text != timer.TimeLeft.Days.ToString();}}

    public void UpdateText(bool playGongOnChange = true)
    {
        if (TextOutOfDate){
            int t;
            if (int.TryParse(myText.text, out t) && t > timer.TimeLeft.Days)
            {
                myText.text = (t - 1).ToString();
            }
            else
            {
                myText.text = timer.TimeLeft.Days.ToString();
            }
            if (playGongOnChange)
                AudioManager.instance.PlayGong();
            SetInteractibility();
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(saveFile)){
                file.Write(myText.text);
            }
            
        }
    }

    void OnApplicationFocus(bool focusStatus) {
          SetInteractibility();
    }

    public void SetInteractibility(){        
        redeemButton.interactable = TextOutOfDate;
        ParticleAdjuster.instance.EnableParticles(!TextOutOfDate);
    }
}
