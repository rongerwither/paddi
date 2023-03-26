using System;
using UnityEngine;

namespace Fatury
{
	// Token: 0x02000017 RID: 23
	internal struct Vector2
	{
		// Token: 0x17000030 RID: 48
		// (get) Token: 0x060000CA RID: 202 RVA: 0x00005959 File Offset: 0x00003B59
		// (set) Token: 0x060000CB RID: 203 RVA: 0x00005961 File Offset: 0x00003B61
		public float X { readonly get; set; }

		// Token: 0x17000031 RID: 49
		// (get) Token: 0x060000CC RID: 204 RVA: 0x0000596A File Offset: 0x00003B6A
		// (set) Token: 0x060000CD RID: 205 RVA: 0x00005972 File Offset: 0x00003B72
		public float Y { readonly get; set; }

		// Token: 0x060000CE RID: 206 RVA: 0x0000597B File Offset: 0x00003B7B
		public static implicit operator Vector2(Vector2 v)
		{
			return new Vector2(v.X, v.Y);
		}
	}
}
