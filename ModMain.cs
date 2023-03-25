using System;
using System.Reflection;
using MelonLoader;
using System.Security.Cryptography;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Net;

/// <summary>
/// 当你手动修改了此命名空间，需要去模组编辑器修改对应的新命名空间，程序集也需要修改命名空间，否则DLL将加载失败！！！
/// </summary>
namespace MOD_roUFFu
{
    /// <summary>
    /// 此类是模组的主类
    /// </summary>
    public class ModMain : MelonMod
    {
        private TimerCoroutine corUpdate;
		private static HarmonyLib.Harmony harmony;

        /// <summary>
        /// MOD初始化，进入游戏时会调用此函数
        /// </summary>
        public void Init()
        {
            //使用了Harmony补丁功能的，需要手动启用补丁。
            //启动当前程序集的所有补丁
            if (harmony != null)
			{
				harmony.UnpatchSelf();
				harmony = null;
			}
			if (harmony == null)
			{
				harmony = new HarmonyLib.Harmony("MOD_roUFFu");
			}
			harmony.PatchAll(Assembly.GetExecutingAssembly());

            corUpdate = g.timer.Frame(new Action(OnUpdate), 1, true);
            
            MelonLogger.Msg("Paddi立绘加密认证");
            //认证阶段
            // 从gitee上读取blacklist
            string url = "https://gitee.com/Paddi123/blacklist/raw/master/blacklist.txt"; //blacklist的地址
            WebClient client = new WebClient();
            string blacklist = "";
            //检测黑名单是否加载
            try
            {
                blacklist = client.DownloadString(url);
            }
            catch (WebException ex)
            {
                MelonLogger.Msg("无法链接黑名单服务器：" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            //MessageBox.Show("黑名单用户:" + Environment.NewLine + blacklist);
            string userName = CheckQQClass.GetCurrentUserName().Split('\\')[1];
            string path = $@"C:\Users\{userName}\Documents\Tencent Files";
            if (Directory.Exists(path))
            {
                string[] dirs = Directory.GetDirectories(path);
                foreach (string dir in dirs)
                {
                    string qqNum = Path.GetFileNameWithoutExtension(dir);
                    MelonLogger.Msg(qqNum);
                    //检测blacklist名单
                    if (blacklist.Contains(qqNum))
                    {
                        MelonLogger.Msg("黑名单用户禁止访问");
                        Application.Exit();
                        return;
                    }
                    else
                    {
                        //获取当前mod目录，准备加解密使用
                        string folderPath = g.mod.GetModPathRoot("roUFFu");
                        string password;
                        // 读取ModExportData.cache文件的MD5值作为密码
                        string cacheFilePath = Path.Combine(folderPath, "ModExportData.cache");
                        if (File.Exists(cacheFilePath))
                        {
                            using (var md5 = MD5.Create())
                            {
                                using (var stream = File.OpenRead(cacheFilePath))
                                {
                                    var md5Hash = md5.ComputeHash(stream);
                                    using (var sha512 = SHA512.Create())
                                    {
                                        var combinedHash = md5Hash.Concat(Encoding.UTF8.GetBytes("Paddi"));
                                        var hash = sha512.ComputeHash(combinedHash.ToArray());
                                        password = BitConverter.ToString(hash).Replace("-", "").ToLower();
                                    }
                                }
                            }
                        }
                        else
                        {
                            MelonLogger.Msg("ModExportData.cache文件不存在！");
                            return;
                        }

                        // 遍历目标文件夹及其子文件夹
                        foreach (string encryptedFilePath in Directory.GetFiles(folderPath, "*.Paddi", SearchOption.AllDirectories))
                        {
                            // 判断文件路径是否在 ModAssets 文件夹下
                            if (encryptedFilePath.Contains("\\ModAssets\\"))
                            {
                                string decryptedFilePath = Path.ChangeExtension(encryptedFilePath, ".png");
                                DESFileClass.DecryptFile(encryptedFilePath, decryptedFilePath, password);
                                File.Delete(encryptedFilePath);
                            }
                        }
                    }
                }
            }
            else
            {
                // 没检测到 qq 进行处理
                MelonLogger.Msg("QQ识别错误");
                Application.Exit();
            }
            MelonLogger.Msg(blacklist);
            MelonLogger.Msg(path);
        }

        public static void Msg(String input) 
        {
            //MelonLogger.Msg(input);
        }

        /// <summary>
        /// MOD销毁，回到主界面，会调用此函数并重新初始化MOD
        /// </summary>
        public void Destroy()
        {
            g.timer.Stop(corUpdate);            
        }

        /// <summary>
        /// 每帧调用的函数
        /// </summary>
        private void OnUpdate()
        {
            //获取当前mod目录，准备加解密使用
            string folderPath = g.mod.GetModPathRoot("roUFFu");
            string password;
            //加密代码
            // 读取ModExportData.cache文件的MD5值作为密码
            string cacheFilePath = Path.Combine(folderPath, "ModExportData.cache");
            if (File.Exists(cacheFilePath))
            {
                using (var md5 = MD5.Create())
                {
                    using (var stream = File.OpenRead(cacheFilePath))
                    {
                        var md5Hash = md5.ComputeHash(stream);
                        using (var sha512 = SHA512.Create())
                        {
                            var combinedHash = md5Hash.Concat(Encoding.UTF8.GetBytes("Paddi"));
                            var hash = sha512.ComputeHash(combinedHash.ToArray());
                            password = BitConverter.ToString(hash).Replace("-", "").ToLower();
                        }
                    }
                }
            }
            else
            {
                MelonLogger.Msg("ModExportData.cache文件不存在！");
                return;
            }

            foreach (string filePath in Directory.GetFiles(folderPath, "*.png", SearchOption.AllDirectories))
            {
                // 判断文件路径是否在 ModAssets 文件夹下
                if (filePath.Contains("\\ModAssets\\"))
                {
                    string encryptedFilePath = Path.ChangeExtension(filePath, ".Paddi");
                    DESFileClass.EncryptFile(filePath, encryptedFilePath, password);
                    File.Delete(filePath);
                }
            }

            //MelonLogger.Msg("Paddi正在保护你的立绘！");
        }

        /// <summary>
        /// 异常处理类
        /// </summary>
        public class CryptoHelpException : ApplicationException
        {
            public CryptoHelpException(string msg) : base(msg) { }
        }

        /// <summary>
        /// CryptHelp
        /// </summary>
        public class DESFileClass
        {
            private const ulong FC_TAG = 0xFC010203040506CF;

            private const int BUFFER_SIZE = 128 * 1024;

            /// <summary>
            /// 检验两个Byte数组是否相同
            /// </summary>
            /// <param name="b1">Byte数组</param>
            /// <param name="b2">Byte数组</param>
            /// <returns>true－相等</returns>
            private static bool CheckByteArrays(byte[] b1, byte[] b2)
            {
                if (b1.Length == b2.Length)
                {
                    for (int i = 0; i < b1.Length; ++i)
                    {
                        if (b1[i] != b2[i])
                            return false;
                    }
                    return true;
                }
                return false;
            }

            /// <summary>
            /// 创建DebugLZQ ,http://www.cnblogs.com/DebugLZQ
            /// </summary>
            /// <param name="password">密码</param>
            /// <param name="salt"></param>
            /// <returns>加密对象</returns>
            private static SymmetricAlgorithm CreateRijndael(string password, byte[] salt)
            {
                PasswordDeriveBytes pdb = new PasswordDeriveBytes(password, salt, "SHA256", 1000);

                SymmetricAlgorithm sma = Rijndael.Create();
                sma.KeySize = 256;
                sma.Key = pdb.GetBytes(32);
                sma.Padding = PaddingMode.PKCS7;
                return sma;
            }

            /// <summary>
            /// 加密文件随机数生成
            /// </summary>
            private static RandomNumberGenerator rand = new RNGCryptoServiceProvider();

            /// <summary>
            /// 生成指定长度的随机Byte数组
            /// </summary>
            /// <param name="count">Byte数组长度</param>
            /// <returns>随机Byte数组</returns>
            private static byte[] GenerateRandomBytes(int count)
            {
                byte[] bytes = new byte[count];
                rand.GetBytes(bytes);
                return bytes;
            }

            /// <summary>
            /// 加密文件
            /// </summary>
            /// <param name="inFile">待加密文件</param>
            /// <param name="outFile">加密后输入文件</param>
            /// <param name="password">加密密码</param>
            public static void EncryptFile(string inFile, string outFile, string password)
            {
                using (FileStream fin = File.OpenRead(inFile),
                    fout = File.OpenWrite(outFile))
                {
                    long lSize = fin.Length; // 输入文件长度
                    int size = (int)lSize;
                    byte[] bytes = new byte[BUFFER_SIZE]; // 缓存
                    int read = -1; // 输入文件读取数量
                    int value = 0;

                    // 获取IV和salt
                    byte[] IV = GenerateRandomBytes(16);
                    byte[] salt = GenerateRandomBytes(16);

                    // 创建加密对象
                    SymmetricAlgorithm sma = DESFileClass.CreateRijndael(password, salt);
                    sma.IV = IV;

                    // 在输出文件开始部分写入IV和salt
                    fout.Write(IV, 0, IV.Length);
                    fout.Write(salt, 0, salt.Length);

                    // 创建散列加密
                    HashAlgorithm hasher = SHA256.Create();
                    using (CryptoStream cout = new CryptoStream(fout, sma.CreateEncryptor(), CryptoStreamMode.Write),
                        chash = new CryptoStream(Stream.Null, hasher, CryptoStreamMode.Write))
                    {
                        BinaryWriter bw = new BinaryWriter(cout);
                        bw.Write(lSize);

                        bw.Write(FC_TAG);

                        // 读写字节块到加密流缓冲区
                        while ((read = fin.Read(bytes, 0, bytes.Length)) != 0)
                        {
                            cout.Write(bytes, 0, read);
                            chash.Write(bytes, 0, read);
                            value += read;
                        }
                        // 关闭加密流
                        chash.Flush();
                        chash.Close();

                        // 读取散列
                        byte[] hash = hasher.Hash;

                        // 输入文件写入散列
                        cout.Write(hash, 0, hash.Length);

                        // 关闭文件流
                        cout.Flush();
                        cout.Close();
                    }
                }
            }

            /// <summary>
            /// 解密文件
            /// </summary>
            /// <param name="inFile">待解密文件</param>
            /// <param name="outFile">解密后输出文件</param>
            /// <param name="password">解密密码</param>
            public static void DecryptFile(string inFile, string outFile, string password)
            {
                // 创建打开文件流
                using (FileStream fin = File.OpenRead(inFile),
                    fout = File.OpenWrite(outFile))
                {
                    int size = (int)fin.Length;
                    byte[] bytes = new byte[BUFFER_SIZE];
                    int read = -1;
                    int value = 0;
                    int outValue = 0;

                    byte[] IV = new byte[16];
                    fin.Read(IV, 0, 16);
                    byte[] salt = new byte[16];
                    fin.Read(salt, 0, 16);

                    SymmetricAlgorithm sma = DESFileClass.CreateRijndael(password, salt);
                    sma.IV = IV;

                    value = 32;
                    long lSize = -1;

                    // 创建散列对象, 校验文件
                    HashAlgorithm hasher = SHA256.Create();

                    using (CryptoStream cin = new CryptoStream(fin, sma.CreateDecryptor(), CryptoStreamMode.Read),
                        chash = new CryptoStream(Stream.Null, hasher, CryptoStreamMode.Write))
                    {
                        // 读取文件长度
                        BinaryReader br = new BinaryReader(cin);
                        lSize = br.ReadInt64();
                        ulong tag = br.ReadUInt64();

                        //if (FC_TAG != tag)
                        //throw new CryptoHelpException("文件被破坏");

                        long numReads = lSize / BUFFER_SIZE;

                        long slack = (long)lSize % BUFFER_SIZE;

                        for (int i = 0; i < numReads; ++i)
                        {
                            read = cin.Read(bytes, 0, bytes.Length);
                            fout.Write(bytes, 0, read);
                            chash.Write(bytes, 0, read);
                            value += read;
                            outValue += read;
                        }

                        if (slack > 0)
                        {
                            read = cin.Read(bytes, 0, (int)slack);
                            fout.Write(bytes, 0, read);
                            chash.Write(bytes, 0, read);
                            value += read;
                            outValue += read;
                        }

                        chash.Flush();
                        chash.Close();

                        fout.Flush();
                        fout.Close();

                        byte[] curHash = hasher.Hash;

                        // 获取比较和旧的散列对象
                        byte[] oldHash = new byte[hasher.HashSize / 8];
                        read = cin.Read(oldHash, 0, oldHash.Length);
                        //if ((oldHash.Length != read) || (!CheckByteArrays(oldHash, curHash)))
                        //   throw new CryptoHelpException("文件被破坏");
                    }

                    //if (outValue != lSize)
                    //    throw new CryptoHelpException("文件大小不匹配");
                }
            }
        }
        public class CheckQQClass
        {
            [DllImport("Wtsapi32.dll")]
            protected static extern void WTSFreeMemory(IntPtr pointer);

            [DllImport("Wtsapi32.dll")]
            protected static extern bool WTSQuerySessionInformation(IntPtr hServer, int sessionId, WTSInfoClass wtsInfoClass, out IntPtr ppBuffer, out uint pBytesReturned);

            /// <summary>
            /// 获取当前登录用户(可用于管理员身份运行)
            /// </summary>
            /// <returns></returns>
            public static string GetCurrentUserName()
            {
                IntPtr buffer;
                uint strLen;
                int cur_session = -1;
                var username = "SYSTEM"; // assume SYSTEM as this will return "\0" below
                if (WTSQuerySessionInformation(IntPtr.Zero, cur_session, WTSInfoClass.WTSUserName, out buffer, out strLen) && strLen > 1)
                {
                    username = Marshal.PtrToStringAnsi(buffer); // don't need length as these are null terminated strings
                    WTSFreeMemory(buffer);
                    if (WTSQuerySessionInformation(IntPtr.Zero, cur_session, WTSInfoClass.WTSDomainName, out buffer, out strLen) && strLen > 1)
                    {
                        username = Marshal.PtrToStringAnsi(buffer) + "\\" + username; // prepend domain name
                        WTSFreeMemory(buffer);
                    }
                }
                return username;
            }

            public enum WTSInfoClass
            {
                WTSInitialProgram,
                WTSApplicationName,
                WTSWorkingDirectory,
                WTSOEMId,
                WTSSessionId,
                WTSUserName,
                WTSWinStationName,
                WTSDomainName,
                WTSConnectState,
                WTSClientBuildNumber,
                WTSClientName,
                WTSClientDirectory,
                WTSClientProductId,
                WTSClientHardwareId,
                WTSClientAddress,
                WTSClientDisplay,
                WTSClientProtocolType,
                WTSIdleTime,
                WTSLogonTime,
                WTSIncomingBytes,
                WTSOutgoingBytes,
                WTSIncomingFrames,
                WTSOutgoingFrames,
                WTSClientInfo,
                WTSSessionInfo
            }
        }
    }
}
