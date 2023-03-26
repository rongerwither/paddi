using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Harmony;
using MelonLoader;
using UnityEngine;

namespace Fatury
{
	// Token: 0x02000019 RID: 25
	[HarmonyPatch]
	public class ResLoadPatch
	{
		// Token: 0x060000D1 RID: 209 RVA: 0x00005AD1 File Offset: 0x00003CD1
		public static MethodBase TargetMethod()
		{
			return typeof(ResMgr).GetMethods().First((MethodInfo m) => !m.IsGenericMethod && m.Name == "Load");
		}

		// Token: 0x060000D2 RID: 210 RVA: 0x00005B08 File Offset: 0x00003D08
		public static bool Prefix(ref Object __result, string path)
		{
			if (path.StartsWith("Game/PortraitDynamic"))
			{
				if (!CommonData.EditMode)
				{
					if (GoCache.Cache.ContainsKey(path))
					{
						CommonData.currentPath = GoCache.CacheName[path];
						if (Directory.Exists(Helper.GetHome() + "/" + path))
						{
							Worker worker = Worker.Pick(path);
							if (worker == null)
							{
								return true;
							}
							string templatePath = worker.TemplatePath;
							try
							{
								GameObject gameObject;
								if (GoCache.Cache.ContainsKey(templatePath))
								{
									gameObject = GoCache.Cache[templatePath];
								}
								else
								{
									MelonLogger.Msg("tp:" + templatePath);
									GameObject template = Object.Instantiate<GameObject>(Resources.Load<GameObject>(templatePath), GoCache.Root.transform);
									gameObject = worker.Rework(template);
									GoCache.Cache.Add(templatePath, gameObject);
								}
								__result = gameObject;
							}
							catch (Exception arg)
							{
								MelonLogger.Error(string.Format("{0}\n{1}", arg, templatePath));
							}
							return false;
						}
					}
				}
				else
				{
					CommonData.currentPath = CommonData.faturyRootPath;
					if (Directory.Exists(Helper.GetHome() + "/" + path))
					{
						Worker worker2 = Worker.Pick(path);
						if (worker2 == null)
						{
							return true;
						}
						string templatePath2 = worker2.TemplatePath;
						try
						{
							GameObject gameObject2;
							if (GoCache.Cache.ContainsKey(templatePath2))
							{
								gameObject2 = worker2.Rework(GoCache.Cache[templatePath2]);
							}
							else
							{
								MelonLogger.Msg("tp:" + templatePath2);
								GameObject template2 = Object.Instantiate<GameObject>(Resources.Load<GameObject>(templatePath2), GoCache.Root.transform);
								gameObject2 = worker2.Rework(template2);
								GoCache.Cache.Add(templatePath2, gameObject2);
							}
							__result = gameObject2;
						}
						catch (Exception arg2)
						{
							MelonLogger.Error(string.Format("{0}\n{1}", arg2, templatePath2));
						}
						return false;
					}
				}
			}
			if (path.StartsWith("Game/Portrait/"))
			{
				if (!CommonData.EditMode)
				{
					if (!GoCache.Cache.ContainsKey(path))
					{
						return true;
					}
					CommonData.currentPath = GoCache.CacheName[path];
					Worker worker3 = Worker.Pick(path);
					if (worker3 == null)
					{
						return true;
					}
					string templatePath3 = worker3.TemplatePath;
					try
					{
						GameObject gameObject3;
						if (GoCache.Cache.ContainsKey(path))
						{
							gameObject3 = GoCache.Cache[path];
						}
						else
						{
							GameObject gameObject4 = Object.Instantiate<GameObject>(Resources.Load<GameObject>(templatePath3), GoCache.Root.transform);
							GoCache.Cache.Add(path, gameObject4);
							gameObject3 = worker3.Rework(gameObject4);
						}
						__result = gameObject3;
						return false;
					}
					catch (Exception arg3)
					{
						MelonLogger.Error(string.Format("{0}\n{1}", arg3, templatePath3));
						return true;
					}
				}
				CommonData.currentPath = CommonData.faturyRootPath;
				Worker worker4 = Worker.Pick(path);
				if (worker4 == null)
				{
					return true;
				}
				string templatePath4 = worker4.TemplatePath;
				try
				{
					GameObject gameObject5;
					if (GoCache.Cache.ContainsKey(path))
					{
						gameObject5 = GoCache.Cache[path];
						gameObject5 = worker4.Rework(GoCache.Cache[path]);
					}
					else
					{
						MelonLogger.Msg("tp:" + path);
						GameObject gameObject6 = Object.Instantiate<GameObject>(Resources.Load<GameObject>(templatePath4), GoCache.Root.transform);
						GoCache.Cache.Add(path, gameObject6);
						gameObject5 = worker4.Rework(gameObject6);
					}
					__result = gameObject5;
					return false;
				}
				catch (Exception arg4)
				{
					MelonLogger.Error(string.Format("{0}\n{1}", arg4, templatePath4));
				}
				return true;
			}
			return true;
		}
	}
}
