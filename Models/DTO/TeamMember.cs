using System;

namespace Kolokwium_poprawa.Models.DTO
{
    public class TeamMember
    {
        public int MemberID { get; set; }
        public int TeamID { get; set; }

        public DateTime MembershipDate { get; set; }

    }
}
