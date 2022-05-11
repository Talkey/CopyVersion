using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    private void Awake()
    {
        instance = this;
    }
    public AudioClip[] audios;
    // Use this for initialization
    void Start()
    {
        //默认播放第二个音频
        this.GetComponent<AudioSource>().clip = audios[0];
        this.GetComponent<AudioSource>().Play();
    }
    // Update is called once per frame
    public void MapMusic(int i)
    {
        this.GetComponent<AudioSource>().clip = audios[i];
        this.GetComponent<AudioSource>().Play();
    }
    //public void WoodMapMusic(int i)
    //{
    //    this.GetComponent<AudioSource>().clip = audios[i];
    //    this.GetComponent<AudioSource>().Play();
    //}
    //public void OceanMapMusic(int i)
    //{
    //    this.GetComponent<AudioSource>().clip = audios[i];
    //    this.GetComponent<AudioSource>().Play();
    //}
    //public void FlameMapMusic(int i)
    //{
    //    this.GetComponent<AudioSource>().clip = audios[i];
    //    this.GetComponent<AudioSource>().Play();
    //}
    //public void EarthMapMusic(int i)
    //{
    //    this.GetComponent<AudioSource>().clip = audios[i];
    //    this.GetComponent<AudioSource>().Play();
    //}
    public void StartMapMusic()
    {
        this.GetComponent<AudioSource>().clip = audios[0];
        this.GetComponent<AudioSource>().Play();
    }
}
