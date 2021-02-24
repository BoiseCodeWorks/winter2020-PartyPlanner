namespace Party_Planner.Models
{
  public class PartyMember
  {
    // REVIEW[epic=many-to-many] Join Table object
    public int Id { get; set; }
    public string ProfileId { get; set; }
    public int PartyId { get; set; }
  }
}