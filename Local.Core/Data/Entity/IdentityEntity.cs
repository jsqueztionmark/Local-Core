using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Local.Core.Data.Entity;

[Serializable]
public class IdentityEntity<T> : EntityBase, IIdentityEntity<T>
{
	[Key]
	[JsonPropertyName("id")]
	public virtual required T Id { get; set; }
}