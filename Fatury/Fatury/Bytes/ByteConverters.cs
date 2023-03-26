using System;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace Fatury.Bytes
{
	// Token: 0x0200002C RID: 44
	public static class ByteConverters
	{
		// Token: 0x06000132 RID: 306 RVA: 0x0000B19C File Offset: 0x0000939C
		public static string LongToHex(long val, OffSetPanelFixedWidth offsetwight = OffSetPanelFixedWidth.Dynamic)
		{
			return val.ToString((offsetwight == OffSetPanelFixedWidth.Dynamic) ? ConstantReadOnly.HexStringFormat : ConstantReadOnly.HexLineInfoStringFormat, CultureInfo.InvariantCulture);
		}

		// Token: 0x06000133 RID: 307 RVA: 0x0000B1BC File Offset: 0x000093BC
		public static string LongToString(long val, int saveBits = -1)
		{
			if (saveBits == -1)
			{
				return FormattableString.Invariant(FormattableStringFactory.Create("{0}", new object[]
				{
					val
				}));
			}
			char[] array = new char[saveBits];
			for (int i = 1; i <= saveBits; i++)
			{
				array[saveBits - i] = (char)(val % 10L + 48L);
				val /= 10L;
			}
			return new string(array);
		}

		// Token: 0x06000134 RID: 308 RVA: 0x0000B21B File Offset: 0x0000941B
		public static char ByteToChar(byte val)
		{
			if (val <= 31 || (val > 126 && val < 160))
			{
				return '.';
			}
			return (char)val;
		}

		// Token: 0x06000135 RID: 309 RVA: 0x0000B233 File Offset: 0x00009433
		public static byte CharToByte(char val)
		{
			return (byte)val;
		}

		// Token: 0x06000136 RID: 310 RVA: 0x0000B238 File Offset: 0x00009438
		public static string ByteToHex(byte[] data)
		{
			if (data == null)
			{
				return string.Empty;
			}
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < data.Length; i++)
			{
				string value = ByteConverters.ByteToHex(data[i]);
				stringBuilder.Append(value);
				stringBuilder.Append(' ');
			}
			if (stringBuilder.Length > 0)
			{
				stringBuilder.Remove(stringBuilder.Length - 1, 1);
			}
			return stringBuilder.ToString();
		}

		// Token: 0x06000137 RID: 311 RVA: 0x0000B2A0 File Offset: 0x000094A0
		public static char[] ByteToHexCharArray(byte val)
		{
			char[] array = new char[2];
			ByteConverters.ByteToHexCharArray(val, array);
			return array;
		}

		// Token: 0x06000138 RID: 312 RVA: 0x0000B2BC File Offset: 0x000094BC
		public static void ByteToHexCharArray(byte val, char[] charArr)
		{
			if (charArr == null)
			{
				throw new ArgumentNullException("charArr");
			}
			if (charArr.Length != 2)
			{
				throw new ArgumentException(string.Format("The length of {0} should be 2.", charArr));
			}
			charArr[0] = ByteConverters.ByteToHexChar(val >> 4);
			charArr[1] = ByteConverters.ByteToHexChar((int)val - (val >> 4 << 4));
		}

		// Token: 0x06000139 RID: 313 RVA: 0x0000B308 File Offset: 0x00009508
		public static char ByteToHexChar(int val)
		{
			char result;
			if (val < 10)
			{
				result = (char)(48 + val);
			}
			else
			{
				char c;
				switch (val)
				{
				case 10:
					c = 'A';
					break;
				case 11:
					c = 'B';
					break;
				case 12:
					c = 'C';
					break;
				case 13:
					c = 'D';
					break;
				case 14:
					c = 'E';
					break;
				case 15:
					c = 'F';
					break;
				default:
					c = 's';
					break;
				}
				result = c;
			}
			return result;
		}

		// Token: 0x0600013A RID: 314 RVA: 0x0000B369 File Offset: 0x00009569
		public static string ByteToHex(byte val)
		{
			return new string(ByteConverters.ByteToHexCharArray(val));
		}

		// Token: 0x0600013B RID: 315 RVA: 0x0000B378 File Offset: 0x00009578
		public static string BytesToString(byte[] buffer, ByteToString converter = ByteToString.ByteToCharProcess)
		{
			if (buffer == null)
			{
				return string.Empty;
			}
			if (converter == ByteToString.ByteToCharProcess)
			{
				StringBuilder stringBuilder = new StringBuilder();
				foreach (byte val in buffer)
				{
					stringBuilder.Append(ByteConverters.ByteToChar(val));
				}
				return stringBuilder.ToString();
			}
			if (converter == ByteToString.AsciiEncoding)
			{
				return Encoding.ASCII.GetString(buffer, 0, buffer.Length);
			}
			return string.Empty;
		}

		// Token: 0x0600013C RID: 316 RVA: 0x0000B3D8 File Offset: 0x000095D8
		public static byte[] HexToByte(string hex)
		{
			if (string.IsNullOrEmpty(hex))
			{
				return null;
			}
			hex = hex.Trim();
			string[] array = hex.Split(new char[]
			{
				' '
			});
			byte[] array2 = new byte[array.Length];
			for (int i = 0; i < array.Length; i++)
			{
				ValueTuple<bool, byte> valueTuple = ByteConverters.HexToUniqueByte(array[i]);
				bool item = valueTuple.Item1;
				byte item2 = valueTuple.Item2;
				if (!item)
				{
					return null;
				}
				array2[i] = item2;
			}
			return array2;
		}

		// Token: 0x0600013D RID: 317 RVA: 0x0000B444 File Offset: 0x00009644
		[return: TupleElementNames(new string[]
		{
			"success",
			"val"
		})]
		public static ValueTuple<bool, byte> HexToUniqueByte(string hex)
		{
			byte item;
			return new ValueTuple<bool, byte>(byte.TryParse(hex, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out item), item);
		}

		// Token: 0x0600013E RID: 318 RVA: 0x0000B46C File Offset: 0x0000966C
		[return: TupleElementNames(new string[]
		{
			"success",
			"position"
		})]
		public static ValueTuple<bool, long> HexLiteralToLong(string hex)
		{
			if (string.IsNullOrEmpty(hex))
			{
				return new ValueTuple<bool, long>(false, -1L);
			}
			int i = (hex.Length > 1 && hex[0] == '0' && (hex[1] == 'x' || hex[1] == 'X')) ? 2 : 0;
			long num = 0L;
			while (i < hex.Length)
			{
				int num2 = (int)hex[i++];
				if (num2 >= 48 && num2 <= 57)
				{
					num2 -= 48;
				}
				else if (num2 >= 65 && num2 <= 70)
				{
					num2 = num2 - 65 + 10;
				}
				else
				{
					if (num2 < 97 || num2 > 102)
					{
						return new ValueTuple<bool, long>(false, -1L);
					}
					num2 = num2 - 97 + 10;
				}
				num = 16L * num + (long)num2;
			}
			return new ValueTuple<bool, long>(true, num);
		}

		// Token: 0x0600013F RID: 319 RVA: 0x0000B525 File Offset: 0x00009725
		[return: TupleElementNames(new string[]
		{
			"success",
			"value"
		})]
		public static ValueTuple<bool, long> IsHexValue(string hexastring)
		{
			return ByteConverters.HexLiteralToLong(hexastring);
		}

		// Token: 0x06000140 RID: 320 RVA: 0x0000B52D File Offset: 0x0000972D
		[return: TupleElementNames(new string[]
		{
			"success",
			"value"
		})]
		public static ValueTuple<bool, byte[]> IsHexaByteStringValue(string hexastring)
		{
			if (ByteConverters.HexToByte(hexastring) != null)
			{
				return new ValueTuple<bool, byte[]>(true, ByteConverters.HexToByte(hexastring));
			}
			return new ValueTuple<bool, byte[]>(false, null);
		}

		// Token: 0x06000141 RID: 321 RVA: 0x0000B54B File Offset: 0x0000974B
		public static byte[] StringToByte(string str)
		{
			Func<char, byte> selector;
			if ((selector = ByteConverters.<>O.<0>__CharToByte) == null)
			{
				selector = (ByteConverters.<>O.<0>__CharToByte = new Func<char, byte>(ByteConverters.CharToByte));
			}
			return str.Select(selector).ToArray<byte>();
		}

		// Token: 0x06000142 RID: 322 RVA: 0x0000B573 File Offset: 0x00009773
		public static string StringToHex(string str)
		{
			return ByteConverters.ByteToHex(ByteConverters.StringToByte(str));
		}

		// Token: 0x0200003A RID: 58
		[CompilerGenerated]
		private static class <>O
		{
			// Token: 0x0400008B RID: 139
			public static Func<char, byte> <0>__CharToByte;
		}
	}
}
