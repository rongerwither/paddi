using System;
using UnityEngine;
using UnityEngine.Video;

namespace Fatury
{
	// Token: 0x0200001B RID: 27
	public class ArtifactSpriteScript : MonoBehaviour
	{
		// Token: 0x060000D6 RID: 214 RVA: 0x00006EFC File Offset: 0x000050FC
		public ArtifactSpriteScript(IntPtr intPtr) : base(intPtr)
		{
		}

		// Token: 0x060000D7 RID: 215 RVA: 0x00006F05 File Offset: 0x00005105
		private void Awake()
		{
		}

		// Token: 0x060000D8 RID: 216 RVA: 0x00006F07 File Offset: 0x00005107
		private void Start()
		{
		}

		// Token: 0x060000D9 RID: 217 RVA: 0x00006F09 File Offset: 0x00005109
		private void Update()
		{
			if (!this.playing)
			{
				base.gameObject.GetComponent<VideoPlayer>().Play();
				this.playing = true;
			}
		}

		// Token: 0x060000DA RID: 218 RVA: 0x00006F2A File Offset: 0x0000512A
		private void OnDestroy()
		{
			Object.Destroy(base.transform.Find("newCanvas/parentArt").gameObject);
		}

		// Token: 0x0400004F RID: 79
		public bool playing;
	}
}
