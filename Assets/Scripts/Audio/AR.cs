using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AR : MonoBehaviour
{
    public void OnFIre()
    {
        AudioManager.Instance.PlaySFX(SoundEffects.Sfx.FireAR);
    }
}
