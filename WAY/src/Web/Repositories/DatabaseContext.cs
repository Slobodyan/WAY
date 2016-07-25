using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;

namespace Web.Models {
	public class DatabaseContext : DbContext {

		private static bool _created;

		public DatabaseContext() {
			if(!_created) {
				_created = true;
				Database.EnsureCreated();
			}
		}

		protected override void OnConfiguring(DbContextOptionsBuilder options) {
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder) {
			modelBuilder.Entity<Address>(entity => {
				entity.ToTable("Address", "acc");

				entity.Property(e => e.City).HasMaxLength(256);

				entity.Property(e => e.IsPrimary).HasDefaultValue(false);

				entity.Property(e => e.Number).HasMaxLength(16);

				entity.Property(e => e.PostalCode).HasMaxLength(16);

				entity.Property(e => e.Street).HasMaxLength(256);

				entity.Property(e => e.Unit).HasMaxLength(32);

				entity.HasOne(d => d.Blogger).WithMany(p => p.Addresses).HasForeignKey(d => d.BloggerId).OnDelete(DeleteBehavior.Restrict);

				entity.HasOne(d => d.Country).WithMany(p => p.Addresses).HasForeignKey(d => d.CountryId).OnDelete(DeleteBehavior.Restrict);
			});

			modelBuilder.Entity<Article>(entity => {
				entity.ToTable("Article", "acc");

				entity.Property(e => e.Description).IsRequired();

				entity.Property(e => e.HasPhoto).HasDefaultValue(false);

				entity.Property(e => e.PublishedDateUtc).HasColumnType("datetime");

				entity.Property(e => e.Title)
					.IsRequired()
					.HasMaxLength(128);

				entity.Property(e => e.Views).IsRequired();

				entity.HasOne(d => d.Blogger).WithMany(p => p.Articles).HasForeignKey(d => d.BloggerId).OnDelete(DeleteBehavior.Restrict);

				entity.HasOne(d => d.EntityInfo).WithMany(p => p.Articles).HasForeignKey(d => d.EntityInfoId).OnDelete(DeleteBehavior.Restrict);
			});

			modelBuilder.Entity<Blogger>(entity => {
				entity.ToTable("Blogger", "acc");

				entity.HasKey(e => e.Id);
				entity.Property(e => e.Id).ValueGeneratedOnAdd();

				entity.Property(e => e.Email)
					.IsRequired()
					.HasMaxLength(128);

				entity.Property(e => e.Name).HasMaxLength(128);

				entity.Property(e => e.Password)
					.IsRequired();

				entity.HasOne(d => d.EntityInfo).WithMany(p => p.Bloggers).HasForeignKey(d => d.EntityInfoId).OnDelete(DeleteBehavior.Restrict);
			});

			modelBuilder.Entity<Comment>(entity => {
				entity.ToTable("Comment", "acc");

				entity.Property(e => e.BloggerName).HasMaxLength(256);

				entity.Property(e => e.DateTimeUtc).HasColumnType("datetime");

				entity.Property(e => e.IsDeleted).HasDefaultValue(false);

				entity.Property(e => e.Message).IsRequired();

				entity.HasOne(d => d.Blogger).WithMany(p => p.Comments).HasForeignKey(d => d.BloggerId).OnDelete(DeleteBehavior.Restrict);

				entity.HasOne(d => d.EntityInfo).WithMany(p => p.Comments).HasForeignKey(d => d.EntityInfoId).OnDelete(DeleteBehavior.Restrict);
			});

			modelBuilder.Entity<DomainValue>(entity => {
				entity.ToTable("DomainValue", "dom");

				entity.HasOne(d => d.DomailValueType).WithMany(p => p.DomainValues).HasForeignKey(d => d.DomailValueTypeId).OnDelete(DeleteBehavior.Restrict);
			});

			modelBuilder.Entity<DomainValueType>(entity => {
				entity.ToTable("DomainValueType", "dom");

				entity.Property(e => e.Name)
					.HasMaxLength(64)
					.HasColumnType("varchar");
			});

			modelBuilder.Entity<EntityInfo>(entity => {
				entity.ToTable("EntityInfo", "plt");

				entity.HasKey(e => e.Id);
				entity.Property(e => e.Id).ValueGeneratedOnAdd();

				entity.HasIndex(e => e.EntityTypeId).HasName("IX_EntityInfo_EntityTypeId");

				entity.HasIndex(e => e.Guid).HasName("IX_EntityInfo_Guid").IsUnique();

				entity.HasIndex(e => new { e.Id, e.CreatedDateUtc }).HasName("IX_EntityInfo_CreateDateUtc");

				entity.Property(e => e.CreatedDateUtc).HasColumnType("datetime");

				entity.HasOne(d => d.EntityState).WithMany(p => p.EntityInfos).HasForeignKey(d => d.EntityStateId).OnDelete(DeleteBehavior.Restrict);

				entity.HasOne(d => d.EntityType).WithMany(p => p.EntityInfos).HasForeignKey(d => d.EntityTypeId).OnDelete(DeleteBehavior.Restrict);
			});

			modelBuilder.Entity<EntityLifecycle>(entity => {
				entity.ToTable("EntityLifecycle", "plt");

				entity.Property(e => e.Id).ValueGeneratedNever();

				entity.Property(e => e.Name)
					.HasMaxLength(64)
					.HasColumnType("varchar");
			});

			modelBuilder.Entity<EntityState>(entity => {
				entity.ToTable("EntityState", "plt");

				entity.Property(e => e.Id).ValueGeneratedNever();

				entity.Property(e => e.IsSystem).HasDefaultValue(false);

				entity.HasOne(d => d.EntityLifecycle).WithMany(p => p.EntityStates).HasForeignKey(d => d.EntityLifecycleId).OnDelete(DeleteBehavior.Restrict);
			});

			modelBuilder.Entity<EntityTransition>(entity => {
				entity.ToTable("EntityTransition", "plt");

				entity.HasIndex(e => new { e.EntityStateFromId, e.EntityStateToId }).HasName("IX_EntityTransition").IsUnique();

				entity.Property(e => e.Id).ValueGeneratedNever();

				entity.Property(e => e.IsSystem).HasDefaultValue(false);

				entity.HasOne(d => d.EntityLifecycle).WithMany(p => p.EntityTransitions).HasForeignKey(d => d.EntityLifecycleId).OnDelete(DeleteBehavior.Restrict);

				entity.HasOne(d => d.EntityStateFrom).WithMany(p => p.EntityTransitions).HasForeignKey(d => d.EntityStateFromId);

				entity.HasOne(d => d.EntityStateTo).WithMany(p => p.EntityTransitionNavigations).HasForeignKey(d => d.EntityStateToId).OnDelete(DeleteBehavior.Restrict);
			});

			modelBuilder.Entity<EntityType>(entity => {
				entity.ToTable("EntityType", "plt");

				entity.Property(e => e.Id).ValueGeneratedNever();

				entity.Property(e => e.Name)
					.HasMaxLength(64)
					.HasColumnType("varchar");

				entity.HasOne(d => d.EntityLifecycle).WithMany(p => p.EntityTypes).HasForeignKey(d => d.EntityLifecycleId).OnDelete(DeleteBehavior.Restrict);
			});

			modelBuilder.Entity<Favorite>(entity => {
				entity.ToTable("Favorite", "acc");

				entity.Property(e => e.DateTimeUtc).HasColumnType("datetime");

				entity.HasOne(d => d.Blogger).WithMany(p => p.Favorites).HasForeignKey(d => d.BloggerId).OnDelete(DeleteBehavior.Restrict);

				entity.HasOne(d => d.EntityInfo).WithMany(p => p.Favorites).HasForeignKey(d => d.EntityInfoId).OnDelete(DeleteBehavior.Restrict);
			});

			modelBuilder.Entity<Like>(entity => {
				entity.ToTable("Like", "acc");

				entity.Property(e => e.DateTimeUtc).HasColumnType("datetime");

				entity.Property(e => e.IsDislike).HasDefaultValue(false);

				entity.HasOne(d => d.Blogger).WithMany(p => p.Likes).HasForeignKey(d => d.BloggerId).OnDelete(DeleteBehavior.Restrict);

				entity.HasOne(d => d.EntityInfo).WithMany(p => p.Likes).HasForeignKey(d => d.EntityInfoId).OnDelete(DeleteBehavior.Restrict);
			});

			modelBuilder.Entity<Organization>(entity => {
				entity.ToTable("Organization", "acc");

				entity.HasKey(e => e.Id);
				entity.Property(e => e.Id).ValueGeneratedOnAdd();

				entity.Property(e => e.HasPhoto).HasDefaultValue(false);

				entity.Property(e => e.Name).HasMaxLength(256);

				entity.HasOne(d => d.Blogger).WithMany(p => p.Organizations).HasForeignKey(d => d.BloggerId).OnDelete(DeleteBehavior.Restrict);
			});

			modelBuilder.Entity<Tag>(entity => {
				entity.ToTable("Tag", "acc");

				entity.Property(e => e.Name)
					.IsRequired()
					.HasMaxLength(32);
			});

			modelBuilder.Entity<TagEntity>(entity => {
				entity.ToTable("TagEntity", "acc");

				entity.HasIndex(e => new { e.EntityInfoId, e.TagId }).HasName("IX_TagEntity_TagId");

				entity.HasOne(d => d.EntityInfo).WithMany(p => p.TagEntities).HasForeignKey(d => d.EntityInfoId).OnDelete(DeleteBehavior.Restrict);

				entity.HasOne(d => d.Tag).WithMany(p => p.TagEntities).HasForeignKey(d => d.TagId).OnDelete(DeleteBehavior.Restrict);
			});

			modelBuilder.Entity<Translation>(entity => {
				entity.ToTable("Translation", "stl");

				entity.HasIndex(e => e.TranslationCodeId).HasName("IX_Translation_TranslationCodeId");

				entity.Property(e => e.Value).IsRequired();

				entity.HasOne(d => d.Language).WithMany(p => p.Translations).HasForeignKey(d => d.LanguageId).OnDelete(DeleteBehavior.Restrict);

				entity.HasOne(d => d.TranslationCode).WithMany(p => p.Translations).HasForeignKey(d => d.TranslationCodeId).OnDelete(DeleteBehavior.Restrict);
			});

			modelBuilder.Entity<TranslationCode>(entity => {
				entity.ToTable("TranslationCode", "stl");

				entity.Property(e => e.Description)
					.HasMaxLength(512)
					.HasColumnType("varchar");

				entity.Property(e => e.Name)
					.HasMaxLength(128)
					.HasColumnType("varchar");
			});

			modelBuilder.Entity<User>(entity => {
				entity.ToTable("User", "acc");

				entity.HasKey(e => e.Id);
				entity.Property(e => e.Id).ValueGeneratedOnAdd();

				entity.Property(e => e.BirthDate).HasColumnType("datetime");

				entity.Property(e => e.FirstName).HasMaxLength(64);

				entity.Property(e => e.HasPhoto).HasDefaultValue(false);

				entity.Property(e => e.LastName).HasMaxLength(64);

				entity.Property(e => e.MiddleName).HasMaxLength(32);

				entity.Property(e => e.Mobile)
					.HasMaxLength(32)
					.HasColumnType("varchar");

				entity.Property(e => e.ParentName).HasMaxLength(64);

				entity.Property(e => e.Phone)
					.HasMaxLength(32)
					.HasColumnType("varchar");

				entity.Property(e => e.Skype).HasMaxLength(128);

				entity.HasOne(d => d.Blogger).WithMany(p => p.Users).HasForeignKey(d => d.BloggerId).OnDelete(DeleteBehavior.Restrict);

				entity.HasOne(d => d.Gender).WithMany(p => p.Users).HasForeignKey(d => d.GenderId);
			});

			modelBuilder.Entity<Website>(entity => {
				entity.ToTable("Website", "acc");

				entity.Property(e => e.IsPrimary).HasDefaultValue(false);

				entity.Property(e => e.Url)
					.IsRequired()
					.HasMaxLength(256);

				entity.HasOne(d => d.Blogger).WithMany(p => p.Websites).HasForeignKey(d => d.BloggerId).OnDelete(DeleteBehavior.Restrict);
			});
		}

