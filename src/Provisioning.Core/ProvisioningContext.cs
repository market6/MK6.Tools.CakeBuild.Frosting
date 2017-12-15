using MK6.Tools.CakeBuild.Frosting;
using Cake.Core;
using Cake.Frosting;

namespace Provisioning.Core
{
    public class ProvisioningContext : DynamicContext
    {
        public ScmRepositoryOptions ScmRepositoryOptions { get; set; }
        public ProjectGenOptions ProjectGenOptions { get; set; }
        public dynamic TaskOutputs { get; set; }
        public GitLocalOptions GitLocalOptions { get; set; }
        public ProvisioningContext(ICakeContext context) : base(context)
        {
            TaskOutputs = new TaskOutputs();
        }

        public void AddTaskOutput<T>(dynamic output) where T : FrostingTask<ProvisioningContext>
        {
            TaskOutputs.AddTaskOutput<T>(output);
        }

        public T GetTaskOutput<T>(string taskClassName)
        {
            return TaskOutputs.GetTaskOutput<T>(taskClassName);
        }

        public T GetTaskOutput<TTaskType, T>()
        {
            return TaskOutputs.GetTaskOutput<TTaskType, T>();
        }
    }
}
