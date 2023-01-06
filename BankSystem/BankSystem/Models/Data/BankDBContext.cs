using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DatabaseLibrary.Models.Data
{
    public partial class BankDBContext : DbContext
    {
        public BankDBContext()
        {
        }

        public BankDBContext(DbContextOptions<BankDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<BankWorker> BankWorkers { get; set; }
        public virtual DbSet<Card> Cards { get; set; }
        public virtual DbSet<CardReader> CardReaders { get; set; }
        public virtual DbSet<CardReaderAccountConnection> CardReaderAccountConnections { get; set; }
        public virtual DbSet<Document> Documents { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<Request> Requests { get; set; }
        public virtual DbSet<RequestDocumentsConnection> RequestDocumentsConnections { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }
        public virtual DbSet<TransactionAccountsConnection> TransactionAccountsConnections { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=localhost\\SQLEXPRESS;Database=BankDB;Trusted_Connection=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Iban)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Account)
                    .HasPrincipalKey<CardReaderAccountConnection>(p => p.RecieverId)
                    .HasForeignKey<Account>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Account_CardReaderAccountConnection");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.PersonId)
                    .HasConstraintName("FK_Account_Person");
            });

            modelBuilder.Entity<BankWorker>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Person)
                    .WithOne(p => p.BankWorker)
                    .HasForeignKey<BankWorker>(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BankWorker_Person");
            });

            modelBuilder.Entity<Card>(entity =>
            {
                entity.Property(e => e.Number)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.Holder)
                    .WithMany(p => p.Cards)
                    .HasForeignKey(d => d.HolderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Card_Account");
            });

            modelBuilder.Entity<CardReader>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.CardReader)
                    .HasPrincipalKey<CardReaderAccountConnection>(p => p.CardReaderId)
                    .HasForeignKey<CardReader>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CardReader_CardReaderAccountConnection");
            });

            modelBuilder.Entity<Document>(entity =>
            {
                entity.Property(e => e.Extension).IsUnicode(false);
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.Property(e => e.Egn)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Phone).IsUnicode(false);
            });

            modelBuilder.Entity<Request>(entity =>
            {
                entity.Property(e => e.TableAffected).IsUnicode(false);

                entity.Property(e => e.Timestamp).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Requester)
                    .WithMany(p => p.Requests)
                    .HasForeignKey(d => d.RequesterId)
                    .HasConstraintName("FK_Request_Account");

                entity.HasOne(d => d.Reviewer)
                    .WithMany(p => p.RequestReviewers)
                    .HasForeignKey(d => d.ReviewerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Request_BankWorker1");

                entity.HasOne(d => d.Sender)
                    .WithMany(p => p.RequestSenders)
                    .HasForeignKey(d => d.SenderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Request_BankWorker");
            });

            modelBuilder.Entity<RequestDocumentsConnection>(entity =>
            {
                entity.HasOne(d => d.Document)
                    .WithMany(p => p.RequestDocumentsConnections)
                    .HasForeignKey(d => d.DocumentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RequestDocumentsConnection_Documents");

                entity.HasOne(d => d.Request)
                    .WithMany(p => p.RequestDocumentsConnections)
                    .HasForeignKey(d => d.RequestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RequestDocumentsConnection_Request");
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.Property(e => e.Timestamp).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<TransactionAccountsConnection>(entity =>
            {
                entity.HasOne(d => d.Reciever)
                    .WithMany(p => p.TransactionAccountsConnectionRecievers)
                    .HasForeignKey(d => d.RecieverId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TransactionAccountsConnection_Account1");

                entity.HasOne(d => d.Sender)
                    .WithMany(p => p.TransactionAccountsConnectionSenders)
                    .HasForeignKey(d => d.SenderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TransactionAccountsConnection_Account");

                entity.HasOne(d => d.Transaction)
                    .WithMany(p => p.TransactionAccountsConnections)
                    .HasForeignKey(d => d.TransactionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TransactionAccountsConnection_Transaction");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
