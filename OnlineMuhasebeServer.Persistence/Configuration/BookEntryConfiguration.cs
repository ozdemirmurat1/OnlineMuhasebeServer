using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineMuhasebeServer.Domain.CompanyEntities;
using OnlineMuhasebeServer.Persistence.Constants;

namespace OnlineMuhasebeServer.Persistence.Configuration
{
    public sealed class BookEntryConfiguration : IEntityTypeConfiguration<BookEntry>
    {
        public void Configure(EntityTypeBuilder<BookEntry> builder)
        {
            builder.ToTable(TableNames.BookEntries);
            builder.HasKey(t => t.Id);
        }
    }
}
