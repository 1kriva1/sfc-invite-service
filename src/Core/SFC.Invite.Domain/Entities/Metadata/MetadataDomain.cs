using SFC.Invite.Domain.Common;

namespace SFC.Invite.Domain.Entities.Metadata;
public class MetadataDomain : EnumEntity<MetadataDomainEnum>
{
    public MetadataDomain() : base() { }

    public MetadataDomain(MetadataDomainEnum enumType) : base(enumType) { }
}