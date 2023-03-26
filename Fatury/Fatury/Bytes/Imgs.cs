using System;

namespace Fatury.Bytes
{
	// Token: 0x02000030 RID: 48
	public static class Imgs
	{
		// Token: 0x06000144 RID: 324 RVA: 0x0000B5B4 File Offset: 0x000097B4
		public static byte[] DecryptImgs(byte[] img)
		{
			string newValue = "89 50 4E 47 0D 0A 1A 0A 00 00 00 0D 49 48 44 52";
			string oldValue = "89 44 41 54 0D 0A 1A 0A 00 00 00 0D 49 48 44 52";
			return ByteConverters.HexToByte(ByteConverters.ByteToHex(img).Replace(oldValue, newValue));
		}

		// Token: 0x06000145 RID: 325 RVA: 0x0000B5E0 File Offset: 0x000097E0
		public static byte[] DecryptImgs2(byte[] img)
		{
			string newValue = "89 50 4E 47 0D 0A 1A 0A 00 00 00 0D 49 48 44 52";
			string oldValue = "89 44 48 54 0D 0A 1A 0A 00 00 00 0D 49 48 44 52";
			return ByteConverters.HexToByte(ByteConverters.ByteToHex(img).Replace(oldValue, newValue));
		}
	}
}
