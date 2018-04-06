using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace IndexWordsInTexts
{
    public partial class SearchWords
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SearchWords()
        {
            Texts = new HashSet<Texts>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string SearchWord { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<Texts> Texts { get; set; }
    }
}
