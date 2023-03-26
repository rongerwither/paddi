using System;
using MelonLoader;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

namespace Fatury
{
	// Token: 0x02000029 RID: 41
	internal class VideoWorker
	{
		// Token: 0x06000112 RID: 274 RVA: 0x00009B88 File Offset: 0x00007D88
		public static void PlayVideoWithoutAudio(string text, string UI, Vector2 size, Vector2 anchoredposition)
		{
			GameObject.Find("Camera");
			GameObject gameObject = CreateUI.NewImage(null);
			gameObject.transform.SetParent(GameObject.Find(UI).transform, false);
			gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(9999f, 9999f);
			gameObject.GetComponent<Image>().color = new Color(0f, 0f, 0f, 0.5f);
			gameObject.AddComponent<VideoScript>();
			gameObject.name = "VideoRoot";
			GameObject gameObject2 = new GameObject("Image0");
			gameObject2.AddComponent<RectTransform>();
			gameObject2.AddComponent<RawImage>();
			gameObject2.layer = int.MaxValue;
			RectTransform component = gameObject2.GetComponent<RectTransform>();
			component.anchoredPosition = new Vector2(anchoredposition.X, anchoredposition.Y);
			component.sizeDelta = new Vector2(size.X, size.Y);
			gameObject2.transform.SetParent(gameObject.transform, false);
			VideoPlayer videoPlayer = gameObject.AddComponent<VideoPlayer>();
			RawImage component2 = gameObject2.GetComponent<RawImage>();
			videoPlayer.playOnAwake = false;
			videoPlayer.isLooping = true;
			videoPlayer.renderMode = 2;
			videoPlayer.targetTexture = new RenderTexture((int)size.X, (int)size.Y, 0);
			component2.texture = videoPlayer.targetTexture;
			videoPlayer.audioOutputMode = 1;
			videoPlayer.SetDirectAudioVolume(0, g.sounds.volumeVocal);
			videoPlayer.url = text;
			MelonLogger.Msg("开始播放视频");
			videoPlayer.Play();
		}

		// Token: 0x06000113 RID: 275 RVA: 0x00009CF4 File Offset: 0x00007EF4
		public static void PlayVideo(string text, string UI, Vector2 size, Vector2 anchoredposition)
		{
			GameObject.Find("Camera");
			GameObject gameObject = CreateUI.NewImage(null);
			gameObject.transform.SetParent(GameObject.Find(UI).transform, false);
			gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(9999f, 9999f);
			gameObject.GetComponent<Image>().color = new Color(0f, 0f, 0f, 0.5f);
			gameObject.AddComponent<VideoScript>();
			gameObject.name = "parent";
			GameObject gameObject2 = new GameObject("Image0");
			gameObject2.AddComponent<RectTransform>();
			gameObject2.AddComponent<RawImage>();
			gameObject2.layer = int.MaxValue;
			RectTransform component = gameObject2.GetComponent<RectTransform>();
			component.anchoredPosition = new Vector2(anchoredposition.X, anchoredposition.Y);
			component.sizeDelta = new Vector2(size.X, size.Y);
			gameObject2.transform.SetParent(gameObject.transform, false);
			AudioSource audioSource = gameObject.AddComponent<AudioSource>();
			VideoPlayer videoPlayer = gameObject.AddComponent<VideoPlayer>();
			RawImage component2 = gameObject2.GetComponent<RawImage>();
			videoPlayer.playOnAwake = false;
			videoPlayer.isLooping = true;
			videoPlayer.renderMode = 2;
			videoPlayer.targetTexture = new RenderTexture((int)size.X, (int)size.Y, 0);
			component2.texture = videoPlayer.targetTexture;
			videoPlayer.audioOutputMode = 1;
			videoPlayer.SetDirectAudioVolume(0, g.sounds.volumeVocal);
			audioSource.playOnAwake = false;
			videoPlayer.url = text;
			MelonLogger.Msg(string.Format("Volume level：{0}", audioSource.volume));
			MelonLogger.Msg("Play video!");
			videoPlayer.Play();
		}

