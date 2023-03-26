using System;
using UnityEngine;

namespace Fatury
{
	// Token: 0x02000020 RID: 32
	public class WholePortraitScript : MonoBehaviour
	{
		// Token: 0x060000F9 RID: 249 RVA: 0x00007545 File Offset: 0x00005745
		public WholePortraitScript(IntPtr intPtr) : base(intPtr)
		{
		}

		// Token: 0x060000FA RID: 250 RVA: 0x0000754E File Offset: 0x0000574E
		private void Awake()
		{
		}

		// Token: 0x060000FB RID: 251 RVA: 0x00007550 File Offset: 0x00005750
		private void Start()
		{
			Transform parent = base.transform.parent;
			if (parent != null)
			{
				foreach (Transform transform in parent.parent.GetComponentsInChildren<Transform>())
				{
					if (transform.name != "Body" && transform.name != "PortraitRoot(Clone)" && transform.name != base.gameObject.name && transform.name != "sprite")
					{
						transform.gameObject.SetActive(false);
					}
				}
			}
		}

		// Token: 0x060000FC RID: 252 RVA: 0x00007610 File Offset: 0x00005810
		private void Update()
		{
		}

		// Token: 0x060000FD RID: 253 RVA: 0x00007612 File Offset: 0x00005812
		private void OnDestroy()
		{
		}

		// Token: 0x04000063 RID: 99
		public bool playing;
	}
}
