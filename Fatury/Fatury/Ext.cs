using System;
using System.IO;
using UnityEngine;

namespace Fatury
{
	// Token: 0x0200000B RID: 11
	internal static class Ext
	{
		// Token: 0x06000063 RID: 99 RVA: 0x00002D37 File Offset: 0x00000F37
		public static bool IsPortrait(this string path)
		{
			return path.StartsWith("Game/Portrait/");
		}

		// Token: 0x06000064 RID: 100 RVA: 0x00002D44 File Offset: 0x00000F44
		public static bool IsPortraitDynamic(this string path)
		{
			return path.StartsWith("Game/PortraitDynamic/");
		}

		// Token: 0x06000065 RID: 101 RVA: 0x00002D51 File Offset: 0x00000F51
		public static bool IsArtifactSprite(this string path)
		{
			return path.StartsWith("Game/ArtifactSprite/");
		}

		// Token: 0x06000066 RID: 102 RVA: 0x00002D5E File Offset: 0x00000F5E
		public static bool IsEffectUI(this string path)
		{
			return path.StartsWith("Effect/UI");
		}

		// Token: 0x06000067 RID: 103 RVA: 0x00002D6B File Offset: 0x00000F6B
		public static bool IsNPCDynamic(this string path)
		{
			return path.StartsWith("Game/NPCDynamic");
		}

		// Token: 0x06000068 RID: 104 RVA: 0x00002D78 File Offset: 0x00000F78
		public static bool IsNPC(this string path)
		{
			return path.StartsWith("Game/NPC");
		}

		// Token: 0x06000069 RID: 105 RVA: 0x00002D85 File Offset: 0x00000F85
		public static bool IsMonst(this string path)
		{
			return path.StartsWith("Battle/Monst");
		}

		// Token: 0x0600006A RID: 106 RVA: 0x00002D92 File Offset: 0x00000F92
		public static bool IsEffectBattle(this string path)
		{
			return path.StartsWith("Effect/Battle");
		}

		// Token: 0x0600006B RID: 107 RVA: 0x00002D9F File Offset: 0x00000F9F
		public static bool IsTexture(this string path)
		{
			return path.StartsWith("Texture");
		}

		// Token: 0x0600006C RID: 108 RVA: 0x00002DAC File Offset: 0x00000FAC
		public static bool Exist(this string path)
		{
			return Directory.Exists(path);
		}

		// Token: 0x0600006D RID: 109 RVA: 0x00002DB4 File Offset: 0x00000FB4
		public static Component[] Copy(GameObject obj)
		{
			return obj.GetComponents<Component>();
		}

		// Token: 0x0600006E RID: 110 RVA: 0x00002DC1 File Offset: 0x00000FC1
		public static byte[] LoadSprite(this string path, string type_)
		{
			return File.ReadAllBytes(Path.Combine(path, type_));
		}

		// Token: 0x0600006F RID: 111 RVA: 0x00002DCF File Offset: 0x00000FCF
		public static byte[] LoadSprite(this string path, string type_, string extention)
		{
			return File.ReadAllBytes(Path.Combine(path, type_ + extention));
		}
	}
}
