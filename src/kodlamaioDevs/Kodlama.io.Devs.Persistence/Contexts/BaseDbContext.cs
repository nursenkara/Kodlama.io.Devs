using Core.Security.Entities;
using Kodlama.io.Devs.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Persistence.Contexts
{
    /// <summary>
    /// Veritabanı ayarlarını yapar.
    /// </summary>
    public class BaseDbContext : DbContext
    {
        protected IConfiguration Configuration { get; set; }
        public DbSet<ProgrammingLanguage> ProgrammingLanguages { get; set; }
        public DbSet<ProgrammingLanguageTechnology> ProgrammingLanguageTechnologies { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserSocialMediaAddress> UserSocialMediaAddresses { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }

        public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
        {
            Configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProgrammingLanguage>(p =>
            {
                p.ToTable("ProgrammingLanguages").HasKey(x => x.Id);
                p.Property(x => x.Id).HasColumnName("Id");
                p.Property(x => x.Name).HasColumnName("Name");
                p.HasMany(x => x.ProgrammingLanguageTechnologies);
            });

            modelBuilder.Entity<ProgrammingLanguageTechnology>(p =>
            {
                p.ToTable("ProgrammingLanguageTechnologies").HasKey(x => x.Id);
                p.Property(x => x.Id).HasColumnName("Id");
                p.Property(x => x.ProgrammingLanguageId).HasColumnName("ProgrammingLanguageId");
                p.Property(x => x.Name).HasColumnName("Name");
                p.HasOne(x => x.ProgrammingLanguage);
            });

            modelBuilder.Entity<UserSocialMediaAddress>(p =>
            {
                p.ToTable("UserSocialMediaAddresses").HasKey(x => x.Id);
                p.Property(x => x.Id).HasColumnName("Id");
                p.Property(x => x.UserId).HasColumnName("UserId");
                p.Property(x => x.GithubUrl).HasColumnName("GithubUrl");
                p.HasOne(x => x.User);
            });

            modelBuilder.Entity<User>(p =>
            {
                p.ToTable("Users").HasKey(x => x.Id);
                p.Property(x => x.Id).HasColumnName("Id");
                p.Property(x => x.FirstName).HasColumnName("FirstName");
                p.Property(x => x.LastName).HasColumnName("LastName");
                p.Property(x => x.Email).HasColumnName("Email");
                p.Property(x => x.PasswordHash).HasColumnName("PasswordHash");
                p.Property(x => x.PasswordSalt).HasColumnName("PasswordSalt");
                p.Property(x => x.Status).HasColumnName("Status");
                p.Property(x => x.AuthenticatorType).HasColumnName("AuthenticatorType");
                p.HasMany(x => x.UserOperationClaims);
                p.HasMany(x => x.RefreshTokens);
            });

            modelBuilder.Entity<OperationClaim>(p =>
            {
                p.ToTable("OperationClaims").HasKey(x => x.Id);
                p.Property(x => x.Id).HasColumnName("Id");
                p.Property(x => x.Name).HasColumnName("Name");
            });

            modelBuilder.Entity<UserOperationClaim>(p =>
            {
                p.ToTable("UserOperationClaims").HasKey(x => x.Id);
                p.Property(x => x.Id).HasColumnName("Id");
                p.Property(x => x.UserId).HasColumnName("UserId");
                p.Property(x => x.OperationClaimId).HasColumnName("OperationClaimId");
                p.HasOne(x => x.User);
                p.HasOne(x => x.OperationClaim);
            });


            modelBuilder.Entity<RefreshToken>(p =>
            {
                p.ToTable("RefreshTokens").HasKey(x => x.Id);
                p.Property(x => x.Id).HasColumnName("Id");
                p.Property(x => x.UserId).HasColumnName("UserId");
                p.Property(x => x.Token).HasColumnName("Token");
                p.Property(x => x.Expires).HasColumnName("Expires");
                p.Property(x => x.Created).HasColumnName("Created");
                p.Property(x => x.CreatedByIp).HasColumnName("CreatedByIp");
                p.Property(x => x.Revoked).HasColumnName("Revoked");
                p.Property(x => x.RevokedByIp).HasColumnName("RevokedByIp");
                p.Property(x => x.ReplacedByToken).HasColumnName("ReplacedByToken");
                p.Property(x => x.ReasonRevoked).HasColumnName("ReasonRevoked");
                p.HasOne(x => x.User);
            });
            // Programlama dilleri tablosuna varsayılan kayıtları ekler. (Seeds)
            ProgrammingLanguage[] programmingLanguageEntitySeeds =
            {
                new(1, "C#"),
                new ProgrammingLanguage()
                {
                    Id = 2,
                    Name = "Java"
                },
                new ProgrammingLanguage()
                {
                    Id = 3,
                    Name = "Javascript"
                }
            };
            modelBuilder.Entity<ProgrammingLanguage>().HasData(programmingLanguageEntitySeeds);

            //Programlama dili teknolojileri tablosuna varsayılan kayıtları ekler. (Seeds)

            ProgrammingLanguageTechnology[] programmingLanguageTechnologyEntitySeeds =
            {
                new(1, 1, "ASP.NET CORE"),
                new(2, 1, "Wpf"),
                new(3, 2, "Spring"),
                new(4, 2, "Jsp"),
                new(5, 3, "Vue"),
                new(6, 3, "React"),
            };
            modelBuilder.Entity<ProgrammingLanguageTechnology>().HasData(programmingLanguageTechnologyEntitySeeds);
            //Operasyon yetki tablosuna varsayılan kayıtları ekler. (Seeds)
            OperationClaim[] operationClaimsEntitySeeds =
            {
            new(1, "Admin"),
            new(2, "User")
            };
            modelBuilder.Entity<OperationClaim>().HasData(operationClaimsEntitySeeds);

        }
    }
}
