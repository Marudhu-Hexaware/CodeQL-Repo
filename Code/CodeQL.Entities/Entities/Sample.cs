
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeQL.Entities.Entities
{
    public class Sample
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id  { get; set; }
        public string Name  { get; set; }
        public int Age  { get; set; }
        public string Gender  { get; set; }
        public int _Id  { get; set; }
        
    }

}
