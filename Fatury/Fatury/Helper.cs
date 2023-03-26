using System;
using System.IO;
using MelonLoader;

namespace Fatury
{
	// Token: 0x02000010 RID: 16
	internal static class Helper
	{
		// Token: 0x060000A4 RID: 164 RVA: 0x000049C0 File Offset: 0x00002BC0
		public static string GetHome()
		{
			if (CommonData.currentPath.StartsWith("Mod"))
			{
				return Path.Combine(new string[]
				{
					MelonUtils.GameDirectory,
					"ModExportData",
					CommonData.currentPath,
					"ModAssets",
					"Fatury"
				});
			}
			return Path.Combine(CommonData.rootPath, CommonData.currentPath, "ModAssets", "Fatury");
		}

		// Token: 0x060000A5 RID: 165 RVA: 0x00004A2C File Offset: 0x00002C2C
		public static string GetFaturyHome()
		{
			CommonData.currentPath = CommonData.faturyRootPath;
			if (CommonData.rootPath.Contains("debug"))
			{
				return Path.Combine(CommonData.rootPath, "ModAssets");
			}
			return Path.Combine(CommonData.rootPath, CommonData.currentPath, "ModAssets");
		}
	}
}
