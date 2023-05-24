using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Domain
{
    public class CardJira
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Sprint Sprint { get; set; }
        public EpicFeature Epic { get; set; }
        public EnumEpicStatus EpicStatus { get; set; }
        public string GitBranch { get; set; }
        public bool HasDataContractChanges { get; set; }
        public Developer Developer { get; set; }
        public string JiraNumber { get; set; }
        public bool Active { get; set; }

        public DateTime CreationDate { get; set; }
        IEnumerable<Solution> Solutions { get; set; }
    }
}
