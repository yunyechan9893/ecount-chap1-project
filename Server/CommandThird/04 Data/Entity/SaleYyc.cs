using System;

namespace Data.Entity
{
	public class SaleYycKey : IEntityKey
	{
		public DateTime DATE { get; set; }
		public int NUMBER { get; set; }
    }

	public class SaleYyc : EntityBase<SaleYycKey>
	{
        public string CODE { get; set; }
		public string NAME { get; set; }
        public int QUANTITY { get; set; }
        public int PRICE { get; set; }
        public string BRIEFS { get; set; }

    }
}
