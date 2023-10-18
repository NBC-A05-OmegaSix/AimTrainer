using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchBGM : MonoBehaviour
{
    public void switchBGM()
    {
        if(AudioManager.Instance != null)
        {
            AudioManager.Instance.SwitchBGM(0, 1);
        }
    }
}