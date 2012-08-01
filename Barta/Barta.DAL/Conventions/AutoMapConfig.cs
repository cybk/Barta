// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AutoMapConfig.cs" company="Cybk">
//   2012
// </copyright>
// <summary>
//   The Namespace used configure the automapping.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Barta.DAL.Conventions
{
    using FluentNHibernate.Automapping;

    /// <summary>
    /// The Namespace used configure the automapping.
    /// </summary>
    public class AutoMapConfig : DefaultAutomappingConfiguration
    {
        /// <summary>
        /// Indicate the namespace from where
        /// all the classes should be mapped.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>if the class should be mapped</returns>
        public override bool ShouldMap(System.Type type)
        {
            return type.Namespace == "Barta.DAL.Entities";
        }
    }
}