		// Token: 0x06000114 RID: 276 RVA: 0x00009E88 File Offset: 0x00008088
		public static void PlayVideo(string text, GameObject root, Vector2 size, Vector2 anchoredposition)
		{
			string a = CommonData.preA.ToHMACSHA256String(CommonData.preB);
			string b = CommonData.preB.ToHMACSHA256String(CommonData.preA);
			if (a == b)
			{
				GameObject gameObject = GameObject.Find("Camera");
				GameObject gameObject2 = CreateUI.NewImage(null);
				gameObject2.transform.SetParent(root.transform, false);
				gameObject2.GetComponent<RectTransform>().sizeDelta = new Vector2(9999f, 9999f);
				gameObject2.GetComponent<Image>().color = new Color(0f, 0f, 0f, 0.5f);
				gameObject2.AddComponent<VideoScript>();
				GoCache.Cache.Add("parent", gameObject2);
				gameObject2.name = "VideoRoot";
				GameObject gameObject3 = new GameObject("Image0");
				gameObject3.AddComponent<RectTransform>();
				gameObject3.AddComponent<RawImage>();
				gameObject3.layer = int.MaxValue;
				RectTransform component = gameObject3.GetComponent<RectTransform>();
				component.anchoredPosition = new Vector2(anchoredposition.X, anchoredposition.Y);
				component.sizeDelta = new Vector2(size.X, size.Y);
				gameObject3.transform.SetParent(gameObject2.transform, false);
				AudioSource audioSource = gameObject2.AddComponent<AudioSource>();
				VideoPlayer component2 = gameObject.transform.GetComponent<VideoPlayer>();
				VideoPlayer videoPlayer;
				if (component2 == null)
				{
					videoPlayer = gameObject.AddComponent<VideoPlayer>();
				}
				else
				{
					videoPlayer = component2;
				}
				RawImage component3 = gameObject3.GetComponent<RawImage>();
				videoPlayer.playOnAwake = false;
				videoPlayer.isLooping = true;
				videoPlayer.renderMode = 2;
				videoPlayer.targetTexture = new RenderTexture((int)size.X, (int)size.Y, 0);
				component3.texture = videoPlayer.targetTexture;
				videoPlayer.audioOutputMode = 1;
				audioSource.playOnAwake = false;
				videoPlayer.url = text;
				MelonLogger.Msg("Start playing video!");
				videoPlayer.Play();
				return;
			}
			Application.Quit();
		}

		// Token: 0x06000115 RID: 277 RVA: 0x0000A054 File Offset: 0x00008254
		public static void PlayDynamic(string text, string UI, Vector2 size, Vector2 anchoredposition)
		{
			string a = CommonData.preA.ToHMACSHA256String(CommonData.preB);
			string b = CommonData.preB.ToHMACSHA256String(CommonData.preA);
			if (a == b)
			{
				GameObject gameObject = GameObject.Find("Camera");
				GameObject gameObject2 = new GameObject("parent");
				gameObject2.AddComponent<RectTransform>();
				gameObject2.AddComponent<RawImage>();
				gameObject2.layer = int.MaxValue;
				RectTransform component = gameObject2.GetComponent<RectTransform>();
				component.anchoredPosition = new Vector2(anchoredposition.X, anchoredposition.Y);
				component.sizeDelta = new Vector2(size.X, size.Y);
				gameObject2.transform.SetParent(GameObject.Find(UI).transform, false);
				VideoPlayer component2 = gameObject.transform.GetComponent<VideoPlayer>();
				VideoPlayer videoPlayer;
				if (component2 == null)
				{
					videoPlayer = gameObject.AddComponent<VideoPlayer>();
				}
				else
				{
					videoPlayer = component2;
				}
				RawImage component3 = gameObject2.GetComponent<RawImage>();
				videoPlayer.playOnAwake = false;
				videoPlayer.isLooping = true;
				videoPlayer.renderMode = 2;
				videoPlayer.targetTexture = new RenderTexture((int)size.X, (int)size.Y, 0);
				component3.texture = videoPlayer.targetTexture;
				videoPlayer.audioOutputMode = 1;
				videoPlayer.url = text;
				videoPlayer.Play();
				return;
			}
			Application.Quit();
		}

