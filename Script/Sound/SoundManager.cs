using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

namespace MyPlatformer {
    public class SoundManager : Singleton<SoundManager>
    {

        [SerializeField] private Sound[] sounds;
        public enum SoundName
        {
            UISoundMenu,
            Walk,
            ScoreUp,
            Plow,
            PlantedSeed,
            Grow,
            Water,
            Lose,
            WinFireWork,
            FailedCrop,
            Win,
            SwitchTool,
            //
        }



        public void Play(SoundName name)
        {
            //1. Get sound from array
            Sound sound = GetSound(name);
            if (sound.audioSource == null)
            {
                sound.audioSource = gameObject.AddComponent<AudioSource>();

                sound.audioSource.clip = sound.clip;
                sound.audioSource.loop = sound.loop;
                sound.audioSource.volume = sound.volume;
            }

            //2.Play
            sound.audioSource.Play();
        }

        private Sound GetSound(SoundName name)
        {
            return Array.Find(sounds, s => s.soundName == name);
        }


        }
    }

