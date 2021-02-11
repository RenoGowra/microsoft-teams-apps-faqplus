using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using Microsoft.Bot.Sample.SimpleEchoBot;
using Microsoft.Teams.Apps.FAQPlusPlus.Models;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Microsoft.Teams.Apps.FAQPlusPlus.Helpers
{
  public class TasksModuleHelper
  {
    private async HttpResponseMessage HandleInvokeMessages(Activity activity)
    {
      var activityValue = activity.Value.ToString();
        Models.BotFrameworkCardValue<string> action;
        try
        {
          action = JsonConvert.DeserializeObject<Models.TaskModuleActionData<string>>(activityValue).Data;
        }
        catch (Exception)
        {
          action = JsonConvert.DeserializeObject<Models.BotFrameworkCardValue<string>>(activityValue);
        }

        Models.TaskInfo taskInfo = GetTaskInfo(action.Data);
        Models.TaskEnvelope taskEnvelope = new Models.TaskEnvelope
        {
          Task = new Models.Task()
          {
            Type = Models.TaskType.Continue,
            TaskInfo = taskInfo
          }
        };
        return Request.CreateResponse(HttpStatusCode.OK, taskEnvelope);
    }

    private static Models.TaskInfo GetTaskInfo(string actionInfo)
    {
            Models.TaskInfo taskInfo = new Models.TaskInfo();
            taskInfo.Url = taskInfo.FallbackUrl = actionInfo.KnowledgeBaseAnswer;
            taskInfo.Height = 1000;
            taskInfo.Width = 700;
            taskInfo.Title = actionInfo.UserQuestion;
      return taskInfo;
    }
  }
}
