﻿namespace BaretProject.Application.DTOs
{
    public class WalletDto : BaseItemDTO
    {
        public bool IsPay { get; set; }
        public int Amount { get; set; }
        public string Description { get; set; }
    }
}
