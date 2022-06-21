using System.Collections.Generic;

namespace Kolokwium_poprawa.Models.DTO
{
    public class SomeSortOfTeam
    {
        public string TeamName { get; set; }
        public string TeamDescription { get; set; }
        public string OrganizationName { get; set; }
        public List<TeamMember> Members { get; set; }
    }
}
