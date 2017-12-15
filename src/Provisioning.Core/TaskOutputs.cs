using Cake.Frosting;

namespace Provisioning.Core
{
    public class TaskOutputs : DynamicPropertyBag
    {
        public void AddTaskOutput<TTaskType>(dynamic output) where TTaskType : FrostingTask<ProvisioningContext>
        {
            RawProperties.Add(typeof(TTaskType).Name, output);
        }

        public T GetTaskOutput<T>(string taskClassName)
        {
            if (RawProperties.TryGetValue(taskClassName, out var result))
                return (T)result;

            return default(T);
        }

        public T GetTaskOutput<TTaskType, T>()
        {
            return GetTaskOutput<T>(typeof(TTaskType).Name);
        }
    }
}
