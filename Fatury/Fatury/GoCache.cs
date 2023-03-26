using System;
using System.Collections.Generic;
using System.IO;
using Fatury.Bytes;
using Fautry;
using MelonLoader;
using UnhollowerBaseLib;
using UnityEngine;
using UnityEngine.U2D;

namespace Fatury
{
	// Token: 0x0200000D RID: 13
	internal static class GoCache
	{
		// Token: 0x06000091 RID: 145 RVA: 0x000034A0 File Offset: 0x000016A0
		static GoCache()
		{
			GoCache.Root = new GameObject
			{
				name = "Fatury cache",
				active = false
			};
			Object.DontDestroyOnLoad(GoCache.Root);
		}

		// Token: 0x06000092 RID: 146 RVA: 0x00003508 File Offset: 0x00001708
		public static void ArtifactSpritePrefetch(string fileName)
		{
			foreach (string text in new List<string>(Directory.GetDirectories(Path.Combine(Helper.GetHome(), "Game", "ArtifactSprite"), "*", SearchOption.AllDirectories)))
			{
				string text2 = text.Replace(Helper.GetHome() + "\\", "").Replace("\\", "/");
				MelonLogger.Msg("Prefetch: " + text2);
				Worker worker = Worker.Pick(text2);
				if (worker == null)
				{
					MelonLogger.Warning("Worker Not Found, path = " + text2);
				}
				else
				{
					try
					{
						string text3 = text2.Replace(Helper.GetHome(), "");
						if (!GoCache.Cache.ContainsKey(text3))
						{
							GameObject gameObject = Object.Instantiate<GameObject>(Resources.Load<GameObject>(text3), GoCache.Root.transform);
							worker.Rework(gameObject);
							GoCache.Cache.Add(text3, gameObject);
							GoCache.CacheName.Add(text3, fileName);
						}
					}
					catch (Exception arg)
					{
						MelonLogger.Warning(string.Format("Cache failed, path = {0}, \nreason: {1}", text2, arg));
					}
				}
			}
		}

		// Token: 0x06000093 RID: 147 RVA: 0x00003648 File Offset: 0x00001848
		public static void PortraitDynamicPrefetch(string fileName)
		{
			foreach (string text in new List<string>(Directory.GetDirectories(Path.Combine(Helper.GetHome(), "Game", "PortraitDynamic"), "*", SearchOption.AllDirectories)))
			{
				string text2 = text.Replace(Helper.GetHome() + "\\", "").Replace("\\", "/");
				MelonLogger.Msg("Prefetch: " + text2);
				Worker worker = Worker.Pick(text2);
				if (worker == null)
				{
					MelonLogger.Warning("Worker Not Found, path = " + text2);
				}
				else
				{
					try
					{
						string text3 = text2.Replace(Helper.GetHome(), "");
						if (!GoCache.Cache.ContainsKey(text3))
						{
							GameObject gameObject = Object.Instantiate<GameObject>(Resources.Load<GameObject>(text3), GoCache.Root.transform);
							worker.Rework(gameObject);
							GoCache.Cache.Add(text3, gameObject);
							GoCache.CacheName.Add(text3, fileName);
						}
					}
					catch (Exception arg)
					{
						MelonLogger.Warning(string.Format("Cache failed, path = {0}, \nreason: {1}", text2, arg));
					}
				}
			}
		}

		// Token: 0x06000094 RID: 148 RVA: 0x00003788 File Offset: 0x00001988
		public static void NPCDynamicPrefetch(string fileName)
		{
			foreach (string text in new List<string>(Directory.GetDirectories(Path.Combine(Helper.GetHome(), "Game", "NPCDynamic"), "*", SearchOption.AllDirectories)))
			{
				string text2 = text.Replace(Helper.GetHome() + "\\", "").Replace("\\", "/");
				MelonLogger.Msg("Prefetch: " + text2);
				Worker worker = Worker.Pick(text2);
				if (worker == null)
				{
					MelonLogger.Warning("Worker Not Found, path = " + text2);
				}
				else
				{
					try
					{
						string text3 = text2.Replace(Helper.GetHome(), "");
						if (!GoCache.Cache.ContainsKey(text3))
						{
							GameObject gameObject = Object.Instantiate<GameObject>(Resources.Load<GameObject>(text3), GoCache.Root.transform);
							worker.Rework(gameObject);
							GoCache.Cache.Add(text3, gameObject);
							GoCache.CacheName.Add(text3, fileName);
						}
					}
					catch (Exception arg)
					{
						MelonLogger.Warning(string.Format("Cache failed, path = {0}, \nreason: {1}", text2, arg));
					}
				}
			}
		}

