namespace NFaceID.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EMPLOYEE")]
    public partial class EMPLOYEE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EMPLOYEE()
        {
            ATTENDANCEs = new HashSet<ATTENDANCE>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        public int? ID_PS { get; set; }

        [Required]
        [StringLength(50)]
        public string NAME { get; set; }

        [Required]
        [StringLength(3)]
        public string GENDER { get; set; }

        [Required]
        [StringLength(20)]
        public string PHONE { get; set; }

        [Column(TypeName = "date")]
        public DateTime BIRTHDAY { get; set; }

        public string ADDRESS_EMP { get; set; }

        [Required]
        [StringLength(12)]
        public string CMT { get; set; }

        [StringLength(200)]
        public string EMAIL { get; set; }

        public string IMG_FACE { get; set; }

        public bool? ISDELETE { get; set; }

        public string GHICHU { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ATTENDANCE> ATTENDANCEs { get; set; }

        public virtual PERSONAL PERSONAL { get; set; }
    }
}
