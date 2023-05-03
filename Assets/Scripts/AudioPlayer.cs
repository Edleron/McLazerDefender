using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("HeroShoting")]
    [SerializeField] AudioClip heroShootingClip;
    [SerializeField][Range(0f, 1f)] float heroShootingVolume = 1.0f;


    [Header("EnemyShoting")]
    [SerializeField] AudioClip enemyShootingClip;
    [SerializeField][Range(0f, 1f)] float enemyShootingVolume = 1.0f;


    [Header("Damage")]
    [SerializeField] AudioClip damageClip;
    [SerializeField][Range(0f, 1f)] float damageVolume = 1.0f;

    private static AudioPlayer instance;

    public AudioPlayer GetInstance()
    {
        return instance;
    }

    private void Awake()
    {
        ManageSingleton();
    }

    private void ManageSingleton()
    {
        // int instanceCount = FindObjectsOfType(GetType()).Length;
        // if (instanceCount > 1)
        if (instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void PlayHeroShootingClip()
    {
        PlayClip(heroShootingClip, heroShootingVolume);
    }

    public void PlayEnemyShootingClip()
    {
        PlayClip(enemyShootingClip, enemyShootingVolume);
    }

    public void PlayDamageClip()
    {
        PlayClip(damageClip, damageVolume);
    }


    private void PlayClip(AudioClip clip, float volume)
    {
        if (clip != null)
        {
            Vector3 camPos = Camera.main.transform.position;
            AudioSource.PlayClipAtPoint(clip, camPos, volume);
        }
    }
}
