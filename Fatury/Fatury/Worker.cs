using System;
using System.IO;
using System.Text.RegularExpressions;
using Fautry;
using UnityEngine;

namespace Fatury
{
	// Token: 0x02000021 RID: 33
	internal abstract class Worker
	{
		// Token: 0x17000032 RID: 50
		// (get) Token: 0x060000FE RID: 254 RVA: 0x00007614 File Offset: 0x00005814
		public string TemplatePath
		{
			get
			{
				if (this.assetType == "renwu")
				{
					Match match = this.pathPattern_renwu.Match(this.resPath);
					string value = match.Groups[1].Value;
					string path = Path.Combine(Helper.GetHome(), value, match.Groups[2].Value, "asset.yml");
					string value2 = match.Groups[2].Value;
					if (File.Exists(path))
					{
						this.spriteParam = SpriteParam.LoadFromYaml(path);
						return this.spriteParam.Template ?? value2;
					}
					return value + value2 + match.Groups[3].Value;
				}
				else
				{
					if (this.assetType == "qiling")
					{
						return this.resPath;
					}
					if (this.assetType == "shuangxiu")
					{
						return this.resPath;
					}
					if (this.assetType == "NPCdynamic")
					{
						return this.resPath;
					}
					if (this.assetType == "NPC")
					{
						return this.resPath;
					}
					if (this.assetType == "Monst")
					{
						return this.resPath;
					}
					if (this.assetType == "Common")
					{
						return this.resPath;
					}
					return "0";
				}
			}
		}

		// Token: 0x17000033 RID: 51
		// (get) Token: 0x060000FF RID: 255 RVA: 0x0000776F File Offset: 0x0000596F
		protected virtual Func<string, string> MapPath
		{
			get
			{
				return (string s) => s;
			}
		}

		// Token: 0x17000034 RID: 52
		// (get) Token: 0x06000100 RID: 256 RVA: 0x00007790 File Offset: 0x00005990
		protected string AbsolutelyPhysicalPath
		{
			get
			{
				return Path.Combine(Helper.GetHome(), this.MapPath(this.resPath));
			}
		}

		// Token: 0x06000101 RID: 257
		public abstract GameObject Rework(GameObject template);

		// Token: 0x06000102 RID: 258 RVA: 0x000077B0 File Offset: 0x000059B0
		public static Worker Pick(string path)
		{
			Worker worker = null;
			if (path.IsPortraitDynamic())
			{
				worker = new PortraitDynamicWorker
				{
					resPath = path,
					assetType = "renwu"
				};
			}
			else if (path.IsArtifactSprite())
			{
				worker = new ArtifactSpriteWorker
				{
					resPath = path,
					assetType = "qiling"
				};
			}
			else if (path.IsNPCDynamic())
			{
				worker = new NPCDynamicWorker
				{
					resPath = path,
					assetType = "NPCdynamic"
				};
			}
			else if (path.IsNPC())
			{
				worker = new NPCWorker
				{
					resPath = path,
					assetType = "NPC"
				};
			}
			else if (path.IsMonst())
			{
				worker = new MonstWorker
				{
					resPath = path,
					assetType = "Monst"
				};
			}
			else if (path.IsEffectBattle())
			{
				worker = new CommonWorker
				{
					resPath = path,
					assetType = "Common"
				};
			}
			else if (path.IsPortrait())
			{
				worker = new PortraitWorker
				{
					resPath = path,
					assetType = "renwu"
				};
			}
			else if (path.IsTexture())
			{
				worker = new CommonWorker
				{
					resPath = path,
					assetType = "renwu"
				};
			}
			if (worker == null || !worker.AbsolutelyPhysicalPath.Exist())
			{
				return null;
			}
			return worker;
		}

		// Token: 0x04000064 RID: 100
		private string resPath;

		// Token: 0x04000065 RID: 101
		private string assetType;

		// Token: 0x04000066 RID: 102
		private SpriteParam spriteParam;

		// Token: 0x04000067 RID: 103
		private readonly Regex pathPattern_renwu = new Regex("^(.+/)([0-9]{3,})(/[^/]+|$)$");
	}
}
