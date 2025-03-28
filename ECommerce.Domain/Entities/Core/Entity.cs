﻿namespace ECommerce.Domain.Entities.Core;

public class Entity
{
    public int Id { get; set; }
    public DateTime? CreatedAt { get; set; } = DateTime.Now;
    public DateTime? UpdatedAt { get; set; }
}