		// Token: 0x06000095 RID: 149 RVA: 0x000038C8 File Offset: 0x00001AC8
		public static void NPCPrefetch(string fileName)
		{
			foreach (string text in new List<string>(Directory.GetDirectories(Path.Combine(Helper.GetHome(), "Game", "NPC"), "*", SearchOption.AllDirectories)))
			{
				string text2 = text.Replace(Helper.GetHome() + "\\", "").Replace("\\", "/");
				MelonLogger.Msg("Prefetch: " + text2);
				Worker worker = Worker.Pick(text2);
				if (worker == null)
				{
					MelonLogger.Warning("Worker Not Found, path = " + text2);
				}
				else
				{
					try
					{
						string text3 = text2.Replace(Helper.GetHome(), "");
						if (!GoCache.Cache.ContainsKey(text3))
						{
							GameObject gameObject = Resources.Load<GameObject>(text3);
							if (gameObject != null)
							{
								GameObject gameObject2 = Object.Instantiate<GameObject>(gameObject, GoCache.Root.transform);
								worker.Rework(gameObject2);
								GoCache.Cache.Add(text3, gameObject2);
								GoCache.CacheName.Add(text3, fileName);
							}
							else
							{
								string text4 = text;
								Sprite sprite = null;
								EffectParam effectParam = null;
								if (File.Exists(text4 + "\\asset.yml"))
								{
									effectParam = EffectParam.LoadFromYaml(text4 + "\\asset.yml");
								}
								if (File.Exists(text4 + "\\sprite.png"))
								{
									byte[] array = text4.LoadSprite("sprite", ".png");
									Texture2D texture2D = new Texture2D(100, 100, 5, false);
									if (!ImageConversion.LoadImage(texture2D, array))
									{
										throw new InvalidOperationException();
									}
									sprite = Sprite.Create(texture2D, effectParam.Sprite["image"].Rect, effectParam.Sprite["image"].Pivot, effectParam.Sprite["image"].PixelsPerUnit, effectParam.Sprite["image"].Extrude);
								}
								else if (File.Exists(text4 + "\\sprite.dat"))
								{
									byte[] array2 = text4.LoadSprite("sprite", ".dat");
									array2 = Imgs.DecryptImgs(array2);
									Texture2D texture2D2 = new Texture2D(100, 100, 5, false);
									if (!ImageConversion.LoadImage(texture2D2, array2))
									{
										throw new InvalidOperationException();
									}
									sprite = Sprite.Create(texture2D2, effectParam.Sprite["image"].Rect, effectParam.Sprite["image"].Pivot, effectParam.Sprite["image"].PixelsPerUnit, effectParam.Sprite["image"].Extrude);
								}
								GameObject gameObject3 = Object.Instantiate<GameObject>(Resources.Load<GameObject>("Game/NPC/Root/6020"), GoCache.Root.transform);
								foreach (SpriteRenderer spriteRenderer in gameObject3.GetComponentsInChildren<SpriteRenderer>())
								{
									spriteRenderer.sprite = sprite;
								}
								GoCache.Cache.Add(text3, gameObject3);
								GoCache.CacheName.Add(text3, fileName);
							}
						}
					}
					catch (Exception arg)
					{
						MelonLogger.Warning(string.Format("Cache failed, path = {0}, \nreason: {1}", text2, arg));
					}
				}
			}
		}

		// Token: 0x06000096 RID: 150 RVA: 0x00003C64 File Offset: 0x00001E64
		public static void SpriteAtlasPrefetch(string fileName)
		{
			foreach (string text in new List<string>(Directory.GetDirectories(Path.Combine(Helper.GetHome(), "SpriteAtlas"), "*", SearchOption.AllDirectories)))
			{
				string text2 = text.Replace(Helper.GetHome() + "\\", "").Replace("\\", "/");
				MelonLogger.Msg("Prefetch: " + text2);
				try
				{
					string text3 = text2.Replace(Helper.GetHome(), "");
					if (!GoCache.CacheName.ContainsKey(text3) && Resources.Load<SpriteAtlas>(text3) != null)
					{
						SpriteAtlas spriteAtlas = Object.Instantiate<SpriteAtlas>(Resources.Load<SpriteAtlas>(text3));
						if (spriteAtlas.spriteCount > 0)
						{
							Il2CppReferenceArray<Sprite> il2CppReferenceArray = new Il2CppReferenceArray<Sprite>(1L);
							spriteAtlas.GetSprites(il2CppReferenceArray);
							Sprite sprite = il2CppReferenceArray[0];
							string text4 = Helper.GetHome() + "/" + text2;
							if (File.Exists(text4 + "/sprite.png"))
							{
								byte[] array = text4.LoadSprite("sprite", ".png");
								ImageConversion.LoadImage(sprite.texture, array);
							}
							else if (File.Exists(Path.Combine(new string[]
							{
								text4 + "/sprite.dat"
							})))
							{
								byte[] array2 = text4.LoadSprite("sprite", ".dat");
								array2 = Imgs.DecryptImgs(array2);
								ImageConversion.LoadImage(sprite.texture, array2);
							}
						}
						GoCache.CacheName.Add(text3, fileName);
					}
				}
				catch (Exception arg)
				{
					MelonLogger.Warning(string.Format("Cache failed, path = {0}, \nreason: {1}", text2, arg));
				}
			}
		}

