using System.Data.Entity;

namespace WebApi.Models
{
    public class Initializer : MigrateDatabaseToLatestVersion<CnBContext, Configuration>
    {
    }
}