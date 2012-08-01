// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ForeignKeyConventions.cs" company="Cybk">
//   2012
// </copyright>
// <summary>
//   Indicate the convention used to define the foreign keys
//   on the Database
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Barta.DAL.Conventions
{
    using System.Linq;

    using FluentNHibernate.Conventions;
    using FluentNHibernate.Conventions.Inspections;
    using FluentNHibernate.Conventions.Instances;

    /// <summary>
    /// Indicate the convention used to define the foreign keys 
    /// on the Database
    /// </summary>
    public class ForeignKeyConventions : IReferenceConvention, IHasManyConvention, IHasManyToManyConvention
    {
        /// <summary>
        /// Indicate the convention used to name the primary keys
        /// </summary>
        /// <param name="instance">The instance used to get the name for the column</param>
        public void Apply(IManyToOneInstance instance)
        {
            instance.Column(instance.Name + "Id");
        }

        /// <summary>
        /// Indicate the convetion used to name the Keys on the Many to 
        /// one relations
        /// </summary>
        /// <param name="instance">The instance used to get the name for the column</param>
        public void Apply(IOneToManyCollectionInstance instance)
        {
            var reproperty = instance.ChildType.GetProperties().First(prop => prop.PropertyType == instance.EntityType);
            instance.Key.Column(reproperty.Name + "Id");
        }

        /// <summary>
        /// Indicate the convetion used to name the Keys on the many to many relations
        /// </summary>
        /// <param name="instance">The instance used to get the name for the column</param>
        public void Apply(IManyToManyCollectionInstance instance)
        {
            if (((IManyToManyCollectionInspector)instance.OtherSide).Inverse)
            {
                instance.Table(string.Format("{0}For{1}", instance.EntityType.Name, instance.ChildType.Name));
            }
            else
            {
                instance.Inverse();
            }
        }
    }
}
