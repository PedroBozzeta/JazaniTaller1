﻿namespace JazaniT1.Application.Mc.Dtos.MiningConcessions
{
    public class MiningConcessionSimpleDto
    {
        public int Id { get; set; }
        public string Code { get; set; } = default;
        public string? Name { get; set; } = default;
        public string? Description { get; set; }
    }
}
