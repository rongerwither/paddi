using System;
using System.IO;
using MelonLoader;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace Fautry
{
	// Token: 0x02000003 RID: 3
	internal class AssetParam
	{
		// Token: 0x17000005 RID: 5
		// (get) Token: 0x0600000B RID: 11 RVA: 0x00002128 File Offset: 0x00000328
		// (set) Token: 0x0600000C RID: 12 RVA: 0x00002130 File Offset: 0x00000330
		[YamlMember(Alias = "EditMode", ApplyNamingConventions = false)]
		public bool EditMode { get; set; }

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x0600000D RID: 13 RVA: 0x00002139 File Offset: 0x00000339
		// (set) Token: 0x0600000E RID: 14 RVA: 0x00002141 File Offset: 0x00000341
		[YamlMember(Alias = "ArtifactSpritePrefetch", ApplyNamingConventions = false)]
		public bool ArtifactSpritePrefetch { get; set; }

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x0600000F RID: 15 RVA: 0x0000214A File Offset: 0x0000034A
		// (set) Token: 0x06000010 RID: 16 RVA: 0x00002152 File Offset: 0x00000352
		[YamlMember(Alias = "NPCDynamicPrefetch", ApplyNamingConventions = false)]
		public bool NPCDynamicPrefetch { get; set; }

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000011 RID: 17 RVA: 0x0000215B File Offset: 0x0000035B
		// (set) Token: 0x06000012 RID: 18 RVA: 0x00002163 File Offset: 0x00000363
		[YamlMember(Alias = "NPCPrefetch", ApplyNamingConventions = false)]
		public bool NPCPrefetch { get; set; }

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000013 RID: 19 RVA: 0x0000216C File Offset: 0x0000036C
		// (set) Token: 0x06000014 RID: 20 RVA: 0x00002174 File Offset: 0x00000374
		[YamlMember(Alias = "MonstPrefetch", ApplyNamingConventions = false)]
		public bool MonstPrefetch { get; set; }

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000015 RID: 21 RVA: 0x0000217D File Offset: 0x0000037D
		// (set) Token: 0x06000016 RID: 22 RVA: 0x00002185 File Offset: 0x00000385
		[YamlMember(Alias = "ShuangxiuPrefetch", ApplyNamingConventions = false)]
		public bool ShuangxiuPrefetch { get; set; }

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000017 RID: 23 RVA: 0x0000218E File Offset: 0x0000038E
		// (set) Token: 0x06000018 RID: 24 RVA: 0x00002196 File Offset: 0x00000396
		[YamlMember(Alias = "PortraitDynamicPrefetch", ApplyNamingConventions = false)]
		public bool PortraitDynamicPrefetch { get; set; }

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x06000019 RID: 25 RVA: 0x0000219F File Offset: 0x0000039F
		// (set) Token: 0x0600001A RID: 26 RVA: 0x000021A7 File Offset: 0x000003A7
		[YamlMember(Alias = "PortraitPrefetch", ApplyNamingConventions = false)]
		public bool PortraitPrefetch { get; set; }

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x0600001B RID: 27 RVA: 0x000021B0 File Offset: 0x000003B0
		// (set) Token: 0x0600001C RID: 28 RVA: 0x000021B8 File Offset: 0x000003B8
		[YamlMember(Alias = "ShuangxiuType", ApplyNamingConventions = false)]
		public int shuangxiutype { get; set; }

		// Token: 0x0600001D RID: 29 RVA: 0x000021C4 File Offset: 0x000003C4
		public static AssetParam LoadFromYaml(string path)
		{
			IDeserializer deserializer = new DeserializerBuilder().WithNamingConvention(UnderscoredNamingConvention.Instance).Build();
			AssetParam result;
			try
			{
				result = deserializer.Deserialize<AssetParam>(File.ReadAllText(path));
			}
			catch (Exception ex)
			{
				string[] array = new string[5];
				array[0] = "Loaded assets[";
				array[1] = path;
				array[2] = "] failed: ";
				array[3] = ex.Message;
				int num = 4;
				Exception baseException = ex.GetBaseException();
				array[num] = ((baseException != null) ? baseException.Message : null);
				MelonLogger.Warning(string.Concat(array));
				result = null;
			}
			return result;
		}
	}
}
