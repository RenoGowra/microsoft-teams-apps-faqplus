using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.Teams.Apps.FAQPlusPlus.Models
{
  public static class TaskModuleResponseFactory
  {
    public static TaskModuleResponse CreateResponse(string message)
    {
      return new TaskModuleResponse
      {
        Task = new TaskModuleMessageResponse()
        {
          Value = message,
        },
      };
    }

    public static TaskModuleResponse CreateResponse(TaskInfo taskInfo)
    {
      return new TaskModuleResponse
      {
        Task = new TaskModuleContinueResponse()
        {
          Value = taskInfo,
        },
      };
    }

    public static TaskModuleResponse ToTaskModuleResponse(this TaskInfo taskInfo)
    {
      return CreateResponse(taskInfo);
    }
  }
}
