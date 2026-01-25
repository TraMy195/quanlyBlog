using Microsoft.EntityFrameworkCore;
using Blog.Models;

namespace Blog.Data
{
    public class BlogDbContext : DbContext
    {
        public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 1. Cấu hình bảng User (Người dùng)
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.UserId);
                entity.HasIndex(u => u.Username).IsUnique(); // Tên đăng nhập là duy nhất
                entity.Property(u => u.Username).IsRequired().HasMaxLength(50);
                entity.Property(u => u.Password).IsRequired().HasMaxLength(255);
                entity.Property(u => u.Email).IsRequired().HasMaxLength(150);
                entity.Property(u => u.Role).IsRequired().HasDefaultValue("Reader");
            });

            // 2. Cấu hình bảng Category (Chuyên mục)
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(c => c.CategoryId);
                entity.Property(c => c.Name).IsRequired().HasMaxLength(100);
            });

            // 3. Cấu hình bảng Post (Bài viết)
            modelBuilder.Entity<Post>(entity =>
            {
                entity.HasKey(p => p.PostId);
                entity.Property(p => p.Title).IsRequired();
                entity.Property(p => p.Content).IsRequired();
                entity.Property(p => p.CreatedAt).HasDefaultValueSql("GETDATE()");
                entity.Property(p => p.Status).HasDefaultValue("Công khai");

                // Quan hệ Post - User (1-N)
                entity.HasOne(p => p.Author)
                      .WithMany(u => u.Posts)
                      .HasForeignKey(p => p.AuthorId)
                      .OnDelete(DeleteBehavior.Cascade); // Xóa User thì xóa bài viết

                // Quan hệ Post - Category (1-N)
                entity.HasOne(p => p.Category)
                      .WithMany(c => c.Posts)
                      .HasForeignKey(p => p.CategoryId)
                      .OnDelete(DeleteBehavior.Restrict); // Không cho xóa chuyên mục nếu còn bài viết
            });

            // 4. Cấu hình bảng Comment (Bình luận) - PHẦN QUAN TRỌNG ĐỂ SỬA LỖI
            modelBuilder.Entity<Comment>(entity =>
            {
                entity.HasKey(c => c.CommentId);
                entity.Property(c => c.Content).IsRequired();
                entity.Property(c => c.CreatedAt).HasDefaultValueSql("GETDATE()");

                // Quan hệ Comment - Post (1-N)
                entity.HasOne(c => c.Post)
                      .WithMany(p => p.Comments)
                      .HasForeignKey(c => c.PostId)
                      .OnDelete(DeleteBehavior.Cascade); // Xóa Bài viết -> Xóa hết bình luận của bài đó (Hợp lệ)

                // Quan hệ Comment - User (1-N)
                entity.HasOne(c => c.User)
                      .WithMany(u => u.Comments)
                      .HasForeignKey(c => c.UserId)
                      .OnDelete(DeleteBehavior.Restrict); // Đổi sang Restrict để tránh lỗi Multiple Cascade Paths
            });
            // ===== SEED USERS =====
            modelBuilder.Entity<User>().HasData(
                new User { UserId = 1, Username = "admin", Password = "123", FullName = "Admin", Email = "admin@gmail.com", Role = "Admin" },
                new User { UserId = 2, Username = "editor1", Password = "123", FullName = "Editor One", Email = "editor1@gmail.com", Role = "Editor" },
                new User { UserId = 3, Username = "editor2", Password = "123", FullName = "Editor Two", Email = "editor2@gmail.com", Role = "Editor" },
                new User { UserId = 4, Username = "reader1", Password = "123", FullName = "Reader One", Email = "reader1@gmail.com", Role = "Reader" },
                new User { UserId = 5, Username = "reader2", Password = "123", FullName = "Reader Two", Email = "reader2@gmail.com", Role = "Reader" }
            );

            // ===== SEED CATEGORIES =====
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = "Công nghệ", Description = "Tin công nghệ" },
                new Category { CategoryId = 2, Name = "Giải trí", Description = "Tin giải trí" },
                new Category { CategoryId = 3, Name = "Thể thao", Description = "Tin thể thao" },
                new Category { CategoryId = 4, Name = "Giáo dục", Description = "Tin giáo dục" },
                new Category { CategoryId = 5, Name = "Kinh tế", Description = "Tin kinh tế" }
            );

            // ===== SEED POSTS =====
            modelBuilder.Entity<Post>().HasData(
                new Post { PostId = 1, Title = "Bài viết công nghệ", Content = new string('A', 60), AuthorId = 2, CategoryId = 1, Views = 10, Status = "Công khai" },
                new Post { PostId = 2, Title = "Bài viết giải trí", Content = new string('B', 60), AuthorId = 2, CategoryId = 2, Views = 5, Status = "Công khai" },
                new Post { PostId = 3, Title = "Bài viết thể thao", Content = new string('C', 60), AuthorId = 3, CategoryId = 3, Views = 20, Status = "Công khai" },
                new Post { PostId = 4, Title = "Bài viết giáo dục", Content = new string('D', 60), AuthorId = 3, CategoryId = 4, Views = 7, Status = "Công khai" },
                new Post { PostId = 5, Title = "Bài viết kinh tế", Content = new string('E', 60), AuthorId = 2, CategoryId = 5, Views = 15, Status = "Công khai" }
            );

            // ===== SEED COMMENTS =====
            modelBuilder.Entity<Comment>().HasData(
                new Comment { CommentId = 1, Content = "Bài hay", PostId = 1, UserId = 4 },
                new Comment { CommentId = 2, Content = "Rất hữu ích", PostId = 1, UserId = 5 },
                new Comment { CommentId = 3, Content = "Hay quá", PostId = 2, UserId = 4 },
                new Comment { CommentId = 4, Content = "Cảm ơn tác giả", PostId = 3, UserId = 5 },
                new Comment { CommentId = 5, Content = "Đọc rất thích", PostId = 4, UserId = 4 }
            );


        }
    }
}