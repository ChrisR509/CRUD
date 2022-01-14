﻿using MedicalManagment.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalManagment.Models
{
    public class Invoice : IEntity, IAudit
    {
        public Guid Id { get; set; }
        public bool IsCreated { get; set; }
        public string CreatedBy { get; set; } = "";
        public DateTime CreatedOn { get; set; }
        public bool IsUpdated { get; set; }
        public string UpdatedBy { get; set; } = "";
        public DateTime UpdatedOn { get; set; }
        public bool IsDeleted { get; set; }
        public string DeletedBy { get; set; } = "";
        public DateTime DeletedOn { get; set; }
        public string CurrentUser { get; set; } = "";
        public string ClientName { get; set; } = "";
        public ICollection<InvoiceDetail> InvoiceDetails { get; set; }
    }
}
