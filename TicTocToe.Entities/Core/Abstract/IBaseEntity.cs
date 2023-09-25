﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTocToe.Model.Core.Abstract
{
	public interface IBaseEntity
	{
		public int Id { get; set; }
		public Guid SecretId { get; set; }
		public bool IsActive { get; set; }
		public bool IsDeleted { get; set; }
		public DateTime InsertDate { get; set; }
		public DateTime UpdateDate { get; set; }
		public DateTime? DeleteDate { get; set; }
	}
}
