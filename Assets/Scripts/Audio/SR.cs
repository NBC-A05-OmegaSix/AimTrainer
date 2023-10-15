using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SR : MonoBehaviour
{
    public void OnFIre()
    {
        AudioManager.Instance.PlaySFX(SoundEffects.Sfx.FireSR);
    }
}
