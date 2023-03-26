using System;
using System.Collections.Generic;
using System.IO;
using Fatury;
using MelonLoader;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace Fautry
{
	// Token: 0x02000002 RID: 2
	internal class EffectParam
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		// (set) Token: 0x06000002 RID: 2 RVA: 0x00002058 File Offset: 0x00000258
		[YamlMember(Alias = "AssetType", ApplyNamingConventions = false)]
		public string assettype { get; set; }

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000003 RID: 3 RVA: 0x00002061 File Offset: 0x00000261
		// (set) Token: 0x06000004 RID: 4 RVA: 0x00002069 File Offset: 0x00000269
		[YamlMember(Alias = "VideoParam", ApplyNamingConventions = false)]
		public VideoParam videoparam { get; set; }

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000005 RID: 5 RVA: 0x00002072 File Offset: 0x00000272
		// (set) Token: 0x06000006 RID: 6 RVA: 0x0000207A File Offset: 0x0000027A
		[YamlMember(Alias = "RemakeParam", ApplyNamingConventions = false)]
		public Dictionary<string, Dictionary<string, Vector3>> remakeparam { get; set; }

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000007 RID: 7 RVA: 0x00002083 File Offset: 0x00000283
		// (set) Token: 0x06000008 RID: 8 RVA: 0x0000208B File Offset: 0x0000028B
		[YamlMember(Alias = "sprite", ApplyNamingConventions = false)]
		public Dictionary<string, SpriteParam> Sprite { get; set; }

		// Token: 0x06000009 RID: 9 RVA: 0x00002094 File Offset: 0x00000294
		public static EffectParam LoadFromYaml(string path)
		{
			IDeserializer deserializer = new DeserializerBuilder().WithNamingConvention(UnderscoredNamingConvention.Instance).Build();
			EffectParam result;
			try
			{
				result = deserializer.Deserialize<EffectParam>(File.ReadAllText(path));
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
