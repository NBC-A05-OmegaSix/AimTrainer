using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AR : MonoBehaviour
{
    public void OnFireSpray()
    {
        AudioManager.Instance.PlaySFX(SoundEffects.Sfx.FireSpayAR);
    }

    public void OnFire()
    {
        AudioManager.Instance.PlaySFX(SoundEffects.Sfx.FireAR);
    }
}