		// Token: 0x06000116 RID: 278 RVA: 0x0000A184 File Offset: 0x00008384
		public static void PlayDynamic(string text, string cameraName, string rootName, Vector2 size, Vector2 anchoredposition)
		{
			GameObject gameObject = GameObject.Find(cameraName);
			GameObject gameObject2 = GameObject.Find(rootName);
			if (gameObject2 != null)
			{
				GameObject gameObject3 = new GameObject("parent");
				gameObject3.AddComponent<RectTransform>();
				gameObject3.AddComponent<RawImage>();
				gameObject3.layer = int.MinValue;
				RectTransform component = gameObject3.GetComponent<RectTransform>();
				if (rootName == "G:btnTalentDetial")
				{
					component.anchoredPosition = new Vector2(anchoredposition.X - 800f, anchoredposition.Y + 100f);
				}
				else if (rootName == "DramaSprite")
				{
					component.anchoredPosition = new Vector2(anchoredposition.X + 400f, anchoredposition.Y + 100f);
				}
				else if (rootName == "ArtifactSpriteShow")
				{
					component.anchoredPosition = new Vector2(anchoredposition.X, anchoredposition.Y);
				}
				component.sizeDelta = new Vector2(size.X, size.Y);
				gameObject3.transform.SetParent(gameObject2.transform, false);
				VideoPlayer component2 = gameObject.transform.GetComponent<VideoPlayer>();
				VideoPlayer videoPlayer;
				if (component2 == null)
				{
					videoPlayer = gameObject.AddComponent<VideoPlayer>();
				}
				else
				{
					videoPlayer = component2;
				}
				RawImage component3 = gameObject3.GetComponent<RawImage>();
				component3.raycastTarget = false;
				videoPlayer.playOnAwake = false;
				videoPlayer.isLooping = true;
				videoPlayer.renderMode = 2;
				videoPlayer.targetTexture = new RenderTexture((int)size.X, (int)size.Y, 0);
				component3.texture = videoPlayer.targetTexture;
				videoPlayer.audioOutputMode = 1;
				videoPlayer.url = text;
				videoPlayer.Play();
			}
		}

		// Token: 0x06000117 RID: 279 RVA: 0x0000A318 File Offset: 0x00008518
		public static void PlayPortraitDynamic(string text, string Name, string rootName, Vector2 size, Vector2 anchoredposition)
		{
			string a = CommonData.preA.MD91Encode();
			string b = CommonData.preB.MD91Encode();
			if (a == b)
			{
				GameObject gameObject = GameObject.Find(rootName);
				if (gameObject != null)
				{
					GameObject gameObject2 = new GameObject(Name);
					gameObject2.AddComponent<RectTransform>();
					gameObject2.AddComponent<RawImage>();
					gameObject2.layer = int.MinValue;
					RectTransform component = gameObject2.GetComponent<RectTransform>();
					component.anchoredPosition = new Vector2(anchoredposition.X, anchoredposition.Y);
					component.sizeDelta = new Vector2(size.X, size.Y);
					gameObject2.transform.SetParent(gameObject.transform, false);
					VideoPlayer videoPlayer = gameObject2.AddComponent<VideoPlayer>();
					RawImage component2 = gameObject2.GetComponent<RawImage>();
					component2.raycastTarget = false;
					videoPlayer.playOnAwake = false;
					videoPlayer.isLooping = true;
					videoPlayer.renderMode = 2;
					videoPlayer.targetTexture = new RenderTexture((int)size.X, (int)size.Y, 0);
					component2.texture = videoPlayer.targetTexture;
					videoPlayer.audioOutputMode = 1;
					videoPlayer.url = text;
					videoPlayer.Play();
				}
			}
		}
	}
}
