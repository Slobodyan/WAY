using System.Collections.Generic;

namespace Web.Models {
	public partial class Blogger {
		public Blogger() {
			Addresses = new HashSet<Address>();
			Articles = new HashSet<Article>();
			Comments = new HashSet<Comment>();
			Favorites = new HashSet<Favorite>();
			Likes = new HashSet<Like>();
			Organizations = new HashSet<Organization>();
			Users = new HashSet<User>();
			Websites = new HashSet<Website>();
		}

		public int Id { get; set; }
		public string Email { get; set; }
		public int EntityInfoId { get; set; }
		public string Name { get; set; }
		public string Password { get; set; }

		public virtual ICollection<Address> Addresses { get; set; }
		public virtual ICollection<Article> Articles { get; set; }
		public virtual ICollection<Comment> Comments { get; set; }
		public virtual ICollection<Favorite> Favorites { get; set; }
		public virtual ICollection<Like> Likes { get; set; }
		public virtual ICollection<Organization> Organizations { get; set; }
		public virtual ICollection<User> Users { get; set; }
		public virtual ICollection<Website> Websites { get; set; }
		public virtual EntityInfo EntityInfo { get; set; }
	}
}
