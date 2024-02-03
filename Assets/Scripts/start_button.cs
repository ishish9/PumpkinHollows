using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class start_button : MonoBehaviour
{
    [SerializeField] private GameObject MainCamera;
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject pumpkin;
    [SerializeField] private GameObject start;
    [SerializeField] private AudioClip Music;

    public void startbutton()
    {
        AudioManager.Instance.PlayMusic(Music);
        MainCamera.SetActive(true);
        menu.SetActive(false);
        pumpkin.SetActive(true);
        start.SetActive(false);
    }   
}
