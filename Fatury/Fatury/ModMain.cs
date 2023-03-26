using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using Fatury.Bytes;
using Fautry;
using HarmonyLib;
using MelonLoader;
using UnhollowerRuntimeLib;
using UnityEngine;
using UnityEngine.UI;

namespace Fatury
{
	// Token: 0x02000012 RID: 18
	public class ModMain
	{
		// Token: 0x060000A9 RID: 169 RVA: 0x00004B5C File Offset: 0x00002D5C
		public void Init()
		{
			string path = Path.Combine(MelonUtils.GameDirectory, "Mods", "Yanmie", "Yanmie.key");
			if (Directory.Exists(Path.Combine(MelonUtils.GameDirectory, "Mods", "Yanmie")))
			{
				CommonData.JF = true;
			}
			if (File.Exists(path))
			{
				CommonData.JF = true;
				string text = ByteConverters.ByteToHex(File.ReadAllBytes(path));
				Console.WriteLine(text);
				byte[] array = ByteConverters.HexToByte(text.Remove(text.Length - 1));
				FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
				fileStream.Write(array, 1, array.Length - 2);
				fileStream.Close();
			}
			FaturyMain.ReadData();
			ClassInjector.RegisterTypeInIl2Cpp<VideoScript>();
			ClassInjector.RegisterTypeInIl2Cpp<ArtifactSpriteScript>();
			ClassInjector.RegisterTypeInIl2Cpp<ItemFloatScript>();
			ClassInjector.RegisterTypeInIl2Cpp<PortraitDynamicScript>();
			ClassInjector.RegisterTypeInIl2Cpp<WholePortraitScript>();
			int num = 0;
			int num2 = 0;
			if (CommonData.prefetched)
			{
				return;
			}
			if (!GoCache.Cache.ContainsKey("UI"))
			{
				byte[] array2 = Path.Combine(g.mod.GetModPathRoot("q9CYCo"), "ModAssets").LoadSprite("UI", ".png");
				Texture2D texture2D = new Texture2D(100, 100, 5, false);
				if (!ImageConversion.LoadImage(texture2D, array2))
				{
					throw new InvalidOperationException();
				}
				Sprite sprite = Sprite.Create(texture2D, new Rect(new Vector2(0f, 0f), new Vector2(1824f, 1024f)), new Vector2(0.5f, 0.5f), 100f, 1U);
				GameObject gameObject = CreateUI.NewImage(sprite);
				gameObject.transform.SetParent(GoCache.Root.transform, false);
				gameObject.AddComponent<SpriteRenderer>().sprite = sprite;
				GoCache.Cache.Add("UI", gameObject);
			}
			AssetParam assetParam = AssetParam.LoadFromYaml(Path.Combine(g.mod.GetModPathRoot("q9CYCo"), "ModAssets", "asset.yml"));
			CommonData.EditMode = assetParam.EditMode;
			CommonData.prefetching = true;
			MelonLogger.Msg("RootPath：" + CommonData.rootPath);
			ModMgr.ModLoadData loadOrderData = g.mod.GetLoadOrderData();
			if (!CommonData.EditMode)
			{
				foreach (ModMgr.ModLoadData.Item item in loadOrderData.mods)
				{
					if (item.isLoad)
					{
						CommonData.currentPath = item.modFolderName;
						MelonLogger.Msg(Helper.GetHome());
						if (Directory.Exists(Helper.GetHome()))
						{
							string home = Helper.GetHome();
							if (!(item.modFolderName == "2893505774"))
							{
								MelonLogger.Msg("------------------------------Prefetch " + item.modFolderName + "-------------------------------");
								if (Directory.Exists(home + "/UI/IntoGameDrama"))
								{
									try
									{
										MelonLogger.Msg("Prefetch:/UI/IntoGameDrama");
										GameObject gameObject2 = Object.Instantiate<GameObject>(Resources.Load<GameObject>("UI/IntoGameDrama"), GoCache.Root.transform);
										string text2 = home + "/UI/IntoGameDrama";
										Image componentInChildren = gameObject2.transform.Find("G:goRoot/BG1/BG1").GetComponentInChildren<Image>();
										if (File.Exists(text2 + "/kaijujuqing1.png"))
										{
											byte[] array3 = text2.LoadSprite("kaijujuqing1", ".png");
											Texture2D texture2D2 = new Texture2D(100, 100, 5, false);
											if (!ImageConversion.LoadImage(texture2D2, array3))
											{
												throw new InvalidOperationException();
											}
											Sprite sprite2 = Sprite.Create(texture2D2, new Rect(new Vector2(0f, 0f), new Vector2(1920f, 1920f)), new Vector2(0.5f, 0.5f), 100f, 1U);
											componentInChildren.sprite = sprite2;
										}
										else if (File.Exists(text2 + "/kaijujuqing1.dat"))
										{
											byte[] array3 = text2.LoadSprite("kaijujuqing1", ".dat");
											array3 = Imgs.DecryptImgs(array3);
											Texture2D texture2D3 = new Texture2D(100, 100, 5, false);
											if (!ImageConversion.LoadImage(texture2D3, array3))
											{
												throw new InvalidOperationException();
											}
											Sprite sprite3 = Sprite.Create(texture2D3, new Rect(new Vector2(0f, 0f), new Vector2(1920f, 1920f)), new Vector2(0.5f, 0.5f), 100f, 1U);
											componentInChildren.sprite = sprite3;
										}
										Image componentInChildren2 = gameObject2.transform.Find("G:goRoot/BG2/BG2").GetComponentInChildren<Image>();
										if (File.Exists(text2 + "/kaijujuqing2.png"))
										{
											byte[] array4 = text2.LoadSprite("kaijujuqing2", ".png");
											Texture2D texture2D4 = new Texture2D(100, 100, 5, false);
											if (!ImageConversion.LoadImage(texture2D4, array4))
											{
												throw new InvalidOperationException();
											}
											Sprite sprite4 = Sprite.Create(texture2D4, new Rect(new Vector2(0f, 0f), new Vector2(1920f, 1920f)), new Vector2(0.5f, 0.5f), 100f, 1U);
											componentInChildren2.sprite = sprite4;
										}
										else if (File.Exists(text2 + "/kaijujuqing2.dat"))
										{
											byte[] array4 = text2.LoadSprite("kaijujuqing2", ".dat");
											array4 = Imgs.DecryptImgs(array4);
											Texture2D texture2D5 = new Texture2D(100, 100, 5, false);
											if (!ImageConversion.LoadImage(texture2D5, array4))
											{
												throw new InvalidOperationException();
											}
											Sprite sprite5 = Sprite.Create(texture2D5, new Rect(new Vector2(0f, 0f), new Vector2(1920f, 1920f)), new Vector2(0.5f, 0.5f), 100f, 1U);
											componentInChildren2.sprite = sprite5;
										}
										Image componentInChildren3 = gameObject2.transform.Find("G:goRoot/BG3/BG3").GetComponentInChildren<Image>();
										if (File.Exists(text2 + "/kaijujuqing3.png"))
										{
											byte[] array5 = text2.LoadSprite("kaijujuqing3", ".png");
											Texture2D texture2D6 = new Texture2D(100, 100, 5, false);
											if (!ImageConversion.LoadImage(texture2D6, array5))
											{
												throw new InvalidOperationException();
											}
											Sprite sprite6 = Sprite.Create(texture2D6, new Rect(new Vector2(0f, 0f), new Vector2(1920f, 1920f)), new Vector2(0.5f, 0.5f), 100f, 1U);
											componentInChildren3.sprite = sprite6;
										}
										else if (File.Exists(text2 + "/kaijujuqing3.dat"))
										{
											byte[] array5 = text2.LoadSprite("kaijujuqing3", ".dat");
											array5 = Imgs.DecryptImgs(array5);
											Texture2D texture2D7 = new Texture2D(100, 100, 5, false);
											if (!ImageConversion.LoadImage(texture2D7, array5))
											{
												throw new InvalidOperationException();
											}
											Sprite sprite7 = Sprite.Create(texture2D7, new Rect(new Vector2(0f, 0f), new Vector2(1920f, 1920f)), new Vector2(0.5f, 0.5f), 100f, 1U);
											componentInChildren3.sprite = sprite7;
										}
										GoCache.Cache.Add("UI/IntoGameDrama", gameObject2);
									}
									catch (Exception)
									{
									}
								}
								Stopwatch stopwatch = new Stopwatch();
								MelonLogger.Msg("SpriteAtlas prefetch start...");
								stopwatch.Start();
								if (Directory.Exists(home + "/SpriteAtlas"))
								{
									GoCache.SpriteAtlasPrefetch(item.modFolderName);
								}
								stopwatch.Stop();
								MelonLogger.Msg(string.Format("Prefetch end, total: {0}", stopwatch.Elapsed));
								MelonLogger.Msg("");
								Stopwatch stopwatch2 = new Stopwatch();
								MelonLogger.Msg("Portrait prefetch start...");
								stopwatch2.Start();
								if (Directory.Exists(home + "/Game/Portrait"))
								{
									GoCache.PortraitPrefetch(item.modFolderName);
								}
								stopwatch2.Stop();
								MelonLogger.Msg(string.Format("Prefetch end, total: {0}", stopwatch2.Elapsed));
								MelonLogger.Msg("");
								Stopwatch stopwatch3 = new Stopwatch();
								MelonLogger.Msg("PortraitDynamic prefetch start...");
								stopwatch3.Start();
								if (Directory.Exists(home + "/Game/PortraitDynamic"))
								{
									GoCache.PortraitDynamicPrefetch(item.modFolderName);
								}
								stopwatch3.Stop();
								MelonLogger.Msg(string.Format("Prefetch end, total: {0}", stopwatch3.Elapsed));
								MelonLogger.Msg("");
								Stopwatch stopwatch4 = new Stopwatch();
								MelonLogger.Msg("ArtifactSprite prefetch start...");
								stopwatch4.Start();
								if (Directory.Exists(home + "/Game/ArtifactSprite"))
								{
									GoCache.ArtifactSpritePrefetch(item.modFolderName);
								}
								stopwatch4.Stop();
								MelonLogger.Msg(string.Format("Prefetch end, total: {0}", stopwatch4.Elapsed));
								MelonLogger.Msg("");
								Stopwatch stopwatch5 = new Stopwatch();
								MelonLogger.Msg("NPCDynamic prefetch start...");
								stopwatch5.Start();
								if (Directory.Exists(home + "/Game/NPCDynamic"))
								{
									GoCache.NPCDynamicPrefetch(item.modFolderName);
								}
								stopwatch5.Stop();
								MelonLogger.Msg(string.Format("Prefetch end, total: {0}", stopwatch5.Elapsed));
								MelonLogger.Msg("");
								Stopwatch stopwatch6 = new Stopwatch();
								MelonLogger.Msg("Monst prefetch start...");
								stopwatch6.Start();
								if (Directory.Exists(Path.Combine(new string[]
								{
									Helper.GetHome() + "/Battle/Monst"
								})))
								{
									GoCache.MonstPrefetch(item.modFolderName);
								}
								stopwatch6.Stop();
								MelonLogger.Msg(string.Format("Prefetch end, total: {0}", stopwatch6.Elapsed));
								MelonLogger.Msg("");
								Stopwatch stopwatch7 = new Stopwatch();
								MelonLogger.Msg("NPC prefetch start...");
								stopwatch7.Start();
								if (Directory.Exists(Path.Combine(new string[]
								{
									Helper.GetHome() + "/Game/NPC"
								})))
								{
									GoCache.NPCPrefetch(item.modFolderName);
								}
								stopwatch7.Stop();
								MelonLogger.Msg(string.Format("Prefetch end, total: {0}", stopwatch7.Elapsed));
								MelonLogger.Msg("");
								Stopwatch stopwatch8 = new Stopwatch();
								MelonLogger.Msg("Texture prefetch start...");
								stopwatch8.Start();
								if (Directory.Exists(Path.Combine(new string[]
								{
									Helper.GetHome() + "/Texture"
								})))
								{
									GoCache.TexturePrefetch(item.modFolderName);
								}
								stopwatch8.Stop();
								MelonLogger.Msg(string.Format("Prefetch end, total: {0}", stopwatch8.Elapsed));
								MelonLogger.Msg("");
								Stopwatch stopwatch9 = new Stopwatch();
								MelonLogger.Msg("EffectBattle prefetch start...");
								stopwatch9.Start();
								if (Directory.Exists(home + "/Effect/Battle"))
								{
									GoCache.EffectBattlePrefetch(item.modFolderName);
								}
								stopwatch9.Stop();
								MelonLogger.Msg(string.Format("Prefetch end, total: {0}", stopwatch9.Elapsed));
								MelonLogger.Msg("");
								Stopwatch stopwatch10 = new Stopwatch();
								MelonLogger.Msg("Sounds prefetch start...");
								stopwatch10.Start();
								if (Directory.Exists(home + "/Sounds"))
								{
									GoCache.SoundsPrefetch(item.modFolderName);
								}
								stopwatch10.Stop();
								MelonLogger.Msg(string.Format("Prefetch end, total: {0}", stopwatch10.Elapsed));
								MelonLogger.Msg("");
								CommonData.prefetching = false;
								MelonLogger.Msg("");
								try
								{
									foreach (string text3 in Directory.GetDirectories(Helper.GetHome() + "\\Effect\\UI\\Shuangxiu", "*", SearchOption.AllDirectories))
									{
										MelonLogger.Msg(text3);
										if (text3.StartsWith(Helper.GetHome() + "\\Effect\\UI\\Shuangxiu\\Shuangxiu"))
										{
											num++;
											string item2 = text3;
											GoCache.CacheShuangxiu.Add(item2);
										}
									}
									foreach (string text4 in Directory.GetDirectories(Helper.GetHome() + "\\Effect\\UI\\Shuangxiuyuehui", "*", SearchOption.AllDirectories))
									{
										MelonLogger.Msg(text4);
										if (text4.StartsWith(Helper.GetHome() + "\\Effect\\UI\\Shuangxiuyuehui\\Shuangxiu"))
										{
											num2++;
											string item3 = text4;
											GoCache.CacheShuangxiuyuehui.Add(item3);
										}
									}
								}
								catch (Exception)
								{
								}
							}
						}
					}
				}
				MelonLogger.Msg("Shuangxiu files：" + num.ToString());
				CommonData.shuangxiusum = num;
				CommonData.countshuangxiusum = 1;
				MelonLogger.Msg("Shuangxiuyuehui files：" + num2.ToString());
				CommonData.shuangxiuyuehuisum = num2;
				CommonData.countshuangxiuyuehuisum = 1;
			}
			if (assetParam.shuangxiutype == 1)
			{
				MelonLogger.Msg("Shuangxiu type：Order playback ");
			}
			else if (assetParam.shuangxiutype == 2)
			{
				MelonLogger.Msg("Shuangxiu type: Random broadcast");
			}
			CommonData.shuangxiutype = assetParam.shuangxiutype;
			CommonData.shuangxiuyuehuitype = assetParam.shuangxiutype;
			CommonData.prefetched = true;
			new Harmony("Fatury").PatchAll(Assembly.GetExecutingAssembly());
			this.corUpdate = g.timer.Frame(new Action(this.OnUpdate), 1, true);
		}

		// Token: 0x060000AA RID: 170 RVA: 0x00005818 File Offset: 0x00003A18
		public void Destroy()
		{
			g.timer.Stop(this.corUpdate);
		}

		// Token: 0x060000AB RID: 171 RVA: 0x0000582A File Offset: 0x00003A2A
		private void OnUpdate()
		{
		}

		// Token: 0x04000041 RID: 65
		private TimerCoroutine corUpdate;
	}
}
