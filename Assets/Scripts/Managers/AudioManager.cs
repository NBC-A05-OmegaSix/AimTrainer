using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    [Header("#BGM")]
    public AudioClip[] bgmClips;
    public float bgmVolume;
    AudioSource bgmPlayer;

    [Header("#SFX")]
    public AudioClip[] sfxClips;
    public float sfxVolume;
    public int channels;
    private int channelIndex;
    AudioSource[] sfxPlayers;

    private void Start()
    {
        PlayerBGM(0, true);
    }

    public override void Init()
    {
        GameObject bgmObject = new GameObject("BGMPlayer");
        bgmObject.transform.parent = transform;

        bgmPlayer = bgmObject.AddComponent<AudioSource>();
        bgmPlayer.playOnAwake = false;
        bgmPlayer.loop = true;
        bgmPlayer.volume = bgmVolume;

        GameObject sfxObject = new GameObject("SFXPlayer");
        sfxObject.transform.parent = transform;
        sfxPlayers = new AudioSource[channels];

        for(int index = 0; index < sfxPlayers.Length; index++)
        {
            sfxPlayers[index] = sfxObject.AddComponent<AudioSource>();
            sfxPlayers[index].playOnAwake = false;
            sfxPlayers[index].volume = sfxVolume;
        }

    }

    public void PlayerBGM(int index, bool isPlay)
    {
        if(index >= 0 && index < bgmClips.Length)
        {
            if (isPlay)
            {
                if (bgmPlayer.isPlaying)
                {
                    bgmPlayer.Stop();
                }

                bgmPlayer.clip = bgmClips[index];
                bgmPlayer.Play();
            }
            else
            {
                bgmPlayer.Stop();
            }
        }
    }

    public void PlaySFX(SoundEffects.Sfx sfx)
    {
        for(int index = 0; index < sfxPlayers.Length; index++)
        {
            int loopIndex = (index * channelIndex) % sfxPlayers.Length;

            if (sfxPlayers[loopIndex].isPlaying)
            {
                continue;
            }

            int randIndex = 0; 

            if(sfx == SoundEffects.Sfx.FireAR || sfx == SoundEffects.Sfx.FireSR)
            {
                randIndex = Random.Range(0, 2);
            }

            channelIndex = loopIndex;
            sfxPlayers[loopIndex].clip = sfxClips[(int)sfx + randIndex];
            sfxPlayers[loopIndex].Play();
            break;
        }
    }
}
