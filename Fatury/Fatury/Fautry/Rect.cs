using System;
using Fatury;
using UnityEngine;
using YamlDotNet.Serialization;

namespace Fautry
{
	// Token: 0x02000005 RID: 5
	internal struct Rect
	{
		// Token: 0x1700001F RID: 31
		// (get) Token: 0x06000043 RID: 67 RVA: 0x000023A5 File Offset: 0x000005A5
		// (set) Token: 0x06000044 RID: 68 RVA: 0x000023AD File Offset: 0x000005AD
		[YamlMember(Alias = "position", ApplyNamingConventions = false)]
		public Vector2 Position { readonly get; set; }

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x06000045 RID: 69 RVA: 0x000023B6 File Offset: 0x000005B6
		// (set) Token: 0x06000046 RID: 70 RVA: 0x000023BE File Offset: 0x000005BE
		[YamlMember(Alias = "size", ApplyNamingConventions = false)]
		public Vector2 Size { readonly get; set; }

		// Token: 0x06000047 RID: 71 RVA: 0x000023C7 File Offset: 0x000005C7
		public static implicit operator Rect(Rect v)
		{
			return new Rect(v.Position, v.Size);
		}
	}
}
