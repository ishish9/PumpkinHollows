using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableAudioClips", menuName = "AudioClipsScriptable")]

public class AudioClips : ScriptableObject
{
    [Header("AudioClips For Player")]
    public AudioClip Move;
    public AudioClip Jump;
    public AudioClip JumpDouble;
    public AudioClip Land;
    public AudioClip Stomp;

    [Header("Collectable Sounds")]
    public AudioClip CollectCoin;
    public AudioClip CollectCoinBush;
    public AudioClip BushShake;

    public AudioClip GetPowerUp;

    [Header("Chest Sounds")]
    public AudioClip ChestOpen;
    public AudioClip TaDa;
    public AudioClip TaDaBad;

    [Header("Door Sounds")]
    public AudioClip CreekyDoorOpen;




}
