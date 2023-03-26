using System;
using System.IO;
using YamlDotNet.Serialization;

namespace Fatury
{
	// Token: 0x02000016 RID: 22
	internal class VideoParam
	{
		// Token: 0x1700002D RID: 45
		// (get) Token: 0x060000C2 RID: 194 RVA: 0x0000590C File Offset: 0x00003B0C
		// (set) Token: 0x060000C3 RID: 195 RVA: 0x00005914 File Offset: 0x00003B14
		[YamlMember(Alias = "VideoName", ApplyNamingConventions = false)]
		public string file { get; set; }

		// Token: 0x1700002E RID: 46
		// (get) Token: 0x060000C4 RID: 196 RVA: 0x0000591D File Offset: 0x00003B1D
		// (set) Token: 0x060000C5 RID: 197 RVA: 0x00005925 File Offset: 0x00003B25
		[YamlMember(Alias = "Size", ApplyNamingConventions = false)]
		public Vector2 size { get; set; }

		// Token: 0x1700002F RID: 47
		// (get) Token: 0x060000C6 RID: 198 RVA: 0x0000592E File Offset: 0x00003B2E
		// (set) Token: 0x060000C7 RID: 199 RVA: 0x00005936 File Offset: 0x00003B36
		[YamlMember(Alias = "Position", ApplyNamingConventions = false)]
		public Vector2 anchoredposition { get; set; }

		// Token: 0x060000C8 RID: 200 RVA: 0x0000593F File Offset: 0x00003B3F
		public static VideoParam LoadFromYaml(string path)
		{
			return new Deserializer().Deserialize<VideoParam>(File.ReadAllText(path));
		}
	}
}
