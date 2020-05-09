using System;
using System.Collections.Generic;
using System.Text;

namespace KY.Infrastructure.Database
{
    public interface IEntity<PrimaryKeyType>
    {
        /// <summary>
        /// Unique identifier for this entity.
        /// </summary>
        PrimaryKeyType Id { get; set; }

        /// <summary>
        /// Checks if this entity is transient (not persisted to database and it has not an <see cref="Id"/>).
        /// </summary>
        /// <returns>True, if this entity is transient</returns>
        bool IsTransient();

    }
}
