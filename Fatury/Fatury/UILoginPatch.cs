using System;
using Fatury.Bytes;
using HarmonyLib;
using UnityEngine;
using UnityEngine.UI;

namespace Fatury
{
	// Token: 0x02000008 RID: 8
	[HarmonyPatch(typeof(UILogin), "Init")]
	internal class UILoginPatch
	{
		// Token: 0x06000056 RID: 86 RVA: 0x00002470 File Offset: 0x00000670
		[HarmonyPostfix]
		private static void Postfix(UILogin __instance)
		{
			if (GameObject.Find("FaturybtnOpenHelpMe") == null)
			{
				GameObject gameObject = CreateUI.NewImage(SpriteTool.GetSprite("Common", "tongyongbutton_2"));
				gameObject.transform.SetParent(__instance.transform.Find("Root"), false);
				gameObject.GetComponent<RectTransform>().anchorMin = new Vector2(1f, 1f);
				gameObject.GetComponent<RectTransform>().anchorMax = new Vector2(1f, 1f);
				gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(-112f, -200f);
				gameObject.name = "FaturybtnOpenHelpMe";
				Action action = delegate()
				{
					UILoginPatch.OpenHelpMe(__instance);
				};
				gameObject.AddComponent<Button>().onClick.AddListener(action);
				GameObject gameObject2 = CreateUI.NewText("Fatury", gameObject.GetComponent<RectTransform>().sizeDelta, 0);
				gameObject2.transform.SetParent(gameObject.transform, false);
				gameObject2.GetComponent<Text>().alignment = 3;
				gameObject2.GetComponent<Text>().color = Color.black;
				gameObject2.GetComponent<RectTransform>().anchoredPosition = new Vector2(20f, 2f);
			}
		}

