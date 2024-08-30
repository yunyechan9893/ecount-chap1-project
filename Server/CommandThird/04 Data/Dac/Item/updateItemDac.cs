using System.Collections.Generic;
using CommandThird._01_Command;
using Data.Db;
using Data.Entity;

namespace Data.Dac
{
	public class UpdateItemDac : BaseCommand<int>
	{
		public ItemYyc Request { get; set; }
		protected override void ExecuteCore()
		{
			var sql = @"
				UPDATE flow.item
				SET name=@name
				WHERE code=@code
			";

			var parameters = new Dictionary<string, object>() {
				{"@name", Request.NAME },
				{"@code", Request.CODE}
			};

			var dbManager = new DbManager();
			this.Output = dbManager.Execute(sql, parameters);
		}
	}
}
