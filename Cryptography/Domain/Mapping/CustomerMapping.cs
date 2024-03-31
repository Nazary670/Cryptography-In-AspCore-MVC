using Cryptography.Domain.Entities;
using Cryptography.Security.CryptographyTools;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cryptography.Domain.Mapping
{
    public class CustomerMapping : IEntityTypeConfiguration<Customer>
    {
        private readonly EncryptionService _EncryptionService;

        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(X => X.FirstName).HasMaxLength(1024).IsRequired();
            builder.Property(X => X.LastName).HasMaxLength(1024).IsRequired();

            builder.Property(X => X.Email).HasMaxLength(1024).IsRequired();
            builder.Property(X => X.Phone).HasMaxLength(1024).IsRequired();

            builder.Property(X => X.Country).HasMaxLength(1024).IsRequired();
            builder.Property(X => X.State).HasMaxLength(1024).IsRequired();
            builder.Property(X => X.City).HasMaxLength(1024).IsRequired();
            builder.Property(X => X.Address).HasMaxLength(1024).IsRequired();



            #region Encrypt and DeCrypt columns
            var Encryptor = new EncryptionConverter(_EncryptionService);

            builder.Property(X => X.FirstName)
                .HasConversion(Encryptor);

            builder.Property(X => X.LastName)
                .HasConversion(Encryptor);

            builder.Property(X => X.Email)
                .HasConversion(Encryptor);

            builder.Property(X => X.Phone)
                .HasConversion(Encryptor);

            builder.Property(X => X.Address)
                .HasConversion(Encryptor);

            #endregion


        }
    }
    //The end.
}