		// Token: 0x06000057 RID: 87 RVA: 0x000025B0 File Offset: 0x000007B0
		private static void OpenHelpMe(UILogin ui)
		{
			bool flag = ui.transform.Find("Root/FaturyHelpMe") != null;
			bool flag2 = GameObject.Find("Game/UIRoot/Canvas/Root/UI/Login/G:goBG/beijinglong5") != null;
			if (flag)
			{
				Object.Destroy(ui.transform.Find("Root/FaturyHelpMe").gameObject);
			}
			if (flag2)
			{
				GameObject gameObject9 = GameObject.Find("Game/UIRoot/Canvas/Root/UI/Login/G:goBG/beijinglong5");
				gameObject9.transform.Find("root/xuanzhuan").gameObject.SetActive(false);
				gameObject9.transform.Find("root/ren").gameObject.SetActive(false);
				gameObject9.transform.Find("effect").gameObject.SetActive(false);
				gameObject9.transform.Find("niao").gameObject.SetActive(false);
			}
			GameObject parent = CreateUI.NewImage(null);
			parent.transform.SetParent(ui.transform.Find("Root"), false);
			parent.GetComponent<RectTransform>().sizeDelta = new Vector2(9999f, 9999f);
			parent.GetComponent<Image>().color = new Color(0f, 0f, 0f, 0.5f);
			parent.name = "FaturyHelpMe";
			GameObject gameObject = Object.Instantiate<GameObject>(GoCache.Cache["UI"]);
			gameObject.transform.SetParent(parent.transform, false);
			GameObject gameObject2 = CreateUI.NewText("感谢使用<color=#990000>《Fatury框架》</color>！\n作者：<color=#990000>Sorry</color>\nb站id：<color=#990000>SorryLL</color>\n目前正在b站更新《Fatury框架使用教程与疑难解答》系列视频，欢迎大家来关注我！\n\n在官方编辑器的基础上拓展了以下功能：\n- 不需要使用Unity就能替换游戏内资源！ \n- 静态立绘、动态立绘（包括人物、器灵）替换 \n- 立绘全部位名称提示 \n- 器灵和双修视频替换  \n- UI替换 \n- 奇遇图、过场图替换 \n- 原版背景音乐和对话语音替换 \n- 视频顺序或随机双修 \n- 内附加密工具，更好的保护原作者作品安全 \n- <color=#0000CC>欢迎加入</color><color=#990000>Sorry</color><color=#0000CC>的QQ群：647917100</color>", new Vector2(600f, 600f), 0);
			gameObject2.transform.SetParent(gameObject.transform, false);
			gameObject2.GetComponent<Text>().alignment = 3;
			gameObject2.GetComponent<Text>().color = Color.black;
			gameObject2.GetComponent<RectTransform>().anchoredPosition = new Vector2(230f, 0f);
			GameObject gameObject3 = CreateUI.NewImage(SpriteTool.GetSprite("Common", "youxishezhi_1"));
			gameObject3.transform.SetParent(gameObject.transform, false);
			gameObject3.GetComponent<RectTransform>().anchoredPosition = new Vector2(0f, -300f);
			GameObject gameObject4 = CreateUI.NewRawImage(new Vector2(1000f, 2000f));
			gameObject4.transform.SetParent(parent.transform, false);
			gameObject4.transform.localEulerAngles = new Vector3(0f, 180f, 0f);
			gameObject4.transform.localScale = new Vector3(1f, 1f, -1f);
			gameObject4.GetComponent<RectTransform>().anchoredPosition = new Vector2(-400f, 0f);
			gameObject4.GetComponent<RawImage>().raycastTarget = false;
			UILoginPatch.SetDragonModel("Game/NPCDynamic/dt_genpilongnv", gameObject4.GetComponent<RawImage>(), new Vector3(0.3f, 0.3f, 1f), new Vector2(-0.7f, -1.65f));
			GameObject gameObject5 = CreateUI.NewText("关闭", gameObject3.GetComponent<RectTransform>().sizeDelta, 0);
			gameObject5.transform.SetParent(gameObject3.transform, false);
			gameObject5.GetComponent<Text>().alignment = 4;
			gameObject5.GetComponent<Text>().color = Color.black;
			Action action = delegate()
			{
				if (flag2)
				{
					GameObject gameObject8 = GameObject.Find("Game/UIRoot/Canvas/Root/UI/Login/G:goBG/beijinglong5");
					gameObject8.transform.Find("root/xuanzhuan").gameObject.SetActive(true);
					gameObject8.transform.Find("root/ren").gameObject.SetActive(true);
					gameObject8.transform.Find("effect").gameObject.SetActive(true);
					gameObject8.transform.Find("niao").gameObject.SetActive(true);
				}
				Object.Destroy(parent.gameObject);
			};
			gameObject3.AddComponent<Button>().onClick.AddListener(action);
			GameObject gameObject6 = CreateUI.NewImage(SpriteTool.GetSprite("Common", "youxishezhi_1"));
			gameObject6.transform.SetParent(gameObject.transform, false);
			gameObject6.GetComponent<RectTransform>().anchoredPosition = new Vector2(300f, -300f);
			GameObject gameObject7 = CreateUI.NewText("打赏作者", gameObject6.GetComponent<RectTransform>().sizeDelta, 0);
			gameObject7.transform.SetParent(gameObject6.transform, false);
			gameObject7.GetComponent<Text>().alignment = 4;
			gameObject7.GetComponent<Text>().color = Color.black;
			Action action2 = delegate()
			{
				if (GameObject.Find("reward") == null)
				{
					CommonData.currentPath = "2814703549";
					byte[] array = Helper.GetHome().LoadSprite("image", ".dat");
					array = Imgs.DecryptImgs2(array);
					Texture2D texture2D = new Texture2D(100, 100, 5, false);
					if (!ImageConversion.LoadImage(texture2D, array))
					{
						throw new InvalidOperationException();
					}
					GameObject gameObject8 = CreateUI.NewImage(Sprite.Create(texture2D, new Rect(new Vector2(0f, 0f), new Vector2(1175f, 1175f)), new Vector2(0.5f, 0.5f), 100f, 1U));
					gameObject8.transform.localScale = new Vector3(0.45f, 0.45f, 1f);
					gameObject8.transform.localPosition = new Vector3(190f, 0f, 0f);
					gameObject8.transform.SetParent(gameObject.transform, false);
				}
			};
			gameObject6.AddComponent<Button>().onClick.AddListener(action2);
		}

		// Token: 0x06000058 RID: 88 RVA: 0x000029CC File Offset: 0x00000BCC
		private static void SetDragonModel(string path, RawImage rimg, Vector3 scale, Vector2 offset)
		{
			rimg.gameObject.SetActive(true);
			new ModelRenderTexture(Object.Instantiate<GameObject>(g.res.Load<GameObject>(path)), rimg, offset).gameObject.transform.localScale = scale;
		}
	}
}
