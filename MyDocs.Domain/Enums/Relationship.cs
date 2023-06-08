using MyDocs.Domain.Primitives;

namespace MyDocs.Domain.Enums;

public sealed class Relationship : Enumeration
{
    public readonly static Relationship Self = new Relationship(default, "Self");
    public readonly static Relationship Spouse = new Relationship(1, "Spouse");
    public readonly static Relationship Child = new Relationship(2, "Child");

    private Relationship(int value, string name)
        : base(value, name)
    {

    }

    public Relationship()
    {
        
    }

    public static Relationship FromValue(int value)
    {
        return value switch
        {
            0 => Self,
            1 => Spouse,
            2 => Child,
            _ => throw new ArgumentException($"Invalid value for Relationship: {value}")
        };
    }
}