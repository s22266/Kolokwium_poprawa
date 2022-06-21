﻿using System;

namespace Kolokwium_poprawa.Models
{
    public class Membership
    {
        public int MemberID { get; set; }
        public int TeamID { get; set; }
        public DateTime MembershipDate { get; set; }
        public virtual Member Member { get; set; }
        public virtual Team Team { get; set; }
    }
}
