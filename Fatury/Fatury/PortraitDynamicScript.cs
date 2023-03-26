using System;
using UnityEngine;
using UnityEngine.Video;

namespace Fatury
{
	// Token: 0x0200001E RID: 30
	public class PortraitDynamicScript : MonoBehaviour
	{
		// Token: 0x060000EF RID: 239 RVA: 0x0000741C File Offset: 0x0000561C
		public PortraitDynamicScript(IntPtr intPtr) : base(intPtr)
		{
		}

		// Token: 0x060000F0 RID: 240 RVA: 0x00007425 File Offset: 0x00005625
		private void Awake()
		{
		}

		// Token: 0x060000F1 RID: 241 RVA: 0x00007427 File Offset: 0x00005627
		private void Start()
		{
		}

		// Token: 0x060000F2 RID: 242 RVA: 0x0000742C File Offset: 0x0000562C
		private void Update()
		{
			if (!this.playing)
			{
				VideoPlayer component = base.gameObject.GetComponent<VideoPlayer>();
				base.gameObject.transform.parent.position = new Vector3(base.transform.parent.parent.position.x - base.transform.parent.parent.localPosition.x, base.transform.parent.parent.position.y - base.transform.parent.parent.localPosition.y, base.transform.parent.parent.position.z);
				component.Play();
				this.playing = true;
			}
		}

		// Token: 0x060000F3 RID: 243 RVA: 0x000074F9 File Offset: 0x000056F9
		private void OnDestroy()
		{
			Object.Destroy(base.GetComponent<PortraitDynamicScript>());
		}

		// Token: 0x04000062 RID: 98
		public bool playing;
	}
}
