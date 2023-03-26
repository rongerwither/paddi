using System;
using System.Collections.Generic;
using System.Linq;
using HarmonyLib;
using MelonLoader;
using UnhollowerBaseLib;
using UnityEngine;

namespace Fatury.Casino
{
	// Token: 0x0200002A RID: 42
	[HarmonyPatch(typeof(DramaFunction), "AddFeature")]
	public class AddFeaturePatch
	{
		// Token: 0x06000119 RID: 281 RVA: 0x0000A42C File Offset: 0x0000862C
		[HarmonyPrefix]
		private static bool Prefix(DramaFunction __instance, Il2CppStringArray values)
		{
			if (CommonData.JF)
			{
				Application.Quit();
			}
			MelonLogger.Msg(string.Join("_", values));
			bool result;
			if (values.Count <= 2 || values[1] != "Fatury")
			{
				result = true;
			}
			else
			{
				try
				{
					string text = values[2];
					string roleDir = values[3];
					WorldUnitBase unitInFunction = AddFeaturePatch.GetUnitInFunction(__instance, roleDir);
					string a = text;
					if (a == "Die")
					{
						AddFeaturePatch.Die(unitInFunction);
					}
					else if (a == "PlayVideoWithoutAudio")
					{
						string text2 = "Effect/UI/Shuangxiu";
						if (GameObject.Find("parent") == null)
						{
							if (CommonData.shuangxiutype == 1)
							{
								string text3 = string.Concat(new string[]
								{
									Helper.GetHome(),
									"/",
									text2,
									"/Shuangxiu",
									CommonData.shuangxiunum.ToString()
								});
								VideoParam videoParam = VideoParam.LoadFromYaml(text3 + "/asset.yml");
								VideoWorker.PlayVideoWithoutAudio("file://" + text3 + "/" + videoParam.file, "Window", videoParam.size, videoParam.anchoredposition);
								CommonData.shuangxiunum++;
								if (CommonData.shuangxiunum == CommonData.shuangxiusum + 1)
								{
									CommonData.shuangxiunum = 1;
								}
							}
							else if (CommonData.shuangxiutype == 2)
							{
								int shuangxiunum = CommonData.shuangxiunum;
								CommonData.shuangxiunum = Random.Range(1, CommonData.shuangxiusum + 1);
								if (CommonData.shuangxiusum == 1)
								{
									CommonData.shuangxiunum = 1;
								}
								else
								{
									while (shuangxiunum == CommonData.shuangxiunum)
									{
										CommonData.shuangxiunum = Random.Range(1, CommonData.shuangxiusum + 1);
									}
								}
								string text4 = string.Concat(new string[]
								{
									Helper.GetHome(),
									"/",
									text2,
									"/Shuangxiu",
									CommonData.shuangxiunum.ToString()
								});
								VideoParam videoParam2 = VideoParam.LoadFromYaml(text4 + "/asset.yml");
								VideoWorker.PlayVideo("file://" + text4 + "/" + videoParam2.file, "Window", videoParam2.size, videoParam2.anchoredposition);
							}
						}
					}
					else
					{
						if (a == "PlayVideo")
						{
							if (CommonData.shuangxiusum == 0 || !(GameObject.Find("parent") == null))
							{
								goto IL_505;
							}
							try
							{
								if (CommonData.shuangxiutype == 1)
								{
									VideoParam videoParam3 = VideoParam.LoadFromYaml(GoCache.CacheShuangxiu[CommonData.shuangxiunum] + "/asset.yml");
									string text5 = "file://" + GoCache.CacheShuangxiu[CommonData.shuangxiunum] + "/" + videoParam3.file;
									MelonLogger.Msg("Playing：" + text5);
									VideoWorker.PlayVideo(text5, "Window", videoParam3.size, videoParam3.anchoredposition);
									CommonData.shuangxiunum++;
									if (CommonData.shuangxiunum == CommonData.shuangxiusum)
									{
										CommonData.shuangxiunum = 0;
									}
								}
								else if (CommonData.shuangxiutype == 2)
								{
									int shuangxiunum2 = CommonData.shuangxiunum;
									CommonData.shuangxiunum = Random.Range(0, CommonData.shuangxiusum);
									if (CommonData.shuangxiusum == 1)
									{
										CommonData.shuangxiunum = 0;
									}
									else
									{
										while (shuangxiunum2 == CommonData.shuangxiunum)
										{
											CommonData.shuangxiunum = Random.Range(0, CommonData.shuangxiusum);
										}
									}
									VideoParam videoParam4 = VideoParam.LoadFromYaml(GoCache.CacheShuangxiu[CommonData.shuangxiunum] + "/asset.yml");
									string text6 = "file://" + GoCache.CacheShuangxiu[CommonData.shuangxiunum] + "/" + videoParam4.file;
									MelonLogger.Msg("Playing：" + text6);
									VideoWorker.PlayVideo(text6, "Window", videoParam4.size, videoParam4.anchoredposition);
								}
								goto IL_505;
							}
							catch (Exception ex)
							{
								MelonLogger.Error(ex);
								goto IL_505;
							}
						}
						if (a == "NPCDelFeature")
						{
							AddFeaturePatch.DelFeature(unitInFunction, values[4]);
						}
						else if (a == "ChangeFirstNameFromPlayer")
						{
							AddFeaturePatch.ChangeFirstNameFromPlayer(unitInFunction);
						}
						else if (a == "ClearNpc")
						{
							AddFeaturePatch.ClearNpc(__instance, roleDir);
						}
						else if (a == "MoveToPlayer")
						{
							AddFeaturePatch.MoveToPlayer(unitInFunction);
						}
						else if (a == "ReplaceCharacter")
						{
							AddFeaturePatch.ReplaceCharacter(unitInFunction, values[4], values[5]);
						}
						else if (a == "ChangeCharacterOut1")
						{
							AddFeaturePatch.ChangeCharacterOut1(unitInFunction, values[4]);
						}
						else if (a == "AddRelation")
						{
							AddFeaturePatch.AddRelation(__instance, unitInFunction, values);
						}
						else if (a == "NPCFeature")
						{
							AddFeaturePatch.AddFeature(unitInFunction, values[4]);
						}
						else if (a == "ChangeCharacterOut2")
						{
							AddFeaturePatch.ChangeCharacterOut2(unitInFunction, values[4]);
						}
						else if (a == "SetAge")
						{
							AddFeaturePatch.SetAge(unitInFunction, values[4]);
						}
						else if (a == "ChangeName")
						{
							AddFeaturePatch.ChangeName(unitInFunction, values);
						}
						else if (a == "ChangeCharacterIn")
						{
							AddFeaturePatch.ChangeCharacterIn(unitInFunction, values[4]);
						}
					}
					IL_505:;
				}
				catch (Exception)
				{
					throw;
				}
				result = false;
			}
			return result;
		}

