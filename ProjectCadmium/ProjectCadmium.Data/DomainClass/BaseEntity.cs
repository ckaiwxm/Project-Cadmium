using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjectCadmium.Model.DomainClass
{
    /// <summary>
    /// Primary Key
    /// </summary>
    public class BaseEntity
    {
        [Required, Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }
        /// <summary>
        /// This is only for sorting transactions by number.
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Nth { get; set; }
    }

    /// <summary>
    /// Primary key and publish create metadata
    /// </summary>
    public abstract class PublishCreateMetadata : BaseEntity
    {
        public DateTime CreationDate { get; set; }
        public Guid CreatedById { get; set; }
        public virtual User CreatedBy { get; set; }

    }
}