﻿namespace JazaniT1.Application.Admins.Dtos.NotificationActions
{
    public class NotificationActionDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = default;
        public string? Description { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool State { get; set; }

    }
}
