using CodigoTransitoReader.Domain.Abstractions;

namespace CodigoTransitoReader.Domain.Users;

public sealed class User : Entity
{
    public string? ClientId { get; set; }
    public Name? Name { get; set; }
    public LastName? LastName { get; set; }
    public Email? Email { get; set; }
    public DateOnly BirthDate { get; set; }
    public PlanType PlanType { get; set; }
}