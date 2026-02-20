namespace Local.Core.Data.Entity;

public interface IIdentityEntity<T>
{
	T Id { get; set; }
}