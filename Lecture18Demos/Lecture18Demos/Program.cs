using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Lecture18Demos
{
    class Program
    {
        static void Main(string[] args)
        {
            SymmetricEncryptionDemo();

            //AsymmetricEncryptionDemo();

            //DigitalSigningDemo();

            //ExamDemo();
        }

        private static void SymmetricEncryptionDemo()
        {
            string plainText = "My super secret string";
            byte[] encryptedValue;
            string decryptedValue;

            byte[] key;
            byte[] iv;

            using (AesCryptoServiceProvider csp = new AesCryptoServiceProvider())
            {
                //provider.GenerateKey();
                key = csp.Key;
                Console.WriteLine("Key: {0}", Encoding.UTF8.GetString(key));

                //provider.GenerateIV();
                iv = csp.IV;
                Console.WriteLine("IV: {0}", Encoding.UTF8.GetString(iv));

                ICryptoTransform encryptor = csp.CreateEncryptor(key, iv);

                // Create the streams used for encryption.
                using (MemoryStream stream = new MemoryStream())
                using (CryptoStream crypt = new CryptoStream(stream, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter writer = new StreamWriter(crypt))
                    {
                        writer.Write(plainText);
                    }

                    encryptedValue = stream.ToArray();
                }

                ICryptoTransform decryptor = csp.CreateDecryptor(key, iv);

                // Create the streams for decryption.
                using (MemoryStream stream = new MemoryStream(encryptedValue))
                using (CryptoStream crypt = new CryptoStream(stream, decryptor, CryptoStreamMode.Read))
                using (StreamReader reader = new StreamReader(crypt))
                {
                    decryptedValue = reader.ReadToEnd();
                }

                //Display the original data and the decrypted data.
                Console.WriteLine("Plain text: {0}", plainText);
                Console.WriteLine("Encrypted value: {0}", Encoding.UTF8.GetString(encryptedValue));
                Console.WriteLine("Decrypted value: {0}", decryptedValue);
            }
        }

        private static void AsymmetricEncryptionDemo()
        {
            string plainText = "My super secret string";
            byte[] encryptedValue;
            string decryptedValue;

            using (RSACryptoServiceProvider csp = new RSACryptoServiceProvider())
            {
                Console.WriteLine(csp.ToXmlString(true));

                encryptedValue = csp.Encrypt(Encoding.UTF8.GetBytes(plainText), true);

                decryptedValue = Encoding.UTF8.GetString(csp.Decrypt(encryptedValue, true));
            }

            Console.WriteLine("Plain text: {0}", plainText);
            Console.WriteLine("Encrypted value: {0}", Encoding.UTF8.GetString(encryptedValue));
            Console.WriteLine("Decrypted value: {0}", decryptedValue);
        }

        private static void DigitalSigningDemo()
        {
            string plainText = "My super important message.";
            byte[] signature;
            byte[] bogusSignature = new byte[] { 0, 1, 2, 3 };
            bool isValid;

            using (RSACryptoServiceProvider csp = new RSACryptoServiceProvider())
            {
                //Console.WriteLine(csp.ToXmlString(true));

                string sha256Id = CryptoConfig.MapNameToOID("SHA256");

                signature = csp.SignData(Encoding.UTF8.GetBytes(plainText), sha256Id);

                //signature = bogusSignature;
                isValid = csp.VerifyData(Encoding.UTF8.GetBytes(plainText), sha256Id, signature);
            }

            Console.WriteLine("Plain text: {0}", plainText);
            Console.WriteLine("Signature: {0}", Encoding.UTF8.GetString(signature));
            Console.WriteLine("IsValid? {0}", isValid);
        }

        private static void ExamDemo()
        {
            BaseLogger logger = new Logger();
            logger.Log("Log started");
            logger.Log("Base: Log continuing");
            ((Logger)logger).LogCompleted();
        }
    }
}