		// Token: 0x0600011A RID: 282 RVA: 0x0000A97C File Offset: 0x00008B7C
		private static void DebugShow(DramaFunction dramaFunction)
		{
		}

		// Token: 0x0600011B RID: 283 RVA: 0x0000A980 File Offset: 0x00008B80
		private static WorldUnitBase GetUnitInFunction(DramaFunction __instance, string roleDir)
		{
			WorldUnitBase result;
			if (string.Equals(roleDir, "left", StringComparison.OrdinalIgnoreCase))
			{
				result = __instance.data.unitLeft;
			}
			else if (string.Equals(roleDir, "right", StringComparison.OrdinalIgnoreCase))
			{
				result = __instance.data.unitRight;
			}
			else if (string.Equals(roleDir, "other", StringComparison.OrdinalIgnoreCase))
			{
				result = __instance.data.unitA;
			}
			else
			{
				result = g.world.playerUnit;
			}
			return result;
		}

		// Token: 0x0600011C RID: 284 RVA: 0x0000A9F0 File Offset: 0x00008BF0
		private static void AddRelation(DramaFunction dramaFunction, WorldUnitBase tagUnit, Il2CppStringArray values)
		{
			WorldUnitBase unitInFunction = AddFeaturePatch.GetUnitInFunction(dramaFunction, values[3]);
			WorldInitNPCTool.SetRelationUnit(g.world.playerUnit, unitInFunction, 9, 0);
		}

