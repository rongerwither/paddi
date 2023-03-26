using System;
using MelonLoader;
using UnityEngine;

namespace Fatury
{
	// Token: 0x0200001D RID: 29
	public class ItemFloatScript : MonoBehaviour
	{
		// Token: 0x060000EB RID: 235 RVA: 0x000072E4 File Offset: 0x000054E4
		public ItemFloatScript(IntPtr intPtr) : base(intPtr)
		{
		}

		// Token: 0x060000EC RID: 236 RVA: 0x00007312 File Offset: 0x00005512
		private void Start()
		{
			if (this.speed <= 0f)
			{
				this.speed = 1f;
			}
			this.originalPos = base.gameObject.transform.localPosition;
		}

		// Token: 0x060000ED RID: 237 RVA: 0x00007344 File Offset: 0x00005544
		private void Update()
		{
			MelonLogger.Msg(string.Format("{0}", ItemFloatScript.delScript));
			if (!ItemFloatScript.setPos)
			{
				this.originalPos = base.gameObject.transform.localPosition;
				ItemFloatScript.setPos = true;
			}
			if (!ItemFloatScript.delScript)
			{
				Object.Destroy(base.gameObject.GetComponentInChildren<EffectTraceTargetCtrl>());
				ItemFloatScript.delScript = true;
			}
			base.gameObject.transform.localPosition = this.originalPos + new Vector3(0f, this.offsetXYZ.y * Mathf.Cos(Time.time * this.speed) * Mathf.Sin(Time.time * this.speed), 0f);
		}

		// Token: 0x060000EE RID: 238 RVA: 0x00007403 File Offset: 0x00005603
		private void OnDestroy()
		{
			ItemFloatScript.setPos = false;
			ItemFloatScript.delScript = false;
			Object.Destroy(base.GetComponent<ItemFloatScript>());
		}

		// Token: 0x0400005D RID: 93
		public float speed = 1f;

		// Token: 0x0400005E RID: 94
		public Vector3 offsetXYZ = new Vector3(1f, 0.1f, 1f);

		// Token: 0x0400005F RID: 95
		private Vector3 originalPos;

		// Token: 0x04000060 RID: 96
		private static bool setPos;

		// Token: 0x04000061 RID: 97
		private static bool delScript;
	}
}
