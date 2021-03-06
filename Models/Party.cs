namespace Party_Planner.Models
{
  public class Party
  {
    public int Id { get; set; }
    public string CreatorId { get; set; }
    public string Name { get; set; }
    // REVIEW[epic=Populate] This value will be populated when pulled from the DB will not be stored in the db
    // it is effectively a 'virtual'
    public Profile Creator { get; set; }
  }


  // NOTE[epic=many-to-many] Adds the relationshipId to the base class
  public class PartyPartyMemberViewModel : Party
  {
    public int PartyMemberId { get; set; }
  }
}