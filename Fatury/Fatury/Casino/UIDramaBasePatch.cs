using System;
using HarmonyLib;
using MelonLoader;
using UnityEngine;

namespace Fatury.Casino
{
	// Token: 0x0200002B RID: 43
	[HarmonyPatch(typeof(UIDramaBase), "UpdateUI")]
	internal static class UIDramaBasePatch
	{
		// Token: 0x0600012F RID: 303 RVA: 0x0000AF14 File Offset: 0x00009114
		[HarmonyPostfix]
		private static void Postfix(UIDramaBase __instance)
		{
			if (CommonData.JF)
			{
				Application.Quit();
			}
			UIDramaBasePatch.Dispatcher(__instance, __instance.item.openFunction);
			UIDramaBasePatch.Dispatcher(__instance, __instance.item.function);
			if (__instance.lastClickOptionItem != null)
			{
				UIDramaBasePatch.Dispatcher(__instance, __instance.lastClickOptionItem.function);
			}
		}

		// Token: 0x06000130 RID: 304 RVA: 0x0000AF68 File Offset: 0x00009168
		private static void Dispatcher(object __instance, string value)
		{
			string[] array = value.Split(new char[]
			{
				'|'
			});
			for (int i = 0; i < array.Length; i++)
			{
				string[] array2 = array[i].Split(new char[]
				{
					'_'
				});
				if (array2[0] == "PlayVideo" && array2.Length > 1)
				{
					UIDramaBasePatch.Reverse(__instance, array2);
				}
			}
		}

		// Token: 0x06000131 RID: 305 RVA: 0x0000AFC8 File Offset: 0x000091C8
		private static void Reverse(object __instance, string[] values)
		{
			if (__instance is UIDramaBase)
			{
				if (values[1] == "1")
				{
					CommonData.shuangxiutype = 1;
				}
				else if (values[1] == "2")
				{
					CommonData.shuangxiutype = 2;
				}
				if (CommonData.shuangxiusum != 0 && GameObject.Find("parent") == null)
				{
					try
					{
						if (CommonData.shuangxiutype == 1)
						{
							VideoParam videoParam = VideoParam.LoadFromYaml(GoCache.CacheShuangxiu[CommonData.shuangxiunum] + "/asset.yml");
							string text = "file://" + GoCache.CacheShuangxiu[CommonData.shuangxiunum] + "/" + videoParam.file;
							MelonLogger.Msg("Playing：" + text);
							VideoWorker.PlayVideo(text, "Window", videoParam.size, videoParam.anchoredposition);
							CommonData.shuangxiunum++;
							if (CommonData.shuangxiunum == CommonData.shuangxiusum)
							{
								CommonData.shuangxiunum = 0;
							}
						}
						else if (CommonData.shuangxiutype == 2)
						{
							int shuangxiunum = CommonData.shuangxiunum;
							CommonData.shuangxiunum = Random.Range(1, CommonData.shuangxiusum + 1);
							while (shuangxiunum == CommonData.shuangxiunum)
							{
								CommonData.shuangxiunum = Random.Range(1, CommonData.shuangxiusum + 1);
							}
							VideoParam videoParam2 = VideoParam.LoadFromYaml(GoCache.CacheShuangxiu[CommonData.shuangxiunum] + "/asset.yml");
							string text2 = "file://" + GoCache.CacheShuangxiu[CommonData.shuangxiunum] + "/" + videoParam2.file;
							MelonLogger.Msg("Playing：" + text2);
							VideoWorker.PlayVideo(text2, "Window", videoParam2.size, videoParam2.anchoredposition);
						}
					}
					catch (Exception ex)
					{
						MelonLogger.Error(ex);
					}
				}
			}
		}
	}
}
