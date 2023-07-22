using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public List<AudioClip> soundEffects = new List<AudioClip>();

    private AudioSource audioSource;

    private void Start()

    {

        audioSource = GetComponent<AudioSource>();

    }

    public void PlaySoundEffect(int index)
    {

        audioSource.clip = soundEffects[index];
        audioSource.Play();

    }

    public void WalkSound()
    {

        PlaySoundEffect(0);
        // Sound effect for Astra walking
    }

    public void CollectStarSound()
    {

        PlaySoundEffect(1);
        // Sound effect for when Collecting Stars

    }

    public void PlantingSound()
    {

        PlaySoundEffect(2);
        // Sound effect for when Planting Stars

    }

    public void GrownSound()
    {

        PlaySoundEffect(3);
        // Sound effect for when the plants have finished growing

    }

    public void HarvestSound()
    {

        PlaySoundEffect(4);
        // Sound effect for when Harvesting Grapes

    }

    public void StoreJingleSound()
    {

        PlaySoundEffect(5);
        // Sound effect for when the Player opens the Store UI
    }

    public void SoldSound()
    {

        PlaySoundEffect(6);
        // Sound effect for when the Player sells a Grape

    }

    public void BoughtSound()
    {

        PlaySoundEffect(7);
        // Sound effect for when the Player purchases from the Store
    }

    public void LoseSound()
    {

        PlaySoundEffect(8);
        // Sound effect for if the Player loses the game

    }

    public void WinSound()
    {

        PlaySoundEffect(9);
        // Sound effect for if the Player wins the game

    }

}
