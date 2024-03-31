using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Cryptography.Security.CryptographyTools
{
    public class EncryptionConverter(EncryptionService encryptionService) : ValueConverter<string, string>(
      v => encryptionService.Encrypt(v),
      v => encryptionService.Decrypt(v))
    {
    }
}
