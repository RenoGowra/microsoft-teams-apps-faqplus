

namespace Microsoft.Teams.Apps.FAQPlusPlus.Models
{
  using Newtonsoft.Json;
  public class BotFrameworkCardValue<T>
  {
    [JsonProperty("type")]
    public object Type { get; set; } = "task/fetch";

    [JsonProperty("data")]
    public T Data { get; set; }
  }
  public class TaskModuleActionData<T>
  {
    [JsonProperty("data")]
    public BotFrameworkCardValue<T> Data { get; set; }
  }
}
