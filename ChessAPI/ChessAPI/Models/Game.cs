namespace ChessAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Game
    {
        public int ID { get; set; }

        [StringLength(255)]
        public string FEN { get; set; }

        [StringLength(4)]
        public string STATUS { get; set; }
    }
}
