namespace NFaceID.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ATTENDANCE")]
    public partial class ATTENDANCE
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        public int? ID_EMP { get; set; }

        public string IMG_IN { get; set; }

        public string IMG_OUT { get; set; }

        [Column(TypeName = "date")]
        public DateTime DATE_ATT { get; set; }

        public TimeSpan? TIME_IN { get; set; }

        public TimeSpan? TIME_OUT { get; set; }

        public string GHICHU { get; set; }

        public virtual EMPLOYEE EMPLOYEE { get; set; }
    }
}
