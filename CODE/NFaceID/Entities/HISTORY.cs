namespace NFaceID.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HISTORY")]
    public partial class HISTORY
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        public int? ID_PER { get; set; }

        public DateTime TIME_UPDATE { get; set; }

        public bool? IN_OUT { get; set; }

        [Required]
        public string IMG_FACE { get; set; }

        [Required]
        public string IMG { get; set; }

        public string GHICHU { get; set; }

        public virtual PERSONAL PERSONAL { get; set; }
    }
}
