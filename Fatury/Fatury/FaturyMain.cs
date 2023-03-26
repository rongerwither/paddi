using System;
using System.Collections.Generic;
using MelonLoader;
using Newtonsoft.Json;

namespace Fatury
{
	// Token: 0x0200000F RID: 15
	public class FaturyMain : MelonMod
	{
		// Token: 0x0600009E RID: 158 RVA: 0x00004594 File Offset: 0x00002794
		public override void OnSceneWasLoaded(int buildIndex, string sceneName)
		{
			base.OnSceneWasLoaded(buildIndex, sceneName);
			this.InitCasinoData();
		}

		// Token: 0x0600009F RID: 159 RVA: 0x000045A4 File Offset: 0x000027A4
		private void InitCasinoData()
		{
			try
			{
				if (this._isInitCasinoData)
				{
					Action action = new Action(FaturyMain.ReadData);
					Action action2 = new Action(FaturyMain.SaveData);
					g.events.On(EGameType.OneOpenUIEnd(UIType.MapMain), action, -1, false);
					g.events.On(EGameType.SaveData, action2, 0, false);
				}
			}
			catch (Exception ex)
			{
				MelonDebug.Msg(ex.Message);
			}
			finally
			{
				this._isInitCasinoData = !this._isInitCasinoData;
			}
		}

		// Token: 0x060000A0 RID: 160 RVA: 0x00004640 File Offset: 0x00002840
		public static void ReadData()
		{
			if (g.data.obj.ContainsKey("Lucifer", "CasinoData"))
			{
				FaturyMain.CasinoData = JsonConvert.DeserializeObject<Dictionary<string, int>>(g.data.obj.GetString("Lucifer", "CasinoData"));
				if (!FaturyMain.CasinoData.ContainsKey("chouMa"))
				{
					FaturyMain.CasinoData.Add("chouMa", 0);
				}
				if (!FaturyMain.CasinoData.ContainsKey("haoGan"))
				{
					FaturyMain.CasinoData.Add("haoGan", 0);
				}
				if (!FaturyMain.CasinoData.ContainsKey("ciShu"))
				{
					FaturyMain.CasinoData.Add("ciShu", 0);
				}
				if (!FaturyMain.CasinoData.ContainsKey("daJia"))
				{
					FaturyMain.CasinoData.Add("daJia", 0);
				}
				if (!FaturyMain.CasinoData.ContainsKey("qinglou"))
				{
					FaturyMain.CasinoData.Add("qinglou", 0);
				}
				MelonLogger.Msg("已成功读取赌场数据");
				return;
			}
			if (!FaturyMain.CasinoData.ContainsKey("chouMa"))
			{
				FaturyMain.CasinoData.Add("chouMa", 0);
			}
			if (!FaturyMain.CasinoData.ContainsKey("haoGan"))
			{
				FaturyMain.CasinoData.Add("haoGan", 0);
			}
			if (!FaturyMain.CasinoData.ContainsKey("ciShu"))
			{
				FaturyMain.CasinoData.Add("ciShu", 0);
			}
			if (!FaturyMain.CasinoData.ContainsKey("daJia"))
			{
				FaturyMain.CasinoData.Add("daJia", 0);
			}
			if (!FaturyMain.CasinoData.ContainsKey("qinglou"))
			{
				FaturyMain.CasinoData.Add("qinglou", 0);
			}
			MelonLogger.Msg("已成功写入赌场数据");
		}

		// Token: 0x060000A1 RID: 161 RVA: 0x000047F0 File Offset: 0x000029F0
		public static void SaveData()
		{
			if (FaturyMain.CasinoData != null)
			{
				if (!FaturyMain.CasinoData.ContainsKey("chouMa"))
				{
					FaturyMain.CasinoData.Add("chouMa", 0);
				}
				if (!FaturyMain.CasinoData.ContainsKey("haoGan"))
				{
					FaturyMain.CasinoData.Add("haoGan", 0);
				}
				if (!FaturyMain.CasinoData.ContainsKey("ciShu"))
				{
					FaturyMain.CasinoData.Add("ciShu", 0);
				}
				if (!FaturyMain.CasinoData.ContainsKey("daJia"))
				{
					FaturyMain.CasinoData.Add("daJia", 0);
				}
				if (!FaturyMain.CasinoData.ContainsKey("qinglou"))
				{
					FaturyMain.CasinoData.Add("qinglou", 0);
				}
				g.data.obj.SetString("Lucifer", "CasinoData", JsonConvert.SerializeObject(FaturyMain.CasinoData));
				MelonLogger.Msg("已保存赌场数据");
				return;
			}
			if (!FaturyMain.CasinoData.ContainsKey("chouMa"))
			{
				FaturyMain.CasinoData.Add("chouMa", 0);
			}
			if (!FaturyMain.CasinoData.ContainsKey("haoGan"))
			{
				FaturyMain.CasinoData.Add("haoGan", 0);
			}
			if (!FaturyMain.CasinoData.ContainsKey("ciShu"))
			{
				FaturyMain.CasinoData.Add("ciShu", 0);
			}
			if (!FaturyMain.CasinoData.ContainsKey("daJia"))
			{
				FaturyMain.CasinoData.Add("daJia", 0);
			}
			if (!FaturyMain.CasinoData.ContainsKey("qinglou"))
			{
				FaturyMain.CasinoData.Add("qinglou", 0);
			}
			g.data.obj.SetString("Lucifer", "CasinoData", JsonConvert.SerializeObject(FaturyMain.CasinoData));
			MelonLogger.Msg("已初始化并保存赌场数据");
		}

		// Token: 0x0400003F RID: 63
		private bool _isInitCasinoData;

		// Token: 0x04000040 RID: 64
		public static Dictionary<string, int> CasinoData = new Dictionary<string, int>();
	}
}
