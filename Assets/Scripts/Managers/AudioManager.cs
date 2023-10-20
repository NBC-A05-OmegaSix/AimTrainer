using UnityEngine;
using static SoundEffects;

public class AudioManager : Singleton<AudioManager>
{
    private const bool soundPlay = true;
    private const bool soundStop = false;

    [Header("#BGM")]
    [SerializeField] private AudioClip[] bgmClips;
    public float bgmVolume;
    AudioSource bgmPlayer;

    [Header("#SFX")]
    [SerializeField] private AudioClip[] sfxClips;
    public float sfxVolume;
    [SerializeField] private int channels;
    private int channelIndex;
    AudioSource[] sfxPlayers;

    [Header("#Dialogue")]
    [SerializeField] private AudioClip[] dialogueClips;
    [SerializeField] private float dialogueVolume;

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

    public void PlayBGM(int index, bool isPlay)
    {
        if (index >= 0 && index < bgmClips.Length)
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

    public void SwitchBGM(int stopIndex, int playIndex)
    {
        PlayBGM(stopIndex, soundStop);
        PlayBGM(playIndex, soundPlay);
    }

    public void SetBGMVolume(float bgmVolume)
    {
        this.bgmVolume = bgmVolume;

        bgmPlayer.volume = bgmVolume;
    }

    public void PlaySFX(Sfx sfx)
    {
        for (int index = 0; index < sfxPlayers.Length; index++)
        {
            int loopIndex = index % sfxPlayers.Length;
            if (!sfxPlayers[loopIndex].isPlaying)
            {
                if (sfx == Sfx.RunLeftFoot)
                {
                    sfx = (sfxPlayers[loopIndex].clip == sfxClips[(int)Sfx.RunLeftFoot])
                        ? Sfx.RunRightFoot : Sfx.RunLeftFoot;
                }

                if (sfx == Sfx.WalkLeftFoot)
                {
                    sfx = (sfxPlayers[loopIndex].clip == sfxClips[(int)Sfx.WalkLeftFoot])
                        ? Sfx.WalkRightFoot : Sfx.WalkLeftFoot;
                }

                channelIndex++;
                if (channelIndex >= sfxPlayers.Length)
                {
                    channelIndex = 0;
                }

                sfxPlayers[loopIndex].PlayOneShot(sfxClips[(int)sfx]);

                break;
            }
        }
    }

    public void SetSFXVolume(float sfxVolume)
    {
        this.sfxVolume = sfxVolume;

        foreach(var sfxPlayer in sfxPlayers)
        {
            sfxPlayer.volume = sfxVolume;
        }
    }

    public void PlayerDialogue(int index)
    {
        if(index >= 0 && index < dialogueClips.Length)
        {
            AudioSource dialoguePlayer = sfxPlayers[0];
            if (dialoguePlayer.isPlaying)
            {
                dialoguePlayer.Stop();
            }

            dialoguePlayer.clip = dialogueClips[index];
            dialoguePlayer.volume = dialogueVolume;
            dialoguePlayer.Play();
        }
    }
}