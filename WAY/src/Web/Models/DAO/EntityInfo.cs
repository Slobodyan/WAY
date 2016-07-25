using System;
using System.Collections.Generic;

namespace Web.Models {
	public partial class EntityInfo {
		public EntityInfo() {
			Articles = new HashSet<Article>();
			Bloggers = new HashSet<Blogger>();
			Comments = new HashSet<Comment>();
			Favorites = new HashSet<Favorite>();
			Likes = new HashSet<Like>();
			TagEntities = new HashSet<TagEntity>();

			CreatedDateUtc = DateTime.UtcNow;
			Guid = Guid.NewGuid();
		}

		public int Id { get; set; }
		public DateTime CreatedDateUtc { get; set; }
		public int EntityStateId { get; set; }
		public int EntityTypeId { get; set; }
		public Guid Guid { get; set; }

		public virtual ICollection<Article> Articles { get; set; }
		public virtual ICollection<Blogger> Bloggers { get; set; }
		public virtual ICollection<Comment> Comments { get; set; }
		public virtual ICollection<Favorite> Favorites { get; set; }
		public virtual ICollection<Like> Likes { get; set; }
		public virtual ICollection<TagEntity> TagEntities { get; set; }
		public virtual EntityState EntityState { get; set; }
		public virtual EntityType EntityType { get; set; }
	}
}
