﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entity
{
	public class ItemKey : IEntityKey
	{
		public long ID { get; set; }
	}

	public class ItemYyc : EntityBase<ItemKey>
	{
		public string CODE { get; set; }
		public string NAME { get; set; }
	}
}