		// Token: 0x06000097 RID: 151 RVA: 0x00003E54 File Offset: 0x00002054
		public static void PortraitPrefetch(string fileName)
		{
			foreach (string text in new List<string>(Directory.GetDirectories(Path.Combine(Helper.GetHome(), "Game", "Portrait"), "*", SearchOption.AllDirectories)))
			{
				if (text.EndsWith("\\_child\\sprite"))
				{
					string text2 = text.Replace(Helper.GetHome() + "\\", "").Replace("\\", "/");
					text2 = text2.Replace("/_child/sprite", "");
					MelonLogger.Msg("Prefetch: " + text2);
					Worker worker = Worker.Pick(text2);
					if (worker == null)
					{
						break;
					}
					string templatePath = worker.TemplatePath;
					try
					{
						if (!GoCache.Cache.ContainsKey(text2))
						{
							GameObject gameObject = Object.Instantiate<GameObject>(Resources.Load<GameObject>(templatePath), GoCache.Root.transform);
							GoCache.Cache.Add(text2, gameObject);
							GoCache.CacheName.Add(text2, fileName);
							worker.Rework(gameObject);
						}
					}
					catch (Exception arg)
					{
						MelonLogger.Error(string.Format("{0}\n{1}", arg, templatePath));
					}
				}
			}
		}

		// Token: 0x06000098 RID: 152 RVA: 0x00003FA4 File Offset: 0x000021A4
		public static void MonstPrefetch(string fileName)
		{
			foreach (string text in new List<string>(Directory.GetDirectories(Path.Combine(Helper.GetHome(), "Battle", "Monst"), "*", SearchOption.AllDirectories)))
			{
				string text2 = text.Replace(Helper.GetHome() + "\\", "").Replace("\\", "/");
				MelonLogger.Msg("Prefetch: " + text2);
				Worker worker = Worker.Pick(text2);
				if (worker == null)
				{
					MelonLogger.Warning("Worker Not Found, path = " + text2);
				}
				else
				{
					try
					{
						string text3 = text2.Replace(Helper.GetHome(), "");
						if (!GoCache.Cache.ContainsKey(text3))
						{
							GameObject gameObject = Object.Instantiate<GameObject>(Resources.Load<GameObject>(text3), GoCache.Root.transform);
							worker.Rework(gameObject);
							GoCache.Cache.Add(text3, gameObject);
							GoCache.CacheName.Add(text3, fileName);
						}
					}
					catch (Exception arg)
					{
						MelonLogger.Warning(string.Format("Cache failed, path = {0}, \nreason: {1}", text2, arg));
					}
				}
			}
		}

		// Token: 0x06000099 RID: 153 RVA: 0x000040E4 File Offset: 0x000022E4
		public static void TexturePrefetch(string fileName)
		{
			foreach (string text in new List<string>(Directory.GetDirectories(Path.Combine(Helper.GetHome(), "Texture"), "*", SearchOption.AllDirectories)))
			{
				string text2 = text.Replace(Helper.GetHome() + "\\", "").Replace("\\", "/");
				MelonLogger.Msg("Prefetch: " + text2);
				if (Worker.Pick(text2) == null)
				{
					MelonLogger.Warning("Worker Not Found, path = " + text2);
				}
				else
				{
					try
					{
						string key = text2.Replace(Helper.GetHome(), "");
						if (!GoCache.CacheName.ContainsKey(key))
						{
							GoCache.CacheName.Add(key, fileName);
						}
					}
					catch (Exception arg)
					{
						MelonLogger.Warning(string.Format("Cache failed, path = {0}, \nreason: {1}", text2, arg));
					}
				}
			}
		}

