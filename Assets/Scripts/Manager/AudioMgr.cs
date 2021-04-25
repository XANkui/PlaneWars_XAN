/****************************************************
文件：AudioMgr.cs
作者：仙魁 X-AN
博客：https://blog.csdn.net/u014361280 
日期：2021/04/24 16:26:07
功能：Nothing
*****************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlaneWars_XAN { 

	public class AudioMgr : MonoSingleton<AudioMgr>,IInit
	{
		private Dictionary<string, AudioClip> mClips = new Dictionary<string, AudioClip>();
        private AudioSource mBGAudioSource;

        private List<AudioSource> mActiveAudioSources = new List<AudioSource>();
        private List<AudioSource> mInactiveAudioSources = new List<AudioSource>();

        private Dictionary<string, AudioSource> mClipAndSourceMap = new Dictionary<string, AudioSource>();
        private Dictionary<string, float> mVolumes = new Dictionary<string, float>();

        private Action mChangeVolume;
        private float mDefaultVolume = 0.5f;

        public void Init()
        {
            AudioClip[] clips = LoadMgr.Instance.LoadAll<AudioClip>(Paths.AUDIO_FOLDER);

            foreach (var clip in clips)
            {
                mClips.Add(clip.name, clip);
            }

            mBGAudioSource = gameObject.AddComponent<AudioSource>();

            IReader reader = ReadMgr.Instance.GetReader(Paths.CONFIG_AUDIO_VOULME_CONFIG);
            string audioName = "";
            float volume = 0;
            reader.Count((count)=> {

                for (int i = 0; i < count; i++)
                {
                    TaskQueueMgr.Instance.AddQueue<string>(() => reader[i][DataKeys.AUDIO_NAME]);
                    TaskQueueMgr.Instance.AddQueue<float>(() => reader[i][DataKeys.AUDIO_Volume]);
                    TaskQueueMgr.Instance.Execute((datas) => {
                        audioName = (string)datas[0];
                        volume = (float)datas[1];
                        mVolumes.Add(audioName, volume);
                    });
                }

                // 执行音量设置回调
                if (mChangeVolume != null)
                {
                    mChangeVolume.Invoke();
                    mChangeVolume = null;
                }
                
            });
            
        }

        public AudioClip GetAudioClip(Hero aduio)
        {
            return GetAudioClip(aduio.ToString());
        }

        public AudioClip GetAudioClip(UIAudio aduio)
        {
            return GetAudioClip(aduio.ToString());
        }

        public AudioClip GetAudioClip(BGAudio aduio) {
            return GetAudioClip(aduio.ToString());
        }

        public AudioClip GetAudioClip(string aduio) {
            
            if (mClips.ContainsKey(aduio))
            {
                return mClips[aduio];
            }
            else { 
                Debug.LogError(GetType() + "/PlayBG()/ There is no ths name audio :" + aduio) ;
                return null;
            }
        }

        private void SetVolume(string audio, AudioSource source) {
            if (mVolumes.Count == 0)
            {
                mChangeVolume += () => source.volume = GetVolumeValue(audio);
            }
            else {
                source.volume = GetVolumeValue(audio);
            }
        }

        private float GetVolumeValue(string audio) {
            // 读取 json  string 带 引号 奇怪
            audio = "\"" + audio + "\"";
            if (mVolumes.ContainsKey(audio))
            {
                
                return mVolumes[audio];
            }
            else {
                
                return mDefaultVolume;
            }
        }

        public void PlayBG(BGAudio audio) {
            mBGAudioSource.clip = GetAudioClip(audio);
            SetVolume(audio.ToString(),mBGAudioSource);
            mBGAudioSource.loop = true;
            mBGAudioSource.Play();
        }

        public void PlayOnce(string audio)
        {
            var clip = GetAudioClip(audio);
            mBGAudioSource.PlayOneShot(clip, GetVolumeValue(audio));
        }

        public void Play(string audio, bool loop=false) {
            AudioSource source = GetSource();
            var clip = GetAudioClip(audio);
            source.clip = clip;
            SetVolume(audio.ToString(), source);
            source.loop = loop;
            source.Play();

            mClipAndSourceMap.Add(audio, source) ;

            CoruotineMgr.Instance.ExecuteOnce(Wait(audio));
        }

        private IEnumerator Wait(string audio)
        {
            var clip = GetAudioClip(audio);
            yield return new WaitForSeconds(clip.length);
            Stop(audio);
        }

        public void Stop(string audio)
        {

            if (mClipAndSourceMap.ContainsKey(audio))
            {
                Debug.Log("Stop");
                var source = mClipAndSourceMap[audio];
                source.Stop();
                source.clip = null;
                mActiveAudioSources.Remove(source);
                mInactiveAudioSources.Add(source);
                mClipAndSourceMap.Remove(audio);
            }
        }

        private AudioSource GetSource() {
            AudioSource source;
            if (mInactiveAudioSources.Count > 0)
            {
                source = mInactiveAudioSources[0];
                mInactiveAudioSources.Remove(source);
            }
            else
            {
                source = gameObject.AddComponent<AudioSource>();
            }
            mActiveAudioSources.Add(source);
            return source;
        }
    }
}
