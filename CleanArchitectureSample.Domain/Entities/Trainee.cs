using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureSample.Domain.Entities
{
    public class Trainee
    {
        [Key] public int TraineeId { get; set; }
        public string TraineeName { get; set; } = string.Empty;
    }
}
