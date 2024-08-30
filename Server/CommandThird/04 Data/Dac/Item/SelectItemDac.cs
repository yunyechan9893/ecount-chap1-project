using System;
using System.Collections.Generic;
using CommandThird._01_Command;
using Data.Db;
using Data.Entity;
using System.Text;

namespace Data.Dac
{
	public class SelectItemDac : BaseCommand<List<ItemYyc>>
	{
		public SelectItemDacRequestDto Request { get; set; }
		protected override void ExecuteCore()
		{
            StringBuilder sql = new StringBuilder(
                @"
				SELECT *
				FROM flow.item
				WHERE id > @id
				LIMIT 10;
			");

            var parameters = new Dictionary<string, object>() {
				{"@id",  Request.Id}
			};

			var dbManager = new DbManager();
			this.Output = dbManager.Query<ItemYyc>(sql.ToString(), parameters, (reader, data) => {
				data.Key.ID = Request.Id;
                data.CODE = reader["code"].ToString();
                data.NAME = reader["name"].ToString();
			});
		}
	}

	public class SelectItemDacRequestDto
	{
		public long Id { get; set; }
    }
}
