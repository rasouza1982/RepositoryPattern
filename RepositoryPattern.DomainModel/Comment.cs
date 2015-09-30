using System;
using RepositoryPattern.Infrastructure;

namespace RepositoryPattern.DomainModel
{
	public class Comment
	{
		public int Id { get; set; }
		public string Email { get; set; }
		public DateTime CommentDate { get; set; }
		public string Text { get; set; }
		public int Rating { get; set; }
		public BlogPost BlogPost { get; set; }
	}
}
