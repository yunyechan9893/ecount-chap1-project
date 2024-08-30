using System;

namespace Data.Entity
{
	public class SaleJoinItemKey : IEntityKey
	{
    }

	public class SaleJoinItem : EntityBase<SaleJoinItemKey>
	{
        public DateTime DATE { get; set; }
        public int NUMBER { get; set; }
        public string CODE { get; set; }
        public string ITEM_NAME { get; set; }
        public string SALE_NAME{ get; set; }
        public int QUANTITY{ get; set; }
        public int PRICE { get; set; }
        public string BRIEFS { get; set; }
    }
}
