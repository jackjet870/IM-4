using System;
using System.Security.Cryptography;

namespace FinalHttpFramework
{
    class Encryption
    {
        public Encryption()
        {
            this.rsaProvider = new RSACryptoServiceProvider();

            this.publicOnly = false;
        }

        public Encryption(RSAParameters publicKeyParameters) : this()
        {
            this.rsaProvider.ImportParameters(publicKeyParameters);

            this.publicOnly = true;
        }

        private readonly bool publicOnly;

        private readonly RSACryptoServiceProvider rsaProvider;
        
        /// <summary>
        /// Used to get a public-only version to send to the server for other users to send messages to this user with
        /// </summary>
        public RSAParameters RSAParameters => this.rsaProvider.ExportParameters(false);

        public byte[] DecryptBytes(byte[] bytesToDecrypt)
        {
            if (this.publicOnly)
            {
                throw new NotSupportedException("Cannot decrypt on a public-only keychain");
            }

            return this.rsaProvider.Decrypt(bytesToDecrypt, false);
        }

        public byte[] EncryptBytes(byte[] bytesToEncrypt)
        {
            return this.rsaProvider.Encrypt(bytesToEncrypt, false);
        }
    }
}
