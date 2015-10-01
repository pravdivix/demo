using System;
using System.Collections.Generic;

namespace Skeleton.Client.Models
{
	public class BlogPost
	{
		public BlogPost()
		{
			Comments = new List<BlogComment>();
		}

		public IList<BlogComment> Comments { get; set; }

		public string Text { get; set; }

		public string Title { get; set; }

		public DateTime When { get; set; }
	}
}