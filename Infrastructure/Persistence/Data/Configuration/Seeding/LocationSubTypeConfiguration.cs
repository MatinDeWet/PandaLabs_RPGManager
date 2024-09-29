using Persistence.Common;

namespace Persistence.Data.Configuration
{
    public partial class LocationSubTypeConfiguration : IEntityTypeConfiguration<LocationSubType>
    {
        partial void OnConfigurePartial(EntityTypeBuilder<LocationSubType> entity)
        {
            entity.HasData(FileReader.ReadSeedFile<LocationSubType>("LocationSubTypes.json"));
        }
    }
}
