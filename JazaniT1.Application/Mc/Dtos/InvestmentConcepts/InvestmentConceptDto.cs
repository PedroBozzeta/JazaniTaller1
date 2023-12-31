﻿namespace JazaniT1.Application.Mc.Dtos.InvestmentConcepts
{
    public class InvestmentConceptDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = default;
        public string? Description { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool State { get; set; }
    }
}
