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
	public class FetchSaleDac : BaseCommand<List<Sale>>
	{
		public FetchSaleDacRequestDto Request { get; set; }
        public List<Order<string>> orders = new List<Order<string>>();

        protected override void ExecuteCore()
		{

            StringBuilder sql = new StringBuilder(@"
				SELECT *
				FROM flow.sale_yyc
				WHERE 
                    date = @date AND 
                    number = @number");

            var parameters = new Dictionary<string, object>() {
				{"@date",  Request.Date},
				{"@number",  Request.Number}
            };

			var dbManager = new DbManager();
			this.Output = dbManager.Query<Sale>(sql.ToString(), parameters, (reader, data) => {
				data.Key.DATE = Request.Date;
				data.Key.NUMBER = Request.Number;
				data.CODE = reader["code"].ToString();
                data.QUANTITY = reader.GetInt32(3);
				data.PRICE = reader.GetInt32(4);
                data.BRIEFS = reader["briefs"].ToString(); 
			});
		}
	}

	public class FetchSaleDacRequestDto
    {
		public DateTime Date { get; set; }
		public int Number { get; set; }
    }
}
