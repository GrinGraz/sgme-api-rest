//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace api_rest_sgmw
{
    using System;
    using System.Collections.Generic;
    
    public partial class MODELOS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MODELOS()
        {
            this.MAQUINAS = new HashSet<MAQUINAS>();
        }
    
        public int MODELO_ID { get; set; }
        public string MODELO_DESCRIPCION { get; set; }
        public int USER_ID { get; set; }
        public Nullable<System.DateTime> CREATED { get; set; }
        public Nullable<System.DateTime> MODIFIED { get; set; }
        public Nullable<bool> DELETED { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MAQUINAS> MAQUINAS { get; set; }
    }
}
