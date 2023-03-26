using System;
using System.IO;
using Fatury;
using UnityEngine;
using YamlDotNet.Serialization;

namespace Fautry
{
	// Token: 0x02000004 RID: 4
	internal class SpriteParam
	{
		// Token: 0x1700000E RID: 14
		// (get) Token: 0x0600001F RID: 31 RVA: 0x00002258 File Offset: 0x00000458
		// (set) Token: 0x06000020 RID: 32 RVA: 0x00002260 File Offset: 0x00000460
		[YamlMember(Alias = "file", Description = "文件名，必须是同级目录下有的文件", ApplyNamingConventions = false)]
		public string _File { get; set; } = "image.dat";

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x06000021 RID: 33 RVA: 0x00002269 File Offset: 0x00000469
		// (set) Token: 0x06000022 RID: 34 RVA: 0x00002271 File Offset: 0x00000471
		[YamlMember(Alias = "template", Description = "模板完整路径，跟上面的 template 可以同时设置，都设置的情况下以这个为准，如以钻木取火图片为模板则设置为 Texture/BG/zuanmuquhuo，若此资源是原版没有的，则必须设置 template", ApplyNamingConventions = false)]
		public string Template { get; set; }

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x06000023 RID: 35 RVA: 0x0000227A File Offset: 0x0000047A
		// (set) Token: 0x06000024 RID: 36 RVA: 0x00002282 File Offset: 0x00000482
		[YamlMember(Alias = "delay", ApplyNamingConventions = false)]
		public int Delay { get; set; }

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x06000025 RID: 37 RVA: 0x0000228B File Offset: 0x0000048B
		// (set) Token: 0x06000026 RID: 38 RVA: 0x00002293 File Offset: 0x00000493
		[YamlMember(Alias = "newSprite", Description = "是否是创建新的 sprite，如果为 false，则除了图片为自定义，其他均使用原版，如大小，边框，强烈建议为 false，加载速度比 true 快一倍，但原版立绘有边框，这种情况下建议用 true", ApplyNamingConventions = false)]
		public bool NewSprite { get; set; }

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x06000027 RID: 39 RVA: 0x0000229C File Offset: 0x0000049C
		// (set) Token: 0x06000028 RID: 40 RVA: 0x000022A4 File Offset: 0x000004A4
		[YamlMember(Alias = "wholePortrait", ApplyNamingConventions = false)]
		public bool WholePortrait { get; set; }

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x06000029 RID: 41 RVA: 0x000022AD File Offset: 0x000004AD
		// (set) Token: 0x0600002A RID: 42 RVA: 0x000022B5 File Offset: 0x000004B5
		[YamlMember(Alias = "rect", ApplyNamingConventions = false)]
		public Rect Rect { get; set; }

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x0600002B RID: 43 RVA: 0x000022BE File Offset: 0x000004BE
		// (set) Token: 0x0600002C RID: 44 RVA: 0x000022C6 File Offset: 0x000004C6
		[YamlMember(Alias = "rectDrama", ApplyNamingConventions = false)]
		public Rect Rect_Drama { get; set; }

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x0600002D RID: 45 RVA: 0x000022CF File Offset: 0x000004CF
		// (set) Token: 0x0600002E RID: 46 RVA: 0x000022D7 File Offset: 0x000004D7
		[YamlMember(Alias = "rectBigPortrait", ApplyNamingConventions = false)]
		public Rect Rect_BigPortrait { get; set; }

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x0600002F RID: 47 RVA: 0x000022E0 File Offset: 0x000004E0
		// (set) Token: 0x06000030 RID: 48 RVA: 0x000022E8 File Offset: 0x000004E8
		[YamlMember(Alias = "rectCreatePlayer", ApplyNamingConventions = false)]
		public Rect Rect_CreatePlayer { get; set; }

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x06000031 RID: 49 RVA: 0x000022F1 File Offset: 0x000004F1
		// (set) Token: 0x06000032 RID: 50 RVA: 0x000022F9 File Offset: 0x000004F9
		[YamlMember(Alias = "pivot", ApplyNamingConventions = false)]
		public Vector2 Pivot { get; set; }

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x06000033 RID: 51 RVA: 0x00002302 File Offset: 0x00000502
		// (set) Token: 0x06000034 RID: 52 RVA: 0x0000230A File Offset: 0x0000050A
		[YamlMember(Alias = "pixelsPerUnit", ApplyNamingConventions = false)]
		public float PixelsPerUnit { get; set; }

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x06000035 RID: 53 RVA: 0x00002313 File Offset: 0x00000513
		// (set) Token: 0x06000036 RID: 54 RVA: 0x0000231B File Offset: 0x0000051B
		[YamlMember(Alias = "extrude", ApplyNamingConventions = false)]
		public uint Extrude { get; set; }

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x06000037 RID: 55 RVA: 0x00002324 File Offset: 0x00000524
		// (set) Token: 0x06000038 RID: 56 RVA: 0x0000232C File Offset: 0x0000052C
		[YamlMember(Alias = "meshType", ApplyNamingConventions = false)]
		public SpriteMeshType MeshType { get; set; } = 1;

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x06000039 RID: 57 RVA: 0x00002335 File Offset: 0x00000535
		// (set) Token: 0x0600003A RID: 58 RVA: 0x0000233D File Offset: 0x0000053D
		[YamlMember(Alias = "border", ApplyNamingConventions = false)]
		public Vector4 Border { get; set; }

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x0600003B RID: 59 RVA: 0x00002346 File Offset: 0x00000546
		// (set) Token: 0x0600003C RID: 60 RVA: 0x0000234E File Offset: 0x0000054E
		[YamlMember(Alias = "generateFallbackPhysicsShape", ApplyNamingConventions = false)]
		public bool GenerateFallbackPhysicsShape { get; set; }

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x0600003D RID: 61 RVA: 0x00002357 File Offset: 0x00000557
		// (set) Token: 0x0600003E RID: 62 RVA: 0x0000235F File Offset: 0x0000055F
		[YamlMember(Alias = "expireTime", ApplyNamingConventions = false)]
		public int expireTime { get; set; }

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x0600003F RID: 63 RVA: 0x00002368 File Offset: 0x00000568
		// (set) Token: 0x06000040 RID: 64 RVA: 0x00002370 File Offset: 0x00000570
		[YamlMember(Alias = "condition", ApplyNamingConventions = false)]
		public bool condition { get; set; }

		// Token: 0x06000041 RID: 65 RVA: 0x00002379 File Offset: 0x00000579
		public static SpriteParam LoadFromYaml(string path)
		{
			return new Deserializer().Deserialize<SpriteParam>(File.ReadAllText(path));
		}
	}
}
