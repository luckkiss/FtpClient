using System;
using System.IO;
using System.Security.Cryptography;

namespace Common
{
    public class HashHelper
    {
        public static string GetHash(string filePath)
        {
            using (HashAlgorithm hash = HashAlgorithm.Create())
            {
                using (FileStream file = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    byte[] hashByte = hash.ComputeHash(file);//哈希算法根据文本得到哈希码的字节数组                   
                    return BitConverter.ToString(hashByte).Replace("-", "");//将字节数组装换为字符串                    
                }
            }
        }
    }
}
