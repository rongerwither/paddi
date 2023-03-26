using System;
using System.Collections.Generic;
using System.IO;
using YamlDotNet.Serialization;

namespace Fatury
{
	// Token: 0x02000013 RID: 19
	internal class AudioParam
	{
		// Token: 0x17000025 RID: 37
		// (get) Token: 0x060000AD RID: 173 RVA: 0x00005834 File Offset: 0x00003A34
		// (set) Token: 0x060000AE RID: 174 RVA: 0x0000583C File Offset: 0x00003A3C
		[YamlMember(Alias = "audio", ApplyNamingConventions = false)]
		public Dictionary<string, Dictionary<string, string>> audioParam { get; set; }

		// Token: 0x060000AF RID: 175 RVA: 0x00005845 File Offset: 0x00003A45
		public static AudioParam LoadFromYaml(string path)
		{
			return new Deserializer().Deserialize<AudioParam>(File.ReadAllText(path));
		}
	}
}
