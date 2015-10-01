using System.Collections.Generic;

namespace Skeleton.Client.Models
{
	public class Blog
	{
		public Blog()
		{
			Posts = new List<BlogPost>();
		}

		public Blogger Blogger { get; set; }

		public IList<BlogPost> Posts { get; set; }

		public string Title { get; set; }
	}
}