using Newtonsoft.Json;
using System.Collections.Generic;

namespace WebApplicationAPIV_2.Models
{
  public class ContactModel
  {
    
    public ContactModel()
    {
      Accounts = new List<AccountDetails>();
    }
    [JsonProperty("Id")]
    public int Id { get; set; }
    [JsonProperty("FirstName")]
    public string FirstName { get; set; }
    [JsonProperty("LastName")]
    public string LastName { get; set; }
    [JsonProperty("Email")]
    public string Email { get; set; }
    [JsonProperty("Accounts")]
    public IList<AccountDetails> Accounts { get; set; }
  }
}