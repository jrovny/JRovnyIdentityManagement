using System;
using System.Security.Cryptography.X509Certificates;

namespace JRovnySites.IdentityManagement
{
    public static class X509CertificateManager
    {
        public static X509Certificate2 GetX509Certificate2(string x509CertificatePath, string password)
        {
            if (string.IsNullOrWhiteSpace(x509CertificatePath))
                throw new ArgumentNullException(nameof(x509CertificatePath));

            using (X509Store store = new X509Store(StoreName.My, StoreLocation.CurrentUser, OpenFlags.ReadWrite))
            {
                store.Add(new X509Certificate2(x509CertificatePath, password, X509KeyStorageFlags.PersistKeySet));
                store.Open(OpenFlags.ReadOnly);
                var certs = store.Certificates.Find(X509FindType.FindByTimeValid, DateTime.Now, false);
                if (certs.Count == 0)
                    throw new Exception($"No certificate found in path: '{x509CertificatePath}'");

                return certs[0];
            }
        }
    }
}