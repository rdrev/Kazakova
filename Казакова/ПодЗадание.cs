//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Казакова
{
    using System;
    using System.Collections.Generic;
    
    public partial class ПодЗадание
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ПодЗадание()
        {
            this.ЗадачиСотрудники = new HashSet<ЗадачиСотрудники>();
        }
    
        public int КодПодзадание { get; set; }
        public string Название { get; set; }
        public bool СтатусПодЗадание { get; set; }
        public string КомментарийПодЗадание { get; set; }
        public int Задача { get; set; }
    
        public virtual Задание Задание { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ЗадачиСотрудники> ЗадачиСотрудники { get; set; }
    }
}
