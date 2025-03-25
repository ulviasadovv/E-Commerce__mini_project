namespace ECommerce.Application.DTOs;

public class CategoryDto
{
    public int Id { get; set; }
    public required string Name { get; set; }

}

public class CategoryCreateDto
{
    public required string Name { get; set; }
    public DateTime? createdAt { get; set; } = DateTime.Now;
}

public class CategoryUpdateDto
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public DateTime? UpdatedAt { get; set; } = DateTime.Now;
}