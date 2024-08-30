using System.Collections.Generic;
using CommandThird._01_Command;
using Data.Db;
using Data.Entity;

namespace Data.Dac
{
	public class UpdateSaleDac : BaseCommand<int>
	{
		public Sale Request { get; set; }
		protected override void ExecuteCore()
		{
			var sql = @"
				UPDATE flow.sale_yyc
				SET 
					code=@code,
					quantity=@quantity,
					price=@price,
					briefs=@briefs
				WHERE date = @date AND number = @number
			";

			var parameters = new Dictionary<string, object>() {
				{"@code", Request.Key.DATE },
				{"@quantity", Request.Key.NUMBER },
				{"@price", Request.CODE},
				{"@prod_cd", Request.QUANTITY},
				{"@briefs", Request.PRICE},
            };

			var dbManager = new DbManager();
			this.Output = dbManager.Execute(sql, parameters);
		}
	}
}
