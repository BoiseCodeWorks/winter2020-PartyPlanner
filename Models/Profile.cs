namespace Party_Planner.Models
{
  public class Profile
  {
    // REVIEW[epic=Authentication] This Id is a string because it is provided by Auth0
    public string Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Picture { get; set; }
  }
}