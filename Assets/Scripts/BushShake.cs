using UnityEngine;

public class BushShake : MonoBehaviour
{
    [SerializeField] private string ShakeAnimation;
    [SerializeField] private Animator Animation = null;
    [SerializeField] private AudioClip ShakeClip;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            AudioManager.Instance.PlaySound(ShakeClip);
            Animation.Play(ShakeAnimation, 0, 0.0f);
        }
    }
}
