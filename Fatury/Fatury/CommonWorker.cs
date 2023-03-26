using System;
using System.Collections.Generic;
using System.IO;
using Fatury.Bytes;
using MelonLoader;
using UnityEngine;

namespace Fatury
{
	// Token: 0x02000023 RID: 35
	internal class CommonWorker : Worker
	{
		// Token: 0x06000106 RID: 262 RVA: 0x00008518 File Offset: 0x00006718
		public override GameObject Rework(GameObject template)
		{
			List<string> list = new List<string>();
			List<string> list2 = new List<string>();
			MelonLogger.Msg("Load:" + base.AbsolutelyPhysicalPath);
			foreach (SpriteRenderer spriteRenderer in template.GetComponentsInChildren<SpriteRenderer>())
			{
				if (File.Exists(Path.Combine(new string[]
				{
					base.AbsolutelyPhysicalPath + "/" + spriteRenderer.name + ".png"
				})))
				{
					list.Add(spriteRenderer.name);
					byte[] array = base.AbsolutelyPhysicalPath.LoadSprite(spriteRenderer.name, ".png");
					ImageConversion.LoadImage(spriteRenderer.sprite.texture, array);
				}
				else if (File.Exists(Path.Combine(new string[]
				{
					base.AbsolutelyPhysicalPath + "/" + spriteRenderer.name + ".dat"
				})))
				{
					list.Add(spriteRenderer.name);
					byte[] array2 = base.AbsolutelyPhysicalPath.LoadSprite(spriteRenderer.name, ".dat");
					array2 = Imgs.DecryptImgs(array2);
					ImageConversion.LoadImage(spriteRenderer.sprite.texture, array2);
				}
				else
				{
					list2.Add(spriteRenderer.name);
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
}
