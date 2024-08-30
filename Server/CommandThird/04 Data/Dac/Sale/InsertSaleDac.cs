using System.Collections.Generic;
using CommandThird._01_Command;
using Data.Db;
using Data.Entity;

namespace Data.Dac
{
	public class InsertSaleDac : BaseCommand<int>
	{
		public Sale Request { get; set; }
		protected override void ExecuteCore()
		{
			var sql = @"
				INSERT INTO flow.sale_yyc (date, number, code, name, quantity, price, briefs)
				VALUES (@date, @number, @code, @name, @quantity, @price, @briefs)
			";

			var parameters = new Dictionary<string, object>() {
				{"@date", Request.Key.DATE },
				{"@number", Request.Key.NUMBER },
				{"@code", Request.CODE },
				{"@name", Request.NAME },
				{"@quantity", Request.QUANTITY },
                {"@price", Request.PRICE},
				{"@briefs", Request.BRIEFS}
            };

			var dbManager = new DbManager();
			this.Output = dbManager.Execute(sql, parameters);
		}
	}
}
