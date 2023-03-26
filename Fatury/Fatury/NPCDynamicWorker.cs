using System;
using System.Collections.Generic;
using System.IO;
using Fatury.Bytes;
using MelonLoader;
using UnityEngine;

namespace Fatury
{
	// Token: 0x02000025 RID: 37
	internal class NPCDynamicWorker : Worker
	{
		// Token: 0x0600010A RID: 266 RVA: 0x000089E0 File Offset: 0x00006BE0
		public override GameObject Rework(GameObject template)
		{
			List<string> list = new List<string>();
			List<string> list2 = new List<string>();
			MelonLogger.Msg("Load:" + base.AbsolutelyPhysicalPath);
			string path = Path.Combine(new string[]
			{
				base.AbsolutelyPhysicalPath + "/asset.yml"
			});
			RemakeParam remakeParam = null;
			int num = 0;
			if (File.Exists(path))
			{
				num = 1;
				remakeParam = RemakeParam.LoadFromYaml(path);
			}
			if (num == 1)
			{
				if (remakeParam.assettype == "lihui")
				{
					if (GoCache.Cache.ContainsKey(base.TemplatePath))
					{
						foreach (SpriteRenderer spriteRenderer in template.GetComponentsInChildren<SpriteRenderer>())
						{
							if (remakeParam.remakeparam.ContainsKey(spriteRenderer.name))
							{
								if (remakeParam.remakeparam[spriteRenderer.name].ContainsKey("localposition"))
								{
									spriteRenderer.gameObject.transform.localPosition = new Vector3(remakeParam.remakeparam[spriteRenderer.name]["localposition"].X, remakeParam.remakeparam[spriteRenderer.name]["localposition"].Y, remakeParam.remakeparam[spriteRenderer.name]["localposition"].Z);
								}
								if (remakeParam.remakeparam[spriteRenderer.name].ContainsKey("localscale"))
								{
									spriteRenderer.gameObject.transform.localScale = new Vector3(remakeParam.remakeparam[spriteRenderer.name]["localscale"].X, remakeParam.remakeparam[spriteRenderer.name]["localscale"].Y, remakeParam.remakeparam[spriteRenderer.name]["localscale"].Z);
								}
								if (remakeParam.remakeparam[spriteRenderer.name].ContainsKey("localeulerangles"))
								{
									spriteRenderer.transform.transform.localEulerAngles = new Vector3(remakeParam.remakeparam[spriteRenderer.name]["localeulerangles"].X, remakeParam.remakeparam[spriteRenderer.name]["localeulerangles"].Y, remakeParam.remakeparam[spriteRenderer.name]["localeulerangles"].Z);
								}
							}
						}
						return template;
					}
					if (!GoCache.Cache.ContainsKey(base.TemplatePath))
					{
						foreach (SpriteRenderer spriteRenderer2 in template.GetComponentsInChildren<SpriteRenderer>())
						{
							if (num == 1 && remakeParam.remakeparam.ContainsKey(spriteRenderer2.name))
							{
								if (remakeParam.remakeparam[spriteRenderer2.name].ContainsKey("localposition"))
								{
									spriteRenderer2.gameObject.transform.localPosition = new Vector3(remakeParam.remakeparam[spriteRenderer2.name]["localposition"].X, remakeParam.remakeparam[spriteRenderer2.name]["localposition"].Y, remakeParam.remakeparam[spriteRenderer2.name]["localposition"].Z);
								}
								if (remakeParam.remakeparam[spriteRenderer2.name].ContainsKey("localscale"))
								{
									spriteRenderer2.gameObject.transform.localScale = new Vector3(remakeParam.remakeparam[spriteRenderer2.name]["localscale"].X, remakeParam.remakeparam[spriteRenderer2.name]["localscale"].Y, remakeParam.remakeparam[spriteRenderer2.name]["localscale"].Z);
								}
								if (remakeParam.remakeparam[spriteRenderer2.name].ContainsKey("localeulerangles"))
								{
									spriteRenderer2.transform.transform.localEulerAngles = new Vector3(remakeParam.remakeparam[spriteRenderer2.name]["localeulerangles"].X, remakeParam.remakeparam[spriteRenderer2.name]["localeulerangles"].Y, remakeParam.remakeparam[spriteRenderer2.name]["localeulerangles"].Z);
								}
							}
							if (File.Exists(Path.Combine(new string[]
							{
								base.AbsolutelyPhysicalPath + "/" + spriteRenderer2.name + ".png"
							})))
							{
								list.Add(spriteRenderer2.name);
								byte[] array = base.AbsolutelyPhysicalPath.LoadSprite(spriteRenderer2.name, ".png");
								ImageConversion.LoadImage(spriteRenderer2.sprite.texture, array);
							}
							else if (File.Exists(Path.Combine(new string[]
							{
								base.AbsolutelyPhysicalPath + "/" + spriteRenderer2.name + ".dat"
							})))
							{
								list.Add(spriteRenderer2.name);
								byte[] array2 = base.AbsolutelyPhysicalPath.LoadSprite(spriteRenderer2.name, ".dat");
								array2 = Imgs.DecryptImgs(array2);
								ImageConversion.LoadImage(spriteRenderer2.sprite.texture, array2);
							}
							else
							{
								list2.Add(spriteRenderer2.name);
							}
						}
						MelonLogger.Msg("****************************");
						if (list.Count == 0)
						{
							MelonLogger.Msg("No part has been modified.");
						}
						foreach (string str in list)
						{
							MelonLogger.Msg("Modified：" + str);
						}
						MelonLogger.Msg("****************************");
						if (list2.Count == 0)
						{
							MelonLogger.Msg("All parts have been modified.");
						}
						foreach (string str2 in list2)
						{
							MelonLogger.Msg("Not modified：" + str2);
						}
						MelonLogger.Msg("****************************");
						return template;
					}
				}
				else if (remakeParam.assettype == "video")
				{
					if (CommonData.prefetching)
					{
						return template;
					}
					string text = "file://" + base.AbsolutelyPhysicalPath + "/" + remakeParam.videoparam.file;
					MelonLogger.Msg(text);
					foreach (SpriteRenderer spriteRenderer3 in template.GetComponentsInChildren<SpriteRenderer>())
					{
						spriteRenderer3.transform.gameObject.SetActive(false);
					}
					VideoWorker.PlayDynamic(text, "Camera", "G:btnTalentDetial", remakeParam.videoparam.size, remakeParam.videoparam.anchoredposition);
					if (template.GetComponent<ArtifactSpriteScript>() == null)
					{
						template.AddComponent<ArtifactSpriteScript>();
					}
					return template;
				}
				return template;
			}
			MelonLogger.Msg("No config");
			foreach (SpriteRenderer spriteRenderer4 in template.GetComponentsInChildren<SpriteRenderer>())
			{
				if (File.Exists(Path.Combine(new string[]
				{
					base.AbsolutelyPhysicalPath + "/" + spriteRenderer4.name + ".png"
				})))
				{
					list.Add(spriteRenderer4.name);
					byte[] array3 = base.AbsolutelyPhysicalPath.LoadSprite(spriteRenderer4.name, ".png");
					ImageConversion.LoadImage(spriteRenderer4.sprite.texture, array3);
				}
				else if (File.Exists(Path.Combine(new string[]
				{
					base.AbsolutelyPhysicalPath + "/" + spriteRenderer4.name + ".dat"
				})))
				{
					list.Add(spriteRenderer4.name);
					byte[] array4 = base.AbsolutelyPhysicalPath.LoadSprite(spriteRenderer4.name, ".dat");
					array4 = Imgs.DecryptImgs(array4);
					ImageConversion.LoadImage(spriteRenderer4.sprite.texture, array4);
				}
				else
				{
					list2.Add(spriteRenderer4.name);
				}
			}
			MelonLogger.Msg("****************************");
			if (list.Count == 0)
			{
				MelonLogger.Msg("No part has been modified.");
			}
			foreach (string str3 in list)
			{
				MelonLogger.Msg("Modified：" + str3);
			}
			MelonLogger.Msg("****************************");
			if (list2.Count == 0)
			{
				MelonLogger.Msg("All parts have been modified.");
			}
			foreach (string str4 in list2)
			{
				MelonLogger.Msg("Not modified：" + str4);
			}
			MelonLogger.Msg("****************************");
			return template;
		}
	}
}
