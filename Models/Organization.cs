﻿using System.Collections.Generic;

namespace Kolokwium_poprawa.Models
{
    public class Organization
    {
        public int OrganizationID { get; set; }
        public string OrganizationName { get; set; }
        public string OrganizationDomain { get; set; }
        public virtual ICollection<Team> Teams { get; set; }
        public virtual ICollection<Member> Members { get; set; }
    }
}
