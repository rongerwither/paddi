using System;
using System.IO;

namespace Fatury
{
	// Token: 0x02000011 RID: 17
	internal class IOtxt
	{
		// Token: 0x060000A6 RID: 166 RVA: 0x00004A78 File Offset: 0x00002C78
		public static void Write(string path, string value, bool isClearOldText = true)
		{
			if (isClearOldText)
			{
				using (FileStream fileStream = File.Open(path, FileMode.OpenOrCreate, FileAccess.Write))
				{
					fileStream.Seek(0L, SeekOrigin.Begin);
					fileStream.SetLength(0L);
				}
			}
			using (StreamWriter streamWriter = new StreamWriter(path, true))
			{
				streamWriter.WriteLine(value);
			}
		}

		// Token: 0x060000A7 RID: 167 RVA: 0x00004AE8 File Offset: 0x00002CE8
		public static string Read(string path)
		{
			string result;
			try
			{
				string text = string.Empty;
				using (StreamReader streamReader = new StreamReader(path))
				{
					string str;
					while ((str = streamReader.ReadLine()) != null)
					{
						text += str;
					}
				}
				result = text;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				result = null;
			}
			return result;
		}
	}
}