		public virtual DbSet<Address> Address { get; set; }
		public virtual DbSet<Article> Article { get; set; }
		public virtual DbSet<Blogger> Blogger { get; set; }
		public virtual DbSet<Comment> Comment { get; set; }
		public virtual DbSet<DomainValue> DomainValue { get; set; }
		public virtual DbSet<DomainValueType> DomainValueType { get; set; }
		public virtual DbSet<EntityInfo> EntityInfo { get; set; }
		public virtual DbSet<EntityLifecycle> EntityLifecycle { get; set; }
		public virtual DbSet<EntityState> EntityState { get; set; }
		public virtual DbSet<EntityTransition> EntityTransition { get; set; }
		public virtual DbSet<EntityType> EntityType { get; set; }
		public virtual DbSet<Favorite> Favorite { get; set; }
		public virtual DbSet<Like> Like { get; set; }
		public virtual DbSet<Organization> Organization { get; set; }
		public virtual DbSet<Tag> Tag { get; set; }
		public virtual DbSet<TagEntity> TagEntity { get; set; }
		public virtual DbSet<Translation> Translation { get; set; }
		public virtual DbSet<TranslationCode> TranslationCode { get; set; }
		public virtual DbSet<User> User { get; set; }
		public virtual DbSet<Website> Website { get; set; }
	}
}