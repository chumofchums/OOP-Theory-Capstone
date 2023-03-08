using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // ENCAPSULATION
    public static SoundManager Instance { get; private set; }

    [SerializeField] private AudioClipRefsSO audioClipRefsSO;


    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        SpearGun.OnFireAndReload += SpearGun_OnFireAndReload;
    }


    private void SpearGun_OnFireAndReload(object sender, System.EventArgs e)
    {
        SpearGun spearGun = sender as SpearGun;
        Debug.Log("Shoot and Reload");
        // PlaySound(audioClipRefsSO.shootAndReload, transform.position);
    }

    public void OnFishDeath()
    {
        Debug.Log("Fish Died");
        // PlaySound(audioClipRefsSO.fishDeath, transform.position);
    }

    private void PlaySound(AudioClip audioClip, Vector3 position, float volume = 1f)
    {
        AudioSource.PlayClipAtPoint(audioClip, position, volume);
    }

    private void PlaySound(AudioClip[] audioClipArray, Vector3 position, float volume = 1f)
    {
        AudioSource.PlayClipAtPoint(audioClipArray[Random.Range(0, audioClipArray.Length)], position, volume);
    }
}