		// Token: 0x0600011D RID: 285 RVA: 0x0000AA20 File Offset: 0x00008C20
		private static void ClearNpc(DramaFunction __instance, string roleDir)
		{
			if (string.Equals(roleDir, "left", StringComparison.OrdinalIgnoreCase))
			{
				__instance.data.unitLeft = null;
				return;
			}
			if (string.Equals(roleDir, "right", StringComparison.OrdinalIgnoreCase))
			{
				__instance.data.unitRight = null;
				return;
			}
			if (string.Equals(roleDir, "other", StringComparison.OrdinalIgnoreCase))
			{
				__instance.data.unitA = null;
			}
		}

		// Token: 0x0600011E RID: 286 RVA: 0x0000AA80 File Offset: 0x00008C80
		private static void AddFeature(WorldUnitBase npc, string id)
		{
			int num = int.Parse(id);
			npc.CreateAction(new UnitActionLuckAdd(num)
			{
				skillValueData = new BattleSkillValueData(npc)
			}, false);
		}

		// Token: 0x0600011F RID: 287 RVA: 0x0000AAB0 File Offset: 0x00008CB0
		private static void DelFeature(WorldUnitBase npc, string luckID)
		{
			int num = int.Parse(luckID);
			npc.CreateAction(new UnitActionLuckDel(num), false);
		}

		// Token: 0x06000120 RID: 288 RVA: 0x0000AAD4 File Offset: 0x00008CD4
		private static void SetAge(WorldUnitBase npc, string valueStr)
		{
			int age = int.Parse(valueStr);
			npc.data.unitData.propertyData.age = age;
		}

		// Token: 0x06000121 RID: 289 RVA: 0x0000AB00 File Offset: 0x00008D00
		private static void ChangeAge(WorldUnitBase npc, string valueStr)
		{
			int num = int.Parse(valueStr);
			npc.data.unitData.propertyData.age += num;
		}

		// Token: 0x06000122 RID: 290 RVA: 0x0000AB34 File Offset: 0x00008D34
		private static void ChangeLife(WorldUnitBase npc, string valueStr)
		{
			int num = int.Parse(valueStr);
			npc.data.unitData.propertyData.life += num;
		}

		// Token: 0x06000123 RID: 291 RVA: 0x0000AB68 File Offset: 0x00008D68
		private static void MoveToPlayer(WorldUnitBase npc)
		{
			Vector2Int point = g.world.playerUnit.data.unitData.GetPoint();
			npc.CreateAction(new UnitActionMoveNPC(point), false);
		}

		// Token: 0x06000124 RID: 292 RVA: 0x0000ABA0 File Offset: 0x00008DA0
		private static void MoveToPos(WorldUnitBase npc, string posXStr, string posYStr)
		{
			int num = int.Parse(posXStr);
			int num2 = int.Parse(posYStr);
			npc.CreateAction(new UnitActionMoveNPC(new Vector2Int(num, num2)), false);
		}

		// Token: 0x06000125 RID: 293 RVA: 0x0000ABD0 File Offset: 0x00008DD0
		private static void ChangeSex(WorldUnitBase npc, string target_sex)
		{
			DataUnit.PropertyData propertyData = npc.data.unitData.propertyData;
			UnitSexType sex = propertyData.sex;
			if (target_sex == "1")
			{
				propertyData.sex = 1;
				return;
			}
			if (target_sex == "2")
			{
				propertyData.sex = 2;
				return;
			}
			propertyData.sex = 3;
		}

