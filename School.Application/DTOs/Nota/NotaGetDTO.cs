using System;
using System.Collections.Generic;
using System.Text;

namespace School.Application.DTOs.Nota
{
    public class NotaGetDTO
    {
        public int Id { get; set; }
        public int RegistrationId { get; set; }
        public int ValueNota { get; set; }
        public bool Approved { get; set; }
        public DateTime invoiceDate { get; set; }
    }
}