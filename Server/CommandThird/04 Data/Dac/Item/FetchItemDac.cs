using System;
using System.Collections.Generic;
using CommandThird._01_Command;
using Data.Db;
using Data.Entity;
using System.Text;

namespace Data.Dac
{
	public class FetchItemDac : BaseCommand<List<ItemYyc>>
	{
		public FetchItemDacRequestDto Request { get; set; }
		protected override void ExecuteCore()
		{
            StringBuilder sql = new StringBuilder(
                @"
				SELECT *
				FROM item_yyc
				WHERE code = @code
			");

            var parameters = new Dictionary<string, object>() {
				{"@code",  Request.Code}
			};

			var dbManager = new DbManager();
			this.Output = dbManager.Query<ItemYyc>(sql.ToString(), parameters, (reader, data) => {
				data.Key.ID = reader.GetInt64(0);
				data.CODE = Request.Code;
				data.NAME = reader["name"].ToString();
			});
		}
	}

	public class FetchItemDacRequestDto
	{
		public string Code { get; set; }
	}
}
