using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSound : MonoBehaviour
{
    [SerializeField] private AudioClip[] gunSounds;

    private AudioSource _source;

    private void Start()
    {
        _source = gameObject.AddComponent<AudioSource>();
        _source.loop = _source.playOnAwake = false;
    }
    
    public void PlaySound()
    {
        if (gunSounds.Length == 0) return;
        
        _source.PlayOneShot(gunSounds[Random.Range(0, gunSounds.Length)]);
    }
}
