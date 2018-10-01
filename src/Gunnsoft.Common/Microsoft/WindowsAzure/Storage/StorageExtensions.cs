using Autofac;

namespace Microsoft.WindowsAzure.Storage
{
    public static class StorageExtensions
    {
        public static ContainerBuilder AddStorageAccount
        (
            this ContainerBuilder extended,
            string connectionString
        )
        {
            var storageAccount = CloudStorageAccount.Parse(connectionString);

            extended.RegisterInstance(storageAccount)
                .AsSelf()
                .SingleInstance();

            return extended;
        }
    }
}