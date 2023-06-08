using MyDocs.Domain.Primitives;

namespace MyDocs.Domain.Enums;

public sealed class DocumentType : Enumeration
{
    public readonly static DocumentType Other = new DocumentType(default, "Other");
    public readonly static DocumentType Government = new DocumentType(1, "Government");
    public readonly static DocumentType Medical = new DocumentType(2, "Medical");

    private DocumentType(int value, string name)
        : base(value, name)
    {

    }
}
