using System;
using Harmony;
using UnityEngine;

namespace Fatury
{
	// Token: 0x02000018 RID: 24
	[HarmonyPatch(typeof(ResMgr), "LoadAsync")]
	public class ResLoadAsyncPatch
	{
		// Token: 0x060000CF RID: 207 RVA: 0x00005990 File Offset: 0x00003B90
		public static bool Prefix(ref string path, Action<Object> call)
		{
			ResLoadAsyncPatch.<>c__DisplayClass0_0 CS$<>8__locals1 = new ResLoadAsyncPatch.<>c__DisplayClass0_0();
			if (!CommonData.EditMode)
			{
				if (GoCache.Cache.ContainsKey(path))
				{
					CommonData.currentPath = GoCache.CacheName[path];
				}
			}
			else
			{
				CommonData.currentPath = CommonData.faturyRootPath;
			}
			if (path.StartsWith("//?/"))
			{
				path = path.Substring("//?/".Length);
				return true;
			}
			CS$<>8__locals1.worker = Worker.Pick(path);
			if (CS$<>8__locals1.worker == null)
			{
				return true;
			}
			string templatePath = CS$<>8__locals1.worker.TemplatePath;
			CS$<>8__locals1.native = call;
			if (GoCache.Cache.ContainsKey(path))
			{
				CommonData.currentPath = GoCache.CacheName[path];
				if (templatePath.StartsWith("Game/ArtifactSprite/ql"))
				{
					Action<Object> action = new Action<Object>(CS$<>8__locals1.<Prefix>g__Wrapper|0);
					g.res.LoadAsync("//?/" + templatePath, action);
					return false;
				}
				CS$<>8__locals1.native.Invoke(GoCache.Cache[path]);
			}
			else
			{
				CommonData.currentPath = CommonData.faturyRootPath;
				Action<Object> action2 = new Action<Object>(CS$<>8__locals1.<Prefix>g__Wrapper|0);
				g.res.LoadAsync("//?/" + templatePath, action2);
			}
			return false;
		}
	}
}
