using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Auth.Infrastructure.Extensions
{
    /// <summary>
    /// Removes the cascade delete convention from the model builder
    /// </summary>
    internal static class ModelBuilderExtensions
    {
        internal static void RemoveCascadeDeleteConvension(this ModelBuilder modelBuilder)
        {
            var foreignKeys = modelBuilder.Model
                .GetEntityTypes()
                .SelectMany(entity => entity.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade)
                .ToList();

            // Change the delete behavior of each foreign key to restrict
            foreach (var fk in foreignKeys)
                fk.DeleteBehavior = DeleteBehavior.Restrict;
        }
    }
}
