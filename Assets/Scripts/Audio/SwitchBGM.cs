using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchBGM : MonoBehaviour
{
    public void switchBGM()
    {
        if(AudioManager.Instance != null)
        {
            AudioManager.Instance.PlayerBGM(0, false);
            AudioManager.Instance.PlayerBGM(1, true);
        }
    }
}
