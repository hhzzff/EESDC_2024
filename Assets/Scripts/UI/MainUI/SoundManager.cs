using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.U2D;
using UnityEngine.UI;

namespace FWC
{
    public class SoundManager : MonoBehaviour
    {
        public AudioMixer masterMixer;
        private float volume_sfx = 1;
        private float volume_music = 1;
        private bool muteSFX, muteMusic;
        [SerializeField] Image image_SFX, image_Music; 
        public Sprite[] sprite_SFX , sprite_Music; 
        public static SoundManager Instance;
        public AudioSource source_SFX;
        public AudioSource source_Music; 
        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {        
            source_Music.volume = volume_music;            
            source_SFX.volume = volume_sfx;      
        }
        public void PlaySFX(AudioClip clip)
        {
            if (!source_SFX.isPlaying)
            {
                source_SFX.clip = clip;
                source_SFX.PlayOneShot(source_SFX.clip);
            }
        }
        public void MuteMusic()
        {
            muteMusic = !muteMusic;

            if (muteMusic)
            {                
                image_Music.sprite = sprite_Music[1];
                masterMixer.SetFloat("VolumeMusic", -80f);
                return;
            }

            image_Music.sprite = sprite_Music[0];
            masterMixer.SetFloat("VolumeMusic", volume_music);
        }

        public void MuteSFX()
        {
            muteSFX = !muteSFX;

            if (muteSFX)
            {
                image_SFX.sprite = sprite_SFX[1];
                masterMixer.SetFloat("VolumeSFX", -80f);
                return;
            }

            image_SFX.sprite = sprite_SFX[0];
            masterMixer.SetFloat("VolumeSFX", volume_sfx);
        }

        public void ChangeVolumeMusic(float musicVol)
        {
            volume_music = musicVol;

            if (muteMusic) return;

            masterMixer.SetFloat("VolumeMusic", musicVol);
        }

        public void ChangeVolumeSFX(float sfxVol)
        {
            volume_sfx = sfxVol;

            if (muteSFX) return;

            masterMixer.SetFloat("VolumeSFX", sfxVol);
        }
    }
}
