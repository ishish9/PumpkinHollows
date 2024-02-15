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
        if (collider.gameObject.tag == "Player")
        {
            AudioManager.Instance.PlaySound(audioClip.BushShake);
            Animation.Play(ShakeAnimation, 0, 0.0f);
        } 

        if (emitsCoin)
        {
            AudioManager.Instance.PlaySound(audioClip.CollectCoinBush);
            emitsCoin = false;
            PS.Play();
        }                    
    }
}
