using System.Security.Cryptography;
using UnityEngine;

public class CatchObject: MonoBehaviour
{
    [SerializeField] private bool isFirstAidKit;
    [SerializeField] private int scoreCountChange;
    [SerializeField] private int healthCountChange; 
    [SerializeField] private GameObject VFXeffect;
    [SerializeField, Range(0.0f, 1.0f)] private float dropChance;

    private AudioSource audioEffect;
    private Renderer rendererObject;
    private Collider colliderObject;

    private void Awake()
    {
        audioEffect = GetComponent<AudioSource>();
        rendererObject = GetComponent<Renderer>();
        colliderObject = GetComponent<Collider>();
    }

    public int GetHealthChange() { return healthCountChange; }
    public int GetScoreChange() { return scoreCountChange; }
    public float GetDropChance() { return dropChance; }
    public GameObject GetEffect() { return VFXeffect; }
    public AudioSource GetAudioEffect() { return audioEffect; }
    public bool GetBool() { return isFirstAidKit; }

    public void PlaySoundAndDestroy()
    {
        rendererObject.enabled = false;
        colliderObject.enabled = false;

        audioEffect.Play();
        Destroy(gameObject, audioEffect.clip.length);
    }
}
