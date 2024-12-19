using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager_Sc : MonoBehaviour
{

    public AudioSource audioSourceBonus;
    public AudioClip bonusSound;
    public AudioSource audioSourceExplosion;
    public AudioClip explosionSound;
    public AudioSource audioSourceLaser;
    public AudioClip laserSound;
    private void Awake()
    {
        audioSourceBonus.clip = bonusSound;
        audioSourceExplosion.clip = explosionSound;
        audioSourceLaser.clip = laserSound;
    }
}

