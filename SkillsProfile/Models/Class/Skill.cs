namespace SkillsProfile.Models.Class
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Skills")]
    public partial class Skill
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Description { get; set; }

        public byte Value { get; set; }
    }
}