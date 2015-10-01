using System.IO;

namespace Skeleton.Client.Models
{
	public class Blogger
	{
		public string Email { get; set; }

		public string Name { get; set; }

		public Stream Picture { get; set; }
	}
}