using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Threading;
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
        private string CharacterSet { get; set; }
        public MARIACryptography()
        {

        }
        public MARIACryptography(string CharacterSet)
        {
            this.CharacterSet = CharacterSet;
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
        public StatusObject GetPermutations()
        {
            StatusObject SO = new StatusObject();
            DateTime Start = DateTime.Now;
            try
            {
                int[] PermutationArray = new int[10] { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1 };
                int ArrayLength = PermutationArray.Length;
                int FinalIndex = ArrayLength - 1;
                DateTime StartTime = DateTime.Now;
                while (true)
                {
                    PermutationArray[FinalIndex]++;
                    for(int i = FinalIndex; i >= 0; i--)
                    {
                        if(PermutationArray[i] == this.CharacterSet.Length)
                        {
                            PermutationArray[i - 1] = PermutationArray[i - 1] + 1;
                            PermutationArray[i] = 0;
                        }
                    }
                    Console.WriteLine(String.Join(",", PermutationArray.Select(x => x < 0 ? ' ' : this.CharacterSet[x])));
                }
            }
            catch(Exception e)
            {
                SO = new StatusObject(e, "CRYPTOGRAPHY_GETPERMUTATIONS");
            }
            DateTime End = DateTime.Now;
            Console.WriteLine("[Start: {0}] [End: {1}]", Start, End);
            return SO;
        }
        public StatusObject GetPermutations(string StartSequence, string EndSequence)
        {
            StatusObject SO = new StatusObject();
            try
            {
                /*EndSequence must be longer than or equal to StartSequence*/
                bool SequenceValidated = true;
                char[] StartSequenceCharacters = StartSequence.ToCharArray();
                char[] EndSequenceCharacters = EndSequence.ToCharArray();
                string ErrorMessage = "";
                for (int i = 0; i < StartSequenceCharacters.Length; i++)
                {
                    if(this.CharacterSet.IndexOf(StartSequenceCharacters[i]) == -1)
                    {
                        SequenceValidated = false;
                        break;
                    }
                }
                for(int i = 0; i < EndSequenceCharacters.Length; i++)
                {
                    if (this.CharacterSet.IndexOf(EndSequenceCharacters[i]) == -1)
                    {
                        SequenceValidated = false;
                        break;
                    }
                }
                if (EndSequence.Length < StartSequence.Length)
                {
                    SequenceValidated = false;
                }
                else if(EndSequence.Length == StartSequence.Length)
                {
                    /*EndSequence cannot be alphabetically greater than StartSequence*/
                    
                    /*for(int i = 0; i < StartSequenceCharacters.Length; i++)
                    {
                        if (this.CharacterSet.IndexOf(StartSequenceCharacters[i]) > this.CharacterSet.IndexOf(EndSequenceCharacters[i]))
                        {
                            SequenceValidated = false;
                            ErrorMessage = "Alphabetical";
                            break;
                        }
                    }*/
                }
                if (SequenceValidated)
                {
                    // EndSequence is always Greater or Equal to Start Sequence
                    int[] PermutationArray = new int[EndSequence.Length];
                    int LengthDifference = EndSequence.Length - StartSequence.Length;
                    int FinalIndex = EndSequence.Length - 1;
                    for (int i = PermutationArray.Length - 1; i >= 0; i--)
                    {
                        if(StartSequence.Length == EndSequence.Length)
                        {
                            PermutationArray[i] = this.CharacterSet.IndexOf(StartSequence[i]);
                        }
                        else if(EndSequence.Length > StartSequence.Length)
                        {
                            if(i - LengthDifference >= 0)
                            {
                                PermutationArray[i] = this.CharacterSet.IndexOf(StartSequence[i - LengthDifference]);
                            }
                            else
                            {
                                PermutationArray[i] = -1;
                            }
                        }
                    }
                    Console.WriteLine(String.Join("", PermutationArray.Select(x => x < 0 ? ' ' : this.CharacterSet[x])));
                    while (true)
                    {
                        PermutationArray[FinalIndex]++;
                        for (int i = FinalIndex; i >= 0; i--)
                        {
                            if (PermutationArray[i] == this.CharacterSet.Length)
                            {
                                if (i - 1 >= 0)
                                {
                                    PermutationArray[i - 1] = PermutationArray[i - 1] + 1;
                                    PermutationArray[i] = 0;
                                }
                            }
                        }
                        string CurrentString = String.Join("", PermutationArray.Select(x => x < 0 ? ' ' : this.CharacterSet.ElementAtOrDefault(x)));
                        Console.WriteLine(CurrentString);
                        if (CurrentString == EndSequence)
                        {
                            break;
                        }
                    }
                }
                else
                {
                    SO = new StatusObject(new Exception(ErrorMessage), "CRYPTOGRAPHY_GETPERMUTATIONS_INVALIDINPUT");
                }
            }
            catch(Exception e)
            {
                SO = new StatusObject(e, "CRYPTOGRAPHY_GETPERMUTATIONS");
            }
            return SO;
        }
        public StatusObject GetEndSequence(string StartSequence, int Iterations)
        {
            StatusObject SO = new StatusObject();
            try
            {
                List<int?> EndSequence = new List<int?>();
                foreach(char i in StartSequence)
                {
                    EndSequence.Add(this.CharacterSet.IndexOf(i));
                }
                for(int i = 0; i < EndSequence.Count; i++)
                {
                    EndSequence[i] = EndSequence[i] + Iterations;
                    if (EndSequence.ElementAtOrDefault(i + 1) != null)
                    {

                    }
                    else
                    {

                    }
                }
            }
            catch (Exception e)
            {
                SO = new StatusObject(e, "CRYPTOGRAPHY_GETENDSEQUENCE");
            }
            return SO;
        }
    }
}
