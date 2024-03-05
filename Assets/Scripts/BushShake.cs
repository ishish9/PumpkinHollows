using UnityEngine;

public class BushShake : MonoBehaviour
{
    [SerializeField] private AudioClips audioClip;
    [SerializeField] private string ShakeAnimation;
    [SerializeField] private Animator Animation = null;
    [SerializeField] private ParticleSystem PS;
    [SerializeField] private bool emitsCoin;

    private void OnTriggerEnter(Collider collider)
    {
        int RandomCoin;
        RandomCoin = Random.Range(0, 3);
        if (collider.gameObject.tag == "Player")
        {
            AudioManager.Instance.PlaySound(audioClip.BushShake);
            Animation.Play(ShakeAnimation, 0, 0.0f);
        }
        
        if (RandomCoin == 1 && emitsCoin)
        {
            EmitCoin();
            emitsCoin = false;
        } 
        else
        {
            emitsCoin = false;
        }
    }

    private void EmitCoin()
    {
        AudioManager.Instance.PlaySound(audioClip.CollectCoinBush);
        PS.Play();
    }
}
