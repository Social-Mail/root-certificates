﻿using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace ExtractAll;

internal class Program
{

    static int counter = 0;
    static void Main(string[] args)
    {
        Collect(StoreName.Root);
        Collect(StoreName.AuthRoot);
        Collect(StoreName.CertificateAuthority);
    }

    private static void Collect(StoreName storeName)
    {
        var store = new X509Store(storeName, StoreLocation.LocalMachine);
        store.Open(OpenFlags.ReadOnly);

        if (store.Certificates.Count > 0)
        {
            foreach (var certificate in store.Certificates)
            {
                counter++;

                var pem = certificate.ExportCertificatePem();
                System.IO.File.WriteAllText("cert" + counter + ".crt", pem);
            }
        }
    }
}
