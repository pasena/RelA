// <auto-generated />
namespace RelA.Domain.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Migrations.Infrastructure;
    
    public sealed partial class TaskStatusIsDefault : IMigrationMetadata
    {
        string IMigrationMetadata.Id
        {
            get { return "201207080351244_TaskStatusIsDefault"; }
        }
        
        string IMigrationMetadata.Source
        {
            get { return null; }
        }
        
        string IMigrationMetadata.Target
        {
            get { return "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"; }
        }
    }
}
