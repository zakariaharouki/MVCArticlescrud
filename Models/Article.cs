using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MVCArticlescrud.Models
{
    [Table ("Articles", Schema ="dbo")]
    public class Article
    {
        [Key]
        [DatabaseGenerated (DatabaseGeneratedOption.Identity)]
        [Display(Name ="ID")]
        public int ID { get; set; }
        [Required]
        [Column (TypeName = "nvarchar(255)")]
        [Display (Name ="Title")]
        public string Title { get; set; }
        [Required (ErrorMessage = "Please choose a file to upload.")]
        [Column(TypeName = "nvarchar(255)")]
        [Display(Name = "image")]
        public string image { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date")]
        [DisplayFormat(DataFormatString = "{0: dd-MMM-yyy}")]
        public DateTime Date { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(255)")]
        [Display(Name = "Summary")]
        public string Summary { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(255)")]
        [Display(Name = "Body")]
        public string Body { get; set; }
    }
}