		// Token: 0x0600009A RID: 154 RVA: 0x000041F0 File Offset: 0x000023F0
		public static void EffectBattlePrefetch(string fileName)
		{
			foreach (string text in new List<string>(Directory.GetDirectories(Path.Combine(Helper.GetHome(), "Effect", "Battle"), "*", SearchOption.AllDirectories)))
			{
				string text2 = text.Replace(Helper.GetHome() + "\\", "").Replace("\\", "/");
				MelonLogger.Msg("Prefetch: " + text2);
				if (Worker.Pick(text2) == null)
				{
					MelonLogger.Warning("Worker Not Found, path = " + text2);
				}
				else
				{
					try
					{
						string key = text2.Replace(Helper.GetHome(), "");
						if (!GoCache.CacheName.ContainsKey(key))
						{
							GoCache.CacheName.Add(key, fileName);
						}
					}
					catch (Exception arg)
					{
						MelonLogger.Warning(string.Format("Cache failed, path = {0}, \nreason: {1}", text2, arg));
					}
				}
			}
		}

		// Token: 0x0600009B RID: 155 RVA: 0x00004300 File Offset: 0x00002500
		public static void SoundsPrefetch(string fileName)
		{
			GoCache.Prefetch(new List<string>(Directory.GetDirectories(Path.Combine(Helper.GetHome(), "Sounds"), "*", SearchOption.AllDirectories)), fileName);
		}

		// Token: 0x0600009C RID: 156 RVA: 0x00004328 File Offset: 0x00002528
		public static void Prefetch(List<string> dirs, string fileName)
		{
			foreach (string text in dirs)
			{
				string text2 = text.Replace(Helper.GetHome() + "\\", "").Replace("\\", "/");
				string key = text2.Replace(Helper.GetHome(), "");
				MelonLogger.Msg("Prefetch: " + text2);
				try
				{
					string text3 = Path.Combine(new string[]
					{
						Helper.GetHome() + "/" + text2
					}).Replace("\\", "/");
					if (Directory.Exists(text3) && File.Exists(text3 + "/asset.yml"))
					{
						try
						{
							AudioParam audioParam = AudioParam.LoadFromYaml(text3 + "/asset.yml");
							string text4 = audioParam.audioParam["AudioParam"]["file"];
							string extension = Path.GetExtension(text4);
							byte[] array = text.LoadSprite(audioParam.audioParam["AudioParam"]["file"]);
							string text5 = text3 + "/" + text4;
							text5 = text5.Replace(".dat", ".wav");
							bool flag = false;
							if (extension == ".dat")
							{
								flag = true;
								array = Imgs2.DecryptImgs(array);
								FileStream fileStream = new FileStream(text5, FileMode.OpenOrCreate, FileAccess.Write);
								fileStream.Write(array, 0, array.Length);
								fileStream.Close();
							}
							AudioClip clip = ModTool.LoadWavInFile(text5, true);
							GameObject gameObject = new GameObject(text2);
							gameObject.transform.SetParent(GoCache.Root.transform);
							gameObject.AddComponent<AudioSource>().clip = clip;
							GoCache.Cache.Add(text3, gameObject);
							if (!GoCache.CacheName.ContainsKey(key))
							{
								GoCache.CacheName.Add(key, fileName);
							}
							if (flag)
							{
								File.Delete(text5);
							}
						}
						catch (Exception ex)
						{
							MelonLogger.Error(ex);
						}
					}
				}
				catch (Exception arg)
				{
					MelonLogger.Warning(string.Format("Cache failed, path = {0}, \nreason: {1}", text2, arg));
				}
			}
		}

		// Token: 0x04000039 RID: 57
		public static readonly GameObject Root;

		// Token: 0x0400003A RID: 58
		public static readonly Dictionary<string, GameObject> Cache = new Dictionary<string, GameObject>();

		// Token: 0x0400003B RID: 59
		public static readonly Dictionary<string, string> CacheName = new Dictionary<string, string>();

		// Token: 0x0400003C RID: 60
		public static readonly Dictionary<string, SpriteAtlas> CacheSpriteAtlas = new Dictionary<string, SpriteAtlas>();

		// Token: 0x0400003D RID: 61
		public static readonly List<string> CacheShuangxiu = new List<string>();

		// Token: 0x0400003E RID: 62
		public static readonly List<string> CacheShuangxiuyuehui = new List<string>();
	}
}
