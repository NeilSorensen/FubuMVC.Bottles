using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FubuMVC.Core;
using SampleFubuApplication.TaskListView;

namespace SampleFubuApplication.App_Start
{
    public class ConfigureFubuMVC : FubuRegistry
    {
        public ConfigureFubuMVC()
        {
            Actions.IncludeClassesSuffixedWithController();

            Routes.IgnoreControllerNamespaceEntirely()
                .IgnoreClassNameForType<TaskListController>()
                .HomeIs<TaskListController>(x => x.TaskList(new TaskListInput{UserId = 1}));
        }
    }
}