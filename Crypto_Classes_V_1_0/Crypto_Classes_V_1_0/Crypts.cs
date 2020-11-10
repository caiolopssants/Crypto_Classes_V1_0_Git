using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;
using System.Windows;


namespace Crypto_Classes_Library
{
    public static class Crypto_SHA512
    {

        public static byte[] ComputeHashToByte(string text)
        {
            try
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    foreach (char element in text) { memoryStream.WriteByte(Convert.ToByte(element)); }
                    memoryStream.Position = 0;
                    byte[] hash = new SHA512Managed().ComputeHash(memoryStream);
                    memoryStream.Dispose();
                    return hash;
                }
            }
            catch //(Exception error)
            {
                //throw new Exception($"Cryptography process error.\n\n*Error: {error.Message}");
                return new byte[] { };
            }
        }

        public static byte[] ComputeHashToByte(IEnumerable<string> enumerableInformations)
        {
            try
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    foreach (string text in enumerableInformations) { foreach (char element in text) { memoryStream.WriteByte(Convert.ToByte(element)); } }
                    memoryStream.Position = 0;
                    byte[] hash = new SHA512Managed().ComputeHash(memoryStream);
                    memoryStream.Dispose();
                    return hash;
                }
            }
            catch //(Exception error)
            {
                //throw new Exception($"Cryptography process error.\n\n*Error: {error.Message}");
                return new byte[] { };
            }
        }

        public static byte[] ComputeHashToByte(string path, bool detectEncodingFromByteOrderMarks = true)
        {

            try
            {
                string _path_ = $@"{System.Reflection.Assembly.GetExecutingAssembly().Location/*Application.StartupPath*/}\{new Random().Next()}";
                Encoding documentEncoding = null;
                using (StreamReader sR = new StreamReader(path, detectEncodingFromByteOrderMarks)) { documentEncoding = sR.CurrentEncoding; sR.Close(); }
                File.WriteAllLines(_path_, File.ReadAllLines(path, documentEncoding), documentEncoding);
                byte[] answer = new byte[] { };
                using (StreamReader sR = new StreamReader(_path_, documentEncoding)) { answer = new SHA512Managed().ComputeHash(sR.BaseStream); sR.Close(); }
                return answer;
            }
            catch //(Exception error)
            {
                //throw new Exception($"Cryptography process error.\n\n*Error: {error.Message}");
                return new byte[] { };
            }
        }

        public static byte[] ComputeHashToByte(string path, Encoding encoding)
        {
            try
            {
                string _path_ = $@"{System.Reflection.Assembly.GetExecutingAssembly().Location/*Application.StartupPath*/}\{new Random().Next()}";
                File.WriteAllLines(_path_, File.ReadAllLines(path, encoding), encoding);
                byte[] answer = new byte[] { };
                using (StreamReader sR = new StreamReader(_path_, encoding)) { answer = new SHA512Managed().ComputeHash(sR.BaseStream); sR.Close(); }
                return answer;
            }
            catch //(Exception error)
            {
                //throw new Exception($"Cryptography process error.\n\n*Error: {error.Message}");
                return new byte[] { };
            }
        }

        public static byte[] ComputeHashToByte(Stream streamInformations)
        {
            List<byte[]> cI = new List<byte[]>(); //Computed informations
            try
            {
                return new SHA512Managed().ComputeHash(streamInformations);
            }
            catch //(Exception error)
            {
                //throw new Exception($"Cryptography process error.\n\n*Error: {error.Message}");
                return new byte[] { };
            }
        }

        public static List<byte[]> ComputeHashToByte(IEnumerable<Stream> enumerableStreamInformations)
        {
            List<byte[]> cI = new List<byte[]>(); //Computed informations
            try
            {
                foreach (var x in enumerableStreamInformations)
                {
                    cI.Add(new SHA512Managed().ComputeHash(x));
                }

                return cI;
            }
            catch //(Exception error)
            {
                //throw new Exception($"Cryptography process error.\n\n*Error: {error.Message}");
                return new List<byte[]>();
            }
        }



        public static string ComputeHashToString(string text, char splitTerm)
        {
            try
            {
                string answer = string.Empty;
                using (MemoryStream memoStream = new MemoryStream(text.Length))
                {
                    foreach (char element in text) { memoStream.WriteByte(Convert.ToByte(element)); }
                    memoStream.Position = 0;
                    byte[] hash = new SHA512Managed().ComputeHash(memoStream);
                    int count = -1, maxCount = hash.Count();
                    foreach (var x in hash)
                    {
                        count++; answer += x;
                        if (count < maxCount - 1) { answer += splitTerm; }
                    }
                    memoStream.Dispose();
                }
                return answer;
            }
            catch //(Exception error)
            {
                //throw new Exception($"Cryptography process error.\n\n*Error: {error.Message}");
                return string.Empty;
            }
        }

        public static string ComputeHashToString(IEnumerable<string> enumerableInformations)
        {
            try
            {
                string answer = string.Empty;
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    foreach (string text in enumerableInformations) { foreach (char element in text) { memoryStream.WriteByte(Convert.ToByte(element)); } }
                    memoryStream.Position = 0;
                    byte[] hash = new SHA512Managed().ComputeHash(memoryStream);
                    int count = -1, maxCount = hash.Count();
                    foreach (var x in hash)
                    {
                        count++; answer += x;
                        if (count < maxCount - 1) { answer += "."; }
                    }
                    memoryStream.Dispose();
                }
                return answer;
            }
            catch //(Exception error)
            {
                //throw new Exception($"Cryptography process error.\n\n*Error: {error.Message}");
                return string.Empty;
            }
        }

        public static string ComputeHashToString(string path, bool detectEncodingFromByteOrderMarks = true)
        {

            try
            {
                string _path_ = $@"{System.Reflection.Assembly.GetExecutingAssembly().Location/*Application.StartupPath*/}\{new Random().Next()}";
                Encoding documentEncoding = null;
                using (StreamReader sR = new StreamReader(path, detectEncodingFromByteOrderMarks)) { documentEncoding = sR.CurrentEncoding; sR.Close(); }
                File.WriteAllLines(_path_, File.ReadAllLines(path, documentEncoding), documentEncoding);
                string answer = string.Empty;
                using (StreamReader sR = new StreamReader(_path_, documentEncoding)) { foreach (var x in new SHA512Managed().ComputeHash(sR.BaseStream)) { answer += x; } sR.Close(); }
                return answer;
            }
            catch //(Exception error)
            {
                //throw new Exception($"Cryptography process error.\n\n*Error: {error.Message}");
                return string.Empty;
            }

        }

        public static string ComputeHashToString(string path, Encoding encoding)
        {
            try
            {
                string _path_ = $@"{System.Reflection.Assembly.GetExecutingAssembly().Location/*Application.StartupPath*/}\{new Random().Next()}";
                File.WriteAllLines(_path_, File.ReadAllLines(path, encoding), encoding);
                string answer = string.Empty;
                using (StreamReader sR = new StreamReader(_path_, encoding)) { foreach (var x in new SHA512Managed().ComputeHash(sR.BaseStream)) { answer += x; } sR.Close(); }
                return answer;
            }
            catch //(Exception error)
            {
                //throw new Exception($"Cryptography process error.\n\n*Error: {error.Message}");
                return string.Empty;
            }
        }

        public static string ComputeHashToString(Stream streamInformations)
        {
            try
            {
                string answer = string.Empty;
                foreach (var x in new SHA512Managed().ComputeHash(streamInformations)) { answer += x; }
                return answer;

            }
            catch //(Exception error)
            {
                //throw new Exception($"Cryptography process error.\n\n*Error: {error.Message}");
                return string.Empty;
            }
        }

        public static List<string> ComputeHashToString(IEnumerable<Stream> enumerableStreamInformations)
        {
            List<string> cI = new List<string>(); //Computed informations
            try
            {
                foreach (var x in enumerableStreamInformations)
                {
                    string answer = string.Empty;
                    foreach (var y in new SHA512Managed().ComputeHash(x)) { answer += y; }
                    cI.Add(answer);
                }

                return cI;
            }
            catch //(Exception error)
            {
                //throw new Exception($"Cryptography process error.\n\n*Error: {error.Message}");
                return new List<string>();
            }
        }
    }

    public static class Crypto_SHA384
    {

        public static byte[] ComputeHashToByte(string text)
        {
            try
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    foreach (char element in text) { memoryStream.WriteByte(Convert.ToByte(element)); }
                    memoryStream.Position = 0;
                    byte[] hash = new SHA384Managed().ComputeHash(memoryStream);
                    memoryStream.Dispose();
                    return hash;
                }
            }
            catch //(Exception error)
            {
                //throw new Exception($"Cryptography process error.\n\n*Error: {error.Message}");
                return new byte[] { };
            }
        }

        public static byte[] ComputeHashToByte(IEnumerable<string> enumerableInformations)
        {
            try
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {

                    foreach (string text in enumerableInformations) { foreach (char element in text) { memoryStream.WriteByte(Convert.ToByte(element)); } }
                    memoryStream.Position = 0;
                    byte[] hash = new SHA384Managed().ComputeHash(memoryStream);
                    memoryStream.Dispose();
                    return hash;
                }
            }
            catch //(Exception error)
            {
                //throw new Exception($"Cryptography process error.\n\n*Error: {error.Message}");
                return new byte[] { };
            }
        }

        public static byte[] ComputeHashToByte(string path, bool detectEncodingFromByteOrderMarks = true)
        {

            try
            {
                string _path_ = $@"{System.Reflection.Assembly.GetExecutingAssembly().Location/*Application.StartupPath*/}\{new Random().Next()}";
                Encoding documentEncoding = null;
                using (StreamReader sR = new StreamReader(path, detectEncodingFromByteOrderMarks)) { documentEncoding = sR.CurrentEncoding; sR.Close(); }
                File.WriteAllLines(_path_, File.ReadAllLines(path, documentEncoding), documentEncoding);
                byte[] answer = new byte[] { };
                using (StreamReader sR = new StreamReader(_path_, documentEncoding)) { answer = new SHA384Managed().ComputeHash(sR.BaseStream); sR.Close(); }
                return answer;
            }
            catch //(Exception error)
            {
                //throw new Exception($"Cryptography process error.\n\n*Error: {error.Message}");
                return new byte[] { };
            }
        }

        public static byte[] ComputeHashToByte(string path, Encoding encoding)
        {
            try
            {
                string _path_ = $@"{System.Reflection.Assembly.GetExecutingAssembly().Location/*Application.StartupPath*/}\{new Random().Next()}";
                File.WriteAllLines(_path_, File.ReadAllLines(path, encoding), encoding);
                byte[] answer = new byte[] { };
                using (StreamReader sR = new StreamReader(_path_, encoding)) { answer = new SHA384Managed().ComputeHash(sR.BaseStream); sR.Close(); }
                return answer;
            }
            catch //(Exception error)
            {
                //throw new Exception($"Cryptography process error.\n\n*Error: {error.Message}");
                return new byte[] { };
            }
        }

        public static byte[] ComputeHashToByte(Stream streamInformations)
        {
            List<byte[]> cI = new List<byte[]>(); //Computed informations
            try
            {
                return new SHA384Managed().ComputeHash(streamInformations);
            }
            catch //(Exception error)
            {
                //throw new Exception($"Cryptography process error.\n\n*Error: {error.Message}");
                return new byte[] { };
            }
        }

        public static List<byte[]> ComputeHashToByte(IEnumerable<Stream> enumerableStreamInformations)
        {
            List<byte[]> cI = new List<byte[]>(); //Computed informations
            try
            {
                foreach (var x in enumerableStreamInformations)
                {
                    cI.Add(new SHA384Managed().ComputeHash(x));
                }

                return cI;
            }
            catch //(Exception error)
            {
                //throw new Exception($"Cryptography process error.\n\n*Error: {error.Message}");
                return new List<byte[]>();
            }
        }



        public static string ComputeHashToString(string text)
        {
            try
            {
                string answer = string.Empty;
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    foreach (char element in text) { memoryStream.WriteByte(Convert.ToByte(element)); }
                    memoryStream.Position = 0;
                    byte[] hash = new SHA384Managed().ComputeHash(memoryStream);
                    int count = -1, maxCount = hash.Count();
                    foreach (var x in hash)
                    {
                        count++; answer += x;
                        if (count < maxCount - 1) { answer += "."; }
                    }
                    memoryStream.Dispose();
                }
                return answer;
            }
            catch //(Exception error)
            {
                //throw new Exception($"Cryptography process error.\n\n*Error: {error.Message}");
                return string.Empty;
            }
        }

        public static string ComputeHashToString(IEnumerable<string> enumerableInformations)
        {
            try
            {
                string answer = string.Empty;
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    foreach (string text in enumerableInformations) { foreach (char element in text) { memoryStream.WriteByte(Convert.ToByte(element)); } }
                    memoryStream.Position = 0;
                    byte[] hash = new SHA384Managed().ComputeHash(memoryStream);
                    int count = -1, maxCount = hash.Count();
                    foreach (var x in hash)
                    {
                        count++; answer += x;
                        if (count < maxCount - 1) { answer += "."; }
                    }
                    memoryStream.Dispose();
                }
                return answer;
            }
            catch //(Exception error)
            {
                //throw new Exception($"Cryptography process error.\n\n*Error: {error.Message}");
                return string.Empty;
            }
        }

        public static string ComputeHashToString(string path, bool detectEncodingFromByteOrderMarks = true)
        {

            try
            {
                string _path_ = $@"{System.Reflection.Assembly.GetExecutingAssembly().Location/*Application.StartupPath*/}\{new Random().Next()}";
                Encoding documentEncoding = null;
                using (StreamReader sR = new StreamReader(path, detectEncodingFromByteOrderMarks)) { documentEncoding = sR.CurrentEncoding; sR.Close(); }
                File.WriteAllLines(_path_, File.ReadAllLines(path, documentEncoding), documentEncoding);
                string answer = string.Empty;
                using (StreamReader sR = new StreamReader(_path_, documentEncoding)) { foreach (var x in new SHA384Managed().ComputeHash(sR.BaseStream)) { answer += x; } sR.Close(); }
                return answer;
            }
            catch //(Exception error)
            {
                //throw new Exception($"Cryptography process error.\n\n*Error: {error.Message}");
                return string.Empty;
            }

        }

        public static string ComputeHashToString(string path, Encoding encoding)
        {
            try
            {
                string _path_ = $@"{System.Reflection.Assembly.GetExecutingAssembly().Location/*Application.StartupPath*/}\{new Random().Next()}";
                File.WriteAllLines(_path_, File.ReadAllLines(path, encoding), encoding);
                string answer = string.Empty;
                using (StreamReader sR = new StreamReader(_path_, encoding)) { foreach (var x in new SHA384Managed().ComputeHash(sR.BaseStream)) { answer += x; } sR.Close(); }
                return answer;
            }
            catch //(Exception error)
            {
                //throw new Exception($"Cryptography process error.\n\n*Error: {error.Message}");
                return string.Empty;
            }
        }

        public static string ComputeHashToString(Stream streamInformations)
        {
            try
            {
                string answer = string.Empty;
                foreach (var x in new SHA384Managed().ComputeHash(streamInformations)) { answer += x; }
                return answer;

            }
            catch //(Exception error)
            {
                //throw new Exception($"Cryptography process error.\n\n*Error: {error.Message}");
                return string.Empty;
            }
        }

        public static List<string> ComputeHashToString(IEnumerable<Stream> enumerableStreamInformations)
        {
            List<string> cI = new List<string>(); //Computed informations
            try
            {
                foreach (var x in enumerableStreamInformations)
                {
                    string answer = string.Empty;
                    foreach (var y in new SHA384Managed().ComputeHash(x)) { answer += y; }
                    cI.Add(answer);
                }

                return cI;
            }
            catch //(Exception error)
            {
                //throw new Exception($"Cryptography process error.\n\n*Error: {error.Message}");
                return new List<string>();
            }
        }
    }

    public static class Crypto_SHA256
    {
        public static byte[] ComputeHashToByte(string text)
        {
            try
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    foreach (char element in text) { memoryStream.WriteByte(Convert.ToByte(element)); }
                    memoryStream.Position = 0;
                    byte[] hash = new SHA256Managed().ComputeHash(memoryStream);
                    memoryStream.Dispose();
                    return hash;
                }
            }
            catch //(Exception error)
            {
                //throw new Exception($"Cryptography process error.\n\n*Error: {error.Message}");
                
                return new byte[] { };
                
            }
        }

        public static byte[] ComputeHashToByte(IEnumerable<string> enumerableInformations)
        {
            try
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    foreach (string text in enumerableInformations) { foreach (char element in text) { memoryStream.WriteByte(Convert.ToByte(element)); } }
                    memoryStream.Position = 0;
                    byte[] hash = new SHA256Managed().ComputeHash(memoryStream);
                    memoryStream.Dispose();
                    return hash;
                }
            }
            catch //(Exception error)
            {
                //throw new Exception($"Cryptography process error.\n\n*Error: {error.Message}");
                
                return new byte[] { };
                
            }
        }

        public static byte[] ComputeHashToByte(string path, bool detectEncodingFromByteOrderMarks = true)
        {

            try
            {
                string _path_ = $@"{System.Reflection.Assembly.GetExecutingAssembly().Location/*Application.StartupPath*/}\{new Random().Next()}";
                Encoding documentEncoding = null;
                using (StreamReader sR = new StreamReader(path, detectEncodingFromByteOrderMarks)) { documentEncoding = sR.CurrentEncoding; sR.Close(); }
                File.WriteAllLines(_path_, File.ReadAllLines(path, documentEncoding), documentEncoding);
                byte[] answer = new byte[] { };
                using (StreamReader sR = new StreamReader(_path_, documentEncoding)) { answer = new SHA256Managed().ComputeHash(sR.BaseStream); sR.Close(); }
                return answer;
            }
            catch //(Exception error)
            {
                //throw new Exception($"Cryptography process error.\n\n*Error: {error.Message}");
                return new byte[] { };
            }
        }

        public static byte[] ComputeHashToByte(string path, Encoding encoding)
        {
            try
            {
                string _path_ = $@"{System.Reflection.Assembly.GetExecutingAssembly().Location/*Application.StartupPath*/}\{new Random().Next()}";
                File.WriteAllLines(_path_, File.ReadAllLines(path, encoding), encoding);
                byte[] answer = new byte[] { };
                using (StreamReader sR = new StreamReader(_path_, encoding)) { answer = new SHA256Managed().ComputeHash(sR.BaseStream); sR.Close(); }
                return answer;
            }
            catch //(Exception error)
            {
                //throw new Exception($"Cryptography process error.\n\n*Error: {error.Message}");
                return new byte[] { };
            }
        }

        public static byte[] ComputeHashToByte(Stream streamInformations)
        {
            List<byte[]> cI = new List<byte[]>(); //Computed informations
            try
            {
                return new SHA256Managed().ComputeHash(streamInformations);
            }
            catch //(Exception error)
            {
                //throw new Exception($"Cryptography process error.\n\n*Error: {error.Message}");
                return new byte[] { };
            }
        }

        public static List<byte[]> ComputeHashToByte(IEnumerable<Stream> enumerableStreamInformations)
        {
            List<byte[]> cI = new List<byte[]>(); //Computed informations
            try
            {
                foreach (var x in enumerableStreamInformations)
                {
                    cI.Add(new SHA256Managed().ComputeHash(x));
                }

                return cI;
            }
            catch //(Exception error)
            {
                //throw new Exception($"Cryptography process error.\n\n*Error: {error.Message}");
                return new List<byte[]>();
            }
        }



        public static string ComputeHashToString(string text)
        {
            try
            {
                string answer = string.Empty;
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    foreach (char element in text) { memoryStream.WriteByte(Convert.ToByte(element)); }
                    memoryStream.Position = 0;
                    byte[] hash = new SHA256Managed().ComputeHash(memoryStream);
                    int count = -1, maxCount = hash.Count();
                    foreach (var x in hash)
                    {
                        count++; answer += x;
                        if (count < maxCount - 1) { answer += "."; }
                    }
                    memoryStream.Dispose();
                }
                return answer;
            }
            catch //(Exception error)
            {
                //throw new Exception($"Cryptography process error.\n\n*Error: {error.Message}");
                return string.Empty;
            }
        }

        public static string ComputeHashToString(IEnumerable<string> enumerableInformations)
        {
            try
            {
                string answer = string.Empty;
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    foreach (string text in enumerableInformations) { foreach (char element in text) { memoryStream.WriteByte(Convert.ToByte(element)); } }
                    memoryStream.Position = 0;
                    byte[] hash = new SHA256Managed().ComputeHash(memoryStream);
                    int count = -1, maxCount = hash.Count();
                    foreach (var x in hash)
                    {
                        count++; answer += x;
                        if (count < maxCount - 1) { answer += "."; }
                    }
                    memoryStream.Dispose();
                }
                return answer;
            }
            catch //(Exception error)
            {
                //throw new Exception($"Cryptography process error.\n\n*Error: {error.Message}");
                return string.Empty;
            }
        }

        public static string ComputeHashToString(string path, bool detectEncodingFromByteOrderMarks = true)
        {

            try
            {
                string _path_ = $@"{System.Reflection.Assembly.GetExecutingAssembly().Location/*Application.StartupPath*/}\{new Random().Next()}";
                Encoding documentEncoding = null;
                using (StreamReader sR = new StreamReader(path, detectEncodingFromByteOrderMarks)) { documentEncoding = sR.CurrentEncoding; sR.Close(); }
                File.WriteAllLines(_path_, File.ReadAllLines(path, documentEncoding), documentEncoding);
                string answer = string.Empty;
                using (StreamReader sR = new StreamReader(_path_, documentEncoding)) { foreach (var x in new SHA256Managed().ComputeHash(sR.BaseStream)) { answer += x; } sR.Close(); }
                return answer;
            }
            catch //(Exception error)
            {
                //throw new Exception($"Cryptography process error.\n\n*Error: {error.Message}");
                return string.Empty;
            }

        }

        public static string ComputeHashToString(string path, Encoding encoding)
        {
            try
            {
                string _path_ = $@"{System.Reflection.Assembly.GetExecutingAssembly().Location/*Application.StartupPath*/}\{new Random().Next()}";
                File.WriteAllLines(_path_, File.ReadAllLines(path, encoding), encoding);
                string answer = string.Empty;
                using (StreamReader sR = new StreamReader(_path_, encoding)) { foreach (var x in new SHA256Managed().ComputeHash(sR.BaseStream)) { answer += x; } sR.Close(); }
                return answer;
            }
            catch //(Exception error)
            {
                //throw new Exception($"Cryptography process error.\n\n*Error: {error.Message}");
                return string.Empty;
            }
        }

        public static string ComputeHashToString(Stream streamInformations)
        {
            try
            {
                string answer = string.Empty;
                foreach (var x in new SHA256Managed().ComputeHash(streamInformations)) { answer += x; }
                return answer;

            }
            catch //(Exception error)
            {
                //throw new Exception($"Cryptography process error.\n\n*Error: {error.Message}");
                return string.Empty;
            }
        }

        public static List<string> ComputeHashToString(IEnumerable<Stream> enumerableStreamInformations)
        {
            List<string> cI = new List<string>(); //Computed informations
            try
            {
                foreach (var x in enumerableStreamInformations)
                {
                    string answer = string.Empty;
                    foreach (var y in new SHA256Managed().ComputeHash(x)) { answer += y; }
                    cI.Add(answer);
                }

                return cI;
            }
            catch //(Exception error)
            {
                //throw new Exception($"Cryptography process error.\n\n*Error: {error.Message}");
                return new List<string>();
            }
        }

    }

    public static class Crypto_AES
    {
        /// <summary>
        /// Generate a byte array for secret key and initialization vector.
        /// </summary>        
        /// <returns></returns>
        public static Tuple<byte[], byte[]> Generate_Key_IV()
        {
            Aes aes = Aes.Create();
            return new Tuple<byte[], byte[]>(aes.Key, aes.IV);
        }



        public static byte[] EncryptToByte(Stream document, byte[] secretKey, byte[] initializationVector)
        {
            try
            {
                Aes aes = Aes.Create();
                aes.Key = secretKey;
                aes.IV = initializationVector;

                var encrypt = aes.CreateEncryptor(secretKey, initializationVector);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encrypt, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            //Write all data to the stream.
                            using (StreamReader sR = new StreamReader(document, true))
                            {
                                swEncrypt.Write(sR.ReadToEnd());
                            }
                        }
                        return msEncrypt.ToArray();
                    }
                }
            }
            catch //(Exception error)
            {
                //throw new Exception($"Cryptography process error.\n\n*Error: {error.Message}");
                return new byte[] { };
            }
        }

        public static byte[] EncryptToByte(string text, byte[] secretKey, byte[] initializationVector)
        {
            try
            {
                Aes aes = Aes.Create();
                aes.Key = secretKey;
                aes.IV = initializationVector;
                var encrypt = aes.CreateEncryptor(secretKey, initializationVector);
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encrypt, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            //Write all data to the stream.          
                            swEncrypt.Write(text);
                        }
                        return msEncrypt.ToArray();
                    }
                }
            }
            catch //(Exception error)
            {
                //throw new Exception($"Cryptography process error.\n\n*Error: {error.Message}");
                return new byte[] { };
            }
        }

        public static byte[] EncryptToByte(string path, byte[] secretKey, byte[] initializationVector, bool detectEncodingFromByteOrderMarks = true)
        {

            try
            {
                Aes aes = Aes.Create();
                aes.Key = secretKey;
                aes.IV = initializationVector;

                var encrypt = aes.CreateEncryptor(secretKey, initializationVector);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encrypt, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            StreamReader sR = new StreamReader(path, detectEncodingFromByteOrderMarks);
                            string text = sR.ReadToEnd();
                            sR.Close();
                            //Write all data to the stream.                        
                            swEncrypt.Write(text);
                        }
                        return msEncrypt.ToArray();
                    }
                }
            }
            catch //(Exception error)
            {
                //throw new Exception($"Cryptography process error.\n\n*Error: {error.Message}");
                return new byte[] { };
            }
        }

        public static byte[] EncryptToByte(string path, byte[] secretKey, byte[] initializationVector, Encoding encoding)
        {
            try
            {
                Aes aes = Aes.Create();
                aes.Key = secretKey;
                aes.IV = initializationVector;

                var encrypt = aes.CreateEncryptor(secretKey, initializationVector);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encrypt, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            StreamReader sR = new StreamReader(path, encoding);
                            string text = sR.ReadToEnd();
                            sR.Close();
                            //Write all data to the stream.                        
                            swEncrypt.Write(text);
                        }
                        return msEncrypt.ToArray();
                    }
                }
            }
            catch //(Exception error)
            {
                //throw new Exception($"Cryptography process error.\n\n*Error: {error.Message}");
                return new byte[] { };
            }
        }

        public static byte[] EncryptToByte(IEnumerable<string> enumerableInformations, byte[] secretKey, byte[] initializationVector, Encoding encoding)
        {

            try
            {

                byte[] answer = new byte[] { };



                Aes aes = Aes.Create();
                aes.Key = secretKey;
                aes.IV = initializationVector;

                var encrypt = aes.CreateEncryptor(secretKey, initializationVector);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encrypt, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            string text = string.Empty;
                            int forCount = -1, iEnumCount = enumerableInformations.Count();
                            foreach (var x in enumerableInformations) { forCount++; text += x; if (forCount < iEnumCount) { text += "\n"; } }
                            //Write all data to the stream.                        
                            swEncrypt.Write(text);
                        }
                        return msEncrypt.ToArray();
                    }
                }
            }
            catch //(Exception error)
            {
                //throw new Exception($"Cryptography process error.\n\n*Error: {error.Message}");
                return new byte[] { };
            }
        }

        public static List<byte[]> EncryptToByte(IEnumerable<Stream> enumerableStreamInformations, byte[] secretKey, byte[] initializationVector)
        {
            List<byte[]> cI = new List<byte[]>(); //Computed informations
            try
            {
                Aes aes = Aes.Create();
                aes.Key = secretKey;
                aes.IV = initializationVector;

                var encrypt = aes.CreateEncryptor(secretKey, initializationVector);
                foreach (var x in enumerableStreamInformations)
                {

                    using (MemoryStream msEncrypt = new MemoryStream())
                    {
                        using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encrypt, CryptoStreamMode.Write))
                        {
                            using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                            {
                                //Write all data to the stream.
                                using (StreamReader sR = new StreamReader(x, true))
                                {
                                    swEncrypt.Write(sR.ReadToEnd());
                                }
                            }
                            cI.Add(msEncrypt.ToArray());
                        }
                    }
                }

                return cI;
            }
            catch //(Exception error)
            {
                //throw new Exception($"Cryptography process error.\n\n*Error: {error.Message}");
                return new List<byte[]>();
            }
        }




        public static string[] EncryptToStringArrayByte(Stream document, byte[] secretKey, byte[] initializationVector)
        {
            try
            {
                Aes aes = Aes.Create();
                aes.Key = secretKey;
                aes.IV = initializationVector;

                var encrypt = aes.CreateEncryptor(secretKey, initializationVector);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encrypt, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            //Write all data to the stream.
                            using (StreamReader sR = new StreamReader(document, true))
                            {
                                swEncrypt.Write(sR.ReadToEnd());
                            }
                        }
                        return Crypto_Tools.ConvertToStringArray(msEncrypt.ToArray());
                    }
                }
            }
            catch //(Exception error)
            {
                //throw new Exception($"Cryptography process error.\n\n*Error: {error.Message}");
                return new string[] { };
            }
        }

        public static string[] EncryptToStringArrayByte(string text, byte[] secretKey, byte[] initializationVector)
        {
            try
            {


                Aes aes = Aes.Create();
                aes.Key = secretKey;
                aes.IV = initializationVector;

                var encrypt = aes.CreateEncryptor(secretKey, initializationVector);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encrypt, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            //Write all data to the stream.                        
                            swEncrypt.Write(text);
                        }
                        return Crypto_Tools.ConvertToStringArray(msEncrypt.ToArray());
                    }
                }
            }
            catch //(Exception error)
            {
                //throw new Exception($"Cryptography process error.\n\n*Error: {error.Message}");
                return new string[] { };
            }
        }

        public static string[] EncryptToStringArrayByte(string path, byte[] secretKey, byte[] initializationVector, bool detectEncodingFromByteOrderMarks = true)
        {

            try
            {
                Aes aes = Aes.Create();
                aes.Key = secretKey;
                aes.IV = initializationVector;

                var encrypt = aes.CreateEncryptor(secretKey, initializationVector);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encrypt, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            StreamReader sR = new StreamReader(path, detectEncodingFromByteOrderMarks);
                            string text = sR.ReadToEnd();
                            sR.Close();
                            //Write all data to the stream.                        
                            swEncrypt.Write(text);
                        }
                        return Crypto_Tools.ConvertToStringArray(msEncrypt.ToArray());
                    }
                }
            }
            catch //(Exception error)
            {
                //throw new Exception($"Cryptography process error.\n\n*Error: {error.Message}");
                return new string[] { };
            }
        }

        public static string[] EncryptToStringArrayByte(string path, byte[] secretKey, byte[] initializationVector, Encoding encoding)
        {
            try
            {
                Aes aes = Aes.Create();
                aes.Key = secretKey;
                aes.IV = initializationVector;

                var encrypt = aes.CreateEncryptor(secretKey, initializationVector);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encrypt, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            StreamReader sR = new StreamReader(path, encoding);
                            string text = sR.ReadToEnd();
                            sR.Close();
                            //Write all data to the stream.                        
                            swEncrypt.Write(text);
                        }
                        return Crypto_Tools.ConvertToStringArray(msEncrypt.ToArray());
                    }
                }
            }
            catch //(Exception error)
            {
                //throw new Exception($"Cryptography process error.\n\n*Error: {error.Message}");
                return new string[] { };
            }
        }

        public static string[] EncryptToStringArrayByte(IEnumerable<string> enumerableInformations, byte[] secretKey, byte[] initializationVector, Encoding encoding)
        {

            try
            {

                byte[] answer = new byte[] { };



                Aes aes = Aes.Create();
                aes.Key = secretKey;
                aes.IV = initializationVector;

                var encrypt = aes.CreateEncryptor(secretKey, initializationVector);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encrypt, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {

                            string text = string.Empty;
                            int forCount = -1, iEnumCount = enumerableInformations.Count();
                            foreach (var x in enumerableInformations) { forCount++; text += x; if (forCount < iEnumCount) { text += "\n"; } }

                            //Write all data to the stream.                        
                            swEncrypt.Write(text);
                        }
                        return Crypto_Tools.ConvertToStringArray(msEncrypt.ToArray());
                    }
                }
            }
            catch //(Exception error)
            {
                //throw new Exception($"Cryptography process error.\n\n*Error: {error.Message}");
                return new string[] { };
            }
        }

        public static List<string[]> EncryptToStringArrayByte(IEnumerable<Stream> enumerableStreamInformations, byte[] secretKey, byte[] initializationVector)
        {
            List<byte[]> cI = new List<byte[]>(); //Computed informations
            try
            {
                Aes aes = Aes.Create();
                aes.Key = secretKey;
                aes.IV = initializationVector;

                var encrypt = aes.CreateEncryptor(secretKey, initializationVector);
                foreach (var x in enumerableStreamInformations)
                {

                    using (MemoryStream msEncrypt = new MemoryStream())
                    {
                        using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encrypt, CryptoStreamMode.Write))
                        {
                            using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                            {
                                //Write all data to the stream.
                                using (StreamReader sR = new StreamReader(x, true))
                                {
                                    swEncrypt.Write(sR.ReadToEnd());
                                }
                            }
                            cI.Add(msEncrypt.ToArray());
                        }
                    }
                }

                return Crypto_Tools.ConvertToStringArray(cI);
            }
            catch //(Exception error)
            {
                //throw new Exception($"Cryptography process error.\n\n*Error: {error.Message}");
                return new List<string[]>();
            }
        }





        public static string EncryptToString(Stream document, byte[] secretKey, byte[] initializationVector)
        {
            try
            {
                Aes aes = Aes.Create();
                aes.Key = secretKey;
                aes.IV = initializationVector;

                var encrypt = aes.CreateEncryptor(secretKey, initializationVector);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encrypt, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            //Write all data to the stream.
                            using (StreamReader sR = new StreamReader(document, true))
                            {
                                swEncrypt.Write(sR.ReadToEnd());
                            }
                        }

                        byte[] hash = msEncrypt.ToArray();
                        string answer = string.Empty;
                        int count = -1, maxCount = hash.Count(); foreach (var x in hash) { count++; answer += x; if (count < maxCount - 1) { answer += "."; } }
                        return answer;
                    }
                }
            }
            catch //(Exception error)
            {
                //throw new Exception($"Cryptography process error.\n\n*Error: {error.Message}");
                return string.Empty;
            }
        }

        public static string EncryptToString(string text, byte[] secretKey, byte[] initializationVector)
        {
            try
            {
                Aes aes = Aes.Create();
                aes.Key = secretKey;
                aes.IV = initializationVector;

                var encrypt = aes.CreateEncryptor(secretKey, initializationVector);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encrypt, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            //Write all data to the stream.                        
                            swEncrypt.Write(text);
                        }
                        byte[] hash = msEncrypt.ToArray();
                        string answer = string.Empty;
                        int count = -1, maxCount = hash.Count(); foreach (var x in hash) { count++; answer += x; if (count < maxCount - 1) { answer += "."; } }
                        return answer;
                    }
                }
            }
            catch //(Exception error)
            {
                //throw new Exception($"Cryptography process error.\n\n*Error: {error.Message}");
                return string.Empty;
            }
        }

        public static string EncryptToString(string path, byte[] secretKey, byte[] initializationVector, bool detectEncodingFromByteOrderMarks = true)
        {

            try
            {
                Aes aes = Aes.Create();
                aes.Key = secretKey;
                aes.IV = initializationVector;

                var encrypt = aes.CreateEncryptor(secretKey, initializationVector);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encrypt, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            StreamReader sR = new StreamReader(path, detectEncodingFromByteOrderMarks);
                            string text = sR.ReadToEnd();
                            sR.Close();
                            //Write all data to the stream.                        
                            swEncrypt.Write(text);
                        }
                        byte[] hash = msEncrypt.ToArray();
                        string answer = string.Empty;
                        int count = -1, maxCount = hash.Count(); foreach (var x in hash) { count++; answer += x; if (count < maxCount - 1) { answer += "."; } }
                        return answer;
                    }
                }
            }
            catch //(Exception error)
            {
                //throw new Exception($"Cryptography process error.\n\n*Error: {error.Message}");
                return string.Empty;
            }
        }

        public static string EncryptToString(string path, byte[] secretKey, byte[] initializationVector, Encoding encoding)
        {
            try
            {
                Aes aes = Aes.Create();
                aes.Key = secretKey;
                aes.IV = initializationVector;

                var encrypt = aes.CreateEncryptor(secretKey, initializationVector);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encrypt, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            StreamReader sR = new StreamReader(path, encoding);
                            string text = sR.ReadToEnd();
                            sR.Close();
                            //Write all data to the stream.                        
                            swEncrypt.Write(text);
                        }
                        byte[] hash = msEncrypt.ToArray();
                        string answer = string.Empty;
                        int count = -1, maxCount = hash.Count(); foreach (var x in hash) { count++; answer += x; if (count < maxCount - 1) { answer += "."; } }
                        return answer;
                    }
                }
            }
            catch //(Exception error)
            {
                //throw new Exception($"Cryptography process error.\n\n*Error: {error.Message}");
                return string.Empty;
            }
        }

        public static string EncryptToString(IEnumerable<string> enumerableInformations, byte[] secretKey, byte[] initializationVector, Encoding encoding)
        {

            try
            {


                Aes aes = Aes.Create();
                aes.Key = secretKey;
                aes.IV = initializationVector;

                var encrypt = aes.CreateEncryptor(secretKey, initializationVector);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encrypt, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            string text = string.Empty;
                            int forCount = -1, iEnumCount = enumerableInformations.Count();
                            foreach (var x in enumerableInformations) { forCount++; text += x; if (forCount < iEnumCount) { text += "\n"; } }
                            //Write all data to the stream.                        
                            swEncrypt.Write(text);
                        }
                        byte[] hash = msEncrypt.ToArray();
                        string answer = string.Empty;
                        int count = -1, maxCount = hash.Count(); foreach (var x in hash) { count++; answer += x; if (count < maxCount - 1) { answer += "."; } }
                        return answer;
                    }
                }
            }
            catch //(Exception error)
            {
                //throw new Exception($"Cryptography process error.\n\n*Error: {error.Message}");
                return string.Empty;
            }
        }

        public static List<string> EncryptToString(IEnumerable<Stream> enumerableStreamInformations, byte[] secretKey, byte[] initializationVector)
        {
            List<string> cI = new List<string>(); //Computed informations
            try
            {
                Aes aes = Aes.Create();
                aes.Key = secretKey;
                aes.IV = initializationVector;

                var encrypt = aes.CreateEncryptor(secretKey, initializationVector);
                foreach (var x in enumerableStreamInformations)
                {

                    using (MemoryStream msEncrypt = new MemoryStream())
                    {
                        using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encrypt, CryptoStreamMode.Write))
                        {
                            using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                            {
                                //Write all data to the stream.
                                using (StreamReader sR = new StreamReader(x, true))
                                {
                                    swEncrypt.Write(sR.ReadToEnd());
                                }
                            }

                            byte[] hash = msEncrypt.ToArray();
                            string answer = string.Empty;
                            int count = -1, maxCount = hash.Count(); foreach (var y in hash) { count++; answer += y; if (count < maxCount - 1) { answer += "."; } }
                            cI.Add(answer);
                        }
                    }
                }

                return cI;
            }
            catch //(Exception error)
            {
                //throw new Exception($"Cryptography process error.\n\n*Error: {error.Message}");
                return new List<string>();
            }
        }



        public static string Decrypt(byte[] hash, byte[] secretKey, byte[] initializationVector)
        {
            try
            {
                Aes aes = Aes.Create();
                aes.Key = secretKey;
                aes.IV = initializationVector;

                var decrypt = aes.CreateDecryptor(secretKey, initializationVector);

                using (MemoryStream msDecrypt = new MemoryStream(hash))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decrypt, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {

                            // Read the decrypted bytes from the decrypting stream
                            // and place them in a string.
                            return srDecrypt.ReadToEnd();
                        }
                    }
                }


            }
            catch //(Exception error)
            {
                //throw new Exception($"Cryptography process error.\n\n*Error: {error.Message}");
                return string.Empty;
                
            }

        }

        public static string Decrypt(string[] hash, byte[] secretKey, byte[] initializationVector)
        {
            try
            {
                Aes aes = Aes.Create();
                aes.Key = secretKey;
                aes.IV = initializationVector;

                byte[] _hash_ = new byte[hash.Length];
                for (int i = 0; i < hash.Length; i++)
                {
                    _hash_[i] = Convert.ToByte(hash[i]);
                }

                var decrypt = aes.CreateDecryptor(secretKey, initializationVector);

                using (MemoryStream msDecrypt = new MemoryStream(_hash_))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decrypt, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {

                            // Read the decrypted bytes from the decrypting stream
                            // and place them in a string.
                            return srDecrypt.ReadToEnd();
                        }
                    }
                }


            }
            catch //(Exception error)
            {
                //throw new Exception($"Cryptography process error.\n\n*Error: {error.Message}");
                return string.Empty;
            }

        }

        public static List<string> Decrypt(IEnumerable<byte[]> hashs, byte[] secretKey, byte[] initializationVector)
        {
            try
            {
                List<string> dI = new List<string>();//decryptographed information

                Aes aes = Aes.Create();
                aes.Key = secretKey;
                aes.IV = initializationVector;

                var decrypt = aes.CreateDecryptor(secretKey, initializationVector);

                foreach (var hash in hashs)
                {
                    using (MemoryStream msDecrypt = new MemoryStream(hash))
                    {
                        using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decrypt, CryptoStreamMode.Read))
                        {
                            using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                            {

                                // Read the decrypted bytes from the decrypting stream
                                // and place them in a string.
                                dI.Add(srDecrypt.ReadToEnd());
                            }
                        }
                    }
                }
                return dI;


            }
            catch //(Exception error)
            {
                //throw new Exception($"Descryptography process error.\n\n*Error: {error.Message}");
                return new List<string>();

            }
        }
    }

    public static class Crypto_Tools
    {

        /// <summary>
        /// Method to convert a byte array to a string struct (each byte will be converted into a char element)
        /// </summary>
        /// <param name="hash"></param>
        /// <returns></returns>
        public static string ConvertByteArrayToString(byte[] hash)
        {
            string hashString = string.Empty;
            foreach (byte element in hash)
            {
                hashString += Convert.ToChar(element);
            }
            return hashString;
        }//Gera uma string contendo todos os bytes fornecidos pelo parâmetro hash, onde cada valor será convertido para char.

        /// <summary>
        /// Method to convert a byte array to a string struct
        /// </summary>
        /// <param name="hash"></param>
        /// <returns></returns>
        public static string ConvertByteArrayToString(byte[] hash, char spltTerm, bool convertByteToChar = false)
        {
            if (convertByteToChar)
            {
                string hashString = string.Empty;
                bool first = true;
                foreach (byte element in hash)
                {
                    if (first) { hashString += Convert.ToChar(element); first = false; }
                    {
                        hashString += $"{spltTerm}{Convert.ToChar(element)}";
                    }
                }
                return hashString;
            }
            else
            {
                string hashString = string.Empty;
                bool first = true;
                foreach (byte element in hash)
                {
                    if (first) { hashString += $"{element}"; first = false; }
                    {
                        hashString += $"{spltTerm}{element}";
                    }
                }
                return hashString;
            }
        }//Gera um string contendo todos os bytes fornecidos pelo parâmetro hash, sendo que cada valor será convertido em char e separado pelo termo 'splitTerm'.



        /// <summary>
        /// Method to convert string to a byte array
        /// </summary>
        /// <param name="hashString"></param>
        /// <returns></returns>
        public static byte[] ConvertStringToByteArray(string hashString)
        {
            IEnumerable<byte> hash = new byte[] { };
            foreach (char element in hashString)
            {
                hash = hash.Append(Convert.ToByte(element));
            }
            return hash.ToArray();
        }//Converte uma string em uma matriz de byte, cada elemento da string passada será usado como um byte diferente pra a criação da matriz.

        /// <summary>
        /// Method to convert string to a byte array (each value splited by splitTerm variable, need be a byte)
        /// </summary>
        /// <param name="stringExpression"></param>
        /// <param name="splitTerm"></param>
        /// <returns></returns>
        public static byte[] ConvertStringToByteArray(string stringExpression, char splitTerm)
        {
            IEnumerable<byte> hash = new byte[] { };
            foreach (string text in stringExpression.Split(splitTerm))
            {
                foreach (char element in text)
                {
                    hash = hash.Append(Convert.ToByte(element));
                }
            }
            return (byte[])hash;
        }//Converte uma string em uma matriz de byte, a string possui um elemento separador, representado pela variável do tipo char 'splitTerm', pressupõe que cada valor entre os termos de separação será um número do tipo byte.



        /// <summary>
        /// Method to convert a byte array to a string array
        /// </summary>
        /// <param name="hash"></param>
        /// <param name="convertByteToChar"></param>
        /// <returns></returns>
        public static string[] ConvertToStringArray(byte[] hash, bool convertByteToChar = false)
        {
            IEnumerable<string> stringHash = new string[] { };

            if (convertByteToChar)
            {
                foreach (byte element in hash)
                {
                    stringHash = stringHash.Append($"{Convert.ToChar(element)}");
                }
            }
            else
            {
                foreach (byte element in hash)
                {
                    stringHash = stringHash.Append($"element");
                }
            }
            return ((string[])stringHash);
        }//Converte uma matriz byte para uma matriz string, sendo que cada elemento pode estar como byte ou char(sendo convertido ou não).

        /// <summary>
        /// Method to convert a enumerable byte array to a list string array
        /// </summary>
        /// <param name="hash"></param>
        /// <param name="convertByteToChar"></param>
        /// <returns></returns>
        public static List<string[]> ConvertToStringArray(IEnumerable<byte[]> hashCollection, bool convertByteToChar = false)
        {
            IEnumerable<string[]> listStringHash = new List<string[]>();
            foreach (var hash in hashCollection)
            {
                ((List<string[]>)listStringHash).Add((string[])ConvertToStringArray(hash, convertByteToChar));
            }
            return (List<string[]>)listStringHash;
        }//Converte uma lista de matrizes byte para uma lista de matrizes string, sendo que cada elemento pode estar como byte ou char.



        /// <summary>
        /// Method to convert a byte array to a char array
        /// </summary>
        /// <param name="hash"></param>
        /// <returns></returns>
        public static char[] ConvertToCharArray(byte[] hash)
        {
            IEnumerable<char> charHash = new char[] { };
            foreach (byte element in hash)
            {
                charHash = charHash.Append(Convert.ToChar(element));
            }
            return ((char[])charHash);
        }//Converte uma matriz byte para uma matriz char, sendo que cada elemento estará como char.

        /// <summary>
        /// Method to convert a enumerable byte array to a list char array
        /// </summary>
        /// <param name="hashCollection"></param>
        /// <returns></returns>
        public static List<char[]> ConvertToCharArray(IEnumerable<byte[]> hashCollection)
        {
            IEnumerable<char[]> listCharHash = new List<char[]>();
            foreach (var hash in hashCollection)
            {
                ((List<char[]>)listCharHash).Add((char[])ConvertToCharArray(hash));
            }
            return (List<char[]>)listCharHash;
        }//Converte uma lista de matrizes byte para uma lista de matrizes char, sendo que cada elemento estará como char.
    }

    public enum Crypto
    {
        Crypto_SHA512,
        Crypto_SHA384,
        Crypto_SHA256,
        Crypto_Aes
    }
}
