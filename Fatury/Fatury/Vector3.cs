using System;
using UnityEngine;

namespace Fatury
{
	// Token: 0x02000015 RID: 21
	internal struct Vector3
	{
		// Token: 0x1700002A RID: 42
		// (get) Token: 0x060000BB RID: 187 RVA: 0x000058BD File Offset: 0x00003ABD
		// (set) Token: 0x060000BC RID: 188 RVA: 0x000058C5 File Offset: 0x00003AC5
		public float X { readonly get; set; }

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x060000BD RID: 189 RVA: 0x000058CE File Offset: 0x00003ACE
		// (set) Token: 0x060000BE RID: 190 RVA: 0x000058D6 File Offset: 0x00003AD6
		public float Y { readonly get; set; }

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x060000BF RID: 191 RVA: 0x000058DF File Offset: 0x00003ADF
		// (set) Token: 0x060000C0 RID: 192 RVA: 0x000058E7 File Offset: 0x00003AE7
		public float Z { readonly get; set; }

		// Token: 0x060000C1 RID: 193 RVA: 0x000058F0 File Offset: 0x00003AF0
		public static implicit operator Vector3(Vector3 v)
		{
			return new Vector3(v.X, v.Y, v.Z);
		}
	}
}
