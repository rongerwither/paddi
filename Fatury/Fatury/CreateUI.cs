using System;
using UnityEngine;
using UnityEngine.UI;

namespace Fatury
{
	// Token: 0x0200000A RID: 10
	internal class CreateUI
	{
		// Token: 0x0600005C RID: 92 RVA: 0x00002AC4 File Offset: 0x00000CC4
		public static GameObject NewCanvas(int sortLayer = -2147483648)
		{
			GameObject gameObject = new GameObject("newCanvas");
			gameObject.AddComponent<RectTransform>();
			gameObject.AddComponent<Canvas>();
			gameObject.AddComponent<CanvasScaler>();
			gameObject.AddComponent<GraphicRaycaster>();
			gameObject.layer = int.MaxValue;
			Canvas component = gameObject.GetComponent<Canvas>();
			component.renderMode = 2;
			component.sortingOrder = ((sortLayer == int.MinValue) ? (++CreateUI.sort) : sortLayer);
			CanvasScaler component2 = gameObject.GetComponent<CanvasScaler>();
			component2.uiScaleMode = 1;
			Object.FindObjectsOfType<CanvasScaler>();
			component2.referenceResolution = new Vector2(1920f, 1080f);
			return gameObject;
		}

		// Token: 0x0600005D RID: 93 RVA: 0x00002B54 File Offset: 0x00000D54
		public static GameObject NewImage(Sprite sprite = null)
		{
			GameObject gameObject = new GameObject("Image");
			gameObject.AddComponent<RectTransform>();
			gameObject.AddComponent<Image>();
			gameObject.layer = int.MaxValue;
			RectTransform component = gameObject.GetComponent<RectTransform>();
			Image component2 = gameObject.GetComponent<Image>();
			if (sprite == null)
			{
				component.sizeDelta = new Vector2(100f, 100f);
				return gameObject;
			}
			component2.sprite = sprite;
			component2.SetNativeSize();
			return gameObject;
		}

		// Token: 0x0600005E RID: 94 RVA: 0x00002BC0 File Offset: 0x00000DC0
		public static GameObject NewRawImage(Vector2 size = default(Vector2))
		{
			GameObject gameObject = new GameObject("Image");
			gameObject.AddComponent<RectTransform>();
			gameObject.AddComponent<RawImage>();
			gameObject.layer = int.MaxValue;
			RectTransform component = gameObject.GetComponent<RectTransform>();
			gameObject.GetComponent<Image>();
			if (size == default(Vector2))
			{
				component.sizeDelta = new Vector2(100f, 100f);
				return gameObject;
			}
			component.sizeDelta = size;
			return gameObject;
		}

		// Token: 0x0600005F RID: 95 RVA: 0x00002C34 File Offset: 0x00000E34
		public static GameObject NewText(string s = null, Vector2 size = default(Vector2), int fontID = 0)
		{
			GameObject gameObject = new GameObject("Text");
			gameObject.AddComponent<RectTransform>();
			gameObject.AddComponent<Text>();
			gameObject.layer = int.MaxValue;
			RectTransform component = gameObject.GetComponent<RectTransform>();
			Text component2 = gameObject.GetComponent<Text>();
			component2.text = s;
			component2.fontSize = 20;
			GameObject gameObject2 = Resources.Load<GameObject>("UI/Item/AchievementItem");
			component2.font = gameObject2.transform.Find("G:goItem/Title").GetComponent<Text>().font;
			if (size == default(Vector2))
			{
				component.sizeDelta = new Vector2(90f, 30f);
				return gameObject;
			}
			component.sizeDelta = size;
			return gameObject;
		}

		// Token: 0x06000060 RID: 96 RVA: 0x00002CD8 File Offset: 0x00000ED8
		public static GameObject NewButton(Action clickAction, Sprite sprite = null)
		{
			if (sprite == null)
			{
				sprite = SpriteTool.GetSprite("Common", "tongyongbutton");
			}
			GameObject gameObject = CreateUI.NewImage(sprite);
			Button button = gameObject.AddComponent<Button>();
			if (clickAction != null)
			{
				button.onClick.AddListener(clickAction);
			}
			return gameObject;
		}

		// Token: 0x04000038 RID: 56
		private static int sort = 10000;
	}
}
