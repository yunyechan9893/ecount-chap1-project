using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommandThird;
using CommandThird._01_Command;
using Data.Db;
using Data.Entity;

namespace Data.Dac
{
	public class SelectSaleDac : BaseCommand<List<SaleJoinItem>>
	{
		public SelectSaleDacRequestDto Request { get; set; }
        public List<Order<string>> orders = new List<Order<string>>();

        protected override void ExecuteCore()
		{

            var sql = @"
				SELECT 
                    s.date as date,
                    s.number as number,
                    s.code as code,
                    i.name as item_name,
                    s.quantity as quantity,
                    s.price as price,
                    s.briefs as briefs,
				FROM flow.sale_yyc as s
                WHERE 
                    s.date > @date AND 
                    s.number > @number
                JOIN flow.item as i 
                    ON i.code = s.code
                ORDER BY s.date asc, s.number desc
                LIMIT 10
			";

            Console.WriteLine(sql.ToString());

            var parameters = new Dictionary<string, object>() {
				{"@date",  Request.Date},
                {"@date",  Request.Number}
            };

			var dbManager = new DbManager();
			this.Output = dbManager.Query<SaleJoinItem>(sql.ToString(), parameters, (reader, data) => {
				data.DATE = reader.GetDateTime(0);
				data.NUMBER = reader.GetInt32(1);
                data.CODE = reader["code"].ToString();
                data.ITEM_NAME = reader["item_name"].ToString();
                data.QUANTITY = reader.GetInt32(4);
                data.PRICE = reader.GetInt32(5);
                data.BRIEFS = reader["briefs"].ToString();
			});
		}
	}

	public class SelectSaleDacRequestDto
    {
		public DateTime Date { get; set; }
        public int Number{ get; set; }
    }
}
