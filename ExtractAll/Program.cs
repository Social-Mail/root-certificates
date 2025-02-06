using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace ExtractAll;

internal class Program
{
    static void Main(string[] args)
    {
        var store = new X509Store(StoreName.Root, StoreLocation.LocalMachine);
        store.Open(OpenFlags.ReadOnly);

        if (store.Certificates.Count > 0)
        {
            var counter = 0;
            foreach (var certificate in store.Certificates)
            {
                counter++;

                var pem = certificate.ExportCertificatePem();
                System.IO.File.WriteAllText("cert" + counter + ".crt", pem);
            }
        }
    }
}
