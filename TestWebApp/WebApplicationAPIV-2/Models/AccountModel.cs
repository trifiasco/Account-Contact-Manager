using Newtonsoft.Json;
using System.Collections.Generic;

namespace WebApplicationAPIV_2.Models
{
  public class AccountModel
  {
    public AccountModel()
    {
      Contacts = new List<ContactDetails>();
    }
    [JsonProperty("Id")]
    public int Id { get; set; }
    [JsonProperty("Name")]
    public string Name { get; set; }

    [JsonProperty("Contacts")]
    public IList<ContactDetails> Contacts { get; set; }

  }
}