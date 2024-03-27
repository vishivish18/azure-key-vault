using System;
using System.Threading.Tasks;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;

namespace azure_key_vault.Services
{
    public class KeyVault
    {
        public static async Task<KeyVaultSecret> Get(string secretName = "username")
        {
            var keyVaultName = "fub-poc-key-vault";
            var keyVaultUri = $"https://{keyVaultName}.vault.azure.net";

            var client = new SecretClient(new Uri(keyVaultUri), new DefaultAzureCredential());

            Console.WriteLine($"Retrieving your secret from {keyVaultName}.");
            var secret = await client.GetSecretAsync(secretName);
            Console.WriteLine($"Your secret is '{secret.Value.Value}'.");
            return secret.Value;
        }
    }
}
