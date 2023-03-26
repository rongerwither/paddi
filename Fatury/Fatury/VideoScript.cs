using System;
using UnityEngine;

namespace Fatury
{
	// Token: 0x0200001F RID: 31
	public class VideoScript : MonoBehaviour
	{
		// Token: 0x060000F4 RID: 244 RVA: 0x00007506 File Offset: 0x00005706
		public VideoScript(IntPtr intPtr) : base(intPtr)
		{
		}

		// Token: 0x060000F5 RID: 245 RVA: 0x0000750F File Offset: 0x0000570F
		private void Awake()
		{
		}

		// Token: 0x060000F6 RID: 246 RVA: 0x00007511 File Offset: 0x00005711
		private void Start()
		{
		}

		// Token: 0x060000F7 RID: 247 RVA: 0x00007513 File Offset: 0x00005713
		private void Update()
		{
			if (Input.GetMouseButtonUp(0))
			{
				GoCache.Cache.Remove("parent");
				Object.Destroy(base.gameObject);
			}
		}

		// Token: 0x060000F8 RID: 248 RVA: 0x00007538 File Offset: 0x00005738
		private void OnDestroy()
		{
			Object.Destroy(base.GetComponent<VideoScript>());
		}
	}
}
