using System;

namespace Data.Entity
{
	public class SaleKey : IEntityKey
	{
		public DateTime DATE { get; set; }
		public int NUMBER { get; set; }
    }

	public class Sale : EntityBase<SaleKey>
	{
        public string CODE { get; set; }
        public int QUANTITY{ get; set; }
        public int PRICE { get; set; }
        public string BRIEFS { get; set; }
    }
}
