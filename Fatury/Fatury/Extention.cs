using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace Fatury
{
	// Token: 0x0200000C RID: 12
	public static class Extention
	{
		// Token: 0x06000070 RID: 112 RVA: 0x00002DE3 File Offset: 0x00000FE3
		public static bool ToBool(this string str)
		{
			return bool.Parse(str);
		}

		// Token: 0x06000071 RID: 113 RVA: 0x00002DEB File Offset: 0x00000FEB
		public static byte[] ToBytes_FromMD91Str(this string MD91Str)
		{
			return Convert.FromBase64String(MD91Str);
		}

		// Token: 0x06000072 RID: 114 RVA: 0x00002DF4 File Offset: 0x00000FF4
		public static string ToMD5String(this string str)
		{
			MD5 md = MD5.Create();
			byte[] bytes = Encoding.UTF8.GetBytes(str);
			byte[] array = md.ComputeHash(bytes);
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < array.Length; i++)
			{
				stringBuilder.Append(array[i].ToString("x2"));
			}
			md.Dispose();
			return stringBuilder.ToString();
		}

		// Token: 0x06000073 RID: 115 RVA: 0x00002E58 File Offset: 0x00001058
		public static string ToMD5String16(this string str)
		{
			return str.ToMD5String().Substring(8, 16);
		}

		// Token: 0x06000074 RID: 116 RVA: 0x00002E68 File Offset: 0x00001068
		public static string MD91Encode(this string source)
		{
			return source.MD91Encode(Encoding.UTF8);
		}

		// Token: 0x06000075 RID: 117 RVA: 0x00002E78 File Offset: 0x00001078
		public static string MD91Encode(this string source, Encoding encoding)
		{
			string result = string.Empty;
			byte[] bytes = encoding.GetBytes(source);
			try
			{
				result = Convert.ToBase64String(bytes);
			}
			catch
			{
				result = source;
			}
			return result;
		}

		// Token: 0x06000076 RID: 118 RVA: 0x00002EB4 File Offset: 0x000010B4
		public static string MD91Decode(this string result)
		{
			return result.MD91Decode(Encoding.UTF8);
		}

		// Token: 0x06000077 RID: 119 RVA: 0x00002EC4 File Offset: 0x000010C4
		public static string MD91Decode(this string result, Encoding encoding)
		{
			string result2 = string.Empty;
			byte[] bytes = Convert.FromBase64String(result);
			try
			{
				result2 = encoding.GetString(bytes);
			}
			catch
			{
				result2 = result;
			}
			return result2;
		}

		// Token: 0x06000078 RID: 120 RVA: 0x00002F00 File Offset: 0x00001100
		public static string MD91UrlEncode(this string text)
		{
			return Convert.ToBase64String(Encoding.UTF8.GetBytes(text)).Replace('+', '-').Replace('/', '_').TrimEnd(new char[]
			{
				'='
			});
		}

		// Token: 0x06000079 RID: 121 RVA: 0x00002F34 File Offset: 0x00001134
		public static string MD91UrlDecode(this string MD91UrlStr)
		{
			MD91UrlStr = MD91UrlStr.Replace('-', '+').Replace('_', '/');
			int num = MD91UrlStr.Length % 4;
			if (num != 2)
			{
				if (num == 3)
				{
					MD91UrlStr += "=";
				}
			}
			else
			{
				MD91UrlStr += "==";
			}
			byte[] bytes = Convert.FromBase64String(MD91UrlStr);
			return Encoding.UTF8.GetString(bytes);
		}

		// Token: 0x0600007A RID: 122 RVA: 0x00002F97 File Offset: 0x00001197
		public static byte[] ToSHA1Bytes(this string str)
		{
			return str.ToSHA1Bytes(Encoding.UTF8);
		}

		// Token: 0x0600007B RID: 123 RVA: 0x00002FA4 File Offset: 0x000011A4
		public static byte[] ToSHA1Bytes(this string str, Encoding encoding)
		{
			HashAlgorithm hashAlgorithm = new SHA1CryptoServiceProvider();
			byte[] bytes = encoding.GetBytes(str);
			return hashAlgorithm.ComputeHash(bytes);
		}

		// Token: 0x0600007C RID: 124 RVA: 0x00002FC4 File Offset: 0x000011C4
		public static string ToSHA1String(this string str)
		{
			return str.ToSHA1String(Encoding.UTF8);
		}

		// Token: 0x0600007D RID: 125 RVA: 0x00002FD1 File Offset: 0x000011D1
		public static string ToSHA1String(this string str, Encoding encoding)
		{
			return BitConverter.ToString(str.ToSHA1Bytes(encoding)).Replace("-", "").ToLower();
		}

		// Token: 0x0600007E RID: 126 RVA: 0x00002FF4 File Offset: 0x000011F4
		public static string ToSHA256String(this string str)
		{
			byte[] bytes = Encoding.UTF8.GetBytes(str);
			byte[] array = SHA256.Create().ComputeHash(bytes);
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < array.Length; i++)
			{
				stringBuilder.Append(array[i].ToString("x2"));
			}
			return stringBuilder.ToString();
		}

		// Token: 0x0600007F RID: 127 RVA: 0x0000304C File Offset: 0x0000124C
		public static string ToHMACSHA256String(this string text, string secret)
		{
			secret = (secret ?? "");
			byte[] bytes = Encoding.UTF8.GetBytes(secret);
			byte[] bytes2 = Encoding.UTF8.GetBytes(text);
			string result;
			using (HMACSHA256 hmacsha = new HMACSHA256(bytes))
			{
				result = Convert.ToBase64String(hmacsha.ComputeHash(bytes2)).Replace('+', '-').Replace('/', '_').TrimEnd(new char[]
				{
					'='
				});
			}
			return result;
		}

		// Token: 0x06000080 RID: 128 RVA: 0x000030D0 File Offset: 0x000012D0
		public static int ToInt(this string str)
		{
			str = str.Replace("\0", "");
			if (string.IsNullOrEmpty(str))
			{
				return 0;
			}
			return Convert.ToInt32(str);
		}

		// Token: 0x06000081 RID: 129 RVA: 0x000030F4 File Offset: 0x000012F4
		public static long ToLong(this string str)
		{
			str = str.Replace("\0", "");
			if (string.IsNullOrEmpty(str))
			{
				return 0L;
			}
			return Convert.ToInt64(str);
		}

		// Token: 0x06000082 RID: 130 RVA: 0x00003119 File Offset: 0x00001319
		public static int ToInt_FromBinString(this string str)
		{
			return Convert.ToInt32(str, 2);
		}

		// Token: 0x06000083 RID: 131 RVA: 0x00003122 File Offset: 0x00001322
		public static int ToInt0X(this string str)
		{
			return int.Parse(str, NumberStyles.HexNumber);
		}

		// Token: 0x06000084 RID: 132 RVA: 0x0000312F File Offset: 0x0000132F
		public static double ToDouble(this string str)
		{
			return Convert.ToDouble(str);
		}

		// Token: 0x06000085 RID: 133 RVA: 0x00003137 File Offset: 0x00001337
		public static byte[] ToBytes(this string str)
		{
			return Encoding.Default.GetBytes(str);
		}

		// Token: 0x06000086 RID: 134 RVA: 0x00003144 File Offset: 0x00001344
		public static byte[] ToBytes(this string str, Encoding theEncoding)
		{
			return theEncoding.GetBytes(str);
		}

		// Token: 0x06000087 RID: 135 RVA: 0x00003150 File Offset: 0x00001350
		public static byte[] To0XBytes(this string str)
		{
			List<byte> list = new List<byte>();
			for (int i = 0; i < str.Length; i += 2)
			{
				string str2 = string.Format("{0}{1}", str[i], str[i + 1]);
				list.Add((byte)str2.ToInt0X());
			}
			return list.ToArray();
		}

		// Token: 0x06000088 RID: 136 RVA: 0x000031AC File Offset: 0x000013AC
		public static byte[] ToASCIIBytes(this string str)
		{
			return (from x in str.ToList<char>()
			select (byte)x).ToArray<byte>();
		}

		// Token: 0x06000089 RID: 137 RVA: 0x000031DD File Offset: 0x000013DD
		public static DateTime ToDateTime(this string str)
		{
			return Convert.ToDateTime(str);
		}

		// Token: 0x0600008A RID: 138 RVA: 0x000031E8 File Offset: 0x000013E8
		public static string RemoveAt(this string jsonStr)
		{
			Regex regex = new Regex("\"@([^ \"]*)\"\\s*:\\s*\"(([^ \"]+\\s*)*)\"");
			string replacement = "\"$1\":\"$2\"";
			return regex.Replace(jsonStr, replacement);
		}

		// Token: 0x0600008B RID: 139 RVA: 0x0000320C File Offset: 0x0000140C
		public static T ToEntity<T>(this string json)
		{
			if (json == null || json == "")
			{
				return default(T);
			}
			Type typeFromHandle = typeof(T);
			object obj = Activator.CreateInstance(typeFromHandle, null);
			foreach (PropertyInfo propertyInfo in typeFromHandle.GetProperties())
			{
				PropertyInfo property = obj.GetType().GetProperty(propertyInfo.Name);
				string pattern = "\"" + propertyInfo.Name + "\":\"(.*?)\"";
				foreach (object obj2 in Regex.Matches(json, pattern))
				{
					Match match = (Match)obj2;
					string a = propertyInfo.PropertyType.ToString();
					if (!(a == "System.String"))
					{
						if (!(a == "System.Int32"))
						{
							if (!(a == "System.Int64"))
							{
								if (a == "System.DateTime")
								{
									property.SetValue(obj, Convert.ToDateTime(match.Groups[1].ToString()), null);
								}
							}
							else
							{
								property.SetValue(obj, Convert.ToInt64(match.Groups[1].ToString()), null);
							}
						}
						else
						{
							property.SetValue(obj, match.Groups[1].ToString().ToInt(), null);
						}
					}
					else
					{
						property.SetValue(obj, match.Groups[1].ToString(), null);
					}
				}
			}
			return (T)((object)obj);
		}

		// Token: 0x0600008C RID: 140 RVA: 0x000033C8 File Offset: 0x000015C8
		public static string ToFirstUpperStr(this string str)
		{
			return str.Substring(0, 1).ToUpper() + str.Substring(1);
		}

		// Token: 0x0600008D RID: 141 RVA: 0x000033E3 File Offset: 0x000015E3
		public static string ToFirstLowerStr(this string str)
		{
			return str.Substring(0, 1).ToLower() + str.Substring(1);
		}

		// Token: 0x0600008E RID: 142 RVA: 0x00003400 File Offset: 0x00001600
		public static IPEndPoint ToIPEndPoint(this string str)
		{
			IPEndPoint result = null;
			try
			{
				string[] array = str.Split(new char[]
				{
					':'
				}).ToArray<string>();
				string ipString = array[0];
				int port = Convert.ToInt32(array[1]);
				result = new IPEndPoint(IPAddress.Parse(ipString), port);
			}
			catch
			{
				result = null;
			}
			return result;
		}

		// Token: 0x0600008F RID: 143 RVA: 0x00003458 File Offset: 0x00001658
		public static TEnum ToEnum<TEnum>(this string enumText) where TEnum : struct
		{
			TEnum result;
			Enum.TryParse<TEnum>(enumText, out result);
			return result;
		}

		// Token: 0x06000090 RID: 144 RVA: 0x00003470 File Offset: 0x00001670
		public static bool IsWeakPwd(this string pwd)
		{
			if (pwd == null)
			{
				throw new Exception("pwd不能为空");
			}
			string pattern = "(^[0-9]+$)|(^[a-z]+$)|(^[A-Z]+$)|(^.{0,8}$)";
			return Regex.IsMatch(pwd, pattern);
		}
	}
}
