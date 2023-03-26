using System;

namespace Fatury.Bytes
{
	// Token: 0x02000031 RID: 49
	public static class Imgs2
	{
		// Token: 0x06000146 RID: 326 RVA: 0x0000B60C File Offset: 0x0000980C
		public static byte[] DecryptImgs(byte[] bytes)
		{
			byte[] array = new byte[4];
			for (int i = 0; i < 4; i++)
			{
				array[i] = bytes[i];
			}
			string text = ByteConverters.ByteToHex(array);
			string newValue = "52 49 46 46";
			string oldValue = "52 41 45 40";
			byte[] array2 = ByteConverters.HexToByte(text.Replace(oldValue, newValue));
			for (int j = 0; j < 4; j++)
			{
				bytes[j] = array2[j];
			}
			return bytes;
		}
	}
}
