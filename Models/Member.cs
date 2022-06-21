﻿using System.Collections.Generic;

namespace Kolokwium_poprawa.Models
{
    public class Member
    {
        public int MemberID { get; set; }
        public string MemberName { get; set; }
        public string MemberSurName { get; set; }
        public string? MemberNickName { get; set; }

        public int OrganizationID { get; set; }
        public virtual Organization Organization { get; set; }
        public virtual ICollection<Membership> Memberships { get; set; }
    }
}
