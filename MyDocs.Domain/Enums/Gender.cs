using MyDocs.Domain.Primitives;

namespace MyDocs.Domain.Enums;

public sealed class Gender : Enumeration
{
    public static readonly Gender Male = new Gender(default, "Male");
    public static readonly Gender Female = new Gender(1, "Female");
    
    private Gender(int value, string name)
        : base(value, name)
    {
    }

    public Gender()
    {
        
    }

    public static Gender FromValue(int value)
    {
        return value switch
        {
            0 => Male,
            1 => Female,
            _ => throw new ArgumentException($"Invalid value for Gender: {value}")
        };
    }
}
