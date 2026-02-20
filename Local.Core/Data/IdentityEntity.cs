using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Local.Core.Data;

[Serializable]
public class IdentityEntity<T> : IIdentityEntity<T>
{
	[Key]
	[JsonPropertyName("id")]
	public virtual required T Id { get; set; }
}