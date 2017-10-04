using PartyApp.Core.Model;
using PartyApp.Core.Model.Content;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace PartyApp.Infrastructure.Data.Contexts
{
    public class ContentDbContext : DbContext
    {
        public ContentDbContext()
            : base("MeMConnectionString")
        {
            //Configuration.LazyLoadingEnabled = false;
        }

        public virtual DbSet<Content> Contents { get; set; }
        public virtual DbSet<ContentUsage> ContentUsages { get; set; }
        public virtual DbSet<FeatureInstance> FeatureInstances { get; set; }
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<MovieMusicSelection> MovieMusicSelections { get; set; }
        public virtual DbSet<Music> Musics { get; set; }
        public virtual DbSet<ImageContent> ImageContents { get; set; }
        public virtual DbSet<MediaContent> MediaContents { get; set; }
        public virtual DbSet<TextContent> TextContents { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("core");
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            EfMapContent(modelBuilder);
            EfMapContentUsage(modelBuilder);
            EfMapFeatureInstance(modelBuilder);
            EfMapImageContent(modelBuilder);
            EfMapMediaContent(modelBuilder);
            EfMapMovie(modelBuilder);
            EfMapMovieMusicSelection(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private static void EfMapContent(DbModelBuilder modelBuilder)
        {
            var content = modelBuilder.Entity<Content>();

            content.Property(c => c.Id).HasColumnName("ContentId");
            content.HasOptional(e => e.MediaContent).WithRequired(e => e.Content);
            content.HasOptional(c => c.TextContent).WithRequired(c => c.Content);
        }

        private static void EfMapContentUsage(DbModelBuilder modelBuilder)
        {
            var cUsage = modelBuilder.Entity<ContentUsage>();

            cUsage.HasKey(k => k.Id);
            cUsage.Property(k => k.Id).HasColumnName("ContentId");
            cUsage.Property(c => c.GroupSequence).HasColumnName("ContentGroupSeqNo");
            cUsage.Property(c => c.Id).HasColumnName("ContentUsageId");
            cUsage.Property(c => c.Sequence).HasColumnName("FeatureInstanceSeqNo");
            cUsage.Property(c => c.ContentUsageType).HasColumnName("ContentUsageTypeId");
            cUsage.Property(c => c.ContentUsageStatusType).HasColumnName("ContentUsageStatusTypeId");
            cUsage.HasRequired(c => c.Content).WithMany(c => c.ContentUsages).HasForeignKey(k => k.ContentId);
            //cUsage.HasRequired(c => c.ImageContent).WithMany(c => c.ContentUsages).HasForeignKey(k => k.ContentId);
        }

        public static void EfMapImageContent(DbModelBuilder modelBuilder)
        {
            var imageContent = modelBuilder.Entity<ImageContent>();

            imageContent.Property(i => i.ImageContentId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
        }

        private static void EfMapFeatureInstance(DbModelBuilder modelBuilder)
        {
            var fInstance = modelBuilder.Entity<FeatureInstance>();

            fInstance
                .Property(f => f.Feature).HasColumnName("FeatureId");

            fInstance
                .HasMany(e => e.ContentUsages)
                .WithOptional(e => e.ParentFeatureInstance)
                .HasForeignKey(e => e.ParentFeatureInstanceId);
        }

        //private static void EfMapImageContent(DbModelBuilder modelBuilder)
        //{
        //    var imageContent = modelBuilder.Entity<ImageContent>();

        //    imageContent.Property(c => c.Id).HasColumnName("ImageContentId");
        //    imageContent.Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

        //    //modelBuilder.Entity<ImageContent>()
        //    //    .Map(m =>
        //    //    {
        //    //        m.Property(p => p.Id).HasColumnName("ContentId");
        //    //        m.Properties(c => new { c.ContentCaption, c.ContentTypeId, c.ContentName, c.StorageUnitTypeId, c.EffectiveStartDate, c.EffectiveEndDate });
        //    //        m.ToTable("Content");
        //    //    })
        //    //    .Map(m =>
        //    //    {
        //    //        m.Property(p => p.Id).HasColumnName("MediaContentId");
        //    //        m.Properties(mc => new { mc.MediaContentTypeId, mc.PhysicalLocationUrl });
        //    //        m.ToTable("MediaContent");
        //    //    })
        //    //    .Map(m =>
        //    //    {
        //    //        m.Property(p => p.Id).HasColumnName("ImageContentId");
        //    //        m.Properties(i => new { i.AspectRatio, i.OrigHeight, i.OrigWidth, i.ImageCreateDate, i.QueryString });
        //    //        m.ToTable("ImageContent");
        //    //    });
        //}

        private static void EfMapMediaContent(DbModelBuilder modelBuilder)
        {
            var mediaContent = modelBuilder.Entity<MediaContent>();

            mediaContent.Property(c => c.MediaContentId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            mediaContent.HasOptional(m => m.ImageContent).WithRequired(m => m.MediaContent);
        }

        private static void EfMapMovie(DbModelBuilder modelBuilder)
        {
            var movie = modelBuilder.Entity<Movie>();
            movie.Ignore(m => m.Images);
            movie.Ignore(m => m.Videos);
            movie.Ignore(m => m.TitleImageId);
            movie.Ignore(m => m.UseVideoDefault);
        }

        private static void EfMapMovieMusicSelection(DbModelBuilder modelBuilder)
        {
            var mms = modelBuilder.Entity<MovieMusicSelection>();
            mms.Property(m => m.MovieId).HasColumnName("MovieSelectionId");
        }

    }
}
