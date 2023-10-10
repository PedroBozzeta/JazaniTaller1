namespace JazaniT1.Domain.Cores.Models
{
    public abstract class CoreModel<ID>
    {
        public ID Id { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool State { get; set; }
    }
}
