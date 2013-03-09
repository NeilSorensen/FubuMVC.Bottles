using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SampleFubuApplication.DataAccess;

namespace SampleFubuApplication.TaskListView
{
    public class TaskListController
    {
        public TaskList TaskList(TaskListInput input)
        {
            return new TaskList
                {
                    WorkItems = new List<WorkItem>
                        {
                            new WorkItem {ID = 1, TaskName = "Create a sample Fubu App", Completed = true, CompletedDate = DateTime.Today},
                            new WorkItem {ID = 2, TaskName = "Add FubuMVC.Diagnostics"},
                            new WorkItem {ID = 3, TaskName = "Create a bottle"}
                        }
                };
        }
    }

    public class TaskList
    {
        public List<WorkItem> WorkItems { get; set; }
    }

    public class TaskListInput
    {
        public int UserId { get; set; }
    }
}