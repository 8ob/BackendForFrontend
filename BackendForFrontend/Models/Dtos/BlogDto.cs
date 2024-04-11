namespace BackendForFrontend.Models.DTOs
{
    public static class BlogDto
    {
        public class CreatePostDto
        {
            public string Title { get; set; }
            public string Content { get; set; }
            public int AuthorId { get; set; }
            public string Slug { get; set; }
            public bool IsPublished { get; set; }
        }

        public class UpdatePostDto
        {
            public string Title { get; set; }
            public string Content { get; set; }
            public string Slug { get; set; }
            public bool IsPublished { get; set; }
        }

        public class CreateCategoryDto
        {
            public string Name { get; set; }
            public string Description { get; set; }
        }

        public class UpdateCategoryDto
        {
            public string Name { get; set; }
            public string Description { get; set; }
        }

        public class CreateTagDto
        {
            public string Name { get; set; }
        }

        public class UpdateTagDto
        {
            public string Name { get; set; }
        }

        public class CreateCommentDto
        {
            public int PostId { get; set; }
            public int? UserId { get; set; }
            public int? EmployeeId { get; set; }
            public string Content { get; set; }
        }

        public class UpdateCommentDto
        {
            public int UserId { get; set; }
            public string Content { get; set; }
        }

        public class LoginDto
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }
    }
}
