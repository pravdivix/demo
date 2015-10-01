using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Skeleton.Client.Core;
using Skeleton.Client.Models;

namespace Skeleton.Client.ViewModels
{
	public sealed class MainViewModel : ViewModel
	{
		private BlogViewModel selectedBlog;

		public MainViewModel()
		{
			Blogs = new ObservableCollection<BlogViewModel>(GetDummyBlogs().Select(x => new BlogViewModel(x)));
			////SelectedBlog = Blogs.First();
		}

		public ICollection<BlogViewModel> Blogs { get; set; }

		public bool IsSelectedBlog
		{
			get
			{
				return selectedBlog != null;
			}
		}

		public BlogViewModel SelectedBlog
		{
			get
			{
				return selectedBlog;
			}

			set
			{
				bool set = SetProperty(ref selectedBlog, value);

				if (set)
				{
					OnPropertyChanged("IsSelectedBlog");
				}
			}
		}

		private IEnumerable<Blog> GetDummyBlogs()
		{
			ObservableCollection<Blog> blogs = new ObservableCollection<Blog> 
			{
				new Blog 
				{
					Blogger = new Blogger
					{
						Name = "Bart Simpson",
						Email = "bart@springfield.com",
						////Picture = GetResourceStream(new Uri("/Images/bart.png", UriKind.Relative)).Stream
					},
					Title = "Bart's adventures",
					Posts = 
					{
						new BlogPost 
						{
							When = new DateTime(2000, 8, 12),
							Title = "Post 1",
							Text = "This is the first post of Bart",
							Comments = 
							{
								new BlogComment 
								{
									Name = "Homer S.",
									Text = "Why you little...",
									When = new DateTime(2000, 8, 13)
								}
							}
						},
						new BlogPost 
						{
							When = new DateTime(2002, 3, 22),
							Title = "Post 2",
							Text = "This is the the second post",
							Comments = 
							{
								new BlogComment 
								{
									Name = "Lisa S.",
									Text = "Come on bart!",
									When = new DateTime(2002, 3, 24)
								},
								new BlogComment 
								{
									Name = "Maggie S.",
									Text = "Whhhaaa!",
									When = DateTime.Now
								}
							}
						}
					}
				},
				new Blog 
				{
					Blogger = new Blogger
					{
						Name = "Jhon Snow",
						Email = "jhon@snow.com",
						////Picture = GetResourceStream(new Uri("/Images/bart.png", UriKind.Relative)).Stream
					},
					Title = "Winter is coming",
					Posts = 
					{
						new BlogPost 
						{
							When = new DateTime(2000, 8, 12),
							Title = "Post 1",
							Text = "This is the first post of Bart",
							Comments = 
							{
								new BlogComment 
								{
									Name = "Homer S.",
									Text = "Why you little...",
									When = new DateTime(2000, 8, 13)
								}
							}
						},
						new BlogPost 
						{
							When = new DateTime(2002, 3, 22),
							Title = "Post 2",
							Text = "This is the the second post",
							Comments = 
							{
								new BlogComment 
								{
									Name = "Lisa S.",
									Text = "Come on bart!",
									When = new DateTime(2002, 3, 24)
								},
								new BlogComment 
								{
									Name = "Maggie S.",
									Text = "Whhhaaa!",
									When = DateTime.Now
								}
							}
						}
					}
				}
			};

			return blogs;
		}
	}
}