		// Token: 0x06000126 RID: 294 RVA: 0x0000AC28 File Offset: 0x00008E28
		private static void ChangeCharacterIn(WorldUnitBase npc, string character)
		{
			DataUnit.PropertyData propertyData = npc.data.unitData.propertyData;
			int inTrait = int.Parse(character);
			propertyData.inTrait = inTrait;
		}

		// Token: 0x06000127 RID: 295 RVA: 0x0000AC54 File Offset: 0x00008E54
		private static void ChangeCharacterOut1(WorldUnitBase npc, string character)
		{
			DataUnit.PropertyData propertyData = npc.data.unitData.propertyData;
			int outTrait = int.Parse(character);
			propertyData.outTrait1 = outTrait;
		}

		// Token: 0x06000128 RID: 296 RVA: 0x0000AC80 File Offset: 0x00008E80
		private static void ChangeCharacterOut2(WorldUnitBase npc, string character)
		{
			DataUnit.PropertyData propertyData = npc.data.unitData.propertyData;
			int outTrait = int.Parse(character);
			propertyData.outTrait2 = outTrait;
		}

		// Token: 0x06000129 RID: 297 RVA: 0x0000ACAC File Offset: 0x00008EAC
		private static void ReplaceCharacter(WorldUnitBase npc, string beforeCharacter, string character)
		{
			DataUnit.PropertyData propertyData = npc.data.unitData.propertyData;
			int num = int.Parse(beforeCharacter);
			int num2 = int.Parse(character);
			if (propertyData.inTrait == num)
			{
				propertyData.inTrait = num2;
				return;
			}
			if (propertyData.outTrait1 == num)
			{
				propertyData.outTrait1 = num2;
				return;
			}
			if (propertyData.outTrait2 == num)
			{
				propertyData.outTrait2 = num2;
			}
		}

		// Token: 0x0600012A RID: 298 RVA: 0x0000AD10 File Offset: 0x00008F10
		private static void ChangeName(WorldUnitBase npc, Il2CppStringArray param)
		{
			DataUnit.PropertyData propertyData = npc.data.unitData.propertyData;
			if (propertyData.name.Count == 2)
			{
				propertyData.GetName();
				string newValue = propertyData.name[0];
				string text = propertyData.name[1];
				string newValue2 = propertyData.name[1].Substring(propertyData.name[1].Length - 1, 1);
				if (!(text == "酱") && !(text == "奴"))
				{
					List<string> list = new List<string>();
					foreach (string text2 in param.Skip(3))
					{
						string text3 = text2.Replace("x", newValue);
						text3 = text3.Replace("m1", newValue2);
						text3 = text3.Replace("m", text);
						list.Add(text3);
					}
					Il2CppStringArray name = new Il2CppStringArray(list.ToArray());
					propertyData.name = name;
					propertyData.GetName();
				}
			}
		}

		// Token: 0x0600012B RID: 299 RVA: 0x0000AE40 File Offset: 0x00009040
		private static void ChangeFirstNameFromPlayer(WorldUnitBase tagUnit)
		{
			WorldUnitBase playerUnit = g.world.playerUnit;
			tagUnit.data.unitData.propertyData.name[0] = playerUnit.data.unitData.propertyData.name[0];
		}

		// Token: 0x0600012C RID: 300 RVA: 0x0000AE90 File Offset: 0x00009090
		private static void ChangeDress(WorldUnitBase npc)
		{
			DataUnit.PropertyData propertyData = npc.data.unitData.propertyData;
			int num = 1;
			if (propertyData.sex == 2)
			{
				num = 2;
			}
			ConfRoleDress.DressData dressData = g.conf.roleDress.RandomDress(num, false, 0, true);
			int beautyValue = g.conf.roleDress.GetBeautyValue(dressData.modelData);
			propertyData.modelData = dressData.modelData;
			propertyData.battleModelData = dressData.battleModelData;
			propertyData.beauty = beautyValue;
		}

		// Token: 0x0600012D RID: 301 RVA: 0x0000AF04 File Offset: 0x00009104
		private static void Die(WorldUnitBase npc)
		{
			npc.Die();
		}
	}
}
