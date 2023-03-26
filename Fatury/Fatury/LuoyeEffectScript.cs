using System;
using UnityEngine;

namespace Fatury
{
	// Token: 0x02000007 RID: 7
	public class LuoyeEffectScript : MonoBehaviour
	{
		// Token: 0x06000051 RID: 81 RVA: 0x0000244D File Offset: 0x0000064D
		public LuoyeEffectScript(IntPtr intPtr) : base(intPtr)
		{
		}

		// Token: 0x06000052 RID: 82 RVA: 0x00002456 File Offset: 0x00000656
		private void Awake()
		{
		}

		// Token: 0x06000053 RID: 83 RVA: 0x00002458 File Offset: 0x00000658
		private void Start()
		{
			Object.Destroy(GameObject.Find("kaijuluoye"));
		}

		// Token: 0x06000054 RID: 84 RVA: 0x00002469 File Offset: 0x00000669
		private void Update()
		{
		}

		// Token: 0x06000055 RID: 85 RVA: 0x0000246B File Offset: 0x0000066B
		private void OnDestroy()
		{
		}
	}
}
