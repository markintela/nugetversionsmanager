using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Domain
{
    public class ManagerVersion
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public CardJira CardJira { get; set; }
        public int Major { get; set; }
        public int Minor { get; set; }
        public int Patch { get; set; }
        public int PreRelease { get; set; }
        public DateTime CreationDate { get; set; }
        public Solution Solution { get; set; }
        public bool Active { get; set; }
    }
}
