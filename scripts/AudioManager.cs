using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using Common;

public class AudioManager : MonoSingleton<AudioManager>
{
    AudioSource bgmSource;              //bgm播放器
    public AudioSource voiceSource;          //人物声音播放器
    public override void Init()
    {
        base.Init();
        bgmSource = gameObject.AddComponent<AudioSource>();
        voiceSource = gameObject.AddComponent<AudioSource>();
    }

    public void PlaySource(AudioClip bgm ,AudioClip voice)
    {
        if (bgm != null)
        {
            bgmSource.clip = bgm;
            //测试音量
            bgmSource.volume = 0.1f;
            bgmSource.Play();
        }

        voiceSource.clip = voice;
        voiceSource.loop = false;
        voiceSource.Play();
    }
}
