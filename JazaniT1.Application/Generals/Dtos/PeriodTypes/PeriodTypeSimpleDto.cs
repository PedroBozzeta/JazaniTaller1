﻿namespace JazaniT1.Application.Generals.Dtos.PeriodTypes
{
    public class PeriodTypeSimpleDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = default;
        public string? Description { get; set; }
        public int Time { get; set; }
    }
}
