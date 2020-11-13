﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SoundManager : MonoBehaviour
{
    private AudioSource audioPlayer;
    public AudioClip buttonSound;
    public static SoundManager instance; //다른 스크립트에서 이스크립트에있는 함수를 호출할때 쓰임

    void Awake()  // Start함수보다 먼저 호출됨
    {
        if (SoundManager.instance == null)  //게임시작했을때 이 instance가 없을때
            SoundManager.instance = this;  // instance를 생성
    }

    void Start()
    {
        audioPlayer = GetComponent<AudioSource>();  //myAudio에 컴퍼넌트에있는 AudioSource넣기
        DontDestroyOnLoad(audioPlayer);
    }

    public void PlaySound()
    {
        audioPlayer.PlayOneShot(buttonSound);
        // 유니티에서 기본으로 제공하는 함수 (이 소리)를 한번재생
    }
}

