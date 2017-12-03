using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
namespace MARIA
{
    public enum HashAlgorithm
    {
        MD5,
        SHA1,
        SHA256,
        SHA512
    }
    public class MARIACryptography
    {
        public MARIACryptography()
        {

        }
        public string GetHash(HashAlgorithm HashType, string Input)
        {
            string HashedString = null;
            try
            {
                MD5 MD5Hasher = MD5.Create();
                SHA1 SHA1Hasher = SHA1.Create();
                SHA256 SHA256Hasher = SHA256.Create();
                SHA512 SHA512Hasher = SHA512.Create();
                byte[] InputBytes = Encoding.ASCII.GetBytes(Input);
                if(HashType == HashAlgorithm.MD5)
                {
                    byte[] OutputBytes = MD5Hasher.ComputeHash(InputBytes);
                    HashedString = String.Join("", OutputBytes.Select(x => x.ToString("x2").ToUpper()));
                }
                else if (HashType == HashAlgorithm.SHA1)
                {
                    byte[] OutputBytes = SHA1Hasher.ComputeHash(InputBytes);
                    HashedString = String.Join("", OutputBytes.Select(x => x.ToString("x2").ToUpper()));
                }
                else if(HashType == HashAlgorithm.SHA256)
                {
                    byte[] OutputBytes = SHA256Hasher.ComputeHash(InputBytes);
                    HashedString = String.Join("", OutputBytes.Select(x => x.ToString("x2").ToUpper()));
                }
                else if(HashType == HashAlgorithm.SHA512)
                {
                    byte[] OutputBytes = SHA512Hasher.ComputeHash(InputBytes);
                    HashedString = String.Join("", OutputBytes.Select(x => x.ToString("x2").ToUpper()));
                }
                else
                {
                    return null;
                }
            }
            catch(Exception e)
            {
                HashedString = null;
            }
            return HashedString;
        }
    }
}
