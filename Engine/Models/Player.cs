using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Models
{
    public class Player
    {
        string Name { get; set; } // You can "set" a value to Player.Name. You can also "get" the value of Player.Name from somewhere else.
        string CharacterClass { get; set; }
        int HitPoints { get; set; }
        int ExperiencePoints { get; set; }
        int Level { get; set; }
        int Gold { get; set; }
    }
}
