using System;
using System.Collections.Generic;
using System.IO;
using Fatury.Bytes;
using Fautry;
using Harmony;
using Il2CppSystem;
using MelonLoader;
using UnityEngine;

namespace Fatury
{
	// Token: 0x0200001A RID: 26
	[HarmonyPatch(typeof(Resources), "Load", new Type[]
	{
		typeof(string),
		typeof(Type)
	})]
	public class ResLateLoadPatch
	{
		// Token: 0x060000D4 RID: 212 RVA: 0x00005E64 File Offset: 0x00004064
		public static Object Postfix(Object __result, string path, Type systemTypeInstance)
		{
			if (!path.StartsWith("SpriteAtlas"))
			{
				if (path.StartsWith("Game/ArtifactSprite"))
				{
					if (!CommonData.EditMode)
					{
						if (!GoCache.CacheName.ContainsKey(path))
						{
							return __result;
						}
						CommonData.currentPath = GoCache.CacheName[path];
						if (!File.Exists(Path.Combine(Helper.GetHome(), path, "asset.yml")))
						{
							return __result;
						}
						Worker worker = Worker.Pick(path);
						string templatePath = worker.TemplatePath;
						try
						{
							GameObject gameObject;
							if (GoCache.CacheName.ContainsKey(templatePath))
							{
								gameObject = worker.Rework(__result.TryCast<GameObject>());
							}
							else
							{
								gameObject = __result.TryCast<GameObject>();
							}
							__result = gameObject;
							return __result;
						}
						catch (Exception arg)
						{
							MelonLogger.Error(string.Format("{0}\n{1}", arg, templatePath));
							return __result;
						}
					}
					CommonData.currentPath = CommonData.faturyRootPath;
					if (File.Exists(Path.Combine(Helper.GetHome(), path, "asset.yml")))
					{
						Worker worker2 = Worker.Pick(path);
						string templatePath2 = worker2.TemplatePath;
						try
						{
							GameObject gameObject2;
							if (GoCache.Cache.ContainsKey(templatePath2))
							{
								gameObject2 = worker2.Rework(GoCache.Cache[templatePath2]);
								return __result;
							}
							gameObject2 = worker2.Rework(__result.TryCast<GameObject>());
							GoCache.Cache.Add(templatePath2, gameObject2);
							__result = gameObject2;
							return __result;
						}
						catch (Exception arg2)
						{
							MelonLogger.Error(string.Format("{0}\n{1}", arg2, templatePath2));
						}
					}
					return __result;
				}
				if (path.StartsWith("Game/NPCDynamic"))
				{
					if (!CommonData.EditMode)
					{
						if (!GoCache.Cache.ContainsKey(path))
						{
							return __result;
						}
						CommonData.currentPath = GoCache.CacheName[path];
						if (!Directory.Exists(Path.Combine(Helper.GetHome(), path)))
						{
							return __result;
						}
						Worker worker3 = Worker.Pick(path);
						string templatePath3 = worker3.TemplatePath;
						try
						{
							if (GoCache.Cache.ContainsKey(templatePath3))
							{
								return __result;
							}
							GameObject gameObject3 = worker3.Rework(__result.TryCast<GameObject>());
							__result = gameObject3;
							return __result;
						}
						catch (Exception arg3)
						{
							MelonLogger.Error(string.Format("{0}\n{1}", arg3, templatePath3));
							return __result;
						}
					}
					CommonData.currentPath = CommonData.faturyRootPath;
					if (!Directory.Exists(Path.Combine(Helper.GetHome(), path)))
					{
						return __result;
					}
					Worker worker4 = Worker.Pick(path);
					string templatePath4 = worker4.TemplatePath;
					try
					{
						GameObject gameObject4;
						if (GoCache.Cache.ContainsKey(templatePath4))
						{
							gameObject4 = worker4.Rework(GoCache.Cache[templatePath4]);
						}
						else
						{
							gameObject4 = worker4.Rework(__result.TryCast<GameObject>());
							GoCache.Cache.Add(templatePath4, gameObject4);
						}
						__result = gameObject4;
						return __result;
					}
					catch (Exception arg4)
					{
						MelonLogger.Error(string.Format("{0}\n{1}", arg4, templatePath4));
						return __result;
					}
				}
				if (path.StartsWith("Game/NPC/"))
				{
					if (GoCache.Cache.ContainsKey(path))
					{
						return GoCache.Cache[path];
					}
					return __result;
				}
				else
				{
					if (path.StartsWith("Battle/Monst"))
					{
						if (!GoCache.Cache.ContainsKey(path))
						{
							return __result;
						}
						CommonData.currentPath = GoCache.CacheName[path];
						if (!Directory.Exists(Path.Combine(Helper.GetHome(), path)))
						{
							return __result;
						}
						Worker worker5 = Worker.Pick(path);
						string templatePath5 = worker5.TemplatePath;
						try
						{
							if (GoCache.Cache.ContainsKey(templatePath5))
							{
								return __result;
							}
							GameObject gameObject5 = worker5.Rework(__result.TryCast<GameObject>());
							__result = gameObject5;
							return __result;
						}
						catch (Exception arg5)
						{
							MelonLogger.Error(string.Format("{0}\n{1}", arg5, templatePath5));
							return __result;
						}
					}
					if (path.StartsWith("Texture"))
					{
						if (!GoCache.CacheName.ContainsKey(path))
						{
							return __result;
						}
						CommonData.currentPath = GoCache.CacheName[path];
						string text = Path.Combine(Helper.GetHome(), path);
						if (!Directory.Exists(text))
						{
							return __result;
						}
						try
						{
							Sprite sprite = null;
							if (File.Exists(text + "\\asset.yml"))
							{
								EffectParam effectParam = EffectParam.LoadFromYaml(text + "\\asset.yml");
								if (File.Exists(text + "\\sprite.png"))
								{
									byte[] array = text.LoadSprite("sprite", ".png");
									Texture2D texture2D = new Texture2D(100, 100, 5, false);
									if (!ImageConversion.LoadImage(texture2D, array))
									{
										throw new InvalidOperationException();
									}
									sprite = Sprite.Create(texture2D, effectParam.Sprite["image"].Rect, effectParam.Sprite["image"].Pivot, effectParam.Sprite["image"].PixelsPerUnit, effectParam.Sprite["image"].Extrude);
								}
								else if (File.Exists(text + "\\sprite.dat"))
								{
									byte[] array2 = text.LoadSprite("sprite", ".dat");
									array2 = Imgs.DecryptImgs(array2);
									Texture2D texture2D2 = new Texture2D(100, 100, 5, false);
									if (!ImageConversion.LoadImage(texture2D2, array2))
									{
										throw new InvalidOperationException();
									}
									sprite = Sprite.Create(texture2D2, effectParam.Sprite["image"].Rect, effectParam.Sprite["image"].Pivot, effectParam.Sprite["image"].PixelsPerUnit, effectParam.Sprite["image"].Extrude);
								}
								__result = sprite;
								return __result;
							}
							if (File.Exists(text + "\\sprite.png"))
							{
								byte[] array3 = text.LoadSprite("sprite", ".png");
								ImageConversion.LoadImage(sprite.texture, array3);
							}
							else if (File.Exists(text + "\\sprite.dat"))
							{
								byte[] array4 = text.LoadSprite("sprite", ".dat");
								array4 = Imgs.DecryptImgs(array4);
								ImageConversion.LoadImage(sprite.texture, array4);
							}
							__result = sprite;
							return __result;
						}
						catch (Exception arg6)
						{
							MelonLogger.Error(string.Format("{0}", arg6));
							return __result;
						}
					}
					if (path.StartsWith("Effect/Battle/Skill"))
					{
						if (!GoCache.CacheName.ContainsKey(path))
						{
							return __result;
						}
						CommonData.currentPath = GoCache.CacheName[path];
						if (!Directory.Exists(Path.Combine(Helper.GetHome(), path)))
						{
							return __result;
						}
						Worker worker6 = Worker.Pick(path);
						string templatePath6 = worker6.TemplatePath;
						try
						{
							if (GoCache.Cache.ContainsKey(templatePath6))
							{
								return __result;
							}
							GameObject gameObject6 = worker6.Rework(__result.TryCast<GameObject>());
							__result = gameObject6;
							return __result;
						}
						catch (Exception arg7)
						{
							MelonLogger.Error(string.Format("{0}\n{1}", arg7, templatePath6));
							return __result;
						}
					}
					if (path.StartsWith("Effect/Battle/Unit/ql"))
					{
						if (!GoCache.CacheName.ContainsKey(path))
						{
							return __result;
						}
						CommonData.currentPath = GoCache.CacheName[path];
						string text2 = Helper.GetHome() + "/" + path;
						if (!File.Exists(Helper.GetHome() + "/" + path + "/asset.yml"))
						{
							if (systemTypeInstance.Name == "Transform")
							{
								if (Directory.Exists(Path.Combine(Helper.GetHome(), path)))
								{
									Transform transform = __result.Cast<Transform>();
									Worker worker7 = Worker.Pick(path);
									string templatePath7 = worker7.TemplatePath;
									try
									{
										if (GoCache.Cache.ContainsKey(templatePath7))
										{
											return __result;
										}
										worker7.Rework(transform.gameObject);
										return __result;
									}
									catch (Exception arg8)
									{
										MelonLogger.Error(string.Format("{0}\n{1}", arg8, templatePath7));
										return __result;
									}
								}
								return __result;
							}
							if (Directory.Exists(Path.Combine(Helper.GetHome(), path)))
							{
								Worker worker8 = Worker.Pick(path);
								string templatePath8 = worker8.TemplatePath;
								try
								{
									if (GoCache.Cache.ContainsKey(templatePath8))
									{
										return __result;
									}
									GameObject gameObject7 = worker8.Rework(__result.TryCast<GameObject>());
									__result = gameObject7;
									return __result;
								}
								catch (Exception arg9)
								{
									MelonLogger.Error(string.Format("{0}\n{1}", arg9, templatePath8));
									return __result;
								}
							}
							return __result;
						}
						else if (systemTypeInstance.Name == "Transform")
						{
							if (path == "Effect/Battle/Unit/ql_yushi")
							{
								return __result;
							}
							string text3 = "Effect/Battle/Unit/ql_yushi";
							GameObject gameObject8 = null;
							if (GoCache.Cache.ContainsKey(text3))
							{
								gameObject8 = GoCache.Cache[text3];
							}
							else
							{
								gameObject8 = Object.Instantiate<GameObject>(Resources.Load<GameObject>(text3), GoCache.Root.transform);
								GoCache.Cache.Add(text3, gameObject8);
							}
							foreach (Transform transform2 in gameObject8.GetComponentsInChildren<Transform>())
							{
								if (transform2.name == "bone_1")
								{
									transform2.gameObject.SetActive(false);
								}
							}
							EffectParam effectParam2 = EffectParam.LoadFromYaml(text2 + "\\asset.yml");
							if (File.Exists(text2 + "\\ql_shenti.png"))
							{
								byte[] array5 = text2.LoadSprite("ql_shenti", ".png");
								Texture2D texture2D3 = new Texture2D(100, 100, 5, false);
								if (!ImageConversion.LoadImage(texture2D3, array5))
								{
									throw new InvalidOperationException();
								}
								Sprite sprite2 = Sprite.Create(texture2D3, effectParam2.Sprite["image"].Rect, effectParam2.Sprite["image"].Pivot, effectParam2.Sprite["image"].PixelsPerUnit, effectParam2.Sprite["image"].Extrude);
								using (IEnumerator<SpriteRenderer> enumerator2 = gameObject8.GetComponentsInChildren<SpriteRenderer>().GetEnumerator())
								{
									while (enumerator2.MoveNext())
									{
										SpriteRenderer spriteRenderer = enumerator2.Current;
										if (spriteRenderer.name == "ql_shenti")
										{
											spriteRenderer.sprite = sprite2;
										}
									}
									goto IL_AE4;
								}
							}
							if (File.Exists(text2 + "\\ql_shenti.dat"))
							{
								byte[] array6 = text2.LoadSprite("ql_shenti", ".dat");
								array6 = Imgs.DecryptImgs(array6);
								Texture2D texture2D4 = new Texture2D(100, 100, 5, false);
								if (!ImageConversion.LoadImage(texture2D4, array6))
								{
									throw new InvalidOperationException();
								}
								Sprite sprite3 = Sprite.Create(texture2D4, effectParam2.Sprite["image"].Rect, effectParam2.Sprite["image"].Pivot, effectParam2.Sprite["image"].PixelsPerUnit, effectParam2.Sprite["image"].Extrude);
								foreach (SpriteRenderer spriteRenderer2 in gameObject8.GetComponentsInChildren<SpriteRenderer>())
								{
									if (spriteRenderer2.name == "ql_shenti")
									{
										spriteRenderer2.sprite = sprite3;
									}
								}
							}
							IL_AE4:
							return gameObject8.transform;
						}
						else
						{
							if (path == "Effect/Battle/Unit/ql_yushi")
							{
								return __result;
							}
							string text4 = "Effect/Battle/Unit/ql_yushi";
							GameObject gameObject9 = null;
							if (GoCache.Cache.ContainsKey(text4))
							{
								gameObject9 = GoCache.Cache[text4];
							}
							else
							{
								gameObject9 = Object.Instantiate<GameObject>(Resources.Load<GameObject>(text4), GoCache.Root.transform);
								GoCache.Cache.Add(text4, gameObject9);
							}
							foreach (Transform transform3 in gameObject9.GetComponentsInChildren<Transform>())
							{
								if (transform3.name == "bone_1")
								{
									transform3.gameObject.SetActive(false);
								}
							}
							EffectParam effectParam3 = EffectParam.LoadFromYaml(text2 + "\\asset.yml");
							if (File.Exists(text2 + "\\ql_shenti.png"))
							{
								byte[] array7 = text2.LoadSprite("ql_shenti", ".png");
								Texture2D texture2D5 = new Texture2D(100, 100, 5, false);
								if (!ImageConversion.LoadImage(texture2D5, array7))
								{
									throw new InvalidOperationException();
								}
								Sprite sprite4 = Sprite.Create(texture2D5, effectParam3.Sprite["image"].Rect, effectParam3.Sprite["image"].Pivot, effectParam3.Sprite["image"].PixelsPerUnit, effectParam3.Sprite["image"].Extrude);
								using (IEnumerator<SpriteRenderer> enumerator2 = gameObject9.GetComponentsInChildren<SpriteRenderer>().GetEnumerator())
								{
									while (enumerator2.MoveNext())
									{
										SpriteRenderer spriteRenderer3 = enumerator2.Current;
										if (spriteRenderer3.name == "ql_shenti")
										{
											spriteRenderer3.sprite = sprite4;
										}
									}
									goto IL_DB7;
								}
							}
							if (File.Exists(text2 + "\\ql_shenti.dat"))
							{
								byte[] array8 = text2.LoadSprite("ql_shenti", ".dat");
								array8 = Imgs.DecryptImgs(array8);
								Texture2D texture2D6 = new Texture2D(100, 100, 5, false);
								if (!ImageConversion.LoadImage(texture2D6, array8))
								{
									throw new InvalidOperationException();
								}
								Sprite sprite5 = Sprite.Create(texture2D6, effectParam3.Sprite["image"].Rect, effectParam3.Sprite["image"].Pivot, effectParam3.Sprite["image"].PixelsPerUnit, effectParam3.Sprite["image"].Extrude);
								foreach (SpriteRenderer spriteRenderer4 in gameObject9.GetComponentsInChildren<SpriteRenderer>())
								{
									if (spriteRenderer4.name == "ql_shenti")
									{
										spriteRenderer4.sprite = sprite5;
									}
								}
							}
							IL_DB7:
							if (gameObject9.GetComponent<ItemFloatScript>() == null)
							{
								gameObject9.AddComponent<ItemFloatScript>();
							}
							return gameObject9;
						}
					}
					else
					{
						if (path.StartsWith("Sounds/"))
						{
							if (!GoCache.CacheName.ContainsKey(path))
							{
								return __result;
							}
							CommonData.currentPath = GoCache.CacheName[path];
							string text5 = Path.Combine(new string[]
							{
								Helper.GetHome() + "/" + path
							}).Replace("\\", "/");
							if (!Directory.Exists(text5) || !File.Exists(text5 + "/asset.yml"))
							{
								return __result;
							}
							try
							{
								AudioParam audioParam = AudioParam.LoadFromYaml(text5 + "/asset.yml");
								AudioSource audioSource = null;
								string text6 = audioParam.audioParam["AudioParam"]["file"];
								Path.GetExtension(text6);
								"file://" + text5 + "/" + text6;
								if (GoCache.Cache.ContainsKey(text5))
								{
									MelonLogger.Msg(text5);
									audioSource = GoCache.Cache[text5].GetComponent<AudioSource>();
								}
								return audioSource.clip;
							}
							catch (Exception ex)
							{
								MelonLogger.Error(ex);
								return __result;
							}
						}
						if (path == "UI/IntoGameDrama" && GoCache.Cache.ContainsKey(path))
						{
							return GoCache.Cache[path];
						}
						return __result;
					}
				}
				Object result;
				return result;
			}
			if (GoCache.CacheSpriteAtlas.ContainsKey(path))
			{
				return GoCache.CacheSpriteAtlas[path];
			}
			return __result;
		}
	}
}
