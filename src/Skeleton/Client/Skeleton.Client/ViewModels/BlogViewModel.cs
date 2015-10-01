using System;
using Skeleton.Client.Core;
using Skeleton.Client.Models;

namespace Skeleton.Client.ViewModels
{
	public sealed class BlogViewModel : ViewModel
	{
		public BlogViewModel(Blog model)
		{
			if (model == null)
			{
				throw new ArgumentNullException("model");
			}

			Model = model;
		}

		public Blog Model { get; set; }
	}
}