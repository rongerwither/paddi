using System;
using UnityEngine;

namespace Fautry
{
	// Token: 0x02000006 RID: 6
	internal struct Vector4
	{
		// Token: 0x17000021 RID: 33
		// (get) Token: 0x06000048 RID: 72 RVA: 0x000023E6 File Offset: 0x000005E6
		// (set) Token: 0x06000049 RID: 73 RVA: 0x000023EE File Offset: 0x000005EE
		public float X { readonly get; set; }

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x0600004A RID: 74 RVA: 0x000023F7 File Offset: 0x000005F7
		// (set) Token: 0x0600004B RID: 75 RVA: 0x000023FF File Offset: 0x000005FF
		public float Y { readonly get; set; }

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x0600004C RID: 76 RVA: 0x00002408 File Offset: 0x00000608
		// (set) Token: 0x0600004D RID: 77 RVA: 0x00002410 File Offset: 0x00000610
		public float Z { readonly get; set; }

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x0600004E RID: 78 RVA: 0x00002419 File Offset: 0x00000619
		// (set) Token: 0x0600004F RID: 79 RVA: 0x00002421 File Offset: 0x00000621
		public float W { readonly get; set; }

		// Token: 0x06000050 RID: 80 RVA: 0x0000242A File Offset: 0x0000062A
		public static implicit operator Vector4(Vector4 v)
		{
			return new Vector4(v.X, v.Y, v.Z, v.W);
		}
	}
}
