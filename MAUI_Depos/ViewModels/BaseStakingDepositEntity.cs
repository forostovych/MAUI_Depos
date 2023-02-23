using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI_Depos.ViewModels
{
    public class BaseStakingDepositEntity
    {
        public int Id { get; set; }

        [Required]
        public string Account { get; set; }

        public int StakingOptionEntityId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime FinishDate { get; set; }

        public DateTime? UnstakeDate { get; set; }

        public string DepositTransactionHash { get; set; }

        public bool IsUnstakeRequested { get; set; }

        public bool IsUnstaked { get; set; }

        public int? UnStakeTransactionId { get; set; }

        public decimal Amount { get; set; }
    }
}
