using System;
using System.Collections.Generic;
using System.IO;
using Fautry;
using YamlDotNet.Serialization;

namespace Fatury
{
	// Token: 0x02000014 RID: 20
	internal class RemakeParam
	{
		// Token: 0x17000026 RID: 38
		// (get) Token: 0x060000B1 RID: 177 RVA: 0x0000585F File Offset: 0x00003A5F
		// (set) Token: 0x060000B2 RID: 178 RVA: 0x00005867 File Offset: 0x00003A67
		[YamlMember(Alias = "AssetType", ApplyNamingConventions = false)]
		public string assettype { get; set; }

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x060000B3 RID: 179 RVA: 0x00005870 File Offset: 0x00003A70
		// (set) Token: 0x060000B4 RID: 180 RVA: 0x00005878 File Offset: 0x00003A78
		[YamlMember(Alias = "VideoParam", ApplyNamingConventions = false)]
		public VideoParam videoparam { get; set; }

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x060000B5 RID: 181 RVA: 0x00005881 File Offset: 0x00003A81
		// (set) Token: 0x060000B6 RID: 182 RVA: 0x00005889 File Offset: 0x00003A89
		[YamlMember(Alias = "RemakeParam", ApplyNamingConventions = false)]
		public Dictionary<string, Dictionary<string, Vector3>> remakeparam { get; set; }

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x060000B7 RID: 183 RVA: 0x00005892 File Offset: 0x00003A92
		// (set) Token: 0x060000B8 RID: 184 RVA: 0x0000589A File Offset: 0x00003A9A
		[YamlMember(Alias = "sprite", Description = "图片列表，可以多个，条件 condition 均满足的将随机一个", ApplyNamingConventions = false)]
		public Dictionary<string, SpriteParam> Sprite { get; set; }

		// Token: 0x060000B9 RID: 185 RVA: 0x000058A3 File Offset: 0x00003AA3
		public static RemakeParam LoadFromYaml(string path)
		{
			return new Deserializer().Deserialize<RemakeParam>(File.ReadAllText(path));
		}
	}
}
