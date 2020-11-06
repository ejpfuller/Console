using System;
using System.IO;
using System.Security.Cryptography;

namespace Test
{
    public class Cryptography
    {
        public Cryptography()
        {
        }
        public static void EncryptToFile()
        {
            try
            {
                FileStream myStream = new FileStream("../../../TestData.txt", FileMode.OpenOrCreate);
                Aes aes = Aes.Create();
                byte[] key = { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16 };
                byte[] iv = { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16 };

                CryptoStream cryptStream = new CryptoStream(myStream, aes.CreateEncryptor(key, iv), CryptoStreamMode.Write);

                //Create a StreamWriter for easy writing to the
                //file stream.  
                StreamWriter sWriter = new StreamWriter(cryptStream);

                //Write to the stream.  
                sWriter.WriteLine("Hello World! This is an encrypted message that can be decrypted using the correct key used during the encrypting process! If you can successfully decrypt this, then you have access to that key");

                //Close all the connections.  
                sWriter.Close();
                cryptStream.Close();
                myStream.Close();

                //Inform the user that the message was written  
                //to the stream.  
                Console.WriteLine("The file was encrypted.");
            }

            catch
            {
                //Inform the user that an exception was raised.  
                Console.WriteLine("The encryption failed.");
                throw;
            }

        }

        public static void DecryptFromFile()
        {
            try
            {
                FileStream myStream = new FileStream("../../../TestData.txt", FileMode.Open);
                Aes aes = Aes.Create();

                byte[] key = { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16 };
                byte[] iv = { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16 };

                CryptoStream cryptStream = new CryptoStream(myStream, aes.CreateDecryptor(key, iv), CryptoStreamMode.Read);

                //Create a StreamWriter for easy writing to the
                //file stream.  
                StreamReader sReader = new StreamReader(cryptStream);

                //Write to the stream.  
                Console.WriteLine(sReader.ReadToEnd());

                //Close all the connections.  
                sReader.Close();
                cryptStream.Close();
                myStream.Close();

                //Inform the user that the message was written  
                //to the stream.  

            }

            catch
            {
                //Inform the user that an exception was raised.  
                Console.WriteLine("The encryption read failed.");
                throw;
            }

        }

        public static string EncryptString(string plainText)
        {

            byte[] key = { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16 };
            byte[] iv = { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16 };
            byte[] array;

            using (Aes aes = Aes.Create())
            {
                aes.Key = key;
                aes.IV = iv;

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream))
                        {
                            streamWriter.Write(plainText);
                        }

                        array = memoryStream.ToArray();
                    }
                }
                return Convert.ToBase64String(array);
            }


        }
    }
}
