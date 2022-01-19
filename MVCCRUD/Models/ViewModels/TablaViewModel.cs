using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCCRUD.Models.ViewModels
{
    public class TablaViewModel
    {
        //Guardar nuevo registro
        public int Id { get; set; }
        //DataAnnotations
        [Required]
        [StringLength(50)]
        [Display(Name ="Nombre")]
        public string Nombre { get; set; }
        [Required]
        [StringLength(50)]
        [EmailAddress]
        [Display(Name = "Correo electronico")]
        public string Correo { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Nacimiento")]
        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaNacimiento { get; set; }
        [Required]
        [Display(Name = "Direccion")]
        public string Direccion { get; set; }
    }
}