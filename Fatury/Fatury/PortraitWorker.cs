using System;
using System.IO;
using Fatury.Bytes;
using Fautry;
using UnityEngine;

namespace Fatury
{
	// Token: 0x02000028 RID: 40
	internal class PortraitWorker : Worker
	{
		// Token: 0x06000110 RID: 272 RVA: 0x00009928 File Offset: 0x00007B28
		public override GameObject Rework(GameObject template)
		{
			EffectParam effectParam = EffectParam.LoadFromYaml(base.AbsolutelyPhysicalPath + "/_child/sprite/asset.yml");
			string text = base.AbsolutelyPhysicalPath + "/_child/sprite";
			SpriteRenderer componentInChildren = template.GetComponentInChildren<SpriteRenderer>();
			if (effectParam.Sprite["image"].WholePortrait)
			{
				template.AddComponent<WholePortraitScript>();
			}
			string file = effectParam.Sprite["image"]._File;
			Sprite sprite = null;
			string extension = Path.GetExtension(file);
			string type_ = file.Replace(extension, "");
			if (File.Exists(text + "/" + file) && extension == ".png")
			{
				byte[] array = text.LoadSprite(type_, extension);
				Texture2D texture2D = new Texture2D(100, 100, 5, false);
				if (!ImageConversion.LoadImage(texture2D, array))
				{
					throw new InvalidOperationException();
				}
				sprite = Sprite.Create(texture2D, new Rect(new Vector2(0f, 0f), new Vector2(effectParam.Sprite["image"].Rect.Size.X, effectParam.Sprite["image"].Rect.Size.Y)), effectParam.Sprite["image"].Pivot, effectParam.Sprite["image"].PixelsPerUnit, effectParam.Sprite["image"].Extrude);
			}
			else if (File.Exists(text + "/" + file) && extension == ".dat")
			{
				byte[] array2 = text.LoadSprite(type_, extension);
				array2 = Imgs.DecryptImgs(array2);
				Texture2D texture2D2 = new Texture2D(100, 100, 5, false);
				if (!ImageConversion.LoadImage(texture2D2, array2))
				{
					throw new InvalidOperationException();
				}
				sprite = Sprite.Create(texture2D2, effectParam.Sprite["image"].Rect, effectParam.Sprite["image"].Pivot, effectParam.Sprite["image"].PixelsPerUnit, effectParam.Sprite["image"].Extrude);
			}
			componentInChildren.sprite = sprite;
			return template;
		}
	}
}
