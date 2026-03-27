namespace Local.Core.Exception;

public class EntityMappingException : System.Exception
{
    public EntityMappingException(string msg, System.Exception baseException)
        : base(msg, baseException) { }
}
