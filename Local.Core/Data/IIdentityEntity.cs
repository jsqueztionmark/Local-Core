namespace Local.Core.Data;

public interface IIdentityEntity<T>
{
	T Id { get; set; }
}